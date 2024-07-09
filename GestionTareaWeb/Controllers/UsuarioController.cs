using Microsoft.AspNetCore.Mvc;
using NLog;
using RestSharp;
using SendGrid;
using GestionTareaWeb.Models;
using GestionTareaWeb.Servicios;
using Utf8Json;

namespace GestionTareaWeb.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IConfiguration configuration;

        private RestClient _apiClient;
        private RestClient _appAutogoClient;
        private static Logger _log = LogManager.GetLogger("Account");
        private string responseContent { get; }


        public UsuarioController(IConfiguration configuration)
        {
            this.configuration = configuration;
            _apiClient = new RestClient(configuration["APIClient"]);//RestClient(baseURL);
      
          
        }



        public IActionResult Index()
        {
            UsuarioViewModel  model = new UsuarioViewModel();

            string tokenValue = Request.Cookies["token"];
            var client = new RestClient(configuration["APIClient"]);
            var request = new RestRequest("/api/cuentas/ListarUsuario", Method.Get);

            request.AddParameter("Authorization", string.Format("Bearer " + tokenValue), ParameterType.HttpHeader);

            var response = client.Execute(request);

            if (response.Content != null)
            {
                var content = response.Content;

                List<ItemsUsuarios> ListaUsuario = System.Text.Json.JsonSerializer.Deserialize<List<ItemsUsuarios>>(content);
                model.itemUsuario = ListaUsuario;
            }
            else
            {
                model.itemUsuario = null;
            }

             request = new RestRequest("/api/cuentas/ListarRoles", Method.Get);

            request.AddParameter("Authorization", string.Format("Bearer " + tokenValue), ParameterType.HttpHeader);

             response = client.Execute(request);

            if (response.Content != null)
            {
                var content = response.Content;

                List<ItemRoles> ListaUsuarioRoles = System.Text.Json.JsonSerializer.Deserialize<List<ItemRoles>>(content);
                model.ListaItemRoles = ListaUsuarioRoles;
            }
            else
            {
                model.ListaItemRoles = null;
            }

            TempData["menu"] = "";

            return View(model);
        }


        public IActionResult IndexRoles()
        {
            UsuarioViewModel model = new UsuarioViewModel();

            string tokenValue = Request.Cookies["token"];
            var client = new RestClient(configuration["APIClient"]);
            var request = new RestRequest("/api/cuentas/ListarRoles", Method.Get);

            request.AddParameter("Authorization", string.Format("Bearer " + tokenValue), ParameterType.HttpHeader);

          var  response = client.Execute(request);

            if (response.Content != null)
            {
                var content = response.Content;

                List<ItemRoles> ListaUsuarioRoles = System.Text.Json.JsonSerializer.Deserialize<List<ItemRoles>>(content);
                model.ListaItemRoles = ListaUsuarioRoles;
            }
            else
            {
                model.ListaItemRoles = null;
            }

            TempData["menu"] = "";

            return View(model);
        }

        
        public async Task<ActionResult> DeleteInformacion(UsuarioViewModel model)
        {
            string tokenValue = Request.Cookies["token"];
            var client = new RestClient(configuration["APIClient"]);
            var request = new RestRequest("/api/Cuentas/EliminarUsuario", Method.Post/*, DataFormat.Json*/);

            //copiar y pegar en el resto de controladores
            request.AddParameter("Authorization", string.Format("Bearer " + tokenValue), ParameterType.HttpHeader);
            //------------------------------------------ 
            if (model.id != null)
            {
                request.AddJsonBody(new { id = model.id });
            }


            request.AddJsonBody(model);



            try
            {

                if (ModelState.IsValid)
                {
                    _log.Info("Accediendo al API");
                    var response = await _apiClient.ExecuteAsync(request, Method.Post);
                    _log.Info("Registrando Rol "/* + Tipo*/);
                    if (response.IsSuccessful)
                    {

                        TempData["MensajeExito"] = " Usuario Eliminado Correctamente";



                        return RedirectToAction("Index", "Usuario");
                    }
                    TempData["MensajeError"] = "No se puede eliminar el  usuario";
                    return RedirectToAction("Index", "Usuario");
                }
                TempData["MensajeError"] = "No se puede eliminar el  usuario";
                return RedirectToAction("Index", "Usuario");
            }
            catch (JsonParsingException e)
            {
                _log.Error(e, "Error Obteniendo Token");
                _log.Error(e.GetUnderlyingStringUnsafe());
                TempData["MensajeError"] = e.Message.ToString();
                return RedirectToAction("Index", "Usuario");
            }
            catch (Exception e)
            {
                _log.Error(e, "Error al iniciar sesión");
                _log.Error(responseContent);
                TempData["MensajeError"] = e.Message;
                return RedirectToAction("Index", "Usuario");
            }
        }

        public async Task<ActionResult> GuardarUsuarioRol(UsuarioViewModel model)
        {
            string tokenValue = Request.Cookies["token"];
            var client = new RestClient(configuration["APIClient"]);
            var request = new RestRequest("/api/Cuentas/GuardarUsuarioRol", Method.Post/*, DataFormat.Json*/);

            //copiar y pegar en el resto de controladores
            request.AddParameter("Authorization", string.Format("Bearer " + tokenValue), ParameterType.HttpHeader);
            //------------------------------------------ 
            if (model.id != null)
            {
                request.AddJsonBody(new { idUser = model.id, idRol = model.idRol });
            }
           

            request.AddJsonBody(model);



            try
            {

                if (ModelState.IsValid)
                {
                    _log.Info("Accediendo al API");
                    var response = await _apiClient.ExecuteAsync(request, Method.Post);
                    _log.Info("Registrando Rol "/* + Tipo*/);
                    if (response.IsSuccessful)
                    {
                      
                            TempData["MensajeExito"] = " Rol de Usuario asignado de Manera Exitosa";
                       
                       

                        return RedirectToAction("Index", "Usuario");
                    }
                    TempData["MensajeError"] = "No se pudo Guardar el Rol del usuario";
                    return RedirectToAction("Index", "Usuario");
                }
                TempData["MensajeError"] = "No se pudo Guardar el Rol del usuario";
                return RedirectToAction("Index", "Usuario");
            }
            catch (JsonParsingException e)
            {
                _log.Error(e, "Error Obteniendo Token");
                _log.Error(e.GetUnderlyingStringUnsafe());
                TempData["MensajeError"] = e.Message.ToString();
                return RedirectToAction("Index", "Usuario");
            }
            catch (Exception e)
            {
                _log.Error(e, "Error al iniciar sesión");
                _log.Error(responseContent);
                TempData["MensajeError"] = e.Message;
                return RedirectToAction("Index", "Usuario");
            }
        }

        public async Task<ActionResult> GuardarUsuario(UsuarioViewModel model)
        {
            string tokenValue = Request.Cookies["token"];
            var client = new RestClient(configuration["APIClient"]);
            var request = new RestRequest("/api/Cuentas/GuardarUsuarios", Method.Post/*, DataFormat.Json*/);

            //copiar y pegar en el resto de controladores
            request.AddParameter("Authorization", string.Format("Bearer " + tokenValue), ParameterType.HttpHeader);
            //------------------------------------------ 
            if (model.id == null)
            {
                request.AddJsonBody(new { id = "", nombre = model.nombre , 
                                          apellido = model.apellido, 
                                          correo = model.correo ,
                                          telefono = model.telefono , 
                                          contrasenia = model.contrasenia,
                                          tipoRol = model.idRol
                });
            }
            else
            {
                request.AddJsonBody(new { id = model.id,
                    nombre = model.nombre,
                    apellido = model.apellido,
                    correo = model.correo,
                    telefono = model.telefono, 
                    contrasenia = model.contrasenia,
                    tipoRol = model.idRol
                });
            }

            request.AddJsonBody(model);

        

            try
            {
         
                    if (ModelState.IsValid)
                    {
                        _log.Info("Accediendo al API");
                        var response = await _apiClient.ExecuteAsync(request, Method.Post);
                        _log.Info("Registrando Rol "/* + Tipo*/);
                        if (response.IsSuccessful && Convert.ToBoolean(response.Content) == true)
                        {
                          
                                TempData["MensajeExito"] = "Registro Usuario de Manera Exitosa";
                            
                        
                           

                            return RedirectToAction("Index", "Usuario");
                        }
                    TempData["MensajeExito"] = "Registro Usuario de Manera Exitosa";
                    return RedirectToAction("Index", "Usuario");
                }
                TempData["MensajeError"] ="No se pudo Guardar el usuario";
                return RedirectToAction("Index", "Usuario");
            }
            catch (JsonParsingException e)
            {
                _log.Error(e, "Error Obteniendo Token");
                _log.Error(e.GetUnderlyingStringUnsafe());
                TempData["MensajeError"] = e.Message.ToString();
                return RedirectToAction("Index", "Usuario");
            }
            catch (Exception e)
            {
                _log.Error(e, "Error al iniciar sesión");
                _log.Error(responseContent);
                TempData["MensajeError"] = e.Message;
                return RedirectToAction("Index", "Usuario");
            }
        }
            public async Task<ActionResult> GuardaryEditarInfoRoles(UsuarioViewModel model)
        {
            string tokenValue = Request.Cookies["token"];
            var client = new RestClient(configuration["APIClient"]);
            var request = new RestRequest("/api/Cuentas/NuevoRol", Method.Post/*, DataFormat.Json*/);

            //copiar y pegar en el resto de controladores
            request.AddParameter("Authorization", string.Format("Bearer " + tokenValue), ParameterType.HttpHeader);
            //------------------------------------------

            if (model.idRol == null)
            {
                request.AddJsonBody(new { id = "", descripcion = model.descripcionRoles});
            }
            else
            {
                request.AddJsonBody(new { id = model.idRol, descripcion = model.descripcionRoles });
            }

            request.AddJsonBody(model);

            if (model.descripcionRoles == null)
            {
                TempData["MensajeError"] = "Rellene todos los campos";
                return RedirectToAction("IndexRoles", "Usuario");
            }

            try
            {
                if (model.descripcionRoles != null)
                {
                    if (ModelState.IsValid)
                    {
                        _log.Info("Accediendo al API");
                        var response = await _apiClient.ExecuteAsync(request, Method.Post);
                        _log.Info("Registrando Rol "/* + Tipo*/);
                        if (response.IsSuccessful)
                        {
                            if (model.idRol == null)
                            {
                                TempData["MensajeExito"] = "Registro Exitoso";
                            }
                            else
                            {
                                TempData["MensajeExito"] = "Se edito correctamente";
                            }
                            return RedirectToAction("IndexRoles", "Usuario");
                        }
                        TempData["MensajeError"] = response.Content;
                        return View(model);
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


        public async Task<ActionResult> EliminarRoles(UsuarioViewModel model)
        {
            string tokenValue = Request.Cookies["token"];
            var client = new RestClient(configuration["APIClient"]);
            var request = new RestRequest("/api/Cuentas/EliminarRol", Method.Post/*, DataFormat.Json*/);

            //copiar y pegar en el resto de controladores
            request.AddParameter("Authorization", string.Format("Bearer " + tokenValue), ParameterType.HttpHeader);
            //------------------------------------------

            if (model.idRol == null)
            {
                request.AddJsonBody(new { id = "", descripcion = model.descripcionRoles });
            }
            else
            {
                request.AddJsonBody(new { id = model.idRol, descripcion = model.descripcionRoles });
            }

         

          

            try
            {
              
                    if (ModelState.IsValid)
                    {
                        _log.Info("Accediendo al API");
                        var response = await _apiClient.ExecuteAsync(request, Method.Post);
                        _log.Info("Eliminando Rol "/* + Tipo*/);
                        if (response.IsSuccessful)
                        {
                            if (model.idRol != null)
                            {
                                TempData["MensajeExito"] = "Eliminación Exitosa";
                            }
                          
                            return RedirectToAction("IndexRoles", "Usuario");
                        }
                        TempData["MensajeError"] = response.Content;
                        return View(model);
                    }
                    TempData["MensajeError"] = "No se Eliminó Correctamente";
                
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


    }
}
