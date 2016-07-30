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

namespace CatalogoLivros.DAL.Persistence.PersistenceObra
{
    public class ObraDal : GenericInterface<Obra, FotoObra>
    {
        /// <summary>
        /// Método para pesquisar e retornar a obra do usuário logado no sistema.
        /// </summary>
        /// <param name="titulo">Recebe como parâmetro o titulo da obra do usuário.</param>
        /// <param name="ISBN">Recebe como parâmetro o ISBN da obra do usuário.</param>
        /// <returns>Retorna, se existir, a obra do usuário logado no sistema.</returns>
        public Obra FindObraByTituloISBN(string titulo, long isbn)
        {
            using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
            {
                try
                {
                    return dbCatalogoLivros.Obra
                           .Where(o => o.Titulo.Equals(titulo) || o.ISBN.Equals(isbn)).FirstOrDefault();
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

        //_________________________________________________________________

        /// <summary>
        /// Método para pesquisar e retornar a obra do usuário logado no sistema.
        /// </summary>
        /// <param name="autor">Recebe como parâmetro o titulo da obra do usuário.</param>
        /// <returns>Retorna, se existir, a obra do usuário logado no sistema.</returns>
        public Obra FindObraByTitulo(string titulo)
        {
            using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
            {
                try
                {
                    return dbCatalogoLivros.Obra
                           .Where(o => o.Titulo.Equals(titulo)).FirstOrDefault();
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

        //_________________________________________________________________

        /// <summary>
        /// Método para pesquisar e retornar a obra do usuário logado no sistema.
        /// </summary>
        /// <param name="autor">Recebe como parâmetro o autor da obra do usuário.</param>
        /// <returns>Retorna, se existir, a obra do usuário logado no sistema.</returns>
        public Obra FindObraByAutor(string autor)
        {
            using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
            {
                try
                {
                    return dbCatalogoLivros.Obra
                           .Where(o => o.AutorObra.Nome.Equals(autor)).FirstOrDefault();
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

        //_________________________________________________________________

        /// <summary>
        /// Método para pesquisar e retornar a obra do usuário logado no sistema.
        /// </summary>
        /// <param name="isbn">Recebe como parâmetro o isbn da obra do usuário.</param>
        /// <returns>Retorna, se existir, a obra do usuário logado no sistema.</returns>
        public Obra FindObraByISBN(long isbn)
        {
            using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
            {
                try
                {
                    return dbCatalogoLivros.Obra
                           .Where(o => o.ISBN.Equals(isbn)).FirstOrDefault();
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

        //_________________________________________________________________

        /// <summary>
        /// Método para pesquisar e retornar a obra do usuário logado no sistema.
        /// </summary>
        /// <param name="titulo">Recebe como parâmetro o titulo da obra do usuário.</param>
        /// <param name="autor">Recebe como parâmetro o autor da obra do usuário.</param>
        /// <returns>Retorna, se existir, a obra do usuário logado no sistema.</returns>
        public Obra FindObra(string titulo, string autor)
        {
            using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
            {
                try
                {
                    return dbCatalogoLivros.Obra
                           .Where(o => o.Titulo.Equals(titulo) && o.AutorObra.Nome.Equals(autor)).FirstOrDefault();
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

        //_________________________________________________________________

        /// <summary>
        /// Método para pesquisar e retornar a obra do usuário logado no sistema.
        /// </summary>
        /// <param name="titulo">Recebe como parâmetro o titulo da obra do usuário.</param>
        /// <param name="isbn">Recebe como parâmetro o isbn da obra do usuário.</param>
        /// <returns>Retorna, se existir, a obra do usuário logado no sistema.</returns>
        public Obra FindObra(string titulo, long isbn)
        {
            using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
            {
                try
                {
                    return dbCatalogoLivros.Obra
                           .Where(o => o.Titulo.Equals(titulo) && o.ISBN.Equals(isbn)).FirstOrDefault();
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

        //_________________________________________________________________

        /// <summary>
        /// Método para pesquisar e retornar a obra do usuário logado no sistema.
        /// </summary>
        /// <param name="autor">Recebe como parâmetro o autor da obra do usuário.</param>
        /// <param name="isbn">Recebe como parâmetro o isbn da obra do usuário.</param>
        /// <returns>Retorna, se existir, a obra do usuário logado no sistema.</returns>
        public Obra FindObra(long isbn, string autor)
        {
            using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
            {
                try
                {
                    return dbCatalogoLivros.Obra
                           .Where(o => o.ISBN.Equals(isbn) && o.AutorObra.Nome.Equals(autor)).FirstOrDefault();
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

        //_________________________________________________________________

        /// <summary>
        /// Método para pesquisar e retornar a obra do usuário logado no sistema.
        /// </summary>
        /// <param name="titulo">Recebe como parâmetro o titulo da obra do usuário.</param>
        /// <param name="titulo">Recebe como parâmetro o autor da obra do usuário.</param>
        /// <param name="isbn">Recebe como parâmetro o ISBN (International Standard Book Number) da obra do usuário.</param>
        /// <returns>Retorna, se existir, a obra do usuário logado no sistema.</returns>
        public Obra FindObra(string titulo, string autor, long isbn)
        {
            using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
            {
                try
                {
                    return dbCatalogoLivros.Obra
                           .Where(o => o.Titulo.Equals(titulo) && o.AutorObra.Nome.Equals(autor) && o.ISBN.Equals(isbn))
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

        //_________________________________________________________________


        public Obra FindObrasAtivas(StatusObra statusObra)
        {
            using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
            {
                try
                {
                    return dbCatalogoLivros.Obra
                           .Where(o => o.StatusObra == StatusObra.Ativo).FirstOrDefault();
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

        //_________________________________________________________________


        public Obra FindObrasInativas(StatusObra statusObra)
        {
            using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
            {
                try
                {
                    return dbCatalogoLivros.Obra
                           .Where(o => o.StatusObra == StatusObra.Inativo).FirstOrDefault();
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

        //_________________________________________________________________

        /// <summary>
        /// Método para retornar a obra do usuário pelo tipo de parâmetro que foi passado.
        /// </summary>
        /// <param name="collectionParam">Recebe como parâmetro uma informação de pesquisa qualquer passada pelo usuário.</param>
        /// <returns>Retorna, se existir, a obra do usuário logado no sistema.</returns>
        public Obra ReturnTypeParam(string[] collectionParam)
        {
            if (Convert.ToInt16(collectionParam[3]) == 1) // se foi submetido um parâmetro qualquer.
            {
                if (!string.IsNullOrEmpty(collectionParam[0])) // pelo Titulo
                {
                    return this.FindObraByTitulo(collectionParam[0]);
                }
                if (!string.IsNullOrEmpty(collectionParam[1])) // pelo Autor
                {
                    return this.FindObraByAutor(collectionParam[1]);
                }
                if (!string.IsNullOrEmpty(collectionParam[2])) // pelo ISBN
                {
                    return this.FindObraByISBN(Convert.ToInt64(collectionParam[2]));
                }
                else
                {
                    return null;
                }
            }

            if (Convert.ToInt16(collectionParam[3]) == 2) // se foi submetido dois parâmetros quaisquer.
            {
                if (!string.IsNullOrEmpty(collectionParam[0]) && !string.IsNullOrEmpty(collectionParam[1])) // titulo e autor
                {
                    return this.FindObra(collectionParam[0], collectionParam[1]);
                }
                if (!string.IsNullOrEmpty(collectionParam[0]) && !string.IsNullOrEmpty(collectionParam[2])) // titulo e isbn
                {
                    return this.FindObra(collectionParam[0], Convert.ToInt64(collectionParam[2]));
                }
                if (!string.IsNullOrEmpty(collectionParam[2]) && !string.IsNullOrEmpty(collectionParam[1])) // isbn e autor
                {
                    return this.FindObra(Convert.ToInt64(collectionParam[2]), collectionParam[1]);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        //_________________________________________________________________

        /// <summary>
        /// Método para retornar o autor da obra cadastrada pelo usuário do sistema.
        /// </summary>
        /// <param name="obra">Recebe como parâmetro a obra cadastrada pelo usuário do sistema.</param>
        /// <returns>Retorna o autor da obra cadastrada pelo usuário do sistema.</returns>
        public Autor ReturnDataAutor(Obra obra)
        {
            using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
            {
                try
                {
                    return dbCatalogoLivros.Autor
                           .Where(a => a.IdAutor.Equals(obra.IdAutor)).FirstOrDefault();
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

        //_________________________________________________________________

        /// <summary>
        /// Método para retornar a editora da obra cadastrada pelo usuário do sistema.
        /// </summary>
        /// <param name="obra">Recebe como parâmetro a obra cadastrada pelo usuário do sistema.</param>
        /// <returns>Retorna a editora da obra cadastrada pelo usuário do sistema.</returns>
        public Editora ReturnDataEditora(Obra obra)
        {
            using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
            {
                try
                {
                    return dbCatalogoLivros.Editora
                           .Where(e =>e.IdEditora.Equals(obra.IdEditora)).FirstOrDefault();
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

        //_________________________________________________________________

        /// <summary>
        /// Método para retornar a quantidade de parâmetros referentes a :pesquisa de uma obra.
        /// </summary>
        /// <param name="titulo">Recebe como parâmetro o titulo da obra do usuário.</param>
        /// <param name="autor">Recebe como parâmetro o autor da obra do usuário.</param>
        /// <param name="isbn">Recebe como parâmetro o ISBN (International Standard Book Number) da obra do usuário.</param>
        /// <returns>Retorna a quantidade de parâmetros submetidos pelo usuário logado no sistema.</returns>
        public string[] ReturnParam(string titulo, string autor, long isbn)
        {
            string[] collectionParam = new string[4]; // Indice 0 = titulo; Indice 1 = autor; 
                                                      // Indice 2 = isbn; Indice 3 = quantidade de parâmetros passados.
            Int16 qtdParam = 0;

            if(!string.IsNullOrEmpty(titulo))
            {
                collectionParam[0] = titulo;
                qtdParam += 1;
                collectionParam[3] += qtdParam;
            }
            if (!string.IsNullOrEmpty(autor))
            {
                collectionParam[1] = autor;
                qtdParam += 1;
                collectionParam[3] = Convert.ToString(qtdParam);
            }
            if (isbn != 0)
            {
                collectionParam[2] = Convert.ToString(isbn);
                qtdParam += 1;
                collectionParam[3] = Convert.ToString(qtdParam);
            }

            if(Convert.ToInt32(collectionParam[3]) > 0)
            {
                return collectionParam;
            }
            return null;
        }

        //_________________________________________________________________

        /// <summary>
        /// Método para retornar o caminho completo (raiz) da foto do usuário logado no sistema.
        /// </summary>
        /// <param name="foto">Recebe como parâmetro o nome da foto do usuário e sua extensão.</param>
        /// <param name="caminhoFoto">Recebe como parâmetro o endereço completo onde se encontra a foto do usuário.</param>
        /// <returns>Retorna o endereço completo onde se encontra a foto do usuário, foto do usuário e sua extensão.</returns>
        public string ReturnFotoObra(string caminhoFoto, string foto)
        {
            try
            {
                foto = foto.Replace("-", "");
                caminhoFoto = caminhoFoto + foto;
                return caminhoFoto;
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException("Ocorreu o seguinte erro: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Ocorreu o seguinte erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
            }
        }

        //_________________________________________________________________

        /// <summary>
        /// Método para retornar a foto da obra cadastrada pelo usuário do sistema.
        /// </summary>
        /// <param name="obra">Recebe como parâmetro a obra cadastrada pelo usuário do sistema.</param>
        /// <returns>Retorna a foto da obra cadastrada pelo usuário do sistema.</returns>
        public FotoObra ReturnFotoObra(Obra obra)
        {
            using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
            {
                try
                {
                    return dbCatalogoLivros.FotoObra
                           .Where(fo => fo.IdObra.Equals(obra.IdObra)).FirstOrDefault();
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

        //_________________________________________________________________

        /// <summary>
        /// Método para retornar a formatação e a conversão do ISBN (International Standard Book Number) da obra cadastrada pelo usuário do sistema.
        /// </summary>
        /// <param name="isbn">Recebe como parâmetro o ISBN (International Standard Book Number) do tipo alfanumérico da obra cadastrada pelo usuário do sistema.</param>
        /// <returns>Retorna o ISBN (International Standard Book Number) formatado e convertido para um tipo numérico da obra cadastrada pelo usuário do sistema.</returns>
        public long ReturnConvertionISBNByLong(string isbn)
        {
            try
            {
                string tmpISBN = isbn;
                tmpISBN = tmpISBN.Replace("-", "");
                isbn = tmpISBN;
                return Convert.ToInt64(isbn);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException("Ocorreu o seguinte erro: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Ocorreu o seguinte erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ocorreu o seguinte erro: " + ex.Message);
            }
        }
    }
}