﻿// <auto-generated />
using System;
using FileMaker.Domain.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FileMaker.Domain.Migrations
{
    [DbContext(typeof(FileMakerFinalContext))]
    [Migration("20200220123321_AddClientExtraInformationModelToDatabase")]
    partial class AddClientExtraInformationModelToDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FileMaker.Domain.Models.Client", b =>
                {
                    b.Property<int>("ClientCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientCategory")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int?>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NickName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OriginId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Relation")
                        .HasColumnType("int");

                    b.Property<int>("Salesman")
                        .HasColumnType("int");

                    b.Property<int>("SexualOrientation")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Title")
                        .HasColumnType("int");

                    b.HasKey("ClientCode");

                    b.HasIndex("LanguageId");

                    b.HasIndex("OriginId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("FileMaker.Domain.Models.ClientAddress", b =>
                {
                    b.Property<int>("ClientAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BussinesAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("City")
                        .HasColumnType("int");

                    b.Property<int>("ClientCode")
                        .HasColumnType("int");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Town")
                        .HasColumnType("int");

                    b.HasKey("ClientAddressId");

                    b.HasIndex("ClientCode")
                        .IsUnique();

                    b.ToTable("ClientAddresses");
                });

            modelBuilder.Entity("FileMaker.Domain.Models.ClientContact", b =>
                {
                    b.Property<int>("ClientContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientCode")
                        .HasColumnType("int");

                    b.Property<int>("ContactType")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OkToContact")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientContactId");

                    b.HasIndex("ClientCode")
                        .IsUnique();

                    b.ToTable("ClientContacts");
                });

            modelBuilder.Entity("FileMaker.Domain.Models.ClientDeliveryAddress", b =>
                {
                    b.Property<int>("ClientDeliveryAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClientCode")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Town")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientDeliveryAddressId");

                    b.HasIndex("ClientCode")
                        .IsUnique();

                    b.ToTable("ClientDeliveryAddresses");
                });

            modelBuilder.Entity("FileMaker.Domain.Models.ClientExtraInformation", b =>
                {
                    b.Property<int>("ClientExtraInformationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientCode")
                        .HasColumnType("int");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ntk")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RelationShip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientExtraInformationId");

                    b.HasIndex("ClientCode")
                        .IsUnique();

                    b.ToTable("ClientExtraInformations");
                });

            modelBuilder.Entity("FileMaker.Domain.Models.ClientPurchase", b =>
                {
                    b.Property<int>("ClientPurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Balance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClientCode")
                        .HasColumnType("int");

                    b.Property<string>("Credit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentTerms")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pricing")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vat")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientPurchaseId");

                    b.HasIndex("ClientCode")
                        .IsUnique();

                    b.ToTable("ClientPurchases");
                });

            modelBuilder.Entity("FileMaker.Domain.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LanguageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("FileMaker.Domain.Models.Origin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OriginName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Origins");
                });

            modelBuilder.Entity("FileMaker.Domain.Models.Client", b =>
                {
                    b.HasOne("FileMaker.Domain.Models.Language", "Language")
                        .WithMany("Client")
                        .HasForeignKey("LanguageId");

                    b.HasOne("FileMaker.Domain.Models.Origin", "Origin")
                        .WithMany("Clients")
                        .HasForeignKey("OriginId");
                });

            modelBuilder.Entity("FileMaker.Domain.Models.ClientAddress", b =>
                {
                    b.HasOne("FileMaker.Domain.Models.Client", "Client")
                        .WithOne("ClientAddress")
                        .HasForeignKey("FileMaker.Domain.Models.ClientAddress", "ClientCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FileMaker.Domain.Models.ClientContact", b =>
                {
                    b.HasOne("FileMaker.Domain.Models.Client", "Client")
                        .WithOne("ClientContact")
                        .HasForeignKey("FileMaker.Domain.Models.ClientContact", "ClientCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FileMaker.Domain.Models.ClientDeliveryAddress", b =>
                {
                    b.HasOne("FileMaker.Domain.Models.Client", "Client")
                        .WithOne("ClientDeliveryAddress")
                        .HasForeignKey("FileMaker.Domain.Models.ClientDeliveryAddress", "ClientCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FileMaker.Domain.Models.ClientExtraInformation", b =>
                {
                    b.HasOne("FileMaker.Domain.Models.Client", "Client")
                        .WithOne("ClientExtraInformation")
                        .HasForeignKey("FileMaker.Domain.Models.ClientExtraInformation", "ClientCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FileMaker.Domain.Models.ClientPurchase", b =>
                {
                    b.HasOne("FileMaker.Domain.Models.Client", "Client")
                        .WithOne("ClientPurchase")
                        .HasForeignKey("FileMaker.Domain.Models.ClientPurchase", "ClientCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
