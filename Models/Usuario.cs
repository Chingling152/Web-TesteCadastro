using System;
namespace Web_TesteCadastroMVC.Models
{
    [System.Serializable]
    public class Usuario
    {
        public int ID ;
        public readonly string Nome;
        public readonly string Email;
        public readonly string Senha;
        public readonly string Tipo;
        public readonly DateTime DataNascimento;

        /// <summary>
        /// Construtor da classe Usuario  
        /// Usado por metodos de procura e listagem  
        /// </summary>
        /// <param name="valores">
        /// Uma array de strings onde:  
        /// 0 = ID  
        /// 1 = Nome  
        /// 2 = Email  
        /// 3 = Senha  
        /// 4 = Tipo  
        /// 5 = DataNascimento
        /// </param>
        public Usuario(string[] valores){
            ID = int.Parse(valores[0]);
            Nome = valores[1];
            Email = valores[2];
            Senha = valores[3];
            Tipo = valores[4];
            DataNascimento = DateTime.Parse(valores[5]);
        }

        public Usuario(string ID,string Nome,string Email,string Senha,string Tipo,string DataNascimento){
            this.ID = int.Parse(ID);
            this.Nome = Nome;
            this.Email = Email;
            this.Senha = Senha;
            this.Tipo = Tipo;
            this.DataNascimento = DateTime.Parse(DataNascimento);
        }

    }
}