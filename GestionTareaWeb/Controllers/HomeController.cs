using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLog.Fluent;
using RestSharp;
using SendGrid;
using System.Diagnostics;
using GestionTareaWeb.Models;
using GestionTareaWeb.Servicios;
using Utf8Json;
using NLog;

namespace GestionTareaWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorioProyectos repositorioProyectos;
        private readonly IServicioEmail servicioEmail;
        private readonly IConfiguration configuration;
        private static Logger _log = LogManager.GetLogger("Account");
        private RestClient _apiClient;
        private string responseContent { get; }
        private AccountService _AccountService;
        public HomeController(
            IRepositorioProyectos repositorioProyectos, IServicioEmail servicioEmail , IConfiguration configuration
            )
        {
            this.configuration = configuration;
            this.repositorioProyectos = repositorioProyectos;
            this.servicioEmail = servicioEmail;
            _AccountService = new AccountService(configuration);
            _apiClient = new RestClient(configuration["APIClient"]);
        }

        public async Task<IActionResult> Index()
        {
            HomeIndexViewModel model = new();
            model.ListaUsuarios = await ApiRequest<List<UsuariosInformacion>>("/api/cuentas/ListarUsuario");
            model.ListaTaskViewModel = await ApiRequest<List<TaskViewModels>>("/api/TaskEstudiantes/Listar");
            TempData["menu"] = "";
            return View(model);
        }

        public async Task<T> ApiRequest<T>(string endpoint)
        {
            try
            {
                string tokenValue = Request.Cookies["token"];
                var client = new RestClient(configuration["APIClient"]);
                var request = new RestRequest(endpoint, Method.Get);

                //copiar y pegar en el resto de controladores
                request.AddParameter("Authorization", string.Format("Bearer " + tokenValue), ParameterType.HttpHeader);
                //------------------------------------------
                var response = client.Execute(request);

                if (response.Content != null && response.IsSuccessful == true)
                {
                    var content = response.Content;

                    return System.Text.Json.JsonSerializer.Deserialize<T>(content);

                }
                else
                {
                    throw new Exception("");
                }
            }
            catch(Exception e)
            {
                return default(T);
            } 
        }



        [HttpPost]
        public async Task<ActionResult> GuardaryEditarInfoTarea(ItemUsuarioTarea model)
        {
            string tokenValue = Request.Cookies["token"];

            var request = new RestRequest("/api/TaskEstudiantes/Registrar", Method.Post/*, DataFormat.Json*/);

            //copiar y pegar en el resto de controladores
            request.AddParameter("Authorization", string.Format("Bearer " + tokenValue), ParameterType.HttpHeader);
            //------------------------------------------

            if (model.idTask == 0)
            {
                request.AddJsonBody(new { idtask = 0, idEstuduante = model.usuarioId, descripcion = model.tarea });
            }
            else
            {
                request.AddJsonBody(new { idtask = model.idTask, idEstuduante = model.usuarioId, descripcion = model.tarea });
            }

            request.AddJsonBody(model);

            if (model.tarea == null)
            {
                TempData["MensajeError"] = "Rellene todos los campos";
                return Redirect("Index");
            }

            try
            {
                if (model.tarea != null)
                {
                    if (ModelState.IsValid)
                    {
                        _log.Info("Accediendo al API");
                        var response = await _apiClient.ExecuteAsync(request, Method.Post);
                        _log.Info("Registrando Cabezal "/* + Tipo*/);
                        if (response.IsSuccessful)
                        {
                            if (model.idTask == 0)
                            {
                                TempData["MensajeExito"] = "Registro Exitoso";
                            }
                            else
                            {
                                TempData["MensajeExito"] = "Se edito correctamente";
                            }
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensajeError"] = "No  se puedo registrar";
                        return RedirectToAction("Index", "Home");
                    }
                    TempData["MensajeError"] = "Rellene todos los campos";
                }
                return View(model);
            }
            catch (JsonParsingException e)
            {
                _log.Error(e, "Error Obteniendo Token");
                _log.Error(e.GetUnderlyingStringUnsafe());
                TempData["MensajeError"] = e.Message.ToString();
                return View(model);
            }
            catch (Exception e)
            {
                _log.Error(e, "Error al iniciar sesión");
                _log.Error(responseContent);
                TempData["MensajeError"] = e.Message;
                return Redirect("Index");
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteInformacionTarea(ItemUsuarioTarea model)
        {
            string tokenValue = Request.Cookies["token"];
            long id = model.idTask;
            if (id > 0)
            {
                var request = new RestRequest("/api/TaskEstudiantes/Deshabilitar", Method.Post/*, DataFormat.Json*/);

                //copiar y pegar en el resto de controladores
                request.AddParameter("Authorization", string.Format("Bearer " + tokenValue), ParameterType.HttpHeader);
                //------------------------------------------

                request.AddQueryParameter("idTask", model.idTask);
                //   request.AddJsonBody(model);

                try
                {
                    if (model.idTask != 0)
                    {
                        if (ModelState.IsValid)
                        {
                            _log.Info("Accediendo al API");
                            var response = await _apiClient.ExecuteAsync(request, Method.Post);
                            // _log.Info("Registrando Tipo de" + Tipo);
                            //responseContent = ;
                            if (response.IsSuccessful)
                            {
                                // LogedDataViewModel LogedData = JsonSerializer.Deserialize<LogedDataViewModel>(response.Content);

                                // Crear una cookie para almacenar el token
                                //Response.Cookies.Append("token", LogedData.token);
                                //Response.Cookies.Append("expiracion", LogedData.expiracion.ToString());
                                // Response.Cookies.Append("user", model.User);

                                TempData["MensajeExito"] = "Eliminacion Exitosa";

                                return RedirectToAction("Index", "Home");
                            }
                            TempData["MensajeError"] = response.Content;
                            return View(model);
                        }
                        TempData["MensajeError"] = "No se pudo eliminar la tarea";
                    }
                    return View(model);
                }
                catch (Exception e)
                {
                    _log.Error(e, "Error al iniciar sesión");
                    _log.Error(responseContent);
                    TempData["MensajeError"] = e.Message;
                    return Redirect("Index");
                }
            }
            return RedirectToAction("Index", "Home");
        }



        public IActionResult Proyectos()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos();
            return View(proyectos);
        }

        [HttpGet]
        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contacto(ContactoViewModel contactoViewModel)
        {
            await servicioEmail.Enviar(contactoViewModel);
            return RedirectToAction("Gracias");
        }

        public IActionResult Gracias()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}