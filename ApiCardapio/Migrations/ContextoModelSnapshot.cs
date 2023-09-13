﻿// <auto-generated />
using System;
using ApiCardapio.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiCardapio.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("ApiCardapio.Models.AdicionalModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CategoriaAdicionalId")
                        .HasColumnType("int");

                    b.Property<int>("IngredienteId")
                        .HasColumnType("int");

                    b.Property<double?>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaAdicionalId");

                    b.HasIndex("IngredienteId");

                    b.ToTable("Adicional");
                });

            modelBuilder.Entity("ApiCardapio.Models.CategoriaAdicionalModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AdditionalCategoryName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NomeCategoriaAdicional")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("CategoriaAdicional");
                });

            modelBuilder.Entity("ApiCardapio.Models.CategoriaEstabelecimentoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Icone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CategoriaEstabelecimento");
                });

            modelBuilder.Entity("ApiCardapio.Models.CategoriaProdutoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CategoriaAdicionalId")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("EstabelecimentoId")
                        .HasColumnType("int");

                    b.Property<bool>("ExibirCardapio")
                        .HasColumnType("bit");

                    b.Property<string>("ImagemFiltro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeCategoriaProduto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaAdicionalId");

                    b.HasIndex("EstabelecimentoId");

                    b.ToTable("CategoriaProduto");
                });

            modelBuilder.Entity("ApiCardapio.Models.DiaHorasFuncionamentoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DiaFim")
                        .HasColumnType("int");

                    b.Property<int>("DiaInicio")
                        .HasColumnType("int");

                    b.Property<int>("EstabelecimentoId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("HoraFim")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("HoraInicio")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EstabelecimentoId");

                    b.ToTable("DiaHorasFuncionamento");
                });

            modelBuilder.Entity("ApiCardapio.Models.EstabelecimentoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CategoriaEstabelecimentoId")
                        .HasColumnType("int");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Facebook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagemCapa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instagram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkCardapio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Whatsapp")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaEstabelecimentoId");

                    b.ToTable("Estabelecimento");
                });

            modelBuilder.Entity("ApiCardapio.Models.IngredienteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DescricaoIngrediente")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("EstabelecimentoId")
                        .HasColumnType("int");

                    b.Property<string>("NameIngredient")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NomeIngrediente")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("EstabelecimentoId");

                    b.ToTable("Ingrediente");
                });

            modelBuilder.Entity("ApiCardapio.Models.PagamentoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("NomeFormaPagamento")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("ApiCardapio.Models.PedidoIngredienteModel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("IngredienteId")
                        .HasColumnType("int");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int?>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoPedidoId")
                        .HasColumnType("int");

                    b.Property<double>("Quantidade")
                        .HasColumnType("float");

                    b.HasIndex("IngredienteId");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("ProdutoPedidoId");

                    b.ToTable("PedidoIngrediente");
                });

            modelBuilder.Entity("ApiCardapio.Models.PedidoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Entrega")
                        .HasColumnType("bit");

                    b.Property<int?>("PagamentoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Troco")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("PagamentoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("ApiCardapio.Models.PerfilModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("NomePerfil")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Perfil");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NomePerfil = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            NomePerfil = "Proprietário"
                        });
                });

            modelBuilder.Entity("ApiCardapio.Models.PerfilUsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("PerfilId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PerfilId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("PerfilUsuario");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PerfilId = 1,
                            UsuarioId = 1
                        });
                });

            modelBuilder.Entity("ApiCardapio.Models.PontoCarneModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("NomePontoCarne")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PontoCarne");
                });

            modelBuilder.Entity("ApiCardapio.Models.ProdutoEstabelecimentoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("EstabelecimentoId")
                        .HasColumnType("int");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.Property<double>("ValorPromocional")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EstabelecimentoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ProdutoEstabelecimento");
                });

            modelBuilder.Entity("ApiCardapio.Models.ProdutoIngredienteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IngredienteId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<double?>("Quantidade")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IngredienteId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ProdutoIngrediente");
                });

            modelBuilder.Entity("ApiCardapio.Models.ProdutoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaProdutoId")
                        .HasColumnType("int");

                    b.Property<string>("DescricaoProduto")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImagemProduto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ProductDescription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("ApiCardapio.Models.ProdutoPedidoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int?>("PontoCarneId")
                        .HasColumnType("int");

                    b.Property<int?>("ProdutoEstabelecimentoId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Valor")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("PontoCarneId");

                    b.HasIndex("ProdutoEstabelecimentoId");

                    b.ToTable("ProdutoPedido");
                });

            modelBuilder.Entity("ApiCardapio.Models.UsuarioEstabelecimentoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("EstabelecimentoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstabelecimentoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioEstabelecimento");
                });

            modelBuilder.Entity("ApiCardapio.Models.UsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CodigoUsuario")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("DataNascimento")
                        .HasMaxLength(200)
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailUsuario")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Endereco")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Whatsapp")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CodigoUsuario = "vitoria.fusco",
                            DataNascimento = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailUsuario = "vitoriaketillin@hotmail.com",
                            Endereco = "Moisés Fantin, 92",
                            NomeUsuario = "Vitória Fusco",
                            Senha = "$2a$11$1p.3/q6KPnbMitb8mFihTOvkOuPoxPZ/uitRlr9woiWpHR9/u8TOa",
                            Whatsapp = "14998700705"
                        });
                });

            modelBuilder.Entity("ApiCardapio.Models.AdicionalModel", b =>
                {
                    b.HasOne("ApiCardapio.Models.CategoriaAdicionalModel", "CategoriaAdicional")
                        .WithMany()
                        .HasForeignKey("CategoriaAdicionalId");

                    b.HasOne("ApiCardapio.Models.IngredienteModel", "Ingrediente")
                        .WithMany()
                        .HasForeignKey("IngredienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaAdicional");

                    b.Navigation("Ingrediente");
                });

            modelBuilder.Entity("ApiCardapio.Models.CategoriaProdutoModel", b =>
                {
                    b.HasOne("ApiCardapio.Models.CategoriaAdicionalModel", "CategoriaAdicional")
                        .WithMany()
                        .HasForeignKey("CategoriaAdicionalId");

                    b.HasOne("ApiCardapio.Models.EstabelecimentoModel", "Estabelecimento")
                        .WithMany()
                        .HasForeignKey("EstabelecimentoId");

                    b.Navigation("CategoriaAdicional");

                    b.Navigation("Estabelecimento");
                });

            modelBuilder.Entity("ApiCardapio.Models.DiaHorasFuncionamentoModel", b =>
                {
                    b.HasOne("ApiCardapio.Models.EstabelecimentoModel", "Estabelecimento")
                        .WithMany()
                        .HasForeignKey("EstabelecimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estabelecimento");
                });

            modelBuilder.Entity("ApiCardapio.Models.EstabelecimentoModel", b =>
                {
                    b.HasOne("ApiCardapio.Models.CategoriaEstabelecimentoModel", "CategoriaEstabelecimento")
                        .WithMany()
                        .HasForeignKey("CategoriaEstabelecimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaEstabelecimento");
                });

            modelBuilder.Entity("ApiCardapio.Models.IngredienteModel", b =>
                {
                    b.HasOne("ApiCardapio.Models.EstabelecimentoModel", "Estabelecimento")
                        .WithMany()
                        .HasForeignKey("EstabelecimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estabelecimento");
                });

            modelBuilder.Entity("ApiCardapio.Models.PedidoIngredienteModel", b =>
                {
                    b.HasOne("ApiCardapio.Models.IngredienteModel", "Ingrediente")
                        .WithMany()
                        .HasForeignKey("IngredienteId");

                    b.HasOne("ApiCardapio.Models.PedidoModel", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiCardapio.Models.ProdutoModel", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");

                    b.HasOne("ApiCardapio.Models.ProdutoPedidoModel", "ProdutoPedido")
                        .WithMany()
                        .HasForeignKey("ProdutoPedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingrediente");

                    b.Navigation("Pedido");

                    b.Navigation("Produto");

                    b.Navigation("ProdutoPedido");
                });

            modelBuilder.Entity("ApiCardapio.Models.PedidoModel", b =>
                {
                    b.HasOne("ApiCardapio.Models.PagamentoModel", "Pagamento")
                        .WithMany()
                        .HasForeignKey("PagamentoId");

                    b.HasOne("ApiCardapio.Models.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Pagamento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ApiCardapio.Models.PerfilUsuarioModel", b =>
                {
                    b.HasOne("ApiCardapio.Models.PerfilModel", "Perfil")
                        .WithMany()
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiCardapio.Models.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfil");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ApiCardapio.Models.ProdutoEstabelecimentoModel", b =>
                {
                    b.HasOne("ApiCardapio.Models.EstabelecimentoModel", "Estabelecimento")
                        .WithMany()
                        .HasForeignKey("EstabelecimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiCardapio.Models.ProdutoModel", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estabelecimento");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("ApiCardapio.Models.ProdutoIngredienteModel", b =>
                {
                    b.HasOne("ApiCardapio.Models.IngredienteModel", "Ingrediente")
                        .WithMany()
                        .HasForeignKey("IngredienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiCardapio.Models.ProdutoModel", "Produto")
                        .WithMany("ProdutoIngredientes")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingrediente");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("ApiCardapio.Models.ProdutoModel", b =>
                {
                    b.HasOne("ApiCardapio.Models.CategoriaProdutoModel", "CategoriaProduto")
                        .WithMany()
                        .HasForeignKey("CategoriaId");

                    b.Navigation("CategoriaProduto");
                });

            modelBuilder.Entity("ApiCardapio.Models.ProdutoPedidoModel", b =>
                {
                    b.HasOne("ApiCardapio.Models.PedidoModel", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoId");

                    b.HasOne("ApiCardapio.Models.PontoCarneModel", "PontoCarne")
                        .WithMany()
                        .HasForeignKey("PontoCarneId");

                    b.HasOne("ApiCardapio.Models.ProdutoEstabelecimentoModel", "ProdutoEstabelecimento")
                        .WithMany()
                        .HasForeignKey("ProdutoEstabelecimentoId");

                    b.Navigation("Pedido");

                    b.Navigation("PontoCarne");

                    b.Navigation("ProdutoEstabelecimento");
                });

            modelBuilder.Entity("ApiCardapio.Models.UsuarioEstabelecimentoModel", b =>
                {
                    b.HasOne("ApiCardapio.Models.EstabelecimentoModel", "Estabelecimento")
                        .WithMany()
                        .HasForeignKey("EstabelecimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiCardapio.Models.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estabelecimento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ApiCardapio.Models.ProdutoModel", b =>
                {
                    b.Navigation("ProdutoIngredientes");
                });
#pragma warning restore 612, 618
        }
    }
}
