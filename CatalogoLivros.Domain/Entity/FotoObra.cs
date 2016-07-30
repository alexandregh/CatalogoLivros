using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoLivros.Domain.Entity
{
    [Table("TBFotoObra")]
    public class FotoObra
    {
        #region Propriedades

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdFotoObra")]
        public int IdFotoObra { get; set; }

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

        [StringLength(1000, MinimumLength = 3)]
        [Column("CaminhoFotoObra")]
        public string CaminhoFotoObra { get; set; }

        //______________________________________________________

        [Required]
        [Column("IdObra")]
        public int IdObra { get; set; } // FK

        #endregion


        #region Relacionamentos

        [ForeignKey("IdObra")]
        public virtual Obra Obra { get; set; }

        #endregion
    }
}