using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CatalogoLivros.Web.Models.Usuario.Cadastro
{
    public class ModelViewCadastroUsuario
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

        [Required(ErrorMessage = "Campo Senha é obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Campo Senha com no mínimo 3 e no máximo 50 caracteres.")]
        [Display(Name = "Senha: ")]
        public string Senha { get; set; }

        //________________________________________

        [Required(ErrorMessage = "Campo Tipo de Criptografia é obrigatório.")]
        [StringLength(4, MinimumLength = 3, ErrorMessage = "Campo Tipo de Criptografia com no mínimo 3 e no máximo 50 caracteres.")]
        [Display(Name = "Escolha o Tipo de Criptografia da Senha: ")]
        public string TipoCriptografia { get; set; }

        #endregion

        #region Dados da Foto do Usuário

        [Required(ErrorMessage = "Campo Foto do Usuário é obrigatório")]
        [Display(Name = "Selecione sua Foto: ")]
        public HttpPostedFileBase FotoUsuario { get; set; }

        //________________________________________

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