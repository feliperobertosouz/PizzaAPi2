
public class PizzaDTO{
    
    public string Nome {get;set;}

    public ICollection<IngredienteDTO> ingredientes {get;set;}

    public PizzaDTO()
    {
        
    }
}