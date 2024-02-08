
using AutoMapper;
using PizzaAPI2.Models;

public class PizzaMapper : Profile{

    public PizzaMapper(){
        CreateMap<Pizza, PizzaDTO>().ReverseMap();
        CreateMap<Ingrediente,IngredienteDTO>();
        CreateMap<Ingrediente,IngredienteDTO>().ReverseMap();
    }
}