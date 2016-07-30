using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoLivros.Domain.Entity
{
    [Table("TBUsuario")]
    public class Usuario
    {
        #region Propriedades

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdUsuario")]
        public int IdUsuario { get; set; }

        //______________________________________________________

        [Required]
        [StringLength(80, MinimumLength = 3)]
        [Column("Nome")]
        public string Nome { get; set; }

        //______________________________________________________

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [DataType(DataType.EmailAddress)]
        [Index("INDEmail", IsUnique = true)]
        [Column("Email")]
        public string Email { get; set; }

        //______________________________________________________

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Index("INDLogin", IsUnique = true)]
        [Column("Login")]
        public string Login { get; set; }

        //______________________________________________________

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Column("Senha")]
        public string Senha { get; set; }

        //______________________________________________________

        [Required]
        [DataType(DataType.DateTime)]
        [Column("DataCadastro")]
        public DateTime DataCadastro { get; set; }

        //______________________________________________________

        [DataType(DataType.DateTime)]
        [Column("DataAlteracao")]
        public DateTime DataAlteracao { get; set; }

        //______________________________________________________

        [Required]
        [StringLength(4, MinimumLength = 3)]
        [Column("TipoCriptografia")]
        public string TipoCriptografia { get; set; }

        #endregion


        #region Relacionamentos

        [InverseProperty("Usuario")]
        public virtual FotoUsuario FotoUsuario { get; set; }

        #endregion
    }
}