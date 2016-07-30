using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CatalogoLivros.Domain.Entity;
using CatalogoLivros.Web.Models.Obra.Cadastro;
using CatalogoLivros.Web.Models.Obra.Atualizacao;
using CatalogoLivros.Web.Models.Obra.Exibicao;
using CatalogoLivros.Web.Models.Obra.Pesquisa;
using CatalogoLivros.Web.Models.Obra.AtivacaoDesativacao;
using CatalogoLivros.DAL.Persistence.PersistenceObra;
using CatalogoLivros.Domain.Enum;
using CatalogoLivros.SGBDDAL.DataSource;
using PagedList;

namespace CatalogoLivros.Web.Controllers
{
    [Authorize]
    public class ObraController : Controller
    {
        ModelViewAtivacaoDesativacao modelDadosObra = new ModelViewAtivacaoDesativacao();

        #region Páginas

        public ActionResult Index()
        {
            return View();
        }

        //____________________________________________

        public ActionResult CadastroObra()
        {
            return View();
        }

        //____________________________________________

        public ActionResult AtualizacaoObra()
        {
            return View();
        }

        //____________________________________________

        public ActionResult AtivacaoDesativacaoObra()
        {
            return View();
        }

        //____________________________________________

        public ActionResult PesquisaObra()
        {
            return View();
        }

        //____________________________________________

        public ActionResult ExibicaoObras()
        {
            return this.ExibirObras(null);
        }

        //____________________________________________

        public ActionResult ExibicaoObrasAtivas()
        {
            return this.ExibirObrasAtivas(null);
        }

        //____________________________________________

        public ActionResult ExibicaoObrasInativas()
        {
            return this.ExibirObrasInativas(null);
        }

        //____________________________________________

        public ActionResult CatalogoServicosFuncionalidades()
        {
            return View();
        }

        #endregion


        #region Métodos

        [HttpPost]
        public ActionResult CadastrarObra(ModelViewCadastroObra modelObra)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Obra obra = new Obra();
                    obra.AutorObra = new Autor();
                    FotoObra fotoObra = new FotoObra();
                    obra.EditoraObra = new Editora();
                    ObraDal obraDal = new ObraDal();

                    obra.Titulo = modelObra.Titulo;
                    obra.Genero = modelObra.Genero;

                    modelObra.ISBN = modelObra.ISBN;
                    obra.ISBN = obraDal.ReturnConvertionISBNByLong(modelObra.ISBN);
                    obra.Sinopse = modelObra.Sinopse;
                    obra.StatusObra = modelObra.StatusObra;

                    fotoObra.Foto = modelObra.FotoObra.FileName;
                    fotoObra.Descricao = modelObra.DescricaoFotoObra;

                    obra.AutorObra.Nome = modelObra.NomeAutor;
                    obra.AutorObra.Descricao = modelObra.DescricaoAutor;

                    obra.EditoraObra.Nome = modelObra.NomeEditora;
                    obra.EditoraObra.TipoEditora = modelObra.TipoEditora;
                    obra.EditoraObra.Descricao = modelObra.DescricaoEditora;

                    Obra obraExists = obraDal.FindObraByTituloISBN(obra.Titulo, obra.ISBN);

                    if(obraExists != null)
                    {
                        ViewBag.MensagemErro = "Esta Obra já está cadastrada. Tente novamente.";
                    }
                    else
                    {
                        string tipoExtensaoFoto = modelObra.FotoObra.ContentType;
                        string foto = modelObra.FotoObra.FileName;

                        tipoExtensaoFoto = obraDal.ReturnExtensionFoto(tipoExtensaoFoto, foto);

                        fotoObra.Foto = Guid.NewGuid().ToString() + "." + tipoExtensaoFoto;
                        fotoObra.Descricao = modelObra.DescricaoFotoObra;

                        Usuario usuarioAutenticado = (Usuario)Session["usuarioAutenticado"];
                        if(usuarioAutenticado != null)
                        {
                            string pathFotoObra = HttpContext.Server.MapPath("/Fotos/FotoObra/") + usuarioAutenticado.Nome.ToLower() + "_" + usuarioAutenticado.Login.ToLower() + "\\" + obra.ISBN + "_" + obra.Titulo.ToLower();
                            obraDal.CreateDirectoryFoto(pathFotoObra);
                            pathFotoObra = obraDal.ReturnFotoFull(pathFotoObra, fotoObra.Foto);
                            modelObra.FotoObra.SaveAs(pathFotoObra); // usa a classe da Model de Cliente e não a classe da Entidade de Cliente.
                            fotoObra.CaminhoFotoObra = pathFotoObra;
                            obraDal.Insert(obra, fotoObra);
                            ModelState.Clear();
                            ViewBag.MensagemOK = "A Obra " + obra.Titulo + " foi cadastrada com sucesso.";
                        }
                        else
                        {
                            Response.Redirect("/Home/Index");
                        }
                    }
                }
                return View("CadastroObra");
            }
            catch(NotImplementedException ex)
            {
                throw new NotImplementedException("Ocorreu o seguinte erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
            }
        }

        //_______________________________________________________________________

        [HttpPost]
        public ActionResult AtualizarObra(ModelViewAtualizacaoObra modelAtualizacaoObra)
        {

            return null;
        }

        //_______________________________________________________________________

        [HttpGet]
        public ActionResult PesquisarObra(ModelViewPesquisaObra modelViewPesquisaObra)
        {
            try
            {
                ModelViewPesquisaObra modelDadosObra = new ModelViewPesquisaObra();
                bool flagViewBag = false;
                if (string.IsNullOrEmpty(modelViewPesquisaObra.Titulo) && string.IsNullOrEmpty(modelViewPesquisaObra.NomeAutor) && modelViewPesquisaObra.ISBN == 0)
                {
                    ViewBag.MensagemErro = "Erro. Preencha pelo menos um campo.";
                    flagViewBag = true;
                }
                else
                {
                    using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
                    {
                        Obra obra = new Obra();
                        obra.AutorObra = new Autor();
                        obra.EditoraObra = new Editora();
                        FotoObra fotoObra = new FotoObra();
                        ObraDal obraDal = new ObraDal();

                        string[] collectionParam = new string[4];
                        collectionParam = obraDal.ReturnParam(modelViewPesquisaObra.Titulo, modelViewPesquisaObra.NomeAutor, modelViewPesquisaObra.ISBN);
                        if (Convert.ToInt32(collectionParam[3]) == 0)
                        {
                            ViewBag.MensagemErro = "Erro. Preencha pelo menos um campo.";
                        }
                        else
                        {
                            if (Convert.ToInt32(collectionParam[3]) == 3)
                            {
                                obra = obraDal.FindObra(modelViewPesquisaObra.Titulo, modelViewPesquisaObra.NomeAutor, modelViewPesquisaObra.ISBN);
                            }
                            if (Convert.ToInt32(collectionParam[3]) == 2)
                            {
                                obra = obraDal.ReturnTypeParam(collectionParam);
                            }
                            if (Convert.ToInt32(collectionParam[3]) == 1)
                            {
                                obra = obraDal.ReturnTypeParam(collectionParam);
                            }
                        }
                        if (obra == null)
                        {
                            ViewBag.MensagemErro = "Não foi encontrada nenhuma Obra pesquisada.";
                            return View("PesquisaObra");
                        }
                        obra.AutorObra = obraDal.ReturnDataAutor(obra);
                        obra.EditoraObra = obraDal.ReturnDataEditora(obra);
                        fotoObra = obraDal.ReturnFotoObra(obra);

                        ModelViewPesquisaObra itensObra = new ModelViewPesquisaObra();

                        string[] foto = fotoObra.CaminhoFotoObra.Split('\\');

                        Usuario usuarioAutenticado = (Usuario)Session["usuarioAutenticado"];
                        if(usuarioAutenticado != null)
                        {
                            itensObra.CaminhoFotoObra = "/Fotos/FotoObra/" + usuarioAutenticado.Nome.ToLower() + "_" + usuarioAutenticado.Login.ToLower() + "/" + obra.ISBN + "_" + obra.Titulo.ToLower() + "/" + foto[12];
                            itensObra.Titulo = obra.Titulo;
                            itensObra.Genero = obra.Genero;
                            itensObra.ISBN = obra.ISBN;
                            itensObra.StatusObra = obra.StatusObra;
                            itensObra.Sinopse = obra.Sinopse;

                            itensObra.NomeAutor = obra.AutorObra.Nome;
                            itensObra.DescricaoAutor = obra.AutorObra.Descricao;

                            itensObra.NomeEditora = obra.EditoraObra.Nome;
                            itensObra.TipoEditora = obra.EditoraObra.TipoEditora;

                            modelDadosObra = itensObra;
                        }
                        else
                        {
                            Response.Redirect("/Home/Index");
                        }
                    }
                }

                if (flagViewBag)
                {
                    return View("PesquisaObra");
                }
                else
                {
                    ViewBag.MensagemOK = "Pesquisa realizada com sucesso.";
                    return View("PesquisaObra", modelDadosObra);
                }
            }
            catch(NotImplementedException ex)
            {
                throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
            }
        }

        //_______________________________________________________________________

        [HttpGet]
        public ActionResult PesquisarAtualizarObras(ModelViewAtualizacaoObra modelViewAtualizacaoObra)
        {
            try
            {
                ModelViewAtualizacaoObra modelDadosObra = new ModelViewAtualizacaoObra();
                bool flagViewBag = false;
                if (string.IsNullOrEmpty(modelViewAtualizacaoObra.Titulo) && string.IsNullOrEmpty(modelViewAtualizacaoObra.NomeAutor) && modelViewAtualizacaoObra.ISBN == 0)
                {
                    ViewBag.MensagemErro = "Erro. Preencha pelo menos um campo.";
                    flagViewBag = true;
                }
                else
                {
                    using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
                    {
                        Obra obra = new Obra();
                        obra.AutorObra = new Autor();
                        obra.EditoraObra = new Editora();
                        FotoObra fotoObra = new FotoObra();
                        ObraDal obraDal = new ObraDal();

                        string[] collectionParam = new string[4];
                        collectionParam = obraDal.ReturnParam(modelViewAtualizacaoObra.Titulo, modelViewAtualizacaoObra.NomeAutor, modelViewAtualizacaoObra.ISBN);
                        if (Convert.ToInt32(collectionParam[3]) == 0)
                        {
                            ViewBag.MensagemErro = "Erro. Preencha pelo menos um campo.";
                        }
                        else
                        {
                            if (Convert.ToInt32(collectionParam[3]) == 3)
                            {
                                obra = obraDal.FindObra(modelViewAtualizacaoObra.Titulo, modelViewAtualizacaoObra.NomeAutor, modelViewAtualizacaoObra.ISBN);
                            }
                            if (Convert.ToInt32(collectionParam[3]) == 2)
                            {
                                obra = obraDal.ReturnTypeParam(collectionParam);
                            }
                            if (Convert.ToInt32(collectionParam[3]) == 1)
                            {
                                obra = obraDal.ReturnTypeParam(collectionParam);
                            }
                        }
                        if (obra == null)
                        {
                            ViewBag.MensagemErro = "Não foi encontrada nenhuma Obra pesquisada.";
                            return View("AtualizacaoObra");
                        }
                        obra.AutorObra = obraDal.ReturnDataAutor(obra);
                        obra.EditoraObra = obraDal.ReturnDataEditora(obra);
                        fotoObra = obraDal.ReturnFotoObra(obra);

                        ModelViewAtualizacaoObra itensObra = new ModelViewAtualizacaoObra();

                        string[] foto = fotoObra.CaminhoFotoObra.Split('\\');

                        Usuario usuarioAutenticado = (Usuario)Session["usuarioAutenticado"];
                        if (usuarioAutenticado != null)
                        {
                            itensObra.CaminhoFotoObra = "/Fotos/FotoObra/" + usuarioAutenticado.Nome.ToLower() + "_" + usuarioAutenticado.Login.ToLower() + "/" + obra.ISBN + "_" + obra.Titulo.ToLower() + "/" + foto[12];
                            itensObra.Titulo = obra.Titulo;
                            itensObra.Genero = obra.Genero;
                            itensObra.ISBN = obra.ISBN;
                            itensObra.Sinopse = obra.Sinopse;

                            itensObra.NomeAutor = obra.AutorObra.Nome;
                            itensObra.DescricaoAutor = obra.AutorObra.Descricao;

                            itensObra.NomeEditora = obra.EditoraObra.Nome;
                            itensObra.TipoEditora = obra.EditoraObra.TipoEditora;
                            itensObra.DescricaoEditora = obra.EditoraObra.Descricao;

                            modelDadosObra = itensObra;
                        }
                        else
                        {
                            Response.Redirect("/Home/Index");
                        }                        
                    }
                }

                if (flagViewBag)
                {
                    return View("AtualizacaoObra");
                }
                else
                {
                    ViewBag.MensagemOK = "Pesquisa realizada com sucesso.";
                    return View("AtualizacaoObra", modelDadosObra);
                }
            }
            catch(NotImplementedException ex)
            {
                throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
            }
        }

        //_______________________________________________________________________

        [HttpGet]
        public ActionResult PesquisarObrasAtivasDesativas(ModelViewAtivacaoDesativacao modelViewAtivacaoDesativacao)
        {
            try
            {
                bool flagViewBag = false;
                if (string.IsNullOrEmpty(modelViewAtivacaoDesativacao.Titulo) && string.IsNullOrEmpty(modelViewAtivacaoDesativacao.NomeAutor) && modelViewAtivacaoDesativacao.ISBN == 0)
                {
                    ViewBag.MensagemErro = "Erro. Preencha pelo menos um campo.";
                    flagViewBag = true;
                }
                else
                {
                    using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
                    {
                        Obra obra = new Obra();
                        obra.AutorObra = new Autor();
                        obra.EditoraObra = new Editora();
                        FotoObra fotoObra = new FotoObra();
                        ObraDal obraDal = new ObraDal();

                        string[] collectionParam = new string[4];
                        collectionParam = obraDal.ReturnParam(modelViewAtivacaoDesativacao.Titulo, modelViewAtivacaoDesativacao.NomeAutor, modelViewAtivacaoDesativacao.ISBN);
                        if (Convert.ToInt32(collectionParam[3]) == 0)
                        {
                            ViewBag.MensagemErro = "Erro. Preencha pelo menos um campo.";
                        }
                        else
                        {
                            if (Convert.ToInt32(collectionParam[3]) == 3)
                            {
                                obra = obraDal.FindObra(modelViewAtivacaoDesativacao.Titulo, modelViewAtivacaoDesativacao.NomeAutor, modelViewAtivacaoDesativacao.ISBN);
                            }
                            if (Convert.ToInt32(collectionParam[3]) == 2)
                            {
                                obra = obraDal.ReturnTypeParam(collectionParam);
                            }
                            if (Convert.ToInt32(collectionParam[3]) == 1)
                            {
                                obra = obraDal.ReturnTypeParam(collectionParam);
                            }
                        }
                        if (obra == null)
                        {
                            ViewBag.MensagemErro = "Não foi encontrada nenhuma Obra pesquisada.";
                            return View("AtivacaoDesativacaoObra");
                        }
                        obra.AutorObra = obraDal.ReturnDataAutor(obra);
                        obra.EditoraObra = obraDal.ReturnDataEditora(obra);
                        fotoObra = obraDal.ReturnFotoObra(obra);

                        ModelViewAtivacaoDesativacao itensObra = new ModelViewAtivacaoDesativacao();

                        string[] foto = fotoObra.CaminhoFotoObra.Split('\\');

                        if (obra != null)
                        {
                            Usuario usuarioAutenticado = (Usuario)Session["usuarioAutenticado"];
                            if (usuarioAutenticado != null)
                            {
                                itensObra.CaminhoFotoObra = "/Fotos/FotoObra/" + usuarioAutenticado.Nome.ToLower() + "_" + usuarioAutenticado.Login.ToLower() + "/" + obra.ISBN + "_" + obra.Titulo.ToLower() + "/" + foto[12];
                                itensObra.Titulo = obra.Titulo;
                                itensObra.Genero = obra.Genero;
                                itensObra.ISBN = obra.ISBN;
                                itensObra.StatusObra = obra.StatusObra;
                                itensObra.Sinopse = obra.Sinopse;

                                itensObra.NomeAutor = obra.AutorObra.Nome;
                                itensObra.DescricaoAutor = obra.AutorObra.Descricao;

                                itensObra.NomeEditora = obra.EditoraObra.Nome;
                                itensObra.TipoEditora = obra.EditoraObra.TipoEditora;

                                modelDadosObra = itensObra;
                            }
                            else
                            {
                                Redirect("/Home/Index");
                            }
                        }
                    }
                }

                if (flagViewBag)
                {
                    return View("AtivacaoDesativacaoObra");
                }
                else
                {
                    ViewBag.MensagemOK = "Pesquisa realizada com sucesso.";
                    return View("AtivacaoDesativacaoObra", modelDadosObra);
                }
            }
            catch (NotImplementedException ex)
            {
                throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
            }
        }

        //_______________________________________________________________________

        [HttpPost]
        public ActionResult AtivarDesativarObras(ModelViewAtivacaoDesativacao modelViewAtivacaoDesativacao, long ISBN)
        {
            try
            {
                using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
                {
                    Obra obra = new Obra();
                    obra.AutorObra = new Autor();
                    obra.EditoraObra = new Editora();
                    FotoObra fotoObra = new FotoObra();
                    ObraDal obraDal = new ObraDal();

                    if (modelViewAtivacaoDesativacao.StatusObra == StatusObra.Ativo)
                    {
                        obra = obraDal.FindObraByISBN(ISBN);
                        obra.StatusObra = StatusObra.Ativo;
                        obraDal.Update(obra);
                        ViewBag.MensagemOK = "Obra ativada com sucesso.";
                    }
                    if (modelViewAtivacaoDesativacao.StatusObra == StatusObra.Inativo)
                    {
                        obra = obraDal.FindObraByISBN(ISBN);
                        obra.StatusObra = StatusObra.Inativo;
                        obraDal.Update(obra);
                        ViewBag.MensagemOK = "Obra inativada com sucesso.";
                    }
                }
                return View("AtivacaoDesativacaoObra");
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
            }
        }

        //_______________________________________________________________________

        [HttpGet]
        public ActionResult ExibirObras(int? pagina)
        {
            try
            {
                List<ModelViewExibicaoObras> modelDadosObras = new List<ModelViewExibicaoObras>(); // cria uma lista de ModelViewExibicaoObras.
                List<ModelViewExibicaoObras> listagemDadosObra = new List<ModelViewExibicaoObras>(); //
                ObraDal obraDal = new ObraDal();

                int maximumRows = 1;
                int startRowIndex = (pagina ?? 1);

                using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
                {
                    foreach (var obra in dbCatalogoLivros.Obra.ToList())
                    {
                        ModelViewExibicaoObras itensObras = new ModelViewExibicaoObras(); // para cada regisrto da lista de ModelViewExibicaoObras cria uma instâcia de ModelViewExibicaoObras com seus dados.
                        FotoObra fotoObra = new FotoObra();
                        fotoObra = obraDal.ReturnFotoObra(obra);
                        string[] foto = fotoObra.CaminhoFotoObra.Split('\\');

                        if (obra != null)
                        {
                            Usuario usuarioAutenticado = (Usuario)Session["usuarioAutenticado"];
                            itensObras.CaminhoFotoObra = "/Fotos/FotoObra/" + usuarioAutenticado.Nome.ToLower() + "_" + usuarioAutenticado.Login.ToLower() + "/" + obra.ISBN + "_" + obra.Titulo.ToLower() + "/" + foto[12];
                            itensObras.Titulo = obra.Titulo;
                            itensObras.Genero = obra.Genero;
                            itensObras.ISBN = obra.ISBN;
                            itensObras.StatusObra = obra.StatusObra;
                            itensObras.Sinopse = obra.Sinopse;

                            itensObras.NomeAutor = obra.AutorObra.Nome;
                            itensObras.DescricaoAutor = obra.AutorObra.Descricao;

                            itensObras.NomeEditora = obra.EditoraObra.Nome;
                            itensObras.TipoEditora = obra.EditoraObra.TipoEditora;

                            modelDadosObras.Add(itensObras);
                        }
                        else
                        {
                            Response.Redirect("/Home/Index");
                        }
                    }
                    listagemDadosObra = modelDadosObras;
                }
                return View("ExibicaoObras", listagemDadosObra.ToPagedList(startRowIndex, maximumRows));
            }
            catch (NotImplementedException ex)
            {
                throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
            }
        }

        //_______________________________________________________________________

        [HttpGet]
        public ActionResult ExibirObrasAtivas(int? pagina)
        {
            try
            {
                List<ModelViewExibicaoObras> modelDadosObras = new List<ModelViewExibicaoObras>(); // cria uma lista de ModelViewExibicaoObras.
                List<ModelViewExibicaoObras> listagemDadosObra = new List<ModelViewExibicaoObras>(); //
                ObraDal obraDal = new ObraDal();

                int maximumRows = 1;
                int startRowIndex = (pagina ?? 1);

                using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
                {
                    foreach (var obra in dbCatalogoLivros.Obra.ToList())
                    {
                        ModelViewExibicaoObras itensObras = new ModelViewExibicaoObras(); // para cada regisrto da lista de ModelViewExibicaoObras cria uma instâcia de ModelViewExibicaoObras com seus dados.
                        FotoObra fotoObra = new FotoObra();
                        fotoObra = obraDal.ReturnFotoObra(obra);
                        string[] foto = fotoObra.CaminhoFotoObra.Split('\\');

                        if (obra != null)
                        {
                            Usuario usuarioAutenticado = (Usuario)Session["usuarioAutenticado"];

                            if (obra.StatusObra == StatusObra.Ativo)
                            {
                                itensObras.CaminhoFotoObra = "/Fotos/FotoObra/" + usuarioAutenticado.Nome.ToLower() + "_" + usuarioAutenticado.Login.ToLower() + "/" + obra.ISBN + "_" + obra.Titulo.ToLower() + "/" + foto[12];
                                itensObras.Titulo = obra.Titulo;
                                itensObras.Genero = obra.Genero;
                                itensObras.ISBN = obra.ISBN;
                                itensObras.StatusObra = obra.StatusObra;
                                itensObras.Sinopse = obra.Sinopse;

                                itensObras.NomeAutor = obra.AutorObra.Nome;
                                itensObras.DescricaoAutor = obra.AutorObra.Descricao;

                                itensObras.NomeEditora = obra.EditoraObra.Nome;
                                itensObras.TipoEditora = obra.EditoraObra.TipoEditora;

                                modelDadosObras.Add(itensObras);
                            }
                        }
                        else
                        {
                            Response.Redirect("/Home/Index");
                        }
                    }
                    listagemDadosObra = modelDadosObras;
                }
                if (listagemDadosObra.Count != 0)
                {
                    return View("ExibicaoObrasAtivas", listagemDadosObra.ToPagedList(startRowIndex, maximumRows));
                }
                else
                {
                    ViewBag.MensagemErro = "Não foram encontradas nenhuma Obra Ativa.";
                    return View("ExibicaoObrasAtivas");
                }
            }
            catch (NotImplementedException ex)
            {
                throw new NotImplementedException("Ocorreu o seguinte erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
            }
        }

        //_______________________________________________________________________

        [HttpGet]
        public ActionResult ExibirObrasInativas(int? pagina)
        {
            try
            {
                List<ModelViewExibicaoObras> modelDadosObras = new List<ModelViewExibicaoObras>(); // cria uma lista de ModelViewExibicaoObras.
                List<ModelViewExibicaoObras> listagemDadosObra = new List<ModelViewExibicaoObras>(); //
                ObraDal obraDal = new ObraDal();

                int maximumRows = 1;
                int startRowIndex = (pagina ?? 1);

                using (DBCatalogoLivros dbCatalogoLivros = new DBCatalogoLivros())
                {
                    foreach (var obra in dbCatalogoLivros.Obra.ToList())
                    {
                        ModelViewExibicaoObras itensObras = new ModelViewExibicaoObras(); // para cada regisrto da lista de ModelViewExibicaoObras cria uma instâcia de ModelViewExibicaoObras com seus dados.
                        FotoObra fotoObra = new FotoObra();
                        fotoObra = obraDal.ReturnFotoObra(obra);
                        string[] foto = fotoObra.CaminhoFotoObra.Split('\\');

                        if (obra != null)
                        {
                            Usuario usuarioAutenticado = (Usuario)Session["usuarioAutenticado"];

                            if (obra.StatusObra == StatusObra.Inativo)
                            {
                                itensObras.CaminhoFotoObra = "/Fotos/FotoObra/" + usuarioAutenticado.Nome.ToLower() + "_" + usuarioAutenticado.Login.ToLower() + "/" + obra.ISBN + "_" + obra.Titulo.ToLower() + "/" + foto[12];
                                itensObras.Titulo = obra.Titulo;
                                itensObras.Genero = obra.Genero;
                                itensObras.ISBN = obra.ISBN;
                                itensObras.StatusObra = obra.StatusObra;
                                itensObras.Sinopse = obra.Sinopse;

                                itensObras.NomeAutor = obra.AutorObra.Nome;
                                itensObras.DescricaoAutor = obra.AutorObra.Descricao;

                                itensObras.NomeEditora = obra.EditoraObra.Nome;
                                itensObras.TipoEditora = obra.EditoraObra.TipoEditora;

                                modelDadosObras.Add(itensObras);
                            }
                        }
                        else
                        {
                            Response.Redirect("/Home/Index");
                        }
                    }
                    listagemDadosObra = modelDadosObras;
                }
                if (listagemDadosObra.Count != 0)
                {
                    return View("ExibicaoObrasInativas", listagemDadosObra.ToPagedList(startRowIndex, maximumRows));
                }
                else
                {
                    ViewBag.MensagemErro = "Não foram encontradas nenhuma Obra Inativa.";
                    return View("ExibicaoObrasInativas");
                }
            }
            catch (NotImplementedException ex)
            {
                throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
            }
        }

        #endregion
    }
}