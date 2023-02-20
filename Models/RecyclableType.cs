using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SDSolutionsApp.Models
{
    public class RecyclableType
    {
        public RecyclableType()
        {
            Id = -1;
            Type = "";
            Rate = 0;
            MinKg = 0;
            MaxKg = 0;
        }

        public RecyclableType(int id, string type, decimal rate, decimal minKg, decimal maxKg)
        {
            Id = id;
            Type = type;
            Rate = rate;
            MinKg = minKg;
            MaxKg = maxKg;
        }

        [Required, Key]
        public int Id { get; set; }

        [MaxLength(150), DisplayName("Type")]
        public string Type { get; set; }

        [DisplayName("Rate")]
        public decimal Rate { get; set; }

        [DisplayName("MinKg")]
        public decimal MinKg { get; set; }

        [DisplayName("MaxKg")]
        public decimal MaxKg { get; set;}

    }
}