using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogoLivros.Domain.Entity;

namespace CatalogoLivros.DAL.Interfaces.Usuario
{
    public interface IUsuario<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        TEntity Login(string login, string senha);
        void Logout();
        void Update(string nome, string email, string login, string senha, DateTime dataAlteracao);
        void UpdateFoto(FotoUsuario fotoUsuario);
        void Delete(string email, string login);
        TEntity FindById(int id);
        void CreateDirectoryFoto(string path);
        string ReturnExtensionFoto(string tipoExtensaoFoto, string foto);
        string ReturnTipoCriptografia(string tipoCriptografia, string senha);
    }
}