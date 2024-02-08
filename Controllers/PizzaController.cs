using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PizzaAPI2.Dtos;
using PizzaAPI2.Repositories;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase{
    

     private readonly IPizzaRepositorie _pizzaRepositorie;

     public PizzaController(IPizzaRepositorie pizzaRepositorie)
     {
          _pizzaRepositorie = pizzaRepositorie;
     }
     
     [HttpGet]
     public IActionResult getPizzas(){
          var recebido = _pizzaRepositorie.getAll();
          Console.WriteLine(recebido);
          return Ok(recebido);
     }

     [HttpGet("{id}")]
     public IActionResult getPizza(int id){

          var pizza = _pizzaRepositorie.get(id);
          if(pizza is null){
               NotFound("Pizza não encontrada");
          }
          return Ok(pizza);
     }

     [HttpPost]
     public IActionResult AdicionarPizza(PizzaRequestDTO pizzaRequestDTO){
          _pizzaRepositorie.Add(pizzaRequestDTO);

          return Ok(pizzaRequestDTO);
     }

}