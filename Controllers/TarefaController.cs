using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Web_TesteCadastroMVC.Models;
using System;
using System.IO;
using System.Collections.Generic;
using Web_TesteCadastroMVC.Repositorio;

namespace Web_TesteCadastroMVC.Controllers
{
    public class TarefaController : Controller
    {
        #region Criar   
        private TarefaDatabase database = new TarefaDatabase();
        private string id;
        [HttpGet]
        public ActionResult Criar(){
            id = HttpContext.Session.GetString("ID");
            
            if(string.IsNullOrEmpty(id) || id == "0"){
                return RedirectToAction("Login","Usuario");
            }else{
                return View();
            }
        }

        [HttpPost]
        public ActionResult Criar(IFormCollection form){
            id = HttpContext.Session.GetString("ID");
            /*
            if(string.IsNullOrEmpty(id) || id != "0"){
                return RedirectToAction("Login","Usuario");
            }else{*/

                Tarefa tarefa = database.Cadastrar(new Tarefa(
                    form["Titulo"],
                    form["Descricao"],
                    form["Status"],
                    form["Data"],
                    id
                ));
                ViewBag.Mensagem = $"Tarefa {tarefa.Titulo} Cadastrada no ID {tarefa.ID} com sucesso!";
                
                return View();
            //}
        }
        #endregion

        #region Mostrar
        [HttpGet]
        public ActionResult Mostrar(){
            id = HttpContext.Session.GetString("ID");
            List<Tarefa> tarefas = database.Listar(id);
            ViewData["ListarTarefas"] = tarefas;
            return View();
        }
        #endregion

        public ActionResult Excluir(int ID){
            id = HttpContext.Session.GetString("ID");

            if(database.Excluir(ID.ToString(),id)){
                ViewBag.Mensagem = $"Tarefa no id {id} deletado com sucesso";
            }else{
                ViewBag.Mensagem = $"Você não tem permissão para apagar essa tarefa";
            }
            return RedirectToAction("Mostrar","Tarefa");
        }

        [HttpGet]
        public ActionResult Editar(int ID){
            if(ID != 0){
                Tarefa tarefa = database.Procurar(ID.ToString());
                Usuario user = new UsuarioDatabase().Procurar(tarefa.IDUsuario.ToString());
                //Finalizar isso ;-;
                //https://github.com/corujasdevbr/Senai_Financas_Web_Mvc_Manha
                return View();
            }else{
                return RedirectToAction("Logado","Usuario");
            }
        }
        
        [HttpPost]
        public ActionResult Editar(IFormCollection form){
            
            return RedirectToAction("Mostrar","Tarefa");
        }

    }
}