using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PizzaAPI2.Models;

[Table("Ingredientes")]
public class Ingrediente{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IngredienteID {get;set;}
    public string Nome {get;set;}

    public bool vegano {get;set;}

    [JsonIgnore]
    public ICollection<Pizza> pizzas{get;set;}
    public Ingrediente(){}
}