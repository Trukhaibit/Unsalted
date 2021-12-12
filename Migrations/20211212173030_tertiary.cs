using Microsoft.EntityFrameworkCore.Migrations;

namespace Unsalted.Migrations
{
    public partial class tertiary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Food_ID",
                table: "Review");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Review",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "FoodID",
                table: "Review",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Allergy",
                columns: new[] { "ID", "Allergen", "Examples", "Reactions" },
                values: new object[] { 2, "Lactose", "Milk, Cheese, Yogurt, etc.", "Bloating, Flatulence, etc." });

            migrationBuilder.InsertData(
                table: "Allergy",
                columns: new[] { "ID", "Allergen", "Examples", "Reactions" },
                values: new object[] { 3, "Egg", "Bread, Wheat, Cereal, etc.", "Eczema, Hives, Nausea, etc." });

            migrationBuilder.CreateIndex(
                name: "IX_Review_FoodID",
                table: "Review",
                column: "FoodID");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Food_FoodID",
                table: "Review",
                column: "FoodID",
                principalTable: "Food",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Food_FoodID",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_FoodID",
                table: "Review");

            migrationBuilder.DeleteData(
                table: "Allergy",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Allergy",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "FoodID",
                table: "Review");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Review",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Food_ID",
                table: "Review",
                column: "ID",
                principalTable: "Food",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
