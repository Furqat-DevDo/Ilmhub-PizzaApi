using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PizzaApi.Enteties;

namespace PizzaApi.Services
{
  public interface IStorageService
    {
        Task<(bool IsSuccess, Exception exception)> InsertPizzaAsync(Pizza pizza);
        Task<(bool IsSuccess, Exception exception, List<Models.NewPizza> pizza)> GetPizzaAsync();
        Task<(bool IsSuccess, Exception exception, Pizza pizzaResult)> GetPizzaAsync(Guid Id);
        Task<(bool isSuccess, Exception exception)> UpdateOrderAsync(Enteties.Pizza pizza);

        Task<(bool isSuccess, Exception exception)> DelatePizzaAsync(Guid id);
    }
}