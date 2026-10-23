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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
