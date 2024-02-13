public class PizzaListDTO{
    public int PizzaId {get;set;}
    public string Nome {get;set;}
    public ICollection<IngredienteDTO> Ingredientes {get;set;}

    public PizzaListDTO(){
        
    }
}