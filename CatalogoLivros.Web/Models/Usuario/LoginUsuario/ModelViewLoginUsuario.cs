using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CatalogoLivros.Web.Models.Usuario.LoginUsuario
{
    public class ModelViewLoginUsuario
    {
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

        [Required(ErrorMessage = "Campo Email é obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Campo Email com no mínimo 3 e no máximo 50 caracteres.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email: ")]
        public string Email { get; set; }
    }
}