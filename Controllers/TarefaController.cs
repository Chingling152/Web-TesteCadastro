using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Projeto.Financas.Transacoes.Controllers
{
    public class TarefaController : Controller
    {
        [HttpGet]
        public ActionResult Criar(){
            if(string.IsNullOrEmpty(HttpContext.Session.GetString("ID"))){
                return RedirectToAction("Login","Usuario");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Criar(IFormCollection form){
            return View();
        }
    }
}