using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AFOP_OPTICAL_TESTINGv5.Models;

public partial class Afop2023Context : DbContext
{
    public Afop2023Context()
    {
    }

    public Afop2023Context(DbContextOptions<Afop2023Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Tblacquisition> Tblacquisitions { get; set; }

    public virtual DbSet<Tblinfo> Tblinfos { get; set; }

    public virtual DbSet<Tblmeasurement> Tblmeasurements { get; set; }

    public virtual DbSet<Tblorlzone> Tblorlzones { get; set; }

    public virtual DbSet<Tblportmap> Tblportmaps { get; set; }

    public virtual DbSet<Tblsetupcompany> Tblsetupcompanies { get; set; }

    public virtual DbSet<Tblsetupdut> Tblsetupduts { get; set; }

    public virtual DbSet<Tblsetupmtj> Tblsetupmtjs { get; set; }

    public virtual DbSet<Tblsetupspec> Tblsetupspecs { get; set; }

    public virtual DbSet<Tblsetuptest> Tblsetuptests { get; set; }

    public virtual DbSet<Tbltestportmap> Tbltestportmaps { get; set; }

    public virtual DbSet<Tblunitdut> Tblunitduts { get; set; }

    public virtual DbSet<Tblunitmtj> Tblunitmtjs { get; set; }

    public virtual DbSet<Tblunittest> Tblunittests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Tblacquisition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tblacquisition");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DateTime).HasColumnType("datetime");
            entity.Property(e => e.DutinputPort).HasColumnName("DUTInputPort");
            entity.Property(e => e.DutoutputPort).HasColumnName("DUTOutputPort");
            entity.Property(e => e.Dutpath).HasColumnName("DUTPath");
            entity.Property(e => e.Dutpower).HasColumnName("DUTPower");
            entity.Property(e => e.InputMtjid).HasColumnName("InputMTJID");
            entity.Property(e => e.OutputMtjid).HasColumnName("OutputMTJID");
            entity.Property(e => e.Results).HasColumnType("text");
            entity.Property(e => e.UnitDutid).HasColumnName("UnitDUTID");
            entity.Property(e => e.UnitTestId).HasColumnName("UnitTestID");
        });

        modelBuilder.Entity<Tblinfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tblinfo");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Created).HasColumnType("text");
            entity.Property(e => e.ScriptId).HasColumnName("ScriptID");
        });

        modelBuilder.Entity<Tblmeasurement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tblmeasurement");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AcquisitionId).HasColumnName("AcquisitionID");
            entity.Property(e => e.Passed).HasColumnType("text");
            entity.Property(e => e.SetupSpecId).HasColumnName("SetupSpecID");
        });

        modelBuilder.Entity<Tblorlzone>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblorlzone");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Id)
                .HasColumnType("text")
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasColumnType("text");
        });

        modelBuilder.Entity<Tblportmap>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblportmap");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Id)
                .HasColumnType("text")
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasColumnType("text");
        });

        modelBuilder.Entity<Tblsetupcompany>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tblsetupcompany");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Address).HasColumnType("text");
            entity.Property(e => e.City).HasColumnType("text");
            entity.Property(e => e.CompanyName).HasColumnType("text");
            entity.Property(e => e.Country).HasColumnType("text");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.IsActive).HasColumnType("text");
            entity.Property(e => e.Name).HasColumnType("text");
            entity.Property(e => e.Phone).HasColumnType("text");
            entity.Property(e => e.State).HasColumnType("text");
            entity.Property(e => e.ZipCode).HasColumnType("text");
        });

        modelBuilder.Entity<Tblsetupdut>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tblsetupdut");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.IsActive).HasColumnType("text");
            entity.Property(e => e.Name).HasColumnType("text");
            entity.Property(e => e.PartNumber).HasColumnType("text");
            entity.Property(e => e.PortNames).HasColumnType("text");
        });

        modelBuilder.Entity<Tblsetupmtj>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tblsetupmtj");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.Connector).HasColumnType("text");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.IsActive).HasColumnType("text");
            entity.Property(e => e.IsFanout).HasColumnType("text");
            entity.Property(e => e.Name).HasColumnType("text");
            entity.Property(e => e.PartNumber).HasColumnType("text");
        });

        modelBuilder.Entity<Tblsetupspec>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tblsetupspec");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.IsActive).HasColumnType("text");
            entity.Property(e => e.Name).HasColumnType("text");
            entity.Property(e => e.Setup).HasColumnType("text");
            entity.Property(e => e.TableHeader).HasColumnType("text");
        });

        modelBuilder.Entity<Tblsetuptest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tblsetuptest");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Dutfibers).HasColumnName("DUTFibers");
            entity.Property(e => e.Duttype).HasColumnName("DUTType");
            entity.Property(e => e.IsActive).HasColumnType("text");
            entity.Property(e => e.J1channels).HasColumnName("J1Channels");
            entity.Property(e => e.J2channels).HasColumnName("J2Channels");
            entity.Property(e => e.Name).HasColumnType("text");
            entity.Property(e => e.Opmdevices).HasColumnName("OPMDevices");
            entity.Property(e => e.Pdlmode).HasColumnName("PDLMode");
            entity.Property(e => e.SetupSpecIds)
                .HasColumnType("text")
                .HasColumnName("SetupSpecIDs");
            entity.Property(e => e.Sources).HasColumnType("text");
            entity.Property(e => e.TestSteps).HasColumnType("text");
        });

        modelBuilder.Entity<Tbltestportmap>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbltestportmap");

            entity.Property(e => e.Id)
                .HasColumnType("text")
                .HasColumnName("ID");
            entity.Property(e => e.Serialized).HasColumnType("text");
            entity.Property(e => e.TestStep).HasColumnType("text");
            entity.Property(e => e.UnitDutid)
                .HasColumnType("text")
                .HasColumnName("UnitDUTID");
            entity.Property(e => e.UnitTestId)
                .HasColumnType("text")
                .HasColumnName("UnitTestID");
        });

        modelBuilder.Entity<Tblunitdut>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tblunitdut");

            entity.HasIndex(e => e.Id, "idx_tblunitdut_ID");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.SerialNumber).HasColumnType("text");
            entity.Property(e => e.SetupDutid).HasColumnName("SetupDUTID");
        });

        modelBuilder.Entity<Tblunitmtj>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblunitmtj");

            entity.Property(e => e.Id)
                .HasColumnType("text")
                .HasColumnName("ID");
            entity.Property(e => e.MyUsage).HasColumnType("text");
            entity.Property(e => e.SerialNumber).HasColumnType("text");
            entity.Property(e => e.SetupMtjid)
                .HasColumnType("text")
                .HasColumnName("SetupMTJID");
        });

        modelBuilder.Entity<Tblunittest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tblunittest");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AddSummary).HasColumnType("text");
            entity.Property(e => e.ChassisSn).HasColumnName("ChassisSN");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CurrentDut).HasColumnName("CurrentDUT");
            entity.Property(e => e.Custom1).HasColumnType("text");
            entity.Property(e => e.Custom2).HasColumnType("text");
            entity.Property(e => e.Custom3).HasColumnType("text");
            entity.Property(e => e.Custom4).HasColumnType("text");
            entity.Property(e => e.Custom5).HasColumnType("text");
            entity.Property(e => e.DebugMode).HasColumnType("text");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.EndDateTime).HasColumnType("datetime");
            entity.Property(e => e.ModuleSn).HasColumnName("ModuleSN");
            entity.Property(e => e.SetupDutid).HasColumnName("SetupDUTID");
            entity.Property(e => e.SetupTestId).HasColumnName("SetupTestID");
            entity.Property(e => e.StartDateTime).HasColumnType("datetime");
            entity.Property(e => e.UnitDutids).HasColumnName("UnitDUTIDs");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
