using System;
using Microsoft.AspNetCore.Mvc;

namespace PizzaApi.Models{
    public class QueryPizza{
        [FromQuery]
        public Guid Id { get; set; }
        [FromQuery]
        public string Title{get;set;}
        [FromQuery]
        public double Price{get;set;}
        [FromQuery]
        public string Ingredients{get;set;}
    }
}