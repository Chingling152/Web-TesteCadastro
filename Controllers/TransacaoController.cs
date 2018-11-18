using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_TesteCadastroMVC.Models;

namespace Web_TesteCadastroMVC.Controllers
{
    public class TransacaoController : Controller
    {
        private int contador = System.IO.File.Exists("Databases/Transacao.csv")?System.IO.File.ReadAllLines("Databases/Transacao.csv").Length +1 : 1;
        [HttpGet]
        public ActionResult Cadastrar(){
            string id = HttpContext.Session.GetString("ID");
            
            if(string.IsNullOrEmpty(id) || id != "0"){
                return RedirectToAction("Login","Usuario");
            }else{
                return View();
            }
        }        

        [HttpPost]
        public ActionResult Cadastrar(IFormCollection formulario){
            Transacao tra = new Transacao(){
                NumeroTransacao = contador++,
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

        [HttpGet]
        public ActionResult Mostrar(){
            if(string.IsNullOrEmpty(HttpContext.Session.GetString("emailUsuario"))){
                return RedirectToAction("Login","Usuario");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Mostrar(IFormCollection formulario){
            List<Transacao> transacoes = new List<Transacao>();
            StreamReader reader = new StreamReader("Databases/Transacao.csv",true);

            List<string> nomes = new List<string>();

            while(!reader.EndOfStream){             
                string[] info = reader.ReadLine().Split(';');
                Transacao t = new Transacao(){
                    NumeroTransacao = int.Parse(info[0]),
                    Descricao = info[1],
                    tipo = info[2],
                    valor = double.Parse(info[3]),
                    data = System.DateTime.Parse(info[4])
                };
                transacoes.Add(t);
            }
            return View();
        }
    }
}