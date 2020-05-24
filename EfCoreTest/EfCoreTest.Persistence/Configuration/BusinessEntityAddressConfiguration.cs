﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreTest.Persistence
{
    public class BusinessEntityAddressConfiguration : IEntityTypeConfiguration<BusinessEntityAddress>
    {
        public void Configure(EntityTypeBuilder<BusinessEntityAddress> entity)
        {
            entity.HasKey(e => new { e.BusinessEntityId, e.AddressId, e.AddressTypeId })
                .HasName("PK_BusinessEntityAddress_BusinessEntityID_AddressID_AddressTypeID");

            entity.ToTable("BusinessEntityAddress", "Person");

            entity.HasComment("Cross-reference table mapping customers, vendors, and employees to their addresses.");

            entity.HasIndex(e => e.AddressId);

            entity.HasIndex(e => e.AddressTypeId);

            entity.HasIndex(e => e.Rowguid)
                .HasName("AK_BusinessEntityAddress_rowguid")
                .IsUnique();

            entity.Property(e => e.BusinessEntityId)
                .HasColumnName("BusinessEntityID")
                .HasComment("Primary key. Foreign key to BusinessEntity.BusinessEntityID.");

            entity.Property(e => e.AddressId)
                .HasColumnName("AddressID")
                .HasComment("Primary key. Foreign key to Address.AddressID.");

            entity.Property(e => e.AddressTypeId)
                .HasColumnName("AddressTypeID")
                .HasComment("Primary key. Foreign key to AddressType.AddressTypeID.");

            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Rowguid)
                .HasColumnName("rowguid")
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            entity.HasOne(d => d.Address)
                .WithMany(p => p.BusinessEntityAddresses)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.AddressType)
                .WithMany(p => p.BusinessEntityAddresses)
                .HasForeignKey(d => d.AddressTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.BusinessEntity)
                .WithMany(p => p.BusinessEntityAddresses)
                .HasForeignKey(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}