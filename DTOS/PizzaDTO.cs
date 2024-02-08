
public class PizzaDTO{
    
    public string Nome {get;set;}

    public ICollection<IngredientePizzaDTO> ingredientes {get;set;}

    public PizzaDTO()
    {
        
    }
}