using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PcShop.Models;

public partial class PcshopContext : DbContext
{
    public PcshopContext()
    {
    }

    public PcshopContext(DbContextOptions<PcshopContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Server=localhost;Database=pcshop;Username=postgres;Password=1234;Persist Security Info=True");
// # warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
