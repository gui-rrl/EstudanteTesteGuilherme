using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Models;
using EstudanteTesteGuilherme.Models;
using static Models.Estudante;
using static Models.Estudante.Filtro;

namespace EstudanteTesteGuilherme.Controllers
{
    public class EstudanteController : Controller
    {
        public IActionResult Estudante()
        {
            return View();
        }

        public JsonResult Estudante_SelecionarFiltro(Filtro filtro)
        {
            List<Estudante> lista = new List<Estudante>();
            lista = SelecionarFiltro(filtro);
            
            return Json(new JsonResult(lista));
        }

        public IActionResult EstudanteEditar()
        {
            Estudante estudante = new Estudante();
            if(RouteData.Values["id"] != null)
            {
                estudante = Selecionar(Convert.ToInt32(RouteData.Values["id"]));
            }

            return View(estudante);
        }

        //public IActionResult EstudanteEditar()
        //{
        //    Estudante estudante = new Estudante();
        //    estudante = Selecionar(estudante.Identificador);

        //    return new JsonResult(estudante);
        //}

        public int EstudanteEditar_Alterar(Estudante estudante)
        {
            int identificador = estudante.Identificador;
            
            if(identificador != 0)
            {
                Alterar(estudante);
                return identificador;
            }

            else
            {
                Inserir(estudante);
                return identificador;
            }
        }
    }
}