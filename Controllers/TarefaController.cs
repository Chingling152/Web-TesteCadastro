using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Web_TesteCadastroMVC.Models;
using System;
using System.IO;

namespace Web_TesteCadastroMVC.Controllers
{
    public class TarefaController : Controller
    {
        private int contador = System.IO.File.Exists("Databases/Tarefa.csv")?System.IO.File.ReadAllLines("Databases/Tarefa.csv").Length +1 : 1;
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
            string id = HttpContext.Session.GetString("ID");

            if(string.IsNullOrEmpty(id) || id != "0"){
                return RedirectToAction("Login","Usuario");
            }else{
                Tarefa tarefa = new Tarefa(){
                    ID = contador++,
                    Titulo = form["Titulo"],
                    Descricao = form["Descricao"],
                    Status = form["Status"],
                    DataInicio = DateTime.Now,
                    SetDataEntrega = DateTime.Parse(form["Data"]),
                    IDUsuario = int.Parse(id)
                };

                using (StreamWriter sw = new StreamWriter("Databases/Tarefa.csv",true))
                {
                    sw.WriteLine($"{tarefa.ID};{tarefa.Titulo};{tarefa.Descricao};{tarefa.Status};{tarefa.DataInicio};{tarefa.GetDataEntrega};{tarefa.IDUsuario}");
                }

                ViewBag.Mensagem = $"Tarefa {tarefa.Titulo} Cadastrada no ID {tarefa.ID} com sucesso!";
                
                return View();
            }
        }
    }
}