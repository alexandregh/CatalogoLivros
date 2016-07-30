using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogoLivros.DAL.Abstract.GenericInterface;
using CatalogoLivros.Domain.Entity;
using CatalogoLivros.Domain.Enum;
using CatalogoLivros.Util.Criptografia;
using CatalogoLivros.SGBDDAL.DataSource;

namespace CatalogoLivros.DAL.Persistence.PersistenceUsuario
{
    public class UsuarioDal : GenericInterface<Usuario, FotoUsuario>
    {
        /// <summary>
        /// Método para Pesquisar um Usuário pelo seu Email e Login.
        /// </summary>
        /// <param name="email">Recebe como parâmetro um Email.</param>
        /// <param name="login">Recebe como parâmetro um Login.</param>
        /// <returns>Retorna um Usuário baseado no seu Email e Login.</returns>
        public Usuario FindUsuarioByEmailLogin(string email, string login)
        {
            using(DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
            {
                try
                {
                    return dbCatalogoLivros.Usuario
                           .Where(u => u.Email.Equals(email) && u.Login.Equals(login))                            
                           .FirstOrDefault();
                }
                catch (ArgumentNullException ex)
                {
                    throw new ArgumentNullException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
                }
            }
        }

        //________________________________________________________________________

        /// <summary>
        /// Método para Pesquisar um Usuário pelo seu Login e Senha.
        /// </summary>
        /// <param name="login">Recebe como parâmetro um Login.</param>
        /// <param name="senha">Recebe como parâmetro um Senha.</param>
        /// <returns>Retorna um Usuário baseado no seu Login e Senha.</returns>
        public Usuario FindUsuarioByLoginSenha(string login, string senha)
        {
            using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
            {
                try
                {
                    Usuario usuario = new Usuario();
                    usuario = this.ReturnTipoCriptografiaByUsuario(login);
                    if(usuario != null)
                    {
                        string tipoCriptografia = usuario.TipoCriptografia;

                        if (tipoCriptografia == "MD5")
                        {
                            senha = Criptografia.CriptografarSenhaByMD5(senha);
                            return dbCatalogoLivros.Usuario
                               .Where(u => u.Login.Equals(login) && u.Senha.Equals(senha))
                               .FirstOrDefault();
                        }
                        if (tipoCriptografia == "SHA1")
                        {
                            senha = Criptografia.CriptografarSenhaBySHA1(senha);
                            return dbCatalogoLivros.Usuario
                               .Where(u => u.Login.Equals(login) && u.Senha.Equals(senha))
                               .FirstOrDefault();
                        }
                    }
                    return null;
                }
                catch (ArgumentNullException ex)
                {
                    throw new ArgumentNullException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
                }
            }
        }

        //________________________________________________________________________

        /// <summary>
        /// Método para Pesquisar o Login e/ou a Senha de um Usuário pelo seu Email.
        /// </summary>
        /// <param name="email">Recebe como parâmetro o seu email.</param>
        /// <returns>Retorna um Usuário baseado no seu Login e/ou na sua Senha.</returns>
        public Usuario FindLoginSenhaUsuario(string email)
        {
            using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
            {
                try
                {
                    return dbCatalogoLivros.Usuario
                           .Where(u => u.Email.Equals(email)).FirstOrDefault();
                }
                catch (ArgumentNullException ex)
                {
                    throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
                }
            }
        }

        //________________________________________________________________________

        /// <summary>
        /// Método para Pesquisar um usuário pelo seu Id.
        /// </summary>
        /// <param name="id">Recebe como parâmetro o seu id.</param>
        /// <returns>Retorna um Usuário baseado no seu Id.</returns>
        public Usuario FindIdUsuario(int id)
        {
            using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
            {
                try
                {
                    return dbCatalogoLivros.Usuario
                           .Where(u => u.IdUsuario.Equals(id)).FirstOrDefault();
                }
                catch (ArgumentNullException ex)
                {
                    throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
                }
            }
        }

        //________________________________________________________________________

        /// <summary>
        /// Método para Pesquisar uma Foto de Usuário pelo seu Id.
        /// </summary>
        /// <param name="id">Recebe como parâmetro o Id do Usuário.</param>
        /// <returns>Retorna uma Foto do Usuário baseado no seu Id.</returns>
        public FotoUsuario FindFotoUsuarioByIdFotoUsuario(int id)
        {
            using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
            {
                try
                {   
                    return dbCatalogoLivros.FotoUsuario
                           .Where(fu => fu.IdFotoUsuario.Equals(id)).FirstOrDefault();
                }
                catch (ArgumentNullException ex)
                {
                    throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
                }
            }
        }

        //________________________________________________________________________

        /// <summary>
        /// Método para retornar a extensão do arquivo de imagem/foto de um objeto genérico (TEntity entity).
        /// </summary>
        /// <param name="tipoCriptografia">Recebe como parâmetro o tipo da extensão da imagem/foto.</param>
        /// <returns>Retorna o tipo da criptografia da senha do usuário.</returns>
        public string ReturnTipoCriptografia(string tipoCriptografia, string senha)
        {
            if (tipoCriptografia == "MD5") // MD5
            {
                senha = Criptografia.CriptografarSenhaByMD5(senha);
                return senha;
            }
            if (tipoCriptografia == "SHA1") // SHA1
            {
                senha = Criptografia.CriptografarSenhaBySHA1(senha);
                return senha;
            }
            else
            {
                return null;
            }
        }

        //________________________________________________________________________

        /// <summary>
        /// Método para retornar o tipo da criptografia (MD5 ou SHA1) da senha do usuário.
        /// </summary>
        /// <param name="login">Recebe como parâmetro um Login.</param>
        /// <returns>Retorna um usuário baseado no tipo da criptografia (MD5 ou SHA1) da senha do usuário.</returns>
        private Usuario ReturnTipoCriptografiaByUsuario(string login)
        {
            using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
            {
                try
                {
                    return dbCatalogoLivros.Usuario
                           .Where(u => u.Login.Equals(login)).FirstOrDefault();
                }
                catch (ArgumentNullException ex)
                {
                    throw new ArgumentNullException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
                }
            }
        }
    }
}