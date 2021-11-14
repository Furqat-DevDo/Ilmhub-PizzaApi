using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaApi.Enteties
{
    public class PizzaEntity
    {
       
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        Guid Id{get;set;}

        [Required,MaxLength(255)]
        [NotNull]
        string Title{get;set;}
        [Required,MaxLength(3)]
        string ShortName{get;set;}
        [Required]
        EPizzaStockStatus stockStatus{get;set;}
        [Required,MaxLength(1024)]
        string Ingredients{get;set;}
        [Required,Range(0,1000)]
        double Price{get;set;}

        [Obsolete]
        public PizzaEntity(){}

         public PizzaEntity( string title, string shortName, EPizzaStockStatus stockStatus, string ingredients, double price)
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