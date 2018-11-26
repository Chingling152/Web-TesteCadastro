using System;
using System.Collections.Generic;
using System.IO;
using Web_TesteCadastroMVC.Interfaces;
using Web_TesteCadastroMVC.Models;
using Web_TesteCadastroMVC.Util;

namespace Web_TesteCadastroMVC.Repositorio
{
    public class UsuarioDatabase : IUsuario
    {
        private const string caminho = "Databases/Usuario.csv";
        private int contador = System.IO.File.Exists(caminho)?System.IO.File.ReadAllLines(caminho).Length +1 : 1;  
        private IValidacaoUsuario validacao = new ValidacaoUsuario();
        #region CRUM
        /// <summary>
        /// Cadastra o usuario no banco de dados
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public Usuario Cadastrar(Usuario usuario)
        { 
            usuario.ID = contador++;
            using(StreamWriter sw = new StreamWriter(caminho,true)){
                sw.WriteLine($"{usuario.ID};{usuario.Nome};{usuario.Email};{usuario.Senha};{usuario.Tipo};{usuario.DataNascimento}");
            }

            return usuario;
        }

        public bool Excluir(string id)
        {
            string[] linhas = System.IO.File.ReadAllLines(caminho);
            bool flag = false;

            for (int i = 0; i < linhas.Length; i++)
            {
                string[] linha = linhas[i].Split(";");

                if(id == linha[0]){   
                    linhas[i] = "";
                    flag = true;
                    break;
                }

            }
            System.IO.File.WriteAllLines(caminho,linhas);

            return flag;
        }

        public List<Usuario> Listar()
        {
            List<Usuario> usuarios = new List<Usuario>();
            string[] linhas = System.IO.File.ReadAllLines(caminho);

            foreach (string item in linhas)
            {
                if(string.IsNullOrEmpty(item)){
                    continue;
                }else{
                    Usuario user = Procurar(item.Split(";")[0]);
                    if(user != null){
                        usuarios.Add(user);
                    }
                }
            }
            return usuarios;
        }
        
        /// <summary>
        /// Procura o usuario no arquivos .csv
        /// </summary>
        /// <param name="id">o ID do usuario a ser procurado</param>
        /// <returns>Retorna um usuario criado na linha do ID encontrado</returns>
        public Usuario Procurar(string id){
            Usuario user = null;
            string[] usuarios = System.IO.File.ReadAllLines(caminho);

            foreach(string item in usuarios){     
                string[] usuario = item.Split(";");
                if(usuario[0] == id){
                    user = new Usuario(usuario);
                    break;
                }
            }
            return user;
        }

        public Usuario Editar(Usuario usuario)
        {
            throw new System.NotImplementedException();
        }
        #endregion
        
        #region Verificação
        
        public Usuario Logar(string email, string senha)
        {
            Usuario usuario = null;

            using(StreamReader leitor = new StreamReader(caminho)){
                while(!leitor.EndOfStream){
                    string[] info = leitor.ReadLine().Split(';');

                    if(email == info[2].ToLower() && senha == info[3].ToLower()){
                        usuario = Procurar(info[0]);
                        break;
                    }
                }
            }
            return usuario;
        }

        #endregion
    }
}