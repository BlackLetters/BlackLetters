using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminFirstName = table.Column<string>(nullable: true),
                    AdminLastName = table.Column<string>(nullable: true),
                    AdminEmail = table.Column<string>(nullable: true),
                    AdminPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookTitle = table.Column<string>(nullable: true),
                    BookPrice = table.Column<string>(nullable: true),
                    BookStatus = table.Column<string>(nullable: true),
                    BookType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                });

            migrationBuilder.CreateTable(
                name: "RegistredUsers",
                columns: table => new
                {
                    RegistredUserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistredUserFirstName = table.Column<string>(nullable: true),
                    RegistredUserLastName = table.Column<string>(nullable: true),
                    RegistredUserEmail = table.Column<string>(nullable: true),
                    RegistredUserPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistredUsers", x => x.RegistredUserID);
                });

            migrationBuilder.CreateTable(
                name: "RegistredUserSubs",
                columns: table => new
                {
                    RegistredUserSubID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistredUserSubs", x => x.RegistredUserSubID);
                });

            migrationBuilder.CreateTable(
                name: "UnregistredUsers",
                columns: table => new
                {
                    UnregistredUserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnregistredUsers", x => x.UnregistredUserID);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDateOfReturn = table.Column<int>(nullable: false),
                    TransactionDateOfAquire = table.Column<int>(nullable: false),
                    BookID1 = table.Column<int>(nullable: true),
                    RegistredUserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transactions_Books_BookID1",
                        column: x => x.BookID1,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_RegistredUsers_RegistredUserID",
                        column: x => x.RegistredUserID,
                        principalTable: "RegistredUsers",
                        principalColumn: "RegistredUserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BookID1",
                table: "Transactions",
                column: "BookID1");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_RegistredUserID",
                table: "Transactions",
                column: "RegistredUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "RegistredUserSubs");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "UnregistredUsers");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "RegistredUsers");
        }
    }
}
