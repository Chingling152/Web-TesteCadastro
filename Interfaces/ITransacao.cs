using Web_TesteCadastroMVC.Models;

namespace Web_TesteCadastroMVC.Interfaces
{
    public interface ITransacao
    {
        Transacao Cadastrar(Transacao transacao);
    }
}