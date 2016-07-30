using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CatalogoLivros.Domain.Enum;

namespace CatalogoLivros.Domain.Entity
{
    [Table("TBEditora")]
    public class Editora
    {
        #region Propriedades

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdEditora")]
        public int IdEditora { get; set; }

        //______________________________________________________

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Column("Nome")]
        public string Nome { get; set; }

        //______________________________________________________

        [Required]
        [StringLength(5000, MinimumLength = 3)]
        [Column("Descricao")]
        public string Descricao { get; set; }

        //______________________________________________________

        [Required]
        [Column("TipoEditora")]
        public TipoEditora TipoEditora { get; set; }

        #endregion


        #region Relacionamentos

        public virtual ICollection<Obra> Obras { get; set; }

        #endregion
    }
}