using PizzaApi.Enteties;
using PizzaApi.Models;

namespace PizzaApi.Mappers
{
    public static  class ModelToEntityPizzaMapper
    {
         public static Pizza ToPizzaEntities(this NewPizza newPizza)
        {
            return new Pizza(
                title: newPizza.Title,
                shortName: newPizza.ShortName,
                stockStatus: newPizza.stockStatus.ToEntitiesStockStatus(),
                ingredients: newPizza.Ingredients,
                price: newPizza.Price
            );
        }
        public static Pizza ToPizzaEntities(this UpdateOrder updatedPizza)
        {
            return new Pizza(
                title: updatedPizza.Title,
                shortName: updatedPizza.ShortName,
                stockStatus: updatedPizza.stockStatus.ToEntitiesStockStatus(),
                ingredients: updatedPizza.Ingredients,
                price: updatedPizza.Price
            );
        }
        public static Enteties.EPizzaStockStatus ToEntitiesStockStatus(this Models.EPizzaStockStatus stockStatus)
        {
            return stockStatus switch
            {
                Models.EPizzaStockStatus.In => Enteties.EPizzaStockStatus.In,
                _ => Enteties.EPizzaStockStatus.Out
            };
        }
    }
}