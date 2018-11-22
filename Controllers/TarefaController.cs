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
        private TarefaDatabase database;
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
            /*id = HttpContext.Session.GetString("ID");

            if(string.IsNullOrEmpty(id) || id != "0"){
                return RedirectToAction("Login","Usuario");
            }else{*/
                Tarefa tarefa = database.Cadastrar(new Tarefa(){
                    Titulo = form["Titulo"],
                    Descricao = form["Descricao"],
                    Status = form["Status"],
                    DataInicio = DateTime.Now,
                    SetDataEntrega = DateTime.Parse(form["Data"]),
                    IDUsuario = int.Parse(id)
                });

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
            string[] linhas = System.IO.File.ReadAllLines(caminho);
            id = HttpContext.Session.GetString("ID");

            for (int i = 0; i < linhas.Length; i++)
            {
                string[] linha = linhas[i].Split(";");

                if(ID.ToString() == linha[0]){
                    if(id == linha[linha.Length-1]){
                        ViewBag.Mensagem = $"Tarefa no id {id} deletado com sucesso";
                        linhas[i] = "";
                    }else{
                        ViewBag.Mensagem = $"Você não tem permissão para apagar essa tarefa";
                    }
                }
            }

            System.IO.File.WriteAllLines(caminho,linhas);

            return RedirectToAction("Mostrar","Tarefa");
        }
    }
}