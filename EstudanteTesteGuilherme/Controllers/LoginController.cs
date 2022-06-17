using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using Microsoft.AspNetCore.Session;
using System.Web;
using Models;

namespace EstudanteTesteGuilherme.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Usuario_ChecarLogin(Usuario usuarioInformado)
        {
            int codigo;

            if (Usuario.Logar(usuarioInformado) == true)
            {
                HttpContext.Session.SetString("usuarioSessao", JsonConvert.SerializeObject(usuarioInformado));
                codigo = 1;
            }

            else
            {
                codigo = 0;

            }
            return Json(new JsonResult(new {codigo}));
        }
    }
}