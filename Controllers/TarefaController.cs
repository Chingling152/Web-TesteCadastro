using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Web_TesteCadastroMVC.Models;
using System;
using System.IO;
using System.Collections.Generic;

namespace Web_TesteCadastroMVC.Controllers
{
    public class TarefaController : Controller
    {
        #region Criar
        private const string caminho = "Databases/Tarefa.csv";
        private int contador = System.IO.File.Exists(caminho)?System.IO.File.ReadAllLines(caminho).Length +1 : 1;     
        private string id;
        [HttpGet]
        public ActionResult Criar(){
            id = HttpContext.Session.GetString("ID");
            
            if(string.IsNullOrEmpty(id) || id != "0"){
                return RedirectToAction("Login","Usuario");
            }else{
                return View();
            }
        }

        [HttpPost]
        public ActionResult Criar(IFormCollection form){
            string id = HttpContext.Session.GetString("ID");

            if(string.IsNullOrEmpty(id) || id != "0"){
                return RedirectToAction("Login","Usuario");
            }else{
                Tarefa tarefa = new Tarefa(){
                    ID = contador++,
                    Titulo = form["Titulo"],
                    Descricao = form["Descricao"],
                    Status = form["Status"],
                    DataInicio = DateTime.Now,
                    SetDataEntrega = DateTime.Parse(form["Data"]),
                    IDUsuario = int.Parse(id)
                };

                using (StreamWriter sw = new StreamWriter(caminho,true))
                {
                    sw.WriteLine($"{tarefa.ID};{tarefa.Titulo};{tarefa.Descricao};{tarefa.Status};{tarefa.DataInicio};{tarefa.GetDataEntrega};{tarefa.IDUsuario}");
                }

                ViewBag.Mensagem = $"Tarefa {tarefa.Titulo} Cadastrada no ID {tarefa.ID} com sucesso!";
                
                return View();
            }
        }
        #endregion

        #region Mostrar
        [HttpGet]
        public ActionResult Mostrar(){
            id = HttpContext.Session.GetString("ID");

            List<Tarefa> tarefas = new List<Tarefa>();

            string[] linhas = System.IO.File.ReadAllLines(caminho);

            foreach(string item in linhas){

                string[] linha = item.Split(";");

                if(!String.IsNullOrEmpty(linha[0]) && linha[linha.Length-1] == id){
                    tarefas.Add(
                        new Tarefa(){
                            ID = int.Parse(linha[0]),
                            Titulo = linha[1],
                            Descricao = linha[2],
                            Status = linha[3],
                            DataInicio = DateTime.Parse(linha[4]),
                            SetDataEntrega = DateTime.Parse(linha[5]),
                            IDUsuario = int.Parse(linha[6])
                        }
                    );
                }
            }
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