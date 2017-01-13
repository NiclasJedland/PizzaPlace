using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PizzaPlace.Entities;

namespace PizzaPlace.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20170113103148_first")]
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

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PizzaPlace.Entities.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("Price");

                    b.Property<int>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("PizzaPlace.Entities.FoodIngredients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FoodId");

                    b.Property<int>("IngredientId");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("IngredientId");

                    b.ToTable("FoodIngredients");
                });

            modelBuilder.Entity("PizzaPlace.Entities.FoodType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("FoodTypes");
                });

            modelBuilder.Entity("PizzaPlace.Entities.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IngredientName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("PizzaPlace.Entities.Food", b =>
                {
                    b.HasOne("PizzaPlace.Entities.FoodType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PizzaPlace.Entities.FoodIngredients", b =>
                {
                    b.HasOne("PizzaPlace.Entities.Food", "Food")
                        .WithMany("FoodIngredients")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PizzaPlace.Entities.Ingredient", "Ingredient")
                        .WithMany("FoodIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
