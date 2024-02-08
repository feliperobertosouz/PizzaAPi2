using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaAPI2.Migrations
{
    /// <inheritdoc />
    public partial class start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    IngredienteID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    vegano = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientes", x => x.IngredienteID);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    PizzaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.PizzaId);
                });

            migrationBuilder.CreateTable(
                name: "IngredientePizza",
                columns: table => new
                {
                    ingredientesIngredienteID = table.Column<int>(type: "INTEGER", nullable: false),
                    pizzasPizzaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientePizza", x => new { x.ingredientesIngredienteID, x.pizzasPizzaId });
                    table.ForeignKey(
                        name: "FK_IngredientePizza_Ingredientes_ingredientesIngredienteID",
                        column: x => x.ingredientesIngredienteID,
                        principalTable: "Ingredientes",
                        principalColumn: "IngredienteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientePizza_Pizzas_pizzasPizzaId",
                        column: x => x.pizzasPizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "PizzaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientePizza_pizzasPizzaId",
                table: "IngredientePizza",
                column: "pizzasPizzaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientePizza");

            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "Pizzas");
        }
    }
}
