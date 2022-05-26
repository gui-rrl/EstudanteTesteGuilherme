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
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Estudante_SelecionarFiltro(Filtro filtro)
        {
            List<Estudante> lista = new List<Estudante>();
            lista = SelecionarFiltro(filtro);
            var retorno = new
            {
                data = lista
            };
            return new JsonResult(retorno);
        }   
        
        public ActionResult EstudanteEditar()
        {
            Estudante estudante = new Estudante();
            estudante = Selecionar(estudante.Identificador);
            return new JsonResult(estudante);
        }

        public string EstudanteInserir_Alterar(Estudante estudante)
        {
            string identificador = Convert.ToInt32(estudante.Identificador).ToString();
            
            if(identificador != default(string))
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