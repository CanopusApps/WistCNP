using System;
using System.Collections.Generic;
using CalSystem2._0.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalSystem2._0.DataContext;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CalBwyb> CalBwybs { get; set; }

    public virtual DbSet<CalDynamicDatum> CalDynamicData { get; set; }

    public virtual DbSet<CalFchx> CalFchxes { get; set; }

    public virtual DbSet<CalHbg1> CalHbg1s { get; set; }

    public virtual DbSet<CalHbg2> CalHbg2s { get; set; }

    public virtual DbSet<CalHbg3> CalHbg3s { get; set; }

    public virtual DbSet<CalHbg4> CalHbg4s { get; set; }

    public virtual DbSet<CalHbg5> CalHbg5s { get; set; }

    public virtual DbSet<CalJdhcwy> CalJdhcwies { get; set; }

    public virtual DbSet<CalLog> CalLogs { get; set; }

    public virtual DbSet<CalLtcwy> CalLtcwies { get; set; }

    public virtual DbSet<CalLzfq1> CalLzfq1s { get; set; }

    public virtual DbSet<CalLzfs1> CalLzfs1s { get; set; }

    public virtual DbSet<CalLzfs2> CalLzfs2s { get; set; }

    public virtual DbSet<CalSbq2> CalSbq2s { get; set; }

    public virtual DbSet<CalSbq4> CalSbq4s { get; set; }

    public virtual DbSet<CalStand> CalStands { get; set; }

    public virtual DbSet<CalTicketD> CalTicketDs { get; set; }

    public virtual DbSet<CalTicketFlow> CalTicketFlows { get; set; }

    public virtual DbSet<CalTicketRejectmailcc> CalTicketRejectmailccs { get; set; }

    public virtual DbSet<CalUp> CalUps { get; set; }

    public virtual DbSet<CalWyb1> CalWyb1s { get; set; }

    public virtual DbSet<CalWyb2> CalWyb2s { get; set; }

    public virtual DbSet<CalYbkc1> CalYbkc1s { get; set; }

    public virtual DbSet<CalYbkc2> CalYbkc2s { get; set; }

    public virtual DbSet<CalYbkc3> CalYbkc3s { get; set; }

    public virtual DbSet<CalYbkc4> CalYbkc4s { get; set; }

    public virtual DbSet<CalYlnzq> CalYlnzqs { get; set; }

    public virtual DbSet<CalZlwydy1201gsma> CalZlwydy1201gsmas { get; set; }

    public virtual DbSet<CalZlwydy2306> CalZlwydy2306s { get; set; }

    public virtual DbSet<CalZlwydy2308> CalZlwydy2308s { get; set; }

    public virtual DbSet<CalZlwydy3030> CalZlwydy3030s { get; set; }

    public virtual DbSet<CalZlwydy3303d> CalZlwydy3303ds { get; set; }

    public virtual DbSet<CalZlwydy66309d> CalZlwydy66309ds { get; set; }

    public virtual DbSet<CalZlwydy6632b> CalZlwydy6632bs { get; set; }

    public virtual DbSet<Calchecklist> Calchecklists { get; set; }

    public virtual DbSet<Calemslst> Calemslsts { get; set; }

    public virtual DbSet<Calmaillist> Calmaillists { get; set; }

    public virtual DbSet<CalmaillistJ> CalmaillistJs { get; set; }

    public virtual DbSet<Calmain> Calmains { get; set; }

    public virtual DbSet<Calmodel> Calmodels { get; set; }

    public virtual DbSet<Caluser> Calusers { get; set; }

    public virtual DbSet<HrAt> HrAts { get; set; }

    public virtual DbSet<HrAtOld> HrAtOlds { get; set; }

    public virtual DbSet<IqcLog> IqcLogs { get; set; }

    public virtual DbSet<Iqcmaillist> Iqcmaillists { get; set; }

    public virtual DbSet<Iqcmain> Iqcmains { get; set; }

    public virtual DbSet<Iqcmodel> Iqcmodels { get; set; }

    public virtual DbSet<Ken> Kens { get; set; }

    public virtual DbSet<Mtnchart> Mtncharts { get; set; }

    public virtual DbSet<Mtnmaillist> Mtnmaillists { get; set; }

    public virtual DbSet<Mtnmain> Mtnmains { get; set; }

    public virtual DbSet<MtnmainHi> MtnmainHis { get; set; }

    public virtual DbSet<Mtnmaind> Mtnmainds { get; set; }

    public virtual DbSet<Mtnmodel> Mtnmodels { get; set; }

    public virtual DbSet<Pmdetail> Pmdetails { get; set; }

    public virtual DbSet<Pmscheduledetail> Pmscheduledetails { get; set; }

    public virtual DbSet<Ssntemp> Ssntemps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseOracle("Name=CalDBCon");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("CAL_USER")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<CalBwyb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_BWYB");

            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.BwybX1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X1");
            entity.Property(e => e.BwybX10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X10");
            entity.Property(e => e.BwybX11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X11");
            entity.Property(e => e.BwybX111)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X11_1");
            entity.Property(e => e.BwybX112)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X11_2");
            entity.Property(e => e.BwybX12)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X12");
            entity.Property(e => e.BwybX13)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X13");
            entity.Property(e => e.BwybX14)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X14");
            entity.Property(e => e.BwybX15)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X15");
            entity.Property(e => e.BwybX16)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X16");
            entity.Property(e => e.BwybX17)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X17");
            entity.Property(e => e.BwybX18)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X18");
            entity.Property(e => e.BwybX19)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X19");
            entity.Property(e => e.BwybX2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X2");
            entity.Property(e => e.BwybX20)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X20");
            entity.Property(e => e.BwybX21)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X21");
            entity.Property(e => e.BwybX22)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X22");
            entity.Property(e => e.BwybX23)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X23");
            entity.Property(e => e.BwybX24)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X24");
            entity.Property(e => e.BwybX25)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X25");
            entity.Property(e => e.BwybX26)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X26");
            entity.Property(e => e.BwybX27)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X27");
            entity.Property(e => e.BwybX28)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X28");
            entity.Property(e => e.BwybX29)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X29");
            entity.Property(e => e.BwybX3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X3");
            entity.Property(e => e.BwybX4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X4");
            entity.Property(e => e.BwybX5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X5");
            entity.Property(e => e.BwybX51)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X5_1");
            entity.Property(e => e.BwybX6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X6");
            entity.Property(e => e.BwybX7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X7");
            entity.Property(e => e.BwybX8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X8");
            entity.Property(e => e.BwybX9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BWYB_X9");
            entity.Property(e => e.Checkid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.Uptime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPTIME");
        });

        modelBuilder.Entity<CalDynamicDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C007432");

            entity.ToTable("CAL_DYNAMIC_DATA");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ID");
            entity.Property(e => e.Content)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CONTENT");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Type)
                .HasColumnType("NUMBER")
                .HasColumnName("TYPE");
        });

        modelBuilder.Entity<CalFchx>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_FCHX");

            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Checkid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.FchxX1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FCHX_X1");
            entity.Property(e => e.FchxX2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FCHX_X2");
            entity.Property(e => e.FchxX3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FCHX_X3");
            entity.Property(e => e.FchxX4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FCHX_X4");
            entity.Property(e => e.FchxY1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FCHX_Y1");
            entity.Property(e => e.FchxY2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FCHX_Y2");
            entity.Property(e => e.FchxY3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FCHX_Y3");
            entity.Property(e => e.FchxY4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FCHX_Y4");
            entity.Property(e => e.Uptime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPTIME");
        });

        modelBuilder.Entity<CalHbg1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_HBG1");

            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Checkid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.Hbg1A1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A1");
            entity.Property(e => e.Hbg1A10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A10");
            entity.Property(e => e.Hbg1A11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A11");
            entity.Property(e => e.Hbg1A12)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A12");
            entity.Property(e => e.Hbg1A13)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A13");
            entity.Property(e => e.Hbg1A14)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A14");
            entity.Property(e => e.Hbg1A15)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A15");
            entity.Property(e => e.Hbg1A16)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A16");
            entity.Property(e => e.Hbg1A17)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A17");
            entity.Property(e => e.Hbg1A18)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A18");
            entity.Property(e => e.Hbg1A19)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A19");
            entity.Property(e => e.Hbg1A2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A2");
            entity.Property(e => e.Hbg1A20)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A20");
            entity.Property(e => e.Hbg1A21)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A21");
            entity.Property(e => e.Hbg1A22)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A22");
            entity.Property(e => e.Hbg1A23)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A23");
            entity.Property(e => e.Hbg1A24)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A24");
            entity.Property(e => e.Hbg1A25)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A25");
            entity.Property(e => e.Hbg1A26)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A26");
            entity.Property(e => e.Hbg1A27)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A27");
            entity.Property(e => e.Hbg1A28)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A28");
            entity.Property(e => e.Hbg1A29)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A29");
            entity.Property(e => e.Hbg1A3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A3");
            entity.Property(e => e.Hbg1A30)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A30");
            entity.Property(e => e.Hbg1A31)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A31");
            entity.Property(e => e.Hbg1A32)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A32");
            entity.Property(e => e.Hbg1A33)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A33");
            entity.Property(e => e.Hbg1A34)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A34");
            entity.Property(e => e.Hbg1A35)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A35");
            entity.Property(e => e.Hbg1A36)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A36");
            entity.Property(e => e.Hbg1A37)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A37");
            entity.Property(e => e.Hbg1A38)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A38");
            entity.Property(e => e.Hbg1A39)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A39");
            entity.Property(e => e.Hbg1A4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A4");
            entity.Property(e => e.Hbg1A40)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A40");
            entity.Property(e => e.Hbg1A41)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A41");
            entity.Property(e => e.Hbg1A42)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A42");
            entity.Property(e => e.Hbg1A5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A5");
            entity.Property(e => e.Hbg1A6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A6");
            entity.Property(e => e.Hbg1A7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A7");
            entity.Property(e => e.Hbg1A8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A8");
            entity.Property(e => e.Hbg1A9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_A9");
            entity.Property(e => e.Hbg1M1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M1");
            entity.Property(e => e.Hbg1M10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M10");
            entity.Property(e => e.Hbg1M11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M11");
            entity.Property(e => e.Hbg1M12)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M12");
            entity.Property(e => e.Hbg1M13)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M13");
            entity.Property(e => e.Hbg1M14)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M14");
            entity.Property(e => e.Hbg1M15)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M15");
            entity.Property(e => e.Hbg1M16)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M16");
            entity.Property(e => e.Hbg1M17)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M17");
            entity.Property(e => e.Hbg1M18)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M18");
            entity.Property(e => e.Hbg1M19)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M19");
            entity.Property(e => e.Hbg1M2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M2");
            entity.Property(e => e.Hbg1M20)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M20");
            entity.Property(e => e.Hbg1M21)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M21");
            entity.Property(e => e.Hbg1M22)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M22");
            entity.Property(e => e.Hbg1M23)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M23");
            entity.Property(e => e.Hbg1M24)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M24");
            entity.Property(e => e.Hbg1M25)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M25");
            entity.Property(e => e.Hbg1M26)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M26");
            entity.Property(e => e.Hbg1M27)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M27");
            entity.Property(e => e.Hbg1M28)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M28");
            entity.Property(e => e.Hbg1M29)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M29");
            entity.Property(e => e.Hbg1M3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M3");
            entity.Property(e => e.Hbg1M30)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M30");
            entity.Property(e => e.Hbg1M4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M4");
            entity.Property(e => e.Hbg1M5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M5");
            entity.Property(e => e.Hbg1M6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M6");
            entity.Property(e => e.Hbg1M7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M7");
            entity.Property(e => e.Hbg1M8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M8");
            entity.Property(e => e.Hbg1M9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_M9");
            entity.Property(e => e.Hbg1X1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X1");
            entity.Property(e => e.Hbg1X10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X10");
            entity.Property(e => e.Hbg1X11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X11");
            entity.Property(e => e.Hbg1X12)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X12");
            entity.Property(e => e.Hbg1X13)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X13");
            entity.Property(e => e.Hbg1X14)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X14");
            entity.Property(e => e.Hbg1X15)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X15");
            entity.Property(e => e.Hbg1X16)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X16");
            entity.Property(e => e.Hbg1X17)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X17");
            entity.Property(e => e.Hbg1X18)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X18");
            entity.Property(e => e.Hbg1X19)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X19");
            entity.Property(e => e.Hbg1X2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X2");
            entity.Property(e => e.Hbg1X20)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X20");
            entity.Property(e => e.Hbg1X21)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X21");
            entity.Property(e => e.Hbg1X22)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X22");
            entity.Property(e => e.Hbg1X23)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X23");
            entity.Property(e => e.Hbg1X24)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X24");
            entity.Property(e => e.Hbg1X25)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X25");
            entity.Property(e => e.Hbg1X26)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X26");
            entity.Property(e => e.Hbg1X27)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X27");
            entity.Property(e => e.Hbg1X28)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X28");
            entity.Property(e => e.Hbg1X29)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X29");
            entity.Property(e => e.Hbg1X3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X3");
            entity.Property(e => e.Hbg1X30)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X30");
            entity.Property(e => e.Hbg1X31)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X31");
            entity.Property(e => e.Hbg1X32)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X32");
            entity.Property(e => e.Hbg1X33)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X33");
            entity.Property(e => e.Hbg1X34)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X34");
            entity.Property(e => e.Hbg1X35)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X35");
            entity.Property(e => e.Hbg1X36)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X36");
            entity.Property(e => e.Hbg1X37)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X37");
            entity.Property(e => e.Hbg1X38)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X38");
            entity.Property(e => e.Hbg1X39)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X39");
            entity.Property(e => e.Hbg1X4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X4");
            entity.Property(e => e.Hbg1X40)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X40");
            entity.Property(e => e.Hbg1X41)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X41");
            entity.Property(e => e.Hbg1X42)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X42");
            entity.Property(e => e.Hbg1X5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X5");
            entity.Property(e => e.Hbg1X6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X6");
            entity.Property(e => e.Hbg1X7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X7");
            entity.Property(e => e.Hbg1X8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X8");
            entity.Property(e => e.Hbg1X9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG1_X9");
            entity.Property(e => e.Uptime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPTIME");
        });

        modelBuilder.Entity<CalHbg2>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_HBG2");

            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Checkid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.Hbg2X1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X1");
            entity.Property(e => e.Hbg2X10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X10");
            entity.Property(e => e.Hbg2X11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X11");
            entity.Property(e => e.Hbg2X12)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X12");
            entity.Property(e => e.Hbg2X13)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X13");
            entity.Property(e => e.Hbg2X14)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X14");
            entity.Property(e => e.Hbg2X15)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X15");
            entity.Property(e => e.Hbg2X16)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X16");
            entity.Property(e => e.Hbg2X17)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X17");
            entity.Property(e => e.Hbg2X18)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X18");
            entity.Property(e => e.Hbg2X19)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X19");
            entity.Property(e => e.Hbg2X2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X2");
            entity.Property(e => e.Hbg2X20)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X20");
            entity.Property(e => e.Hbg2X21)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X21");
            entity.Property(e => e.Hbg2X22)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X22");
            entity.Property(e => e.Hbg2X23)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X23");
            entity.Property(e => e.Hbg2X24)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X24");
            entity.Property(e => e.Hbg2X25)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X25");
            entity.Property(e => e.Hbg2X26)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X26");
            entity.Property(e => e.Hbg2X27)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X27");
            entity.Property(e => e.Hbg2X28)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X28");
            entity.Property(e => e.Hbg2X29)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X29");
            entity.Property(e => e.Hbg2X3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X3");
            entity.Property(e => e.Hbg2X30)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X30");
            entity.Property(e => e.Hbg2X31)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X31");
            entity.Property(e => e.Hbg2X32)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X32");
            entity.Property(e => e.Hbg2X33)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X33");
            entity.Property(e => e.Hbg2X34)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X34");
            entity.Property(e => e.Hbg2X35)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X35");
            entity.Property(e => e.Hbg2X36)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X36");
            entity.Property(e => e.Hbg2X37)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X37");
            entity.Property(e => e.Hbg2X38)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X38");
            entity.Property(e => e.Hbg2X39)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X39");
            entity.Property(e => e.Hbg2X4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X4");
            entity.Property(e => e.Hbg2X40)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X40");
            entity.Property(e => e.Hbg2X41)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X41");
            entity.Property(e => e.Hbg2X42)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X42");
            entity.Property(e => e.Hbg2X43)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X43");
            entity.Property(e => e.Hbg2X44)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X44");
            entity.Property(e => e.Hbg2X45)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X45");
            entity.Property(e => e.Hbg2X46)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X46");
            entity.Property(e => e.Hbg2X47)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X47");
            entity.Property(e => e.Hbg2X48)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X48");
            entity.Property(e => e.Hbg2X49)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X49");
            entity.Property(e => e.Hbg2X5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X5");
            entity.Property(e => e.Hbg2X50)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X50");
            entity.Property(e => e.Hbg2X51)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X51");
            entity.Property(e => e.Hbg2X52)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X52");
            entity.Property(e => e.Hbg2X53)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X53");
            entity.Property(e => e.Hbg2X54)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X54");
            entity.Property(e => e.Hbg2X55)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X55");
            entity.Property(e => e.Hbg2X56)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X56");
            entity.Property(e => e.Hbg2X57)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X57");
            entity.Property(e => e.Hbg2X58)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X58");
            entity.Property(e => e.Hbg2X59)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X59");
            entity.Property(e => e.Hbg2X6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X6");
            entity.Property(e => e.Hbg2X60)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X60");
            entity.Property(e => e.Hbg2X61)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X61");
            entity.Property(e => e.Hbg2X62)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X62");
            entity.Property(e => e.Hbg2X63)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X63");
            entity.Property(e => e.Hbg2X64)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X64");
            entity.Property(e => e.Hbg2X65)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X65");
            entity.Property(e => e.Hbg2X66)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X66");
            entity.Property(e => e.Hbg2X67)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X67");
            entity.Property(e => e.Hbg2X68)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X68");
            entity.Property(e => e.Hbg2X69)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X69");
            entity.Property(e => e.Hbg2X7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X7");
            entity.Property(e => e.Hbg2X70)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X70");
            entity.Property(e => e.Hbg2X71)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X71");
            entity.Property(e => e.Hbg2X72)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X72");
            entity.Property(e => e.Hbg2X73)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X73");
            entity.Property(e => e.Hbg2X74)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X74");
            entity.Property(e => e.Hbg2X75)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X75");
            entity.Property(e => e.Hbg2X76)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X76");
            entity.Property(e => e.Hbg2X77)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X77");
            entity.Property(e => e.Hbg2X78)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X78");
            entity.Property(e => e.Hbg2X79)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X79");
            entity.Property(e => e.Hbg2X8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X8");
            entity.Property(e => e.Hbg2X80)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X80");
            entity.Property(e => e.Hbg2X81)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X81");
            entity.Property(e => e.Hbg2X82)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X82");
            entity.Property(e => e.Hbg2X83)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X83");
            entity.Property(e => e.Hbg2X84)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X84");
            entity.Property(e => e.Hbg2X9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X9");
            entity.Property(e => e.Uptime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPTIME");
        });

        modelBuilder.Entity<CalHbg3>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_HBG3");

            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Checkid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.Hbg3X1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X1");
            entity.Property(e => e.Hbg3X10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X10");
            entity.Property(e => e.Hbg3X100)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X100");
            entity.Property(e => e.Hbg3X101)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X101");
            entity.Property(e => e.Hbg3X102)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X102");
            entity.Property(e => e.Hbg3X103)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X103");
            entity.Property(e => e.Hbg3X104)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X104");
            entity.Property(e => e.Hbg3X105)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X105");
            entity.Property(e => e.Hbg3X106)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X106");
            entity.Property(e => e.Hbg3X107)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X107");
            entity.Property(e => e.Hbg3X108)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X108");
            entity.Property(e => e.Hbg3X109)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X109");
            entity.Property(e => e.Hbg3X11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X11");
            entity.Property(e => e.Hbg3X110)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X110");
            entity.Property(e => e.Hbg3X111)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X111");
            entity.Property(e => e.Hbg3X112)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X112");
            entity.Property(e => e.Hbg3X113)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X113");
            entity.Property(e => e.Hbg3X114)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X114");
            entity.Property(e => e.Hbg3X115)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X115");
            entity.Property(e => e.Hbg3X116)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X116");
            entity.Property(e => e.Hbg3X117)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X117");
            entity.Property(e => e.Hbg3X118)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X118");
            entity.Property(e => e.Hbg3X119)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X119");
            entity.Property(e => e.Hbg3X12)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X12");
            entity.Property(e => e.Hbg3X120)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X120");
            entity.Property(e => e.Hbg3X13)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X13");
            entity.Property(e => e.Hbg3X14)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X14");
            entity.Property(e => e.Hbg3X15)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X15");
            entity.Property(e => e.Hbg3X16)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X16");
            entity.Property(e => e.Hbg3X17)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X17");
            entity.Property(e => e.Hbg3X18)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X18");
            entity.Property(e => e.Hbg3X19)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X19");
            entity.Property(e => e.Hbg3X2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X2");
            entity.Property(e => e.Hbg3X20)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X20");
            entity.Property(e => e.Hbg3X21)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X21");
            entity.Property(e => e.Hbg3X22)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X22");
            entity.Property(e => e.Hbg3X23)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X23");
            entity.Property(e => e.Hbg3X24)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X24");
            entity.Property(e => e.Hbg3X25)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X25");
            entity.Property(e => e.Hbg3X26)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X26");
            entity.Property(e => e.Hbg3X27)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X27");
            entity.Property(e => e.Hbg3X28)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X28");
            entity.Property(e => e.Hbg3X29)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X29");
            entity.Property(e => e.Hbg3X3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X3");
            entity.Property(e => e.Hbg3X30)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X30");
            entity.Property(e => e.Hbg3X31)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X31");
            entity.Property(e => e.Hbg3X32)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X32");
            entity.Property(e => e.Hbg3X33)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X33");
            entity.Property(e => e.Hbg3X34)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X34");
            entity.Property(e => e.Hbg3X35)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X35");
            entity.Property(e => e.Hbg3X36)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X36");
            entity.Property(e => e.Hbg3X37)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X37");
            entity.Property(e => e.Hbg3X38)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X38");
            entity.Property(e => e.Hbg3X39)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X39");
            entity.Property(e => e.Hbg3X4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X4");
            entity.Property(e => e.Hbg3X40)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X40");
            entity.Property(e => e.Hbg3X41)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X41");
            entity.Property(e => e.Hbg3X42)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X42");
            entity.Property(e => e.Hbg3X43)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X43");
            entity.Property(e => e.Hbg3X44)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X44");
            entity.Property(e => e.Hbg3X45)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X45");
            entity.Property(e => e.Hbg3X46)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X46");
            entity.Property(e => e.Hbg3X47)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X47");
            entity.Property(e => e.Hbg3X48)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X48");
            entity.Property(e => e.Hbg3X49)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X49");
            entity.Property(e => e.Hbg3X5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X5");
            entity.Property(e => e.Hbg3X50)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X50");
            entity.Property(e => e.Hbg3X51)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X51");
            entity.Property(e => e.Hbg3X52)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X52");
            entity.Property(e => e.Hbg3X53)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X53");
            entity.Property(e => e.Hbg3X54)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X54");
            entity.Property(e => e.Hbg3X55)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X55");
            entity.Property(e => e.Hbg3X56)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X56");
            entity.Property(e => e.Hbg3X57)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X57");
            entity.Property(e => e.Hbg3X58)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X58");
            entity.Property(e => e.Hbg3X59)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X59");
            entity.Property(e => e.Hbg3X6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X6");
            entity.Property(e => e.Hbg3X60)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X60");
            entity.Property(e => e.Hbg3X61)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X61");
            entity.Property(e => e.Hbg3X62)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X62");
            entity.Property(e => e.Hbg3X63)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X63");
            entity.Property(e => e.Hbg3X64)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X64");
            entity.Property(e => e.Hbg3X65)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X65");
            entity.Property(e => e.Hbg3X66)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X66");
            entity.Property(e => e.Hbg3X67)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X67");
            entity.Property(e => e.Hbg3X68)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X68");
            entity.Property(e => e.Hbg3X69)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X69");
            entity.Property(e => e.Hbg3X7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X7");
            entity.Property(e => e.Hbg3X70)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X70");
            entity.Property(e => e.Hbg3X71)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X71");
            entity.Property(e => e.Hbg3X72)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X72");
            entity.Property(e => e.Hbg3X73)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X73");
            entity.Property(e => e.Hbg3X74)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X74");
            entity.Property(e => e.Hbg3X75)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X75");
            entity.Property(e => e.Hbg3X76)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X76");
            entity.Property(e => e.Hbg3X77)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X77");
            entity.Property(e => e.Hbg3X78)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X78");
            entity.Property(e => e.Hbg3X79)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X79");
            entity.Property(e => e.Hbg3X8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X8");
            entity.Property(e => e.Hbg3X80)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X80");
            entity.Property(e => e.Hbg3X81)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X81");
            entity.Property(e => e.Hbg3X82)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X82");
            entity.Property(e => e.Hbg3X83)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X83");
            entity.Property(e => e.Hbg3X84)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X84");
            entity.Property(e => e.Hbg3X85)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X85");
            entity.Property(e => e.Hbg3X86)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X86");
            entity.Property(e => e.Hbg3X87)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X87");
            entity.Property(e => e.Hbg3X88)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X88");
            entity.Property(e => e.Hbg3X89)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X89");
            entity.Property(e => e.Hbg3X9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X9");
            entity.Property(e => e.Hbg3X90)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X90");
            entity.Property(e => e.Hbg3X91)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X91");
            entity.Property(e => e.Hbg3X92)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X92");
            entity.Property(e => e.Hbg3X93)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X93");
            entity.Property(e => e.Hbg3X94)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X94");
            entity.Property(e => e.Hbg3X95)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X95");
            entity.Property(e => e.Hbg3X96)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X96");
            entity.Property(e => e.Hbg3X97)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X97");
            entity.Property(e => e.Hbg3X98)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X98");
            entity.Property(e => e.Hbg3X99)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG3_X99");
            entity.Property(e => e.Uptime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPTIME");
        });

        modelBuilder.Entity<CalHbg4>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_HBG4");

            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Checkid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.Hbg4A1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A1");
            entity.Property(e => e.Hbg4A10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A10");
            entity.Property(e => e.Hbg4A11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A11");
            entity.Property(e => e.Hbg4A12)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A12");
            entity.Property(e => e.Hbg4A13)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A13");
            entity.Property(e => e.Hbg4A14)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A14");
            entity.Property(e => e.Hbg4A15)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A15");
            entity.Property(e => e.Hbg4A16)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A16");
            entity.Property(e => e.Hbg4A17)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A17");
            entity.Property(e => e.Hbg4A18)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A18");
            entity.Property(e => e.Hbg4A19)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A19");
            entity.Property(e => e.Hbg4A2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A2");
            entity.Property(e => e.Hbg4A20)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A20");
            entity.Property(e => e.Hbg4A21)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A21");
            entity.Property(e => e.Hbg4A22)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A22");
            entity.Property(e => e.Hbg4A23)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A23");
            entity.Property(e => e.Hbg4A24)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A24");
            entity.Property(e => e.Hbg4A25)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A25");
            entity.Property(e => e.Hbg4A26)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A26");
            entity.Property(e => e.Hbg4A27)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A27");
            entity.Property(e => e.Hbg4A28)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A28");
            entity.Property(e => e.Hbg4A29)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A29");
            entity.Property(e => e.Hbg4A3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A3");
            entity.Property(e => e.Hbg4A30)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A30");
            entity.Property(e => e.Hbg4A31)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A31");
            entity.Property(e => e.Hbg4A32)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A32");
            entity.Property(e => e.Hbg4A33)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A33");
            entity.Property(e => e.Hbg4A34)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A34");
            entity.Property(e => e.Hbg4A35)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A35");
            entity.Property(e => e.Hbg4A36)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A36");
            entity.Property(e => e.Hbg4A37)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A37");
            entity.Property(e => e.Hbg4A38)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A38");
            entity.Property(e => e.Hbg4A39)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A39");
            entity.Property(e => e.Hbg4A4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A4");
            entity.Property(e => e.Hbg4A40)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A40");
            entity.Property(e => e.Hbg4A41)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A41");
            entity.Property(e => e.Hbg4A42)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A42");
            entity.Property(e => e.Hbg4A5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A5");
            entity.Property(e => e.Hbg4A6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A6");
            entity.Property(e => e.Hbg4A7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A7");
            entity.Property(e => e.Hbg4A8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A8");
            entity.Property(e => e.Hbg4A9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_A9");
            entity.Property(e => e.Hbg4M1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M1");
            entity.Property(e => e.Hbg4M10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M10");
            entity.Property(e => e.Hbg4M11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M11");
            entity.Property(e => e.Hbg4M12)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M12");
            entity.Property(e => e.Hbg4M13)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M13");
            entity.Property(e => e.Hbg4M14)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M14");
            entity.Property(e => e.Hbg4M15)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M15");
            entity.Property(e => e.Hbg4M16)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M16");
            entity.Property(e => e.Hbg4M17)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M17");
            entity.Property(e => e.Hbg4M18)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M18");
            entity.Property(e => e.Hbg4M19)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M19");
            entity.Property(e => e.Hbg4M2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M2");
            entity.Property(e => e.Hbg4M20)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M20");
            entity.Property(e => e.Hbg4M21)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M21");
            entity.Property(e => e.Hbg4M22)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M22");
            entity.Property(e => e.Hbg4M23)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M23");
            entity.Property(e => e.Hbg4M24)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M24");
            entity.Property(e => e.Hbg4M25)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M25");
            entity.Property(e => e.Hbg4M26)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M26");
            entity.Property(e => e.Hbg4M27)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M27");
            entity.Property(e => e.Hbg4M28)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M28");
            entity.Property(e => e.Hbg4M29)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M29");
            entity.Property(e => e.Hbg4M3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M3");
            entity.Property(e => e.Hbg4M30)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M30");
            entity.Property(e => e.Hbg4M31)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M31");
            entity.Property(e => e.Hbg4M32)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M32");
            entity.Property(e => e.Hbg4M33)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M33");
            entity.Property(e => e.Hbg4M34)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M34");
            entity.Property(e => e.Hbg4M35)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M35");
            entity.Property(e => e.Hbg4M36)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M36");
            entity.Property(e => e.Hbg4M37)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M37");
            entity.Property(e => e.Hbg4M38)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M38");
            entity.Property(e => e.Hbg4M39)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M39");
            entity.Property(e => e.Hbg4M4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M4");
            entity.Property(e => e.Hbg4M40)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M40");
            entity.Property(e => e.Hbg4M41)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M41");
            entity.Property(e => e.Hbg4M42)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M42");
            entity.Property(e => e.Hbg4M5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M5");
            entity.Property(e => e.Hbg4M6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M6");
            entity.Property(e => e.Hbg4M7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M7");
            entity.Property(e => e.Hbg4M8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M8");
            entity.Property(e => e.Hbg4M9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_M9");
            entity.Property(e => e.Hbg4X1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X1");
            entity.Property(e => e.Hbg4X10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X10");
            entity.Property(e => e.Hbg4X11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X11");
            entity.Property(e => e.Hbg4X12)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X12");
            entity.Property(e => e.Hbg4X13)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X13");
            entity.Property(e => e.Hbg4X14)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X14");
            entity.Property(e => e.Hbg4X15)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X15");
            entity.Property(e => e.Hbg4X16)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X16");
            entity.Property(e => e.Hbg4X17)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X17");
            entity.Property(e => e.Hbg4X18)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X18");
            entity.Property(e => e.Hbg4X19)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X19");
            entity.Property(e => e.Hbg4X2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X2");
            entity.Property(e => e.Hbg4X20)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X20");
            entity.Property(e => e.Hbg4X21)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X21");
            entity.Property(e => e.Hbg4X22)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X22");
            entity.Property(e => e.Hbg4X23)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X23");
            entity.Property(e => e.Hbg4X24)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X24");
            entity.Property(e => e.Hbg4X25)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X25");
            entity.Property(e => e.Hbg4X26)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X26");
            entity.Property(e => e.Hbg4X27)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X27");
            entity.Property(e => e.Hbg4X28)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X28");
            entity.Property(e => e.Hbg4X29)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X29");
            entity.Property(e => e.Hbg4X3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X3");
            entity.Property(e => e.Hbg4X30)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X30");
            entity.Property(e => e.Hbg4X31)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X31");
            entity.Property(e => e.Hbg4X32)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X32");
            entity.Property(e => e.Hbg4X33)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X33");
            entity.Property(e => e.Hbg4X34)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X34");
            entity.Property(e => e.Hbg4X35)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X35");
            entity.Property(e => e.Hbg4X36)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X36");
            entity.Property(e => e.Hbg4X37)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X37");
            entity.Property(e => e.Hbg4X38)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X38");
            entity.Property(e => e.Hbg4X39)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X39");
            entity.Property(e => e.Hbg4X4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X4");
            entity.Property(e => e.Hbg4X40)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X40");
            entity.Property(e => e.Hbg4X41)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X41");
            entity.Property(e => e.Hbg4X42)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X42");
            entity.Property(e => e.Hbg4X5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X5");
            entity.Property(e => e.Hbg4X6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X6");
            entity.Property(e => e.Hbg4X7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X7");
            entity.Property(e => e.Hbg4X8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X8");
            entity.Property(e => e.Hbg4X9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG4_X9");
            entity.Property(e => e.Uptime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPTIME");
        });

        modelBuilder.Entity<CalHbg5>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_HBG5");

            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Checkid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.Hbg2X1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X1");
            entity.Property(e => e.Hbg2X10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X10");
            entity.Property(e => e.Hbg2X11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X11");
            entity.Property(e => e.Hbg2X12)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X12");
            entity.Property(e => e.Hbg2X13)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X13");
            entity.Property(e => e.Hbg2X14)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X14");
            entity.Property(e => e.Hbg2X15)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X15");
            entity.Property(e => e.Hbg2X16)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X16");
            entity.Property(e => e.Hbg2X17)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X17");
            entity.Property(e => e.Hbg2X18)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X18");
            entity.Property(e => e.Hbg2X19)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X19");
            entity.Property(e => e.Hbg2X2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X2");
            entity.Property(e => e.Hbg2X20)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X20");
            entity.Property(e => e.Hbg2X21)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X21");
            entity.Property(e => e.Hbg2X22)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X22");
            entity.Property(e => e.Hbg2X23)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X23");
            entity.Property(e => e.Hbg2X24)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X24");
            entity.Property(e => e.Hbg2X25)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X25");
            entity.Property(e => e.Hbg2X26)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X26");
            entity.Property(e => e.Hbg2X27)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X27");
            entity.Property(e => e.Hbg2X28)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X28");
            entity.Property(e => e.Hbg2X29)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X29");
            entity.Property(e => e.Hbg2X3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X3");
            entity.Property(e => e.Hbg2X30)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X30");
            entity.Property(e => e.Hbg2X31)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X31");
            entity.Property(e => e.Hbg2X32)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X32");
            entity.Property(e => e.Hbg2X33)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X33");
            entity.Property(e => e.Hbg2X34)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X34");
            entity.Property(e => e.Hbg2X35)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X35");
            entity.Property(e => e.Hbg2X36)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X36");
            entity.Property(e => e.Hbg2X37)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X37");
            entity.Property(e => e.Hbg2X38)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X38");
            entity.Property(e => e.Hbg2X39)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X39");
            entity.Property(e => e.Hbg2X4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X4");
            entity.Property(e => e.Hbg2X40)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X40");
            entity.Property(e => e.Hbg2X41)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X41");
            entity.Property(e => e.Hbg2X42)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X42");
            entity.Property(e => e.Hbg2X43)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X43");
            entity.Property(e => e.Hbg2X44)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X44");
            entity.Property(e => e.Hbg2X45)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X45");
            entity.Property(e => e.Hbg2X46)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X46");
            entity.Property(e => e.Hbg2X47)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X47");
            entity.Property(e => e.Hbg2X48)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X48");
            entity.Property(e => e.Hbg2X49)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X49");
            entity.Property(e => e.Hbg2X5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X5");
            entity.Property(e => e.Hbg2X50)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X50");
            entity.Property(e => e.Hbg2X51)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X51");
            entity.Property(e => e.Hbg2X52)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X52");
            entity.Property(e => e.Hbg2X53)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X53");
            entity.Property(e => e.Hbg2X54)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X54");
            entity.Property(e => e.Hbg2X55)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X55");
            entity.Property(e => e.Hbg2X56)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X56");
            entity.Property(e => e.Hbg2X57)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X57");
            entity.Property(e => e.Hbg2X58)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X58");
            entity.Property(e => e.Hbg2X59)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X59");
            entity.Property(e => e.Hbg2X6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X6");
            entity.Property(e => e.Hbg2X60)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X60");
            entity.Property(e => e.Hbg2X61)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X61");
            entity.Property(e => e.Hbg2X62)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X62");
            entity.Property(e => e.Hbg2X63)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X63");
            entity.Property(e => e.Hbg2X64)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X64");
            entity.Property(e => e.Hbg2X65)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X65");
            entity.Property(e => e.Hbg2X66)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X66");
            entity.Property(e => e.Hbg2X67)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X67");
            entity.Property(e => e.Hbg2X68)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X68");
            entity.Property(e => e.Hbg2X69)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X69");
            entity.Property(e => e.Hbg2X7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X7");
            entity.Property(e => e.Hbg2X70)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X70");
            entity.Property(e => e.Hbg2X71)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X71");
            entity.Property(e => e.Hbg2X72)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X72");
            entity.Property(e => e.Hbg2X73)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X73");
            entity.Property(e => e.Hbg2X74)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X74");
            entity.Property(e => e.Hbg2X75)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X75");
            entity.Property(e => e.Hbg2X76)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X76");
            entity.Property(e => e.Hbg2X77)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X77");
            entity.Property(e => e.Hbg2X78)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X78");
            entity.Property(e => e.Hbg2X8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X8");
            entity.Property(e => e.Hbg2X9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HBG2_X9");
            entity.Property(e => e.Uptime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPTIME");
        });

        modelBuilder.Entity<CalJdhcwy>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_JDHCWY");

            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Checkid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.Ddlres1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DDLRES1");
            entity.Property(e => e.Ddlres2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DDLRES2");
            entity.Property(e => e.Ddlres3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DDLRES3");
            entity.Property(e => e.Ddlres4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DDLRES4");
            entity.Property(e => e.Ddlres5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DDLRES5");
            entity.Property(e => e.Ddlres6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DDLRES6");
            entity.Property(e => e.Ddlres7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DDLRES7");
            entity.Property(e => e.JdhcwyX1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("JDHCWY_X1");
            entity.Property(e => e.JdhcwyX2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("JDHCWY_X2");
            entity.Property(e => e.JdhcwyX3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("JDHCWY_X3");
            entity.Property(e => e.JdhcwyX4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("JDHCWY_X4");
            entity.Property(e => e.JdhcwyX5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("JDHCWY_X5");
            entity.Property(e => e.JdhcwyX6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("JDHCWY_X6");
            entity.Property(e => e.JdhcwyX7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("JDHCWY_X7");
            entity.Property(e => e.Uptime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPTIME");
        });

        modelBuilder.Entity<CalLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_LOG");

            entity.HasIndex(e => new { e.Assetag, e.Model, e.Logdate }, "CAL_LOG_IDX1");

            entity.Property(e => e.Assetag)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Attribute)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE");
            entity.Property(e => e.Brand)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BRAND");
            entity.Property(e => e.Calfee)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CALFEE");
            entity.Property(e => e.Department)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT");
            entity.Property(e => e.FirstDate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FIRST_DATE");
            entity.Property(e => e.Inspno)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("INSPNO");
            entity.Property(e => e.Keeper)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("KEEPER");
            entity.Property(e => e.Keepername)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("KEEPERNAME");
            entity.Property(e => e.LastDate)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("LAST_DATE");
            entity.Property(e => e.Logdate)
                .HasColumnType("DATE")
                .HasColumnName("LOGDATE");
            entity.Property(e => e.Loginid)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("LOGINID");
            entity.Property(e => e.Model)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MODEL");
            entity.Property(e => e.NextDate)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("NEXT_DATE");
            entity.Property(e => e.Nocalremark)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOCALREMARK");
            entity.Property(e => e.Ostatus)
                .HasColumnType("NUMBER(1)")
                .HasColumnName("OSTATUS");
            entity.Property(e => e.Pic)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("PIC");
            entity.Property(e => e.Plant)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("PLANT");
            entity.Property(e => e.Price)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PRICE");
            entity.Property(e => e.Sendmail)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("SENDMAIL");
            entity.Property(e => e.Sendpic)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SENDPIC");
            entity.Property(e => e.Serialno)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SERIALNO");
            entity.Property(e => e.Site)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SITE");
            entity.Property(e => e.Status)
                .HasColumnType("NUMBER(1)")
                .HasColumnName("STATUS");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TYPE");
        });

        modelBuilder.Entity<CalLtcwy>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_LTCWY");

            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Checkid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.LtcwyX1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LTCWY_X1");
            entity.Property(e => e.LtcwyX10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LTCWY_X10");
            entity.Property(e => e.LtcwyX2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LTCWY_X2");
            entity.Property(e => e.LtcwyX3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LTCWY_X3");
            entity.Property(e => e.LtcwyX4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LTCWY_X4");
            entity.Property(e => e.LtcwyX5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LTCWY_X5");
            entity.Property(e => e.LtcwyX6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LTCWY_X6");
            entity.Property(e => e.LtcwyX7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LTCWY_X7");
            entity.Property(e => e.LtcwyX8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LTCWY_X8");
            entity.Property(e => e.LtcwyX9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LTCWY_X9");
            entity.Property(e => e.Uptime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPTIME");
        });

        modelBuilder.Entity<CalLzfq1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_LZFQ1");

            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Checkid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.Lzfq1X1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LZFQ1_X1");
            entity.Property(e => e.Lzfq1X2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LZFQ1_X2");
            entity.Property(e => e.Lzfq1X3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LZFQ1_X3");
            entity.Property(e => e.Lzfq1X4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LZFQ1_X4");
            entity.Property(e => e.Uptime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPTIME");
        });

        modelBuilder.Entity<CalLzfs1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_LZFS1");

            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Checkid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.Lzfs1X1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LZFS1_X1");
            entity.Property(e => e.Lzfs1X2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LZFS1_X2");
            entity.Property(e => e.Lzfs1X3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LZFS1_X3");
            entity.Property(e => e.Lzfs1X4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LZFS1_X4");
            entity.Property(e => e.Lzfs1X5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LZFS1_X5");
            entity.Property(e => e.Lzfs1X6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LZFS1_X6");
            entity.Property(e => e.Uptime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPTIME");
        });

        modelBuilder.Entity<CalLzfs2>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_LZFS2");

            entity.Property(e => e.Assetag)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Checkid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.Lzfs2X1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LZFS2_X1");
            entity.Property(e => e.Lzfs2X10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LZFS2_X10");
            entity.Property(e => e.Lzfs2X2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LZFS2_X2");
            entity.Property(e => e.Lzfs2X3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LZFS2_X3");
            entity.Property(e => e.Lzfs2X4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LZFS2_X4");
            entity.Property(e => e.Lzfs2X5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LZFS2_X5");
            entity.Property(e => e.Lzfs2X6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LZFS2_X6");
            entity.Property(e => e.Lzfs2X7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LZFS2_X7");
            entity.Property(e => e.Lzfs2X8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LZFS2_X8");
            entity.Property(e => e.Lzfs2X9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LZFS2_X9");
            entity.Property(e => e.Uptime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPTIME");
        });

        modelBuilder.Entity<CalSbq2>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_SBQ2");

            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Checkid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.Sbq2A1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_A1");
            entity.Property(e => e.Sbq2A10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_A10");
            entity.Property(e => e.Sbq2A11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_A11");
            entity.Property(e => e.Sbq2A12)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_A12");
            entity.Property(e => e.Sbq2A13)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_A13");
            entity.Property(e => e.Sbq2A14)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_A14");
            entity.Property(e => e.Sbq2A15)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_A15");
            entity.Property(e => e.Sbq2A16)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_A16");
            entity.Property(e => e.Sbq2A17)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_A17");
            entity.Property(e => e.Sbq2A18)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_A18");
            entity.Property(e => e.Sbq2A19)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_A19");
            entity.Property(e => e.Sbq2A2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_A2");
            entity.Property(e => e.Sbq2A20)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_A20");
            entity.Property(e => e.Sbq2A21)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_A21");
            entity.Property(e => e.Sbq2A3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_A3");
            entity.Property(e => e.Sbq2A4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_A4");
            entity.Property(e => e.Sbq2A5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_A5");
            entity.Property(e => e.Sbq2A6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_A6");
            entity.Property(e => e.Sbq2A7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_A7");
            entity.Property(e => e.Sbq2A8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_A8");
            entity.Property(e => e.Sbq2A9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_A9");
            entity.Property(e => e.Sbq2Aa1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_AA1");
            entity.Property(e => e.Sbq2Aa10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_AA10");
            entity.Property(e => e.Sbq2Aa11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_AA11");
            entity.Property(e => e.Sbq2Aa12)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_AA12");
            entity.Property(e => e.Sbq2Aa13)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_AA13");
            entity.Property(e => e.Sbq2Aa14)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_AA14");
            entity.Property(e => e.Sbq2Aa15)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_AA15");
            entity.Property(e => e.Sbq2Aa16)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_AA16");
            entity.Property(e => e.Sbq2Aa17)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_AA17");
            entity.Property(e => e.Sbq2Aa18)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_AA18");
            entity.Property(e => e.Sbq2Aa19)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_AA19");
            entity.Property(e => e.Sbq2Aa2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_AA2");
            entity.Property(e => e.Sbq2Aa20)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_AA20");
            entity.Property(e => e.Sbq2Aa21)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_AA21");
            entity.Property(e => e.Sbq2Aa3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_AA3");
            entity.Property(e => e.Sbq2Aa4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_AA4");
            entity.Property(e => e.Sbq2Aa5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_AA5");
            entity.Property(e => e.Sbq2Aa6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_AA6");
            entity.Property(e => e.Sbq2Aa7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_AA7");
            entity.Property(e => e.Sbq2Aa8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_AA8");
            entity.Property(e => e.Sbq2Aa9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_AA9");
            entity.Property(e => e.Sbq2X1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_X1");
            entity.Property(e => e.Sbq2X10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_X10");
            entity.Property(e => e.Sbq2X11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_X11");
            entity.Property(e => e.Sbq2X2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_X2");
            entity.Property(e => e.Sbq2X3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_X3");
            entity.Property(e => e.Sbq2X4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_X4");
            entity.Property(e => e.Sbq2X5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_X5");
            entity.Property(e => e.Sbq2X6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_X6");
            entity.Property(e => e.Sbq2X7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_X7");
            entity.Property(e => e.Sbq2X8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_X8");
            entity.Property(e => e.Sbq2X9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_X9");
            entity.Property(e => e.Sbq2Xx1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_XX1");
            entity.Property(e => e.Sbq2Xx10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_XX10");
            entity.Property(e => e.Sbq2Xx11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_XX11");
            entity.Property(e => e.Sbq2Xx2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_XX2");
            entity.Property(e => e.Sbq2Xx3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_XX3");
            entity.Property(e => e.Sbq2Xx4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_XX4");
            entity.Property(e => e.Sbq2Xx5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_XX5");
            entity.Property(e => e.Sbq2Xx6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_XX6");
            entity.Property(e => e.Sbq2Xx7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_XX7");
            entity.Property(e => e.Sbq2Xx8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_XX8");
            entity.Property(e => e.Sbq2Xx9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ2_XX9");
            entity.Property(e => e.Uptime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPTIME");
        });

        modelBuilder.Entity<CalSbq4>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_SBQ4");

            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Checkid)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.Sbq4A1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_A1");
            entity.Property(e => e.Sbq4A10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_A10");
            entity.Property(e => e.Sbq4A11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_A11");
            entity.Property(e => e.Sbq4A12)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_A12");
            entity.Property(e => e.Sbq4A13)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_A13");
            entity.Property(e => e.Sbq4A14)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_A14");
            entity.Property(e => e.Sbq4A15)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_A15");
            entity.Property(e => e.Sbq4A16)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_A16");
            entity.Property(e => e.Sbq4A17)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_A17");
            entity.Property(e => e.Sbq4A18)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_A18");
            entity.Property(e => e.Sbq4A19)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_A19");
            entity.Property(e => e.Sbq4A2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_A2");
            entity.Property(e => e.Sbq4A20)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_A20");
            entity.Property(e => e.Sbq4A21)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_A21");
            entity.Property(e => e.Sbq4A3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_A3");
            entity.Property(e => e.Sbq4A4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_A4");
            entity.Property(e => e.Sbq4A5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_A5");
            entity.Property(e => e.Sbq4A6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_A6");
            entity.Property(e => e.Sbq4A7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_A7");
            entity.Property(e => e.Sbq4A8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_A8");
            entity.Property(e => e.Sbq4A9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_A9");
            entity.Property(e => e.Sbq4Aa1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_AA1");
            entity.Property(e => e.Sbq4Aa10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_AA10");
            entity.Property(e => e.Sbq4Aa11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_AA11");
            entity.Property(e => e.Sbq4Aa12)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_AA12");
            entity.Property(e => e.Sbq4Aa13)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_AA13");
            entity.Property(e => e.Sbq4Aa14)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_AA14");
            entity.Property(e => e.Sbq4Aa15)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_AA15");
            entity.Property(e => e.Sbq4Aa16)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_AA16");
            entity.Property(e => e.Sbq4Aa17)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_AA17");
            entity.Property(e => e.Sbq4Aa18)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_AA18");
            entity.Property(e => e.Sbq4Aa19)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_AA19");
            entity.Property(e => e.Sbq4Aa2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_AA2");
            entity.Property(e => e.Sbq4Aa20)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_AA20");
            entity.Property(e => e.Sbq4Aa21)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_AA21");
            entity.Property(e => e.Sbq4Aa3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_AA3");
            entity.Property(e => e.Sbq4Aa4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_AA4");
            entity.Property(e => e.Sbq4Aa5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_AA5");
            entity.Property(e => e.Sbq4Aa6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_AA6");
            entity.Property(e => e.Sbq4Aa7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_AA7");
            entity.Property(e => e.Sbq4Aa8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_AA8");
            entity.Property(e => e.Sbq4Aa9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_AA9");
            entity.Property(e => e.Sbq4I1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_I1");
            entity.Property(e => e.Sbq4I10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_I10");
            entity.Property(e => e.Sbq4I11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_I11");
            entity.Property(e => e.Sbq4I12)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_I12");
            entity.Property(e => e.Sbq4I13)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_I13");
            entity.Property(e => e.Sbq4I14)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_I14");
            entity.Property(e => e.Sbq4I15)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_I15");
            entity.Property(e => e.Sbq4I16)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_I16");
            entity.Property(e => e.Sbq4I17)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_I17");
            entity.Property(e => e.Sbq4I18)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_I18");
            entity.Property(e => e.Sbq4I19)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_I19");
            entity.Property(e => e.Sbq4I2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_I2");
            entity.Property(e => e.Sbq4I20)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_I20");
            entity.Property(e => e.Sbq4I21)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_I21");
            entity.Property(e => e.Sbq4I3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_I3");
            entity.Property(e => e.Sbq4I4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_I4");
            entity.Property(e => e.Sbq4I5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_I5");
            entity.Property(e => e.Sbq4I6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_I6");
            entity.Property(e => e.Sbq4I7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_I7");
            entity.Property(e => e.Sbq4I8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_I8");
            entity.Property(e => e.Sbq4I9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_I9");
            entity.Property(e => e.Sbq4Ii1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_II1");
            entity.Property(e => e.Sbq4Ii10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_II10");
            entity.Property(e => e.Sbq4Ii11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_II11");
            entity.Property(e => e.Sbq4Ii12)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_II12");
            entity.Property(e => e.Sbq4Ii13)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_II13");
            entity.Property(e => e.Sbq4Ii14)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_II14");
            entity.Property(e => e.Sbq4Ii15)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_II15");
            entity.Property(e => e.Sbq4Ii16)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_II16");
            entity.Property(e => e.Sbq4Ii17)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_II17");
            entity.Property(e => e.Sbq4Ii18)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_II18");
            entity.Property(e => e.Sbq4Ii19)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_II19");
            entity.Property(e => e.Sbq4Ii2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_II2");
            entity.Property(e => e.Sbq4Ii20)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_II20");
            entity.Property(e => e.Sbq4Ii21)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_II21");
            entity.Property(e => e.Sbq4Ii3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_II3");
            entity.Property(e => e.Sbq4Ii4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_II4");
            entity.Property(e => e.Sbq4Ii5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_II5");
            entity.Property(e => e.Sbq4Ii6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_II6");
            entity.Property(e => e.Sbq4Ii7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_II7");
            entity.Property(e => e.Sbq4Ii8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_II8");
            entity.Property(e => e.Sbq4Ii9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_II9");
            entity.Property(e => e.Sbq4M1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_M1");
            entity.Property(e => e.Sbq4M10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_M10");
            entity.Property(e => e.Sbq4M11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_M11");
            entity.Property(e => e.Sbq4M2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_M2");
            entity.Property(e => e.Sbq4M3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_M3");
            entity.Property(e => e.Sbq4M4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_M4");
            entity.Property(e => e.Sbq4M5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_M5");
            entity.Property(e => e.Sbq4M6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_M6");
            entity.Property(e => e.Sbq4M7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_M7");
            entity.Property(e => e.Sbq4M8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_M8");
            entity.Property(e => e.Sbq4M9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_M9");
            entity.Property(e => e.Sbq4Mm1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_MM1");
            entity.Property(e => e.Sbq4Mm10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_MM10");
            entity.Property(e => e.Sbq4Mm11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_MM11");
            entity.Property(e => e.Sbq4Mm2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_MM2");
            entity.Property(e => e.Sbq4Mm3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_MM3");
            entity.Property(e => e.Sbq4Mm4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_MM4");
            entity.Property(e => e.Sbq4Mm5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_MM5");
            entity.Property(e => e.Sbq4Mm6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_MM6");
            entity.Property(e => e.Sbq4Mm7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_MM7");
            entity.Property(e => e.Sbq4Mm8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_MM8");
            entity.Property(e => e.Sbq4Mm9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_MM9");
            entity.Property(e => e.Sbq4X1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_X1");
            entity.Property(e => e.Sbq4X10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_X10");
            entity.Property(e => e.Sbq4X11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_X11");
            entity.Property(e => e.Sbq4X2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_X2");
            entity.Property(e => e.Sbq4X3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_X3");
            entity.Property(e => e.Sbq4X4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_X4");
            entity.Property(e => e.Sbq4X5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_X5");
            entity.Property(e => e.Sbq4X6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_X6");
            entity.Property(e => e.Sbq4X7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_X7");
            entity.Property(e => e.Sbq4X8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_X8");
            entity.Property(e => e.Sbq4X9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_X9");
            entity.Property(e => e.Sbq4Xx1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_XX1");
            entity.Property(e => e.Sbq4Xx10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_XX10");
            entity.Property(e => e.Sbq4Xx11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_XX11");
            entity.Property(e => e.Sbq4Xx2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_XX2");
            entity.Property(e => e.Sbq4Xx3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_XX3");
            entity.Property(e => e.Sbq4Xx4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_XX4");
            entity.Property(e => e.Sbq4Xx5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_XX5");
            entity.Property(e => e.Sbq4Xx6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_XX6");
            entity.Property(e => e.Sbq4Xx7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_XX7");
            entity.Property(e => e.Sbq4Xx8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_XX8");
            entity.Property(e => e.Sbq4Xx9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SBQ4_XX9");
            entity.Property(e => e.Uptime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPTIME");
        });

        modelBuilder.Entity<CalStand>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_STAND");

            entity.Property(e => e.Calibrator)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CALIBRATOR");
            entity.Property(e => e.Checkid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.Description)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.DueDate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DUE_DATE");
            entity.Property(e => e.IdNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ID_NO");
            entity.Property(e => e.MfgM)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MFG_M");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Parameter)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PARAMETER");
            entity.Property(e => e.Procedure)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PROCEDURE");
            entity.Property(e => e.ReportName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("REPORT_NAME");
            entity.Property(e => e.Signer)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SIGNER");
            entity.Property(e => e.Sn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SN");
            entity.Property(e => e.TestDate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TEST_DATE");
        });

        modelBuilder.Entity<CalTicketD>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_TICKET_D");

            entity.HasIndex(e => e.Ticketno, "CAL_TICKET_D_IDX1").IsUnique();

            entity.Property(e => e.Applicantid)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("APPLICANTID");
            entity.Property(e => e.Applicantname)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("APPLICANTNAME");
            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.BfReason)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("BF_REASON");
            entity.Property(e => e.Brand)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BRAND");
            entity.Property(e => e.Createdate)
                .HasDefaultValueSql("sysdate")
                .HasColumnType("DATE")
                .HasColumnName("CREATEDATE");
            entity.Property(e => e.Department)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT");
            entity.Property(e => e.Englishdesc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ENGLISHDESC");
            entity.Property(e => e.LastDate)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("LAST_DATE");
            entity.Property(e => e.Model)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MODEL");
            entity.Property(e => e.NextDate)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("NEXT_DATE");
            entity.Property(e => e.Plant)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PLANT");
            entity.Property(e => e.Serialno)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SERIALNO");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("STATUS");
            entity.Property(e => e.TestDate)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("TEST_DATE");
            entity.Property(e => e.TestPic)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("TEST_PIC");
            entity.Property(e => e.Ticketno)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TICKETNO");
            entity.Property(e => e.Tickettype)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("TICKETTYPE");
            entity.Property(e => e.WxReason1)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("WX_REASON1");
            entity.Property(e => e.WxReason2)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("WX_REASON2");
            entity.Property(e => e.WxReason3)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("WX_REASON3");
            entity.Property(e => e.YsReason)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("YS_REASON");
        });

        modelBuilder.Entity<CalTicketFlow>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_TICKET_FLOW");

            entity.HasIndex(e => new { e.Ticketno, e.Picid }, "CAL_TICKET_FLOW_IDX1");

            entity.Property(e => e.Picid)
                .IsRequired()
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("PICID");
            entity.Property(e => e.Picmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PICMAIL");
            entity.Property(e => e.Picname)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("PICNAME");
            entity.Property(e => e.Remark)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("REMARK");
            entity.Property(e => e.Signdate)
                .HasDefaultValueSql("NULL")
                .HasColumnType("DATE")
                .HasColumnName("SIGNDATE");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N'")
                .HasColumnName("STATUS");
            entity.Property(e => e.Step)
                .IsRequired()
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("STEP");
            entity.Property(e => e.Ticketno)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TICKETNO");
        });

        modelBuilder.Entity<CalTicketRejectmailcc>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_TICKET_REJECTMAILCC");

            entity.Property(e => e.Mailadd)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("MAILADD");
        });

        modelBuilder.Entity<CalUp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_UP");

            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Brand)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BRAND");
            entity.Property(e => e.Calibrator)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CALIBRATOR");
            entity.Property(e => e.Checkid)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.Coc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("COC");
            entity.Property(e => e.Department)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT");
            entity.Property(e => e.Docno)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DOCNO");
            entity.Property(e => e.Englishdesc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ENGLISHDESC");
            entity.Property(e => e.LastDate)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("LAST_DATE");
            entity.Property(e => e.Model)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MODEL");
            entity.Property(e => e.NextDate)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("NEXT_DATE");
            entity.Property(e => e.Plant)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PLANT");
            entity.Property(e => e.Readj)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("READJ");
            entity.Property(e => e.Repair)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("REPAIR");
            entity.Property(e => e.Result)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("RESULT");
            entity.Property(e => e.Rh)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("RH");
            entity.Property(e => e.Serialno)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SERIALNO");
            entity.Property(e => e.Signer)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SIGNER");
            entity.Property(e => e.Signstatus)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("SIGNSTATUS");
            entity.Property(e => e.Signtime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SIGNTIME");
            entity.Property(e => e.Temp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TEMP");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TYPE");
            entity.Property(e => e.Uptime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPTIME");
        });

        modelBuilder.Entity<CalWyb1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_WYB1");

            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Checkid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.Uptime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPTIME");
            entity.Property(e => e.Wyb1A1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A1");
            entity.Property(e => e.Wyb1A10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A10");
            entity.Property(e => e.Wyb1A11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A11");
            entity.Property(e => e.Wyb1A12)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A12");
            entity.Property(e => e.Wyb1A13)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A13");
            entity.Property(e => e.Wyb1A14)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A14");
            entity.Property(e => e.Wyb1A15)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A15");
            entity.Property(e => e.Wyb1A16)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A16");
            entity.Property(e => e.Wyb1A17)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A17");
            entity.Property(e => e.Wyb1A18)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A18");
            entity.Property(e => e.Wyb1A19)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A19");
            entity.Property(e => e.Wyb1A2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A2");
            entity.Property(e => e.Wyb1A20)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A20");
            entity.Property(e => e.Wyb1A21)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A21");
            entity.Property(e => e.Wyb1A22)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A22");
            entity.Property(e => e.Wyb1A23)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A23");
            entity.Property(e => e.Wyb1A24)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A24");
            entity.Property(e => e.Wyb1A25)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A25");
            entity.Property(e => e.Wyb1A26)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A26");
            entity.Property(e => e.Wyb1A27)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A27");
            entity.Property(e => e.Wyb1A28)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A28");
            entity.Property(e => e.Wyb1A29)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A29");
            entity.Property(e => e.Wyb1A3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A3");
            entity.Property(e => e.Wyb1A30)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A30");
            entity.Property(e => e.Wyb1A31)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A31");
            entity.Property(e => e.Wyb1A32)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A32");
            entity.Property(e => e.Wyb1A33)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A33");
            entity.Property(e => e.Wyb1A34)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A34");
            entity.Property(e => e.Wyb1A4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A4");
            entity.Property(e => e.Wyb1A5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A5");
            entity.Property(e => e.Wyb1A6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A6");
            entity.Property(e => e.Wyb1A7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A7");
            entity.Property(e => e.Wyb1A8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A8");
            entity.Property(e => e.Wyb1A9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_A9");
            entity.Property(e => e.Wyb1X1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_X1");
            entity.Property(e => e.Wyb1X10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_X10");
            entity.Property(e => e.Wyb1X11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_X11");
            entity.Property(e => e.Wyb1X2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_X2");
            entity.Property(e => e.Wyb1X3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_X3");
            entity.Property(e => e.Wyb1X4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_X4");
            entity.Property(e => e.Wyb1X5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_X5");
            entity.Property(e => e.Wyb1X6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_X6");
            entity.Property(e => e.Wyb1X7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_X7");
            entity.Property(e => e.Wyb1X8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_X8");
            entity.Property(e => e.Wyb1X9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB1_X9");
        });

        modelBuilder.Entity<CalWyb2>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_WYB2");

            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Checkid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.Uptime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPTIME");
            entity.Property(e => e.Wyb2A1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A1");
            entity.Property(e => e.Wyb2A10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A10");
            entity.Property(e => e.Wyb2A11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A11");
            entity.Property(e => e.Wyb2A12)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A12");
            entity.Property(e => e.Wyb2A13)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A13");
            entity.Property(e => e.Wyb2A14)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A14");
            entity.Property(e => e.Wyb2A15)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A15");
            entity.Property(e => e.Wyb2A16)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A16");
            entity.Property(e => e.Wyb2A17)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A17");
            entity.Property(e => e.Wyb2A18)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A18");
            entity.Property(e => e.Wyb2A19)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A19");
            entity.Property(e => e.Wyb2A2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A2");
            entity.Property(e => e.Wyb2A20)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A20");
            entity.Property(e => e.Wyb2A21)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A21");
            entity.Property(e => e.Wyb2A22)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A22");
            entity.Property(e => e.Wyb2A23)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A23");
            entity.Property(e => e.Wyb2A24)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A24");
            entity.Property(e => e.Wyb2A25)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A25");
            entity.Property(e => e.Wyb2A26)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A26");
            entity.Property(e => e.Wyb2A27)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A27");
            entity.Property(e => e.Wyb2A28)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A28");
            entity.Property(e => e.Wyb2A29)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A29");
            entity.Property(e => e.Wyb2A3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A3");
            entity.Property(e => e.Wyb2A30)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A30");
            entity.Property(e => e.Wyb2A31)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A31");
            entity.Property(e => e.Wyb2A32)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A32");
            entity.Property(e => e.Wyb2A33)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A33");
            entity.Property(e => e.Wyb2A34)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A34");
            entity.Property(e => e.Wyb2A4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A4");
            entity.Property(e => e.Wyb2A5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A5");
            entity.Property(e => e.Wyb2A6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A6");
            entity.Property(e => e.Wyb2A7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A7");
            entity.Property(e => e.Wyb2A8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A8");
            entity.Property(e => e.Wyb2A9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_A9");
            entity.Property(e => e.Wyb2X1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_X1");
            entity.Property(e => e.Wyb2X10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_X10");
            entity.Property(e => e.Wyb2X11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_X11");
            entity.Property(e => e.Wyb2X2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_X2");
            entity.Property(e => e.Wyb2X3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_X3");
            entity.Property(e => e.Wyb2X4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_X4");
            entity.Property(e => e.Wyb2X5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_X5");
            entity.Property(e => e.Wyb2X6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_X6");
            entity.Property(e => e.Wyb2X7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_X7");
            entity.Property(e => e.Wyb2X8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_X8");
            entity.Property(e => e.Wyb2X9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WYB2_X9");
        });

        modelBuilder.Entity<CalYbkc1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_YBKC1");

            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Checkid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.Uptime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPTIME");
            entity.Property(e => e.Ybkc1X1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC1_X1");
            entity.Property(e => e.Ybkc1X10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC1_X10");
            entity.Property(e => e.Ybkc1X2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC1_X2");
            entity.Property(e => e.Ybkc1X3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC1_X3");
            entity.Property(e => e.Ybkc1X4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC1_X4");
            entity.Property(e => e.Ybkc1X5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC1_X5");
            entity.Property(e => e.Ybkc1X6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC1_X6");
            entity.Property(e => e.Ybkc1X7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC1_X7");
            entity.Property(e => e.Ybkc1X8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC1_X8");
            entity.Property(e => e.Ybkc1X9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC1_X9");
        });

        modelBuilder.Entity<CalYbkc2>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_YBKC2");

            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Checkid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.Uptime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPTIME");
            entity.Property(e => e.Ybkc2X1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC2_X1");
            entity.Property(e => e.Ybkc2X10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC2_X10");
            entity.Property(e => e.Ybkc2X11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC2_X11");
            entity.Property(e => e.Ybkc2X2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC2_X2");
            entity.Property(e => e.Ybkc2X3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC2_X3");
            entity.Property(e => e.Ybkc2X4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC2_X4");
            entity.Property(e => e.Ybkc2X5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC2_X5");
            entity.Property(e => e.Ybkc2X6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC2_X6");
            entity.Property(e => e.Ybkc2X7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC2_X7");
            entity.Property(e => e.Ybkc2X8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC2_X8");
            entity.Property(e => e.Ybkc2X9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC2_X9");
        });

        modelBuilder.Entity<CalYbkc3>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_YBKC3");

            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Checkid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.Uptime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPTIME");
            entity.Property(e => e.Ybkc3X1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC3_X1");
            entity.Property(e => e.Ybkc3X2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC3_X2");
            entity.Property(e => e.Ybkc3X3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC3_X3");
            entity.Property(e => e.Ybkc3X4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC3_X4");
            entity.Property(e => e.Ybkc3X5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC3_X5");
            entity.Property(e => e.Ybkc3X6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC3_X6");
            entity.Property(e => e.Ybkc3X7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC3_X7");
            entity.Property(e => e.Ybkc3X8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC3_X8");
        });

        modelBuilder.Entity<CalYbkc4>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_YBKC4");

            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Checkid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.Uptime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPTIME");
            entity.Property(e => e.Ybkc4X1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC4_X1");
            entity.Property(e => e.Ybkc4X2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC4_X2");
            entity.Property(e => e.Ybkc4X3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC4_X3");
            entity.Property(e => e.Ybkc4X4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC4_X4");
            entity.Property(e => e.Ybkc4X5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC4_X5");
            entity.Property(e => e.Ybkc4X6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC4_X6");
            entity.Property(e => e.Ybkc4X7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC4_X7");
            entity.Property(e => e.Ybkc4X8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC4_X8");
            entity.Property(e => e.Ybkc4X9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YBKC4_X9");
        });

        modelBuilder.Entity<CalYlnzq>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_YLNZQ");

            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Checkid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.Uptime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPTIME");
            entity.Property(e => e.YlnzqX1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YLNZQ_X1");
            entity.Property(e => e.YlnzqX10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YLNZQ_X10");
            entity.Property(e => e.YlnzqX11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YLNZQ_X11");
            entity.Property(e => e.YlnzqX12)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YLNZQ_X12");
            entity.Property(e => e.YlnzqX2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YLNZQ_X2");
            entity.Property(e => e.YlnzqX3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YLNZQ_X3");
            entity.Property(e => e.YlnzqX4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YLNZQ_X4");
            entity.Property(e => e.YlnzqX5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YLNZQ_X5");
            entity.Property(e => e.YlnzqX6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YLNZQ_X6");
            entity.Property(e => e.YlnzqX7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YLNZQ_X7");
            entity.Property(e => e.YlnzqX8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YLNZQ_X8");
            entity.Property(e => e.YlnzqX9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("YLNZQ_X9");
        });

        modelBuilder.Entity<CalZlwydy1201gsma>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_ZLWYDY1201GSMA");

            entity.Property(e => e.Assetag)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Checkid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.Uptime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPTIME");
            entity.Property(e => e.Zlwydy1201X1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY1201_X1");
            entity.Property(e => e.Zlwydy1201X10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY1201_X10");
            entity.Property(e => e.Zlwydy1201X11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY1201_X11");
            entity.Property(e => e.Zlwydy1201X12)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY1201_X12");
            entity.Property(e => e.Zlwydy1201X13)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY1201_X13");
            entity.Property(e => e.Zlwydy1201X14)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY1201_X14");
            entity.Property(e => e.Zlwydy1201X15)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY1201_X15");
            entity.Property(e => e.Zlwydy1201X16)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY1201_X16");
            entity.Property(e => e.Zlwydy1201X17)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY1201_X17");
            entity.Property(e => e.Zlwydy1201X18)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY1201_X18");
            entity.Property(e => e.Zlwydy1201X2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY1201_X2");
            entity.Property(e => e.Zlwydy1201X3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY1201_X3");
            entity.Property(e => e.Zlwydy1201X4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY1201_X4");
            entity.Property(e => e.Zlwydy1201X5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY1201_X5");
            entity.Property(e => e.Zlwydy1201X6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY1201_X6");
            entity.Property(e => e.Zlwydy1201X7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY1201_X7");
            entity.Property(e => e.Zlwydy1201X8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY1201_X8");
            entity.Property(e => e.Zlwydy1201X9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY1201_X9");
        });

        modelBuilder.Entity<CalZlwydy2306>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_ZLWYDY2306");

            entity.Property(e => e.Assetag)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Checkid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.Uptime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPTIME");
            entity.Property(e => e.Zlwydy2306X1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2306_X1");
            entity.Property(e => e.Zlwydy2306X10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2306_X10");
            entity.Property(e => e.Zlwydy2306X11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2306_X11");
            entity.Property(e => e.Zlwydy2306X12)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2306_X12");
            entity.Property(e => e.Zlwydy2306X13)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2306_X13");
            entity.Property(e => e.Zlwydy2306X14)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2306_X14");
            entity.Property(e => e.Zlwydy2306X15)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2306_X15");
            entity.Property(e => e.Zlwydy2306X16)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2306_X16");
            entity.Property(e => e.Zlwydy2306X17)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2306_X17");
            entity.Property(e => e.Zlwydy2306X18)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2306_X18");
            entity.Property(e => e.Zlwydy2306X19)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2306_X19");
            entity.Property(e => e.Zlwydy2306X2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2306_X2");
            entity.Property(e => e.Zlwydy2306X20)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2306_X20");
            entity.Property(e => e.Zlwydy2306X21)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2306_X21");
            entity.Property(e => e.Zlwydy2306X22)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2306_X22");
            entity.Property(e => e.Zlwydy2306X3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2306_X3");
            entity.Property(e => e.Zlwydy2306X4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2306_X4");
            entity.Property(e => e.Zlwydy2306X5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2306_X5");
            entity.Property(e => e.Zlwydy2306X6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2306_X6");
            entity.Property(e => e.Zlwydy2306X7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2306_X7");
            entity.Property(e => e.Zlwydy2306X8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2306_X8");
            entity.Property(e => e.Zlwydy2306X9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2306_X9");
        });

        modelBuilder.Entity<CalZlwydy2308>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_ZLWYDY2308");

            entity.Property(e => e.Assetag)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Checkid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.Uptime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPTIME");
            entity.Property(e => e.Zlwydy2308X1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2308_X1");
            entity.Property(e => e.Zlwydy2308X10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2308_X10");
            entity.Property(e => e.Zlwydy2308X11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2308_X11");
            entity.Property(e => e.Zlwydy2308X12)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2308_X12");
            entity.Property(e => e.Zlwydy2308X13)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2308_X13");
            entity.Property(e => e.Zlwydy2308X14)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2308_X14");
            entity.Property(e => e.Zlwydy2308X15)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2308_X15");
            entity.Property(e => e.Zlwydy2308X16)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2308_X16");
            entity.Property(e => e.Zlwydy2308X17)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2308_X17");
            entity.Property(e => e.Zlwydy2308X18)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2308_X18");
            entity.Property(e => e.Zlwydy2308X19)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2308_X19");
            entity.Property(e => e.Zlwydy2308X2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2308_X2");
            entity.Property(e => e.Zlwydy2308X20)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2308_X20");
            entity.Property(e => e.Zlwydy2308X3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2308_X3");
            entity.Property(e => e.Zlwydy2308X4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2308_X4");
            entity.Property(e => e.Zlwydy2308X5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2308_X5");
            entity.Property(e => e.Zlwydy2308X6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2308_X6");
            entity.Property(e => e.Zlwydy2308X7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2308_X7");
            entity.Property(e => e.Zlwydy2308X8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2308_X8");
            entity.Property(e => e.Zlwydy2308X9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY2308_X9");
        });

        modelBuilder.Entity<CalZlwydy3030>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_ZLWYDY3030");

            entity.Property(e => e.Assetag)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Checkid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.Uptime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPTIME");
            entity.Property(e => e.Zlwydy3030X1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY3030_X1");
            entity.Property(e => e.Zlwydy3030X10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY3030_X10");
            entity.Property(e => e.Zlwydy3030X11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY3030_X11");
            entity.Property(e => e.Zlwydy3030X12)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY3030_X12");
            entity.Property(e => e.Zlwydy3030X13)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY3030_X13");
            entity.Property(e => e.Zlwydy3030X14)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY3030_X14");
            entity.Property(e => e.Zlwydy3030X15)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY3030_X15");
            entity.Property(e => e.Zlwydy3030X16)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY3030_X16");
            entity.Property(e => e.Zlwydy3030X2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY3030_X2");
            entity.Property(e => e.Zlwydy3030X3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY3030_X3");
            entity.Property(e => e.Zlwydy3030X4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY3030_X4");
            entity.Property(e => e.Zlwydy3030X5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY3030_X5");
            entity.Property(e => e.Zlwydy3030X6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY3030_X6");
            entity.Property(e => e.Zlwydy3030X7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY3030_X7");
            entity.Property(e => e.Zlwydy3030X8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY3030_X8");
            entity.Property(e => e.Zlwydy3030X9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY3030_X9");
        });

        modelBuilder.Entity<CalZlwydy3303d>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_ZLWYDY3303D");

            entity.Property(e => e.Assetag)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Checkid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.Uptime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPTIME");
            entity.Property(e => e.Zlwydy3303X1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY3303_X1");
            entity.Property(e => e.Zlwydy3303X10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY3303_X10");
            entity.Property(e => e.Zlwydy3303X2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY3303_X2");
            entity.Property(e => e.Zlwydy3303X3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY3303_X3");
            entity.Property(e => e.Zlwydy3303X4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY3303_X4");
            entity.Property(e => e.Zlwydy3303X5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY3303_X5");
            entity.Property(e => e.Zlwydy3303X6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY3303_X6");
            entity.Property(e => e.Zlwydy3303X7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY3303_X7");
            entity.Property(e => e.Zlwydy3303X8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY3303_X8");
            entity.Property(e => e.Zlwydy3303X9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY3303_X9");
        });

        modelBuilder.Entity<CalZlwydy66309d>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_ZLWYDY66309D");

            entity.Property(e => e.Assetag)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Checkid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.Uptime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPTIME");
            entity.Property(e => e.Zlwydy66309X1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY66309_X1");
            entity.Property(e => e.Zlwydy66309X10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY66309_X10");
            entity.Property(e => e.Zlwydy66309X11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY66309_X11");
            entity.Property(e => e.Zlwydy66309X12)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY66309_X12");
            entity.Property(e => e.Zlwydy66309X13)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY66309_X13");
            entity.Property(e => e.Zlwydy66309X14)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY66309_X14");
            entity.Property(e => e.Zlwydy66309X15)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY66309_X15");
            entity.Property(e => e.Zlwydy66309X16)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY66309_X16");
            entity.Property(e => e.Zlwydy66309X17)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY66309_X17");
            entity.Property(e => e.Zlwydy66309X2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY66309_X2");
            entity.Property(e => e.Zlwydy66309X3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY66309_X3");
            entity.Property(e => e.Zlwydy66309X4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY66309_X4");
            entity.Property(e => e.Zlwydy66309X5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY66309_X5");
            entity.Property(e => e.Zlwydy66309X6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY66309_X6");
            entity.Property(e => e.Zlwydy66309X7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY66309_X7");
            entity.Property(e => e.Zlwydy66309X8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY66309_X8");
            entity.Property(e => e.Zlwydy66309X9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY66309_X9");
        });

        modelBuilder.Entity<CalZlwydy6632b>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAL_ZLWYDY6632B");

            entity.Property(e => e.Assetag)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Checkid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CHECKID");
            entity.Property(e => e.Uptime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPTIME");
            entity.Property(e => e.Zlwydy6632X1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY6632_X1");
            entity.Property(e => e.Zlwydy6632X10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY6632_X10");
            entity.Property(e => e.Zlwydy6632X11)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY6632_X11");
            entity.Property(e => e.Zlwydy6632X2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY6632_X2");
            entity.Property(e => e.Zlwydy6632X3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY6632_X3");
            entity.Property(e => e.Zlwydy6632X4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY6632_X4");
            entity.Property(e => e.Zlwydy6632X5)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY6632_X5");
            entity.Property(e => e.Zlwydy6632X6)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY6632_X6");
            entity.Property(e => e.Zlwydy6632X7)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY6632_X7");
            entity.Property(e => e.Zlwydy6632X8)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY6632_X8");
            entity.Property(e => e.Zlwydy6632X9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZLWYDY6632_X9");
        });

        modelBuilder.Entity<Calchecklist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("CALCHECKLIST_PK");

            entity.ToTable("CALCHECKLIST");

            entity.HasIndex(e => new { e.Assetag, e.Checkflag }, "CHECKLIST_INX").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("ID");
            entity.Property(e => e.ApproveDate)
                .HasColumnType("DATE")
                .HasColumnName("APPROVE_DATE");
            entity.Property(e => e.ApproveMsg)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("APPROVE_MSG");
            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Auditlevel)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("AUDITLEVEL");
            entity.Property(e => e.Auditor)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("AUDITOR");
            entity.Property(e => e.Checkflag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CHECKFLAG");
            entity.Property(e => e.Createdate)
                .HasColumnType("DATE")
                .HasColumnName("CREATEDATE");
            entity.Property(e => e.Cycletime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CYCLETIME");
            entity.Property(e => e.Memo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MEMO");
            entity.Property(e => e.Publishdate)
                .HasColumnType("DATE")
                .HasColumnName("PUBLISHDATE");
            entity.Property(e => e.Seq)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("SEQ");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("STATUS");
            entity.Property(e => e.Updatedate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
        });

        modelBuilder.Entity<Calemslst>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CALEMSLST");

            entity.HasIndex(e => e.Assetag, "CALEMSLST_IDX1").IsUnique();

            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.BinEmplid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BIN_EMPLID");
            entity.Property(e => e.Comp)
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("COMP");
            entity.Property(e => e.Currency)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("CURRENCY");
            entity.Property(e => e.Item)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ITEM");
            entity.Property(e => e.Itemdesc)
                .HasMaxLength(240)
                .IsUnicode(false)
                .HasColumnName("ITEMDESC");
            entity.Property(e => e.Logdate)
                .HasDefaultValueSql("SYSDATE ")
                .HasColumnType("DATE")
                .HasColumnName("LOGDATE");
            entity.Property(e => e.Loginid)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("LOGINID");
            entity.Property(e => e.Price)
                .HasColumnType("NUMBER(12,3)")
                .HasColumnName("PRICE");
            entity.Property(e => e.Sn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SN");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'O' ")
                .HasColumnName("STATUS");
            entity.Property(e => e.WhDeptid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WH_DEPTID");
        });

        modelBuilder.Entity<Calmaillist>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CALMAILLIST");

            entity.Property(e => e.Memberlist)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("MEMBERLIST");
            entity.Property(e => e.Plant)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("PLANT");
            entity.Property(e => e.Sendmail)
                .HasPrecision(2)
                .HasColumnName("SENDMAIL");
        });

        modelBuilder.Entity<CalmaillistJ>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CALMAILLIST_J");

            entity.Property(e => e.Memberlist)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("MEMBERLIST");
            entity.Property(e => e.Plant)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("PLANT");
            entity.Property(e => e.Sendmail)
                .HasPrecision(2)
                .HasColumnName("SENDMAIL");
        });

        modelBuilder.Entity<Calmain>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("CALMAIN_PK");

            entity.ToTable("CALMAIN");

            entity.HasIndex(e => e.Assetag, "CALMAIN_IDX1").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ID");
            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Attach)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ATTACH");
            entity.Property(e => e.Attribute)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("ATTRIBUTE");
            entity.Property(e => e.Brand)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("BRAND");
            entity.Property(e => e.Calfee)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("CALFEE");
            entity.Property(e => e.Cycle)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CYCLE");
            entity.Property(e => e.Department)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("DEPARTMENT");
            entity.Property(e => e.FirstDate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("FIRST_DATE");
            entity.Property(e => e.Inspno)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("INSPNO");
            entity.Property(e => e.Keeper)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("KEEPER");
            entity.Property(e => e.Keepername)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("KEEPERNAME");
            entity.Property(e => e.LastDate)
                .HasMaxLength(16)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("LAST_DATE");
            entity.Property(e => e.Logdate)
                .HasColumnType("DATE")
                .HasColumnName("LOGDATE");
            entity.Property(e => e.Loginid)
                .HasMaxLength(16)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("LOGINID");
            entity.Property(e => e.Model)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("MODEL");
            entity.Property(e => e.NextDate)
                .HasMaxLength(16)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("NEXT_DATE");
            entity.Property(e => e.Nocalremark)
                .HasMaxLength(100)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("NOCALREMARK");
            entity.Property(e => e.Pic)
                .HasMaxLength(16)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("PIC");
            entity.Property(e => e.Plant)
                .HasMaxLength(16)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("PLANT");
            entity.Property(e => e.Price)
                .HasMaxLength(10)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("PRICE");
            entity.Property(e => e.Project)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PROJECT");
            entity.Property(e => e.Sendmail)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("SENDMAIL");
            entity.Property(e => e.Sendpic)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("SENDPIC");
            entity.Property(e => e.Serialno)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("SERIALNO");
            entity.Property(e => e.Status)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("STATUS");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("TYPE");
        });

        modelBuilder.Entity<Calmodel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("CALMODEL_PK");

            entity.ToTable("CALMODEL");

            entity.HasIndex(e => e.Model, "CALMODEL_IDX1").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ID");
            entity.Property(e => e.Attribute)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE");
            entity.Property(e => e.Brand)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("BRAND");
            entity.Property(e => e.Caldepartment)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CALDEPARTMENT");
            entity.Property(e => e.Chinesedesc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CHINESEDESC");
            entity.Property(e => e.Cycle)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CYCLE");
            entity.Property(e => e.Englishdesc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ENGLISHDESC");
            entity.Property(e => e.Logdate)
                .HasColumnType("DATE")
                .HasColumnName("LOGDATE");
            entity.Property(e => e.Loginid)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("LOGINID");
            entity.Property(e => e.Model)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MODEL");
        });

        modelBuilder.Entity<Caluser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("CALUSERS_PK");

            entity.ToTable("CALUSERS");

            entity.HasIndex(e => new { e.Loginid, e.Department }, "CALUSERS_IDX1").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ID");
            entity.Property(e => e.Department)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT");
            entity.Property(e => e.Emplid)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EMPLID");
            entity.Property(e => e.Logdate)
                .HasColumnType("DATE")
                .HasColumnName("LOGDATE");
            entity.Property(e => e.Loginid)
                .IsRequired()
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("LOGINID");
            entity.Property(e => e.Password)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Right)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("RIGHT");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USERNAME");
        });

        modelBuilder.Entity<HrAt>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("HR_AT");

            entity.Property(e => e.Company)
                .HasMaxLength(3)
                .HasColumnName("COMPANY");
            entity.Property(e => e.DeptDescrA)
                .HasMaxLength(50)
                .HasColumnName("DEPT_DESCR_A");
            entity.Property(e => e.Deptid)
                .HasMaxLength(20)
                .HasColumnName("DEPTID");
            entity.Property(e => e.EmailAddressA)
                .HasMaxLength(120)
                .HasColumnName("EMAIL_ADDRESS_A");
            entity.Property(e => e.EmplCategoryA)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("EMPL_CATEGORY_A");
            entity.Property(e => e.Emplid)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("EMPLID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("NAME");
            entity.Property(e => e.NameA)
                .HasMaxLength(50)
                .HasColumnName("NAME_A");
            entity.Property(e => e.OfficerLevelA)
                .HasPrecision(3)
                .HasColumnName("OFFICER_LEVEL_A");
            entity.Property(e => e.PhoneA)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("PHONE_A");
            entity.Property(e => e.SupervisorId)
                .HasMaxLength(20)
                .HasColumnName("SUPERVISOR_ID");
            entity.Property(e => e.UpperDeptidA)
                .HasMaxLength(20)
                .HasColumnName("UPPER_DEPTID_A");
        });

        modelBuilder.Entity<HrAtOld>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("HR_AT_OLD");

            entity.Property(e => e.Company)
                .HasMaxLength(3)
                .HasColumnName("COMPANY");
            entity.Property(e => e.DeptDescrA)
                .HasMaxLength(50)
                .HasColumnName("DEPT_DESCR_A");
            entity.Property(e => e.Deptid)
                .HasMaxLength(20)
                .HasColumnName("DEPTID");
            entity.Property(e => e.EmailAddressA)
                .HasMaxLength(50)
                .HasColumnName("EMAIL_ADDRESS_A");
            entity.Property(e => e.EmplCategoryA)
                .HasMaxLength(10)
                .HasColumnName("EMPL_CATEGORY_A");
            entity.Property(e => e.Emplid)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("EMPLID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("NAME");
            entity.Property(e => e.NameA)
                .HasMaxLength(50)
                .HasColumnName("NAME_A");
            entity.Property(e => e.OfficerLevelA)
                .HasPrecision(3)
                .HasColumnName("OFFICER_LEVEL_A");
            entity.Property(e => e.PhoneA)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("PHONE_A");
            entity.Property(e => e.SupervisorId)
                .HasMaxLength(20)
                .HasColumnName("SUPERVISOR_ID");
            entity.Property(e => e.UpperDeptidA)
                .HasMaxLength(20)
                .HasColumnName("UPPER_DEPTID_A");
        });

        modelBuilder.Entity<IqcLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("IQC_LOG");

            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Cycle)
                .HasColumnType("NUMBER")
                .HasColumnName("CYCLE");
            entity.Property(e => e.Department)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT");
            entity.Property(e => e.Flag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("FLAG");
            entity.Property(e => e.Keeper)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("KEEPER");
            entity.Property(e => e.LDate)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("L_DATE");
            entity.Property(e => e.Location)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("LOCATION");
            entity.Property(e => e.Logdate)
                .HasColumnType("DATE")
                .HasColumnName("LOGDATE");
            entity.Property(e => e.Loginid)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("LOGINID");
            entity.Property(e => e.Model)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("MODEL");
            entity.Property(e => e.NDate)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("N_DATE");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Nocalremark)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOCALREMARK");
            entity.Property(e => e.Pic)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("PIC");
            entity.Property(e => e.Plant)
                .IsRequired()
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("PLANT");
            entity.Property(e => e.Result)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("RESULT");
            entity.Property(e => e.Status)
                .HasColumnType("NUMBER(1)")
                .HasColumnName("STATUS");
        });

        modelBuilder.Entity<Iqcmaillist>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("IQCMAILLIST");

            entity.Property(e => e.Memberlist)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("MEMBERLIST");
            entity.Property(e => e.Plant)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("PLANT");
            entity.Property(e => e.Sendmail)
                .HasPrecision(2)
                .HasColumnName("SENDMAIL");
        });

        modelBuilder.Entity<Iqcmain>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("IQCMAIN");

            entity.HasIndex(e => e.Assetag, "IQCMAIN_IDX1").IsUnique();

            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Cycle)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("CYCLE");
            entity.Property(e => e.Department)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("DEPARTMENT");
            entity.Property(e => e.Keeper)
                .HasMaxLength(16)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("KEEPER");
            entity.Property(e => e.LDate)
                .HasMaxLength(8)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("L_DATE");
            entity.Property(e => e.Location)
                .HasMaxLength(30)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("LOCATION");
            entity.Property(e => e.Logdate)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("LOGDATE");
            entity.Property(e => e.Loginid)
                .HasMaxLength(8)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("LOGINID");
            entity.Property(e => e.Model)
                .HasMaxLength(30)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("MODEL");
            entity.Property(e => e.NDate)
                .HasMaxLength(8)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("N_DATE");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("NAME");
            entity.Property(e => e.Nocalremark)
                .HasMaxLength(100)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("NOCALREMARK");
            entity.Property(e => e.Pic)
                .HasMaxLength(16)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("PIC");
            entity.Property(e => e.Plant)
                .IsRequired()
                .HasMaxLength(16)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("PLANT");
            entity.Property(e => e.Result)
                .HasMaxLength(4)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("RESULT");
            entity.Property(e => e.Status)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(1)")
                .HasColumnName("STATUS");
        });

        modelBuilder.Entity<Iqcmodel>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("IQCMODEL");

            entity.HasIndex(e => new { e.Name, e.Model }, "IQCMODEL_IDX1").IsUnique();

            entity.Property(e => e.Logdate)
                .HasColumnType("DATE")
                .HasColumnName("LOGDATE");
            entity.Property(e => e.Loginid)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("LOGINID");
            entity.Property(e => e.Model)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("MODEL");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Ken>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("KEN");

            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Cycle)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("CYCLE");
            entity.Property(e => e.Department)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT");
            entity.Property(e => e.Keeper)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("KEEPER");
            entity.Property(e => e.LDate)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("L_DATE");
            entity.Property(e => e.Location)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("LOCATION");
            entity.Property(e => e.Logdate)
                .HasColumnType("DATE")
                .HasColumnName("LOGDATE");
            entity.Property(e => e.Loginid)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("LOGINID");
            entity.Property(e => e.Model)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("MODEL");
            entity.Property(e => e.NDate)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("N_DATE");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Nocalremark)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOCALREMARK");
            entity.Property(e => e.Pic)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("PIC");
            entity.Property(e => e.Plant)
                .IsRequired()
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("PLANT");
            entity.Property(e => e.Result)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("RESULT");
            entity.Property(e => e.Status)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("STATUS");
        });

        modelBuilder.Entity<Mtnchart>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MTNCHART");

            entity.HasIndex(e => new { e.Model, e.Brand, e.Department, e.Plant }, "MTNCHART_IDX1").IsUnique();

            entity.Property(e => e.Brand)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BRAND");
            entity.Property(e => e.Cal)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CAL");
            entity.Property(e => e.Cat)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CAT");
            entity.Property(e => e.Cpk)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CPK");
            entity.Property(e => e.Cproce)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CPROCE");
            entity.Property(e => e.Cseq)
                .IsRequired()
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("CSEQ");
            entity.Property(e => e.Department)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT");
            entity.Property(e => e.Gproce)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("GPROCE");
            entity.Property(e => e.Grr)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("GRR");
            entity.Property(e => e.Gseq)
                .IsRequired()
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("GSEQ");
            entity.Property(e => e.Lc)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("LC");
            entity.Property(e => e.Lcproce)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("LCPROCE");
            entity.Property(e => e.Lcseq)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LCSEQ");
            entity.Property(e => e.Logdate)
                .HasColumnType("DATE")
                .HasColumnName("LOGDATE");
            entity.Property(e => e.Loginid)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("LOGINID");
            entity.Property(e => e.Model)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MODEL");
            entity.Property(e => e.Mproce)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("MPROCE");
            entity.Property(e => e.Mtnd)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("MTND");
            entity.Property(e => e.Mtnm)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("MTNM");
            entity.Property(e => e.Mtnq)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("MTNQ");
            entity.Property(e => e.Mtnw)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("MTNW");
            entity.Property(e => e.Mtny)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("MTNY");
            entity.Property(e => e.Plant)
                .IsRequired()
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("PLANT");
        });

        modelBuilder.Entity<Mtnmaillist>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MTNMAILLIST");

            entity.Property(e => e.Memberlist)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("MEMBERLIST");
            entity.Property(e => e.Plant)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("PLANT");
            entity.Property(e => e.Sendmail)
                .HasPrecision(2)
                .HasColumnName("SENDMAIL");
        });

        modelBuilder.Entity<Mtnmain>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MTNMAIN");

            entity.HasIndex(e => new { e.Assetag, e.Plant }, "MTNMAIN_IDX1").IsUnique();

            entity.Property(e => e.Acheck)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("ACHECK");
            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Brand)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BRAND");
            entity.Property(e => e.Daycode)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("DAYCODE");
            entity.Property(e => e.Dcheck)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("DCHECK");
            entity.Property(e => e.Department)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT");
            entity.Property(e => e.Gcheck)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("GCHECK");
            entity.Property(e => e.Keeper)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("KEEPER");
            entity.Property(e => e.Keepername)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("KEEPERNAME");
            entity.Property(e => e.Lifecycle)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("LIFECYCLE");
            entity.Property(e => e.Location)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("LOCATION");
            entity.Property(e => e.Logdate)
                .HasColumnType("DATE")
                .HasColumnName("LOGDATE");
            entity.Property(e => e.Loginid)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("LOGINID");
            entity.Property(e => e.Mcheck)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("MCHECK");
            entity.Property(e => e.Model)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MODEL");
            entity.Property(e => e.Nocalremark)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOCALREMARK");
            entity.Property(e => e.Pic)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("PIC");
            entity.Property(e => e.Picokay)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("PICOKAY");
            entity.Property(e => e.Plant)
                .IsRequired()
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("PLANT");
            entity.Property(e => e.Qcheck)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("QCHECK");
            entity.Property(e => e.Sendmail)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("SENDMAIL");
            entity.Property(e => e.Sopno)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SOPNO");
            entity.Property(e => e.Status)
                .HasColumnType("NUMBER(1)")
                .HasColumnName("STATUS");
            entity.Property(e => e.Wcheck)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("WCHECK");
            entity.Property(e => e.Ycheck)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("YCHECK");
        });

        modelBuilder.Entity<MtnmainHi>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MTNMAIN_HIS");

            entity.Property(e => e.Acheck)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("ACHECK");
            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Brand)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BRAND");
            entity.Property(e => e.Daycode)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("DAYCODE");
            entity.Property(e => e.Dcheck)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("DCHECK");
            entity.Property(e => e.Department)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT");
            entity.Property(e => e.Gcheck)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("GCHECK");
            entity.Property(e => e.Keeper)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("KEEPER");
            entity.Property(e => e.Keepername)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("KEEPERNAME");
            entity.Property(e => e.Location)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("LOCATION");
            entity.Property(e => e.Logdate)
                .HasColumnType("DATE")
                .HasColumnName("LOGDATE");
            entity.Property(e => e.Loginid)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("LOGINID");
            entity.Property(e => e.Mcheck)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("MCHECK");
            entity.Property(e => e.Model)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MODEL");
            entity.Property(e => e.Nocalremark)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOCALREMARK");
            entity.Property(e => e.Pic)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("PIC");
            entity.Property(e => e.Picokay)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("PICOKAY");
            entity.Property(e => e.Plant)
                .IsRequired()
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("PLANT");
            entity.Property(e => e.Qcheck)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("QCHECK");
            entity.Property(e => e.Sendmail)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("SENDMAIL");
            entity.Property(e => e.Sopno)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SOPNO");
            entity.Property(e => e.Status)
                .HasColumnType("NUMBER(1)")
                .HasColumnName("STATUS");
            entity.Property(e => e.Wcheck)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("WCHECK");
            entity.Property(e => e.Ycheck)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("YCHECK");
        });

        modelBuilder.Entity<Mtnmaind>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MTNMAIND");

            entity.HasIndex(e => new { e.Assetag, e.Plant }, "MTNMAIND_IDX1");

            entity.Property(e => e.Assetag)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Daycode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("DAYCODE");
            entity.Property(e => e.LastDate)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("LAST_DATE");
            entity.Property(e => e.Lifecycle)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("LIFECYCLE");
            entity.Property(e => e.Logdate)
                .HasColumnType("DATE")
                .HasColumnName("LOGDATE");
            entity.Property(e => e.Loginid)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("LOGINID");
            entity.Property(e => e.Plant)
                .IsRequired()
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("PLANT");
            entity.Property(e => e.Remark)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("REMARK");
            entity.Property(e => e.Status)
                .HasColumnType("NUMBER(1)")
                .HasColumnName("STATUS");
        });

        modelBuilder.Entity<Mtnmodel>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MTNMODEL");

            entity.HasIndex(e => e.Model, "MTNMODEL_IDX1").IsUnique();

            entity.Property(e => e.Logdate)
                .HasColumnType("DATE")
                .HasColumnName("LOGDATE");
            entity.Property(e => e.Loginid)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("LOGINID");
            entity.Property(e => e.Model)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("MODEL");
        });

        modelBuilder.Entity<Pmdetail>(entity =>
        {
            entity.HasKey(e => e.MachineidSn).HasName("SYS_C007285");

            entity.ToTable("PMDETAILS");

            entity.Property(e => e.MachineidSn)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("MACHINEID_SN");
            entity.Property(e => e.Checklistno)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CHECKLISTNO");
            entity.Property(e => e.Firsttimepmscheduledate)
                .HasPrecision(6)
                .HasColumnName("FIRSTTIMEPMSCHEDULEDATE");
            entity.Property(e => e.Frequency)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FREQUENCY");
            entity.Property(e => e.Ischecked)
                .HasPrecision(10)
                .HasColumnName("ISCHECKED");
            entity.Property(e => e.Lastcheck)
                .HasColumnType("DATE")
                .HasColumnName("LASTCHECK");
            entity.Property(e => e.Line)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("LINE");
            entity.Property(e => e.Machinecategory)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("MACHINECATEGORY");
            entity.Property(e => e.Machinelocation)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("MACHINELOCATION");
            entity.Property(e => e.Machinename)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("MACHINENAME");
            entity.Property(e => e.Make)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("MAKE");
            entity.Property(e => e.Pmmanager)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PMMANAGER");
            entity.Property(e => e.Project)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PROJECT");
            entity.Property(e => e.Subline)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SUBLINE");
            entity.Property(e => e.TataDriname)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TATA_DRINAME");
            entity.Property(e => e.Vendordri)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("VENDORDRI");
        });

        modelBuilder.Entity<Pmscheduledetail>(entity =>
        {
            entity.HasKey(e => e.MachineidSn).HasName("SYS_C007289");

            entity.ToTable("PMSCHEDULEDETAILS");

            entity.Property(e => e.MachineidSn)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("MACHINEID_SN");
            entity.Property(e => e.Actualpmdate)
                .HasPrecision(6)
                .HasColumnName("ACTUALPMDATE");
            entity.Property(e => e.Created)
                .HasPrecision(6)
                .HasColumnName("CREATED");
            entity.Property(e => e.Createdby)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CREATEDBY");
            entity.Property(e => e.Currentpmstatus)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CURRENTPMSTATUS");
            entity.Property(e => e.Dccchecklistlink)
                .HasColumnType("CLOB")
                .HasColumnName("DCCCHECKLISTLINK");
            entity.Property(e => e.Eighthtimepmschedule)
                .HasColumnType("DATE")
                .HasColumnName("EIGHTHTIMEPMSCHEDULE");
            entity.Property(e => e.Eleventhtimepmschedule)
                .HasColumnType("DATE")
                .HasColumnName("ELEVENTHTIMEPMSCHEDULE");
            entity.Property(e => e.Engineeringmanager)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ENGINEERINGMANAGER");
            entity.Property(e => e.Fifthtimepmschedule)
                .HasColumnType("DATE")
                .HasColumnName("FIFTHTIMEPMSCHEDULE");
            entity.Property(e => e.Fourthtimepmschedule)
                .HasColumnType("DATE")
                .HasColumnName("FOURTHTIMEPMSCHEDULE");
            entity.Property(e => e.Headcountsize)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("HEADCOUNTSIZE");
            entity.Property(e => e.Modified)
                .HasPrecision(6)
                .HasColumnName("MODIFIED");
            entity.Property(e => e.Modifiedby)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("MODIFIEDBY");
            entity.Property(e => e.Month)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MONTH");
            entity.Property(e => e.Ninthtimepmschedule)
                .HasColumnType("DATE")
                .HasColumnName("NINTHTIMEPMSCHEDULE");
            entity.Property(e => e.Onedayafter)
                .HasColumnType("DATE")
                .HasColumnName("ONEDAYAFTER");
            entity.Property(e => e.Onedayalert)
                .HasColumnType("DATE")
                .HasColumnName("ONEDAYALERT");
            entity.Property(e => e.Planthead)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PLANTHEAD");
            entity.Property(e => e.Pmadherence)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PMADHERENCE");
            entity.Property(e => e.Pmdurationhrs)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PMDURATIONHRS");
            entity.Property(e => e.Pmscheduleflow)
                .HasColumnType("CLOB")
                .HasColumnName("PMSCHEDULEFLOW");
            entity.Property(e => e.Pmworkflow)
                .HasColumnType("CLOB")
                .HasColumnName("PMWORKFLOW");
            entity.Property(e => e.Requiredcriticalsparepartlist)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("REQUIREDCRITICALSPAREPARTLIST");
            entity.Property(e => e.Secondtimepmschedule)
                .HasColumnType("DATE")
                .HasColumnName("SECONDTIMEPMSCHEDULE");
            entity.Property(e => e.Seventhtimepmschedule)
                .HasColumnType("DATE")
                .HasColumnName("SEVENTHTIMEPMSCHEDULE");
            entity.Property(e => e.Sixthtimepmschedule)
                .HasColumnType("DATE")
                .HasColumnName("SIXTHTIMEPMSCHEDULE");
            entity.Property(e => e.Tenthtimepmschedule)
                .HasColumnType("DATE")
                .HasColumnName("TENTHTIMEPMSCHEDULE");
            entity.Property(e => e.Thirdtimepmschedule)
                .HasColumnType("DATE")
                .HasColumnName("THIRDTIMEPMSCHEDULE");
            entity.Property(e => e.Threedaysafter)
                .HasColumnType("DATE")
                .HasColumnName("THREEDAYSAFTER");
            entity.Property(e => e.Threedaysalert)
                .HasColumnType("DATE")
                .HasColumnName("THREEDAYSALERT");
            entity.Property(e => e.Toollist)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TOOLLIST");
            entity.Property(e => e.Twelfthtimepmschedule)
                .HasColumnType("DATE")
                .HasColumnName("TWELFTHTIMEPMSCHEDULE");
            entity.Property(e => e.Twodaysafter)
                .HasColumnType("DATE")
                .HasColumnName("TWODAYSAFTER");
        });

        modelBuilder.Entity<Ssntemp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SSNTEMP");

            entity.Property(e => e.Assetag)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ASSETAG");
            entity.Property(e => e.Plant)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PLANT");
        });
        modelBuilder.HasSequence("CHECKLIST_SEQ");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
