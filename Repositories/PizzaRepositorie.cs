using System.Collections.Generic;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PizzaAPI2.Context;
using PizzaAPI2.Dtos;
using PizzaAPI2.Models;

namespace PizzaAPI2.Repositories;

public class PizzaRepositorie : IPizzaRepositorie
{
    private readonly DataBaseContext _dataBaseContext;
    private readonly IMapper _mapper;


    public PizzaRepositorie(DataBaseContext dataBaseContext, IMapper mapper)
    {
     _dataBaseContext = dataBaseContext;
     _mapper = mapper;   
    }

    public void Add(PizzaRequestDTO pizzaRequestDTO)
    {
        if(pizzaRequestDTO.Nome == null || pizzaRequestDTO.IngredientesIds == null){
            throw new NullReferenceException("Por favor informe o nome/ingredientes da pizza");
        }

       
        using (var transaction = _dataBaseContext.Database.BeginTransaction()){
            try{
                var novaPizza = _mapper.Map<Pizza>(pizzaRequestDTO);
                var ingredients = _dataBaseContext.Ingredientes.Where(i => pizzaRequestDTO.IngredientesIds.Contains(i.IngredienteID)).ToList();
                novaPizza.ingredientes = ingredients;
                _dataBaseContext.Add(novaPizza);
                _dataBaseContext.SaveChanges();
                transaction.Commit();
            }catch(Exception e){
                Console.WriteLine($"Erro ao tentar salvar a pizza: {e.Message}");
                transaction.Rollback();
                throw;
            }
        }
    }

    public void Delete(int id)
    {
        var pizza = _dataBaseContext.Pizzas.Find(id);
        if(pizza == null){
            throw new NullReferenceException($"Não foi possivel encontrar uma pizza com id {id}");
        }
        _dataBaseContext.Pizzas.Remove(pizza);
        _dataBaseContext.SaveChanges();

    }

    public PizzaDTO get(int id)
    {
        var pizza = _dataBaseContext.Pizzas.Find(id);
        if(pizza == null){
            return null;
        }
        var pizzaSearch = _dataBaseContext.Pizzas.Include(p=> p.ingredientes).ToList();
        return _mapper.Map<PizzaDTO>(pizzaSearch);
    }

    public List<PizzaListDTO> getAll()
    {
        var pizzas = _dataBaseContext.Pizzas.Include(p => p.ingredientes).ToList();
        var pizzasDtos = _mapper.Map<List<PizzaListDTO>>(pizzas);

    return pizzasDtos;
    }

    public void Update(PizzaRequestDTO pizzaDTO, int id)
    {
        var pizza = _dataBaseContext.Pizzas.Include(p => p.ingredientes).FirstOrDefault(p => p.PizzaId == id);
        if(pizza == null){
            throw new NullReferenceException($"Não foi possivel encontrar uma pizza com id {id}");
        }
        if(pizzaDTO.Nome == null || pizzaDTO.IngredientesIds == null){
            throw new NullReferenceException($"Informe o nome e ingredientes da pizza por favor");
        }

        using (var transaction = _dataBaseContext.Database.BeginTransaction()){
            try{
                _mapper.Map(pizzaDTO, pizza);
                var ingredients = _dataBaseContext.Ingredientes.Where(i => pizzaDTO.IngredientesIds.Contains(i.IngredienteID)).ToList();
                pizza.ingredientes.Clear();
                foreach (var ingredient in ingredients)
                    {
                    pizza.ingredientes.Add(ingredient);
                    }

                _dataBaseContext.SaveChanges();
                transaction.Commit();
            }catch(Exception e){
                Console.WriteLine($"Erro ao tentar atualizar a pizza: {e.Message}");
                transaction.Rollback();
                throw;
            }
        }
        
    }
}