using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_TesteCadastroMVC.Models;
using Web_TesteCadastroMVC.Repositorio;

namespace Web_TesteCadastroMVC.Controllers {
    public class UsuarioController : Controller {

        private UsuarioDatabase database = new UsuarioDatabase ();
        private string id;

        #region Cadastrar
        [HttpGet]
        public ActionResult Cadastrar () => View ();

        [HttpPost]
        public ActionResult Cadastrar (IFormCollection form) {

            string[] valores = {
                "0",
                form["Nome"],
                form["Email"].ToString ().ToLower (),
                form["Senha"],
                form["Tipo"],
                form["DataNascimento"]    
            };

            Usuario usuario = database.Cadastrar (new Usuario(valores));

            if (usuario == null) {
                ViewBag.Mensagem = "Esse Email Já existe";
                return View ();
            } else {

                return RedirectToAction ("Login", "Usuario");
            }
        }
        #endregion

        #region Logar
        [HttpGet]
        public ActionResult Login () => View ();

        [HttpPost]
        public ActionResult Login (IFormCollection form) {
            Usuario usuario = database.Logar (form["Email"].ToString ().ToLower (), form["Senha"].ToString ().ToLower ());

            if (usuario == null) {
                ViewBag.Mensagem = "Email ou senha incorretos";
            } else {
                HttpContext.Session.SetString ("ID", usuario.ID.ToString ());
                return RedirectToAction ("Logado", "Usuario");
            }

            return View ();
        }
        #endregion

        [HttpGet]
        public ActionResult Logado () {
            id = HttpContext.Session.GetString ("ID");

            if (string.IsNullOrEmpty (id) || id == "0") { //verifica se o id é nulo ou 0
                return RedirectToAction ("Login", "Usuario"); //redireciona para pagina de login
            } else { //se não for nulo e não for igual a 0
                //procura o id do usuario e cria um objeto do tipo usuario
                Usuario user = database.Procurar (id);

                // Salva o usuario
                ViewData["UsuarioLogado"] = user;
                ViewBag.Mensagem = $"Seja bem vindo {user.Nome}!";
                return View ();
            }
        }

        [HttpGet]
        public ActionResult Mostrar () {           
            List<Usuario> usuarios = database.Listar ();
            ViewData["Usuarios"] = usuarios;

            return View ();
        }

        [HttpGet]
        public ActionResult Excluir (string ID) {
            id = HttpContext.Session.GetString ("ID");

            if (database.Excluir (ID)) {
                ViewBag.Mensagem = $"Usuario no id {id} deletado com sucesso";
            } else {
                ViewBag.Mensagem = $"Não existe usuario no id {id}";
            }
            return RedirectToAction ("Mostrar", "Usuario");

        }

        [HttpGet]
        public ActionResult Editar (int ID) {
            id = HttpContext.Session.GetString ("ID");
            database.Procurar (id);
            return View ();
        }
    }
}