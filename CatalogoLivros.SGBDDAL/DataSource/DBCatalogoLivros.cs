using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Entity;
using CatalogoLivros.Domain.Entity;


namespace CatalogoLivros.SGBDDAL.DataSource
{
    public class DBCatalogoLivros : DbContext
    {
        #region Construtor

        public DBCatalogoLivros()
            : base(ConfigurationManager.ConnectionStrings["DBCatalogoLivros"].ConnectionString)
        {

        }

        #endregion


        #region Propriedades

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<FotoUsuario> FotoUsuario { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Obra> Obra { get; set; }
        public DbSet<FotoObra> FotoObra { get; set; }
        public DbSet<Editora> Editora { get; set; }

        #endregion
    }
}
