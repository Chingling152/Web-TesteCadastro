using System;
using System.IO;
using Web_TesteCadastroMVC.Interfaces;
using Web_TesteCadastroMVC.Models;

namespace Web_TesteCadastroMVC.Util
{
    public class ValidacaoUsuario : IValidacaoUsuario
    {
        #region Validação
        public string ValidarUsuario(Usuario user,string caminho)
        {
            if(EmailValido(user.Email,caminho)){
                return "Este email já existe";
            }else if (!DataValida(user.DataNascimento)){
                return "Data de nascimento invalida!";
            }else if(!NomeValido(user.Nome)){
                return "Nome invalido (insira um nome entre 1 e 80 caracteres)";
            }else{
                return $"Usuario {user.Nome} cadastrado com sucesso no ID {user.ID}!";
            }
        }

        /// <summary>
        /// Verifica se existe algum email igual ao inserido no banco de dados
        /// </summary>
        /// <param name="email">o Email a ser verificado</param>
        /// <returns>True se o email existe no banco de dados e false se não existe nenhum email como esse no banco de dados</returns>
        public bool EmailValido(string email,string caminho){
            bool valor = false;
            string[] usuarios = System.IO.File.ReadAllLines(caminho);

            foreach(string item in usuarios){     
                string Email = item.Split(";")[2];
                if(Email == email){
                    valor = true;
                    break;
                }
            }

            return valor;
        }

        public bool DataValida(DateTime data){
            int ano = DateTime.Now.AddYears(-18).Year;
            
            if(ano < data.Year){
                return false;
            }else{
                return true;
            }
            
        }

        public bool NomeValido(string nome){
            if(nome.Length>80){
                return false;
            }else{
                return true;
            }
        }

        #endregion
    }
}