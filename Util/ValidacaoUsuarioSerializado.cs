using System;
using Web_TesteCadastroMVC.Interfaces;
using Web_TesteCadastroMVC.Models;

namespace Web_TesteCadastroMVC.Util
{
    public class ValidacaoUsuarioSerializado : IValidacaoUsuario
    {
        public bool DataValida(DateTime data)
        {
            throw new NotImplementedException();
        }

        public bool EmailValido(string email, string caminho)
        {
            throw new NotImplementedException();
        }

        public bool NomeValido(string nome)
        {
            throw new NotImplementedException();
        }

        public string ValidarUsuario(Usuario user, string caminho)
        {
            throw new NotImplementedException();
        }
    }
}