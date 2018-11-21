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
        private const string caminho = "Databases/Usuario.csv";
        private int contador = System.IO.File.Exists(caminho)?System.IO.File.ReadAllLines(caminho).Length +1 : 1;
        private string id;

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
                using(StreamWriter sw = new StreamWriter(caminho,true)){
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

            using(StreamReader leitor = new StreamReader(caminho)){
                while(!leitor.EndOfStream){
                    string[] info = leitor.ReadLine().Split(';');

                    if(usuario.Email == info[2].ToLower()  && usuario.Senha == info[3].ToLower()){
                        flag = true;
                        //usuario.ID = int.Parse(info[0]);
                        HttpContext.Session.SetString("ID",usuario.ID.ToString());
                        //ViewData["Usuario"] = usuario;
                        ViewBag.Mensagem = $"Seja bem vindo {usuario.Nome} !";
                        return RedirectToAction("Logado","Usuario");
                    }
                }
            }

            if(!flag) 
                ViewBag.Mensagem = "Email ou senha incorretos";

            return View();
        }  
        #endregion

        #region Validações
        private static string tudoOK(Usuario user){
            if(string.IsNullOrEmpty(user.Nome)){
                return "Nome invalido!!";
            }
            if(string.IsNullOrEmpty(user.Senha)){
                return "Senha invalida!!";
            }
            return $"Usuario {user.Nome} cadastrado com sucesso";
        }

        public static bool Admin(Usuario user){
            if(user.Tipo == "Administrador"){
                return true;
            }else{
                return false;
            }
        }

        public static Usuario Procurar(int id){
            
            Usuario usuario = new Usuario();

            using(StreamReader leitor = new StreamReader(caminho)){
                while(!leitor.EndOfStream){
                    string[] info = leitor.ReadLine().Split(';');
                    
                    if(id.ToString() == info[0]){
                        usuario.ID = int.Parse(info[0]);
                        usuario.Nome = info[1];
                        usuario.Email = info[2];
                        usuario.Senha = info[3];
                        usuario.Tipo = info[4];
                        usuario.DataNascimento = DateTime.Parse(info[5]);
                        break;
                    }
                }
            }
            return usuario;
        }
        #endregion

        #region Logado
        [HttpGet]
        public ActionResult Logado(){
            id = HttpContext.Session.GetString("ID"); 

            if(string.IsNullOrEmpty(id) || id != "0"){
                return RedirectToAction("Login","Usuario");
            }else{
                return View();
            }
        }
        #endregion
    }

}