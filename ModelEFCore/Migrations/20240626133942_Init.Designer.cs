﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModelEFCore;

#nullable disable

namespace ModelEFCore.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240626133942_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("ModelEFCore.Account", b =>
                {
                    b.Property<string>("Uuid")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("Create_Time")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("Delete_Time")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Id")
                        .HasColumnType("longtext");

                    b.Property<bool>("Is_Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("Last_LoginTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("Remark")
                        .HasColumnType("longtext");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("User_Name")
                        .HasColumnType("longtext");

                    b.HasKey("Uuid");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("ModelEFCore.Article", b =>
                {
                    b.Property<string>("Uuid")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Account_Id")
                        .HasColumnType("longtext");

                    b.Property<string>("Article_Content")
                        .HasColumnType("longtext");

                    b.Property<string>("Article_Good")
                        .HasColumnType("longtext");

                    b.Property<string>("Article_Image_Src")
                        .HasColumnType("longtext");

                    b.Property<string>("Article_Title")
                        .HasColumnType("longtext");

                    b.Property<string>("Article_Type")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Create_Time")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("Delete_Time")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Is_Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("Last_UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Remark")
                        .HasColumnType("longtext");

                    b.HasKey("Uuid");

                    b.ToTable("Article", (string)null);
                });

            modelBuilder.Entity("ModelEFCore.ArticleComment", b =>
                {
                    b.Property<string>("Uuid")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Account_Id")
                        .HasColumnType("longtext");

                    b.Property<string>("Article_Id")
                        .HasColumnType("longtext");

                    b.Property<string>("Comment_Text")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Create_Time")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("Delete_Time")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Is_Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Remark")
                        .HasColumnType("longtext");

                    b.Property<int?>("评论_Good")
                        .HasColumnType("int");

                    b.HasKey("Uuid");

                    b.ToTable("ArticleComment", (string)null);
                });

            modelBuilder.Entity("ModelEFCore.UserInfo", b =>
                {
                    b.Property<string>("Uuid")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Account_Id")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Create_Time")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("Delete_Time")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Is_Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Remark")
                        .HasColumnType("longtext");

                    b.Property<int?>("User_Age")
                        .HasColumnType("int");

                    b.Property<string>("User_Autograph")
                        .HasColumnType("longtext");

                    b.Property<string>("User_Day")
                        .HasColumnType("longtext");

                    b.Property<int?>("User_Email")
                        .HasColumnType("int");

                    b.Property<int?>("User_Experience")
                        .HasColumnType("int");

                    b.Property<string>("User_Image_Src")
                        .HasColumnType("longtext");

                    b.Property<string>("User_Phone")
                        .HasColumnType("longtext");

                    b.HasKey("Uuid");

                    b.ToTable("UserInfo", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
