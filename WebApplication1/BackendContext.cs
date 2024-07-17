using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1;

public partial class BackendContext : DbContext
{
    public BackendContext()
    {
    }

    public BackendContext(DbContextOptions<BackendContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AiModel> AiModels { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=backend;Username=postgres;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AiModel>(entity =>
        {
            entity.HasKey(e => e.AiModelId).HasName("AI_model_pkey");

            entity.ToTable("AI_model");

            entity.Property(e => e.AiModelId).HasColumnName("AI_model_id");
            entity.Property(e => e.AiModelAuthor).HasColumnName("AI_model_author");
            entity.Property(e => e.AiModelDescription).HasColumnName("AI_model_description");
            entity.Property(e => e.AiModelName).HasColumnName("AI_model_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserLogin).HasName("User_pkey");

            entity.ToTable("User");

            entity.Property(e => e.UserLogin).HasColumnName("User_login");
            entity.Property(e => e.UserEmail).HasColumnName("User_email");
            entity.Property(e => e.UserPassword).HasColumnName("User_password");
            entity.Property(e => e.UserRole).HasColumnName("User_role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
