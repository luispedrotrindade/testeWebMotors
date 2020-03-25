using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("GOL")]
    public class Anuncio
    {
        [Column("Id")]
        [Display(Description = "Código do Avião")]
        public int? Id { get; set; }

        [Column("Model")]
        [Display(Description = "Modelo do Avião")]
        public string Model { get; set; }

        [Column("QtdPassengers")]
        [Display(Description = "Quantidade de Passageiros")]
        public int QtdPassengers { get; set; }

        [Column("CreationDate")]
        [Display(Description = "Data de Criação")]
        public DateTime? CreationDate { get; set; }
    }
}
