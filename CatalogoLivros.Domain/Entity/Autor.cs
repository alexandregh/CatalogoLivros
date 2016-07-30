using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoLivros.Domain.Entity
{
    [Table("TBAutor")]
    public class Autor
    {
        #region Propriedades

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdAutor")]
        public int IdAutor { get; set; }

        //______________________________________________________

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Column("Nome")]
        public string Nome { get; set; }

        //______________________________________________________

        [StringLength(5000, MinimumLength = 3)]
        [Column("Descricao")]
        public string Descricao { get; set; }

        #endregion


        #region Relacionamentos

        public virtual ICollection<Obra> Obras { get; set; }

        #endregion
    }
}