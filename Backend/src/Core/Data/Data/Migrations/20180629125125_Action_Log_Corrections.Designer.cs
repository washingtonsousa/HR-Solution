﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Core.Data.ORM;
using System;

namespace RiscServicesHRSharepointAddIn.Migrations
{
    [DbContext(typeof(HrDbContext))]
    [Migration("20180629125125_Action_Log_Corrections")]
    partial class Action_Log_Corrections
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Data.Models.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Atualizado_em");

                    b.Property<DateTime>("Criado_em");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("Core.Data.Models.Arquivo", b =>
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

            modelBuilder.Entity("Core.Data.Models.Cargo", b =>
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

            modelBuilder.Entity("Core.Data.Models.CertCurso", b =>
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

            modelBuilder.Entity("Core.Data.Models.Config", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key")
                        .IsRequired();

                    b.Property<string>("Value")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Key")
                        .IsUnique();

                    b.ToTable("ConfigOptions");
                });

            modelBuilder.Entity("Core.Data.Models.Conhecimento", b =>
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

            modelBuilder.Entity("Core.Data.Models.Contato", b =>
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

            modelBuilder.Entity("Core.Data.Models.Departamento", b =>
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

            modelBuilder.Entity("Core.Data.Models.Endereco", b =>
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

            modelBuilder.Entity("Core.Data.Models.ExpProfissional", b =>
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

            modelBuilder.Entity("Core.Data.Models.FormAcademica", b =>
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

            modelBuilder.Entity("Core.Data.Models.Gestor", b =>
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

            modelBuilder.Entity("Core.Data.Models.Idioma", b =>
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

            modelBuilder.Entity("Core.Data.Models.Log_Action", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action_Dest");

                    b.Property<string>("Action_Details")
                        .HasColumnType("text");

                    b.Property<string>("Action_Type");

                    b.Property<DateTime>("Data_Acesso");

                    b.Property<string>("Host_Address");

                    b.Property<string>("Matricula_Usuario")
                        .IsRequired();

                    b.Property<string>("Usuario")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Log_Actions");
                });

            modelBuilder.Entity("Core.Data.Models.NivelAcesso", b =>
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

            modelBuilder.Entity("Core.Data.Models.Resumo", b =>
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

            modelBuilder.Entity("Core.Data.Models.Status", b =>
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

            modelBuilder.Entity("Core.Data.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Atualizado_em");

                    b.Property<int>("CargoId");

                    b.Property<DateTime>("Criado_em");

                    b.Property<DateTime>("DataAdmissao");

                    b.Property<DateTime>("DataNasc");

                    b.Property<DateTime>("Data_Demissao");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("EstadoCivil")
                        .IsRequired();

                    b.Property<string>("Matricula");

                    b.Property<int>("NivelAcessoId");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<long?>("Ramal")
                        .IsRequired();

                    b.Property<int?>("StatusId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Matricula")
                        .IsUnique()
                        .HasFilter("[Matricula] IS NOT NULL");

                    b.HasIndex("NivelAcessoId");

                    b.HasIndex("StatusId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Core.Data.Models.UsuarioConhecimento", b =>
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

            modelBuilder.Entity("Core.Data.Models.Arquivo", b =>
                {
                    b.HasOne("Core.Data.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Core.Data.Models.Cargo", b =>
                {
                    b.HasOne("Core.Data.Models.Departamento", "Departamento")
                        .WithMany("Cargos")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Core.Data.Models.CertCurso", b =>
                {
                    b.HasOne("Core.Data.Models.Usuario", "Usuario")
                        .WithMany("CertCursos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Core.Data.Models.Contato", b =>
                {
                    b.HasOne("Core.Data.Models.Usuario", "Usuario")
                        .WithMany("Contatos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Core.Data.Models.Departamento", b =>
                {
                    b.HasOne("Core.Data.Models.Area", "Area")
                        .WithMany("Departamentos")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Core.Data.Models.Endereco", b =>
                {
                    b.HasOne("Core.Data.Models.Usuario", "Usuario")
                        .WithOne("Endereco")
                        .HasForeignKey("Core.Data.Models.Endereco", "UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Core.Data.Models.ExpProfissional", b =>
                {
                    b.HasOne("Core.Data.Models.Usuario", "Usuario")
                        .WithMany("ExpProfissionais")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Core.Data.Models.FormAcademica", b =>
                {
                    b.HasOne("Core.Data.Models.Usuario", "Usuario")
                        .WithMany("FormAcademicas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Core.Data.Models.Gestor", b =>
                {
                    b.HasOne("Core.Data.Models.Departamento", "Departamento")
                        .WithMany("Gestores")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Core.Data.Models.Usuario", "Usuario")
                        .WithMany("Gestores")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Core.Data.Models.Idioma", b =>
                {
                    b.HasOne("Core.Data.Models.Usuario", "Usuario")
                        .WithMany("Idiomas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Core.Data.Models.Resumo", b =>
                {
                    b.HasOne("Core.Data.Models.Usuario", "Usuario")
                        .WithOne("Resumo")
                        .HasForeignKey("Core.Data.Models.Resumo", "UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Core.Data.Models.Usuario", b =>
                {
                    b.HasOne("Core.Data.Models.Cargo", "Cargo")
                        .WithMany("Usuarios")
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Core.Data.Models.NivelAcesso", "NivelAcesso")
                        .WithMany()
                        .HasForeignKey("NivelAcessoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Core.Data.Models.Status", "Status")
                        .WithMany("Usuarios")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Core.Data.Models.UsuarioConhecimento", b =>
                {
                    b.HasOne("Core.Data.Models.Conhecimento", "Conhecimento")
                        .WithMany("UsuarioConhecimentos")
                        .HasForeignKey("ConhecimentoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Core.Data.Models.Usuario", "Usuario")
                        .WithMany("UsuarioConhecimentos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
