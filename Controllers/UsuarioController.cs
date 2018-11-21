using System.IO;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Web_TesteCadastroMVC.Models;
using Web_TesteCadastroMVC.Util;

namespace Web_TesteCadastroMVC.Controllers
{
    public class UsuarioController : Controller
    {
        private const string caminho = "Databases/Usuario.csv";
        private int contador = System.IO.File.Exists(caminho)?System.IO.File.ReadAllLines(caminho).Length +1 : 1;
        private string id;

        #region Cadastrar
        [HttpGet]
        public ActionResult Cadastrar()=> View();

        
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
            string mensagem = Validacao.LoginUsuario(usuario);

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
        public ActionResult Login(IFormCollection form) {    
            string Email = form["Email"].ToString().ToLower();
            string Senha = form["Senha"].ToString().ToLower();   

            bool flag = false;

            using(StreamReader leitor = new StreamReader(caminho)){
                while(!leitor.EndOfStream){
                    string[] info = leitor.ReadLine().Split(';');

                    if(Email == info[2].ToLower() && Senha == info[3].ToLower()){
                        flag = true;

                        Usuario usuario = Validacao.ProcurarUsuario(info[0]);
                        
                        HttpContext.Session.SetString("ID",usuario.ID.ToString());
                        
                        return RedirectToAction("Logado","Usuario");
                    }
                }
            }

            if(!flag) 
                ViewBag.Mensagem = "Email ou senha incorretos";

            return View();
        }  
        #endregion

        [HttpGet]
        public ActionResult Logado(){
            id = HttpContext.Session.GetString("ID"); 

            if(string.IsNullOrEmpty(id) || id == "0"){
                return RedirectToAction("Login","Usuario");
            }else{
                Usuario user = Validacao.ProcurarUsuario(id);

                ViewData["TipoUsuario"] = user.Tipo;
                ViewBag.Mensagem = $"Seja bem vindo {user.Nome}!";

                return View();
            }
        }

        [HttpGet]
        public ActionResult Mostrar(){
            id = HttpContext.Session.GetString("ID");

            List<Usuario> usuario = new List<Usuario>();

            string[] linhas = System.IO.File.ReadAllLines(caminho);

            foreach (string item in linhas)
            {
                if(string.IsNullOrEmpty(item)){
                    continue;
                }else{
                    Usuario user = Validacao.ProcurarUsuario(item.Split(";")[0]);

                    if(user !=null){
                        usuario.Add(user);
                    }
                }
            }

            ViewData["Usuarios"] = usuario;

            return View();
        }

        [HttpGet]
        public ActionResult Excluir(int ID){
            string[] linhas = System.IO.File.ReadAllLines(caminho);
            id = HttpContext.Session.GetString("ID");

            for (int i = 0; i < linhas.Length; i++)
            {
                string[] linha = linhas[i].Split(";");

                if(ID.ToString() == linha[0]){
                    ViewBag.Mensagem = $"Tarefa no id {id} deletado com sucesso";
                    linhas[i] = "";
                }
            }

            System.IO.File.WriteAllLines(caminho,linhas);

            return RedirectToAction("Mostrar","Usuario");
        }

    }
}