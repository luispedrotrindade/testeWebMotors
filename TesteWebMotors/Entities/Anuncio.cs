using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("tb_AnuncioWebmotors")]
    public class Anuncio
    {
        [Column("ID")]
        [Display(Description = "ID")]
        public int id { get; set; }

        [Column("marca")]
        [Display(Description = "Marca")]
        public string marca { get; set; }

        [Column("modelo")]
        [Display(Description = "Modelo")]
        public string modelo { get; set; }

        [Column("versao")]
        [Display(Description = "Versão")]
        public string versao { get; set; }

        [Column("ano")]
        [Display(Description = "Ano")]
        public int ano { get; set; }

        [Column("quilometragem")]
        [Display(Description = "Quilometragem")]
        public int quilometragem { get; set; }

        [Column("observacao")]
        [Display(Description = "Observação")]
        public string observacao { get; set; }
    }


    public class Anuncio2
    {
        [Column("ID")]
        [Display(Description = "ID")]
        public int Id { get; set; }

        //[Column("marca")]
        //[Display(Description = "Marca")]
        //public string marca { get; set; }

        //[Column("modelo")]
        //[Display(Description = "Modelo")]
        //public string modelo { get; set; }

        //[Column("versao")]
        //[Display(Description = "Versão")]
        //public string versao { get; set; }

        //[Column("ano")]
        //[Display(Description = "Ano")]
        //public int ano { get; set; }

        //[Column("quilometragem")]
        //[Display(Description = "Quilometragem")]
        //public int quilometragem { get; set; }

        //[Column("observacao")]
        //[Display(Description = "Observação")]
        //public string observacao { get; set; }
    }
}