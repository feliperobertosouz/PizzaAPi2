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

     [HttpDelete("{id}")]
    public IActionResult deletePizza(int id){
     try{
           _pizzaRepositorie.Delete(id);
        return NoContent();
     }catch(Exception e){
          return BadRequest($"Houve algum problema ao deletar a pizza de id{id}: {e.Message}");
     }
       
    }

     [HttpPut("{id}")]
     public IActionResult updatePizza(PizzaRequestDTO pizzaRequestDTO, int id){
          try{
               _pizzaRepositorie.Update(pizzaRequestDTO, id);
               return Ok(pizzaRequestDTO);
          }catch(Exception e){
               return BadRequest($"Houve um erro ao tentar atualizar a pizza de id{id}: {e.Message}");
          }
          
     }

}