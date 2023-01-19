﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using POS.Doamin.Entities;

namespace POS.Infrastructure.Persistences.Context;

public partial class FormContext : DbContext
{
    public FormContext() { }

    public FormContext(DbContextOptions<FormContext> options) : base(options) { }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer(
            "Server=DESKTOP-G3QA925;Database=form;TrustServerCertificate=True;User iD=sa;Password=index"
        );

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
