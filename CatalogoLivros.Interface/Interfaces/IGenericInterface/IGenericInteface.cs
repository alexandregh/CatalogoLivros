using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogoLivros.Domain.Entity;

namespace CatalogoLivros.Interface.Interfaces.IGenericInterface
{
    public interface IGenericInteface<TEntity, TFoto> where TEntity : class
                                                      where TFoto : class
    {
        void Insert(TEntity entity);
        void Insert(TEntity entity, TFoto foto);
        void Update(TEntity entity);
        void Update(TEntity entity, TFoto foto);
        void Delete(TEntity entity);
        TEntity FindById(int id);
        void UpdateFoto(TEntity entity);
        void CreateDirectoryFoto(string pathFotoObra);
        void CreateDirectoryFoto(string pathFotoUsuario, string pathFotoObra);
        string ReturnExtensionFoto(string tipoExtensaoFoto, string foto);
        string ReturnFotoFull(string caminhoFoto, string foto);
        //void Paginar(int maximumRows);
    }
}