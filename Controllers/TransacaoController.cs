using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_TesteCadastroMVC.Models;

namespace Web_TesteCadastroMVC.Controllers
{
    public class TransacaoController : Controller
    {
        private const string caminho = "Databases/Transacao.csv";
        private int contador = System.IO.File.Exists(caminho)?System.IO.File.ReadAllLines(caminho).Length +1 : 1;
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
            string id = HttpContext.Session.GetString("ID");

            if(string.IsNullOrEmpty(id) || id != "0"){
                return RedirectToAction("Login","Usuario");
            }else{
                Transacao tra = new Transacao(){
                    NumeroTransacao = contador++,
                    Descricao = formulario["Descricao"],
                    valor = double.Parse(formulario["Valor"]),
                    tipo = formulario["TipoTransacao"],
                    data = System.DateTime.Parse(formulario["DataTransacao"]),
                    IDUsuario = int.Parse(id)
                };

                using(StreamWriter sw = new StreamWriter(caminho,true)){
                    sw.WriteLine($"{tra.NumeroTransacao};{tra.Descricao};{tra.tipo};{tra.valor};{tra.data};{tra.IDUsuario}");
                }

                ViewBag.Mensagem = $"Transação {tra.NumeroTransacao} cadastrada com sucesso!";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Mostrar(){
            if(string.IsNullOrEmpty(HttpContext.Session.GetString("ID"))){
                return RedirectToAction("Login","Usuario");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Mostrar(IFormCollection formulario){

            List<Transacao> transacoes = new List<Transacao>();
            StreamReader reader = new StreamReader(caminho,true);

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