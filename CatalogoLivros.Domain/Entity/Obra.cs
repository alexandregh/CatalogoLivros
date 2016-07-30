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
    [Table("TBObra")]
    public class Obra
    {
        #region Propriedades

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdObra")]
        public int IdObra { get; set; }

        //_______________________________________________________

        [Required]
        //[RegularExpression("^[A-Za-zÀ-Üà-ü0-9]$")]
        [StringLength(100, MinimumLength = 3)]
        [Column("Titulo")]
        public string Titulo { get; set; }

        //_______________________________________________________

        [Required]
        [Column("ISBN")]
        public long ISBN { get; set; }

        //_______________________________________________________

        [Required]
        [StringLength(5000, MinimumLength = 3)]
        [Column("Sinopse")]
        public string Sinopse { get; set; }

        //_______________________________________________________

        [Required]
        [Column("Genero")]
        public Genero Genero { get; set; }

        //_______________________________________________________

        [Required]
        [Column("StatusObra")]
        public StatusObra StatusObra { get; set; }

        //_______________________________________________________

        [Required]
        [Column("IdAutor")]
        public int IdAutor { get; set; } // FK

        //_______________________________________________________

        [Required]
        [Column("IdEditora")]
        public int IdEditora { get; set; } // FK

        #endregion


        #region Relacionamentos

        [ForeignKey("IdAutor")]
        public virtual Autor AutorObra { get; set; }

        //_______________________________________________________

        public virtual ICollection<FotoObra> FotosObra { get; set; }

        //_______________________________________________________

        [ForeignKey("IdEditora")]
        public virtual Editora EditoraObra { get; set; }

        #endregion
    }
}