using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Web_TesteCadastroMVC.Interfaces;
using Web_TesteCadastroMVC.Models;

namespace Web_TesteCadastroMVC.Repositorio
{
    public class TarefaDatabaseSerializado : ITarefa
    {
        private const string caminho = "Databases/Tarefa.dat";
        private List<Tarefa> tarefasSalvas;
        private readonly IUsuario usuarios;

        public TarefaDatabaseSerializado(){
            usuarios = new UsuarioDatabaseSerializado();
            bool existe = System.IO.File.Exists(caminho);
            tarefasSalvas = existe?Deserializar():new List<Tarefa>(); 
        }
        public Tarefa Cadastrar(Tarefa tarefa)
        {
            tarefa.ID = tarefasSalvas.Count+1;
            tarefasSalvas.Add(tarefa);
            Serializar();
            return tarefa;
        }

        public Tarefa Editar(Tarefa tarefa, string UserID)
        {
            throw new NotImplementedException();
        }

        public bool Excluir(string id, string UserID)
        {
            throw new NotImplementedException();
        }

        public List<Tarefa> Listar(string id)
        {
            throw new NotImplementedException();
        }

        public Tarefa Procurar(string id)
        {
            throw new NotImplementedException();
        }

        private void Serializar(){
            MemoryStream memoria = new MemoryStream();
            BinaryFormatter serializador = new BinaryFormatter();               
            serializador.Serialize(memoria,tarefasSalvas);
            File.WriteAllBytes(caminho,memoria.ToArray());
            Deserializar();
        }

        private List<Tarefa> Deserializar(){
            byte[] retorno = File.ReadAllBytes(caminho);//cria array de bytes e le o arquivo .dat
            MemoryStream memoria = new MemoryStream(retorno);//le a array de bytes e armazena na memoria
            BinaryFormatter deserializador = new BinaryFormatter(); //criar um fomatador de binarios para converter bytes em objeto
            return deserializador.Deserialize(memoria) as List<Tarefa>;//retorna as informações em forma de lista de tarefa
        }
    }
}