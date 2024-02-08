﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaAPI2.Context;

#nullable disable

namespace PizzaAPI2.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("IngredientePizza", b =>
                {
                    b.Property<int>("ingredientesIngredienteID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("pizzasPizzaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ingredientesIngredienteID", "pizzasPizzaId");

                    b.HasIndex("pizzasPizzaId");

                    b.ToTable("IngredientePizza");
                });

            modelBuilder.Entity("PizzaAPI2.Models.Ingrediente", b =>
                {
                    b.Property<int>("IngredienteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("vegano")
                        .HasColumnType("INTEGER");

                    b.HasKey("IngredienteID");

                    b.ToTable("Ingredientes");
                });

            modelBuilder.Entity("PizzaAPI2.Models.Pizza", b =>
                {
                    b.Property<int>("PizzaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PizzaId");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("IngredientePizza", b =>
                {
                    b.HasOne("PizzaAPI2.Models.Ingrediente", null)
                        .WithMany()
                        .HasForeignKey("ingredientesIngredienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaAPI2.Models.Pizza", null)
                        .WithMany()
                        .HasForeignKey("pizzasPizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
