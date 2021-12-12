using Microsoft.EntityFrameworkCore.Migrations;

namespace Unsalted.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergy",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Allergen = table.Column<string>(nullable: true),
                    Examples = table.Column<string>(nullable: true),
                    Reactions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergy", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Diet",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    Explanation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diet", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DietId = table.Column<int>(nullable: false),
                    AllergyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Food_Allergy_AllergyId",
                        column: x => x.AllergyId,
                        principalTable: "Allergy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Food_Diet_DietId",
                        column: x => x.DietId,
                        principalTable: "Diet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodID = table.Column<int>(nullable: true),
                    User = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Review_Food_FoodID",
                        column: x => x.FoodID,
                        principalTable: "Food",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Allergy",
                columns: new[] { "ID", "Allergen", "Examples", "Reactions" },
                values: new object[] { 1, "Gluten", "Bread, Wheat, Cereal, etc.", "Stomach ache, Rash, etc." });

            migrationBuilder.InsertData(
                table: "Diet",
                columns: new[] { "ID", "Explanation", "Type" },
                values: new object[] { 1, "In accordance with Jewish Dietary Law", "Kosher" });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ID", "Description", "FoodID", "Rating", "User" },
                values: new object[] { 1, null, null, 0, null });

            migrationBuilder.InsertData(
                table: "Food",
                columns: new[] { "ID", "AllergyId", "Description", "DietId", "Item" },
                values: new object[] { 1, 1, "A traditional Italian dish, although the meatballs were added by the Swedes.", 1, "Spaghetti and Meatballs" });

            migrationBuilder.CreateIndex(
                name: "IX_Food_AllergyId",
                table: "Food",
                column: "AllergyId");

            migrationBuilder.CreateIndex(
                name: "IX_Food_DietId",
                table: "Food",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_FoodID",
                table: "Review",
                column: "FoodID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "Allergy");

            migrationBuilder.DropTable(
                name: "Diet");
        }
    }
}
