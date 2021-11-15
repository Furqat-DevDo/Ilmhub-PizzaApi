using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PizzaApi.Data;
using PizzaApi.Enteties;
using PizzaApi.Models;

namespace PizzaApi.Services
{
    public class DbStorageService : IStorageService
    {   
        private readonly ILogger<DbStorageService> _logger;
        private readonly PizzaDbContext _context;

    public DbStorageService(ILogger<DbStorageService> logger, PizzaDbContext context)
    {
        _logger = logger;
        _context = context;
    }

        public async Task<(bool isSuccess, Exception exception)> DelatePizzaAsync(Guid id)
        {
            try{
                _context.Pizzas.Remove(_context.Pizzas.FirstOrDefault(u => u.Id == id));
                await _context.SaveChangesAsync();

                return(true, null);
            }

            catch(Exception e)
            {
                return (false, e);
            }
        }

        public async Task<(bool isSuccess, Exception exception, Pizza pizza)> UpdateOrderAsync(Pizza pizza)
        {
             try
            {
                if(await _context.Pizzas.AnyAsync(t => t.Id == pizza.Id))
                {
                    _context.Pizzas.Update(pizza);
                    await _context.SaveChangesAsync();

                    return (true, null, pizza);
                }
                else
                {
                    return (false, new Exception($"Order with ID: {pizza.Id} doesnt exist!"), null);
                }
            }
            catch(Exception e)
            {
                return (false, e, null);
            }
        }

        async Task<(bool IsSuccess, Exception exception, List<NewPizza> pizza)> IStorageService.GetPizzaAsync()
        {
            try
        {
            var pizzas = await _context.Pizzas.Select(p => new NewPizza()
            {
                Id = p.Id,
                Title = p.Title,
                ShortName = p.ShortName,
                stockStatus = (Models.EPizzaStockStatus)p.stockStatus,
                Ingredients = p.Ingredients,
                Price = p.Price
            }).ToListAsync();

            _logger.LogInformation("Pizzas get from DB");
            return (true, null, pizzas);
        }
        catch (Exception e)
        {
            _logger.LogInformation($"Getting pizzas from DB failed: {e.Message}", e);
            return (false, null, null);
        }

        }

        async Task<(bool IsSuccess, Exception exception, Pizza pizzaResult)> IStorageService.GetPizzaAsync(Guid Id)
        {
            try
        {
            var pizzaResult = await _context.Pizzas.AsNoTracking().FirstOrDefaultAsync(p => p.Id == Id);

            if (pizzaResult is default(Pizza))
            {
                return (false, null, null);
            }

            _logger.LogInformation($"Pizza get from DB: {Id}");
            return (true, null, pizzaResult);
        }
        catch (Exception e)
        {
            _logger.LogInformation($"Getting pizza from DB: {Id} failed");
            return (false, e, null);
        }
        }

       async  Task<(bool IsSuccess, Exception exception)> IStorageService.InsertPizzaAsync(Pizza pizza)
        {
            try
        {
            if (!await _context.Pizzas.AnyAsync(p => p.Id == pizza.Id))
            {
                await _context.Pizzas.AddAsync(pizza);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Pizza ordered in DB: {pizza.Id}");
                return (true, null);
            }
            else
            {
                return (false, new Exception());
            }
        }
        catch (Exception e)
        {
            _logger.LogInformation($"Ordering pizza in DB: {pizza.Id} failed");
            return (false, e);
        }
        }
    }
}