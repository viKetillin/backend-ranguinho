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
                table: "CategoriaAdicional",
                columns: new[] { "Id", "AdditionalCategoryName", "NomeCategoriaAdicional" },
                values: new object[,]
                {
                    { 1, null, "Adicional Porções" },
                    { 2, null, "Adicional Hamburguers" }
                });

            migrationBuilder.InsertData(
                table: "CategoriaEstabelecimento",
                columns: new[] { "Id", "Icone", "Nome" },
                values: new object[] { 1, "/assets/imagens/iconesCategoriaProduto/Hambúrgueres.svg", "Hamburgueria" });

            migrationBuilder.InsertData(
                table: "CategoriaProduto",
                columns: new[] { "Id", "CategoriaAdicionalId", "CategoryName", "EstabelecimentoId", "ExibirCardapio", "ImagemFiltro", "NomeCategoriaProduto" },
                values: new object[,]
                {
                    { 2, null, null, null, true, "/assets/imagens/iconesCategoriaProduto/Bebidas.svg", "Bebidas" },
                    { 4, null, null, null, true, "/assets/imagens/iconesCategoriaProduto/Sobremesas.svg", "Sobremesas" }
                });

            migrationBuilder.InsertData(
                table: "Perfil",
                columns: new[] { "Id", "NomePerfil" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Proprietário" }
                });

            migrationBuilder.InsertData(
                table: "PontoCarne",
                columns: new[] { "Id", "NomePontoCarne" },
                values: new object[,]
                {
                    { 2, "Ao ponto" },
                    { 3, "Bem passada" },
                    { 1, "Mal passada" }
                });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "CategoriaId", "CategoriaProdutoId", "DescricaoProduto", "ImagemProduto", "NomeProduto", "ProductDescription" },
                values: new object[,]
                {
                    { 120, null, 2, "", "", "refrigerante scheweeps", null },
                    { 113, null, 2, "abacaxi, maracujá, morango e limão", "", "caipirinha/caipiroska/saquerinha velho barreiro", null },
                    { 114, null, 2, "abacaxi, maracujá, morango e limão", "", "caipirinha/caipiroska/saquerinha smirnoff", null },
                    { 115, null, 2, "abacaxi, maracujá, morango e limão", "", "caipirinha/caipiroska/saquerinha saquê", null },
                    { 116, null, 2, "", "", "refrigerante limoneto", null },
                    { 117, null, 2, "", "", "refrigerante h2o limão", null },
                    { 118, null, 2, "", "", "refrigerante água tônica", null },
                    { 119, null, 2, "", "", "refrigerante soda", null },
                    { 121, null, 2, "", "", "refrigerante fanta", null },
                    { 126, null, 2, "", "", "refrigerante coca cola zero", null },
                    { 123, null, 2, "", "", "refrigerante coca-cola", null },
                    { 124, null, 2, "", "", "suco de limão", null },
                    { 125, null, 2, "", "", "refrigerante coca cola", null },
                    { 112, null, 2, "limão siciliano, frutas vermelhasm laranja e maça verde", "", "soda italiana", null },
                    { 127, null, 2, "", "", "refrigerante fanta laranja", null },
                    { 128, null, 2, "", "", "refrigerante fanta uva", null },
                    { 129, null, 2, "", "", "refrigerante scheweeps", null },
                    { 130, null, 2, "", "", "refrigerante soda", null },
                    { 122, null, 2, "", "", "refrigerante guaraná", null },
                    { 111, null, 2, "", "", "água sem gás", null },
                    { 106, null, 2, "", "", "h2o limão/limoneto", null },
                    { 109, null, 2, "delivery/retirada", "", "suco de laranja natural (300 ml)", null },
                    { 91, null, 2, "", "", "cervejas eisenbahn 600 ml", null },
                    { 92, null, 2, "", "", "refrigerante soda", null },
                    { 93, null, 2, "", "", "refrigerante fanta", null },
                    { 94, null, 2, "", "", "refrigerante guaraná", null },
                    { 95, null, 2, "", "", "refrigerante coca-cola zero", null },
                    { 96, null, 2, "", "", "refrigerante coca-cola", null },
                    { 97, null, 2, "", "", "refrigerante schwepps", null },
                    { 98, null, 2, "", "", "h20 limao e limoneto", null },
                    { 110, null, 2, "", "", "água com gás", null },
                    { 99, null, 2, "", "", "suco natural de laranja", null }
                });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "CategoriaId", "CategoriaProdutoId", "DescricaoProduto", "ImagemProduto", "NomeProduto", "ProductDescription" },
                values: new object[,]
                {
                    { 101, null, 2, "", "", "cerveja colorado appia 600 ml", null },
                    { 102, null, 2, "", "", "cerveja heineken 600 ml", null },
                    { 103, null, 2, "", "", "cerveja baden baden 600 ml", null },
                    { 104, null, 2, "copo de 300 ml ", "", "chopp (brotas beer pilsen)", null },
                    { 105, null, 2, "", "", "refrigerante soda", null },
                    { 131, null, 2, "", "", "refrigerante sprite", null },
                    { 107, null, 2, "", "", "suco", null },
                    { 108, null, 2, "consumo no local", "", "suco de laranja natural (400 ml)", null },
                    { 100, null, 2, "caneca 300 ml", "", "chopp artesanal texugos", null },
                    { 132, null, 2, "", "", "água tônica", null },
                    { 137, null, 2, "", "", "cerveja budweiser", null },
                    { 134, null, 2, "", "", "cerveja original", null },
                    { 158, null, 3, "porção de 4 palitos e 6 nuggets de frango.", "", "palito de mussarela e nuggets", null },
                    { 159, null, 3, "porção de 10 bolinhos de costela.", "", "bolinho de costela", null },
                    { 160, null, 3, "porção de 10 bolinhos de gorgonzola.", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/a5dbe4ff65084f54b8b7418a3cee4826.jpg", "bolinho de gorgonzola", null },
                    { 161, null, 3, "porção de 4 travesseiros e 6 nuggets de frango.", "", "travesseiro de muçarela e nuggets", null },
                    { 162, null, 3, "porção de 9 bolinhos de bacalhau.", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/a5dbe4ff65084f54b8b7418a3cee4826.jpg", "bolinho de bacalhau", null },
                    { 163, null, 3, "porção de 9 travesseiros de muçarela.", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/bac9a6dab320416fb4651d333c36e89b.jpg", "travesseiros de muçarela", null },
                    { 164, null, 3, "", "", "batata rústica", null },
                    { 165, null, 3, "escolha nos sabores: frango, gorgonzola ou costela", "", "coxinhas", null },
                    { 157, null, 3, "travesseirinhos de queijo gouda", "", "cheese pillows", null },
                    { 166, null, 3, "8 unidades de almofadinhas de queijo", "", "almofadinhas de queijo", null },
                    { 168, null, 3, "porção de coxinhas (salgadinhos) de frango", "", "coxinha de frango", null },
                    { 169, null, 3, "porção de coxinhas (salgadinhos) de gorgonzola", "", "coxinha de gorgonzola", null },
                    { 170, null, 3, "porção de 4 travesseios de mussarela e 6 nuggets de frango.", "", "travesseiro de mussarela e nuggets", null },
                    { 171, null, 4, "8 mini churros acompanhado de doce de leite ou nutella", "", "mini churros", null },
                    { 172, null, 4, "2 bolas de sorvete, cobertura de chocolate, canudo biju waffer e confetes", "", "sorvekids", null },
                    { 173, null, 4, "ganache de chocolate meio amargo, sorvete  de leite ninho trufado e farofa de bolacha negresco", "", "taça negresco", null },
                    { 174, null, 4, "brownie de chocolate, sorvete de creme e calda de chocolate", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/5185dabab1b34d8a9ee4b692cf62ac26.png", "brasa brownie", null },
                    { 175, null, 4, "", "", "milk shake", null },
                    { 167, null, 3, "porção de nuggets", "", "nuggets", null },
                    { 156, null, 3, "aproximadamente 300g de fritas, coberta com carne bovin desfiada, catupiry original e bacon", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/cdac614bbca04f96921bcfa61e38017e.jpg", "brasa fries and ribs", null },
                    { 155, null, 3, "aproximadamente 350g de fritas .", "", "fritas", null },
                    { 154, null, 3, "", "", "batata de carinha e nuggets com molho rosé", null },
                    { 135, null, 2, "", "", "cerveja colorado appia", null },
                    { 136, null, 2, "", "", "long neck heineken", null },
                    { 90, null, 2, "", "", "cervejas colorado 600 ml", null },
                    { 138, null, 2, "", "", "cerveja eisenbahn", null },
                    { 139, null, 2, "", "", "cerveja corona", null },
                    { 140, null, 3, "aproximadamente 350g de fritas acompanhadas do melhor bacon do universo.", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/1c74f9cc7d0c4837981139e860889c38.jpg", "fritas com bacon", null },
                    { 141, null, 3, "aproximadamente 300g de fritas, coberta com carne bovin desfiada, catupiry original e bacon", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/d1688218ecf34409ae1051cc24e649bd.jpg", "brasa fries and rib", null },
                    { 142, null, 3, "porção de 15 anéis de cebola", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/86f6fdcc6c934c5ea93ce24e70603aeb.jpg", "aneis de cebola", null }
                });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "CategoriaId", "CategoriaProdutoId", "DescricaoProduto", "ImagemProduto", "NomeProduto", "ProductDescription" },
                values: new object[,]
                {
                    { 143, null, 3, "porção de 9 bolinhos (costela,coxinha,gorgonzola e carne seca com requeijão) em uma cama de catupiry", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/796f32e4f67b47efb7d0b9b7a981fc29.jpg", "mix de bolinhos", null },
                    { 144, null, 3, "meia porção de fritas com 8 anéis de cebola.", "", "fritas e aneis de cebola", null },
                    { 145, null, 3, "porção de 4 palitos e 6 nuggets de frango.", "", "travesseiro de queijo gouda e nuggets", null },
                    { 146, null, 3, "aproximadamente 300g de fritas, carne de costela bovina desfiada, catupiry e bacon", "", "brasa fries and ribs (fritas com costela)", null },
                    { 147, null, 3, "", "", "aneis de cebola (10 unidades)", null },
                    { 148, null, 3, "", "", "travesseiro de queijo com molho barbecue", null },
                    { 149, null, 3, "", "", "bolinho de costela servido com geléia de abacaxi com pimenta", null },
                    { 150, null, 3, "", "", "mussarela de búfala crispy com geléia de pimenta", null },
                    { 151, null, 3, "", "", "frango artesanal no palito com maionese verde", null },
                    { 152, null, 3, "", "", "croquete de carne na cama de cream cheese", null },
                    { 153, null, 3, "", "", "batata rústica com ervas finas", null },
                    { 133, null, 2, "", "", "h20 limão/limoneto", null },
                    { 89, null, 2, "", "", "cervejas heineken 600 ml", null },
                    { 84, null, 2, "", "", "cervejas long neck eisenbah", null },
                    { 87, null, 2, "", "", "cervejas long neck corona", null },
                    { 24, null, 1, "2 carnes de 100 gramas, queijo prato,  alface, pão de hambúrguer artesanal, catupiry original, linguiça calabresa picada bem fininha e frita e um sensacional vinagrete! (tomate + cebola + pimentão). ", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/799aa62124fa4ec5a47d307ba7288450.png", "brasa especial", null },
                    { 25, null, 1, "alface, tomate, hambúrguer de 150 gramas, queijo prato e aquele aquele molhinho delicia! acompanha fritas e refri de 200 ml.", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/6f2e403e00684f859272073e5efc6a92.png", "combo rose", null },
                    { 26, null, 1, "rúcula, hambúrguer de 150g, queijo cheddar e cebola caramelizada! acompanha refri 200 ml e fritas.", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/56e429222b864f999e22a05b69a71fb1.png", "combo caramelizado", null },
                    { 27, null, 1, "esse foi pensando especialmente pra você que ama bacon! hambúrguer de 180g, queijo prato, maionese de bacon, alface, tomate e cebola roxa.", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/23d1f5302c81456fb741965455739dd3.png", "brasa bacon", null },
                    { 28, null, 1, "pcq (pão, carne (100gramas) e queijo + fritas + refri de 200 ml + danoninho! alegria da criançada!", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/c48e2932fe664d5f8323d505ffd52563.png", "combo kids junior", null },
                    { 29, null, 1, "2 carnes de 100 gramas, queijo prato,  alface, pão de hambúrguer artesanal, catupiry original, linguiça calabresa picada bem fininha e frita e um sensacional vinagrete! (tomate + cebola + pimentão). ", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/799aa62124fa4ec5a47d307ba7288450.png", "brasa calabresa", null },
                    { 30, null, 2, "", "", "long neck heineken", null },
                    { 31, null, 2, "", "", "long neck budweiser", null },
                    { 23, null, 1, "pão tipo italianinho, hambúrguer de 200g, queijo prato, muçarela crispy, geleia de pimenta, rúcula, tomate e cebola", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/f664cc52fe4a4a0f92c63de34172e37e.png", "cheese brasa", null },
                    { 32, null, 2, "", "", "long neck corona", null },
                    { 34, null, 2, "", "", "água com gás", null },
                    { 35, null, 2, "", "", "água sem gás", null },
                    { 36, null, 2, "", "", "cerveja original 600 ml", null },
                    { 37, null, 2, "", "", "cerveja colorado appia 600 ml", null },
                    { 38, null, 2, "", "", "refrigerante guaraná antarctica", null },
                    { 39, null, 2, "", "", "refrigerante coca-cola", null },
                    { 40, null, 2, "", "", "refrigerante fanta", null },
                    { 41, null, 2, "", "", "refrigerante soda/sprite", null },
                    { 33, null, 2, "", "", "long neck eisenbahn", null },
                    { 22, null, 1, "alface americana, tomate fresquinho, hambúrguer, ovo fritinho e nossa maionese verde caseira! acompanha refri 200 ml e batatinha!", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/22a493d5c7c34907bf2d81552a7d1425.png", "brasa egg", null },
                    { 21, null, 1, "2 carnes de 100 gramas, queijo prato,  alface, pão de hambúrguer artesanal, catupiry original, linguiça calabresa picada bem fininha e frita e um sensacional vinagrete! (tomate + cebola + pimentão). ", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/799aa62124fa4ec5a47d307ba7288450.png", "especial", null },
                    { 20, null, 1, "para os amantes do melhor queijo do universo! acompanhado de rúcula, cebola chapeada e aquele tomate fresco! e claro: nosso hambúrguer de 180g e bacon!", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/6b676f1af13e4a1199c8905e9badc4b7.png", "brasa gorgonzola", null },
                    { 1, null, 1, "o melhor hambúrguer, com 200g de pura delícia, creme cheddar artesanal feito com muito amor e carinho, uma farofinha de bacon totalmente especial e aquela alface e tomate fresquinhos", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/8f7e76090120440bb61f4d5fb0107f3a.png", "brasão", null },
                    { 2, null, 1, "hambúrguer de frango feito na casa, sem conservantenenhum, só com peito de frango, bacon, catupiry (original né pai?), couve crispy (fritinha, delícia!)", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/4af6e2ea8a4247bf87db51211e1bcf96.png", "brasa chicken crisp", null },
                    { 3, null, 1, "hambúrguer de 180g. baaaaconnnnn, molho barbecue (o melhor da sua vida), queijo cheddar, rúcula, cebola e tomate, por que nóis é fit", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/2673656e9d7d454c80cc52b32482085e.png", "barbecue", null },
                    { 4, null, 1, "nosso de boa que de boa só tem o nome! esse é o nosso x-salada ! alface, tomate, cebola roxa, hambúrguer de 180 gramas, queijo prato e maionese verde feita na casa.", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/472f4dd5cf3646e4b8e60ec7259fa6aa.png", "de boa", null },
                    { 5, null, 1, "para os amantes do melhor queijo do universo! acompanhado de rúcula, cebola chapeada e aquele tomate fresco! e claro: nosso hambúrguer de 180g e bacon!", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/6b676f1af13e4a1199c8905e9badc4b7.png", "brasagorgonzola", null }
                });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "CategoriaId", "CategoriaProdutoId", "DescricaoProduto", "ImagemProduto", "NomeProduto", "ProductDescription" },
                values: new object[,]
                {
                    { 6, null, 1, "esse era um dos especiais que entrou no cardápio por todo mundo a-m-a-r! alface, tomate, hambúrguer de 180 g, queijo prato, nosso ketchup de goiaba flambado na cachaça feito na casa e um belo de um pedaço de provolone empanado e frito!", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/3fcc9822405b489883223c3f218b854c.png", "brasa provolone", null },
                    { 7, null, 1, "esse é o famoso hambúrguer de costela! 200 gramas de costela bovina, rúcula, tomate, queijo minas, molho lemon pepper com mel e onion rings! sensacional !", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/56baea49fb7e49e6a354eaec36809d2d.png", "brasa ribs", null },
                    { 8, null, 1, "feito com a revolucionária carne da fazenda do futuro, esse é pra quem é vegetariano! lembrando que nosso pão é 100% vegano. acompanha alface, tomate, cebola, queijo prato e catupiry original.", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/46bf73190bce4582aaf26b7312f05105.png", "brasa futuro", null },
                    { 9, null, 1, "carne de 180g, alface, tomate, catupiry original, alho fritinho e muiiiiiiito bacon! esse é de comer pensando: se existe lanche perfeito, é esse!", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/0c78640ab0174a33abdb6d64245f76b6.png", "brasapiry", null },
                    { 10, null, 1, "gosta de apimentar um pouco as coisas? então essa é sua pedida! alface, tomate, cebola, hambúrguer de 180g, queijo prato, molho chipotle com especiarias e nachos! picância média - alta", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/2caaac2ec7a04f9caf082edca135bf2c.png", "braseiro", null },
                    { 11, null, 1, "rúcula, cebola, queijo cheddar,hambúrguer de 150 gramas e nossa deliciosa maionese de bacon feita na casa! acompanha refri 200 ml.", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/9adcc0e66c204cc8ad68a1626808d9ea.png", "combo cheddar", null },
                    { 12, null, 1, "alface, tomate, hambúrguer de 150 gramas, queijo prato , picles e aquele aquele molhinho delicia! acompanha fritas e refri de 200 ml.", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/53b11a4c644843dd9f20ef55bf683906.png", "combo taste", null },
                    { 13, null, 1, "o nome é kids mas esse é o nosso famoso pcq (pão, carne e queijo), ideal para você aflorar a imaginação e colocar quantos adicionais quiser! ele leva hambúrguer de 180 gramas.", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/9640153ac30c4d7d9d2d8cb37aa5a630.png", "kids", null },
                    { 14, null, 1, "nosso vegetariano com hambúrguer de soja crispy feito na casa, alface, tomate, cebola, queijo prato e catupiry original. nosso pão é 100% vegano.", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/7bf646da500048f4af0ac3f38ec2174c.png", "vegetariano", null },
                    { 15, null, 1, "hambúrger de 180 gramas, catupiry empanado crispy, geléia de abacaxi com pimenta, bacon, queijo prato, rúcula, tomate e cebola roxa. gigante!", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/e492b742fa0f490f83978dbddfdd6126.png", "brasa califórnia", null },
                    { 16, null, 1, "esse é um dos mais amados de todas as unidade do brasa! 2 hambúrguers de 100 gramas, queijo cheddar, muiiito bacon e geléia de pimenta! perfeito! ps: experimenta pedir com adicional de catupiry! fica sensacional", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/c8f4943997624b90b9c5a73d77a18c89.png", "smash brasa", null },
                    { 17, null, 1, "futuro burger 100% plantas, maionese verde vegana, alface, tomate, cebola roxa, champignon salteado no azeite e tofu temperado. 100% vegano", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/192fa890bf6841b5af5fbdd7e55e7bd3.png", "brasa vegano", null },
                    { 18, null, 1, "escolha o creme de queijo para mergulhar seu burger e fritas (cheddar, prato e gorgonzola) serve de 2 a 3 pessoas.", "", "brasa bowl", null },
                    { 19, null, 1, "hambúrguer de frango feito na casa, sem conservante nenhum, só com peito de frango, bacon, catupiry (original né pai?), couve crispy (fritinha, delícia!)", "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/4af6e2ea8a4247bf87db51211e1bcf96.png", "brasa chicken crispy", null },
                    { 42, null, 2, "", "", "água tônica", null },
                    { 88, null, 2, "", "", "cervejas original 600 ml", null },
                    { 43, null, 2, "", "", "refrigerante schweeps", null },
                    { 45, null, 2, "", "", "tônica", null },
                    { 69, null, 2, "suco de laranja, suco de pêssego e um lance de groselha ", "", "kiss on the beach", null },
                    { 70, null, 2, "suco de uva, suco de abacaxi e leite condensado", "", "spanish", null },
                    { 71, null, 2, "suco de abacaxi, suco de maracuja, leite condensado e cobertura de morango", "", "pipeline", null },
                    { 72, null, 2, "rum, suco de abacaxi, leite de côco e leite condensado.", "", "piña colada", null },
                    { 73, null, 2, "vodka, xarope de pêssego, suco de laranja e grenadine", "", "sex on the beach", null },
                    { 74, null, 2, "vodka, xarope de açucar e espuma de gengibre", "", "moscow mule", null },
                    { 75, null, 2, "vinho com morango, abacaxi ou maracujá e leite condensado", "", "espanhola", null },
                    { 76, null, 2, "rum, hortelã macerado com açucar, suco de limão e água com gás", "", "mojito", null },
                    { 68, null, 2, "suco de laranja, suco de abacaxi, soda limonada e um lance de groselha", "", "caipirinha teen", null },
                    { 77, null, 2, "whisky, limão maceradp com açucar e borda com sal.", "", "whisky sour", null },
                    { 79, null, 2, "limão siciliano, suco de groselha e aqua mix", "", "pink lemonade (500 ml)", null },
                    { 80, null, 2, "", "", "campari", null },
                    { 81, null, 2, "", "", "whisky red label", null },
                    { 82, null, 2, "", "", "vodka absolut", null },
                    { 83, null, 2, "", "", "gin tanqueray", null },
                    { 176, null, 4, "", "", "brasa split", null },
                    { 85, null, 2, "", "", "cervejas long neck heineken", null },
                    { 86, null, 2, "", "", "cervejas long neck budweiser", null },
                    { 78, null, 2, "tequila, limão, um lance de curaçau e borda com sal", "", "margarita", null },
                    { 67, null, 2, "escolha 3 opcões: blueberry, cardamomo, zimbro, anis estrelado, canela", "", "gin especiarias", null },
                    { 66, null, 2, "tônica e maça verde", "", "gin maça verde", null },
                    { 65, null, 2, "energético tropical ou energético melância", "", "gin tônica tropical", null },
                    { 46, null, 2, "", "", "água mineral", null },
                    { 47, null, 2, "", "", "água mineral com gás", null }
                });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "CategoriaId", "CategoriaProdutoId", "DescricaoProduto", "ImagemProduto", "NomeProduto", "ProductDescription" },
                values: new object[,]
                {
                    { 48, null, 2, "", "", "h20 limão ou limoneto", null },
                    { 49, null, 2, "", "", "red bull original", null },
                    { 50, null, 2, "", "", "red bull tropical", null },
                    { 51, null, 2, "", "", "red bull melancia", null },
                    { 52, null, 2, "400 ml", "", "sucos natural de laranja", null },
                    { 53, null, 2, "400 ml", "", "sucos natural de limão", null },
                    { 54, null, 2, "400 ml", "", "sucos natural de maracujá", null },
                    { 55, null, 2, "400 ml", "", "sucos polpa abacaxi com hortelã", null },
                    { 56, null, 2, "400 ml", "", "sucos polpa acerola", null },
                    { 57, null, 2, "400 ml", "", "sucos polpa caju", null },
                    { 58, null, 2, "", "", "brotas beer pilsen", null },
                    { 59, null, 2, "", "", "brotas beer weiss", null },
                    { 60, null, 2, "", "", "brotas beer red ale", null },
                    { 61, null, 2, "", "", "brotas beer double ipa bruta flor", null },
                    { 62, null, 2, "", "", "brotas beer ne ipa uvaia juicy", null },
                    { 63, null, 2, "", "", "chopp brotas beer pilsen", null },
                    { 64, null, 2, "", "", "chopp brotas beer ipa", null },
                    { 44, null, 2, "", "", "suco de laranja", null }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "CodigoUsuario", "DataNascimento", "EmailUsuario", "Endereco", "NomeUsuario", "Senha", "Whatsapp" },
                values: new object[] { 1, "vitoria.fusco", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "vitoriaketillin@hotmail.com", "Moisés Fantin, 92", "Vitória Fusco", "$2a$11$1p.3/q6KPnbMitb8mFihTOvkOuPoxPZ/uitRlr9woiWpHR9/u8TOa", "14998700705" });

            migrationBuilder.InsertData(
                table: "CategoriaProduto",
                columns: new[] { "Id", "CategoriaAdicionalId", "CategoryName", "EstabelecimentoId", "ExibirCardapio", "ImagemFiltro", "NomeCategoriaProduto" },
                values: new object[,]
                {
                    { 3, 1, null, null, true, "/assets/imagens/iconesCategoriaProduto/Entradas e Porções.svg", "Entradas e Porções" },
                    { 1, 2, null, null, true, "/assets/imagens/iconesCategoriaProduto/Hambúrgueres.svg", "Hambúrgueres" }
                });

            migrationBuilder.InsertData(
                table: "Estabelecimento",
                columns: new[] { "Id", "CategoriaEstabelecimentoId", "Cidade", "Endereco", "Facebook", "ImagemCapa", "Instagram", "LinkCardapio", "Logo", "Nome", "Telefone", "UF", "Whatsapp" },
                values: new object[,]
                {
                    { 1, 1, "Barra Bonita", "Av. Caio Simões, 306 - Vila Sao Jose", null, "", null, "Barra-Bonita", "", "Brasa", "(14) 99606-1938", "SP", null },
                    { 2, 1, "Pederneiras", "Av. Brasil, 410 - Jd Bandeirantes", null, "", null, "Pederneiras", "", "Brasa", "(14) 99667-3737", "SP", null },
                    { 3, 1, "Lençóis Paulista", "Av. Nove de Julho, 791 - Centro", null, "", null, "Lencois-Paulista", "", "Brasa", "(14) 99691-0647", "SP", null },
                    { 4, 1, "Botucatu", "Av. Leonardo Vilas Boas, 641 - Vila Nova Botucatu", null, "", null, "Botucatu", "", "Brasa", "(14) 99673-6679", "SP", null },
                    { 5, 1, "Jaú", "R. Cônego Anselmo Valvekens, 48 - Centro", null, "", null, "Jau", "", "Brasa", "99815-0116", "SP", null },
                    { 6, 1, "Bauru", "R. Luís Bleriot, 8-33 - Vila Aviação", null, "", null, "Bauru", "", "Brasa", "(14) 99720-0798", "SP", null }
                });

            migrationBuilder.InsertData(
                table: "PerfilUsuario",
                columns: new[] { "Id", "PerfilId", "UsuarioId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "DiaHorasFuncionamento",
                columns: new[] { "Id", "DiaFim", "DiaInicio", "EstabelecimentoId", "HoraFim", "HoraInicio" },
                values: new object[,]
                {
                    { 3, 3, 3, 1, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 4, 4, 5, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 5, 5, 5, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 6, 6, 5, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 0, 0, 5, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 0, 0, 4, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 6, 6, 4, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 5, 5, 4, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 4, 4, 4, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 3, 3, 4, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 3, 3, 2, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 3, 3, 5, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 4, 4, 2, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 6, 6, 2, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 0, 0, 2, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 0, 0, 6, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 6, 6, 6, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 5, 5, 6, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 4, 4, 6, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 3, 3, 6, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 0, 0, 3, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 6, 6, 3, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 3, 3, 3, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 5, 5, 2, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 4, 4, 3, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 5, 5, 3, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 6, 6, 1, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, 5, 1, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, 4, 1, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 0, 0, 1, new DateTime(2021, 8, 26, 22, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 18, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Ingrediente",
                columns: new[] { "Id", "DescricaoIngrediente", "EstabelecimentoId", "NameIngredient", "NomeIngrediente" },
                values: new object[,]
                {
                    { 22, null, 1, null, "catupiry original" },
                    { 20, null, 1, null, "onion rings" },
                    { 79, null, 1, null, "queijo minas padrão" },
                    { 77, null, 1, null, "molho tasty" },
                    { 76, null, 1, null, "nachos (doritos)" },
                    { 75, null, 1, null, "batata rústica" },
                    { 74, null, 1, null, "cebola caramelizada" },
                    { 72, null, 1, null, "picles - 3,50" },
                    { 71, null, 1, null, "maionese de bacon" },
                    { 70, null, 1, null, "geléia de abacaxi" },
                    { 69, null, 1, null, "farofa de bacon" },
                    { 68, null, 1, null, "nachos" }
                });

            migrationBuilder.InsertData(
                table: "Ingrediente",
                columns: new[] { "Id", "DescricaoIngrediente", "EstabelecimentoId", "NameIngredient", "NomeIngrediente" },
                values: new object[,]
                {
                    { 67, null, 1, null, "batata extra" },
                    { 66, null, 1, null, "molho rosé" },
                    { 73, null, 1, null, "geléia de abacaxi c/ pimenta" },
                    { 65, null, 1, null, "catupiry crispy" },
                    { 1, null, 1, null, "creme cheddar" },
                    { 3, null, 1, null, "alface" },
                    { 5, null, 1, null, "peito de frango" },
                    { 6, null, 1, null, "bacon" },
                    { 7, null, 1, null, "catupiry" },
                    { 8, null, 1, null, "couve crispy" },
                    { 9, null, 1, null, "molho barbecue" },
                    { 10, null, 1, null, "queijo cheddar" },
                    { 11, null, 1, null, "rúcula" },
                    { 12, null, 1, null, "cebola" },
                    { 13, null, 1, null, "cebola roxa" },
                    { 14, null, 1, null, "queijo prato" },
                    { 15, null, 1, null, "maionese" },
                    { 16, null, 1, null, "cebola chapeada" },
                    { 17, null, 1, null, "ketchup de goiaba flambado na cachaça" },
                    { 18, null, 1, null, "costela bovina" },
                    { 19, null, 1, null, "queijo minas" },
                    { 21, null, 1, null, "molho lemon pepper com mel" },
                    { 4, null, 1, null, "tomate" },
                    { 2, null, 1, null, "farofinha de bacon" },
                    { 64, null, 1, null, "alho frito" },
                    { 78, null, 1, null, "anéis de cebola" },
                    { 62, null, 1, null, "hambúrguer frango" },
                    { 41, null, 1, null, "catupiry original" },
                    { 40, null, 1, null, "salada ou cebola roxa" },
                    { 39, null, 1, null, "maionese verde" },
                    { 38, null, 1, null, "creme cheddar" },
                    { 63, null, 1, null, "maionese bacon" },
                    { 36, null, 1, null, "cebola caramelizada" },
                    { 35, null, 1, null, "vinagrete" },
                    { 34, null, 1, null, "maionese verde" },
                    { 33, null, 1, null, "linguiça calabresa" },
                    { 32, null, 1, null, "tofu temperado" },
                    { 31, null, 1, null, "champignon" },
                    { 30, null, 1, null, "maionese verde vegana" },
                    { 29, null, 1, null, "geléia de pimenta" },
                    { 28, null, 1, null, "geléia de abacaxi com pimenta" },
                    { 27, null, 1, null, "catupiry empanado crispy" }
                });

            migrationBuilder.InsertData(
                table: "Ingrediente",
                columns: new[] { "Id", "DescricaoIngrediente", "EstabelecimentoId", "NameIngredient", "NomeIngrediente" },
                values: new object[,]
                {
                    { 26, null, 1, null, "picles" },
                    { 25, null, 1, null, "maionese de bacon" },
                    { 24, null, 1, null, "molho chipotle" },
                    { 23, null, 1, null, "alho fritinho" },
                    { 42, null, 1, null, "geléia de pimenta" },
                    { 43, null, 1, null, "queijo prato (2 fatias)" },
                    { 37, null, 1, null, "hambúrguer 180g" },
                    { 56, null, 1, null, "queijo prato (fatia)" },
                    { 57, null, 1, null, "maionese verde" },
                    { 58, null, 1, null, "cheddar (fatia)" },
                    { 59, null, 1, null, "geléia de pimenta" },
                    { 55, null, 1, null, "catupiry original" },
                    { 54, null, 1, null, "creme de gorgonzola" },
                    { 53, null, 1, null, "creme cheddar" },
                    { 52, null, 1, null, "ovo" },
                    { 60, null, 1, null, "hambúrguer 100g" },
                    { 61, null, 1, null, "hambúrguer costela 200g" },
                    { 51, null, 1, null, "picles" },
                    { 50, null, 1, null, "molho barbecue" },
                    { 49, null, 1, null, "creme gorgonzola" },
                    { 47, null, 1, null, "provolone crispy" },
                    { 46, null, 1, null, "anel de cebola (4)" },
                    { 45, null, 1, null, "bacon" },
                    { 44, null, 1, null, "queijo cheddar (2fatias)" },
                    { 48, null, 1, null, "ketchup de goiabada" }
                });

            migrationBuilder.InsertData(
                table: "ProdutoEstabelecimento",
                columns: new[] { "Id", "Ativo", "EstabelecimentoId", "Observacao", "ProdutoId", "Valor", "ValorPromocional" },
                values: new object[,]
                {
                    { 217, false, 5, null, 160, 19.0, 0.0 },
                    { 219, false, 5, null, 156, 27.989999999999998, 0.0 },
                    { 216, false, 5, null, 162, 19.0, 0.0 },
                    { 215, false, 5, null, 159, 19.0, 0.0 },
                    { 214, false, 5, null, 142, 20.0, 0.0 },
                    { 213, false, 5, null, 161, 24.0, 0.0 },
                    { 212, false, 5, null, 144, 24.0, 0.0 },
                    { 211, false, 5, null, 155, 22.0, 0.0 },
                    { 210, false, 5, null, 140, 26.0, 0.0 },
                    { 218, false, 5, null, 163, 18.0, 0.0 },
                    { 220, false, 5, null, 172, 10.9, 0.0 },
                    { 234, false, 5, null, 39, 6.0, 0.0 },
                    { 222, false, 5, null, 174, 16.899999999999999, 0.0 },
                    { 233, false, 5, null, 38, 6.0, 0.0 },
                    { 232, false, 5, null, 104, 8.9000000000000004, 0.0 },
                    { 231, false, 5, null, 103, 19.0, 0.0 },
                    { 230, false, 5, null, 102, 15.0, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "ProdutoEstabelecimento",
                columns: new[] { "Id", "Ativo", "EstabelecimentoId", "Observacao", "ProdutoId", "Valor", "ValorPromocional" },
                values: new object[,]
                {
                    { 236, false, 5, null, 105, 6.0, 0.0 },
                    { 237, false, 5, null, 42, 6.0, 0.0 },
                    { 229, false, 5, null, 36, 14.0, 0.0 },
                    { 209, false, 5, null, 18, 13.0, 0.0 },
                    { 228, false, 5, null, 101, 19.0, 0.0 },
                    { 227, false, 5, null, 30, 11.0, 0.0 },
                    { 235, false, 5, null, 40, 6.0, 0.0 },
                    { 226, false, 5, null, 32, 10.0, 0.0 },
                    { 225, false, 5, null, 31, 9.0, 0.0 },
                    { 224, false, 5, null, 33, 9.0, 0.0 },
                    { 223, false, 5, null, 171, 14.0, 0.0 },
                    { 221, false, 5, null, 173, 16.899999999999999, 0.0 },
                    { 208, false, 5, null, 17, 32.0, 0.0 },
                    { 186, false, 4, null, 100, 7.0, 0.0 },
                    { 206, false, 5, null, 26, 26.899999999999999, 0.0 },
                    { 184, false, 4, null, 35, 4.0, 0.0 },
                    { 183, false, 4, null, 99, 6.5, 0.0 },
                    { 182, false, 4, null, 98, 6.5, 0.0 },
                    { 181, false, 4, null, 97, 5.0, 0.0 },
                    { 180, false, 4, null, 96, 5.0, 0.0 },
                    { 179, false, 4, null, 95, 5.0, 0.0 },
                    { 178, false, 4, null, 94, 5.0, 0.0 },
                    { 185, false, 4, null, 34, 4.0, 0.0 },
                    { 177, false, 4, null, 93, 5.0, 0.0 },
                    { 175, false, 4, null, 91, 14.0, 0.0 },
                    { 174, false, 4, null, 90, 16.0, 0.0 },
                    { 172, false, 4, null, 88, 12.0, 0.0 },
                    { 171, false, 4, null, 87, 9.0, 0.0 },
                    { 170, false, 4, null, 86, 9.0, 0.0 },
                    { 169, false, 4, null, 85, 10.0, 0.0 },
                    { 168, false, 4, null, 84, 9.0, 0.0 },
                    { 176, false, 4, null, 92, 5.0, 0.0 },
                    { 207, false, 5, null, 16, 29.0, 0.0 },
                    { 187, false, 5, null, 1, 29.0, 0.0 },
                    { 189, false, 5, null, 3, 30.0, 0.0 },
                    { 205, false, 5, null, 12, 26.899999999999999, 0.0 },
                    { 204, false, 5, null, 15, 33.0, 0.0 },
                    { 203, false, 5, null, 14, 30.0, 0.0 },
                    { 202, false, 5, null, 13, 22.0, 0.0 },
                    { 201, false, 5, null, 28, 22.989999999999998, 0.0 },
                    { 200, false, 5, null, 27, 30.0, 0.0 },
                    { 199, false, 5, null, 4, 27.0, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "ProdutoEstabelecimento",
                columns: new[] { "Id", "Ativo", "EstabelecimentoId", "Observacao", "ProdutoId", "Valor", "ValorPromocional" },
                values: new object[,]
                {
                    { 188, false, 5, null, 19, 26.0, 0.0 },
                    { 198, false, 5, null, 25, 23.899999999999999, 0.0 },
                    { 196, false, 5, null, 10, 29.0, 0.0 },
                    { 195, false, 5, null, 9, 30.0, 0.0 },
                    { 194, false, 5, null, 8, 30.0, 0.0 },
                    { 193, false, 5, null, 7, 31.0, 0.0 },
                    { 192, false, 5, null, 6, 32.0, 0.0 },
                    { 191, false, 5, null, 20, 31.0, 0.0 },
                    { 190, false, 5, null, 24, 31.0, 0.0 },
                    { 197, false, 5, null, 11, 23.899999999999999, 0.0 },
                    { 173, false, 4, null, 89, 16.0, 0.0 },
                    { 279, false, 6, null, 154, 20.0, 0.0 },
                    { 239, false, 5, null, 106, 7.5, 0.0 },
                    { 300, false, 6, null, 62, 29.989999999999998, 0.0 },
                    { 299, false, 6, null, 61, 31.989999999999998, 0.0 },
                    { 298, false, 6, null, 60, 24.0, 0.0 },
                    { 297, false, 6, null, 59, 23.0, 0.0 },
                    { 296, false, 6, null, 58, 22.0, 0.0 },
                    { 295, false, 6, null, 57, 7.5, 0.0 },
                    { 294, false, 6, null, 56, 7.5, 0.0 },
                    { 293, false, 6, null, 55, 7.5, 0.0 },
                    { 292, false, 6, null, 54, 7.5, 0.0 },
                    { 291, false, 6, null, 53, 7.5, 0.0 },
                    { 290, false, 6, null, 52, 7.5, 0.0 },
                    { 289, false, 6, null, 51, 12.0, 0.0 },
                    { 288, false, 6, null, 50, 12.0, 0.0 },
                    { 287, false, 6, null, 49, 12.0, 0.0 },
                    { 286, false, 6, null, 48, 7.5, 0.0 },
                    { 285, false, 6, null, 47, 4.5, 0.0 },
                    { 284, false, 6, null, 46, 4.0, 0.0 },
                    { 301, false, 6, null, 63, 9.5, 0.0 },
                    { 283, false, 6, null, 45, 5.5, 0.0 },
                    { 302, false, 6, null, 64, 10.5, 0.0 },
                    { 304, false, 6, null, 66, 28.899999999999999, 0.0 },
                    { 321, false, 6, null, 81, 16.899999999999999, 0.0 },
                    { 320, false, 6, null, 80, 11.9, 0.0 },
                    { 319, false, 6, null, 79, 15.99, 0.0 },
                    { 318, false, 6, null, 79, 15.99, 0.0 },
                    { 317, false, 6, null, 79, 15.99, 0.0 },
                    { 316, false, 6, null, 78, 23.899999999999999, 0.0 },
                    { 315, false, 6, null, 77, 23.899999999999999, 0.0 },
                    { 314, false, 6, null, 76, 23.899999999999999, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "ProdutoEstabelecimento",
                columns: new[] { "Id", "Ativo", "EstabelecimentoId", "Observacao", "ProdutoId", "Valor", "ValorPromocional" },
                values: new object[,]
                {
                    { 313, false, 6, null, 75, 21.899999999999999, 0.0 },
                    { 312, false, 6, null, 74, 23.899999999999999, 0.0 },
                    { 311, false, 6, null, 73, 25.899999999999999, 0.0 },
                    { 310, false, 6, null, 72, 25.899999999999999, 0.0 },
                    { 309, false, 6, null, 71, 15.9, 0.0 },
                    { 308, false, 6, null, 70, 15.9, 0.0 },
                    { 307, false, 6, null, 69, 13.9, 0.0 },
                    { 306, false, 6, null, 68, 13.9, 0.0 },
                    { 305, false, 6, null, 67, 31.899999999999999, 0.0 },
                    { 303, false, 6, null, 65, 28.899999999999999, 0.0 },
                    { 238, false, 5, null, 43, 6.0, 0.0 },
                    { 282, false, 6, null, 173, 17.0, 0.0 },
                    { 280, false, 6, null, 171, 14.99, 0.0 },
                    { 258, false, 6, null, 21, 30.0, 0.0 },
                    { 257, false, 6, null, 10, 29.0, 0.0 },
                    { 256, false, 6, null, 9, 30.0, 0.0 },
                    { 255, false, 6, null, 8, 32.0, 0.0 },
                    { 254, false, 6, null, 7, 31.0, 0.0 },
                    { 253, false, 6, null, 6, 32.0, 0.0 },
                    { 252, false, 6, null, 20, 31.0, 0.0 },
                    { 251, false, 6, null, 3, 31.0, 0.0 },
                    { 250, false, 6, null, 19, 28.0, 0.0 },
                    { 248, false, 5, null, 115, 18.899999999999999, 0.0 },
                    { 247, false, 5, null, 114, 18.989999999999998, 0.0 },
                    { 246, false, 5, null, 113, 13.99, 0.0 },
                    { 245, false, 5, null, 112, 11.9, 0.0 },
                    { 244, false, 5, null, 111, 4.0, 0.0 },
                    { 243, false, 5, null, 110, 4.0, 0.0 },
                    { 242, false, 5, null, 109, 6.0, 0.0 },
                    { 241, false, 5, null, 108, 7.5, 0.0 },
                    { 259, false, 6, null, 22, 21.989999999999998, 0.0 },
                    { 281, false, 6, null, 172, 11.0, 0.0 },
                    { 260, false, 6, null, 11, 21.989999999999998, 0.0 },
                    { 262, false, 6, null, 23, 33.0, 0.0 },
                    { 167, false, 4, null, 171, 15.0, 0.0 },
                    { 278, false, 6, null, 153, 15.0, 0.0 },
                    { 277, false, 6, null, 152, 22.0, 0.0 },
                    { 276, false, 6, null, 151, 15.0, 0.0 },
                    { 275, false, 6, null, 150, 21.0, 0.0 },
                    { 274, false, 6, null, 149, 22.0, 0.0 },
                    { 273, false, 6, null, 148, 21.0, 0.0 },
                    { 272, false, 6, null, 147, 20.0, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "ProdutoEstabelecimento",
                columns: new[] { "Id", "Ativo", "EstabelecimentoId", "Observacao", "ProdutoId", "Valor", "ValorPromocional" },
                values: new object[,]
                {
                    { 271, false, 6, null, 144, 23.0, 0.0 },
                    { 270, false, 6, null, 146, 31.0, 0.0 },
                    { 269, false, 6, null, 18, 15.0, 0.0 },
                    { 268, false, 6, null, 17, 32.0, 0.0 },
                    { 267, false, 6, null, 14, 31.0, 0.0 },
                    { 266, false, 6, null, 15, 33.0, 0.0 },
                    { 265, false, 6, null, 16, 29.0, 0.0 },
                    { 264, false, 6, null, 13, 22.0, 0.0 },
                    { 263, false, 6, null, 4, 28.0, 0.0 },
                    { 261, false, 6, null, 12, 21.989999999999998, 0.0 },
                    { 166, false, 4, null, 160, 21.0, 0.0 },
                    { 121, false, 3, null, 169, 16.0, 0.0 },
                    { 164, false, 4, null, 142, 21.0, 0.0 },
                    { 58, false, 2, null, 16, 26.0, 0.0 },
                    { 57, false, 2, null, 15, 30.0, 0.0 },
                    { 56, false, 2, null, 14, 25.0, 0.0 },
                    { 55, false, 2, null, 13, 19.0, 0.0 },
                    { 54, false, 2, null, 12, 19.989999999999998, 0.0 },
                    { 53, false, 2, null, 26, 19.989999999999998, 0.0 },
                    { 52, false, 2, null, 4, 23.0, 0.0 },
                    { 59, false, 2, null, 17, 31.0, 0.0 },
                    { 51, false, 2, null, 25, 19.989999999999998, 0.0 },
                    { 49, false, 2, null, 10, 26.0, 0.0 },
                    { 48, false, 2, null, 9, 26.0, 0.0 },
                    { 47, false, 2, null, 8, 27.0, 0.0 },
                    { 46, false, 2, null, 7, 28.0, 0.0 },
                    { 45, false, 2, null, 6, 28.0, 0.0 },
                    { 44, false, 2, null, 20, 28.0, 0.0 },
                    { 43, false, 2, null, 3, 27.0, 0.0 },
                    { 50, false, 2, null, 11, 19.989999999999998, 0.0 },
                    { 60, false, 2, null, 18, 13.0, 0.0 },
                    { 61, false, 2, null, 140, 25.0, 0.0 },
                    { 62, false, 2, null, 144, 23.0, 0.0 },
                    { 79, false, 2, null, 131, 6.0, 0.0 },
                    { 78, false, 2, null, 130, 6.0, 0.0 },
                    { 77, false, 2, null, 129, 6.0, 0.0 },
                    { 76, false, 2, null, 128, 6.0, 0.0 },
                    { 75, false, 2, null, 127, 6.0, 0.0 },
                    { 74, false, 2, null, 126, 6.0, 0.0 },
                    { 73, false, 2, null, 125, 6.0, 0.0 },
                    { 72, false, 2, null, 35, 3.5, 0.0 },
                    { 71, false, 2, null, 34, 4.0, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "ProdutoEstabelecimento",
                columns: new[] { "Id", "Ativo", "EstabelecimentoId", "Observacao", "ProdutoId", "Valor", "ValorPromocional" },
                values: new object[,]
                {
                    { 70, false, 2, null, 124, 6.0, 0.0 },
                    { 69, false, 2, null, 44, 6.5, 0.0 },
                    { 68, false, 2, null, 173, 16.899999999999999, 0.0 },
                    { 67, false, 2, null, 171, 13.0, 0.0 },
                    { 66, false, 2, null, 159, 20.0, 0.0 },
                    { 65, false, 2, null, 142, 19.0, 0.0 },
                    { 64, false, 2, null, 170, 25.0, 0.0 },
                    { 63, false, 2, null, 156, 33.0, 0.0 },
                    { 42, false, 2, null, 19, 23.0, 0.0 },
                    { 41, false, 2, null, 1, 26.0, 0.0 },
                    { 40, false, 1, null, 44, 7.0, 0.0 },
                    { 39, false, 1, null, 43, 5.5, 0.0 },
                    { 17, false, 1, null, 17, 32.0, 0.0 },
                    { 16, false, 1, null, 16, 28.0, 0.0 },
                    { 15, false, 1, null, 15, 33.0, 0.0 },
                    { 14, false, 1, null, 14, 28.0, 0.0 },
                    { 13, false, 1, null, 13, 20.0, 0.0 },
                    { 12, false, 1, null, 12, 21.989999999999998, 0.0 },
                    { 11, false, 1, null, 11, 21.989999999999998, 0.0 },
                    { 10, false, 1, null, 10, 26.0, 0.0 },
                    { 9, false, 1, null, 9, 30.0, 0.0 },
                    { 8, false, 1, null, 8, 28.0, 0.0 },
                    { 7, false, 1, null, 7, 30.0, 0.0 },
                    { 6, false, 1, null, 6, 33.0, 0.0 },
                    { 5, false, 1, null, 5, 31.0, 0.0 },
                    { 4, false, 1, null, 4, 25.0, 0.0 },
                    { 3, false, 1, null, 3, 28.0, 0.0 },
                    { 2, false, 1, null, 2, 26.0, 0.0 },
                    { 1, false, 1, null, 1, 28.0, 0.0 },
                    { 18, false, 1, null, 18, 14.0, 0.0 },
                    { 80, false, 2, null, 132, 6.0, 0.0 },
                    { 19, false, 1, null, 140, 24.0, 0.0 },
                    { 21, false, 1, null, 142, 18.0, 0.0 },
                    { 38, false, 1, null, 42, 5.5, 0.0 },
                    { 37, false, 1, null, 41, 5.5, 0.0 },
                    { 36, false, 1, null, 40, 5.5, 0.0 },
                    { 35, false, 1, null, 39, 5.5, 0.0 },
                    { 34, false, 1, null, 38, 5.5, 0.0 },
                    { 33, false, 1, null, 37, 18.0, 0.0 },
                    { 32, false, 1, null, 36, 12.0, 0.0 },
                    { 31, false, 1, null, 35, 3.0, 0.0 },
                    { 30, false, 1, null, 34, 3.5, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "ProdutoEstabelecimento",
                columns: new[] { "Id", "Ativo", "EstabelecimentoId", "Observacao", "ProdutoId", "Valor", "ValorPromocional" },
                values: new object[,]
                {
                    { 29, false, 1, null, 33, 8.0, 0.0 },
                    { 28, false, 1, null, 32, 9.5, 0.0 },
                    { 27, false, 1, null, 31, 8.0, 0.0 },
                    { 26, false, 1, null, 30, 9.5, 0.0 },
                    { 25, false, 1, null, 171, 13.0, 0.0 },
                    { 24, false, 1, null, 145, 22.0, 0.0 },
                    { 23, false, 1, null, 144, 22.0, 0.0 },
                    { 22, false, 1, null, 143, 20.0, 0.0 },
                    { 20, false, 1, null, 141, 31.989999999999998, 0.0 },
                    { 81, false, 2, null, 133, 6.0, 0.0 },
                    { 82, false, 2, null, 134, 13.0, 0.0 },
                    { 83, false, 2, null, 135, 19.0, 0.0 },
                    { 142, false, 4, null, 6, 32.0, 0.0 },
                    { 141, false, 4, null, 20, 32.0, 0.0 },
                    { 140, false, 4, null, 24, 31.0, 0.0 },
                    { 139, false, 4, null, 3, 30.0, 0.0 },
                    { 138, false, 4, null, 19, 27.0, 0.0 },
                    { 137, false, 4, null, 1, 30.0, 0.0 },
                    { 136, false, 3, null, 110, 4.0, 0.0 },
                    { 135, false, 3, null, 111, 3.5, 0.0 },
                    { 134, false, 3, null, 109, 5.0, 0.0 },
                    { 133, false, 3, null, 108, 6.5, 0.0 },
                    { 132, false, 3, null, 123, 5.0, 0.0 },
                    { 131, false, 3, null, 122, 5.0, 0.0 },
                    { 130, false, 3, null, 121, 5.0, 0.0 },
                    { 129, false, 3, null, 120, 5.0, 0.0 },
                    { 128, false, 3, null, 119, 5.0, 0.0 },
                    { 127, false, 3, null, 118, 5.0, 0.0 },
                    { 126, false, 3, null, 117, 5.0, 0.0 },
                    { 143, false, 4, null, 7, 31.0, 0.0 },
                    { 125, false, 3, null, 116, 5.0, 0.0 },
                    { 144, false, 4, null, 8, 30.0, 0.0 },
                    { 146, false, 4, null, 10, 29.0, 0.0 },
                    { 163, false, 4, null, 158, 25.0, 0.0 },
                    { 162, false, 4, null, 144, 24.0, 0.0 },
                    { 161, false, 4, null, 157, 22.0, 0.0 },
                    { 160, false, 4, null, 156, 32.0, 0.0 },
                    { 159, false, 4, null, 155, 23.0, 0.0 },
                    { 158, false, 4, null, 140, 28.0, 0.0 },
                    { 157, false, 4, null, 18, 14.0, 0.0 },
                    { 156, false, 4, null, 17, 33.0, 0.0 },
                    { 155, false, 4, null, 16, 29.0, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "ProdutoEstabelecimento",
                columns: new[] { "Id", "Ativo", "EstabelecimentoId", "Observacao", "ProdutoId", "Valor", "ValorPromocional" },
                values: new object[,]
                {
                    { 154, false, 4, null, 4, 28.0, 0.0 },
                    { 153, false, 4, null, 15, 34.0, 0.0 },
                    { 152, false, 4, null, 14, 29.0, 0.0 },
                    { 151, false, 4, null, 13, 22.0, 0.0 },
                    { 150, false, 4, null, 12, 23.989999999999998, 0.0 },
                    { 149, false, 4, null, 26, 23.989999999999998, 0.0 },
                    { 148, false, 4, null, 25, 23.989999999999998, 0.0 },
                    { 147, false, 4, null, 11, 23.989999999999998, 0.0 },
                    { 145, false, 4, null, 9, 30.0, 0.0 },
                    { 165, false, 4, null, 159, 20.0, 0.0 },
                    { 124, false, 3, null, 171, 14.0, 0.0 },
                    { 122, false, 3, null, 175, 15.0, 0.0 },
                    { 100, false, 3, null, 4, 25.0, 0.0 },
                    { 99, false, 3, null, 25, 19.989999999999998, 0.0 },
                    { 98, false, 3, null, 11, 19.989999999999998, 0.0 },
                    { 97, false, 3, null, 10, 25.0, 0.0 },
                    { 96, false, 3, null, 9, 27.0, 0.0 },
                    { 95, false, 3, null, 8, 27.0, 0.0 },
                    { 94, false, 3, null, 7, 27.0, 0.0 },
                    { 93, false, 3, null, 6, 28.0, 0.0 },
                    { 92, false, 3, null, 20, 27.0, 0.0 },
                    { 91, false, 3, null, 29, 29.0, 0.0 },
                    { 90, false, 3, null, 3, 27.0, 0.0 },
                    { 89, false, 3, null, 19, 24.0, 0.0 },
                    { 88, false, 3, null, 1, 26.0, 0.0 },
                    { 87, false, 2, null, 139, 9.0, 0.0 },
                    { 86, false, 2, null, 138, 8.0, 0.0 },
                    { 85, false, 2, null, 137, 8.0, 0.0 },
                    { 84, false, 2, null, 136, 10.0, 0.0 },
                    { 101, false, 3, null, 26, 19.989999999999998, 0.0 },
                    { 123, false, 3, null, 176, 15.0, 0.0 },
                    { 102, false, 3, null, 12, 19.989999999999998, 0.0 },
                    { 104, false, 3, null, 13, 19.0, 0.0 },
                    { 322, false, 6, null, 82, 16.899999999999999, 0.0 },
                    { 120, false, 3, null, 168, 16.0, 0.0 },
                    { 119, false, 3, null, 159, 16.0, 0.0 },
                    { 118, false, 3, null, 142, 19.0, 0.0 },
                    { 117, false, 3, null, 167, 22.0, 0.0 },
                    { 116, false, 3, null, 156, 32.0, 0.0 },
                    { 115, false, 3, null, 166, 16.989999999999998, 0.0 },
                    { 114, false, 3, null, 155, 22.0, 0.0 },
                    { 113, false, 3, null, 144, 23.0, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "ProdutoEstabelecimento",
                columns: new[] { "Id", "Ativo", "EstabelecimentoId", "Observacao", "ProdutoId", "Valor", "ValorPromocional" },
                values: new object[,]
                {
                    { 112, false, 3, null, 165, 16.989999999999998, 0.0 },
                    { 111, false, 3, null, 164, 23.0, 0.0 },
                    { 110, false, 3, null, 140, 26.0, 0.0 },
                    { 109, false, 3, null, 18, 13.0, 0.0 },
                    { 108, false, 3, null, 17, 30.0, 0.0 },
                    { 107, false, 3, null, 16, 26.0, 0.0 },
                    { 106, false, 3, null, 15, 30.0, 0.0 },
                    { 105, false, 3, null, 14, 27.0, 0.0 },
                    { 103, false, 3, null, 22, 19.989999999999998, 0.0 },
                    { 323, false, 6, null, 83, 18.899999999999999, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Adicional",
                columns: new[] { "Id", "CategoriaAdicionalId", "IngredienteId", "Valor" },
                values: new object[,]
                {
                    { 87, 2, 38, 5.0 },
                    { 121, 2, 47, 6.0 },
                    { 96, 2, 47, 7.0 },
                    { 66, 2, 47, 7.0 },
                    { 34, 2, 47, 6.0 },
                    { 11, 2, 47, 9.0 },
                    { 149, 2, 46, 4.0 },
                    { 120, 2, 46, 3.0 },
                    { 95, 2, 46, 4.0 },
                    { 65, 2, 46, 3.0 },
                    { 33, 2, 46, 3.0 },
                    { 10, 2, 46, 3.0 },
                    { 148, 2, 45, 4.0 },
                    { 119, 2, 45, 4.0 },
                    { 94, 2, 45, 4.5 },
                    { 64, 2, 45, 4.0 },
                    { 150, 2, 47, 8.0 },
                    { 12, 2, 48, 4.0 },
                    { 36, 2, 48, 4.0 },
                    { 67, 2, 48, 4.0 },
                    { 15, 2, 51, 3.5 },
                    { 154, 2, 50, 3.0 },
                    { 124, 2, 50, 2.5 },
                    { 99, 2, 50, 3.0 },
                    { 69, 2, 50, 3.5 },
                    { 38, 2, 50, 2.5 },
                    { 14, 2, 50, 2.5 },
                    { 32, 2, 45, 4.0 },
                    { 153, 2, 49, 6.0 },
                    { 98, 2, 49, 6.0 },
                    { 68, 2, 49, 5.5 },
                    { 37, 2, 49, 6.0 },
                    { 13, 2, 49, 6.0 },
                    { 152, 2, 48, 4.0 },
                    { 122, 2, 48, 4.0 },
                    { 97, 2, 48, 4.0 },
                    { 123, 2, 49, 6.0 },
                    { 9, 2, 45, 4.0 },
                    { 146, 2, 44, 3.0 },
                    { 116, 2, 44, 3.0 },
                    { 28, 2, 41, 5.0 },
                    { 5, 2, 41, 5.0 }
                });

            migrationBuilder.InsertData(
                table: "Adicional",
                columns: new[] { "Id", "CategoriaAdicionalId", "IngredienteId", "Valor" },
                values: new object[,]
                {
                    { 142, 2, 40, 2.0 },
                    { 112, 2, 40, 2.0 },
                    { 89, 2, 40, 1.0 },
                    { 53, 2, 40, 2.0 },
                    { 27, 2, 40, 2.0 },
                    { 54, 2, 41, 5.0 },
                    { 4, 2, 40, 2.0 },
                    { 111, 2, 39, 3.5 },
                    { 88, 2, 39, 3.5 },
                    { 51, 2, 39, 3.5 },
                    { 26, 2, 39, 3.5 },
                    { 3, 2, 39, 3.5 },
                    { 139, 2, 38, 5.0 },
                    { 110, 2, 38, 4.5 },
                    { 140, 2, 39, 4.0 },
                    { 39, 2, 51, 3.5 },
                    { 90, 2, 41, 5.0 },
                    { 143, 2, 41, 5.0 },
                    { 93, 2, 44, 3.5 },
                    { 59, 2, 44, 3.0 },
                    { 31, 2, 44, 3.0 },
                    { 8, 2, 44, 3.0 },
                    { 145, 2, 43, 3.0 },
                    { 115, 2, 43, 3.0 },
                    { 92, 2, 43, 3.5 },
                    { 113, 2, 41, 5.0 },
                    { 58, 2, 43, 3.0 },
                    { 7, 2, 43, 3.0 },
                    { 144, 2, 42, 4.0 },
                    { 114, 2, 42, 3.5 },
                    { 91, 2, 42, 3.5 },
                    { 57, 2, 42, 3.5 },
                    { 29, 2, 42, 3.5 },
                    { 6, 2, 42, 3.5 },
                    { 30, 2, 43, 3.0 },
                    { 77, 2, 78, 4.0 },
                    { 74, 2, 51, 3.5 },
                    { 158, 2, 51, 3.5 },
                    { 147, 2, 64, 2.0 },
                    { 141, 2, 63, 4.0 },
                    { 52, 2, 63, 4.0 },
                    { 138, 2, 62, 7.0 }
                });

            migrationBuilder.InsertData(
                table: "Adicional",
                columns: new[] { "Id", "CategoriaAdicionalId", "IngredienteId", "Valor" },
                values: new object[,]
                {
                    { 137, 2, 61, 11.0 },
                    { 49, 2, 61, 11.0 },
                    { 136, 2, 60, 7.0 },
                    { 167, 1, 59, 3.0 },
                    { 134, 1, 59, 3.5 },
                    { 108, 1, 59, 3.0 },
                    { 85, 1, 59, 3.5 },
                    { 47, 1, 59, 3.0 },
                    { 23, 1, 59, 3.0 },
                    { 166, 1, 58, 3.0 },
                    { 133, 1, 58, 3.0 },
                    { 35, 2, 65, 8.0 },
                    { 76, 2, 65, 7.0 },
                    { 127, 2, 65, 8.0 },
                    { 151, 2, 65, 9.0 },
                    { 72, 2, 77, 3.0 },
                    { 70, 2, 76, 3.0 },
                    { 63, 2, 75, 5.0 },
                    { 56, 2, 74, 2.5 },
                    { 55, 2, 73, 4.5 },
                    { 118, 2, 71, 3.5 },
                    { 61, 2, 71, 3.5 },
                    { 107, 1, 58, 3.0 },
                    { 117, 2, 70, 3.5 },
                    { 160, 2, 69, 3.0 },
                    { 62, 2, 69, 4.5 },
                    { 157, 2, 68, 3.0 },
                    { 156, 2, 67, 5.0 },
                    { 73, 2, 67, 5.0 },
                    { 155, 2, 66, 3.0 },
                    { 71, 2, 66, 3.0 },
                    { 60, 2, 70, 3.5 },
                    { 84, 1, 58, 3.0 },
                    { 46, 1, 58, 3.0 },
                    { 22, 1, 58, 3.0 },
                    { 103, 1, 54, 7.0 },
                    { 80, 1, 54, 6.0 },
                    { 42, 1, 54, 7.0 },
                    { 18, 1, 54, 7.0 },
                    { 161, 1, 53, 6.0 },
                    { 128, 1, 53, 4.5 },
                    { 102, 1, 53, 6.0 }
                });

            migrationBuilder.InsertData(
                table: "Adicional",
                columns: new[] { "Id", "CategoriaAdicionalId", "IngredienteId", "Valor" },
                values: new object[,]
                {
                    { 129, 1, 54, 6.0 },
                    { 79, 1, 53, 4.5 },
                    { 17, 1, 53, 6.0 },
                    { 159, 2, 52, 2.0 },
                    { 126, 2, 52, 2.5 },
                    { 101, 2, 52, 3.5 },
                    { 75, 2, 52, 2.5 },
                    { 40, 2, 52, 2.5 },
                    { 16, 2, 52, 2.5 },
                    { 41, 1, 53, 6.0 },
                    { 100, 2, 51, 3.5 },
                    { 162, 1, 54, 7.0 },
                    { 43, 1, 55, 5.0 },
                    { 165, 1, 57, 3.0 },
                    { 132, 1, 57, 3.5 },
                    { 106, 1, 57, 3.0 },
                    { 83, 1, 57, 3.5 },
                    { 45, 1, 57, 3.0 },
                    { 21, 1, 57, 3.0 },
                    { 164, 1, 56, 3.0 },
                    { 19, 1, 55, 5.0 },
                    { 131, 1, 56, 3.0 },
                    { 82, 1, 56, 3.0 },
                    { 44, 1, 56, 3.0 },
                    { 20, 1, 56, 3.0 },
                    { 163, 1, 55, 5.0 },
                    { 130, 1, 55, 5.0 },
                    { 104, 1, 55, 5.0 },
                    { 81, 1, 55, 5.0 },
                    { 105, 1, 56, 3.0 },
                    { 50, 2, 38, 4.5 },
                    { 78, 2, 79, 4.0 },
                    { 2, 2, 38, 4.5 },
                    { 135, 2, 37, 10.0 },
                    { 109, 2, 37, 10.0 },
                    { 86, 2, 37, 11.0 },
                    { 48, 2, 37, 10.0 },
                    { 24, 2, 37, 10.0 },
                    { 1, 2, 37, 11.0 },
                    { 25, 2, 38, 4.5 }
                });

            migrationBuilder.InsertData(
                table: "ProdutoIngrediente",
                columns: new[] { "Id", "IngredienteId", "ProdutoId", "Quantidade" },
                values: new object[,]
                {
                    { 113, 7, 24, 1.0 },
                    { 98, 7, 21, 1.0 }
                });

            migrationBuilder.InsertData(
                table: "ProdutoIngrediente",
                columns: new[] { "Id", "IngredienteId", "ProdutoId", "Quantidade" },
                values: new object[,]
                {
                    { 89, 7, 19, 1.0 },
                    { 75, 7, 16, 1.0 },
                    { 67, 7, 15, 1.0 },
                    { 61, 7, 14, 1.0 },
                    { 44, 7, 9, 1.0 },
                    { 148, 6, 146, 1.0 },
                    { 8, 7, 2, 1.0 },
                    { 151, 6, 156, 1.0 },
                    { 135, 7, 29, 1.0 },
                    { 142, 6, 141, 1.0 },
                    { 141, 6, 140, 1.0 },
                    { 126, 6, 27, 1.0 },
                    { 88, 6, 19, 1.0 },
                    { 37, 7, 8, 1.0 },
                    { 143, 7, 141, 1.0 },
                    { 9, 8, 2, 1.0 },
                    { 149, 7, 146, 1.0 },
                    { 14, 12, 3, 1.0 },
                    { 108, 11, 23, 1.0 },
                    { 92, 11, 20, 1.0 },
                    { 68, 11, 15, 1.0 },
                    { 30, 11, 7, 1.0 },
                    { 22, 11, 5, 1.0 },
                    { 13, 11, 3, 1.0 },
                    { 121, 10, 26, 1.0 },
                    { 76, 10, 16, 1.0 },
                    { 52, 10, 11, 1.0 },
                    { 12, 10, 3, 1.0 },
                    { 11, 9, 3, 1.0 },
                    { 90, 8, 19, 1.0 },
                    { 74, 6, 16, 1.0 },
                    { 152, 7, 156, 1.0 },
                    { 146, 7, 143, 1.0 },
                    { 66, 6, 15, 1.0 },
                    { 7, 6, 2, 1.0 },
                    { 43, 6, 9, 1.0 },
                    { 26, 4, 6, 1.0 },
                    { 21, 4, 5, 1.0 },
                    { 15, 4, 4, 1.0 },
                    { 10, 4, 3, 1.0 },
                    { 4, 4, 1, 1.0 },
                    { 133, 3, 29, 1.0 }
                });

            migrationBuilder.InsertData(
                table: "ProdutoIngrediente",
                columns: new[] { "Id", "IngredienteId", "ProdutoId", "Quantidade" },
                values: new object[,]
                {
                    { 124, 3, 27, 1.0 },
                    { 111, 3, 24, 1.0 },
                    { 96, 3, 21, 1.0 },
                    { 78, 3, 17, 1.0 },
                    { 59, 3, 14, 1.0 },
                    { 41, 3, 9, 1.0 },
                    { 35, 3, 8, 1.0 },
                    { 3, 3, 1, 1.0 },
                    { 2, 2, 1, 1.0 },
                    { 29, 4, 7, 1.0 },
                    { 36, 4, 8, 1.0 },
                    { 42, 4, 9, 1.0 },
                    { 47, 4, 10, 1.0 },
                    { 16, 12, 4, 1.0 },
                    { 5, 6, 1, 1.0 },
                    { 87, 5, 19, 1.0 },
                    { 6, 5, 2, 1.0 },
                    { 134, 4, 29, 1.0 },
                    { 125, 4, 27, 1.0 },
                    { 119, 4, 25, 1.0 },
                    { 51, 6, 11, 1.0 },
                    { 112, 4, 24, 1.0 },
                    { 104, 4, 22, 1.0 },
                    { 97, 4, 21, 1.0 },
                    { 91, 4, 20, 1.0 },
                    { 79, 4, 17, 1.0 },
                    { 65, 4, 15, 1.0 },
                    { 60, 4, 14, 1.0 },
                    { 56, 4, 12, 1.0 },
                    { 107, 4, 23, 1.0 },
                    { 23, 12, 5, 1.0 },
                    { 62, 12, 14, 1.0 },
                    { 48, 12, 10, 1.0 },
                    { 46, 23, 9, 1.0 },
                    { 153, 22, 156, 1.0 },
                    { 144, 22, 141, 1.0 },
                    { 138, 22, 29, 1.0 },
                    { 116, 22, 24, 1.0 },
                    { 101, 22, 21, 1.0 },
                    { 64, 22, 14, 1.0 },
                    { 45, 22, 9, 1.0 },
                    { 40, 22, 8, 1.0 }
                });

            migrationBuilder.InsertData(
                table: "ProdutoIngrediente",
                columns: new[] { "Id", "IngredienteId", "ProdutoId", "Quantidade" },
                values: new object[,]
                {
                    { 34, 21, 7, 1.0 },
                    { 33, 20, 7, 1.0 },
                    { 32, 19, 7, 1.0 },
                    { 150, 18, 146, 1.0 },
                    { 31, 18, 7, 1.0 },
                    { 28, 17, 6, 1.0 },
                    { 50, 24, 10, 1.0 },
                    { 55, 25, 11, 1.0 },
                    { 131, 25, 27, 1.0 },
                    { 58, 26, 12, 1.0 },
                    { 123, 36, 26, 1.0 },
                    { 140, 35, 29, 1.0 },
                    { 118, 35, 24, 1.0 },
                    { 103, 35, 21, 1.0 },
                    { 106, 34, 22, 1.0 },
                    { 86, 34, 17, 1.0 },
                    { 20, 34, 4, 1.0 },
                    { 94, 16, 20, 1.0 },
                    { 139, 33, 29, 1.0 },
                    { 102, 33, 21, 1.0 },
                    { 85, 32, 17, 1.0 },
                    { 84, 31, 17, 1.0 },
                    { 83, 30, 17, 1.0 },
                    { 77, 29, 16, 1.0 },
                    { 73, 28, 15, 1.0 },
                    { 72, 27, 15, 1.0 },
                    { 117, 33, 24, 1.0 },
                    { 38, 12, 8, 1.0 },
                    { 24, 16, 5, 1.0 },
                    { 105, 15, 22, 1.0 },
                    { 81, 13, 17, 1.0 },
                    { 70, 13, 15, 1.0 },
                    { 17, 13, 4, 1.0 },
                    { 147, 12, 144, 1.0 },
                    { 145, 12, 142, 1.0 },
                    { 136, 12, 29, 1.0 },
                    { 127, 12, 27, 1.0 },
                    { 122, 12, 26, 1.0 },
                    { 114, 12, 24, 1.0 },
                    { 109, 12, 23, 1.0 },
                    { 99, 12, 21, 1.0 },
                    { 93, 12, 20, 1.0 }
                });

            migrationBuilder.InsertData(
                table: "ProdutoIngrediente",
                columns: new[] { "Id", "IngredienteId", "ProdutoId", "Quantidade" },
                values: new object[,]
                {
                    { 80, 12, 17, 1.0 },
                    { 69, 12, 15, 1.0 },
                    { 53, 12, 11, 1.0 },
                    { 128, 13, 27, 1.0 },
                    { 18, 14, 4, 1.0 },
                    { 27, 14, 6, 1.0 },
                    { 39, 14, 8, 1.0 },
                    { 25, 45, 5, 1.0 },
                    { 95, 45, 20, 1.0 },
                    { 132, 45, 27, 1.0 },
                    { 82, 15, 17, 1.0 },
                    { 54, 15, 11, 1.0 },
                    { 19, 15, 4, 1.0 },
                    { 137, 14, 29, 1.0 },
                    { 130, 15, 27, 1.0 },
                    { 129, 14, 27, 1.0 },
                    { 115, 14, 24, 1.0 },
                    { 110, 14, 23, 1.0 },
                    { 100, 14, 21, 1.0 },
                    { 71, 14, 15, 1.0 },
                    { 63, 14, 14, 1.0 },
                    { 57, 14, 12, 1.0 },
                    { 49, 14, 10, 1.0 },
                    { 120, 14, 25, 1.0 },
                    { 1, 1, 1, 1.0 }
                });

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
