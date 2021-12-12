using Microsoft.EntityFrameworkCore.Migrations;

namespace Unsalted.Migrations
{
    public partial class Secondary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Allergy_AllergyId",
                table: "Food");

            migrationBuilder.DropForeignKey(
                name: "FK_Food_Diet_DietId",
                table: "Food");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Food_FoodID",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_FoodID",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "FoodID",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "DietId",
                table: "Food",
                newName: "DietID");

            migrationBuilder.RenameColumn(
                name: "AllergyId",
                table: "Food",
                newName: "AllergyID");

            migrationBuilder.RenameIndex(
                name: "IX_Food_DietId",
                table: "Food",
                newName: "IX_Food_DietID");

            migrationBuilder.RenameIndex(
                name: "IX_Food_AllergyId",
                table: "Food",
                newName: "IX_Food_AllergyID");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Review",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Allergy_AllergyID",
                table: "Food",
                column: "AllergyID",
                principalTable: "Allergy",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Diet_DietID",
                table: "Food",
                column: "DietID",
                principalTable: "Diet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Food_ID",
                table: "Review",
                column: "ID",
                principalTable: "Food",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Allergy_AllergyID",
                table: "Food");

            migrationBuilder.DropForeignKey(
                name: "FK_Food_Diet_DietID",
                table: "Food");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Food_ID",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "DietID",
                table: "Food",
                newName: "DietId");

            migrationBuilder.RenameColumn(
                name: "AllergyID",
                table: "Food",
                newName: "AllergyId");

            migrationBuilder.RenameIndex(
                name: "IX_Food_DietID",
                table: "Food",
                newName: "IX_Food_DietId");

            migrationBuilder.RenameIndex(
                name: "IX_Food_AllergyID",
                table: "Food",
                newName: "IX_Food_AllergyId");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Review",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "FoodID",
                table: "Review",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Review_FoodID",
                table: "Review",
                column: "FoodID");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Allergy_AllergyId",
                table: "Food",
                column: "AllergyId",
                principalTable: "Allergy",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Diet_DietId",
                table: "Food",
                column: "DietId",
                principalTable: "Diet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Food_FoodID",
                table: "Review",
                column: "FoodID",
                principalTable: "Food",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
