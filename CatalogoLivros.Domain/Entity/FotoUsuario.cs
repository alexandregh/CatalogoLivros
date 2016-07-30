using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoLivros.Domain.Entity
{
    [Table("TBFotoUsuario")]
    public class FotoUsuario
    {
        #region Propriedades

        [Key, ForeignKey("Usuario")]
        [Column("IdFotoUsuario")]
        public int IdFotoUsuario { get; set; }

        //______________________________________________________

        [Required]
        [StringLength(255)]
        [DataType(DataType.ImageUrl)]
        [Column("Foto")]
        public string Foto { get; set; }

        //______________________________________________________

        [Required]
        [StringLength(5000, MinimumLength = 3)]
        [Column("Descricao")]
        public string Descricao { get; set; }

        //______________________________________________________

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Column("Nome")]
        public string Nome { get; set; }

        #endregion


        #region Relacionamentos

        [Required]
        [InverseProperty("FotoUsuario")]
        public virtual Usuario Usuario { get; set; }

        #endregion
    }
}