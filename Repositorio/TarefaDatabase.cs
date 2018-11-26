using System;
using System.Collections.Generic;
using System.IO;
using Web_TesteCadastroMVC.Interfaces;
using Web_TesteCadastroMVC.Models;

namespace Web_TesteCadastroMVC.Repositorio
{
    public class TarefaDatabase : ITarefa
    {
        private const string caminho = "Databases/Tarefa.csv";
        private int contador;
        
        public TarefaDatabase(){
            bool existe = System.IO.File.Exists(caminho);
            contador = existe?File.ReadAllLines(caminho).Length +1 : 1;  
        }
        public Tarefa Cadastrar(Tarefa tarefa)
        {
            tarefa.ID = contador++;
            
            using (StreamWriter sw = new StreamWriter(caminho,true)){
                sw.WriteLine($"{tarefa.ID};{tarefa.Titulo};{tarefa.Descricao};{tarefa.Status};{tarefa.DataInicio};{tarefa.DataEntrega};{tarefa.IDUsuario}");
            }

            return tarefa;
        }

        public Tarefa Editar(Tarefa tarefa, string UserID)
        {
            throw new NotImplementedException();
        }

        public bool Excluir(string ID,string UserID)
        {
            bool flag = false;
            string[] linhas = System.IO.File.ReadAllLines(caminho);

            for (int i = 0; i < linhas.Length; i++)
            {
                string[] linha = linhas[i].Split(";");

                if(ID.ToString() == linha[0]&&UserID == linha[linha.Length-1]){
                    linhas[i] = "";    
                    flag = true;
                }
            }

            System.IO.File.WriteAllLines(caminho,linhas);
            return flag;
        }

        public List<Tarefa> Listar(string id)
        {
            List<Tarefa> tarefas = new List<Tarefa>();
            string[] linhas = System.IO.File.ReadAllLines(caminho);

            foreach(string item in linhas){

                string[] linha = item.Split(";");

                if(!String.IsNullOrEmpty(linha[0]) && linha[linha.Length-1] == id){
                    tarefas.Add(new Tarefa(linha));
                }
            }
            return tarefas;
        }

        public Tarefa Procurar(string id)
        {
            string[] linhas = File.ReadAllLines(caminho);
            Tarefa tarefa = null;

            foreach (string item in linhas)
            {
                string[] linha = item.Split(";");

                if(linha[0] == id){
                    tarefa = new Tarefa(linha);
                }
            }
            return tarefa;
        }
    }
}