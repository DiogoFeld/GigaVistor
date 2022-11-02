﻿// <auto-generated />
using System;
using GigaVistor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GigaVistor.Migrations
{
    [DbContext(typeof(GigaVistorContext))]
    partial class GigaVistorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GigaVistor.Models.AgendamentoAuditoriaModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("AuditoriaCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("AuditoriaDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("IdAuditoria")
                        .HasColumnType("bigint");

                    b.Property<long>("IdCriador")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AgendamentosAuditoria");
                });

            modelBuilder.Entity("GigaVistor.Models.AuditoriaModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("AuditoriaDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("IdCriador")
                        .HasColumnType("bigint");

                    b.Property<long>("IdProjeto")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Auditorias");
                });

            modelBuilder.Entity("GigaVistor.Models.ChecklistModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("IdAuditoria")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("checklists");
                });

            modelBuilder.Entity("GigaVistor.Models.CheckListTemplateModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("IdCriador")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("checkListTemplates");
                });

            modelBuilder.Entity("GigaVistor.Models.ItemCheckModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("Aderente")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatePrazo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatePrazoEscalonado")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Escalonado")
                        .HasColumnType("bit");

                    b.Property<string>("ExplicacaoNaoConformidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("IdCheckList")
                        .HasColumnType("bigint");

                    b.Property<long>("IdCriador")
                        .HasColumnType("bigint");

                    b.Property<long>("IdNaoConformidade")
                        .HasColumnType("bigint");

                    b.Property<long>("IdResponsavel")
                        .HasColumnType("bigint");

                    b.Property<bool>("NaoConformidade")
                        .HasColumnType("bit");

                    b.Property<int>("NivelNaoConformidade")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("StatusPosEscalonado")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("itensCheckList");
                });

            modelBuilder.Entity("GigaVistor.Models.NaoConformidadeModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("Aderente")
                        .HasColumnType("int");

                    b.Property<int>("Classificao")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatePrazo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatePrazoEscalonado")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Explicação")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("IdCheckList")
                        .HasColumnType("bigint");

                    b.Property<long>("IdCriador")
                        .HasColumnType("bigint");

                    b.Property<long>("IdEscalonamento")
                        .HasColumnType("bigint");

                    b.Property<int>("IdEscalonamentoResponsavel")
                        .HasColumnType("int");

                    b.Property<long>("IdResponsavel")
                        .HasColumnType("bigint");

                    b.Property<long>("IdTarefa")
                        .HasColumnType("bigint");

                    b.Property<bool>("PrazoCumprido")
                        .HasColumnType("bit");

                    b.Property<bool>("PrazoEscalonadoCumprido")
                        .HasColumnType("bit");

                    b.Property<int>("PrazoResolucao")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("StatusPosEscalonado")
                        .HasColumnType("int");

                    b.Property<int>("StatusPosEscalonamento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("naoConformidades");
                });

            modelBuilder.Entity("GigaVistor.Models.ProjetoModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("IdCriador")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("criacao")
                        .HasColumnType("datetime2");

                    b.Property<long>("status")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("GigaVistor.Models.SetorModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SupervisorId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Setores");
                });

            modelBuilder.Entity("GigaVistor.Models.TarefaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("IdAuditoria")
                        .HasColumnType("bigint");

                    b.Property<long>("IdCriador")
                        .HasColumnType("bigint");

                    b.Property<long>("IdResponsavel")
                        .HasColumnType("bigint");

                    b.Property<long>("IdSetor")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotasQualidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Status")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Tarefas");
                });

            modelBuilder.Entity("GigaVistor.Models.TarefaTemplateModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("IdAuditoria")
                        .HasColumnType("bigint");

                    b.Property<long>("IdCriador")
                        .HasColumnType("bigint");

                    b.Property<long>("IdSetor")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TarefasTemplate");
                });

            modelBuilder.Entity("GigaVistor.Models.TemplateModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("IdCriador")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("GigaVistor.Models.UsuarioModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("IdSuperVisor")
                        .HasColumnType("bigint");

                    b.Property<string>("Logon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Permissao")
                        .HasColumnType("int");

                    b.Property<string>("Setor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
