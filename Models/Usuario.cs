namespace Web_TesteCadastroMVC.Models
{
    public class Usuario
    {
        public int ID {get; set;}
        public string Nome { get; set; }
        public string Email{get; set;}
        public string Senha{get ;set;}
        public string Tipo{get;set;}
        public System.DateTime DataNascimento;
    }
}