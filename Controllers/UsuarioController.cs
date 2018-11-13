using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinancas.Models;

namespace ProjetoFinancas.Classes.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult Cadastrar() => View();

        [HttpPost]
        public ActionResult Cadastrar(IFormCollection form) {
            Usuario usuario = new Usuario(){
                Nome = form["Nome"],
                Email = form["Email"],
                Senha = form["Senha"],
                data = System.DateTime.Parse(form["DataNascimento"])
            };

            using(StreamWriter sw = new StreamWriter("Usuario.csv",true)){
                sw.WriteLine($"{usuario.Nome};{usuario.Email};{usuario.Senha};{usuario.data}");
            }

            ViewBag.Mensagem = "Você é gay oniichan ≧◡≦";
            return RedirectToAction("Login","Usuario");
        }
        [HttpGet]
        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult Login(IFormCollection colletion){
            Usuario usuario = new Usuario(){
                Email = colletion["Email"],
                Senha = colletion["Senha"]
            };
            using(StreamReader sr = new StreamReader("Usuario.csv")){
                while(!sr.EndOfStream){
                    string[] info = sr.ReadLine().Split(';');

                    if(usuario.Email == info[1] && usuario.Senha == info[2]){
                        HttpContext.Session.SetString("emailUsuario",usuario.Email);
                        return RedirectToAction("Cadastrar","Transacao");
                    }
                }
            }

            ViewBag.Mensagem = "Usuario Invalido!";
            
            return View();
        }
    }
}