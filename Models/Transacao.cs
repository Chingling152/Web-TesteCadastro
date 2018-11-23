namespace Web_TesteCadastroMVC.Models
{
    [System.Serializable]
    public class Transacao
    {
        public int NumeroTransacao;
        public string Descricao;
        public double valor;
        public string tipo;
        public System.DateTime data;
        public int IDUsuario;
    }
}