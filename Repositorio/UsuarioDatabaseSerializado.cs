using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Web_TesteCadastroMVC.Interfaces;
using Web_TesteCadastroMVC.Models;

namespace Web_TesteCadastroMVC.Repositorio
{
    public class UsuarioDatabaseSerializado : IUsuario
    {
        private const string caminho = "Databases/Usuario.dat";
        private List<Usuario> usuariosSalvos;
        public UsuarioDatabaseSerializado(){
            bool existe = System.IO.File.Exists(caminho);
            usuariosSalvos = existe?Listar():new List<Usuario>();
        }
        
        #region CRUM
        
        public Usuario Cadastrar(Usuario usuario)
        {
            usuario.ID = usuariosSalvos.Count+1;

            if(!EmailExiste(usuario.Email)){
                usuariosSalvos.Add(usuario);
                Serializar();
            }

            return usuario;
        }

        public bool Excluir(string id){
            Usuario user = Procurar(id);

            if(user==null){
                return false;
            }else{
                usuariosSalvos.RemoveAt(ProcurarIndex(user));
                Serializar();
                return true;
            }

        }
        #endregion
        #region Procura
        public Usuario Procurar(string id){
            Usuario user = null;
            foreach (Usuario item in usuariosSalvos)
            {
                if(item.ID == int.Parse(id)){
                    user = item;
                    break;
                }
            }
            return user;
        }

        public int ProcurarIndex(Usuario usuario){
            int index = 0;

            foreach (Usuario item in usuariosSalvos)
            {
                if(usuario.ID == item.ID){
                    return index;
                }
                index ++;
            }
            return -1;
        }

        public Usuario Editar(Usuario usuario)
        {
            int index = ProcurarIndex(usuario);
            usuariosSalvos.RemoveAt(index);
            usuariosSalvos.Insert(index,usuario);
            return usuario;
        }
        #endregion
        
        #region Verificação
        private bool EmailExiste(string email){
            bool valor = false;

            foreach (Usuario item in usuariosSalvos)
            {
                if(item.Email == email){
                    valor = true;
                    break;
                }
            }

            return valor;
        }

        public Usuario Logar(string email, string senha)
        {
            Usuario usuario = null;

            foreach (Usuario item in usuariosSalvos)
            {
                if(item.Email == email){
                    if(item.Senha == senha){
                        usuario = item;
                        break;
                    }
                }
            }

            return usuario;
        }
        #endregion

        #region Salvar e carregar
        private void Serializar()
        {
            MemoryStream memoria = new MemoryStream();
            BinaryFormatter serializador = new BinaryFormatter();               
            serializador.Serialize(memoria,usuariosSalvos);
            File.WriteAllBytes(caminho,memoria.ToArray());
            Listar();
        }
        public List<Usuario> Listar()
        {          
            byte[] retorno = File.ReadAllBytes(caminho);//cria array de bytes e le o arquivo .dat
            MemoryStream memoria = new MemoryStream(retorno);//le a array de bytes e armazena na memoria
            BinaryFormatter deserializador = new BinaryFormatter(); //criar um fomatador de binarios para converter bytes em objeto
            return deserializador.Deserialize(memoria) as List<Usuario>;//retorna
        }
        #endregion
    }
}