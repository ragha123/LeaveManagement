﻿// <auto-generated />
using System;
using LeaveManagement.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LeaveManagement.Migrations
{
    [DbContext(typeof(EmployeeLeaveDBContext))]
    partial class EmployeeLeaveDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LeaveManagement.Model.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Companyname")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("LeaveManagement.Model.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<Guid?>("CompanyId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property("Role")
                        .HasConversion<int>();

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId1");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("LeaveManagement.Model.JwtAuthenticationModel", b =>
                {
                    b.Property<string>("SecurityKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ValidAudience")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValidIssuer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SecurityKey");

                    b.ToTable("TokenAuthentication");
                });

            modelBuilder.Entity("LeaveManagement.Model.LeaveAllocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmpId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpId");

                    b.ToTable("LeaveAllocations");
                });

            modelBuilder.Entity("LeaveManagement.Model.LeaveRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApproverId")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RequestingEmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property("Status")
                        .HasConversion<int>();

                    b.HasKey("Id");

                    b.HasIndex("ApproverId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("RequestingEmployeeId");

                    b.ToTable("LeaveRequests");
                });

            modelBuilder.Entity("LeaveManagement.Model.Projects", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmpId")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ProjectId");

                    b.HasIndex("EmpId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("LeaveManagement.Model.Employee", b =>
                {
                    b.HasOne("LeaveManagement.Model.Company", "Company")
                        .WithMany("Employee")
                        .HasForeignKey("CompanyId1");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("LeaveManagement.Model.LeaveAllocation", b =>
                {
                    b.HasOne("LeaveManagement.Model.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmpId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("LeaveManagement.Model.LeaveRequest", b =>
                {
                    b.HasOne("LeaveManagement.Model.Employee", "Approver")
                        .WithMany()
                        .HasForeignKey("ApproverId");

                    b.HasOne("LeaveManagement.Model.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("LeaveManagement.Model.Employee", "RequestingEmployee")
                        .WithMany()
                        .HasForeignKey("RequestingEmployeeId");

                    b.Navigation("Approver");

                    b.Navigation("Employee");

                    b.Navigation("RequestingEmployee");
                });

            modelBuilder.Entity("LeaveManagement.Model.Projects", b =>
                {
                    b.HasOne("LeaveManagement.Model.Employee", "Emp")
                        .WithMany("Projects")
                        .HasForeignKey("EmpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Emp");
                });

            modelBuilder.Entity("LeaveManagement.Model.Company", b =>
                {
                    b.Navigation("Employee");
                });

            modelBuilder.Entity("LeaveManagement.Model.Employee", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
