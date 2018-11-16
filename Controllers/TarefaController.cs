using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Web_TesteCadastroMVC.Models;

namespace Web_TesteCadastroMVC.Controllers
{
    public class TarefaController : Controller
    {
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
                ID = System.IO.File.ReadAllLines("Databases/Tarefas.csv").Length +1
            };
            return View();
        }
    }
}