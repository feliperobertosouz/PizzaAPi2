using PizzaAPI2.Models;

namespace PizzaAPI2.Repositories;

public interface IIngredienteRepositorie{

    public void Add(IngredienteDTO ingredienteDTO);

    public List<Ingrediente> GetAll();

    public Ingrediente Get(int id);

    public void Delete(int id);

    public void Update(int id, IngredienteDTO ingredienteDTO);
}