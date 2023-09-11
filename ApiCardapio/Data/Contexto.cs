using ApiCardapio.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ApiCardapio.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<AdicionalModel> Adicionais { get; set; }
        public DbSet<CategoriaAdicionalModel> CategoriaAdicionais { get; set; }
        public DbSet<CategoriaEstabelecimentoModel> CategoriaEstabelecimento { get; set; }
        public DbSet<CategoriaProdutoModel> CategoriaProdutos { get; set; }
        public DbSet<DiaHorasFuncionamentoModel> DiasHorasFuncionamento { get; set; }
        public DbSet<EstabelecimentoModel> Estabelecimentos { get; set; }
        public DbSet<IngredienteModel> Ingredientes { get; set; }
        public DbSet<PagamentoModel> Pagamentos { get; set; }
        public DbSet<PedidoIngredienteModel> PedidosIngredientes { get; set; }
        public DbSet<PedidoModel> Pedidos { get; set; }
        public DbSet<PerfilUsuarioModel> PerfilUsuario { get; set; }
        public DbSet<PerfilModel> Perfis { get; set; }
        public DbSet<PontoCarneModel> PontosCarne { get; set; }
        public DbSet<ProdutoEstabelecimentoModel> ProdutoEstabelecimentos { get; set; }
        public DbSet<ProdutoIngredienteModel> ProdutoIngredientes { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<ProdutoPedidoModel> ProdutosPedidos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<UsuarioEstabelecimentoModel> UsuarioEstabelecimento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region CategoriaProduto
            modelBuilder.Entity<CategoriaProdutoModel>().HasData(
            new CategoriaProdutoModel()
            {
                Id = 1,
                NomeCategoriaProduto = "Hambúrgueres",
                CategoryName = null,
                ExibirCardapio = true,
                CategoriaAdicionalId = 2,
                ImagemFiltro = "/assets/imagens/iconesCategoriaProduto/Hambúrgueres.svg",
            },
            new CategoriaProdutoModel()
            {
                Id = 2,
                NomeCategoriaProduto = "Bebidas",
                CategoryName = null,
                ExibirCardapio = true,
                CategoriaAdicionalId = null,
                ImagemFiltro = "/assets/imagens/iconesCategoriaProduto/Bebidas.svg",
            },
            new CategoriaProdutoModel()
            {
                Id = 3,
                NomeCategoriaProduto = "Entradas e Porções",
                CategoryName = null,
                ExibirCardapio = true,
                CategoriaAdicionalId = 1,
                ImagemFiltro = "/assets/imagens/iconesCategoriaProduto/Entradas e Porções.svg",
            },
            new CategoriaProdutoModel()
            {
                Id = 4,
                NomeCategoriaProduto = "Sobremesas",
                CategoryName = null,
                ExibirCardapio = true,
                CategoriaAdicionalId = null,
                ImagemFiltro = "/assets/imagens/iconesCategoriaProduto/Sobremesas.svg",
            });
            #endregion CategoriaProduto

            #region CategoriaAdicional
            modelBuilder.Entity<CategoriaAdicionalModel>().HasData(
            new CategoriaAdicionalModel()
            {
                Id = 1,
                NomeCategoriaAdicional = "Adicional Porções",
                AdditionalCategoryName = null,
            },
            new CategoriaAdicionalModel()
            {
                Id = 2,
                NomeCategoriaAdicional = "Adicional Hamburguers",
                AdditionalCategoryName = null,
            });
            #endregion CategoriaAdicional

            #region Categoria Estabelecimento
            modelBuilder.Entity<CategoriaEstabelecimentoModel>().HasData(
            new CategoriaEstabelecimentoModel()
            {
                Id = 1,
                Icone = "/assets/imagens/iconesCategoriaProduto/Hambúrgueres.svg",
                Nome = "Hamburgueria",
            });
            #endregion CategoriaEstabelecimentoModel

            #region Estabelecimento
            modelBuilder.Entity<EstabelecimentoModel>().HasData(

            new EstabelecimentoModel()
            {
                Id = 1,
                UF = "SP",
                Cidade = "Barra Bonita",
                Endereco = "Av. Caio Simões, 306 - Vila Sao Jose",
                Telefone = "(14) 99606-1938",
                Logo = "",
                LinkCardapio = "Barra-Bonita",
                Nome = "Brasa",
                CategoriaEstabelecimentoId = 1,
                ImagemCapa = ""
            },
            new EstabelecimentoModel()
            {
                Id = 2,
                UF = "SP",
                Cidade = "Pederneiras",
                Endereco = "Av. Brasil, 410 - Jd Bandeirantes",
                Telefone = "(14) 99667-3737",
                Logo = "",
                LinkCardapio = "Pederneiras",
                Nome = "Brasa",
                CategoriaEstabelecimentoId = 1,
                ImagemCapa = ""
            },
            new EstabelecimentoModel()
            {
                Id = 3,
                UF = "SP",
                Cidade = "Lençóis Paulista",
                Endereco = "Av. Nove de Julho, 791 - Centro",
                Telefone = "(14) 99691-0647",
                Logo = "",
                LinkCardapio = "Lencois-Paulista",
                Nome = "Brasa",
                CategoriaEstabelecimentoId = 1,
                ImagemCapa = ""
            },
            new EstabelecimentoModel()
            {
                Id = 4,
                UF = "SP",
                Cidade = "Botucatu",
                Endereco = "Av. Leonardo Vilas Boas, 641 - Vila Nova Botucatu",
                Telefone = "(14) 99673-6679",
                Logo = "",
                LinkCardapio = "Botucatu",
                Nome = "Brasa",
                CategoriaEstabelecimentoId = 1,
                ImagemCapa = ""
            },
            new EstabelecimentoModel()
            {
                Id = 5,
                UF = "SP",
                Cidade = "Jaú",
                Endereco = "R. Cônego Anselmo Valvekens, 48 - Centro",
                Telefone = "99815-0116",
                Logo = "",
                LinkCardapio = "Jau",
                Nome = "Brasa",
                CategoriaEstabelecimentoId = 1,
                ImagemCapa = ""

            }, new EstabelecimentoModel()
            {
                Id = 6,
                UF = "SP",
                Endereco = "R. Luís Bleriot, 8-33 - Vila Aviação",
                Cidade = "Bauru",
                Telefone = "(14) 99720-0798",
                Logo = "",
                LinkCardapio = "Bauru",
                Nome = "Brasa",
                CategoriaEstabelecimentoId = 1,
                ImagemCapa = ""
            });

            #endregion Estabelecimento

            #region Ponto carne
            modelBuilder.Entity<PontoCarneModel>().HasData(

            new PontoCarneModel()
            {
                Id = 1,
                NomePontoCarne = "Mal passada"
            },
            new PontoCarneModel()
            {
                Id = 2,
                NomePontoCarne = "Ao ponto"
            },
            new PontoCarneModel()
            {
                Id = 3,
                NomePontoCarne = "Bem passada"
            }
            );
            #endregion Ponto carne

            #region Ingrediente
            modelBuilder.Entity<IngredienteModel>().HasData(
            new IngredienteModel()
            {
                Id = 1,
                NomeIngrediente = "creme cheddar",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 2,
                NomeIngrediente = "farofinha de bacon",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 3,
                NomeIngrediente = "alface",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 4,
                NomeIngrediente = "tomate",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 5,
                NomeIngrediente = "peito de frango",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 6,
                NomeIngrediente = "bacon",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 7,
                NomeIngrediente = "catupiry",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 8,
                NomeIngrediente = "couve crispy",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 9,
                NomeIngrediente = "molho barbecue",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 10,
                NomeIngrediente = "queijo cheddar",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 11,
                NomeIngrediente = "rúcula",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 12,
                NomeIngrediente = "cebola",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 13,
                NomeIngrediente = "cebola roxa",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 14,
                NomeIngrediente = "queijo prato",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 15,
                NomeIngrediente = "maionese",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 16,
                NomeIngrediente = "cebola chapeada",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 17,
                NomeIngrediente = "ketchup de goiaba flambado na cachaça",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 18,
                NomeIngrediente = "costela bovina",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 19,
                NomeIngrediente = "queijo minas",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 20,
                NomeIngrediente = "onion rings",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 21,
                NomeIngrediente = "molho lemon pepper com mel",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 22,
                NomeIngrediente = "catupiry original",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 23,
                NomeIngrediente = "alho fritinho",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 24,
                NomeIngrediente = "molho chipotle",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 25,
                NomeIngrediente = "maionese de bacon",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 26,
                NomeIngrediente = "picles",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 27,
                NomeIngrediente = "catupiry empanado crispy",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 28,
                NomeIngrediente = "geléia de abacaxi com pimenta",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 29,
                NomeIngrediente = "geléia de pimenta",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 30,
                NomeIngrediente = "maionese verde vegana",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 31,
                NomeIngrediente = "champignon",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 32,
                NomeIngrediente = "tofu temperado",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 33,
                NomeIngrediente = "linguiça calabresa",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 34,
                NomeIngrediente = "maionese verde",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 35,
                NomeIngrediente = "vinagrete",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 36,
                NomeIngrediente = "cebola caramelizada",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 37,
                NomeIngrediente = "hambúrguer 180g",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 38,
                NomeIngrediente = "creme cheddar",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 39,
                NomeIngrediente = "maionese verde",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 40,
                NomeIngrediente = "salada ou cebola roxa",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 41,
                NomeIngrediente = "catupiry original",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 42,
                NomeIngrediente = "geléia de pimenta",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 43,
                NomeIngrediente = "queijo prato (2 fatias)",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 44,
                NomeIngrediente = "queijo cheddar (2fatias)",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 45,
                NomeIngrediente = "bacon",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 46,
                NomeIngrediente = "anel de cebola (4)",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 47,
                NomeIngrediente = "provolone crispy",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 48,
                NomeIngrediente = "ketchup de goiabada",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 49,
                NomeIngrediente = "creme gorgonzola",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 50,
                NomeIngrediente = "molho barbecue",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 51,
                NomeIngrediente = "picles",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 52,
                NomeIngrediente = "ovo",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 53,
                NomeIngrediente = "creme cheddar",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 54,
                NomeIngrediente = "creme de gorgonzola",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 55,
                NomeIngrediente = "catupiry original",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 56,
                NomeIngrediente = "queijo prato (fatia)",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 57,
                NomeIngrediente = "maionese verde",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 58,
                NomeIngrediente = "cheddar (fatia)",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 59,
                NomeIngrediente = "geléia de pimenta",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 60,
                NomeIngrediente = "hambúrguer 100g",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 61,
                NomeIngrediente = "hambúrguer costela 200g",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 62,
                NomeIngrediente = "hambúrguer frango",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 63,
                NomeIngrediente = "maionese bacon",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 64,
                NomeIngrediente = "alho frito",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 65,
                NomeIngrediente = "catupiry crispy",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 66,
                NomeIngrediente = "molho rosé",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 67,
                NomeIngrediente = "batata extra",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 68,
                NomeIngrediente = "nachos",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 69,
                NomeIngrediente = "farofa de bacon",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 70,
                NomeIngrediente = "geléia de abacaxi",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 71,
                NomeIngrediente = "maionese de bacon",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 72,
                NomeIngrediente = "picles - 3,50",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 73,
                NomeIngrediente = "geléia de abacaxi c/ pimenta",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 74,
                NomeIngrediente = "cebola caramelizada",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 75,
                NomeIngrediente = "batata rústica",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 76,
                NomeIngrediente = "nachos (doritos)",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 77,
                NomeIngrediente = "molho tasty",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 78,
                NomeIngrediente = "anéis de cebola",
                NameIngredient = null,
                EstabelecimentoId = 1,
            },
            new IngredienteModel()
            {
                Id = 79,
                NomeIngrediente = "queijo minas padrão",
                NameIngredient = null,
                EstabelecimentoId = 1,
            });
            #endregion Ingrediente

            #region Produto
            modelBuilder.Entity<ProdutoModel>().HasData(
            new ProdutoModel()
            {
                Id = 1,
                ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/8f7e76090120440bb61f4d5fb0107f3a.png",
                NomeProduto = "brasão",
                DescricaoProduto = "o melhor hambúrguer, com 200g de pura delícia, creme cheddar artesanal feito com muito amor e carinho, uma farofinha de bacon totalmente especial e aquela alface e tomate fresquinhos",
                ProductDescription = null,
                CategoriaProdutoId = 1
            },
            new ProdutoModel()
            {
                Id = 2,
                ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/4af6e2ea8a4247bf87db51211e1bcf96.png",
                NomeProduto = "brasa chicken crisp",
                DescricaoProduto = "hambúrguer de frango feito na casa, sem conservantenenhum, só com peito de frango, bacon, catupiry (original né pai?), couve crispy (fritinha, delícia!)",
                ProductDescription = null,
                CategoriaProdutoId = 1
            },
            new ProdutoModel()
            {
                Id = 3,
                ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/2673656e9d7d454c80cc52b32482085e.png",
                NomeProduto = "barbecue",
                DescricaoProduto = "hambúrguer de 180g. baaaaconnnnn, molho barbecue (o melhor da sua vida), queijo cheddar, rúcula, cebola e tomate, por que nóis é fit",
                ProductDescription = null,
                CategoriaProdutoId = 1
            },
            new ProdutoModel()
            {
                Id = 4,
                ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/472f4dd5cf3646e4b8e60ec7259fa6aa.png",
                NomeProduto = "de boa",
                DescricaoProduto = "nosso de boa que de boa só tem o nome! esse é o nosso x-salada ! alface, tomate, cebola roxa, hambúrguer de 180 gramas, queijo prato e maionese verde feita na casa.",
                ProductDescription = null,
                CategoriaProdutoId = 1
            },
            new ProdutoModel()
            {
                Id = 5,
                ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/6b676f1af13e4a1199c8905e9badc4b7.png",
                NomeProduto = "brasagorgonzola",
                DescricaoProduto = "para os amantes do melhor queijo do universo! acompanhado de rúcula, cebola chapeada e aquele tomate fresco! e claro: nosso hambúrguer de 180g e bacon!",
                ProductDescription = null,
                CategoriaProdutoId = 1
            },
            new ProdutoModel()
            {
                Id = 6,
                ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/3fcc9822405b489883223c3f218b854c.png",
                NomeProduto = "brasa provolone",
                DescricaoProduto = "esse era um dos especiais que entrou no cardápio por todo mundo a-m-a-r! alface, tomate, hambúrguer de 180 g, queijo prato, nosso ketchup de goiaba flambado na cachaça feito na casa e um belo de um pedaço de provolone empanado e frito!",
                ProductDescription = null,
                CategoriaProdutoId = 1
            },
            new ProdutoModel()
            {
                Id = 7,
                ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/56baea49fb7e49e6a354eaec36809d2d.png",
                NomeProduto = "brasa ribs",
                DescricaoProduto = "esse é o famoso hambúrguer de costela! 200 gramas de costela bovina, rúcula, tomate, queijo minas, molho lemon pepper com mel e onion rings! sensacional !",
                ProductDescription = null,
                CategoriaProdutoId = 1
            },
            new ProdutoModel()
            {
                Id = 8,
                ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/46bf73190bce4582aaf26b7312f05105.png",
                NomeProduto = "brasa futuro",
                DescricaoProduto = "feito com a revolucionária carne da fazenda do futuro, esse é pra quem é vegetariano! lembrando que nosso pão é 100% vegano. acompanha alface, tomate, cebola, queijo prato e catupiry original.",
                ProductDescription = null,
                CategoriaProdutoId = 1
            },
            new ProdutoModel()
            {
                Id = 9,
                ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/0c78640ab0174a33abdb6d64245f76b6.png",
                NomeProduto = "brasapiry",
                DescricaoProduto = "carne de 180g, alface, tomate, catupiry original, alho fritinho e muiiiiiiito bacon! esse é de comer pensando: se existe lanche perfeito, é esse!",
                ProductDescription = null,
                CategoriaProdutoId = 1
            },
            new ProdutoModel()
            {
                Id = 10,
                ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/2caaac2ec7a04f9caf082edca135bf2c.png",
                NomeProduto = "braseiro",
                DescricaoProduto = "gosta de apimentar um pouco as coisas? então essa é sua pedida! alface, tomate, cebola, hambúrguer de 180g, queijo prato, molho chipotle com especiarias e nachos! picância média - alta",
                ProductDescription = null,
                CategoriaProdutoId = 1
            },
            new ProdutoModel()
            {
                Id = 11,
                ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/9adcc0e66c204cc8ad68a1626808d9ea.png",
                NomeProduto = "combo cheddar",
                DescricaoProduto = "rúcula, cebola, queijo cheddar,hambúrguer de 150 gramas e nossa deliciosa maionese de bacon feita na casa! acompanha refri 200 ml.",
                ProductDescription = null,
                CategoriaProdutoId = 1
            },
            new ProdutoModel()
            {
                Id = 12,
                ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/53b11a4c644843dd9f20ef55bf683906.png",
                NomeProduto = "combo taste",
                DescricaoProduto = "alface, tomate, hambúrguer de 150 gramas, queijo prato , picles e aquele aquele molhinho delicia! acompanha fritas e refri de 200 ml.",
                ProductDescription = null,
                CategoriaProdutoId = 1
            },
            new ProdutoModel()
            {
                Id = 13,
                ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/9640153ac30c4d7d9d2d8cb37aa5a630.png",
                NomeProduto = "kids",
                DescricaoProduto = "o nome é kids mas esse é o nosso famoso pcq (pão, carne e queijo), ideal para você aflorar a imaginação e colocar quantos adicionais quiser! ele leva hambúrguer de 180 gramas.",
                ProductDescription = null,
                CategoriaProdutoId = 1
            },
            new ProdutoModel()
            {
                Id = 14,
                ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/7bf646da500048f4af0ac3f38ec2174c.png",
                NomeProduto = "vegetariano",
                DescricaoProduto = "nosso vegetariano com hambúrguer de soja crispy feito na casa, alface, tomate, cebola, queijo prato e catupiry original. nosso pão é 100% vegano.",
                ProductDescription = null,
                CategoriaProdutoId = 1
            },
            new ProdutoModel()
            {
                Id = 15,
                ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/e492b742fa0f490f83978dbddfdd6126.png",
                NomeProduto = "brasa califórnia",
                DescricaoProduto = "hambúrger de 180 gramas, catupiry empanado crispy, geléia de abacaxi com pimenta, bacon, queijo prato, rúcula, tomate e cebola roxa. gigante!",
                ProductDescription = null,
                CategoriaProdutoId = 1
            },
            new ProdutoModel()
            {
                Id = 16,
                ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/c8f4943997624b90b9c5a73d77a18c89.png",
                NomeProduto = "smash brasa",
                DescricaoProduto = "esse é um dos mais amados de todas as unidade do brasa! 2 hambúrguers de 100 gramas, queijo cheddar, muiiito bacon e geléia de pimenta! perfeito! ps: experimenta pedir com adicional de catupiry! fica sensacional",
                ProductDescription = null,
                CategoriaProdutoId = 1
            },
            new ProdutoModel()
            {
                Id = 17,
                ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/192fa890bf6841b5af5fbdd7e55e7bd3.png",
                NomeProduto = "brasa vegano",
                DescricaoProduto = "futuro burger 100% plantas, maionese verde vegana, alface, tomate, cebola roxa, champignon salteado no azeite e tofu temperado. 100% vegano",
                ProductDescription = null,
                CategoriaProdutoId = 1
            },
            new ProdutoModel()
            {
                Id = 18,
                ImagemProduto = "",
                NomeProduto = "brasa bowl",
                DescricaoProduto = "escolha o creme de queijo para mergulhar seu burger e fritas (cheddar, prato e gorgonzola) serve de 2 a 3 pessoas.",
                ProductDescription = null,
                CategoriaProdutoId = 1
            },
            new ProdutoModel()
            {
                Id = 19,
                ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/4af6e2ea8a4247bf87db51211e1bcf96.png",
                NomeProduto = "brasa chicken crispy",
                DescricaoProduto = "hambúrguer de frango feito na casa, sem conservante nenhum, só com peito de frango, bacon, catupiry (original né pai?), couve crispy (fritinha, delícia!)",
                ProductDescription = null,
                CategoriaProdutoId = 1
            },
            new ProdutoModel()
            {
                Id = 20,
                ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/6b676f1af13e4a1199c8905e9badc4b7.png",
                NomeProduto = "brasa gorgonzola",
                DescricaoProduto = "para os amantes do melhor queijo do universo! acompanhado de rúcula, cebola chapeada e aquele tomate fresco! e claro: nosso hambúrguer de 180g e bacon!",
                ProductDescription = null,
                CategoriaProdutoId = 1
            },
            new ProdutoModel()
            {
                Id = 21,
                ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/799aa62124fa4ec5a47d307ba7288450.png",
                NomeProduto = "especial",
                DescricaoProduto = "2 carnes de 100 gramas, queijo prato,  alface, pão de hambúrguer artesanal, catupiry original, linguiça calabresa picada bem fininha e frita e um sensacional vinagrete! (tomate + cebola + pimentão). ",
                ProductDescription = null,
                CategoriaProdutoId = 1
            },
            new ProdutoModel()
            {
                Id = 22,
                ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/22a493d5c7c34907bf2d81552a7d1425.png",
                NomeProduto = "brasa egg",
                DescricaoProduto = "alface americana, tomate fresquinho, hambúrguer, ovo fritinho e nossa maionese verde caseira! acompanha refri 200 ml e batatinha!",
                ProductDescription = null,
                CategoriaProdutoId = 1
            },
            new ProdutoModel()
            {
                Id = 23,
                ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/f664cc52fe4a4a0f92c63de34172e37e.png",
                NomeProduto = "cheese brasa",
                DescricaoProduto = "pão tipo italianinho, hambúrguer de 200g, queijo prato, muçarela crispy, geleia de pimenta, rúcula, tomate e cebola",
                ProductDescription = null,
                CategoriaProdutoId = 1
            },
            new ProdutoModel()
            {
                Id = 24,
                ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/799aa62124fa4ec5a47d307ba7288450.png",
                NomeProduto = "brasa especial",
                DescricaoProduto = "2 carnes de 100 gramas, queijo prato,  alface, pão de hambúrguer artesanal, catupiry original, linguiça calabresa picada bem fininha e frita e um sensacional vinagrete! (tomate + cebola + pimentão). ",
                ProductDescription = null,
                CategoriaProdutoId = 1
            },
            new ProdutoModel()
            {
                Id = 25,
                ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/6f2e403e00684f859272073e5efc6a92.png",
                NomeProduto = "combo rose",
                DescricaoProduto = "alface, tomate, hambúrguer de 150 gramas, queijo prato e aquele aquele molhinho delicia! acompanha fritas e refri de 200 ml.",
                ProductDescription = null,
                CategoriaProdutoId = 1
            },
            new ProdutoModel()
            {
                Id = 26,
                ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/56e429222b864f999e22a05b69a71fb1.png",
                NomeProduto = "combo caramelizado",
                DescricaoProduto = "rúcula, hambúrguer de 150g, queijo cheddar e cebola caramelizada! acompanha refri 200 ml e fritas.",
                ProductDescription = null,
                CategoriaProdutoId = 1
            },
            new ProdutoModel()
            {
                Id = 27,
                ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/23d1f5302c81456fb741965455739dd3.png",
                NomeProduto = "brasa bacon",
                DescricaoProduto = "esse foi pensando especialmente pra você que ama bacon! hambúrguer de 180g, queijo prato, maionese de bacon, alface, tomate e cebola roxa.",
                ProductDescription = null,
                CategoriaProdutoId = 1
            },
            new ProdutoModel()
            {
                Id = 28,
                ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/c48e2932fe664d5f8323d505ffd52563.png",
                NomeProduto = "combo kids junior",
                DescricaoProduto = "pcq (pão, carne (100gramas) e queijo + fritas + refri de 200 ml + danoninho! alegria da criançada!",
                ProductDescription = null,
                CategoriaProdutoId = 1
            },
            new ProdutoModel()
            {
                Id = 29,
                ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/799aa62124fa4ec5a47d307ba7288450.png",
                NomeProduto = "brasa calabresa",
                DescricaoProduto = "2 carnes de 100 gramas, queijo prato,  alface, pão de hambúrguer artesanal, catupiry original, linguiça calabresa picada bem fininha e frita e um sensacional vinagrete! (tomate + cebola + pimentão). ",
                ProductDescription = null,
                CategoriaProdutoId = 1
            },
            new ProdutoModel()
            {
                Id = 30,
                ImagemProduto = "",
                NomeProduto = "long neck heineken",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 31,
                ImagemProduto = "",
                NomeProduto = "long neck budweiser",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 32,
                ImagemProduto = "",
                NomeProduto = "long neck corona",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 33,
                ImagemProduto = "",
                NomeProduto = "long neck eisenbahn",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 34,
                ImagemProduto = "",
                NomeProduto = "água com gás",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 35,
                ImagemProduto = "",
                NomeProduto = "água sem gás",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 36,
                ImagemProduto = "",
                NomeProduto = "cerveja original 600 ml",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 37,
                ImagemProduto = "",
                NomeProduto = "cerveja colorado appia 600 ml",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 38,
                ImagemProduto = "",
                NomeProduto = "refrigerante guaraná antarctica",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 39,
                ImagemProduto = "",
                NomeProduto = "refrigerante coca-cola",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 40,
                ImagemProduto = "",
                NomeProduto = "refrigerante fanta",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 41,
                ImagemProduto = "",
                NomeProduto = "refrigerante soda/sprite",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 42,
                ImagemProduto = "",
                NomeProduto = "água tônica",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 43,
                ImagemProduto = "",
                NomeProduto = "refrigerante schweeps",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 44,
                ImagemProduto = "",
                NomeProduto = "suco de laranja",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 45,
                ImagemProduto = "",
                NomeProduto = "tônica",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 46,
                ImagemProduto = "",
                NomeProduto = "água mineral",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 47,
                ImagemProduto = "",
                NomeProduto = "água mineral com gás",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 48,
                ImagemProduto = "",
                NomeProduto = "h20 limão ou limoneto",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 49,
                ImagemProduto = "",
                NomeProduto = "red bull original",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 50,
                ImagemProduto = "",
                NomeProduto = "red bull tropical",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 51,
                ImagemProduto = "",
                NomeProduto = "red bull melancia",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 52,
                ImagemProduto = "",
                NomeProduto = "sucos natural de laranja",
                DescricaoProduto = "400 ml",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 53,
                ImagemProduto = "",
                NomeProduto = "sucos natural de limão",
                DescricaoProduto = "400 ml",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 54,
                ImagemProduto = "",
                NomeProduto = "sucos natural de maracujá",
                DescricaoProduto = "400 ml",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 55,
                ImagemProduto = "",
                NomeProduto = "sucos polpa abacaxi com hortelã",
                DescricaoProduto = "400 ml",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 56,
                ImagemProduto = "",
                NomeProduto = "sucos polpa acerola",
                DescricaoProduto = "400 ml",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 57,
                ImagemProduto = "",
                NomeProduto = "sucos polpa caju",
                DescricaoProduto = "400 ml",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 58,
                ImagemProduto = "",
                NomeProduto = "brotas beer pilsen",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 59,
                ImagemProduto = "",
                NomeProduto = "brotas beer weiss",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 60,
                ImagemProduto = "",
                NomeProduto = "brotas beer red ale",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 61,
                ImagemProduto = "",
                NomeProduto = "brotas beer double ipa bruta flor",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 62,
                ImagemProduto = "",
                NomeProduto = "brotas beer ne ipa uvaia juicy",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 63,
                ImagemProduto = "",
                NomeProduto = "chopp brotas beer pilsen",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 64,
                ImagemProduto = "",
                NomeProduto = "chopp brotas beer ipa",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 65,
                ImagemProduto = "",
                NomeProduto = "gin tônica tropical",
                DescricaoProduto = "energético tropical ou energético melância",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 66,
                ImagemProduto = "",
                NomeProduto = "gin maça verde",
                DescricaoProduto = "tônica e maça verde",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 67,
                ImagemProduto = "",
                NomeProduto = "gin especiarias",
                DescricaoProduto = "escolha 3 opcões: blueberry, cardamomo, zimbro, anis estrelado, canela",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 68,
                ImagemProduto = "",
                NomeProduto = "caipirinha teen",
                DescricaoProduto = "suco de laranja, suco de abacaxi, soda limonada e um lance de groselha",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 69,
                ImagemProduto = "",
                NomeProduto = "kiss on the beach",
                DescricaoProduto = "suco de laranja, suco de pêssego e um lance de groselha ",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 70,
                ImagemProduto = "",
                NomeProduto = "spanish",
                DescricaoProduto = "suco de uva, suco de abacaxi e leite condensado",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 71,
                ImagemProduto = "",
                NomeProduto = "pipeline",
                DescricaoProduto = "suco de abacaxi, suco de maracuja, leite condensado e cobertura de morango",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 72,
                ImagemProduto = "",
                NomeProduto = "piña colada",
                DescricaoProduto = "rum, suco de abacaxi, leite de côco e leite condensado.",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 73,
                ImagemProduto = "",
                NomeProduto = "sex on the beach",
                DescricaoProduto = "vodka, xarope de pêssego, suco de laranja e grenadine",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 74,
                ImagemProduto = "",
                NomeProduto = "moscow mule",
                DescricaoProduto = "vodka, xarope de açucar e espuma de gengibre",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 75,
                ImagemProduto = "",
                NomeProduto = "espanhola",
                DescricaoProduto = "vinho com morango, abacaxi ou maracujá e leite condensado",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 76,
                ImagemProduto = "",
                NomeProduto = "mojito",
                DescricaoProduto = "rum, hortelã macerado com açucar, suco de limão e água com gás",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 77,
                ImagemProduto = "",
                NomeProduto = "whisky sour",
                DescricaoProduto = "whisky, limão maceradp com açucar e borda com sal.",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 78,
                ImagemProduto = "",
                NomeProduto = "margarita",
                DescricaoProduto = "tequila, limão, um lance de curaçau e borda com sal",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 79,
                ImagemProduto = "",
                NomeProduto = "pink lemonade (500 ml)",
                DescricaoProduto = "limão siciliano, suco de groselha e aqua mix",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 80,
                ImagemProduto = "",
                NomeProduto = "campari",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 81,
                ImagemProduto = "",
                NomeProduto = "whisky red label",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 82,
                ImagemProduto = "",
                NomeProduto = "vodka absolut",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 83,
                ImagemProduto = "",
                NomeProduto = "gin tanqueray",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 84,
                ImagemProduto = "",
                NomeProduto = "cervejas long neck eisenbah",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 85,
                ImagemProduto = "",
                NomeProduto = "cervejas long neck heineken",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 86,
                ImagemProduto = "",
                NomeProduto = "cervejas long neck budweiser",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 87,
                ImagemProduto = "",
                NomeProduto = "cervejas long neck corona",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 88,
                ImagemProduto = "",
                NomeProduto = "cervejas original 600 ml",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 89,
                ImagemProduto = "",
                NomeProduto = "cervejas heineken 600 ml",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 90,
                ImagemProduto = "",
                NomeProduto = "cervejas colorado 600 ml",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 91,
                ImagemProduto = "",
                NomeProduto = "cervejas eisenbahn 600 ml",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 92,
                ImagemProduto = "",
                NomeProduto = "refrigerante soda",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 93,
                ImagemProduto = "",
                NomeProduto = "refrigerante fanta",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 94,
                ImagemProduto = "",
                NomeProduto = "refrigerante guaraná",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 95,
                ImagemProduto = "",
                NomeProduto = "refrigerante coca-cola zero",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 96,
                ImagemProduto = "",
                NomeProduto = "refrigerante coca-cola",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 97,
                ImagemProduto = "",
                NomeProduto = "refrigerante schwepps",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 98,
                ImagemProduto = "",
                NomeProduto = "h20 limao e limoneto",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 99,
                ImagemProduto = "",
                NomeProduto = "suco natural de laranja",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 100,
                ImagemProduto = "",
                NomeProduto = "chopp artesanal texugos",
                DescricaoProduto = "caneca 300 ml",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
            new ProdutoModel()
            {
                Id = 101,
                ImagemProduto = "",
                NomeProduto = "cerveja colorado appia 600 ml",
                DescricaoProduto = "",
                ProductDescription = null,
                CategoriaProdutoId = 2
            },
                new ProdutoModel()
                {
                    Id = 102,
                    ImagemProduto = "",
                    NomeProduto = "cerveja heineken 600 ml",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 103,
                    ImagemProduto = "",
                    NomeProduto = "cerveja baden baden 600 ml",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 104,
                    ImagemProduto = "",
                    NomeProduto = "chopp (brotas beer pilsen)",
                    DescricaoProduto = "copo de 300 ml ",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 105,
                    ImagemProduto = "",
                    NomeProduto = "refrigerante soda",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 106,
                    ImagemProduto = "",
                    NomeProduto = "h2o limão/limoneto",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 107,
                    ImagemProduto = "",
                    NomeProduto = "suco",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 108,
                    ImagemProduto = "",
                    NomeProduto = "suco de laranja natural (400 ml)",
                    DescricaoProduto = "consumo no local",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 109,
                    ImagemProduto = "",
                    NomeProduto = "suco de laranja natural (300 ml)",
                    DescricaoProduto = "delivery/retirada",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 110,
                    ImagemProduto = "",
                    NomeProduto = "água com gás",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 111,
                    ImagemProduto = "",
                    NomeProduto = "água sem gás",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 112,
                    ImagemProduto = "",
                    NomeProduto = "soda italiana",
                    DescricaoProduto = "limão siciliano, frutas vermelhasm laranja e maça verde",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 113,
                    ImagemProduto = "",
                    NomeProduto = "caipirinha/caipiroska/saquerinha velho barreiro",
                    DescricaoProduto = "abacaxi, maracujá, morango e limão",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 114,
                    ImagemProduto = "",
                    NomeProduto = "caipirinha/caipiroska/saquerinha smirnoff",
                    DescricaoProduto = "abacaxi, maracujá, morango e limão",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 115,
                    ImagemProduto = "",
                    NomeProduto = "caipirinha/caipiroska/saquerinha saquê",
                    DescricaoProduto = "abacaxi, maracujá, morango e limão",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 116,
                    ImagemProduto = "",
                    NomeProduto = "refrigerante limoneto",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 117,
                    ImagemProduto = "",
                    NomeProduto = "refrigerante h2o limão",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 118,
                    ImagemProduto = "",
                    NomeProduto = "refrigerante água tônica",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 119,
                    ImagemProduto = "",
                    NomeProduto = "refrigerante soda",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 120,
                    ImagemProduto = "",
                    NomeProduto = "refrigerante scheweeps",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 121,
                    ImagemProduto = "",
                    NomeProduto = "refrigerante fanta",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 122,
                    ImagemProduto = "",
                    NomeProduto = "refrigerante guaraná",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 123,
                    ImagemProduto = "",
                    NomeProduto = "refrigerante coca-cola",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 124,
                    ImagemProduto = "",
                    NomeProduto = "suco de limão",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 125,
                    ImagemProduto = "",
                    NomeProduto = "refrigerante coca cola",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 126,
                    ImagemProduto = "",
                    NomeProduto = "refrigerante coca cola zero",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 127,
                    ImagemProduto = "",
                    NomeProduto = "refrigerante fanta laranja",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 128,
                    ImagemProduto = "",
                    NomeProduto = "refrigerante fanta uva",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 129,
                    ImagemProduto = "",
                    NomeProduto = "refrigerante scheweeps",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 130,
                    ImagemProduto = "",
                    NomeProduto = "refrigerante soda",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 131,
                    ImagemProduto = "",
                    NomeProduto = "refrigerante sprite",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 132,
                    ImagemProduto = "",
                    NomeProduto = "água tônica",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 133,
                    ImagemProduto = "",
                    NomeProduto = "h20 limão/limoneto",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 134,
                    ImagemProduto = "",
                    NomeProduto = "cerveja original",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 135,
                    ImagemProduto = "",
                    NomeProduto = "cerveja colorado appia",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 136,
                    ImagemProduto = "",
                    NomeProduto = "long neck heineken",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 137,
                    ImagemProduto = "",
                    NomeProduto = "cerveja budweiser",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 138,
                    ImagemProduto = "",
                    NomeProduto = "cerveja eisenbahn",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 139,
                    ImagemProduto = "",
                    NomeProduto = "cerveja corona",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 2
                },
                new ProdutoModel()
                {
                    Id = 140,
                    ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/1c74f9cc7d0c4837981139e860889c38.jpg",
                    NomeProduto = "fritas com bacon",
                    DescricaoProduto = "aproximadamente 350g de fritas acompanhadas do melhor bacon do universo.",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 141,
                    ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/d1688218ecf34409ae1051cc24e649bd.jpg",
                    NomeProduto = "brasa fries and rib",
                    DescricaoProduto = "aproximadamente 300g de fritas, coberta com carne bovin desfiada, catupiry original e bacon",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 142,
                    ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/86f6fdcc6c934c5ea93ce24e70603aeb.jpg",
                    NomeProduto = "aneis de cebola",
                    DescricaoProduto = "porção de 15 anéis de cebola",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 143,
                    ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/796f32e4f67b47efb7d0b9b7a981fc29.jpg",
                    NomeProduto = "mix de bolinhos",
                    DescricaoProduto = "porção de 9 bolinhos (costela,coxinha,gorgonzola e carne seca com requeijão) em uma cama de catupiry",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 144,
                    ImagemProduto = "",
                    NomeProduto = "fritas e aneis de cebola",
                    DescricaoProduto = "meia porção de fritas com 8 anéis de cebola.",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 145,
                    ImagemProduto = "",
                    NomeProduto = "travesseiro de queijo gouda e nuggets",
                    DescricaoProduto = "porção de 4 palitos e 6 nuggets de frango.",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 146,
                    ImagemProduto = "",
                    NomeProduto = "brasa fries and ribs (fritas com costela)",
                    DescricaoProduto = "aproximadamente 300g de fritas, carne de costela bovina desfiada, catupiry e bacon",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 147,
                    ImagemProduto = "",
                    NomeProduto = "aneis de cebola (10 unidades)",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 148,
                    ImagemProduto = "",
                    NomeProduto = "travesseiro de queijo com molho barbecue",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 149,
                    ImagemProduto = "",
                    NomeProduto = "bolinho de costela servido com geléia de abacaxi com pimenta",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 150,
                    ImagemProduto = "",
                    NomeProduto = "mussarela de búfala crispy com geléia de pimenta",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 151,
                    ImagemProduto = "",
                    NomeProduto = "frango artesanal no palito com maionese verde",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 152,
                    ImagemProduto = "",
                    NomeProduto = "croquete de carne na cama de cream cheese",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 153,
                    ImagemProduto = "",
                    NomeProduto = "batata rústica com ervas finas",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 154,
                    ImagemProduto = "",
                    NomeProduto = "batata de carinha e nuggets com molho rosé",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 155,
                    ImagemProduto = "",
                    NomeProduto = "fritas",
                    DescricaoProduto = "aproximadamente 350g de fritas .",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 156,
                    ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/cdac614bbca04f96921bcfa61e38017e.jpg",
                    NomeProduto = "brasa fries and ribs",
                    DescricaoProduto = "aproximadamente 300g de fritas, coberta com carne bovin desfiada, catupiry original e bacon",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 157,
                    ImagemProduto = "",
                    NomeProduto = "cheese pillows",
                    DescricaoProduto = "travesseirinhos de queijo gouda",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 158,
                    ImagemProduto = "",
                    NomeProduto = "palito de mussarela e nuggets",
                    DescricaoProduto = "porção de 4 palitos e 6 nuggets de frango.",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 159,
                    ImagemProduto = "",
                    NomeProduto = "bolinho de costela",
                    DescricaoProduto = "porção de 10 bolinhos de costela.",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 160,
                    ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/a5dbe4ff65084f54b8b7418a3cee4826.jpg",
                    NomeProduto = "bolinho de gorgonzola",
                    DescricaoProduto = "porção de 10 bolinhos de gorgonzola.",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 161,
                    ImagemProduto = "",
                    NomeProduto = "travesseiro de muçarela e nuggets",
                    DescricaoProduto = "porção de 4 travesseiros e 6 nuggets de frango.",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 162,
                    ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/a5dbe4ff65084f54b8b7418a3cee4826.jpg",
                    NomeProduto = "bolinho de bacalhau",
                    DescricaoProduto = "porção de 9 bolinhos de bacalhau.",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 163,
                    ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/bac9a6dab320416fb4651d333c36e89b.jpg",
                    NomeProduto = "travesseiros de muçarela",
                    DescricaoProduto = "porção de 9 travesseiros de muçarela.",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 164,
                    ImagemProduto = "",
                    NomeProduto = "batata rústica",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 165,
                    ImagemProduto = "",
                    NomeProduto = "coxinhas",
                    DescricaoProduto = "escolha nos sabores: frango, gorgonzola ou costela",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 166,
                    ImagemProduto = "",
                    NomeProduto = "almofadinhas de queijo",
                    DescricaoProduto = "8 unidades de almofadinhas de queijo",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 167,
                    ImagemProduto = "",
                    NomeProduto = "nuggets",
                    DescricaoProduto = "porção de nuggets",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 168,
                    ImagemProduto = "",
                    NomeProduto = "coxinha de frango",
                    DescricaoProduto = "porção de coxinhas (salgadinhos) de frango",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 169,
                    ImagemProduto = "",
                    NomeProduto = "coxinha de gorgonzola",
                    DescricaoProduto = "porção de coxinhas (salgadinhos) de gorgonzola",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 170,
                    ImagemProduto = "",
                    NomeProduto = "travesseiro de mussarela e nuggets",
                    DescricaoProduto = "porção de 4 travesseios de mussarela e 6 nuggets de frango.",
                    ProductDescription = null,
                    CategoriaProdutoId = 3
                },
                new ProdutoModel()
                {
                    Id = 171,
                    ImagemProduto = "",
                    NomeProduto = "mini churros",
                    DescricaoProduto = "8 mini churros acompanhado de doce de leite ou nutella",
                    ProductDescription = null,
                    CategoriaProdutoId = 4
                },
                new ProdutoModel()
                {
                    Id = 172,
                    ImagemProduto = "",
                    NomeProduto = "sorvekids",
                    DescricaoProduto = "2 bolas de sorvete, cobertura de chocolate, canudo biju waffer e confetes",
                    ProductDescription = null,
                    CategoriaProdutoId = 4
                },
                new ProdutoModel()
                {
                    Id = 173,
                    ImagemProduto = "",
                    NomeProduto = "taça negresco",
                    DescricaoProduto = "ganache de chocolate meio amargo, sorvete  de leite ninho trufado e farofa de bolacha negresco",
                    ProductDescription = null,
                    CategoriaProdutoId = 4
                },
                new ProdutoModel()
                {
                    Id = 174,
                    ImagemProduto = "https://yata-apix-12c626c1-c4e5-440f-9a8a-6cb1537cb8fa.s3-object.locaweb.com.br/5185dabab1b34d8a9ee4b692cf62ac26.png",
                    NomeProduto = "brasa brownie",
                    DescricaoProduto = "brownie de chocolate, sorvete de creme e calda de chocolate",
                    ProductDescription = null,
                    CategoriaProdutoId = 4
                },
                new ProdutoModel()
                {
                    Id = 175,
                    ImagemProduto = "",
                    NomeProduto = "milk shake",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 4
                },
                new ProdutoModel()
                {
                    Id = 176,
                    ImagemProduto = "",
                    NomeProduto = "brasa split",
                    DescricaoProduto = "",
                    ProductDescription = null,
                    CategoriaProdutoId = 4
                });
            #endregion Produto

            #region Produto Estabelecimento
            modelBuilder.Entity<ProdutoEstabelecimentoModel>().HasData(
            new ProdutoEstabelecimentoModel()
            {
                Id = 1,
                Valor = 28,
                EstabelecimentoId = 1,
                ProdutoId = 1
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 2,
                Valor = 26,
                EstabelecimentoId = 1,
                ProdutoId = 2
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 3,
                Valor = 28,
                EstabelecimentoId = 1,
                ProdutoId = 3
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 4,
                Valor = 25,
                EstabelecimentoId = 1,
                ProdutoId = 4
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 5,
                Valor = 31,
                EstabelecimentoId = 1,
                ProdutoId = 5
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 6,
                Valor = 33,
                EstabelecimentoId = 1,
                ProdutoId = 6
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 7,
                Valor = 30,
                EstabelecimentoId = 1,
                ProdutoId = 7
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 8,
                Valor = 28,
                EstabelecimentoId = 1,
                ProdutoId = 8
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 9,
                Valor = 30,
                EstabelecimentoId = 1,
                ProdutoId = 9
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 10,
                Valor = 26,
                EstabelecimentoId = 1,
                ProdutoId = 10
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 11,
                Valor = 21.99,
                EstabelecimentoId = 1,
                ProdutoId = 11
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 12,
                Valor = 21.99,
                EstabelecimentoId = 1,
                ProdutoId = 12
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 13,
                Valor = 20,
                EstabelecimentoId = 1,
                ProdutoId = 13
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 14,
                Valor = 28,
                EstabelecimentoId = 1,
                ProdutoId = 14
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 15,
                Valor = 33,
                EstabelecimentoId = 1,
                ProdutoId = 15
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 16,
                Valor = 28,
                EstabelecimentoId = 1,
                ProdutoId = 16
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 17,
                Valor = 32,
                EstabelecimentoId = 1,
                ProdutoId = 17
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 18,
                Valor = 14,
                EstabelecimentoId = 1,
                ProdutoId = 18
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 19,
                Valor = 24,
                EstabelecimentoId = 1,
                ProdutoId = 140
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 20,
                Valor = 31.99,
                EstabelecimentoId = 1,
                ProdutoId = 141
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 21,
                Valor = 18,
                EstabelecimentoId = 1,
                ProdutoId = 142
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 22,
                Valor = 20,
                EstabelecimentoId = 1,
                ProdutoId = 143
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 23,
                Valor = 22,
                EstabelecimentoId = 1,
                ProdutoId = 144
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 24,
                Valor = 22,
                EstabelecimentoId = 1,
                ProdutoId = 145
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 25,
                Valor = 13,
                EstabelecimentoId = 1,
                ProdutoId = 171
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 26,
                Valor = 9.5,
                EstabelecimentoId = 1,
                ProdutoId = 30
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 27,
                Valor = 8,
                EstabelecimentoId = 1,
                ProdutoId = 31
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 28,
                Valor = 9.5,
                EstabelecimentoId = 1,
                ProdutoId = 32
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 29,
                Valor = 8,
                EstabelecimentoId = 1,
                ProdutoId = 33
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 30,
                Valor = 3.5,
                EstabelecimentoId = 1,
                ProdutoId = 34
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 31,
                Valor = 3,
                EstabelecimentoId = 1,
                ProdutoId = 35
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 32,
                Valor = 12,
                EstabelecimentoId = 1,
                ProdutoId = 36
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 33,
                Valor = 18,
                EstabelecimentoId = 1,
                ProdutoId = 37
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 34,
                Valor = 5.5,
                EstabelecimentoId = 1,
                ProdutoId = 38
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 35,
                Valor = 5.5,
                EstabelecimentoId = 1,
                ProdutoId = 39
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 36,
                Valor = 5.5,
                EstabelecimentoId = 1,
                ProdutoId = 40
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 37,
                Valor = 5.5,
                EstabelecimentoId = 1,
                ProdutoId = 41
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 38,
                Valor = 5.5,
                EstabelecimentoId = 1,
                ProdutoId = 42
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 39,
                Valor = 5.5,
                EstabelecimentoId = 1,
                ProdutoId = 43
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 40,
                Valor = 7,
                EstabelecimentoId = 1,
                ProdutoId = 44
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 41,
                Valor = 26,
                EstabelecimentoId = 2,
                ProdutoId = 1
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 42,
                Valor = 23,
                EstabelecimentoId = 2,
                ProdutoId = 19
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 43,
                Valor = 27,
                EstabelecimentoId = 2,
                ProdutoId = 3
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 44,
                Valor = 28,
                EstabelecimentoId = 2,
                ProdutoId = 20
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 45,
                Valor = 28,
                EstabelecimentoId = 2,
                ProdutoId = 6
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 46,
                Valor = 28,
                EstabelecimentoId = 2,
                ProdutoId = 7
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 47,
                Valor = 27,
                EstabelecimentoId = 2,
                ProdutoId = 8
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 48,
                Valor = 26,
                EstabelecimentoId = 2,
                ProdutoId = 9
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 49,
                Valor = 26,
                EstabelecimentoId = 2,
                ProdutoId = 10
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 50,
                Valor = 19.99,
                EstabelecimentoId = 2,
                ProdutoId = 11
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 51,
                Valor = 19.99,
                EstabelecimentoId = 2,
                ProdutoId = 25
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 52,
                Valor = 23,
                EstabelecimentoId = 2,
                ProdutoId = 4
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 53,
                Valor = 19.99,
                EstabelecimentoId = 2,
                ProdutoId = 26
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 54,
                Valor = 19.99,
                EstabelecimentoId = 2,
                ProdutoId = 12
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 55,
                Valor = 19,
                EstabelecimentoId = 2,
                ProdutoId = 13
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 56,
                Valor = 25,
                EstabelecimentoId = 2,
                ProdutoId = 14
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 57,
                Valor = 30,
                EstabelecimentoId = 2,
                ProdutoId = 15
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 58,
                Valor = 26,
                EstabelecimentoId = 2,
                ProdutoId = 16
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 59,
                Valor = 31,
                EstabelecimentoId = 2,
                ProdutoId = 17
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 60,
                Valor = 13,
                EstabelecimentoId = 2,
                ProdutoId = 18
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 61,
                Valor = 25,
                EstabelecimentoId = 2,
                ProdutoId = 140
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 62,
                Valor = 23,
                EstabelecimentoId = 2,
                ProdutoId = 144
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 63,
                Valor = 33,
                EstabelecimentoId = 2,
                ProdutoId = 156
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 64,
                Valor = 25,
                EstabelecimentoId = 2,
                ProdutoId = 170
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 65,
                Valor = 19,
                EstabelecimentoId = 2,
                ProdutoId = 142
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 66,
                Valor = 20,
                EstabelecimentoId = 2,
                ProdutoId = 159
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 67,
                Valor = 13,
                EstabelecimentoId = 2,
                ProdutoId = 171
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 68,
                Valor = 16.9,
                EstabelecimentoId = 2,
                ProdutoId = 173
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 69,
                Valor = 6.5,
                EstabelecimentoId = 2,
                ProdutoId = 44
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 70,
                Valor = 6,
                EstabelecimentoId = 2,
                ProdutoId = 124
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 71,
                Valor = 4,
                EstabelecimentoId = 2,
                ProdutoId = 34
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 72,
                Valor = 3.5,
                EstabelecimentoId = 2,
                ProdutoId = 35
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 73,
                Valor = 6,
                EstabelecimentoId = 2,
                ProdutoId = 125
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 74,
                Valor = 6,
                EstabelecimentoId = 2,
                ProdutoId = 126
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 75,
                Valor = 6,
                EstabelecimentoId = 2,
                ProdutoId = 127
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 76,
                Valor = 6,
                EstabelecimentoId = 2,
                ProdutoId = 128
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 77,
                Valor = 6,
                EstabelecimentoId = 2,
                ProdutoId = 129
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 78,
                Valor = 6,
                EstabelecimentoId = 2,
                ProdutoId = 130
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 79,
                Valor = 6,
                EstabelecimentoId = 2,
                ProdutoId = 131
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 80,
                Valor = 6,
                EstabelecimentoId = 2,
                ProdutoId = 132
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 81,
                Valor = 6,
                EstabelecimentoId = 2,
                ProdutoId = 133
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 82,
                Valor = 13,
                EstabelecimentoId = 2,
                ProdutoId = 134
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 83,
                Valor = 19,
                EstabelecimentoId = 2,
                ProdutoId = 135
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 84,
                Valor = 10,
                EstabelecimentoId = 2,
                ProdutoId = 136
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 85,
                Valor = 8,
                EstabelecimentoId = 2,
                ProdutoId = 137
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 86,
                Valor = 8,
                EstabelecimentoId = 2,
                ProdutoId = 138
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 87,
                Valor = 9,
                EstabelecimentoId = 2,
                ProdutoId = 139
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 88,
                Valor = 26,
                EstabelecimentoId = 3,
                ProdutoId = 1
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 89,
                Valor = 24,
                EstabelecimentoId = 3,
                ProdutoId = 19
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 90,
                Valor = 27,
                EstabelecimentoId = 3,
                ProdutoId = 3
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 91,
                Valor = 29,
                EstabelecimentoId = 3,
                ProdutoId = 29
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 92,
                Valor = 27,
                EstabelecimentoId = 3,
                ProdutoId = 20
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 93,
                Valor = 28,
                EstabelecimentoId = 3,
                ProdutoId = 6
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 94,
                Valor = 27,
                EstabelecimentoId = 3,
                ProdutoId = 7
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 95,
                Valor = 27,
                EstabelecimentoId = 3,
                ProdutoId = 8
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 96,
                Valor = 27,
                EstabelecimentoId = 3,
                ProdutoId = 9
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 97,
                Valor = 25,
                EstabelecimentoId = 3,
                ProdutoId = 10
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 98,
                Valor = 19.99,
                EstabelecimentoId = 3,
                ProdutoId = 11
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 99,
                Valor = 19.99,
                EstabelecimentoId = 3,
                ProdutoId = 25
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 100,
                Valor = 25,
                EstabelecimentoId = 3,
                ProdutoId = 4
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 101,
                Valor = 19.99,
                EstabelecimentoId = 3,
                ProdutoId = 26
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 102,
                Valor = 19.99,
                EstabelecimentoId = 3,
                ProdutoId = 12
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 103,
                Valor = 19.99,
                EstabelecimentoId = 3,
                ProdutoId = 22
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 104,
                Valor = 19,
                EstabelecimentoId = 3,
                ProdutoId = 13
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 105,
                Valor = 27,
                EstabelecimentoId = 3,
                ProdutoId = 14
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 106,
                Valor = 30,
                EstabelecimentoId = 3,
                ProdutoId = 15
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 107,
                Valor = 26,
                EstabelecimentoId = 3,
                ProdutoId = 16
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 108,
                Valor = 30,
                EstabelecimentoId = 3,
                ProdutoId = 17
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 109,
                Valor = 13,
                EstabelecimentoId = 3,
                ProdutoId = 18
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 110,
                Valor = 26,
                EstabelecimentoId = 3,
                ProdutoId = 140
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 111,
                Valor = 23,
                EstabelecimentoId = 3,
                ProdutoId = 164
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 112,
                Valor = 16.99,
                EstabelecimentoId = 3,
                ProdutoId = 165
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 113,
                Valor = 23,
                EstabelecimentoId = 3,
                ProdutoId = 144
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 114,
                Valor = 22,
                EstabelecimentoId = 3,
                ProdutoId = 155
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 115,
                Valor = 16.99,
                EstabelecimentoId = 3,
                ProdutoId = 166
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 116,
                Valor = 32,
                EstabelecimentoId = 3,
                ProdutoId = 156
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 117,
                Valor = 22,
                EstabelecimentoId = 3,
                ProdutoId = 167
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 118,
                Valor = 19,
                EstabelecimentoId = 3,
                ProdutoId = 142
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 119,
                Valor = 16,
                EstabelecimentoId = 3,
                ProdutoId = 159
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 120,
                Valor = 16,
                EstabelecimentoId = 3,
                ProdutoId = 168
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 121,
                Valor = 16,
                EstabelecimentoId = 3,
                ProdutoId = 169
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 122,
                Valor = 15,
                EstabelecimentoId = 3,
                ProdutoId = 175
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 123,
                Valor = 15,
                EstabelecimentoId = 3,
                ProdutoId = 176
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 124,
                Valor = 14,
                EstabelecimentoId = 3,
                ProdutoId = 171
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 125,
                Valor = 5,
                EstabelecimentoId = 3,
                ProdutoId = 116
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 126,
                Valor = 5,
                EstabelecimentoId = 3,
                ProdutoId = 117
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 127,
                Valor = 5,
                EstabelecimentoId = 3,
                ProdutoId = 118
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 128,
                Valor = 5,
                EstabelecimentoId = 3,
                ProdutoId = 119
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 129,
                Valor = 5,
                EstabelecimentoId = 3,
                ProdutoId = 120
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 130,
                Valor = 5,
                EstabelecimentoId = 3,
                ProdutoId = 121
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 131,
                Valor = 5,
                EstabelecimentoId = 3,
                ProdutoId = 122
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 132,
                Valor = 5,
                EstabelecimentoId = 3,
                ProdutoId = 123
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 133,
                Valor = 6.5,
                EstabelecimentoId = 3,
                ProdutoId = 108
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 134,
                Valor = 5,
                EstabelecimentoId = 3,
                ProdutoId = 109
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 135,
                Valor = 3.5,
                EstabelecimentoId = 3,
                ProdutoId = 111
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 136,
                Valor = 4,
                EstabelecimentoId = 3,
                ProdutoId = 110
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 137,
                Valor = 30,
                EstabelecimentoId = 4,
                ProdutoId = 1
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 138,
                Valor = 27,
                EstabelecimentoId = 4,
                ProdutoId = 19
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 139,
                Valor = 30,
                EstabelecimentoId = 4,
                ProdutoId = 3
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 140,
                Valor = 31,
                EstabelecimentoId = 4,
                ProdutoId = 24
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 141,
                Valor = 32,
                EstabelecimentoId = 4,
                ProdutoId = 20
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 142,
                Valor = 32,
                EstabelecimentoId = 4,
                ProdutoId = 6
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 143,
                Valor = 31,
                EstabelecimentoId = 4,
                ProdutoId = 7
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 144,
                Valor = 30,
                EstabelecimentoId = 4,
                ProdutoId = 8
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 145,
                Valor = 30,
                EstabelecimentoId = 4,
                ProdutoId = 9
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 146,
                Valor = 29,
                EstabelecimentoId = 4,
                ProdutoId = 10
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 147,
                Valor = 23.99,
                EstabelecimentoId = 4,
                ProdutoId = 11
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 148,
                Valor = 23.99,
                EstabelecimentoId = 4,
                ProdutoId = 25
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 149,
                Valor = 23.99,
                EstabelecimentoId = 4,
                ProdutoId = 26
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 150,
                Valor = 23.99,
                EstabelecimentoId = 4,
                ProdutoId = 12
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 151,
                Valor = 22,
                EstabelecimentoId = 4,
                ProdutoId = 13
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 152,
                Valor = 29,
                EstabelecimentoId = 4,
                ProdutoId = 14
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 153,
                Valor = 34,
                EstabelecimentoId = 4,
                ProdutoId = 15
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 154,
                Valor = 28,
                EstabelecimentoId = 4,
                ProdutoId = 4
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 155,
                Valor = 29,
                EstabelecimentoId = 4,
                ProdutoId = 16
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 156,
                Valor = 33,
                EstabelecimentoId = 4,
                ProdutoId = 17
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 157,
                Valor = 14,
                EstabelecimentoId = 4,
                ProdutoId = 18
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 158,
                Valor = 28,
                EstabelecimentoId = 4,
                ProdutoId = 140
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 159,
                Valor = 23,
                EstabelecimentoId = 4,
                ProdutoId = 155
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 160,
                Valor = 32,
                EstabelecimentoId = 4,
                ProdutoId = 156
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 161,
                Valor = 22,
                EstabelecimentoId = 4,
                ProdutoId = 157
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 162,
                Valor = 24,
                EstabelecimentoId = 4,
                ProdutoId = 144
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 163,
                Valor = 25,
                EstabelecimentoId = 4,
                ProdutoId = 158
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 164,
                Valor = 21,
                EstabelecimentoId = 4,
                ProdutoId = 142
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 165,
                Valor = 20,
                EstabelecimentoId = 4,
                ProdutoId = 159
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 166,
                Valor = 21,
                EstabelecimentoId = 4,
                ProdutoId = 160
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 167,
                Valor = 15,
                EstabelecimentoId = 4,
                ProdutoId = 171
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 168,
                Valor = 9,
                EstabelecimentoId = 4,
                ProdutoId = 84
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 169,
                Valor = 10,
                EstabelecimentoId = 4,
                ProdutoId = 85
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 170,
                Valor = 9,
                EstabelecimentoId = 4,
                ProdutoId = 86
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 171,
                Valor = 9,
                EstabelecimentoId = 4,
                ProdutoId = 87
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 172,
                Valor = 12,
                EstabelecimentoId = 4,
                ProdutoId = 88
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 173,
                Valor = 16,
                EstabelecimentoId = 4,
                ProdutoId = 89
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 174,
                Valor = 16,
                EstabelecimentoId = 4,
                ProdutoId = 90
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 175,
                Valor = 14,
                EstabelecimentoId = 4,
                ProdutoId = 91
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 176,
                Valor = 5,
                EstabelecimentoId = 4,
                ProdutoId = 92
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 177,
                Valor = 5,
                EstabelecimentoId = 4,
                ProdutoId = 93
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 178,
                Valor = 5,
                EstabelecimentoId = 4,
                ProdutoId = 94
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 179,
                Valor = 5,
                EstabelecimentoId = 4,
                ProdutoId = 95
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 180,
                Valor = 5,
                EstabelecimentoId = 4,
                ProdutoId = 96
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 181,
                Valor = 5,
                EstabelecimentoId = 4,
                ProdutoId = 97
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 182,
                Valor = 6.5,
                EstabelecimentoId = 4,
                ProdutoId = 98
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 183,
                Valor = 6.5,
                EstabelecimentoId = 4,
                ProdutoId = 99
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 184,
                Valor = 4,
                EstabelecimentoId = 4,
                ProdutoId = 35
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 185,
                Valor = 4,
                EstabelecimentoId = 4,
                ProdutoId = 34
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 186,
                Valor = 7,
                EstabelecimentoId = 4,
                ProdutoId = 100
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 187,
                Valor = 29,
                EstabelecimentoId = 5,
                ProdutoId = 1
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 188,
                Valor = 26,
                EstabelecimentoId = 5,
                ProdutoId = 19
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 189,
                Valor = 30,
                EstabelecimentoId = 5,
                ProdutoId = 3
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 190,
                Valor = 31,
                EstabelecimentoId = 5,
                ProdutoId = 24
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 191,
                Valor = 31,
                EstabelecimentoId = 5,
                ProdutoId = 20
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 192,
                Valor = 32,
                EstabelecimentoId = 5,
                ProdutoId = 6
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 193,
                Valor = 31,
                EstabelecimentoId = 5,
                ProdutoId = 7
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 194,
                Valor = 30,
                EstabelecimentoId = 5,
                ProdutoId = 8
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 195,
                Valor = 30,
                EstabelecimentoId = 5,
                ProdutoId = 9
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 196,
                Valor = 29,
                EstabelecimentoId = 5,
                ProdutoId = 10
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 197,
                Valor = 23.9,
                EstabelecimentoId = 5,
                ProdutoId = 11
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 198,
                Valor = 23.9,
                EstabelecimentoId = 5,
                ProdutoId = 25
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 199,
                Valor = 27,
                EstabelecimentoId = 5,
                ProdutoId = 4
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 200,
                Valor = 30,
                EstabelecimentoId = 5,
                ProdutoId = 27
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 201,
                Valor = 22.99,
                EstabelecimentoId = 5,
                ProdutoId = 28
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 202,
                Valor = 22,
                EstabelecimentoId = 5,
                ProdutoId = 13
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 203,
                Valor = 30,
                EstabelecimentoId = 5,
                ProdutoId = 14
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 204,
                Valor = 33,
                EstabelecimentoId = 5,
                ProdutoId = 15
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 205,
                Valor = 26.9,
                EstabelecimentoId = 5,
                ProdutoId = 12
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 206,
                Valor = 26.9,
                EstabelecimentoId = 5,
                ProdutoId = 26
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 207,
                Valor = 29,
                EstabelecimentoId = 5,
                ProdutoId = 16
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 208,
                Valor = 32,
                EstabelecimentoId = 5,
                ProdutoId = 17
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 209,
                Valor = 13,
                EstabelecimentoId = 5,
                ProdutoId = 18
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 210,
                Valor = 26,
                EstabelecimentoId = 5,
                ProdutoId = 140
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 211,
                Valor = 22,
                EstabelecimentoId = 5,
                ProdutoId = 155
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 212,
                Valor = 24,
                EstabelecimentoId = 5,
                ProdutoId = 144
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 213,
                Valor = 24,
                EstabelecimentoId = 5,
                ProdutoId = 161
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 214,
                Valor = 20,
                EstabelecimentoId = 5,
                ProdutoId = 142
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 215,
                Valor = 19,
                EstabelecimentoId = 5,
                ProdutoId = 159
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 216,
                Valor = 19,
                EstabelecimentoId = 5,
                ProdutoId = 162
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 217,
                Valor = 19,
                EstabelecimentoId = 5,
                ProdutoId = 160
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 218,
                Valor = 18,
                EstabelecimentoId = 5,
                ProdutoId = 163
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 219,
                Valor = 27.99,
                EstabelecimentoId = 5,
                ProdutoId = 156
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 220,
                Valor = 10.9,
                EstabelecimentoId = 5,
                ProdutoId = 172
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 221,
                Valor = 16.9,
                EstabelecimentoId = 5,
                ProdutoId = 173
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 222,
                Valor = 16.9,
                EstabelecimentoId = 5,
                ProdutoId = 174
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 223,
                Valor = 14,
                EstabelecimentoId = 5,
                ProdutoId = 171
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 224,
                Valor = 9,
                EstabelecimentoId = 5,
                ProdutoId = 33
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 225,
                Valor = 9,
                EstabelecimentoId = 5,
                ProdutoId = 31
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 226,
                Valor = 10,
                EstabelecimentoId = 5,
                ProdutoId = 32
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 227,
                Valor = 11,
                EstabelecimentoId = 5,
                ProdutoId = 30
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 228,
                Valor = 19,
                EstabelecimentoId = 5,
                ProdutoId = 101
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 229,
                Valor = 14,
                EstabelecimentoId = 5,
                ProdutoId = 36
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 230,
                Valor = 15,
                EstabelecimentoId = 5,
                ProdutoId = 102
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 231,
                Valor = 19,
                EstabelecimentoId = 5,
                ProdutoId = 103
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 232,
                Valor = 8.9,
                EstabelecimentoId = 5,
                ProdutoId = 104
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 233,
                Valor = 6,
                EstabelecimentoId = 5,
                ProdutoId = 38
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 234,
                Valor = 6,
                EstabelecimentoId = 5,
                ProdutoId = 39
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 235,
                Valor = 6,
                EstabelecimentoId = 5,
                ProdutoId = 40
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 236,
                Valor = 6,
                EstabelecimentoId = 5,
                ProdutoId = 105
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 237,
                Valor = 6,
                EstabelecimentoId = 5,
                ProdutoId = 42
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 238,
                Valor = 6,
                EstabelecimentoId = 5,
                ProdutoId = 43
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 239,
                Valor = 7.5,
                EstabelecimentoId = 5,
                ProdutoId = 106
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 241,
                Valor = 7.5,
                EstabelecimentoId = 5,
                ProdutoId = 108
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 242,
                Valor = 6,
                EstabelecimentoId = 5,
                ProdutoId = 109
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 243,
                Valor = 4,
                EstabelecimentoId = 5,
                ProdutoId = 110
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 244,
                Valor = 4,
                EstabelecimentoId = 5,
                ProdutoId = 111
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 245,
                Valor = 11.9,
                EstabelecimentoId = 5,
                ProdutoId = 112
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 246,
                Valor = 13.99,
                EstabelecimentoId = 5,
                ProdutoId = 113
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 247,
                Valor = 18.99,
                EstabelecimentoId = 5,
                ProdutoId = 114
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 248,
                Valor = 18.9,
                EstabelecimentoId = 5,
                ProdutoId = 115
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 250,
                Valor = 28,
                EstabelecimentoId = 6,
                ProdutoId = 19
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 251,
                Valor = 31,
                EstabelecimentoId = 6,
                ProdutoId = 3
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 252,
                Valor = 31,
                EstabelecimentoId = 6,
                ProdutoId = 20
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 253,
                Valor = 32,
                EstabelecimentoId = 6,
                ProdutoId = 6
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 254,
                Valor = 31,
                EstabelecimentoId = 6,
                ProdutoId = 7
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 255,
                Valor = 32,
                EstabelecimentoId = 6,
                ProdutoId = 8
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 256,
                Valor = 30,
                EstabelecimentoId = 6,
                ProdutoId = 9
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 257,
                Valor = 29,
                EstabelecimentoId = 6,
                ProdutoId = 10
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 258,
                Valor = 30,
                EstabelecimentoId = 6,
                ProdutoId = 21
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 259,
                Valor = 21.99,
                EstabelecimentoId = 6,
                ProdutoId = 22
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 260,
                Valor = 21.99,
                EstabelecimentoId = 6,
                ProdutoId = 11
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 261,
                Valor = 21.99,
                EstabelecimentoId = 6,
                ProdutoId = 12
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 262,
                Valor = 33,
                EstabelecimentoId = 6,
                ProdutoId = 23
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 263,
                Valor = 28,
                EstabelecimentoId = 6,
                ProdutoId = 4
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 264,
                Valor = 22,
                EstabelecimentoId = 6,
                ProdutoId = 13
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 265,
                Valor = 29,
                EstabelecimentoId = 6,
                ProdutoId = 16
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 266,
                Valor = 33,
                EstabelecimentoId = 6,
                ProdutoId = 15
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 267,
                Valor = 31,
                EstabelecimentoId = 6,
                ProdutoId = 14
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 268,
                Valor = 32,
                EstabelecimentoId = 6,
                ProdutoId = 17
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 269,
                Valor = 15,
                EstabelecimentoId = 6,
                ProdutoId = 18
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 270,
                Valor = 31,
                EstabelecimentoId = 6,
                ProdutoId = 146
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 271,
                Valor = 23,
                EstabelecimentoId = 6,
                ProdutoId = 144
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 272,
                Valor = 20,
                EstabelecimentoId = 6,
                ProdutoId = 147
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 273,
                Valor = 21,
                EstabelecimentoId = 6,
                ProdutoId = 148
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 274,
                Valor = 22,
                EstabelecimentoId = 6,
                ProdutoId = 149
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 275,
                Valor = 21,
                EstabelecimentoId = 6,
                ProdutoId = 150
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 276,
                Valor = 15,
                EstabelecimentoId = 6,
                ProdutoId = 151
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 277,
                Valor = 22,
                EstabelecimentoId = 6,
                ProdutoId = 152
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 278,
                Valor = 15,
                EstabelecimentoId = 6,
                ProdutoId = 153
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 279,
                Valor = 20,
                EstabelecimentoId = 6,
                ProdutoId = 154
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 280,
                Valor = 14.99,
                EstabelecimentoId = 6,
                ProdutoId = 171
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 281,
                Valor = 11,
                EstabelecimentoId = 6,
                ProdutoId = 172
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 282,
                Valor = 17,
                EstabelecimentoId = 6,
                ProdutoId = 173
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 283,
                Valor = 5.5,
                EstabelecimentoId = 6,
                ProdutoId = 45
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 284,
                Valor = 4,
                EstabelecimentoId = 6,
                ProdutoId = 46
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 285,
                Valor = 4.5,
                EstabelecimentoId = 6,
                ProdutoId = 47
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 286,
                Valor = 7.5,
                EstabelecimentoId = 6,
                ProdutoId = 48
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 287,
                Valor = 12,
                EstabelecimentoId = 6,
                ProdutoId = 49
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 288,
                Valor = 12,
                EstabelecimentoId = 6,
                ProdutoId = 50
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 289,
                Valor = 12,
                EstabelecimentoId = 6,
                ProdutoId = 51
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 290,
                Valor = 7.5,
                EstabelecimentoId = 6,
                ProdutoId = 52
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 291,
                Valor = 7.5,
                EstabelecimentoId = 6,
                ProdutoId = 53
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 292,
                Valor = 7.5,
                EstabelecimentoId = 6,
                ProdutoId = 54
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 293,
                Valor = 7.5,
                EstabelecimentoId = 6,
                ProdutoId = 55
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 294,
                Valor = 7.5,
                EstabelecimentoId = 6,
                ProdutoId = 56
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 295,
                Valor = 7.5,
                EstabelecimentoId = 6,
                ProdutoId = 57
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 296,
                Valor = 22,
                EstabelecimentoId = 6,
                ProdutoId = 58
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 297,
                Valor = 23,
                EstabelecimentoId = 6,
                ProdutoId = 59
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 298,
                Valor = 24,
                EstabelecimentoId = 6,
                ProdutoId = 60
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 299,
                Valor = 31.99,
                EstabelecimentoId = 6,
                ProdutoId = 61
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 300,
                Valor = 29.99,
                EstabelecimentoId = 6,
                ProdutoId = 62
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 301,
                Valor = 9.5,
                EstabelecimentoId = 6,
                ProdutoId = 63
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 302,
                Valor = 10.5,
                EstabelecimentoId = 6,
                ProdutoId = 64
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 303,
                Valor = 28.9,
                EstabelecimentoId = 6,
                ProdutoId = 65
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 304,
                Valor = 28.9,
                EstabelecimentoId = 6,
                ProdutoId = 66
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 305,
                Valor = 31.9,
                EstabelecimentoId = 6,
                ProdutoId = 67
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 306,
                Valor = 13.9,
                EstabelecimentoId = 6,
                ProdutoId = 68
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 307,
                Valor = 13.9,
                EstabelecimentoId = 6,
                ProdutoId = 69
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 308,
                Valor = 15.9,
                EstabelecimentoId = 6,
                ProdutoId = 70
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 309,
                Valor = 15.9,
                EstabelecimentoId = 6,
                ProdutoId = 71
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 310,
                Valor = 25.9,
                EstabelecimentoId = 6,
                ProdutoId = 72
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 311,
                Valor = 25.9,
                EstabelecimentoId = 6,
                ProdutoId = 73
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 312,
                Valor = 23.9,
                EstabelecimentoId = 6,
                ProdutoId = 74
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 313,
                Valor = 21.9,
                EstabelecimentoId = 6,
                ProdutoId = 75
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 314,
                Valor = 23.9,
                EstabelecimentoId = 6,
                ProdutoId = 76
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 315,
                Valor = 23.9,
                EstabelecimentoId = 6,
                ProdutoId = 77
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 316,
                Valor = 23.9,
                EstabelecimentoId = 6,
                ProdutoId = 78
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 317,
                Valor = 15.99,
                EstabelecimentoId = 6,
                ProdutoId = 79
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 318,
                Valor = 15.99,
                EstabelecimentoId = 6,
                ProdutoId = 79
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 319,
                Valor = 15.99,
                EstabelecimentoId = 6,
                ProdutoId = 79
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 320,
                Valor = 11.9,
                EstabelecimentoId = 6,
                ProdutoId = 80
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 321,
                Valor = 16.9,
                EstabelecimentoId = 6,
                ProdutoId = 81
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 322,
                Valor = 16.9,
                EstabelecimentoId = 6,
                ProdutoId = 82
            },
            new ProdutoEstabelecimentoModel()
            {
                Id = 323,
                Valor = 18.9,
                EstabelecimentoId = 6,
                ProdutoId = 83
            });
            #endregion Produto Estabelecimento

            #region Adicionais
            modelBuilder.Entity<AdicionalModel>().HasData(
            new AdicionalModel()
            {
                Id = 1,
                IngredienteId = 37,
                CategoriaAdicionalId = 2,
                Valor = 11
            },
            new AdicionalModel()
            {
                Id = 2,
                IngredienteId = 38,
                CategoriaAdicionalId = 2,
                Valor = 4.5
            },
            new AdicionalModel()
            {
                Id = 3,
                IngredienteId = 39,
                CategoriaAdicionalId = 2,
                Valor = 3.5
            },
            new AdicionalModel()
            {
                Id = 4,
                IngredienteId = 40,
                CategoriaAdicionalId = 2,
                Valor = 2
            },
            new AdicionalModel()
            {
                Id = 5,
                IngredienteId = 41,
                CategoriaAdicionalId = 2,
                Valor = 5
            },
            new AdicionalModel()
            {
                Id = 6,
                IngredienteId = 42,
                CategoriaAdicionalId = 2,
                Valor = 3.5
            },
            new AdicionalModel()
            {
                Id = 7,
                IngredienteId = 43,
                CategoriaAdicionalId = 2,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 8,
                IngredienteId = 44,
                CategoriaAdicionalId = 2,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 9,
                IngredienteId = 45,
                CategoriaAdicionalId = 2,
                Valor = 4
            },
            new AdicionalModel()
            {
                Id = 10,
                IngredienteId = 46,
                CategoriaAdicionalId = 2,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 11,
                IngredienteId = 47,
                CategoriaAdicionalId = 2,
                Valor = 9
            },
            new AdicionalModel()
            {
                Id = 12,
                IngredienteId = 48,
                CategoriaAdicionalId = 2,
                Valor = 4
            },
            new AdicionalModel()
            {
                Id = 13,
                IngredienteId = 49,
                CategoriaAdicionalId = 2,
                Valor = 6
            },
            new AdicionalModel()
            {
                Id = 14,
                IngredienteId = 50,
                CategoriaAdicionalId = 2,
                Valor = 2.5
            },
            new AdicionalModel()
            {
                Id = 15,
                IngredienteId = 51,
                CategoriaAdicionalId = 2,
                Valor = 3.5
            },
            new AdicionalModel()
            {
                Id = 16,
                IngredienteId = 52,
                CategoriaAdicionalId = 2,
                Valor = 2.5
            },
            new AdicionalModel()
            {
                Id = 17,
                IngredienteId = 53,
                CategoriaAdicionalId = 1,
                Valor = 6
            },
            new AdicionalModel()
            {
                Id = 18,
                IngredienteId = 54,
                CategoriaAdicionalId = 1,
                Valor = 7
            },
            new AdicionalModel()
            {
                Id = 19,
                IngredienteId = 55,
                CategoriaAdicionalId = 1,
                Valor = 5
            },
            new AdicionalModel()
            {
                Id = 20,
                IngredienteId = 56,
                CategoriaAdicionalId = 1,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 21,
                IngredienteId = 57,
                CategoriaAdicionalId = 1,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 22,
                IngredienteId = 58,
                CategoriaAdicionalId = 1,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 23,
                IngredienteId = 59,
                CategoriaAdicionalId = 1,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 24,
                IngredienteId = 37,
                CategoriaAdicionalId = 2,
                Valor = 10
            },
            new AdicionalModel()
            {
                Id = 25,
                IngredienteId = 38,
                CategoriaAdicionalId = 2,
                Valor = 4.5
            },
            new AdicionalModel()
            {
                Id = 26,
                IngredienteId = 39,
                CategoriaAdicionalId = 2,
                Valor = 3.5
            },
            new AdicionalModel()
            {
                Id = 27,
                IngredienteId = 40,
                CategoriaAdicionalId = 2,
                Valor = 2
            },
            new AdicionalModel()
            {
                Id = 28,
                IngredienteId = 41,
                CategoriaAdicionalId = 2,
                Valor = 5
            },
            new AdicionalModel()
            {
                Id = 29,
                IngredienteId = 42,
                CategoriaAdicionalId = 2,
                Valor = 3.5
            },
            new AdicionalModel()
            {
                Id = 30,
                IngredienteId = 43,
                CategoriaAdicionalId = 2,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 31,
                IngredienteId = 44,
                CategoriaAdicionalId = 2,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 32,
                IngredienteId = 45,
                CategoriaAdicionalId = 2,
                Valor = 4
            },
            new AdicionalModel()
            {
                Id = 33,
                IngredienteId = 46,
                CategoriaAdicionalId = 2,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 34,
                IngredienteId = 47,
                CategoriaAdicionalId = 2,
                Valor = 6
            },
            new AdicionalModel()
            {
                Id = 35,
                IngredienteId = 65,
                CategoriaAdicionalId = 2,
                Valor = 8
            },
            new AdicionalModel()
            {
                Id = 36,
                IngredienteId = 48,
                CategoriaAdicionalId = 2,
                Valor = 4
            },
            new AdicionalModel()
            {
                Id = 37,
                IngredienteId = 49,
                CategoriaAdicionalId = 2,
                Valor = 6
            },
            new AdicionalModel()
            {
                Id = 38,
                IngredienteId = 50,
                CategoriaAdicionalId = 2,
                Valor = 2.5
            },
            new AdicionalModel()
            {
                Id = 39,
                IngredienteId = 51,
                CategoriaAdicionalId = 2,
                Valor = 3.5
            },
            new AdicionalModel()
            {
                Id = 40,
                IngredienteId = 52,
                CategoriaAdicionalId = 2,
                Valor = 2.5
            },
            new AdicionalModel()
            {
                Id = 41,
                IngredienteId = 53,
                CategoriaAdicionalId = 1,
                Valor = 6
            },
            new AdicionalModel()
            {
                Id = 42,
                IngredienteId = 54,
                CategoriaAdicionalId = 1,
                Valor = 7
            },
            new AdicionalModel()
            {
                Id = 43,
                IngredienteId = 55,
                CategoriaAdicionalId = 1,
                Valor = 5
            },
            new AdicionalModel()
            {
                Id = 44,
                IngredienteId = 56,
                CategoriaAdicionalId = 1,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 45,
                IngredienteId = 57,
                CategoriaAdicionalId = 1,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 46,
                IngredienteId = 58,
                CategoriaAdicionalId = 1,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 47,
                IngredienteId = 59,
                CategoriaAdicionalId = 1,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 48,
                IngredienteId = 37,
                CategoriaAdicionalId = 2,
                Valor = 10
            },
            new AdicionalModel()
            {
                Id = 49,
                IngredienteId = 61,
                CategoriaAdicionalId = 2,
                Valor = 11
            },
            new AdicionalModel()
            {
                Id = 50,
                IngredienteId = 38,
                CategoriaAdicionalId = 2,
                Valor = 4.5
            },
            new AdicionalModel()
            {
                Id = 51,
                IngredienteId = 39,
                CategoriaAdicionalId = 2,
                Valor = 3.5
            },
            new AdicionalModel()
            {
                Id = 52,
                IngredienteId = 63,
                CategoriaAdicionalId = 2,
                Valor = 4
            },
            new AdicionalModel()
            {
                Id = 53,
                IngredienteId = 40,
                CategoriaAdicionalId = 2,
                Valor = 2
            },
            new AdicionalModel()
            {
                Id = 54,
                IngredienteId = 41,
                CategoriaAdicionalId = 2,
                Valor = 5
            },
            new AdicionalModel()
            {
                Id = 55,
                IngredienteId = 73,
                CategoriaAdicionalId = 2,
                Valor = 4.5
            },
            new AdicionalModel()
            {
                Id = 56,
                IngredienteId = 74,
                CategoriaAdicionalId = 2,
                Valor = 2.5
            },
            new AdicionalModel()
            {
                Id = 57,
                IngredienteId = 42,
                CategoriaAdicionalId = 2,
                Valor = 3.5
            },
            new AdicionalModel()
            {
                Id = 58,
                IngredienteId = 43,
                CategoriaAdicionalId = 2,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 59,
                IngredienteId = 44,
                CategoriaAdicionalId = 2,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 60,
                IngredienteId = 70,
                CategoriaAdicionalId = 2,
                Valor = 3.5
            },
            new AdicionalModel()
            {
                Id = 61,
                IngredienteId = 71,
                CategoriaAdicionalId = 2,
                Valor = 3.5
            },
            new AdicionalModel()
            {
                Id = 62,
                IngredienteId = 69,
                CategoriaAdicionalId = 2,
                Valor = 4.5
            },
            new AdicionalModel()
            {
                Id = 63,
                IngredienteId = 75,
                CategoriaAdicionalId = 2,
                Valor = 5
            },
            new AdicionalModel()
            {
                Id = 64,
                IngredienteId = 45,
                CategoriaAdicionalId = 2,
                Valor = 4
            },
            new AdicionalModel()
            {
                Id = 65,
                IngredienteId = 46,
                CategoriaAdicionalId = 2,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 66,
                IngredienteId = 47,
                CategoriaAdicionalId = 2,
                Valor = 7
            },
            new AdicionalModel()
            {
                Id = 67,
                IngredienteId = 48,
                CategoriaAdicionalId = 2,
                Valor = 4
            },
            new AdicionalModel()
            {
                Id = 68,
                IngredienteId = 49,
                CategoriaAdicionalId = 2,
                Valor = 5.5
            },
            new AdicionalModel()
            {
                Id = 69,
                IngredienteId = 50,
                CategoriaAdicionalId = 2,
                Valor = 3.5
            },
            new AdicionalModel()
            {
                Id = 70,
                IngredienteId = 76,
                CategoriaAdicionalId = 2,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 71,
                IngredienteId = 66,
                CategoriaAdicionalId = 2,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 72,
                IngredienteId = 77,
                CategoriaAdicionalId = 2,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 73,
                IngredienteId = 67,
                CategoriaAdicionalId = 2,
                Valor = 5
            },
            new AdicionalModel()
            {
                Id = 74,
                IngredienteId = 51,
                CategoriaAdicionalId = 2,
                Valor = 3.5
            },
            new AdicionalModel()
            {
                Id = 75,
                IngredienteId = 52,
                CategoriaAdicionalId = 2,
                Valor = 2.5
            },
            new AdicionalModel()
            {
                Id = 76,
                IngredienteId = 65,
                CategoriaAdicionalId = 2,
                Valor = 7
            },
            new AdicionalModel()
            {
                Id = 77,
                IngredienteId = 78,
                CategoriaAdicionalId = 2,
                Valor = 4
            },
            new AdicionalModel()
            {
                Id = 78,
                IngredienteId = 79,
                CategoriaAdicionalId = 2,
                Valor = 4
            },
            new AdicionalModel()
            {
                Id = 79,
                IngredienteId = 53,
                CategoriaAdicionalId = 1,
                Valor = 4.5
            },
            new AdicionalModel()
            {
                Id = 80,
                IngredienteId = 54,
                CategoriaAdicionalId = 1,
                Valor = 6
            },
            new AdicionalModel()
            {
                Id = 81,
                IngredienteId = 55,
                CategoriaAdicionalId = 1,
                Valor = 5
            },
            new AdicionalModel()
            {
                Id = 82,
                IngredienteId = 56,
                CategoriaAdicionalId = 1,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 83,
                IngredienteId = 57,
                CategoriaAdicionalId = 1,
                Valor = 3.5
            },
            new AdicionalModel()
            {
                Id = 84,
                IngredienteId = 58,
                CategoriaAdicionalId = 1,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 85,
                IngredienteId = 59,
                CategoriaAdicionalId = 1,
                Valor = 3.5
            },
            new AdicionalModel()
            {
                Id = 86,
                IngredienteId = 37,
                CategoriaAdicionalId = 2,
                Valor = 11
            },
            new AdicionalModel()
            {
                Id = 87,
                IngredienteId = 38,
                CategoriaAdicionalId = 2,
                Valor = 5
            },
            new AdicionalModel()
            {
                Id = 88,
                IngredienteId = 39,
                CategoriaAdicionalId = 2,
                Valor = 3.5
            },
            new AdicionalModel()
            {
                Id = 89,
                IngredienteId = 40,
                CategoriaAdicionalId = 2,
                Valor = 1
            },
            new AdicionalModel()
            {
                Id = 90,
                IngredienteId = 41,
                CategoriaAdicionalId = 2,
                Valor = 5
            },
            new AdicionalModel()
            {
                Id = 91,
                IngredienteId = 42,
                CategoriaAdicionalId = 2,
                Valor = 3.5
            },
            new AdicionalModel()
            {
                Id = 92,
                IngredienteId = 43,
                CategoriaAdicionalId = 2,
                Valor = 3.5
            },
            new AdicionalModel()
            {
                Id = 93,
                IngredienteId = 44,
                CategoriaAdicionalId = 2,
                Valor = 3.5
            },
            new AdicionalModel()
            {
                Id = 94,
                IngredienteId = 45,
                CategoriaAdicionalId = 2,
                Valor = 4.5
            },
            new AdicionalModel()
            {
                Id = 95,
                IngredienteId = 46,
                CategoriaAdicionalId = 2,
                Valor = 4
            },
            new AdicionalModel()
            {
                Id = 96,
                IngredienteId = 47,
                CategoriaAdicionalId = 2,
                Valor = 7
            },
            new AdicionalModel()
            {
                Id = 97,
                IngredienteId = 48,
                CategoriaAdicionalId = 2,
                Valor = 4
            },
            new AdicionalModel()
            {
                Id = 98,
                IngredienteId = 49,
                CategoriaAdicionalId = 2,
                Valor = 6
            },
            new AdicionalModel()
            {
                Id = 99,
                IngredienteId = 50,
                CategoriaAdicionalId = 2,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 100,
                IngredienteId = 51,
                CategoriaAdicionalId = 2,
                Valor = 3.5
            },
            new AdicionalModel()
            {
                Id = 101,
                IngredienteId = 52,
                CategoriaAdicionalId = 2,
                Valor = 3.5
            },
            new AdicionalModel()
            {
                Id = 102,
                IngredienteId = 53,
                CategoriaAdicionalId = 1,
                Valor = 6
            },
            new AdicionalModel()
            {
                Id = 103,
                IngredienteId = 54,
                CategoriaAdicionalId = 1,
                Valor = 7
            },
            new AdicionalModel()
            {
                Id = 104,
                IngredienteId = 55,
                CategoriaAdicionalId = 1,
                Valor = 5
            },
            new AdicionalModel()
            {
                Id = 105,
                IngredienteId = 56,
                CategoriaAdicionalId = 1,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 106,
                IngredienteId = 57,
                CategoriaAdicionalId = 1,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 107,
                IngredienteId = 58,
                CategoriaAdicionalId = 1,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 108,
                IngredienteId = 59,
                CategoriaAdicionalId = 1,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 109,
                IngredienteId = 37,
                CategoriaAdicionalId = 2,
                Valor = 10
            },
            new AdicionalModel()
            {
                Id = 110,
                IngredienteId = 38,
                CategoriaAdicionalId = 2,
                Valor = 4.5
            },
            new AdicionalModel()
            {
                Id = 111,
                IngredienteId = 39,
                CategoriaAdicionalId = 2,
                Valor = 3.5
            },
            new AdicionalModel()
            {
                Id = 112,
                IngredienteId = 40,
                CategoriaAdicionalId = 2,
                Valor = 2
            },
            new AdicionalModel()
            {
                Id = 113,
                IngredienteId = 41,
                CategoriaAdicionalId = 2,
                Valor = 5
            },
            new AdicionalModel()
            {
                Id = 114,
                IngredienteId = 42,
                CategoriaAdicionalId = 2,
                Valor = 3.5
            },
            new AdicionalModel()
            {
                Id = 115,
                IngredienteId = 43,
                CategoriaAdicionalId = 2,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 116,
                IngredienteId = 44,
                CategoriaAdicionalId = 2,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 117,
                IngredienteId = 70,
                CategoriaAdicionalId = 2,
                Valor = 3.5
            },
            new AdicionalModel()
            {
                Id = 118,
                IngredienteId = 71,
                CategoriaAdicionalId = 2,
                Valor = 3.5
            },
            new AdicionalModel()
            {
                Id = 119,
                IngredienteId = 45,
                CategoriaAdicionalId = 2,
                Valor = 4
            },
            new AdicionalModel()
            {
                Id = 120,
                IngredienteId = 46,
                CategoriaAdicionalId = 2,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 121,
                IngredienteId = 47,
                CategoriaAdicionalId = 2,
                Valor = 6
            },
            new AdicionalModel()
            {
                Id = 122,
                IngredienteId = 48,
                CategoriaAdicionalId = 2,
                Valor = 4
            },
            new AdicionalModel()
            {
                Id = 123,
                IngredienteId = 49,
                CategoriaAdicionalId = 2,
                Valor = 6
            },
            new AdicionalModel()
            {
                Id = 124,
                IngredienteId = 50,
                CategoriaAdicionalId = 2,
                Valor = 2.5
            },
            new AdicionalModel()
            {
                Id = 126,
                IngredienteId = 52,
                CategoriaAdicionalId = 2,
                Valor = 2.5
            },
            new AdicionalModel()
            {
                Id = 127,
                IngredienteId = 65,
                CategoriaAdicionalId = 2,
                Valor = 8
            },
            new AdicionalModel()
            {
                Id = 128,
                IngredienteId = 53,
                CategoriaAdicionalId = 1,
                Valor = 4.5
            },
            new AdicionalModel()
            {
                Id = 129,
                IngredienteId = 54,
                CategoriaAdicionalId = 1,
                Valor = 6
            },
            new AdicionalModel()
            {
                Id = 130,
                IngredienteId = 55,
                CategoriaAdicionalId = 1,
                Valor = 5
            },
            new AdicionalModel()
            {
                Id = 131,
                IngredienteId = 56,
                CategoriaAdicionalId = 1,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 132,
                IngredienteId = 57,
                CategoriaAdicionalId = 1,
                Valor = 3.5
            },
            new AdicionalModel()
            {
                Id = 133,
                IngredienteId = 58,
                CategoriaAdicionalId = 1,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 134,
                IngredienteId = 59,
                CategoriaAdicionalId = 1,
                Valor = 3.5
            },
            new AdicionalModel()
            {
                Id = 135,
                IngredienteId = 37,
                CategoriaAdicionalId = 2,
                Valor = 10
            },
            new AdicionalModel()
            {
                Id = 136,
                IngredienteId = 60,
                CategoriaAdicionalId = 2,
                Valor = 7
            },
            new AdicionalModel()
            {
                Id = 137,
                IngredienteId = 61,
                CategoriaAdicionalId = 2,
                Valor = 11
            },
            new AdicionalModel()
            {
                Id = 138,
                IngredienteId = 62,
                CategoriaAdicionalId = 2,
                Valor = 7
            },
            new AdicionalModel()
            {
                Id = 139,
                IngredienteId = 38,
                CategoriaAdicionalId = 2,
                Valor = 5
            },
            new AdicionalModel()
            {
                Id = 140,
                IngredienteId = 39,
                CategoriaAdicionalId = 2,
                Valor = 4
            },
            new AdicionalModel()
            {
                Id = 141,
                IngredienteId = 63,
                CategoriaAdicionalId = 2,
                Valor = 4
            },
            new AdicionalModel()
            {
                Id = 142,
                IngredienteId = 40,
                CategoriaAdicionalId = 2,
                Valor = 2
            },
            new AdicionalModel()
            {
                Id = 143,
                IngredienteId = 41,
                CategoriaAdicionalId = 2,
                Valor = 5
            },
            new AdicionalModel()
            {
                Id = 144,
                IngredienteId = 42,
                CategoriaAdicionalId = 2,
                Valor = 4
            },
            new AdicionalModel()
            {
                Id = 145,
                IngredienteId = 43,
                CategoriaAdicionalId = 2,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 146,
                IngredienteId = 44,
                CategoriaAdicionalId = 2,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 147,
                IngredienteId = 64,
                CategoriaAdicionalId = 2,
                Valor = 2
            },
            new AdicionalModel()
            {
                Id = 148,
                IngredienteId = 45,
                CategoriaAdicionalId = 2,
                Valor = 4
            },
            new AdicionalModel()
            {
                Id = 149,
                IngredienteId = 46,
                CategoriaAdicionalId = 2,
                Valor = 4
            },
            new AdicionalModel()
            {
                Id = 150,
                IngredienteId = 47,
                CategoriaAdicionalId = 2,
                Valor = 8
            },
            new AdicionalModel()
            {
                Id = 151,
                IngredienteId = 65,
                CategoriaAdicionalId = 2,
                Valor = 9
            },
            new AdicionalModel()
            {
                Id = 152,
                IngredienteId = 48,
                CategoriaAdicionalId = 2,
                Valor = 4
            },
            new AdicionalModel()
            {
                Id = 153,
                IngredienteId = 49,
                CategoriaAdicionalId = 2,
                Valor = 6
            },
            new AdicionalModel()
            {
                Id = 154,
                IngredienteId = 50,
                CategoriaAdicionalId = 2,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 155,
                IngredienteId = 66,
                CategoriaAdicionalId = 2,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 156,
                IngredienteId = 67,
                CategoriaAdicionalId = 2,
                Valor = 5
            },
            new AdicionalModel()
            {
                Id = 157,
                IngredienteId = 68,
                CategoriaAdicionalId = 2,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 158,
                IngredienteId = 51,
                CategoriaAdicionalId = 2,
                Valor = 3.5
            },
            new AdicionalModel()
            {
                Id = 159,
                IngredienteId = 52,
                CategoriaAdicionalId = 2,
                Valor = 2
            },
            new AdicionalModel()
            {
                Id = 160,
                IngredienteId = 69,
                CategoriaAdicionalId = 2,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 161,
                IngredienteId = 53,
                CategoriaAdicionalId = 1,
                Valor = 6
            },
            new AdicionalModel()
            {
                Id = 162,
                IngredienteId = 54,
                CategoriaAdicionalId = 1,
                Valor = 7
            },
            new AdicionalModel()
            {
                Id = 163,
                IngredienteId = 55,
                CategoriaAdicionalId = 1,
                Valor = 5
            },
            new AdicionalModel()
            {
                Id = 164,
                IngredienteId = 56,
                CategoriaAdicionalId = 1,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 165,
                IngredienteId = 57,
                CategoriaAdicionalId = 1,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 166,
                IngredienteId = 58,
                CategoriaAdicionalId = 1,
                Valor = 3
            },
            new AdicionalModel()
            {
                Id = 167,
                IngredienteId = 59,
                CategoriaAdicionalId = 1,
                Valor = 3
            });
            #endregion Adicionais

            #region Produto Ingrediente
            modelBuilder.Entity<ProdutoIngredienteModel>().HasData(
            new ProdutoIngredienteModel()
            {
                Id = 1,
                IngredienteId = 1,
                ProdutoId = 1,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 2,
                IngredienteId = 2,
                ProdutoId = 1,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 3,
                IngredienteId = 3,
                ProdutoId = 1,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 4,
                IngredienteId = 4,
                ProdutoId = 1,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 5,
                IngredienteId = 6,
                ProdutoId = 1,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 6,
                IngredienteId = 5,
                ProdutoId = 2,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 7,
                IngredienteId = 6,
                ProdutoId = 2,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 8,
                IngredienteId = 7,
                ProdutoId = 2,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 9,
                IngredienteId = 8,
                ProdutoId = 2,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 10,
                IngredienteId = 4,
                ProdutoId = 3,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 11,
                IngredienteId = 9,
                ProdutoId = 3,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 12,
                IngredienteId = 10,
                ProdutoId = 3,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 13,
                IngredienteId = 11,
                ProdutoId = 3,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 14,
                IngredienteId = 12,
                ProdutoId = 3,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 15,
                IngredienteId = 4,
                ProdutoId = 4,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 16,
                IngredienteId = 12,
                ProdutoId = 4,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 17,
                IngredienteId = 13,
                ProdutoId = 4,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 18,
                IngredienteId = 14,
                ProdutoId = 4,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 19,
                IngredienteId = 15,
                ProdutoId = 4,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 20,
                IngredienteId = 34,
                ProdutoId = 4,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 21,
                IngredienteId = 4,
                ProdutoId = 5,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 22,
                IngredienteId = 11,
                ProdutoId = 5,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 23,
                IngredienteId = 12,
                ProdutoId = 5,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 24,
                IngredienteId = 16,
                ProdutoId = 5,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 25,
                IngredienteId = 45,
                ProdutoId = 5,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 26,
                IngredienteId = 4,
                ProdutoId = 6,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 27,
                IngredienteId = 14,
                ProdutoId = 6,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 28,
                IngredienteId = 17,
                ProdutoId = 6,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 29,
                IngredienteId = 4,
                ProdutoId = 7,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 30,
                IngredienteId = 11,
                ProdutoId = 7,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 31,
                IngredienteId = 18,
                ProdutoId = 7,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 32,
                IngredienteId = 19,
                ProdutoId = 7,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 33,
                IngredienteId = 20,
                ProdutoId = 7,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 34,
                IngredienteId = 21,
                ProdutoId = 7,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 35,
                IngredienteId = 3,
                ProdutoId = 8,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 36,
                IngredienteId = 4,
                ProdutoId = 8,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 37,
                IngredienteId = 7,
                ProdutoId = 8,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 38,
                IngredienteId = 12,
                ProdutoId = 8,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 39,
                IngredienteId = 14,
                ProdutoId = 8,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 40,
                IngredienteId = 22,
                ProdutoId = 8,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 41,
                IngredienteId = 3,
                ProdutoId = 9,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 42,
                IngredienteId = 4,
                ProdutoId = 9,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 43,
                IngredienteId = 6,
                ProdutoId = 9,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 44,
                IngredienteId = 7,
                ProdutoId = 9,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 45,
                IngredienteId = 22,
                ProdutoId = 9,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 46,
                IngredienteId = 23,
                ProdutoId = 9,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 47,
                IngredienteId = 4,
                ProdutoId = 10,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 48,
                IngredienteId = 12,
                ProdutoId = 10,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 49,
                IngredienteId = 14,
                ProdutoId = 10,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 50,
                IngredienteId = 24,
                ProdutoId = 10,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 51,
                IngredienteId = 6,
                ProdutoId = 11,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 52,
                IngredienteId = 10,
                ProdutoId = 11,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 53,
                IngredienteId = 12,
                ProdutoId = 11,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 54,
                IngredienteId = 15,
                ProdutoId = 11,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 55,
                IngredienteId = 25,
                ProdutoId = 11,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 56,
                IngredienteId = 4,
                ProdutoId = 12,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 57,
                IngredienteId = 14,
                ProdutoId = 12,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 58,
                IngredienteId = 26,
                ProdutoId = 12,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 59,
                IngredienteId = 3,
                ProdutoId = 14,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 60,
                IngredienteId = 4,
                ProdutoId = 14,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 61,
                IngredienteId = 7,
                ProdutoId = 14,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 62,
                IngredienteId = 12,
                ProdutoId = 14,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 63,
                IngredienteId = 14,
                ProdutoId = 14,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 64,
                IngredienteId = 22,
                ProdutoId = 14,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 65,
                IngredienteId = 4,
                ProdutoId = 15,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 66,
                IngredienteId = 6,
                ProdutoId = 15,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 67,
                IngredienteId = 7,
                ProdutoId = 15,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 68,
                IngredienteId = 11,
                ProdutoId = 15,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 69,
                IngredienteId = 12,
                ProdutoId = 15,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 70,
                IngredienteId = 13,
                ProdutoId = 15,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 71,
                IngredienteId = 14,
                ProdutoId = 15,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 72,
                IngredienteId = 27,
                ProdutoId = 15,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 73,
                IngredienteId = 28,
                ProdutoId = 15,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 74,
                IngredienteId = 6,
                ProdutoId = 16,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 75,
                IngredienteId = 7,
                ProdutoId = 16,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 76,
                IngredienteId = 10,
                ProdutoId = 16,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 77,
                IngredienteId = 29,
                ProdutoId = 16,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 78,
                IngredienteId = 3,
                ProdutoId = 17,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 79,
                IngredienteId = 4,
                ProdutoId = 17,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 80,
                IngredienteId = 12,
                ProdutoId = 17,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 81,
                IngredienteId = 13,
                ProdutoId = 17,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 82,
                IngredienteId = 15,
                ProdutoId = 17,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 83,
                IngredienteId = 30,
                ProdutoId = 17,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 84,
                IngredienteId = 31,
                ProdutoId = 17,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 85,
                IngredienteId = 32,
                ProdutoId = 17,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 86,
                IngredienteId = 34,
                ProdutoId = 17,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 87,
                IngredienteId = 5,
                ProdutoId = 19,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 88,
                IngredienteId = 6,
                ProdutoId = 19,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 89,
                IngredienteId = 7,
                ProdutoId = 19,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 90,
                IngredienteId = 8,
                ProdutoId = 19,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 91,
                IngredienteId = 4,
                ProdutoId = 20,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 92,
                IngredienteId = 11,
                ProdutoId = 20,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 93,
                IngredienteId = 12,
                ProdutoId = 20,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 94,
                IngredienteId = 16,
                ProdutoId = 20,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 95,
                IngredienteId = 45,
                ProdutoId = 20,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 96,
                IngredienteId = 3,
                ProdutoId = 21,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 97,
                IngredienteId = 4,
                ProdutoId = 21,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 98,
                IngredienteId = 7,
                ProdutoId = 21,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 99,
                IngredienteId = 12,
                ProdutoId = 21,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 100,
                IngredienteId = 14,
                ProdutoId = 21,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 101,
                IngredienteId = 22,
                ProdutoId = 21,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 102,
                IngredienteId = 33,
                ProdutoId = 21,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 103,
                IngredienteId = 35,
                ProdutoId = 21,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 104,
                IngredienteId = 4,
                ProdutoId = 22,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 105,
                IngredienteId = 15,
                ProdutoId = 22,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 106,
                IngredienteId = 34,
                ProdutoId = 22,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 107,
                IngredienteId = 4,
                ProdutoId = 23,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 108,
                IngredienteId = 11,
                ProdutoId = 23,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 109,
                IngredienteId = 12,
                ProdutoId = 23,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 110,
                IngredienteId = 14,
                ProdutoId = 23,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 111,
                IngredienteId = 3,
                ProdutoId = 24,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 112,
                IngredienteId = 4,
                ProdutoId = 24,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 113,
                IngredienteId = 7,
                ProdutoId = 24,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 114,
                IngredienteId = 12,
                ProdutoId = 24,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 115,
                IngredienteId = 14,
                ProdutoId = 24,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 116,
                IngredienteId = 22,
                ProdutoId = 24,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 117,
                IngredienteId = 33,
                ProdutoId = 24,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 118,
                IngredienteId = 35,
                ProdutoId = 24,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 119,
                IngredienteId = 4,
                ProdutoId = 25,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 120,
                IngredienteId = 14,
                ProdutoId = 25,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 121,
                IngredienteId = 10,
                ProdutoId = 26,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 122,
                IngredienteId = 12,
                ProdutoId = 26,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 123,
                IngredienteId = 36,
                ProdutoId = 26,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 124,
                IngredienteId = 3,
                ProdutoId = 27,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 125,
                IngredienteId = 4,
                ProdutoId = 27,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 126,
                IngredienteId = 6,
                ProdutoId = 27,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 127,
                IngredienteId = 12,
                ProdutoId = 27,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 128,
                IngredienteId = 13,
                ProdutoId = 27,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 129,
                IngredienteId = 14,
                ProdutoId = 27,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 130,
                IngredienteId = 15,
                ProdutoId = 27,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 131,
                IngredienteId = 25,
                ProdutoId = 27,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 132,
                IngredienteId = 45,
                ProdutoId = 27,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 133,
                IngredienteId = 3,
                ProdutoId = 29,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 134,
                IngredienteId = 4,
                ProdutoId = 29,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 135,
                IngredienteId = 7,
                ProdutoId = 29,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 136,
                IngredienteId = 12,
                ProdutoId = 29,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 137,
                IngredienteId = 14,
                ProdutoId = 29,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 138,
                IngredienteId = 22,
                ProdutoId = 29,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 139,
                IngredienteId = 33,
                ProdutoId = 29,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 140,
                IngredienteId = 35,
                ProdutoId = 29,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 141,
                IngredienteId = 6,
                ProdutoId = 140,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 142,
                IngredienteId = 6,
                ProdutoId = 141,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 143,
                IngredienteId = 7,
                ProdutoId = 141,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 144,
                IngredienteId = 22,
                ProdutoId = 141,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 145,
                IngredienteId = 12,
                ProdutoId = 142,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 146,
                IngredienteId = 7,
                ProdutoId = 143,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 147,
                IngredienteId = 12,
                ProdutoId = 144,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 148,
                IngredienteId = 6,
                ProdutoId = 146,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 149,
                IngredienteId = 7,
                ProdutoId = 146,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 150,
                IngredienteId = 18,
                ProdutoId = 146,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 151,
                IngredienteId = 6,
                ProdutoId = 156,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 152,
                IngredienteId = 7,
                ProdutoId = 156,
                Quantidade = 1
            },
            new ProdutoIngredienteModel()
            {
                Id = 153,
                IngredienteId = 22,
                ProdutoId = 156,
                Quantidade = 1
            });
            #endregion Produto Ingrediente

            #region Dia Funcionamento
            modelBuilder.Entity<DiaHorasFuncionamentoModel>().HasData(
            new DiaHorasFuncionamentoModel()
            {
                Id = 3,
                DiaInicio = DayOfWeek.Wednesday,
                DiaFim = DayOfWeek.Wednesday,
                EstabelecimentoId = 1,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            },
            new DiaHorasFuncionamentoModel()
            {
                Id = 4,
                DiaInicio = DayOfWeek.Thursday,
                DiaFim = DayOfWeek.Thursday,
                EstabelecimentoId = 1,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            },
            new DiaHorasFuncionamentoModel()
            {
                Id = 5,
                DiaInicio = DayOfWeek.Friday,
                DiaFim = DayOfWeek.Friday,
                EstabelecimentoId = 1,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            },
            new DiaHorasFuncionamentoModel()
            {
                Id = 6,
                DiaInicio = DayOfWeek.Saturday,
                DiaFim = DayOfWeek.Saturday,
                EstabelecimentoId = 1,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            },
            new DiaHorasFuncionamentoModel()
            {
                Id = 7,
                DiaInicio = DayOfWeek.Sunday,
                DiaFim = DayOfWeek.Sunday,
                EstabelecimentoId = 1,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            },
            new DiaHorasFuncionamentoModel()
            {
                Id = 10,
                DiaInicio = DayOfWeek.Wednesday,
                DiaFim = DayOfWeek.Wednesday,
                EstabelecimentoId = 2,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            },
            new DiaHorasFuncionamentoModel()
            {
                Id = 11,
                DiaInicio = DayOfWeek.Thursday,
                DiaFim = DayOfWeek.Thursday,
                EstabelecimentoId = 2,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            },
            new DiaHorasFuncionamentoModel()
            {
                Id = 12,
                DiaInicio = DayOfWeek.Friday,
                DiaFim = DayOfWeek.Friday,
                EstabelecimentoId = 2,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            },
            new DiaHorasFuncionamentoModel()
            {
                Id = 13,
                DiaInicio = DayOfWeek.Saturday,
                DiaFim = DayOfWeek.Saturday,
                EstabelecimentoId = 2,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            },
            new DiaHorasFuncionamentoModel()
            {
                Id = 14,
                DiaInicio = DayOfWeek.Sunday,
                DiaFim = DayOfWeek.Sunday,
                EstabelecimentoId = 2,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            },
            new DiaHorasFuncionamentoModel()
            {
                Id = 17,
                DiaInicio = DayOfWeek.Wednesday,
                DiaFim = DayOfWeek.Wednesday,
                EstabelecimentoId = 3,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            },
            new DiaHorasFuncionamentoModel()
            {
                Id = 18,
                DiaInicio = DayOfWeek.Thursday,
                DiaFim = DayOfWeek.Thursday,
                EstabelecimentoId = 3,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            },
            new DiaHorasFuncionamentoModel()
            {
                Id = 19,
                DiaInicio = DayOfWeek.Friday,
                DiaFim = DayOfWeek.Friday,
                EstabelecimentoId = 3,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            },
            new DiaHorasFuncionamentoModel()
            {
                Id = 20,
                DiaInicio = DayOfWeek.Saturday,
                DiaFim = DayOfWeek.Saturday,
                EstabelecimentoId = 3,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            },
            new DiaHorasFuncionamentoModel()
            {
                Id = 21,
                DiaInicio = DayOfWeek.Sunday,
                DiaFim = DayOfWeek.Sunday,
                EstabelecimentoId = 3,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            },
            new DiaHorasFuncionamentoModel()
            {
                Id = 24,
                DiaInicio = DayOfWeek.Wednesday,
                DiaFim = DayOfWeek.Wednesday,
                EstabelecimentoId = 4,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            },
            new DiaHorasFuncionamentoModel()
            {
                Id = 25,
                DiaInicio = DayOfWeek.Thursday,
                DiaFim = DayOfWeek.Thursday,
                EstabelecimentoId = 4,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            },
            new DiaHorasFuncionamentoModel()
            {
                Id = 26,
                DiaInicio = DayOfWeek.Friday,
                DiaFim = DayOfWeek.Friday,
                EstabelecimentoId = 4,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            },
            new DiaHorasFuncionamentoModel()
            {
                Id = 27,
                DiaInicio = DayOfWeek.Saturday,
                DiaFim = DayOfWeek.Saturday,
                EstabelecimentoId = 4,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            },
            new DiaHorasFuncionamentoModel()
            {
                Id = 28,
                DiaInicio = DayOfWeek.Sunday,
                DiaFim = DayOfWeek.Sunday,
                EstabelecimentoId = 4,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            },
            new DiaHorasFuncionamentoModel()
            {
                Id = 31,
                DiaInicio = DayOfWeek.Wednesday,
                DiaFim = DayOfWeek.Wednesday,
                EstabelecimentoId = 5,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            },
            new DiaHorasFuncionamentoModel()
            {
                Id = 32,
                DiaInicio = DayOfWeek.Thursday,
                DiaFim = DayOfWeek.Thursday,
                EstabelecimentoId = 5,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            },
            new DiaHorasFuncionamentoModel()
            {
                Id = 33,
                DiaInicio = DayOfWeek.Friday,
                DiaFim = DayOfWeek.Friday,
                EstabelecimentoId = 5,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            },
            new DiaHorasFuncionamentoModel()
            {
                Id = 34,
                DiaInicio = DayOfWeek.Saturday,
                DiaFim = DayOfWeek.Saturday,
                EstabelecimentoId = 5,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            },
            new DiaHorasFuncionamentoModel()
            {
                Id = 35,
                DiaInicio = DayOfWeek.Sunday,
                DiaFim = DayOfWeek.Sunday,
                EstabelecimentoId = 5,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            },
            new DiaHorasFuncionamentoModel()
            {
                Id = 38,
                DiaInicio = DayOfWeek.Wednesday,
                DiaFim = DayOfWeek.Wednesday,
                EstabelecimentoId = 6,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            },
            new DiaHorasFuncionamentoModel()
            {
                Id = 39,
                DiaInicio = DayOfWeek.Thursday,
                DiaFim = DayOfWeek.Thursday,
                EstabelecimentoId = 6,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            },
            new DiaHorasFuncionamentoModel()
            {
                Id = 40,
                DiaInicio = DayOfWeek.Friday,
                DiaFim = DayOfWeek.Friday,
                EstabelecimentoId = 6,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            },
            new DiaHorasFuncionamentoModel()
            {
                Id = 41,
                DiaInicio = DayOfWeek.Saturday,
                DiaFim = DayOfWeek.Saturday,
                EstabelecimentoId = 6,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            },
            new DiaHorasFuncionamentoModel()
            {
                Id = 42,
                DiaInicio = DayOfWeek.Sunday,
                DiaFim = DayOfWeek.Sunday,
                EstabelecimentoId = 6,
                HoraInicio = new DateTime(2021, 08, 26, 18, 30, 00),
                HoraFim = new DateTime(2021, 08, 26, 22, 30, 00),
            }
            );
            #endregion DiaFuncionamento

            #region Perfis
            modelBuilder.Entity<PerfilModel>().HasData(
            new PerfilModel()
            {
                Id = 1,
                NomePerfil = "Admin",
            },
            new PerfilModel()
            {
                Id = 2,
                NomePerfil = "Proprietário",
            });
            #endregion Perfis

            #region Usuário
            modelBuilder.Entity<UsuarioModel>().HasData(
            new UsuarioModel()
            {
                Id = 1,
                NomeUsuario = "Vitória Fusco",
                EmailUsuario = "vitoriaketillin@hotmail.com",
                CodigoUsuario = "vitoria.fusco",
                Senha = "$2a$11$1p.3/q6KPnbMitb8mFihTOvkOuPoxPZ/uitRlr9woiWpHR9/u8TOa",
                Endereco = "Moisés Fantin, 92",
                Whatsapp = "14998700705",                      
            });
            #endregion Usuário

            #region Perfil Usuário
            modelBuilder.Entity<PerfilUsuarioModel>().HasData(
            new PerfilUsuarioModel()
            {
                Id = 1,
                PerfilId = 1,
                UsuarioId = 1
            });
            #endregion Usuário

            modelBuilder.Entity<PedidoIngredienteModel>().HasNoKey();
        }
    }
}