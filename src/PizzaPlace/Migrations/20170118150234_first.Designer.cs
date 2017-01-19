using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PizzaPlace.Entities;

namespace PizzaPlace.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20170118150234_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PizzaPlace.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountName");

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<int>("PremiumCoins");

                    b.Property<int?>("RoleId");

                    b.Property<string>("Zip");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PizzaPlace.Entities.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("FoodTypeId");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("FoodTypeId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("PizzaPlace.Entities.FoodIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FoodId");

                    b.Property<int?>("IngredientId");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("IngredientId");

                    b.ToTable("FoodIngredients");
                });

            modelBuilder.Entity("PizzaPlace.Entities.FoodOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FoodId");

                    b.Property<int?>("OrderId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("OrderId");

                    b.ToTable("FoodOrders");
                });

            modelBuilder.Entity("PizzaPlace.Entities.FoodType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("FoodTypes");
                });

            modelBuilder.Entity("PizzaPlace.Entities.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IngredientName");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("PizzaPlace.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Cost");

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime>("OrderDate");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PizzaPlace.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Discount");

                    b.Property<int>("UserRole");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("PizzaPlace.Entities.Customer", b =>
                {
                    b.HasOne("PizzaPlace.Entities.Role", "Role")
                        .WithMany("Customers")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("PizzaPlace.Entities.Food", b =>
                {
                    b.HasOne("PizzaPlace.Entities.FoodType", "FoodType")
                        .WithMany("Foods")
                        .HasForeignKey("FoodTypeId");
                });

            modelBuilder.Entity("PizzaPlace.Entities.FoodIngredient", b =>
                {
                    b.HasOne("PizzaPlace.Entities.Food", "Food")
                        .WithMany("FoodIngredients")
                        .HasForeignKey("FoodId");

                    b.HasOne("PizzaPlace.Entities.Ingredient", "Ingredient")
                        .WithMany("FoodIngredients")
                        .HasForeignKey("IngredientId");
                });

            modelBuilder.Entity("PizzaPlace.Entities.FoodOrder", b =>
                {
                    b.HasOne("PizzaPlace.Entities.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId");

                    b.HasOne("PizzaPlace.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("PizzaPlace.Entities.Order", b =>
                {
                    b.HasOne("PizzaPlace.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId");
                });
        }
    }
}
