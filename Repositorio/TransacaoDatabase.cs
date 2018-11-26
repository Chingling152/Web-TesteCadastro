using System.Collections.Generic;
using Web_TesteCadastroMVC.Interfaces;
using Web_TesteCadastroMVC.Models;

namespace Web_TesteCadastroMVC.Repositorio
{
    public class TransacaoDatabase : ITransacao
    {
        public Transacao Cadastrar(Transacao transacao)
        {
            throw new System.NotImplementedException();
        }

        public bool Excluir(Transacao transacao, string IDUsuario)
        {
            throw new System.NotImplementedException();
        }

        public List<Transacao> Listar(string IDUsuario)
        {
            throw new System.NotImplementedException();
        }
    }
}