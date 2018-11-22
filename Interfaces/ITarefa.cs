using System.Collections.Generic;
using Web_TesteCadastroMVC.Models;

namespace Web_TesteCadastroMVC.Interfaces
{
    public interface ITarefa
    {
        Tarefa Cadastrar(Tarefa tarefa);
        Tarefa Editar(Tarefa tarefa);
        List<Tarefa> Listar(string id);
        bool Excluir(string id);
        Tarefa Procurar(string id);
    }
}