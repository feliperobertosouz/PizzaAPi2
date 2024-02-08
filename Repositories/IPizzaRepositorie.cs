using PizzaAPI2.Dtos;

public interface IPizzaRepositorie{

    public void Add(PizzaRequestDTO pizzaRequestDTO);

    public PizzaDTO get(int id);

    public List<PizzaDTO> getAll();

    public void Delete(int id);

    public void Update(PizzaDTO pizzaDTO, int id);
}