using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EcommerceMVC.Migrations
{
    public partial class Modelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cadastro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bairro = table.Column<string>(nullable: false),
                    CEP = table.Column<string>(nullable: false),
                    Complemento = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Endereco = table.Column<string>(nullable: false),
                    Municipio = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    PedidoId = table.Column<int>(nullable: false),
                    Telefone = table.Column<string>(nullable: false),
                    UF = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cadastro_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemPedido",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PedidoId = table.Column<int>(nullable: false),
                    PrecoUnitario = table.Column<decimal>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPedido_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPedido_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cadastro_PedidoId",
                table: "Cadastro",
                column: "PedidoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedido_PedidoId",
                table: "ItemPedido",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedido_ProdutoId",
                table: "ItemPedido",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cadastro");

            migrationBuilder.DropTable(
                name: "ItemPedido");

            migrationBuilder.DropTable(
                name: "Pedidos");
        }
    }
}
