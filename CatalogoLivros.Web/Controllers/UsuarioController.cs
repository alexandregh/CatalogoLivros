using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CatalogoLivros.Util.Email;
using CatalogoLivros.Domain.Entity;
using CatalogoLivros.Web.Models.Usuario.Cadastro;
using CatalogoLivros.Web.Models.Usuario.Atualizacao;
using CatalogoLivros.Web.Models.Usuario.EmailUsuario;
using CatalogoLivros.DAL.Persistence.PersistenceUsuario;
using CatalogoLivros.SGBDDAL.DataSource;
using CatalogoLivros.DAL.Persistence.PersistenceObra;

namespace CatalogoLivros.Web.Controllers
{
    public class UsuarioController : Controller
    {
        #region Páginas

        public ActionResult Index()
        {
            return View();
        }

        //_____________________________________________

        public ActionResult CadastroUsuario()
        {
            return View();
        }

        //_____________________________________________

        public ActionResult AtualizacaoUsuario()
        {
            return View();
        }

        //_____________________________________________

        public ActionResult LoginUsuario()
        {
            return View();
        }

        //_____________________________________________

        public ActionResult EsqueciLogin()
        {
            return View();
        }

        //_____________________________________________

        public ActionResult EsqueciSenha()
        {
            return View();
        }

        #endregion
        

        #region Métodos

        [HttpPost]
        public ActionResult CadastrarUsuario(ModelViewCadastroUsuario modelUsuario)
        {
            if(ModelState.IsValid)
            {
                Usuario usuario = new Usuario();
                usuario.FotoUsuario = new FotoUsuario();
                UsuarioDal usuarioDal = new UsuarioDal();

                usuario.Nome = modelUsuario.Nome;
                usuario.Email = modelUsuario.Email;
                usuario.Login = modelUsuario.Login;

                usuario.DataCadastro = DateTime.Now;
                usuario.DataAlteracao = DateTime.Now;
                usuario.TipoCriptografia = modelUsuario.TipoCriptografia;

                usuario.Senha = usuarioDal.ReturnTipoCriptografia(modelUsuario.TipoCriptografia, modelUsuario.Senha);

                string tipoExtensaoFoto = modelUsuario.FotoUsuario.ContentType;
                string foto = modelUsuario.FotoUsuario.FileName;

                tipoExtensaoFoto = usuarioDal.ReturnExtensionFoto(tipoExtensaoFoto, foto);

                usuario.FotoUsuario.Foto = Guid.NewGuid().ToString() + "." + tipoExtensaoFoto;
                usuario.FotoUsuario.Nome = modelUsuario.NomeFotoUsuario;
                usuario.FotoUsuario.Descricao = modelUsuario.DescricaoFotoUsuario;

                if(usuarioDal.FindUsuarioByEmailLogin(usuario.Email, usuario.Login) != null)
                {
                    ViewBag.MensagemErro = "Login e/ou Email já cadastrado. Tente novamente.";
                }
                else
                {
                    usuarioDal.Insert(usuario);
                    string pathFotoUsuario = HttpContext.Server.MapPath("/Fotos/FotoUsuario/") + usuario.Nome.ToLower() + "_" + usuario.Login.ToLower();
                    string pathFotoObra = HttpContext.Server.MapPath("/Fotos/FotoObra/") + usuario.Nome.ToLower() + "_" + usuario.Login.ToLower();
                    usuarioDal.CreateDirectoryFoto(pathFotoUsuario, pathFotoObra);
                    pathFotoUsuario = usuarioDal.ReturnFotoFull(pathFotoUsuario, usuario.FotoUsuario.Foto);
                    modelUsuario.FotoUsuario.SaveAs(pathFotoUsuario); // usa a classe da Model de Cliente e não a classe da Entidade de Cliente.
                    ModelState.Clear();
                    ViewBag.MensagemOK = "Usuário " + usuario.Nome + " cadastrado com sucesso.";   
                }
            }
            return View("CadastroUsuario");
        }

        //______________________________________________________________________________

        [HttpPost]
        public ActionResult AtualizarUsuario(ModelViewAtualizacaoUsuario modelViewAtualizacaoUsuario)
        {
            if(ModelState.IsValid)
            {
                Usuario usuario = new Usuario();
                UsuarioDal usuarioDal = new UsuarioDal();

                usuario = usuarioDal.FindUsuarioByEmailLogin(modelViewAtualizacaoUsuario.EmailPesquisa, modelViewAtualizacaoUsuario.LoginPesquisa);

                if (usuario != null)
                {
                    modelViewAtualizacaoUsuario.EmailPesquisa = modelViewAtualizacaoUsuario.Email; // EmailPesquisa recebe o novo Email substituindo o Email original pesquisado.
                    modelViewAtualizacaoUsuario.LoginPesquisa = modelViewAtualizacaoUsuario.Login; // LoginPesquisa recebe o novo Login substituindo o Login original pesquisado.

                    usuario.Nome = modelViewAtualizacaoUsuario.Nome;
                    usuario.Email = modelViewAtualizacaoUsuario.Email;
                    usuario.Login = modelViewAtualizacaoUsuario.Login;
                    usuario.DataAlteracao = DateTime.Now;

                    usuario.FotoUsuario = new FotoUsuario();

                    usuario.FotoUsuario = usuarioDal.FindFotoUsuarioByIdFotoUsuario(usuario.IdUsuario);
                    if(usuario.FotoUsuario != null)
                    {
                        usuario.FotoUsuario.Nome = modelViewAtualizacaoUsuario.NomeFotoUsuario;
                        usuario.FotoUsuario.Descricao = modelViewAtualizacaoUsuario.DescricaoFotoUsuario;
                    }
                    usuarioDal.Update(usuario, usuario.FotoUsuario);
                    ViewBag.MensagemOk = "Dados do usuário " + usuario.Nome + " atualizados com sucesso.";
                    ModelState.Clear();
                    return View("AtualizacaoUsuario");
                }
                else
                {
                    ModelState.Clear();
                    ViewBag.MensagemErro = "Usuário com email " + modelViewAtualizacaoUsuario.Email + " e/ou com login " + modelViewAtualizacaoUsuario.Login + " não foi encontrado.";
                    return View("AtualizacaoUsuario");
                }
            }
            return View("AtualizacaoUsuario");
        }

        //______________________________________________________________________________

        [HttpPost]
        public ActionResult PesquisarUsuario(string email, string login)
        {
            using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
            {
                try
                {
                    ModelViewAtualizacaoUsuario modelViewAtualizacaoUsuario;
                    if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(login))
                    {
                        UsuarioDal usuarioDal = new UsuarioDal();
                        Usuario usuario = usuarioDal.FindUsuarioByEmailLogin(email, login);
                        if(usuario == null)
                        {
                            ModelState.Clear();
                            ViewBag.MensagemErro = "Usuário de email " + email + " e/ou de login " + login + " não foi encontrado.";
                            return View("AtualizacaoUsuario");
                        }
                        usuario.FotoUsuario = usuarioDal.FindFotoUsuarioByIdFotoUsuario(usuario.IdUsuario);
                        
                        if (usuario != null && usuario.FotoUsuario != null)
                        {
                            modelViewAtualizacaoUsuario = new ModelViewAtualizacaoUsuario();
                            
                            modelViewAtualizacaoUsuario.Nome = usuario.Nome;
                            modelViewAtualizacaoUsuario.Email = usuario.Email;
                            modelViewAtualizacaoUsuario.Login = usuario.Login;

                            modelViewAtualizacaoUsuario.EmailPesquisa = usuario.Email;
                            modelViewAtualizacaoUsuario.LoginPesquisa = usuario.Login;

                            modelViewAtualizacaoUsuario.NomeFotoUsuario = usuario.FotoUsuario.Nome;
                            modelViewAtualizacaoUsuario.DescricaoFotoUsuario = usuario.FotoUsuario.Descricao;

                            ViewBag.MensagemOk = "Usuario encontrado com sucesso.";
                            return View("AtualizacaoUsuario", modelViewAtualizacaoUsuario);
                        }
                        else
                        {
                            ModelState.Clear();
                            ViewBag.MensagemErro = "Usuário não foi encontrado.";
                            return View("AtualizacaoUsuario");
                        }
                    }
                    else
                    {
                        ViewBag.MensagemErro = "Campos Email e Login são obrigatórios.";
                    }
                    return View("AtualizacaoUsuario");
                }
                catch (NotSupportedException ex)
                {
                    throw new NotSupportedException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
                }
            }
        }

        //______________________________________________________________________________

        [HttpPost]
        public ActionResult LogarUsuario(string login, string senha)
        {
            using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
            {
                try
                {
                    if (login != string.Empty && senha != string.Empty)
                    {
                        UsuarioDal usuarioDal = new UsuarioDal();

                        Usuario usuario = usuarioDal.FindUsuarioByLoginSenha(login, senha);                        
                        if (usuario != null)
                        {
                            usuario.FotoUsuario = usuarioDal.FindFotoUsuarioByIdFotoUsuario(usuario.IdUsuario);
                            string foto = usuario.FotoUsuario.Foto;
                            FormsAuthentication.SetAuthCookie(usuario.Login, false);
                            FormsAuthentication.SetAuthCookie(foto, false);
                            Session.Add("usuarioAutenticado", usuario);
                            Session.Add("fotoUsuarioAutenticado", usuario.FotoUsuario);
                            return RedirectToAction("Index", "Obra");
                        }
                        else
                        {
                            ModelState.Clear();
                            ViewBag.MensagemErro = "Usuário " + login + " não foi encontrado. Acesso Negado.";
                            return View("LoginUsuario");
                        }
                    }
                    else
                    {
                        ViewBag.MensagemErro = "Campos Login e Senha são obrigatórios.";
                        return View("LoginUsuario");
                    }
                }
                catch (HttpException ex)
                {
                    throw new HttpException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (NotImplementedException ex)
                {
                    throw new NotImplementedException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (NotSupportedException ex)
                {
                    throw new NotSupportedException("Ocorreu o seguinte erro: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
                }
            }
        }

        //______________________________________________________________________________

        public ActionResult LogoutUsuario()
        {
            FormsAuthentication.SignOut();
            Session.Remove("usuarioAutenticado");
            Session.Remove("fotoUsuarioAutenticado");
            Session.Abandon();
            return View("Index");
        }

        //______________________________________________________________________________

        [HttpPost]
        public ActionResult RecuperarLogin(ModelViewEmailUsuario modelViewEmailUsuario)
        {
            try
            {
                if(!string.IsNullOrEmpty(modelViewEmailUsuario.Email))
                {
                    UsuarioDal usuarioDal = new UsuarioDal();
                    Usuario usuario = usuarioDal.FindLoginSenhaUsuario(modelViewEmailUsuario.Email);
                    if(usuario != null)
                    {
                        Email.SendEmail(usuario);
                        ViewBag.MensagemOk = "Um e-mail com seu Login foi enviado com sucesso.";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
            }
            return View("EsqueciLogin");
        }

        //______________________________________________________________________________

        [HttpPost]
        public ActionResult RecuperarSenha(ModelViewEmailUsuario modelViewEmailUsuario)
        {
            try
            {
                if (!string.IsNullOrEmpty(modelViewEmailUsuario.Email) && !string.IsNullOrEmpty(modelViewEmailUsuario.TipoCriptografia) && !string.IsNullOrEmpty(modelViewEmailUsuario.NovaSenha) && !string.IsNullOrEmpty(modelViewEmailUsuario.ConfirmaNovaSenha))
                {
                    UsuarioDal usuarioDal = new UsuarioDal();
                    Usuario usuario = usuarioDal.FindLoginSenhaUsuario(modelViewEmailUsuario.Email);
                    if (usuario != null)
                    {
                        usuario.FotoUsuario = new FotoUsuario();
                        string[] dadosNovaSenha = new string[2];

                        // dados da nova senha que foi alterada...
                        dadosNovaSenha[0] = modelViewEmailUsuario.NovaSenha;
                        dadosNovaSenha[1] = modelViewEmailUsuario.TipoCriptografia;

                        // atualizar senha...
                        usuario.TipoCriptografia = modelViewEmailUsuario.TipoCriptografia;
                        usuario.Senha = usuarioDal.ReturnTipoCriptografia(modelViewEmailUsuario.TipoCriptografia, modelViewEmailUsuario.NovaSenha);
                        usuario.FotoUsuario = usuarioDal.FindFotoUsuarioByIdFotoUsuario(usuario.IdUsuario);
                        usuarioDal.Update(usuario);

                        // enviar senha descriptografada...
                        Email.SendEmail(usuario, dadosNovaSenha);
                        ViewBag.MensagemOk = "Senha do Usuário " + usuario.Nome + " foi atualizada com sucesso.<br />Um e-mail com sua Nova Senha foi enviado com sucesso.";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
            }
            return View("EsqueciLogin");
        }

        #endregion
    }
}