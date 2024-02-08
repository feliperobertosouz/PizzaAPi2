namespace PizzaAPI2.Dtos;

public class PizzaRequestDTO{
    public string Nome {get;set;}
    public List<int> IngredientesIds {get;set;}

    public PizzaRequestDTO()
    {
        
    }
}