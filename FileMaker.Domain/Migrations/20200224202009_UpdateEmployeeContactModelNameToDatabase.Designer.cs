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
    [Migration("20200224202009_UpdateEmployeeContactModelNameToDatabase")]
    partial class UpdateEmployeeContactModelNameToDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FileMaker.Domain.Models.BankInfo", b =>
                {
                    b.Property<int>("BankInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountName")
                        .HasColumnType("int");

                    b.Property<string>("AccountNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeNumber")
                        .HasColumnType("int");

                    b.Property<string>("Iban")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SortCode")
                        .HasColumnType("int");

                    b.HasKey("BankInfoId");

                    b.HasIndex("EmployeeNumber")
                        .IsUnique();

                    b.ToTable("BankInfos");
                });

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

            modelBuilder.Entity("FileMaker.Domain.Models.ClientPayment", b =>
                {
                    b.Property<int>("ClientPaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientCode")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfReferral")
                        .HasColumnType("datetime2");

                    b.Property<string>("GpsAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GpsName")
                        .HasColumnType("int");

                    b.Property<string>("GpsNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OtherReqirments")
                        .HasColumnType("int");

                    b.Property<string>("ReasonForRefrral")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReferralBy")
                        .HasColumnType("int");

                    b.Property<int>("ReferralFor")
                        .HasColumnType("int");

                    b.Property<string>("ReferralTel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Therapist")
                        .HasColumnType("int");

                    b.HasKey("ClientPaymentId");

                    b.HasIndex("ClientCode")
                        .IsUnique();

                    b.ToTable("ClientPayments");
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

            modelBuilder.Entity("FileMaker.Domain.Models.Degree", b =>
                {
                    b.Property<int>("DegreeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DegreeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DegreeId");

                    b.ToTable("Degrees");
                });

            modelBuilder.Entity("FileMaker.Domain.Models.Education", b =>
                {
                    b.Property<int>("EducationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EducationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EducationId");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("FileMaker.Domain.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EducationId")
                        .HasColumnType("int");

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

                    b.Property<string>("PassportNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SexualOrientation")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Title")
                        .HasColumnType("int");

                    b.HasKey("EmployeeNumber");

                    b.HasIndex("EducationId");

                    b.HasIndex("LanguageId");

                    b.HasIndex("OriginId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("FileMaker.Domain.Models.EmployeeAddress", b =>
                {
                    b.Property<int>("EmployeeAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressOne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressTwo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("City")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeNumber")
                        .HasColumnType("int");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Town")
                        .HasColumnType("int");

                    b.HasKey("EmployeeAddressId");

                    b.HasIndex("EmployeeNumber")
                        .IsUnique();

                    b.ToTable("EmployeeAddresses");
                });

            modelBuilder.Entity("FileMaker.Domain.Models.EmployeeContact", b =>
                {
                    b.Property<int>("EmployeeContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContactType")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeNumber")
                        .HasColumnType("int");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OkToContact")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeContactId");

                    b.HasIndex("EmployeeNumber")
                        .IsUnique();

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("FileMaker.Domain.Models.EmployeeDegree", b =>
                {
                    b.Property<int>("EmployeeNumber")
                        .HasColumnType("int");

                    b.Property<int>("DegreeId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeNumber", "DegreeId");

                    b.HasIndex("DegreeId");

                    b.ToTable("EmployeeDegree");
                });

            modelBuilder.Entity("FileMaker.Domain.Models.EmployeeEmergencyContact", b =>
                {
                    b.Property<int>("EmployeeEmergenctContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Relation")
                        .HasColumnType("int");

                    b.HasKey("EmployeeEmergenctContactId");

                    b.HasIndex("EmployeeNumber")
                        .IsUnique();

                    b.ToTable("EmployeeEmergencyContacts");
                });

            modelBuilder.Entity("FileMaker.Domain.Models.EmployeeRecruitment", b =>
                {
                    b.Property<int>("EmployeeRecruitmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateLeft")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DatePensionStarted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateStarted")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeNumber")
                        .HasColumnType("int");

                    b.Property<string>("InsuarenceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Relationship")
                        .HasColumnType("int");

                    b.Property<int>("TypeOfEmployment")
                        .HasColumnType("int");

                    b.HasKey("EmployeeRecruitmentId");

                    b.HasIndex("EmployeeNumber")
                        .IsUnique();

                    b.ToTable("EmployeeRecruitments");
                });

            modelBuilder.Entity("FileMaker.Domain.Models.EmployeeSkill", b =>
                {
                    b.Property<int>("EmployeeNumber")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeNumber", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("EmployeeSkill");
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

            modelBuilder.Entity("FileMaker.Domain.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeNumber")
                        .HasColumnType("int");

                    b.Property<int>("PaymentFrequency")
                        .HasColumnType("int");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.HasKey("PaymentId");

                    b.HasIndex("EmployeeNumber")
                        .IsUnique();

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("FileMaker.Domain.Models.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SkillName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SkillId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("FileMaker.Domain.Models.Work", b =>
                {
                    b.Property<int>("WorkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Department")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeNumber")
                        .HasColumnType("int");

                    b.Property<int>("Hour")
                        .HasColumnType("int");

                    b.Property<int>("JobTitle")
                        .HasColumnType("int");

                    b.Property<int>("Shift")
                        .HasColumnType("int");

                    b.Property<string>("TimecardNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Unit")
                        .HasColumnType("int");

                    b.HasKey("WorkId");

                    b.HasIndex("EmployeeNumber")
                        .IsUnique();

                    b.ToTable("Works");
                });

            modelBuilder.Entity("FileMaker.Domain.Models.BankInfo", b =>
                {
                    b.HasOne("FileMaker.Domain.Models.Employee", "Employee")
                        .WithOne("BankInfo")
                        .HasForeignKey("FileMaker.Domain.Models.BankInfo", "EmployeeNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("FileMaker.Domain.Models.ClientPayment", b =>
                {
                    b.HasOne("FileMaker.Domain.Models.Client", "Client")
                        .WithOne("ClientPayment")
                        .HasForeignKey("FileMaker.Domain.Models.ClientPayment", "ClientCode")
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

            modelBuilder.Entity("FileMaker.Domain.Models.Employee", b =>
                {
                    b.HasOne("FileMaker.Domain.Models.Education", "Education")
                        .WithMany("Employees")
                        .HasForeignKey("EducationId");

                    b.HasOne("FileMaker.Domain.Models.Language", "Language")
                        .WithMany("Employees")
                        .HasForeignKey("LanguageId");

                    b.HasOne("FileMaker.Domain.Models.Origin", "Origin")
                        .WithMany("Employees")
                        .HasForeignKey("OriginId");
                });

            modelBuilder.Entity("FileMaker.Domain.Models.EmployeeAddress", b =>
                {
                    b.HasOne("FileMaker.Domain.Models.Employee", "Employee")
                        .WithOne("EmployeeAddress")
                        .HasForeignKey("FileMaker.Domain.Models.EmployeeAddress", "EmployeeNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FileMaker.Domain.Models.EmployeeContact", b =>
                {
                    b.HasOne("FileMaker.Domain.Models.Employee", "Employee")
                        .WithOne("EmployeetContact")
                        .HasForeignKey("FileMaker.Domain.Models.EmployeeContact", "EmployeeNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FileMaker.Domain.Models.EmployeeDegree", b =>
                {
                    b.HasOne("FileMaker.Domain.Models.Degree", "Degree")
                        .WithMany("EmployeeDegrees")
                        .HasForeignKey("DegreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FileMaker.Domain.Models.Employee", "Employee")
                        .WithMany("EmployeeDegrees")
                        .HasForeignKey("EmployeeNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FileMaker.Domain.Models.EmployeeEmergencyContact", b =>
                {
                    b.HasOne("FileMaker.Domain.Models.Employee", "Employee")
                        .WithOne("EmployeeEmergencyContact")
                        .HasForeignKey("FileMaker.Domain.Models.EmployeeEmergencyContact", "EmployeeNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FileMaker.Domain.Models.EmployeeRecruitment", b =>
                {
                    b.HasOne("FileMaker.Domain.Models.Employee", "Employee")
                        .WithOne("EmployeeRecruitment")
                        .HasForeignKey("FileMaker.Domain.Models.EmployeeRecruitment", "EmployeeNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FileMaker.Domain.Models.EmployeeSkill", b =>
                {
                    b.HasOne("FileMaker.Domain.Models.Employee", "Employee")
                        .WithMany("EmployeeSkills")
                        .HasForeignKey("EmployeeNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FileMaker.Domain.Models.Skill", "Skill")
                        .WithMany("EmployeeSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FileMaker.Domain.Models.Payment", b =>
                {
                    b.HasOne("FileMaker.Domain.Models.Employee", "Employee")
                        .WithOne("Payment")
                        .HasForeignKey("FileMaker.Domain.Models.Payment", "EmployeeNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FileMaker.Domain.Models.Work", b =>
                {
                    b.HasOne("FileMaker.Domain.Models.Employee", "Employee")
                        .WithOne("Work")
                        .HasForeignKey("FileMaker.Domain.Models.Work", "EmployeeNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
