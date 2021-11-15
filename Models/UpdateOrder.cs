using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace PizzaApi.Models
{
    public class UpdateOrder
    {   
        public  Guid id {get ;set;}
        [Required,MaxLength(255)]
        [NotNull]
        public string Title{get;set;}

        [Required,MaxLength(3)]
        public string ShortName{get;set;}
        public EPizzaStockStatus stockStatus{get;set;}

        [Required,MaxLength(1024)]
        public string Ingredients{get;set;}

        [Required,Range(0,1000)]
        public double Price{get;set;} 
    }
}