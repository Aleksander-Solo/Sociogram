// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sociogram.DAL;

#nullable disable

namespace Sociogram.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("QuizStudent", b =>
                {
                    b.Property<int>("QuizzesId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.HasKey("QuizzesId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("QuizStudent");
                });

            modelBuilder.Entity("Sociogram.DAL.Entities.ClassS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("ClassS");
                });

            modelBuilder.Entity("Sociogram.DAL.Entities.Quiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ClassSId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("JoinCode")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassSId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("Sociogram.DAL.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("FirstFriend")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int>("Nr")
                        .HasColumnType("int");

                    b.Property<int>("SecontFriend")
                        .HasColumnType("int");

                    b.Property<int>("ThirdFriend")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Sociogram.DAL.Entities.StudentConst", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClassSId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Nr")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassSId");

                    b.ToTable("StudentConst");
                });

            modelBuilder.Entity("Sociogram.DAL.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("QuizStudent", b =>
                {
                    b.HasOne("Sociogram.DAL.Entities.Quiz", null)
                        .WithMany()
                        .HasForeignKey("QuizzesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sociogram.DAL.Entities.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sociogram.DAL.Entities.ClassS", b =>
                {
                    b.HasOne("Sociogram.DAL.Entities.Teacher", "Teacher")
                        .WithMany("Classes")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Sociogram.DAL.Entities.Quiz", b =>
                {
                    b.HasOne("Sociogram.DAL.Entities.ClassS", "ClassS")
                        .WithMany()
                        .HasForeignKey("ClassSId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sociogram.DAL.Entities.Teacher", "Teacher")
                        .WithMany("Quizzes")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassS");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Sociogram.DAL.Entities.StudentConst", b =>
                {
                    b.HasOne("Sociogram.DAL.Entities.ClassS", "ClassS")
                        .WithMany("StudentsConst")
                        .HasForeignKey("ClassSId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassS");
                });

            modelBuilder.Entity("Sociogram.DAL.Entities.ClassS", b =>
                {
                    b.Navigation("StudentsConst");
                });

            modelBuilder.Entity("Sociogram.DAL.Entities.Teacher", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("Quizzes");
                });
#pragma warning restore 612, 618
        }
    }
}
