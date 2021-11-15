using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaApi.Enteties
{
    public class Pizza
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
       public  Guid Id{get;set;}

        [Required,MaxLength(255)]
        [NotNull]
       public  string Title{get;set;}
        [Required,MaxLength(3)]
        public string ShortName{get;set;}
        [Required]
        public EPizzaStockStatus stockStatus{get;set;}
        [Required,MaxLength(1024)]
       public  string Ingredients{get;set;}
        [Required,Range(0,1000)]
       public  double Price{get;set;}

        [Obsolete]
        public Pizza(){}

         public Pizza( string title, string shortName, EPizzaStockStatus stockStatus, string ingredients, double price)
        {
            Id = Guid.NewGuid();
            Title = title;
            ShortName = shortName;
            this.stockStatus = stockStatus;
            Ingredients = ingredients;
            Price = price;
        }

    }
}