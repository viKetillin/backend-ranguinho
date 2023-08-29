using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiCardapio.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaAdicional",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCategoriaAdicional = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdditionalCategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaAdicional", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaEstabelecimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaEstabelecimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFormaPagamento = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePerfil = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PontoCarne",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePontoCarne = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontoCarne", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUsuario = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EmailUsuario = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CodigoUsuario = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Whatsapp = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estabelecimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UF = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Whatsapp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagemCapa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkCardapio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaEstabelecimentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estabelecimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estabelecimento_CategoriaEstabelecimento_CategoriaEstabelecimentoId",
                        column: x => x.CategoriaEstabelecimentoId,
                        principalTable: "CategoriaEstabelecimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Troco = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Entrega = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    PagamentoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Pagamento_PagamentoId",
                        column: x => x.PagamentoId,
                        principalTable: "Pagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedido_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PerfilUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    PerfilId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerfilUsuario_Perfil_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerfilUsuario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaProduto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCategoriaProduto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExibirCardapio = table.Column<bool>(type: "bit", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ImagemFiltro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriaAdicionalId = table.Column<int>(type: "int", nullable: true),
                    EstabelecimentoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoriaProduto_CategoriaAdicional_CategoriaAdicionalId",
                        column: x => x.CategoriaAdicionalId,
                        principalTable: "CategoriaAdicional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoriaProduto_Estabelecimento_EstabelecimentoId",
                        column: x => x.EstabelecimentoId,
                        principalTable: "Estabelecimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiaHorasFuncionamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaInicio = table.Column<int>(type: "int", nullable: false),
                    DiaFim = table.Column<int>(type: "int", nullable: false),
                    HoraInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstabelecimentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaHorasFuncionamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiaHorasFuncionamento_Estabelecimento_EstabelecimentoId",
                        column: x => x.EstabelecimentoId,
                        principalTable: "Estabelecimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingrediente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeIngrediente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NameIngredient = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DescricaoIngrediente = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    EstabelecimentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingrediente_Estabelecimento_EstabelecimentoId",
                        column: x => x.EstabelecimentoId,
                        principalTable: "Estabelecimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioEstabelecimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstabelecimentoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioEstabelecimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioEstabelecimento_Estabelecimento_EstabelecimentoId",
                        column: x => x.EstabelecimentoId,
                        principalTable: "Estabelecimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioEstabelecimento_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProduto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DescricaoProduto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProductDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ImagemProduto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriaId = table.Column<int>(type: "int", nullable: true),
                    CategoriaProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_CategoriaProduto_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "CategoriaProduto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Adicional",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<double>(type: "float", nullable: true),
                    IngredienteId = table.Column<int>(type: "int", nullable: false),
                    CategoriaAdicionalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adicional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adicional_CategoriaAdicional_CategoriaAdicionalId",
                        column: x => x.CategoriaAdicionalId,
                        principalTable: "CategoriaAdicional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Adicional_Ingrediente_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Ingrediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoEstabelecimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    ValorPromocional = table.Column<double>(type: "float", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    EstabelecimentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoEstabelecimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoEstabelecimento_Estabelecimento_EstabelecimentoId",
                        column: x => x.EstabelecimentoId,
                        principalTable: "Estabelecimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutoEstabelecimento_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoIngrediente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredienteId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoIngrediente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoIngrediente_Ingrediente_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Ingrediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutoIngrediente_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoPedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    PedidoId = table.Column<int>(type: "int", nullable: true),
                    ProdutoEstabelecimentoId = table.Column<int>(type: "int", nullable: true),
                    PontoCarneId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoPedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoPedido_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProdutoPedido_PontoCarne_PontoCarneId",
                        column: x => x.PontoCarneId,
                        principalTable: "PontoCarne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProdutoPedido_ProdutoEstabelecimento_ProdutoEstabelecimentoId",
                        column: x => x.ProdutoEstabelecimentoId,
                        principalTable: "ProdutoEstabelecimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PedidoIngrediente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<double>(type: "float", nullable: false),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    IngredienteId = table.Column<int>(type: "int", nullable: true),
                    ProdutoPedidoId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_PedidoIngrediente_Ingrediente_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Ingrediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PedidoIngrediente_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoIngrediente_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PedidoIngrediente_ProdutoPedido_ProdutoPedidoId",
                        column: x => x.ProdutoPedidoId,
                        principalTable: "ProdutoPedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Perfil",
                columns: new[] { "Id", "NomePerfil" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Perfil",
                columns: new[] { "Id", "NomePerfil" },
                values: new object[] { 2, "Proprietário" });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "CodigoUsuario", "DataNascimento", "EmailUsuario", "Endereco", "NomeUsuario", "Senha", "Whatsapp" },
                values: new object[] { 1, "vitoria.fusco", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "vitoriaketillin@hotmail.com", "Moisés Fantin, 92", "Vitória Fusco", "$2a$11$1p.3/q6KPnbMitb8mFihTOvkOuPoxPZ/uitRlr9woiWpHR9/u8TOa", "14998700705" });

            migrationBuilder.InsertData(
                table: "PerfilUsuario",
                columns: new[] { "Id", "PerfilId", "UsuarioId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Adicional_CategoriaAdicionalId",
                table: "Adicional",
                column: "CategoriaAdicionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Adicional_IngredienteId",
                table: "Adicional",
                column: "IngredienteId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaProduto_CategoriaAdicionalId",
                table: "CategoriaProduto",
                column: "CategoriaAdicionalId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaProduto_EstabelecimentoId",
                table: "CategoriaProduto",
                column: "EstabelecimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaHorasFuncionamento_EstabelecimentoId",
                table: "DiaHorasFuncionamento",
                column: "EstabelecimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimento_CategoriaEstabelecimentoId",
                table: "Estabelecimento",
                column: "CategoriaEstabelecimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingrediente_EstabelecimentoId",
                table: "Ingrediente",
                column: "EstabelecimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_PagamentoId",
                table: "Pedido",
                column: "PagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_UsuarioId",
                table: "Pedido",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoIngrediente_IngredienteId",
                table: "PedidoIngrediente",
                column: "IngredienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoIngrediente_PedidoId",
                table: "PedidoIngrediente",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoIngrediente_ProdutoId",
                table: "PedidoIngrediente",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoIngrediente_ProdutoPedidoId",
                table: "PedidoIngrediente",
                column: "ProdutoPedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilUsuario_PerfilId",
                table: "PerfilUsuario",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilUsuario_UsuarioId",
                table: "PerfilUsuario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CategoriaId",
                table: "Produto",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoEstabelecimento_EstabelecimentoId",
                table: "ProdutoEstabelecimento",
                column: "EstabelecimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoEstabelecimento_ProdutoId",
                table: "ProdutoEstabelecimento",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoIngrediente_IngredienteId",
                table: "ProdutoIngrediente",
                column: "IngredienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoIngrediente_ProdutoId",
                table: "ProdutoIngrediente",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoPedido_PedidoId",
                table: "ProdutoPedido",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoPedido_PontoCarneId",
                table: "ProdutoPedido",
                column: "PontoCarneId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoPedido_ProdutoEstabelecimentoId",
                table: "ProdutoPedido",
                column: "ProdutoEstabelecimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEstabelecimento_EstabelecimentoId",
                table: "UsuarioEstabelecimento",
                column: "EstabelecimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEstabelecimento_UsuarioId",
                table: "UsuarioEstabelecimento",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adicional");

            migrationBuilder.DropTable(
                name: "DiaHorasFuncionamento");

            migrationBuilder.DropTable(
                name: "PedidoIngrediente");

            migrationBuilder.DropTable(
                name: "PerfilUsuario");

            migrationBuilder.DropTable(
                name: "ProdutoIngrediente");

            migrationBuilder.DropTable(
                name: "UsuarioEstabelecimento");

            migrationBuilder.DropTable(
                name: "ProdutoPedido");

            migrationBuilder.DropTable(
                name: "Perfil");

            migrationBuilder.DropTable(
                name: "Ingrediente");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "PontoCarne");

            migrationBuilder.DropTable(
                name: "ProdutoEstabelecimento");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "CategoriaProduto");

            migrationBuilder.DropTable(
                name: "CategoriaAdicional");

            migrationBuilder.DropTable(
                name: "Estabelecimento");

            migrationBuilder.DropTable(
                name: "CategoriaEstabelecimento");
        }
    }
}
