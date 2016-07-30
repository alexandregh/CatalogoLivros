using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using CatalogoLivros.Domain.Enum;

namespace CatalogoLivros.Web.Models.Obra.AtivacaoDesativacao
{
    public class ModelViewAtivacaoDesativacao
    {
        #region Dados da Obra

        [Display(Name = "Titulo:")]
        public string Titulo { get; set; }

        //________________________________________

        [Display(Name = "Gênero:")]
        public Genero Genero { get; set; }

        //________________________________________

        [Display(Name = "ISBN:")]
        public long ISBN { get; set; }

        //________________________________________

        [Display(Name = "Sinopse:")]
        public string Sinopse { get; set; }

        //________________________________________

        [Display(Name = "Status: ")]
        public StatusObra StatusObra { get; set; }

        #endregion


        #region Dados da Foto da Obra

        [Display(Name = "Selecione a Foto: ")]
        public HttpPostedFileBase FotoObra { get; set; }

        //________________________________________

        [Display(Name = "Descrição da Foto: ")]
        public string DescricaoFotoObra { get; set; }

        //________________________________________

        public string CaminhoFotoObra { get; set; }

        #endregion


        #region Dados do Autor da Obra

        [Display(Name = "Nome do Autor:")]
        public string NomeAutor { get; set; }

        //________________________________________

        [Display(Name = "Descrição do Autor:")]
        public string DescricaoAutor { get; set; }

        #endregion


        #region Dados da Editora da Obra

        [Display(Name = "Nome da Editora:")]
        public string NomeEditora { get; set; }

        //________________________________________

        [Display(Name = "Descrição da Editora:")]
        public string DescricaoEditora { get; set; }

        //________________________________________

        [Display(Name = "Tipo da Editora:")]
        public TipoEditora TipoEditora { get; set; }

        #endregion
    }
}