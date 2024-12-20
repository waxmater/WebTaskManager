﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebTaskManagerApi.Data;

#nullable disable

namespace WebTaskManagerApi.Migrations
{
    [DbContext(typeof(WebTaskManagerContext))]
    [Migration("20241112084952_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");
            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("WebTaskManagerApi.Models.Comment", b =>
                {
                    b.Property<int>("IdComments")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_comments");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdComments"));

                    b.Property<DateTime?>("Datetime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("TasksIdTask")
                        .HasColumnType("int")
                        .HasColumnName("tasks_id_task");

                    b.Property<string>("Text")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("text");

                    b.Property<int>("UsersIdUser")
                        .HasColumnType("int")
                        .HasColumnName("users_id_user");

                    b.HasKey("IdComments")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "TasksIdTask" }, "fk_comments_tasks1_idx");

                    b.HasIndex(new[] { "UsersIdUser" }, "fk_comments_users1_idx");

                    b.ToTable("comments", (string)null);
                });

            modelBuilder.Entity("WebTaskManagerApi.Models.Status", b =>
                {
                    b.Property<int>("IdStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_status");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdStatus"));

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("name");

                    b.HasKey("IdStatus")
                        .HasName("PRIMARY");

                    b.ToTable("statuses", (string)null);
                });

            modelBuilder.Entity("WebTaskManagerApi.Models.Task", b =>
                {
                    b.Property<int>("IdTask")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_task");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdTask"));

                    b.Property<DateOnly?>("CreationDate")
                        .HasColumnType("date")
                        .HasColumnName("creation_date");

                    b.Property<DateOnly?>("Deadline")
                        .HasColumnType("date")
                        .HasColumnName("deadline");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Priority")
                        .IsRequired()
                        .HasColumnType("enum('0','1','2')")
                        .HasColumnName("priority");

                    b.Property<ulong>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit(1)")
                        .HasColumnName("status")
                        .HasDefaultValueSql("b'0'");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("title");

                    b.HasKey("IdTask")
                        .HasName("PRIMARY");

                    b.ToTable("tasks", (string)null);
                });

            modelBuilder.Entity("WebTaskManagerApi.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_user");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdUser"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("email");

                    b.Property<ulong>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit(1)")
                        .HasColumnName("is_active")
                        .HasDefaultValueSql("b'0'");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("login");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varbinary(32)")
                        .HasColumnName("password");

                    b.HasKey("IdUser")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Login" }, "login_UNIQUE")
                        .IsUnique();

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("WebTaskManagerApi.Models.Comment", b =>
                {
                    b.HasOne("WebTaskManagerApi.Models.Task", "TasksIdTaskNavigation")
                        .WithMany("Comments")
                        .HasForeignKey("TasksIdTask")
                        .IsRequired()
                        .HasConstraintName("fk_comments_tasks1");

                    b.HasOne("WebTaskManagerApi.Models.User", "UsersIdUserNavigation")
                        .WithMany("Comments")
                        .HasForeignKey("UsersIdUser")
                        .IsRequired()
                        .HasConstraintName("fk_comments_users1");

                    b.Navigation("TasksIdTaskNavigation");

                    b.Navigation("UsersIdUserNavigation");
                });

            modelBuilder.Entity("WebTaskManagerApi.Models.Task", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("WebTaskManagerApi.Models.User", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
