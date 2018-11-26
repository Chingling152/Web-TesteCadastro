using System;
using Web_TesteCadastroMVC.Models;

namespace Web_TesteCadastroMVC.Interfaces
{
    public interface IValidacaoUsuario
    {
        string ValidarUsuario(Usuario user,string caminho);
        bool EmailValido(string email,string caminho);
        bool DataValida(DateTime data);
        bool NomeValido(string nome);
    }
}