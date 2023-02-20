using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SDSolutionsApp.Models
{
    public class RecyclableItem
    {
        public RecyclableItem()
        {
            this.Id = -1;
            this.Weight = 0;
            this.ComputedRate= 0;
            this.ItemDescription = "";
        }

        public RecyclableItem(int id, decimal weight, decimal computedRate, string itemDescription)
        {
            Id = id;
            Weight = weight;
            ComputedRate = computedRate;
            ItemDescription = itemDescription;
        }


        [Required, Key]
        public int Id { get; set; }

        [Required, ForeignKey("types")]
        public int RecylableTypeId { get; set; }  //1 to 1 relationship with Type, so only Id
        public virtual RecyclableType types { get; set; }

        public decimal Weight { get; set; }

        public decimal ComputedRate { get; set; }

        [MaxLength(150)]
        public string ItemDescription { get; set; }

    }
}