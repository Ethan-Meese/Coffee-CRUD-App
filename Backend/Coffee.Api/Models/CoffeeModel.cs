using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Coffee.Api.Models
{
   public class CoffeeModel
    {
        [Key]
        // [Column("id")] --> I could do this but I dont have to because EntityFramwork does it for me.
        public int Id { get; set; }
        public string Name { get; set; }
        public string Texture { get; set; }
        public string Description { get; set; }
        public string Roast { get; set; }
        public string Origin { get; set; }
        public string Process { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }

    }
}

