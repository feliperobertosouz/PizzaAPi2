namespace PizzaAPI2.Repositories;

public interface IIngredienteRepositorie{

    public void Add(IngredienteDTO ingredienteDTO);

    public List<IngredienteDTO> GetAll();

    public IngredienteDTO Get(int id);

    public void Delete(int id);

    public void Update(int id, IngredienteDTO ingredienteDTO);
}