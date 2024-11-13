using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using WebTaskManagerApi.Models;

namespace WebTaskManagerApi.Data;

public partial class WebTaskManagerContext : DbContext
{
    public WebTaskManagerContext()
    {
    }

    public WebTaskManagerContext(DbContextOptions<WebTaskManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Models.Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.IdComments).HasName("PRIMARY");

            entity.ToTable("comments");

            entity.HasIndex(e => e.TasksIdTask, "fk_comments_tasks1_idx");

            entity.HasIndex(e => e.UsersIdUser, "fk_comments_users1_idx");

            entity.Property(e => e.IdComments).HasColumnName("id_comments");
            entity.Property(e => e.Datetime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("datetime");
            entity.Property(e => e.TasksIdTask).HasColumnName("tasks_id_task");
            entity.Property(e => e.Text)
                .HasMaxLength(200)
                .HasColumnName("text");
            entity.Property(e => e.UsersIdUser).HasColumnName("users_id_user");

            entity.HasOne(d => d.TasksIdTaskNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.TasksIdTask)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_comments_tasks1");

            entity.HasOne(d => d.UsersIdUserNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UsersIdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_comments_users1");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("PRIMARY");

            entity.ToTable("statuses");

            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Models.Task>(entity =>
        {
            entity.HasKey(e => e.IdTask).HasName("PRIMARY");

            entity.ToTable("tasks");

            entity.Property(e => e.IdTask).HasColumnName("id_task");
            entity.Property(e => e.CreationDate).HasColumnName("creation_date");
            entity.Property(e => e.Deadline).HasColumnName("deadline");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Priority)
                .HasColumnType("enum('0','1','2')")
                .HasColumnName("priority");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)")
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(45)
                .HasColumnName("title");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Login, "login_UNIQUE").IsUnique();

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .HasColumnName("email");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)")
                .HasColumnName("is_active");
            entity.Property(e => e.Login)
                .HasMaxLength(40)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(32)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
