using System;
namespace Web_TesteCadastroMVC.Models
{
    public class Tarefa
    {
        public readonly int ID;
        public readonly string Titulo;
        public readonly string Descricao;
        public readonly string Status;
        public readonly DateTime DataInicio;
        public readonly DateTime DataEntrega;
        public readonly int IDUsuario; 

        /// <summary>
        /// Construtor usado na criação da classe Tarefa  
        /// Usado por metodos de procura e listagem  
        /// </summary>
        /// <param name="valores">
        /// Uma array de string , sendo :  
        /// 0 = ID  
        /// 1 = Titulo  
        /// 2 = Descrição  
        /// 3 = Status  
        /// 4 = Data De Entrega  
        /// 5 = ID do Usuario dono da tarefa</param>
        public Tarefa(string[] valores){
            ID = int.Parse(valores[0]);
            Titulo = valores[1];
            Descricao = valores[2];
            Status = valores[3];
            DataInicio = DateTime.Now;
            DataEntrega = DateTime.Parse(valores[4]);
            IDUsuario = int.Parse(valores[5]);
        }

        /// <summary>
        /// Construtor da classe Tarefa  
        /// Usados por metodos de cadastro
        /// </summary>
        /// <param name="Titulo">Titulo da tarefa</param>
        /// <param name="Descricao">Descrição da tarefa</param>
        /// <param name="Status">Status da tarefa</param>
        /// <param name="DataEntrega">Data de entrega da tarefa</param>
        /// <param name="IDUsuario">ID do usuario que criou a tarefa</param>
        public Tarefa(string Titulo,string Descricao,string Status,string DataEntrega,String IDUsuario){
            this.Titulo = Titulo;
            this.Descricao = Descricao;
            this.Status = Status;
            this.DataInicio = DateTime.Now;
            this.DataEntrega = DateTime.Parse(DataEntrega);
            this.IDUsuario = int.Parse(IDUsuario);
        }
    }
}