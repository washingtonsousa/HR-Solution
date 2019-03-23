﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using RiscServicesHRSharepointAddIn;

namespace RiscServicesHRSharepointAddIn.Migrations
{
    [DbContext(typeof(HrDbContext))]
    [Migration("20180103140514_change_cep_type_longoTodouble")]
    partial class change_cep_type_longoTodouble
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Atualizado_em");

                    b.Property<DateTime>("Criado_em");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("WebApplication1.Models.Arquivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Atualizado_em");

                    b.Property<DateTime>("Criado_em");

                    b.Property<DateTime>("Data_Referencia");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<string>("Ext")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("NomeCompleto")
                        .IsRequired();

                    b.Property<string>("Tipo")
                        .IsRequired();

                    b.Property<string>("URL")
                        .IsRequired();

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("URL")
                        .IsUnique();

                    b.HasIndex("UsuarioId");

                    b.ToTable("Arquivos");
                });

            modelBuilder.Entity("WebApplication1.Models.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Atualizado_em");

                    b.Property<DateTime>("Criado_em");

                    b.Property<int>("DepartamentoId");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("WebApplication1.Models.CertCurso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Atualizado_em");

                    b.Property<string>("Certificadora");

                    b.Property<DateTime>("Criado_em");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<string>("Instituicao");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Periodo");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("CertCursos");
                });

            modelBuilder.Entity("WebApplication1.Models.Conhecimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Atualizado_em");

                    b.Property<DateTime>("Criado_em");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Conhecimentos");
                });

            modelBuilder.Entity("WebApplication1.Models.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Atualizado_em");

                    b.Property<long>("Celular");

                    b.Property<DateTime>("Criado_em");

                    b.Property<string>("Descricao");

                    b.Property<string>("EmailContato");

                    b.Property<long>("Fixo");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("WebApplication1.Models.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AreaId");

                    b.Property<DateTime>("Atualizado_em");

                    b.Property<DateTime>("Criado_em");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("WebApplication1.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Atualizado_em");

                    b.Property<string>("Bairro")
                        .IsRequired();

                    b.Property<double>("CEP");

                    b.Property<string>("Cidade")
                        .IsRequired();

                    b.Property<string>("Complemento");

                    b.Property<DateTime>("Criado_em");

                    b.Property<int>("Numero");

                    b.Property<string>("Referencia")
                        .IsRequired();

                    b.Property<string>("Rua")
                        .IsRequired();

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("WebApplication1.Models.ExpProfissional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Atualizado_em");

                    b.Property<string>("Cargo")
                        .IsRequired();

                    b.Property<DateTime>("Criado_em");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Empresa")
                        .IsRequired();

                    b.Property<DateTime>("Fim");

                    b.Property<DateTime>("Inicio");

                    b.Property<float>("UltimoSalario");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("ExpProfissionais");
                });

            modelBuilder.Entity("WebApplication1.Models.FormAcademica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Atualizado_em");

                    b.Property<DateTime>("Criado_em");

                    b.Property<string>("Curso")
                        .IsRequired();

                    b.Property<string>("Instituicao")
                        .IsRequired();

                    b.Property<string>("Situacao");

                    b.Property<string>("TipoCurso")
                        .IsRequired();

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("FormAcademicas");
                });

            modelBuilder.Entity("WebApplication1.Models.Gestor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Atualizado_em");

                    b.Property<DateTime>("Criado_em");

                    b.Property<int>("DepartamentoId");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Gestores");
                });

            modelBuilder.Entity("WebApplication1.Models.Idioma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Atualizado_em");

                    b.Property<DateTime>("Criado_em");

                    b.Property<string>("Fluencia")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Idiomas");
                });

            modelBuilder.Entity("WebApplication1.Models.NivelAcesso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Atualizado_em");

                    b.Property<DateTime>("Criado_em");

                    b.Property<string>("Nivel")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("NivelAcessos");
                });

            modelBuilder.Entity("WebApplication1.Models.Resumo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Atualizado_em");

                    b.Property<string>("Conteudo")
                        .IsRequired();

                    b.Property<DateTime>("Criado_em");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Resumos");
                });

            modelBuilder.Entity("WebApplication1.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Atualizado_em");

                    b.Property<int>("Codigo");

                    b.Property<DateTime>("Criado_em");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("WebApplication1.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Atualizado_em");

                    b.Property<int>("CargoId");

                    b.Property<DateTime>("Criado_em");

                    b.Property<DateTime>("DataAdmissao");

                    b.Property<DateTime>("DataNasc");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("EstadoCivil")
                        .IsRequired();

                    b.Property<long>("Matricula")
                        .HasColumnType("bigint");

                    b.Property<int>("NivelAcessoId");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int?>("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.HasIndex("Matricula")
                        .IsUnique();

                    b.HasIndex("NivelAcessoId");

                    b.HasIndex("StatusId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("WebApplication1.Models.UsuarioConhecimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Atualizado_em");

                    b.Property<int>("ConhecimentoId");

                    b.Property<DateTime>("Criado_em");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("ConhecimentoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioConhecimento");
                });

            modelBuilder.Entity("WebApplication1.Models.Arquivo", b =>
                {
                    b.HasOne("WebApplication1.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebApplication1.Models.Cargo", b =>
                {
                    b.HasOne("WebApplication1.Models.Departamento", "Departamento")
                        .WithMany("Cargos")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebApplication1.Models.CertCurso", b =>
                {
                    b.HasOne("WebApplication1.Models.Usuario", "Usuario")
                        .WithMany("CertCursos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebApplication1.Models.Contato", b =>
                {
                    b.HasOne("WebApplication1.Models.Usuario", "Usuario")
                        .WithMany("Contatos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebApplication1.Models.Departamento", b =>
                {
                    b.HasOne("WebApplication1.Models.Area", "Area")
                        .WithMany("Departamentos")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebApplication1.Models.Endereco", b =>
                {
                    b.HasOne("WebApplication1.Models.Usuario", "Usuario")
                        .WithOne("Endereco")
                        .HasForeignKey("WebApplication1.Models.Endereco", "UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebApplication1.Models.ExpProfissional", b =>
                {
                    b.HasOne("WebApplication1.Models.Usuario", "Usuario")
                        .WithMany("ExpProfissionais")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebApplication1.Models.FormAcademica", b =>
                {
                    b.HasOne("WebApplication1.Models.Usuario", "Usuario")
                        .WithMany("FormAcademicas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebApplication1.Models.Gestor", b =>
                {
                    b.HasOne("WebApplication1.Models.Departamento", "Departamento")
                        .WithMany("Gestores")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebApplication1.Models.Usuario", "Usuario")
                        .WithMany("Gestores")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebApplication1.Models.Idioma", b =>
                {
                    b.HasOne("WebApplication1.Models.Usuario", "Usuario")
                        .WithMany("Idiomas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebApplication1.Models.Resumo", b =>
                {
                    b.HasOne("WebApplication1.Models.Usuario", "Usuario")
                        .WithOne("Resumo")
                        .HasForeignKey("WebApplication1.Models.Resumo", "UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebApplication1.Models.Usuario", b =>
                {
                    b.HasOne("WebApplication1.Models.Cargo", "Cargo")
                        .WithMany("Usuarios")
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebApplication1.Models.NivelAcesso", "NivelAcesso")
                        .WithMany()
                        .HasForeignKey("NivelAcessoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebApplication1.Models.Status", "Status")
                        .WithMany("Usuarios")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebApplication1.Models.UsuarioConhecimento", b =>
                {
                    b.HasOne("WebApplication1.Models.Conhecimento", "Conhecimento")
                        .WithMany("UsuarioConhecimentos")
                        .HasForeignKey("ConhecimentoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebApplication1.Models.Usuario", "Usuario")
                        .WithMany("UsuarioConhecimentos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
