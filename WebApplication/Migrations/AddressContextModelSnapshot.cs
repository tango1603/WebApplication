using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApplication.Models;

namespace WebApplication.Migrations
{
    [DbContext(typeof(AddressContext))]
    partial class AddressContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BuildingNumber");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<DateTime>("DateTime");

                    b.Property<int>("PostID");

                    b.Property<string>("Stereet");

                    b.HasKey("Id");

                    b.ToTable("Addreses");
                });
        }
    }
}
