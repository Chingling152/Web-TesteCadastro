using System.Collections.Generic;
using Web_TesteCadastroMVC.Models;

namespace Web_TesteCadastroMVC.Interfaces
{
    public interface IUsuario
    {
        Usuario Cadastrar(Usuario usuario);
        Usuario Editar(Usuario usuario);
        List<Usuario> Listar();
        bool Excluir(string id);
        Usuario Procurar(string id);
        Usuario Logar(string email,string senha);
        bool EmailExiste(string email);
        bool DataValida(System.DateTime data);
    } 
}