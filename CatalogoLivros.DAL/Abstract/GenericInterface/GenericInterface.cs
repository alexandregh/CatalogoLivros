using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Data.Entity;
using System.IO;
using System.Security.AccessControl;
using CatalogoLivros.DAL.Interfaces.Usuario;
using CatalogoLivros.Domain.Entity;
using CatalogoLivros.Domain.Enum;
using CatalogoLivros.Interface.Interfaces.IGenericInterface;
using CatalogoLivros.Util.Criptografia;
using CatalogoLivros.SGBDDAL.DataSource;

namespace CatalogoLivros.DAL.Abstract.GenericInterface
{
    public abstract class GenericInterface<TEntity, TFoto> : IGenericInteface<TEntity, TFoto> where TEntity : class
                                                                                              where TFoto : class

    {
        /// <summary>
        /// Método para Inserir uma instância de um objeto genérico (TEntity entity).
        /// </summary>
        /// <param name="entity">Recebe como parâmetro um objeto genérico (TEntity entity).</param>
        public void Insert(TEntity entity)
        {
            using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
            {
                DbContextTransaction transacaoBD = dbCatalogoLivros.Database.BeginTransaction();
                try
                {
                    dbCatalogoLivros.Entry(entity).State = EntityState.Added;
                    dbCatalogoLivros.SaveChanges();
                    transacaoBD.Commit();
                    transacaoBD.Dispose();
                }
                catch (NotSupportedException ex)
                {
                    throw new NotSupportedException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (ObjectDisposedException ex)
                {
                    throw new ObjectDisposedException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    throw new InvalidOperationException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw new DbUpdateConcurrencyException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (DbUpdateException ex)
                {
                    throw new DbUpdateException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationsErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationsError in ex.EntityValidationErrors)
                        {
                            Trace.TraceInformation(validationsError.ToString());
                        }
                    }
                    throw new DbEntityValidationException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
                }
            }
        }

        //_______________________________________________

        /// <summary>
        /// Método para Inserir uma instância de um objeto genérico (TEntity entity).
        /// </summary>
        /// <param name="entity">Recebe como parâmetro um objeto genérico (TEntity entity).</param>
        /// <param name="fotoObra">Recebe como parâmetro um objeto do tipo da classe FotoObra.</param>
        public void Insert(TEntity entity, TFoto foto)
        {
            using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
            {
                DbContextTransaction transacaoBD = dbCatalogoLivros.Database.BeginTransaction();
                try
                {
                    dbCatalogoLivros.Entry(entity).State = EntityState.Added;
                    dbCatalogoLivros.Entry(foto).State = EntityState.Added;
                    dbCatalogoLivros.SaveChanges();
                    transacaoBD.Commit();
                    transacaoBD.Dispose();
                }
                catch (NotSupportedException ex)
                {
                    throw new NotSupportedException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (ObjectDisposedException ex)
                {
                    throw new ObjectDisposedException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    throw new InvalidOperationException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw new DbUpdateConcurrencyException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (DbUpdateException ex)
                {
                    throw new DbUpdateException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationsErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationsError in ex.EntityValidationErrors)
                        {
                            Trace.TraceInformation(validationsError.ToString());
                        }
                    }
                    throw new DbEntityValidationException("Ocorreu o seguinte erro: " + ex.StackTrace);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
                }
            }
        }

        //_______________________________________________

        /// <summary>
        /// Método para Atualizar uma instância de um objeto genérico (TEntity entity).
        /// </summary>
        /// <param name="entity">Recebe como parâmetro um objeto genérico (TEntity entity).</param>
        public void Update(TEntity entity)
        {
            using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
            {
                DbContextTransaction transacaoBD = dbCatalogoLivros.Database.BeginTransaction();
                try
                {
                    dbCatalogoLivros.Entry(entity).State = EntityState.Modified;
                    dbCatalogoLivros.SaveChanges();
                    transacaoBD.Commit();
                    transacaoBD.Dispose();
                }
                catch (NotSupportedException ex)
                {
                    throw new NotSupportedException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (ObjectDisposedException ex)
                {
                    throw new ObjectDisposedException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    throw new InvalidOperationException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw new DbUpdateConcurrencyException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (DbUpdateException ex)
                {
                    throw new DbUpdateException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (DbEntityValidationException ex)
                {
                    throw new DbEntityValidationException("Ocorreu o seguinte erro: " + ex.EntityValidationErrors);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
                }
            }
        }

        //_______________________________________________

        public void Update(TEntity entity, TFoto foto)
        {
            using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
            {
                DbContextTransaction transacaoBD = dbCatalogoLivros.Database.BeginTransaction();
                try
                {
                    dbCatalogoLivros.Entry(entity).State = EntityState.Modified;
                    dbCatalogoLivros.Entry(foto).State = EntityState.Modified;
                    dbCatalogoLivros.SaveChanges();
                    transacaoBD.Commit();
                    transacaoBD.Dispose();
                }
                catch (NotSupportedException ex)
                {
                    throw new NotSupportedException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (ObjectDisposedException ex)
                {
                    throw new ObjectDisposedException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    throw new InvalidOperationException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw new DbUpdateConcurrencyException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (DbUpdateException ex)
                {
                    throw new DbUpdateException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (DbEntityValidationException ex)
                {
                    throw new DbEntityValidationException("Ocorreu o seguinte erro: " + ex.EntityValidationErrors);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
                }
            }
        }

        //_______________________________________________

        /// <summary>
        /// Método para Apagar uma instância de um objeto genérico (TEntity entity).
        /// </summary>
        /// <param name="entity">Recebe como parâmetro um objeto genérico (TEntity entity).</param>
        public void Delete(TEntity entity)
        {
            using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
            {
                DbContextTransaction transacaoBD = dbCatalogoLivros.Database.BeginTransaction();
                try
                {
                    dbCatalogoLivros.Entry(entity).State = EntityState.Deleted;
                    dbCatalogoLivros.SaveChanges();
                    transacaoBD.Commit();
                    transacaoBD.Dispose();
                }
                catch (NotSupportedException ex)
                {
                    throw new NotSupportedException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (ObjectDisposedException ex)
                {
                    throw new ObjectDisposedException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    throw new InvalidOperationException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw new DbUpdateConcurrencyException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (DbUpdateException ex)
                {
                    throw new DbUpdateException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (DbEntityValidationException ex)
                {
                    throw new DbEntityValidationException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
                }
            }
        }

        //_______________________________________________

        /// <summary>
        /// Método para Pesquisar uma instância de um objeto genérico (TEntity entity) pelo Id.
        /// </summary>
        /// <param name="id">Recebe como parâmetro um Id de um objeto genérico (TEntity entity).</param>
        /// <returns>Retorna uma instância de um objeto genérico (TEntity entity).</returns>
        public TEntity FindById(int id)
        {
            using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
            {
                DbContextTransaction transacaoBD = dbCatalogoLivros.Database.BeginTransaction();
                try
                {
                    return dbCatalogoLivros.Set<TEntity>().Find(id);
                }
                catch (InvalidOperationException ex)
                {
                    throw new InvalidOperationException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
                }
            }
        }

        //_______________________________________________

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateFoto(TEntity entity)
        {
            // vai ser implementado
        }

        //_______________________________________________

        /// <summary>
        /// Método para retornar o caminho completo (raiz) da foto do usuário logado no sistema.
        /// </summary>
        /// <param name="foto">Recebe como parâmetro a o nome da foto do usuário e sua extensão.</param>
        /// <param name="caminhoFoto">Recebe como parâmetro o endereço completo onde se encontra a foto do usuário.</param>
        /// <returns>Retorna o endereço completo onde se encontra a foto do usuário, foto do usuário e sua extensão.</returns>
        public string ReturnFotoFull(string caminhoFoto, string foto)
        {
            foto = foto.Replace("-", "");
            caminhoFoto = caminhoFoto + "\\" + foto;
            return caminhoFoto;
        }

        //_______________________________________________

        /// <summary>
        /// Método para Criar um Diretório de Foto de uma instância de um objeto genérico (TEntity entity).
        /// </summary>
        /// <param name="pathFotoObra">Recebe como parâmetro o caminho do diretório da foto da obra.</param>
        public void CreateDirectoryFoto(string pathFotoObra)
        {
            try
            {
                if (!Directory.Exists(pathFotoObra))
                {
                    Directory.CreateDirectory(pathFotoObra);
                }
            }
            catch (PathTooLongException ex)
            {
                throw new PathTooLongException("Ocorreu o seguinte erro: " + ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new DirectoryNotFoundException("Ocorreu o seguinte erro: " + ex.Message);
            }
            catch (IOException ex)
            {
                throw new IOException("Ocorreu o seguinte erro: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new UnauthorizedAccessException("Ocorreu o seguinte erro: " + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException("Ocorreu o seguinte erro: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Ocorreu o seguinte erro: " + ex.Message);
            }
            catch (NotSupportedException ex)
            {
                throw new NotSupportedException("Ocorreu o seguinte erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("Ocorreu o seguinte erro: " + ex.Message);
            }
        }

        //_______________________________________________

        /// <summary>
        /// Método para Criar um Diretório de Foto de uma instância de um objeto genérico (TEntity entity).
        /// </summary>
        /// <param name="pathFotoUsuario">Recebe como parâmetro o caminho do diretório da foto do usuário.</param>
        /// <param name="pathFotoObra">Recebe como parâmetro o caminho do diretório da foto da obra.</param>
        public void CreateDirectoryFoto(string pathFotoUsuario, string pathFotoObra)
        {
            try 
	        {
                if (!Directory.Exists(pathFotoUsuario))
                {
                    Directory.CreateDirectory(pathFotoUsuario);
                }
                if (!Directory.Exists(pathFotoObra))
                {
                    Directory.CreateDirectory(pathFotoObra);
                }
	        }
            catch (PathTooLongException ex)
            {
                throw new PathTooLongException("Ocorreu o seguinte erro: " + ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new DirectoryNotFoundException("Ocorreu o seguinte erro: " + ex.Message);
            }
            catch (IOException ex)
            {
                throw new IOException("Ocorreu o seguinte erro: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new UnauthorizedAccessException("Ocorreu o seguinte erro: " + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException("Ocorreu o seguinte erro: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Ocorreu o seguinte erro: " + ex.Message);
            }
            catch (NotSupportedException ex)
            {
                throw new NotSupportedException("Ocorreu o seguinte erro: " + ex.Message);
            }
	        catch (Exception ex)
	        {
                throw new NotSupportedException("Ocorreu o seguinte erro: " + ex.Message);
	        }
        }

        //_______________________________________________

        /// <summary>
        /// Método para retornar a extensão do arquivo de imagem/foto de um objeto genérico (TEntity entity).
        /// </summary>
        /// <param name="tipoExtensaoFoto">Recebe como parâmetro o tipo da extensão da imagem/foto.</param>
        /// <param name="foto">Recebe como parâmetro o arquivo da imagem/foto.</param>
        /// <returns>Retorna o tipo da extensão de um arquivo de imagem/foto.</returns>
        public string ReturnExtensionFoto(string tipoExtensaoFoto, string foto)
        {
            try
            {
                if (tipoExtensaoFoto == "image/jpeg" || tipoExtensaoFoto == "image/pjpeg")
                {
                    string[] extensao = foto.Split('.');
                    if (extensao[1].Contains("jpg"))
                    {
                        return extensao[1];
                    }
                    else
                    {
                        throw new Exception("A extensão do arquivo " + extensao[1] + " não é válida. Tente outro arquivo.");
                    }
                }
                else
                {
                    throw new Exception("Arquivo no formato inválido. Temte outro.");
                }
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