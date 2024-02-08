using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PizzaAPI2.Models;

[Table("Pizzas")]
public class Pizza{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PizzaId {get;set;}

    public string Nome {get;set;}

    public ICollection<Ingrediente> ingredientes {get;set;}


    public Pizza(){
        
    }
}