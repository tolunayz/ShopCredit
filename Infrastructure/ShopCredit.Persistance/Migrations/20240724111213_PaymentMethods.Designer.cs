﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopCredit.Infrastructure.Context;

#nullable disable

namespace ShopCredit.Infrastructure.Migrations
{
    [DbContext(typeof(ShopCreditContext))]
    [Migration("20240724111213_PaymentMethods")]
    partial class PaymentMethods
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShopCredit.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ShopCredit.Entities.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"));

                    b.Property<string>("AdminName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("ShopCredit.Entities.CustomerAccPayment", b =>
                {
                    b.Property<int>("PaymetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymetID"));

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<long>("CurrentDebt")
                        .HasColumnType("bigint");

                    b.Property<int?>("CustomerAccountAccountId")
                        .HasColumnType("int");

                    b.Property<long>("PaidDebt")
                        .HasColumnType("bigint");

                    b.Property<string>("PaymetMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TotalDebt")
                        .HasColumnType("bigint");

                    b.HasKey("PaymetID");

                    b.HasIndex("CustomerAccountAccountId");

                    b.ToTable("CustomerAccPaymentS");
                });

            modelBuilder.Entity("ShopCredit.Entities.CustomerAccount", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DebtDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.HasKey("AccountId");

                    b.HasIndex("CustomerID");

                    b.ToTable("CustomersAccounts");
                });

            modelBuilder.Entity("ShopCredit.Entities.CustomerAccPayment", b =>
                {
                    b.HasOne("ShopCredit.Entities.CustomerAccount", "CustomerAccount")
                        .WithMany()
                        .HasForeignKey("CustomerAccountAccountId");

                    b.Navigation("CustomerAccount");
                });

            modelBuilder.Entity("ShopCredit.Entities.CustomerAccount", b =>
                {
                    b.HasOne("ShopCredit.Domain.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });
#pragma warning restore 612, 618
        }
    }
}
