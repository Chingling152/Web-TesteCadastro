using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Financas.Transacoes.Models;

namespace Projeto.Financas.Transacoes.Controllers
{
    public class TransacaoController : Controller
    {
        [HttpGet]
        public ActionResult Cadastrar(){
            if(string.IsNullOrEmpty(HttpContext.Session.GetString("emailUsuario"))){
                return RedirectToAction("Login","Usuario");
            }
            return View();
        }        

        [HttpPost]
        public ActionResult Cadastrar(IFormCollection formulario){
            Transacao tra = new Transacao(){
                NumeroTransacao = new System.Random().Next(1000,100000),
                Descricao = formulario["Descricao"],
                valor = double.Parse(formulario["Valor"]),
                tipo = formulario["TipoTransacao"],
                data = System.DateTime.Parse(formulario["DataTransacao"])
            };
            using(StreamWriter sw = new StreamWriter("Transacao.csv",true)){
                sw.WriteLine($"{tra.NumeroTransacao};{tra.Descricao};{tra.tipo};{tra.valor};{tra.data}");
            }
            ViewBag.Mensagem = $"Transação {tra.NumeroTransacao} cadastrada com sucesso!";
            return View();
        }
    }
}