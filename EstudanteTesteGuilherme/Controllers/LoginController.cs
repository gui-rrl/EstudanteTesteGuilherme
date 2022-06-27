using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using Microsoft.AspNetCore.Session;
using System.Web;
using Models;
using static Models.Usuario;

namespace EstudanteTesteGuilherme.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult CadastroUsuario(int identificador)
        {
            Usuario usuario = new Usuario();
            if (RouteData.Values["id"] != null)
            {
                usuario = SelecionarPorIdentificador(Convert.ToInt32(RouteData.Values["id"]));
            }
            return View(usuario);
        }

        [HttpPost]
        public JsonResult Usuario_ChecarLogin(Usuario usuarioInformado)
        {
            int codigo;

            if (Usuario.Logar(usuarioInformado) == true)
            {
                HttpContext.Session.SetString("emailSessao", JsonConvert.SerializeObject(usuarioInformado.Email));
                HttpContext.Session.SetString("usuarioSessao", JsonConvert.SerializeObject(usuarioInformado));
                codigo = 1;
            }

            else
            {
                codigo = 0;

            }
            return Json(new JsonResult(new {codigo}));
        }

        public int Usuario_InserirAtualizar(Usuario usuario)
        {
            int identificador = usuario.Identificador;

            if (identificador != 0)
            {
                Alterar(usuario);
                return identificador;
            }

            else
            {
                Inserir(usuario);
                return identificador;
            }
        }

        public void Deslogar()
        {
            HttpContext.Session.Clear();
            Response.Redirect("/Login/Login");
        }
    }
}