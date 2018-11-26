using System.Collections.Generic;
using Web_TesteCadastroMVC.Models;

namespace Web_TesteCadastroMVC.Interfaces
{
    public interface IUsuario
    {
        #region Criar Remover Editar e Atualizar
        Usuario Cadastrar(Usuario usuario);
        bool Excluir(string id);
        Usuario Editar(Usuario usuario);
        List<Usuario> Listar();
        #endregion
        
        Usuario Procurar(string id);
        Usuario Logar(string email,string senha);
    } 
}