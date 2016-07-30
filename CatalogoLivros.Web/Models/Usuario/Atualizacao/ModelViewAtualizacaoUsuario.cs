using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CatalogoLivros.Web.Models.Usuario.Atualizacao
{
    public class ModelViewAtualizacaoUsuario
    {
        #region Dados do Usuário

        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Campo Nome com no mínimo 3 e no máximo 80 caracteres.")]
        [Display(Name = "Nome: ")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Email é obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Campo Email com no mínimo 3 e no máximo 50 caracteres.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email: ")]
        public string Email { get; set; }

        //________________________________________

        [Required(ErrorMessage = "Campo Login é obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Campo Login com no mínimo 3 e no máximo 50 caracteres.")]
        [Display(Name = "Login: ")]
        public string Login { get; set; }

        //________________________________________

        public string EmailPesquisa { get; set; }

        //________________________________________

        public string LoginPesquisa { get; set; }

        #endregion


        #region Dados da Foto do Usuário

        [Required(ErrorMessage = "Campo Nome da Foto do Usuário é obrigatório")]
        [Display(Name = "Nome da Foto: ")]
        public string NomeFotoUsuario { get; set; }

        //________________________________________

        [Required(ErrorMessage = "Campo Descrição da Foto do Usuário é obrigatório")]
        [Display(Name = "Descrição da Foto: ")]
        public string DescricaoFotoUsuario { get; set; }

        #endregion
    }
}