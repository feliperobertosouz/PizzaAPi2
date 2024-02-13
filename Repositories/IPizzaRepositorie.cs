using PizzaAPI2.Dtos;
using PizzaAPI2.Models;

public interface IPizzaRepositorie{

    public void Add(PizzaRequestDTO pizzaRequestDTO);

    public PizzaDTO get(int id);

    public List<PizzaListDTO> getAll();

    public void Delete(int id);

    public void Update(PizzaRequestDTO pizzaDTO, int id);
}