using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CatalogoLivros.Web.Models.Usuario.EmailUsuario
{
    public class ModelViewEmailUsuario
    {
        [Required(ErrorMessage = "Campo Email é obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Campo Email com no mínimo 3 e no máximo 50 caracteres.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email: ")]
        public string Email { get; set; }

        //_____________________________________________________

        [Required(ErrorMessage = "Campo Nova Senha é obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Campo Nova Senha com no mínimo 3 e no máximo 50 caracteres.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmaNovaSenha", ErrorMessage = "Campos Nova Senha e Confirmar Nova Senha deverão ser iguais.")]
        [Display(Name = "Nova Senha: ")]
        public string NovaSenha { get; set; }

        //_____________________________________________________

        [Required(ErrorMessage = "Campo Nova Senha é obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Campo Nova Senha com no mínimo 3 e no máximo 50 caracteres.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Nova Senha: ")]
        public string ConfirmaNovaSenha { get; set; }

        //_____________________________________________________

        [Required(ErrorMessage = "Campo Tipo de Criptografia é obrigatório.")]
        [StringLength(4, MinimumLength = 3, ErrorMessage = "Campo Tipo de Criptografia com no mínimo 3 e no máximo 50 caracteres.")]
        [Display(Name = "Escolha o Tipo de Criptografia da Nova Senha: ")]
        public string TipoCriptografia { get; set; }
    }
}