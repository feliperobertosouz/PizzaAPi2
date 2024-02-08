
using AutoMapper;
using PizzaAPI2.Dtos;
using PizzaAPI2.Models;

public class PizzaMapper : Profile{

    public PizzaMapper(){
        CreateMap<Pizza, PizzaDTO>().ReverseMap();
        CreateMap<Ingrediente, IngredienteDTO>().ReverseMap();
        CreateMap<Pizza, PizzaRequestDTO>().ReverseMap();
        CreateMap<Ingrediente, IngredientePizzaDTO>().ReverseMap();
    }
}