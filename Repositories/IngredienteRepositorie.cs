
using AutoMapper;
using PizzaAPI2.Context;
using PizzaAPI2.Models;

namespace PizzaAPI2.Repositories;

public class IngredienteRepositorie : IIngredienteRepositorie
{
    private readonly DataBaseContext _dataBaseContext;
    private readonly IMapper _mapper;


    public IngredienteRepositorie(DataBaseContext dataBaseContext, IMapper mapper)
    {
     _dataBaseContext = dataBaseContext;
     _mapper = mapper;   
    }
    public void Add(IngredienteDTO ingredienteDTO)
    {
       Ingrediente novoIngrediente = _mapper.Map<Ingrediente>(ingredienteDTO);
       _dataBaseContext.Ingredientes.Add(novoIngrediente);
       _dataBaseContext.SaveChanges();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IngredienteDTO Get(int id)
    {
        var ingrediente = _dataBaseContext.Ingredientes.Find(id);
        var ingredientDTO = _mapper.Map<IngredienteDTO>(ingrediente);
        return ingredientDTO;
    }

    public List<IngredienteDTO> GetAll()
    {
     var ingredientes = _dataBaseContext.Ingredientes.ToList();
     var ingredientesDtos = _mapper.Map<List<IngredienteDTO>>(ingredientes);
     return ingredientesDtos;
    }

    public void Update(int id, IngredienteDTO ingredienteDTO)
    {
        throw new NotImplementedException();
    }
}