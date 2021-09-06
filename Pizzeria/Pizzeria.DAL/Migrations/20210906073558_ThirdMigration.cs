using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizzeria.DAL.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commande_Client_ClientId",
                table: "Commande");

            migrationBuilder.DropForeignKey(
                name: "FK_Plat_Commande_Commande_CommandeId",
                table: "Plat_Commande");

            migrationBuilder.DropForeignKey(
                name: "FK_Plat_Commande_Plats_PlatId",
                table: "Plat_Commande");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plat_Commande",
                table: "Plat_Commande");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commande",
                table: "Commande");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.RenameTable(
                name: "Plat_Commande",
                newName: "Plat_Commandes");

            migrationBuilder.RenameTable(
                name: "Commande",
                newName: "Commandes");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "Clients");

            migrationBuilder.RenameIndex(
                name: "IX_Plat_Commande_PlatId",
                table: "Plat_Commandes",
                newName: "IX_Plat_Commandes_PlatId");

            migrationBuilder.RenameIndex(
                name: "IX_Plat_Commande_CommandeId",
                table: "Plat_Commandes",
                newName: "IX_Plat_Commandes_CommandeId");

            migrationBuilder.RenameIndex(
                name: "IX_Commande_ClientId",
                table: "Commandes",
                newName: "IX_Commandes_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plat_Commandes",
                table: "Plat_Commandes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commandes",
                table: "Commandes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_Clients_ClientId",
                table: "Commandes",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plat_Commandes_Commandes_CommandeId",
                table: "Plat_Commandes",
                column: "CommandeId",
                principalTable: "Commandes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plat_Commandes_Plats_PlatId",
                table: "Plat_Commandes",
                column: "PlatId",
                principalTable: "Plats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_Clients_ClientId",
                table: "Commandes");

            migrationBuilder.DropForeignKey(
                name: "FK_Plat_Commandes_Commandes_CommandeId",
                table: "Plat_Commandes");

            migrationBuilder.DropForeignKey(
                name: "FK_Plat_Commandes_Plats_PlatId",
                table: "Plat_Commandes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plat_Commandes",
                table: "Plat_Commandes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commandes",
                table: "Commandes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Plat_Commandes",
                newName: "Plat_Commande");

            migrationBuilder.RenameTable(
                name: "Commandes",
                newName: "Commande");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Client");

            migrationBuilder.RenameIndex(
                name: "IX_Plat_Commandes_PlatId",
                table: "Plat_Commande",
                newName: "IX_Plat_Commande_PlatId");

            migrationBuilder.RenameIndex(
                name: "IX_Plat_Commandes_CommandeId",
                table: "Plat_Commande",
                newName: "IX_Plat_Commande_CommandeId");

            migrationBuilder.RenameIndex(
                name: "IX_Commandes_ClientId",
                table: "Commande",
                newName: "IX_Commande_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plat_Commande",
                table: "Plat_Commande",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commande",
                table: "Commande",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commande_Client_ClientId",
                table: "Commande",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plat_Commande_Commande_CommandeId",
                table: "Plat_Commande",
                column: "CommandeId",
                principalTable: "Commande",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plat_Commande_Plats_PlatId",
                table: "Plat_Commande",
                column: "PlatId",
                principalTable: "Plats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
