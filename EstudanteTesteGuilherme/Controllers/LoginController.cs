using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using Microsoft.AspNetCore.Session;
using System.Web;
using static Models.Usuario;
using Models;

namespace EstudanteTesteGuilherme.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public void ChecarLogin(Usuario usuarioInformado)
        {

            Logar(usuarioInformado);          
            //HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(usuario));
            Response.Redirect("/Estudante/Estudante");
        }
    }
}