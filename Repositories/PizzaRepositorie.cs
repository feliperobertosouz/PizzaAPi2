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
        var novaPizza = _mapper.Map<Pizza>(pizzaRequestDTO);

        var ingredients = _dataBaseContext.Ingredientes.Where(i => pizzaRequestDTO.IngredientesIds.Contains(i.IngredienteID)).ToList();

        novaPizza.ingredientes = ingredients;

        Console.WriteLine($"Nova Pizza: {novaPizza.Nome}");
        Console.WriteLine("Ingredientes:");
        foreach (var ingrediente in novaPizza.ingredientes)
        {
            Console.WriteLine($"  - {ingrediente.Nome}");
        }
        _dataBaseContext.Add(novaPizza);
        _dataBaseContext.SaveChanges();

    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public PizzaDTO get(int id)
    {
        var pizza = _dataBaseContext.Pizzas.Include(p=> p.ingredientes).ToList();
        return _mapper.Map<PizzaDTO>(pizza);
    }

    public List<PizzaDTO> getAll()
    {
        var pizzas = _dataBaseContext.Pizzas.Include(p => p.ingredientes).ToList();
        List<PizzaDTO> PizzasDtos = _mapper.Map<List<PizzaDTO>>(pizzas);
        
        return PizzasDtos;
    }

    public void Update(PizzaDTO pizzaDTO, int id)
    {
        throw new NotImplementedException();
    }
}