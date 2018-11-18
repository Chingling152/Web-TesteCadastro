using System.IO;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Web_TesteCadastroMVC.Models;

namespace Web_TesteCadastroMVC.Controllers
{
    public class UsuarioController : Controller
    {

        private int contador = System.IO.File.Exists("Databases/Usuario.csv")?System.IO.File.ReadAllLines("Databases/Usuario.csv").Length +1 : 1;
       
        #region Cadastrar
        [HttpGet]
        public ActionResult Cadastrar(){
            ViewBag.Mensagem = "";
            return View();
        }
        
        [HttpPost]
        public ActionResult Cadastrar(IFormCollection form){
            Usuario usuario = new Usuario(){
                ID = contador++,
                Nome = form["Nome"],
                Email = form["Email"].ToString().ToLower(),
                Senha = form["Senha"],
                Tipo = form["Tipo"],
                DataNascimento = DateTime.Parse(form["DataNascimento"])
            };  
            string mensagem = tudoOK(usuario);

            if(mensagem == $"Usuario {usuario.Nome} cadastrado com sucesso"){
                using(StreamWriter sw = new StreamWriter("Databases/Usuario.csv",true)){
                    sw.WriteLine($"{usuario.ID};{usuario.Nome};{usuario.Email};{usuario.Senha};{usuario.Tipo};{usuario.DataNascimento}");
                }
                return RedirectToAction("Login","Usuario");
            }else{
                ViewBag.Erro = mensagem;
                return View();
            }
        }
        #endregion
        
        #region Logar
        [HttpGet]
        public ActionResult Login()=> View();

        [HttpPost]
        public ActionResult Login(IFormCollection form){
            Usuario usuario = new Usuario(){
                Email = form["Email"],
                Senha = form["Senha"]
            };

            bool flag = false;
            using(StreamReader leitor = new StreamReader("Databases/Usuario.csv")){
                while(!leitor.EndOfStream){
                    string[] info = leitor.ReadLine().Split(';');

                    if(usuario.Email == info[2].ToLower()  && usuario.Senha == info[3]){
                        flag = true;
                        HttpContext.Session.SetString("ID",usuario.ID.ToString());
                        ViewBag.Mensagem = $"Seja bem vindo {usuario.Nome} !";
                        return RedirectToAction("Logado","Usuario");
                    }
                }
            }

            if(!flag) 
                ViewBag.Mensagem = "Email ou senha incorretos";

            return View();
        }  

        private string tudoOK(Usuario user){
            if(string.IsNullOrEmpty(user.Nome)){
                return "Nome invalido!!";
            }
            if(string.IsNullOrEmpty(user.Senha)){
                return "Senha invalida!!";
            }
            return $"Usuario {user.Nome} cadastrado com sucesso";
        }
        #endregion

        #region Logado
        [HttpGet]
        public ActionResult Logado(){
            string id = HttpContext.Session.GetString("ID"); 

            if(string.IsNullOrEmpty(id) || id != "0"){
                return RedirectToAction("Login","Usuario");
            }else{
                return View();
            }
        }
        #endregion
    }

}