﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Domain.Models;

namespace Domain.Data
{
    public partial class ButtlerContext : DbContext
    {
        public ButtlerContext()
        {
        }

        public ButtlerContext(DbContextOptions<ButtlerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Foods> Foods { get; set; }
        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<OrderMaster> OrderMaster { get; set; }
        public virtual DbSet<StaffDetails> StaffDetails { get; set; }
        public virtual DbSet<StaffSqs> StaffSqs { get; set; }
        public virtual DbSet<Staffs> Staffs { get; set; }
        public virtual DbSet<Tables> Tables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=tcp:test-server-buttler.database.windows.net,1433;Initial Catalog=Test_DB;Persist Security Info=False;User ID=test;Password=barsha@2000;Multiple Active Result Sets=False;Connect Timeout=30;Encrypt=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerGender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerPhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Foods>(entity =>
            {
                entity.HasKey(e => e.FoodId);

                entity.Property(e => e.FoodImg).IsUnicode(false);

                entity.Property(e => e.FoodPlateSize)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderItems>(entity =>
            {
                entity.HasOne(d => d.Food)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.FoodId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_OrderItems_Foods");

                entity.HasOne(d => d.OrderMaster)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderMasterId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_OrderItems_OrderMaster");
            });

            modelBuilder.Entity<OrderMaster>(entity =>
            {
                entity.Property(e => e.Bill).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.OrderStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StaffId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderMaster)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_OrderMaster_Customer");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.OrderMaster)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_OrderMaster_Staffs");

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.OrderMaster)
                    .HasForeignKey(d => d.TableId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_OrderMaster_Tables");
            });

            modelBuilder.Entity<StaffDetails>(entity =>
            {
                entity.HasKey(e => e.StaffId);

                entity.Property(e => e.StaffId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StaffAddress)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.StaffDob)
                    .HasColumnType("datetime")
                    .HasColumnName("StaffDOB");

                entity.Property(e => e.StaffGender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StaffName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StaffPhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Staff)
                    .WithOne(p => p.StaffDetails)
                    .HasForeignKey<StaffDetails>(d => d.StaffId)
                    .HasConstraintName("FK_StaffDetails_Staffs");
            });

            modelBuilder.Entity<StaffSqs>(entity =>
            {
                entity.HasKey(e => e.StaffSq)
                    .HasName("PK__StaffSQs__96D458B981F9354E");

                entity.ToTable("StaffSQs");

                entity.Property(e => e.StaffSq)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("StaffSQ");
            });

            modelBuilder.Entity<Staffs>(entity =>
            {
                entity.HasKey(e => e.StaffId);

                entity.Property(e => e.StaffId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StaffLastLogin).HasColumnType("datetime");

                entity.Property(e => e.StaffPwd)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StaffSa)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("StaffSA");

                entity.Property(e => e.StaffSq)
                    .IsUnicode(false)
                    .HasColumnName("StaffSQ");

                entity.Property(e => e.StaffType)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tables>(entity =>
            {
                entity.HasKey(e => e.TableId);

                entity.Property(e => e.TableNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Tables)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Tables_Customer");
            });

            modelBuilder.HasSequence<int>("SalesOrderNumber", "SalesLT");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}