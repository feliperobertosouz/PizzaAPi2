
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
    public List<IngredienteDTO> verTodosIngredientes(){

        return _ingredienteRepositorie.GetAll();
    }

    [HttpGet("{id}")]
    public IngredienteDTO getIngrediente(int id){
        return _ingredienteRepositorie.Get(id);
    }

}