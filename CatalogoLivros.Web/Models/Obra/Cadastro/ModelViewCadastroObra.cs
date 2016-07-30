using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using CatalogoLivros.Domain.Enum;

namespace CatalogoLivros.Web.Models.Obra.Cadastro
{
    public class ModelViewCadastroObra
    {
        #region Dados da Obra

        [Required(ErrorMessage = "Campo Titulo da Obra é obrigatório.")]
        //[RegularExpression("[A-Za-zÀ-àÁ-áÜ-ü0-9]", ErrorMessage = "Campo Titulo da Obra possue caracter(es) inválido(s). Informe outro Titulo da Obra.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Campo Titulo da Obra com no mínimo 3 e no máximo 100 caracteres.")]
        [Display(Name = "Titulo:")]
        public string Titulo { get; set; }

        //________________________________________

        [Required(ErrorMessage = "Campo Gênero da Obra é obrigatório.")]
        [Display(Name = "Gênero:")]
        public Genero Genero { get; set; }

        //________________________________________

        [Required(ErrorMessage = "Campo ISBN da Obra obrigatório.")]
        [Display(Name = "ISBN:")]
        public string ISBN { get; set; }

        //________________________________________

        [Required(ErrorMessage = "Campo Sinopse da Obra obrigatório.")]
        [StringLength(5000, MinimumLength = 3, ErrorMessage = "Campo Sinopse da Obra com no mínimo 3 e no máximo 255 caracteres.")]
        [Display(Name = "Sinopse:")]
        public string Sinopse { get; set; }

        //________________________________________

        [Display(Name = "Desejo cadastrar a Obra como: ")]
        public StatusObra StatusObra { get; set; }

        #endregion


        #region Dados da Foto da Obra

        [Required(ErrorMessage = "Campo Foto do Obra é obrigatório.")]
        [Display(Name = "Selecione a Foto: ")]
        public HttpPostedFileBase FotoObra { get; set; }

        //________________________________________

        [Required(ErrorMessage = "Campo Descrição da Obra é obrigatório.")]
        [Display(Name = "Descrição da Foto: ")]
        public string DescricaoFotoObra { get; set; }

        //________________________________________

        [StringLength(1000, MinimumLength = 3, ErrorMessage = "Campo Caminho da Foto da Obra com no mínimo 3 e no máximo 1000 caracteres.")]
        public string CaminhoFotoObra { get; set; }

        #endregion


        #region Dados do Autor da Obra

        [Required(ErrorMessage = "Campo Nome do Autor da Obra é obrigatório.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Campo Nome do Autor da Obra com no mínimo 3 e no máximo 50 caracteres.")]
        [Display(Name = "Nome do Autor:")]
        public string NomeAutor { get; set; }

        //________________________________________

        [StringLength(5000, MinimumLength = 3, ErrorMessage = "Campo Descrição do Autor da Obra com no mínimo 3 e no máximo 255 caracteres.")]
        [Display(Name = "Descrição do Autor:")]
        public string DescricaoAutor { get; set; }

        #endregion


        #region Dados da Editora da Obra

        [Required(ErrorMessage = "Campo Nome da Editora da Obra é obrigatório.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Campo Nome da Editora da Obra com no mínimo 3 e no máximo 50 caracteres.")]
        [Display(Name = "Nome da Editora:")]
        public string NomeEditora { get; set; }

        //________________________________________

        [Required(ErrorMessage = "Campo Descrição da Editora da Obra é obrigatório.")]
        [StringLength(5000, MinimumLength = 3, ErrorMessage = "Campo Descrição da Editora da Obra com no mínimo 3 e no máximo 255 caracteres.")]
        [Display(Name = "Descrição da Editora:")]
        public string DescricaoEditora { get; set; }

        //________________________________________

        [Required(ErrorMessage = "Campo Tipo da Editora da Obra é obrigatório.")]
        [Display(Name = "Tipo da Editora:")]
        public TipoEditora TipoEditora { get; set; }

        #endregion
    }
}