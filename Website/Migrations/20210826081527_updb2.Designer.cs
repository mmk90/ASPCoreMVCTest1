// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Website.Data;

namespace Website.Migrations
{
    [DbContext(typeof(WebsiteDatabaseContext))]
    [Migration("20210826081527_updb2")]
    partial class updb2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Website.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "this is the first category",
                            Name = "Category 1"
                        },
                        new
                        {
                            ID = 2,
                            Description = "this is the second category",
                            Name = "Category 2"
                        },
                        new
                        {
                            ID = 3,
                            Description = "this is the third category",
                            Name = "Category 3"
                        });
                });

            modelBuilder.Entity("Website.Models.CategorytoProduct", b =>
                {
                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("CategoryID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("CategorytoProducts");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            ProductID = 1
                        },
                        new
                        {
                            CategoryID = 2,
                            ProductID = 1
                        },
                        new
                        {
                            CategoryID = 3,
                            ProductID = 1
                        },
                        new
                        {
                            CategoryID = 4,
                            ProductID = 1
                        },
                        new
                        {
                            CategoryID = 1,
                            ProductID = 2
                        },
                        new
                        {
                            CategoryID = 2,
                            ProductID = 2
                        },
                        new
                        {
                            CategoryID = 3,
                            ProductID = 2
                        },
                        new
                        {
                            CategoryID = 4,
                            ProductID = 2
                        },
                        new
                        {
                            CategoryID = 1,
                            ProductID = 3
                        },
                        new
                        {
                            CategoryID = 2,
                            ProductID = 3
                        },
                        new
                        {
                            CategoryID = 3,
                            ProductID = 3
                        },
                        new
                        {
                            CategoryID = 4,
                            ProductID = 3
                        });
                });

            modelBuilder.Entity("Website.Models.Item", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("Money");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Price = 854.0m,
                            Qty = 5
                        },
                        new
                        {
                            ID = 2,
                            Price = 3302.0m,
                            Qty = 8
                        },
                        new
                        {
                            ID = 3,
                            Price = 2500m,
                            Qty = 3
                        });
                });

            modelBuilder.Entity("Website.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "this is the first Product",
                            ItemID = 1,
                            Name = "Product 1"
                        },
                        new
                        {
                            ID = 2,
                            Description = "this is the second Product",
                            ItemID = 2,
                            Name = "Product 2"
                        },
                        new
                        {
                            ID = 3,
                            Description = "this is the third Product",
                            ItemID = 3,
                            Name = "Product 3"
                        });
                });

            modelBuilder.Entity("Website.Models.CategorytoProduct", b =>
                {
                    b.HasOne("Website.Models.Category", "Category")
                        .WithMany("CategoriytoProducts")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Website.Models.Product", "Product")
                        .WithMany("CategoriytoProducts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Website.Models.Item", b =>
                {
                    b.HasOne("Website.Models.Product", "Product")
                        .WithOne("Item")
                        .HasForeignKey("Website.Models.Item", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
