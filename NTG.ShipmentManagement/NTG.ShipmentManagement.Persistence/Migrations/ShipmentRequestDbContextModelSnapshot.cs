﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NTG.ShipmentManagement.Persistence;

#nullable disable

namespace NTG.ShipmentManagement.Persistence.Migrations
{
    [DbContext(typeof(ShipmentRequestDbContext))]
    partial class ShipmentRequestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NTG.ShipmentManagement.Domain.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Suburb")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Address");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Address");
                });

            modelBuilder.Entity("NTG.ShipmentManagement.Domain.ShipmentRequest.ShipmentOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeliveryAddressId")
                        .HasColumnType("int");

                    b.Property<string>("DeliveryInstruction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrdetId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PickupAddressId")
                        .HasColumnType("int");

                    b.Property<string>("PickupInstruction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RequestedPickupTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryAddressId");

                    b.HasIndex("PickupAddressId");

                    b.ToTable("ShipmentOrder");
                });

            modelBuilder.Entity("NTG.ShipmentManagement.Domain.ShipmentRequest.ShipmentOrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ItemCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("ShipmentOrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShipmentOrderId");

                    b.ToTable("ShipmentOrderItem");
                });

            modelBuilder.Entity("NTG.ShipmentManagement.Domain.ShipmentRequest.DeliveryAddress", b =>
                {
                    b.HasBaseType("NTG.ShipmentManagement.Domain.Address");

                    b.ToTable("Address");

                    b.HasDiscriminator().HasValue("DeliveryAddress");
                });

            modelBuilder.Entity("NTG.ShipmentManagement.Domain.ShipmentRequest.PickupAddress", b =>
                {
                    b.HasBaseType("NTG.ShipmentManagement.Domain.Address");

                    b.ToTable("Address");

                    b.HasDiscriminator().HasValue("PickupAddress");
                });

            modelBuilder.Entity("NTG.ShipmentManagement.Domain.ShipmentRequest.ShipmentOrder", b =>
                {
                    b.HasOne("NTG.ShipmentManagement.Domain.ShipmentRequest.DeliveryAddress", "DeliveryAddress")
                        .WithMany()
                        .HasForeignKey("DeliveryAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NTG.ShipmentManagement.Domain.ShipmentRequest.PickupAddress", "PickupAddress")
                        .WithMany()
                        .HasForeignKey("PickupAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeliveryAddress");

                    b.Navigation("PickupAddress");
                });

            modelBuilder.Entity("NTG.ShipmentManagement.Domain.ShipmentRequest.ShipmentOrderItem", b =>
                {
                    b.HasOne("NTG.ShipmentManagement.Domain.ShipmentRequest.ShipmentOrder", null)
                        .WithMany("ShipmentOrderItems")
                        .HasForeignKey("ShipmentOrderId");
                });

            modelBuilder.Entity("NTG.ShipmentManagement.Domain.ShipmentRequest.ShipmentOrder", b =>
                {
                    b.Navigation("ShipmentOrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}