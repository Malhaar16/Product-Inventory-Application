using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace n01597720_FinalProject.Models.DataLayer;

public partial class MMABooksContext : DbContext
{
    public MMABooksContext()
    {
    }

    public MMABooksContext(DbContextOptions<MMABooksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ProductInventory> ProductInventories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["FinalProject"].ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductInventory>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__ProductI__B40CC6EDE50DD441");

            entity.Property(e => e.ProductId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
