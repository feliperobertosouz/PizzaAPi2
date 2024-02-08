using Microsoft.EntityFrameworkCore;
using PizzaAPI2.Models;

namespace PizzaAPI2.Context;

public class DataBaseContext : DbContext{

    public DbSet<Pizza> Pizzas {get;set;}
    public DbSet<Ingrediente> Ingredientes {get;set;}

     public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }
}