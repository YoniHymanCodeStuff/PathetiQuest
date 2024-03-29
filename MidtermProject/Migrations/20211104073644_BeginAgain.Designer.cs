﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MidtermProject.EF;

namespace MidtermProject.Migrations
{
    [DbContext(typeof(DBC))]
    [Migration("20211104073644_BeginAgain")]
    partial class BeginAgain
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AbilityUnit", b =>
                {
                    b.Property<int>("AbilitiesId")
                        .HasColumnType("int");

                    b.Property<int>("units_with_abilityId")
                        .HasColumnType("int");

                    b.HasKey("AbilitiesId", "units_with_abilityId");

                    b.HasIndex("units_with_abilityId");

                    b.ToTable("AbilityUnit");
                });

            modelBuilder.Entity("HeroItem", b =>
                {
                    b.Property<int>("InventoryId")
                        .HasColumnType("int");

                    b.Property<int>("Owning_HeroesId")
                        .HasColumnType("int");

                    b.HasKey("InventoryId", "Owning_HeroesId");

                    b.HasIndex("Owning_HeroesId");

                    b.ToTable("HeroItem");
                });

            modelBuilder.Entity("Hero_NamePlayer", b =>
                {
                    b.Property<int>("Names_UsedId")
                        .HasColumnType("int");

                    b.Property<int>("PlayersId")
                        .HasColumnType("int");

                    b.HasKey("Names_UsedId", "PlayersId");

                    b.HasIndex("PlayersId");

                    b.ToTable("Hero_NamePlayer");
                });

            modelBuilder.Entity("MidtermProject.Model.Ability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AOE")
                        .HasColumnType("bit");

                    b.Property<double>("Alter_Accuracy")
                        .HasColumnType("float");

                    b.Property<double>("Alter_Armor")
                        .HasColumnType("float");

                    b.Property<double>("Alter_HP")
                        .HasColumnType("float");

                    b.Property<double>("Alter_Magic_Resistance")
                        .HasColumnType("float");

                    b.Property<double>("Alter_Mana")
                        .HasColumnType("float");

                    b.Property<double>("Alter_Speed")
                        .HasColumnType("float");

                    b.Property<double>("Alter_Spell_Power")
                        .HasColumnType("float");

                    b.Property<double>("Alter_Strength")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TargetEnemies")
                        .HasColumnType("bit");

                    b.Property<string>("verb")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Abilities");
                });

            modelBuilder.Entity("MidtermProject.Model.Encounter_Intro_Text", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Intro_Texts");
                });

            modelBuilder.Entity("MidtermProject.Model.Hero_Name", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hero_Names");
                });

            modelBuilder.Entity("MidtermProject.Model.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Accuracy_Bonus")
                        .HasColumnType("float");

                    b.Property<double>("Armor_Bonus")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("HP_Bonus")
                        .HasColumnType("float");

                    b.Property<double>("Magic_Resistance_Bonus")
                        .HasColumnType("float");

                    b.Property<double>("Mana_Bonus")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Speed_Bonus")
                        .HasColumnType("float");

                    b.Property<double>("Spell_Power_Bonus")
                        .HasColumnType("float");

                    b.Property<double>("Strength_Bonus")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("MidtermProject.Model.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("MidtermProject.Model.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Accuracy")
                        .HasColumnType("float");

                    b.Property<double>("Armor")
                        .HasColumnType("float");

                    b.Property<double>("HP")
                        .HasColumnType("float");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<double>("Magic_Resistance")
                        .HasColumnType("float");

                    b.Property<double>("Mana")
                        .HasColumnType("float");

                    b.Property<double>("Speed")
                        .HasColumnType("float");

                    b.Property<double>("Spell_Power")
                        .HasColumnType("float");

                    b.Property<double>("Strength")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Unit");
                });

            modelBuilder.Entity("MidtermProject.Model.EnemyType", b =>
                {
                    b.HasBaseType("MidtermProject.Model.Unit");

                    b.Property<string>("CreatureType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IntroText")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Enemy Types");
                });

            modelBuilder.Entity("MidtermProject.Model.HeroType", b =>
                {
                    b.HasBaseType("MidtermProject.Model.Unit");

                    b.Property<string>("ClassName")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Hero Types");
                });

            modelBuilder.Entity("MidtermProject.Model.Hero", b =>
                {
                    b.HasBaseType("MidtermProject.Model.HeroType");

                    b.Property<double>("CurrentExp")
                        .HasColumnType("float");

                    b.Property<int?>("Player")
                        .HasColumnType("int");

                    b.Property<string>("ProperName")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("Player");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("AbilityUnit", b =>
                {
                    b.HasOne("MidtermProject.Model.Ability", null)
                        .WithMany()
                        .HasForeignKey("AbilitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MidtermProject.Model.Unit", null)
                        .WithMany()
                        .HasForeignKey("units_with_abilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HeroItem", b =>
                {
                    b.HasOne("MidtermProject.Model.Item", null)
                        .WithMany()
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MidtermProject.Model.Hero", null)
                        .WithMany()
                        .HasForeignKey("Owning_HeroesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hero_NamePlayer", b =>
                {
                    b.HasOne("MidtermProject.Model.Hero_Name", null)
                        .WithMany()
                        .HasForeignKey("Names_UsedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MidtermProject.Model.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MidtermProject.Model.EnemyType", b =>
                {
                    b.HasOne("MidtermProject.Model.Unit", null)
                        .WithOne()
                        .HasForeignKey("MidtermProject.Model.EnemyType", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MidtermProject.Model.HeroType", b =>
                {
                    b.HasOne("MidtermProject.Model.Unit", null)
                        .WithOne()
                        .HasForeignKey("MidtermProject.Model.HeroType", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MidtermProject.Model.Hero", b =>
                {
                    b.HasOne("MidtermProject.Model.HeroType", null)
                        .WithOne()
                        .HasForeignKey("MidtermProject.Model.Hero", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("MidtermProject.Model.Player", "player")
                        .WithMany("Heroes")
                        .HasForeignKey("Player");

                    b.Navigation("player");
                });

            modelBuilder.Entity("MidtermProject.Model.Player", b =>
                {
                    b.Navigation("Heroes");
                });
#pragma warning restore 612, 618
        }
    }
}
