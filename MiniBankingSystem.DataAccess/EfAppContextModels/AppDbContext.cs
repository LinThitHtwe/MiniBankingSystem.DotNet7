﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MiniBankingSystem.DataAccess.EfAppContextModels;

namespace MiniBankingSystem.DataAccess.EfAppContextModels;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAccount> TblAccounts { get; set; }

    public virtual DbSet<TblAdminUser> TblAdminUsers { get; set; }

    public virtual DbSet<TblPlaceState> TblPlaceStates { get; set; }

    public virtual DbSet<TblPlaceTownship> TblPlaceTownships { get; set; }

    public virtual DbSet<TblTransactionHistory> TblTransactionHistories { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=BankingManagementSystem;User Id=sa;Password=root;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAccount>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK_Account");

            entity.ToTable("Tbl_Account");

            entity.Property(e => e.AccountNo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasComputedColumnSql("(right('000000'+CONVERT([varchar](6),[AccountId]),(6)))", false);
            entity.Property(e => e.Balance).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.CustomerCode).HasMaxLength(50);
            entity.Property(e => e.CustomerName).HasMaxLength(50);
        });

        modelBuilder.Entity<TblAdminUser>(entity =>
        {
            entity.HasKey(e => e.AdminUserId).HasName("PK_Tbl_Employee");

            entity.ToTable("Tbl_AdminUser");

            entity.Property(e => e.AdminUserCode).HasMaxLength(50);
            entity.Property(e => e.AdminUserName).HasMaxLength(50);
            entity.Property(e => e.MobileNo).HasMaxLength(15);
            entity.Property(e => e.UserRoleCode).HasMaxLength(50);
        });

        modelBuilder.Entity<TblPlaceState>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PK_Tbl_City");

            entity.ToTable("Tbl_PlaceState");

            entity.Property(e => e.StateCode).HasMaxLength(50);
            entity.Property(e => e.StateName).HasMaxLength(50);
        });

        modelBuilder.Entity<TblPlaceTownship>(entity =>
        {
            entity.HasKey(e => e.TownshipId).HasName("PK_Tbl_Township");

            entity.ToTable("Tbl_PlaceTownship");

            entity.Property(e => e.StateCode).HasMaxLength(50);
            entity.Property(e => e.TownshipCode).HasMaxLength(50);
            entity.Property(e => e.TownshipName).HasMaxLength(50);
        });

        modelBuilder.Entity<TblTransactionHistory>(entity =>
        {
            entity.HasKey(e => e.TransactionHistoryId).HasName("PK_Tbl_Transfer");

            entity.ToTable("Tbl_TransactionHistory");

            entity.Property(e => e.AdminUserCode).HasMaxLength(50);
            entity.Property(e => e.Amount).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.FromAccountNo).HasMaxLength(50);
            entity.Property(e => e.ToAccountNo).HasMaxLength(50);
            entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            entity.Property(e => e.TransactionType).HasMaxLength(50);
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_Customer");

            entity.ToTable("Tbl_User");

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.CustomerId)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasComputedColumnSql("('C'+right('000000'+CONVERT([varchar](6),[UserId]),(6)))", true);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.MobileNo).HasMaxLength(15);
            entity.Property(e => e.Nrc).HasMaxLength(50);
            entity.Property(e => e.StateCode).HasMaxLength(50);
            entity.Property(e => e.TownshipCode).HasMaxLength(50);
            entity.Property(e => e.UserCode).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
