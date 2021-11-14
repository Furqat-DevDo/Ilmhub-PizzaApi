using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace PizzaApi.Models
{
    public class Pizza
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        Guid Id{get;set;}

        [Required,MaxLength(255)]
        [NotNull]
        string Title{get;set;}

        [Required,MaxLength(3)]
        string ShortName{get;set;}

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        EPizzaStockStatus stockStatus{get;set;}

        [Required,MaxLength(1024)]
        string Ingredients{get;set;}

        [Required,Range(0,1000)]
        double Price{get;set;}
        
    }
}