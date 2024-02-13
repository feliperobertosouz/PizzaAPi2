
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
    if(ingredienteDTO.Nome == null || ingredienteDTO.Vegano == null){
        throw new NullReferenceException("Informe o nome do ingrediente e se ele é vegano ou não");
    }
    using (var transaction = _dataBaseContext.Database.BeginTransaction()){
        try{
            Ingrediente novoIngrediente = _mapper.Map<Ingrediente>(ingredienteDTO);
            _dataBaseContext.Ingredientes.Add(novoIngrediente);
            _dataBaseContext.SaveChanges();
            transaction.Commit();
        }catch(Exception e){
            transaction.Rollback();
            Console.WriteLine($"Erro ao registrar um ingrediente: {e.Message}");
            throw;
        }
    }
    }

    public void Delete(int id)
    {
        var ingrediente = _dataBaseContext.Ingredientes.Find(id);
        if(ingrediente == null){
            throw new InvalidOperationException("Não é possivel encontrar o ingrediente");
        }
        _dataBaseContext.Ingredientes.Remove(ingrediente);
        _dataBaseContext.SaveChanges();
    }

    public Ingrediente Get(int id)
    {
        var ingrediente = _dataBaseContext.Ingredientes.Find(id);
        if(ingrediente == null){
            return null;
        }
        return ingrediente;
    }

    public List<Ingrediente> GetAll()
    {
     var ingredientes = _dataBaseContext.Ingredientes.ToList();
     return ingredientes;
    }

    public void Update(int id, IngredienteDTO ingredienteDTO)
    {
        var ingrediente = _dataBaseContext.Ingredientes.Find(id);
        if (ingrediente == null){
           throw new InvalidOperationException("Não é possivel encontrar o ingrediente para o atualizar");
        }

        _mapper.Map(ingredienteDTO, ingrediente);
         _dataBaseContext.Entry(ingrediente).CurrentValues.SetValues(ingrediente);
        _dataBaseContext.SaveChanges();
    }
}