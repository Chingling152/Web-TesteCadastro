using System;
namespace Web_TesteCadastroMVC.Models
{
    public class Tarefa
    {
        public int ID;
        public string Titulo;
        public string Descricao;
        public string Status;
        public DateTime DataInicio;
        public DateTime GetDataEntrega{
            private set;
            get;
        }
        public int IDUsuario; 
        public DateTime SetDataEntrega{
        set{
            if(DataInicio.CompareTo(value)<1){
                value = DateTime.Now;
            }
                GetDataEntrega = value;
            }
        }
    }
}