﻿using Microsoft.AspNetCore.Mvc;
using NLog;
using RestSharp;
using GestionTareaWeb.Models;
using GestionTareaWeb.Servicios;
using Utf8Json;
using JsonSerializer = Utf8Json.JsonSerializer;

namespace GestionTareaWeb.Controllers
{
    public class AccountController : Controller
    {
     

        Boolean visibleAccount = false;
        private readonly IConfiguration configuration;
        static HttpClient client = new HttpClient();
        private RestClient _apiClient;
        private RestClient _appAutogoClient;
        private static Logger _log = LogManager.GetLogger("Account");
        private string responseContent { get; }
        private AccountService _AccountService;
        //AjaxResposeOK ok = new AjaxResposeOK();
        //AjaxResposeErr err = new AjaxResposeErr();

        // GET: AccountController
        public AccountController(IConfiguration configuration)
        {
            this.configuration = configuration;
            _apiClient = new RestClient(configuration["APIClient"]);//RestClient(baseURL);
            //_apiClient.ThrowOnAnyError = true;
            //_apiClient.Timeout = 120000;
            //_apiClient.UseUtf8Json();
            _AccountService = new AccountService(configuration);
        }

        public async Task<ActionResult> Index(Login model)
        {

//#if DEBUG

//#elif

//#endif
            var request = new RestRequest("/api/cuentas/login", Method.Post/*, DataFormat.Json*/);
            request.AddJsonBody(new { email = model.User, password = model.Password });
            request.AddJsonBody(model);
            TempData["menu"] = null;
            try
            {
                if (model.Password != null && model.User != null)
                {
                    if (ModelState.IsValid)
                    {
                        _log.Info("Iniciando Auterticacion");
                        var response = await _apiClient.ExecuteAsync(request, Method.Post);
                        _log.Info("Verificando credenciales");
                        if (response.IsSuccessful)
                        {
                            LogedDataViewModel LogedData = JsonSerializer.Deserialize<LogedDataViewModel>(response.Content);
                            // Crear una cookie para almacenar el token
                            Response.Cookies.Append("token", LogedData.token);
                            Response.Cookies.Append("expiracion", LogedData.expiracion.ToString());
                            Response.Cookies.Append("user", model.User);
                            //TempData["MensajeExito"] = "Ingreso Exitoso";
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensajeError"] = "No se pudo iniciar sesion contactese con soporte !";
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
                //return RedirectToAction("Index", "Home");
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

        public ActionResult CerrarSession()
        {
            Response.Cookies.Delete("token");
            Response.Cookies.Delete("expiracion");
            Response.Cookies.Delete("username");
            return RedirectToAction(nameof(Index));
        }
    }
}