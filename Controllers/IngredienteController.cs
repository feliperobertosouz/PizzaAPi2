
using Microsoft.AspNetCore.Mvc;
using PizzaAPI2.Models;
using PizzaAPI2.Repositories;

[ApiController]
[Route("[controller]")]
public class IngredienteController : ControllerBase{


    private readonly IIngredienteRepositorie _ingredienteRepositorie;

    public IngredienteController(IIngredienteRepositorie ingredienteRepository){
        _ingredienteRepositorie = ingredienteRepository;
    }

    [HttpPost]
    public IActionResult AdicionarIngrediente(IngredienteDTO ingredienteDTO){
        _ingredienteRepositorie.Add(ingredienteDTO);

        return Ok(ingredienteDTO);
    }

    [HttpGet]
    public List<Ingrediente> verTodosIngredientes(){

        return _ingredienteRepositorie.GetAll();
    }

    [HttpGet("{id}")]
    public Ingrediente getIngrediente(int id){
        return _ingredienteRepositorie.Get(id);
    }

    [HttpPut("{id}")]
    public IActionResult updateIngrediente(int id,IngredienteDTO ingredienteDTO){

        try{
            _ingredienteRepositorie.Update(id,ingredienteDTO);
            return Ok("Ingrediente atualizado com sucesso");
                        
        }catch(Exception e){
            return StatusCode(500, $"Erro ao atualizar o ingrediente {id}: {e.Message}");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult deleteIngrediente(int id){
        try{
            _ingredienteRepositorie.Delete(id);
            return NoContent();
        }catch(InvalidOperationException ex){
            return NotFound(ex.Message);
        }
        catch(Exception e){
            return StatusCode(500, $"Erro ao deletar o ingrediente {id}: {e.Message}");
        }
    }

}