using System.Collections.Generic;
using Web_TesteCadastroMVC.Models;

namespace Web_TesteCadastroMVC.Interfaces
{
    public interface ITransacao
    {
        Transacao Cadastrar(Transacao transacao);
        List<Transacao> Listar(string IDUsuario);
        bool Excluir(Transacao transacao , string IDUsuario);
    }
}