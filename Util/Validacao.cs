using System;
using System.IO;
using Web_TesteCadastroMVC.Models;

namespace Web_TesteCadastroMVC.Util
{
    public static class Validacao
    {
        /// <summary>
        /// Valida o usuario no login
        /// </summary>
        /// <param name="user">O usuario que está sendo logado</param>
        /// <returns>Retorna mensagem de sucesso caso o nome e a senha não forem nulos ou vazios</returns>
        public static string LoginUsuario(Usuario user){
            if(string.IsNullOrEmpty(user.Nome)){
                return "Nome invalido!!";
            }
            if(string.IsNullOrEmpty(user.Senha)){
                return "Senha invalida!!";
            }
            return $"Usuario {user.Nome} cadastrado com sucesso";
        }

        /// <summary>
        /// Verifica se o usuario é administrador
        /// </summary>
        /// <param name="user">O Usuario a ser verificado</param>
        /// <returns>Retorna true se o Usuario for Administrador</returns>
        public static bool Admin(Usuario user){
            if(user.Tipo == "Administrador"){
                return true;
            }else{
                return false;
            }
        }

        /// <summary>
        /// Procura o usuario no arquivos .csv
        /// </summary>
        /// <param name="id">o ID do usuario a ser procurado</param>
        /// <returns>Retorna um usuario criado na linha do ID encontrado</returns>
        public static Usuario ProcurarUsuario(string id){
            Usuario user = null;
            string[] usuarios = System.IO.File.ReadAllLines("Databases/Usuario.csv");

            foreach(string item in usuarios){     
                string[] usuario = item.Split(";");
                if(usuario[0] == id){
                    return new Usuario(){
                        ID = int.Parse(id),
                        Nome = usuario[1],
                        Email = usuario[2],
                        Senha = usuario[3],
                        Tipo = usuario[4],
                        DataNascimento = DateTime.Parse(usuario[5])
                    };
                }
            }
            return user;
        }
    }
}