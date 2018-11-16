using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Web_TesteCadastroMVC.Models;
using System;
using System.IO;

namespace Web_TesteCadastroMVC.Controllers
{
    public class TarefaController : Controller
    {
        private int contador = System.IO.File.Exists("Databases/Tarefas.csv")?System.IO.File.ReadAllLines("Databases/Tarefas.csv").Length +1 : 1;
        [HttpGet]
        public ActionResult Criar(){
            string id = HttpContext.Session.GetString("ID");
            
            if(string.IsNullOrEmpty(id) || id != "0"){
                return RedirectToAction("Login","Usuario");
            }else{
                return View();
            }
        }

        [HttpPost]
        public ActionResult Criar(IFormCollection form){
            Tarefa tarefa = new Tarefa(){
                ID = contador++,
                Titulo = form["Nome"],
                Descricao = form["Descricao"],
                Status = form["Status"],
                DataInicio = DateTime.Now,
                SetDataEntrega = DateTime.Parse(form["Data"]),
                IDUsuario = int.Parse(HttpContext.Session.GetString("ID"))
            };

            using (StreamWriter sw = new StreamWriter("Databases/Tarefas.scv"))
            {
                sw.WriteLine($"{tarefa.ID};{tarefa.Titulo};{tarefa.Descricao};{tarefa.Status};{tarefa.DataInicio};{tarefa.GetDataEntrega};{tarefa.IDUsuario}");
            }

            ViewBag.Mensagem = $"Tarefa {tarefa.IDUsuario} Cadastrado com sucesso!";
            
            return View();
        }
    }
}