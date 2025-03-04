﻿// <auto-generated />
using BookManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookManagement.Infrastructure.Migrations
{
    [DbContext(typeof(BookManagementDbContext))]
    [Migration("20250219122615_auth")]
    partial class auth
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookManagement.Core.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("PublicationYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ViewsCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorName = "F. Scott Fitzgerald",
                            IsDeleted = false,
                            PublicationYear = 1925,
                            Title = "The Great Gatsby",
                            ViewsCount = 150
                        },
                        new
                        {
                            Id = 2,
                            AuthorName = "George Orwell",
                            IsDeleted = false,
                            PublicationYear = 1949,
                            Title = "1984",
                            ViewsCount = 200
                        },
                        new
                        {
                            Id = 3,
                            AuthorName = "Jane Austen",
                            IsDeleted = false,
                            PublicationYear = 1813,
                            Title = "Pride and Prejudice",
                            ViewsCount = 180
                        },
                        new
                        {
                            Id = 4,
                            AuthorName = "Harper Lee",
                            IsDeleted = false,
                            PublicationYear = 1960,
                            Title = "To Kill a Mockingbird",
                            ViewsCount = 170
                        },
                        new
                        {
                            Id = 5,
                            AuthorName = "J.D. Salinger",
                            IsDeleted = false,
                            PublicationYear = 1951,
                            Title = "The Catcher in the Rye",
                            ViewsCount = 130
                        },
                        new
                        {
                            Id = 6,
                            AuthorName = "Gabriel García Márquez",
                            IsDeleted = false,
                            PublicationYear = 1967,
                            Title = "One Hundred Years of Solitude",
                            ViewsCount = 140
                        },
                        new
                        {
                            Id = 7,
                            AuthorName = "Aldous Huxley",
                            IsDeleted = false,
                            PublicationYear = 1932,
                            Title = "Brave New World",
                            ViewsCount = 160
                        },
                        new
                        {
                            Id = 8,
                            AuthorName = "J.R.R. Tolkien",
                            IsDeleted = false,
                            PublicationYear = 1954,
                            Title = "The Lord of the Rings",
                            ViewsCount = 250
                        },
                        new
                        {
                            Id = 9,
                            AuthorName = "Charlotte Brontë",
                            IsDeleted = false,
                            PublicationYear = 1847,
                            Title = "Jane Eyre",
                            ViewsCount = 120
                        },
                        new
                        {
                            Id = 10,
                            AuthorName = "Fyodor Dostoevsky",
                            IsDeleted = false,
                            PublicationYear = 1866,
                            Title = "Crime and Punishment",
                            ViewsCount = 110
                        },
                        new
                        {
                            Id = 11,
                            AuthorName = "J.R.R. Tolkien",
                            IsDeleted = false,
                            PublicationYear = 1937,
                            Title = "The Hobbit",
                            ViewsCount = 230
                        },
                        new
                        {
                            Id = 12,
                            AuthorName = "Miguel de Cervantes",
                            IsDeleted = false,
                            PublicationYear = 1605,
                            Title = "Don Quixote",
                            ViewsCount = 90
                        },
                        new
                        {
                            Id = 13,
                            AuthorName = "Dante Alighieri",
                            IsDeleted = false,
                            PublicationYear = 1320,
                            Title = "The Divine Comedy",
                            ViewsCount = 80
                        },
                        new
                        {
                            Id = 14,
                            AuthorName = "Fyodor Dostoevsky",
                            IsDeleted = false,
                            PublicationYear = 1880,
                            Title = "The Brothers Karamazov",
                            ViewsCount = 100
                        },
                        new
                        {
                            Id = 15,
                            AuthorName = "Emily Brontë",
                            IsDeleted = false,
                            PublicationYear = 1847,
                            Title = "Wuthering Heights",
                            ViewsCount = 140
                        },
                        new
                        {
                            Id = 16,
                            AuthorName = "Homer",
                            IsDeleted = false,
                            PublicationYear = -800,
                            Title = "The Odyssey",
                            ViewsCount = 70
                        },
                        new
                        {
                            Id = 17,
                            AuthorName = "Oscar Wilde",
                            IsDeleted = false,
                            PublicationYear = 1890,
                            Title = "The Picture of Dorian Gray",
                            ViewsCount = 160
                        },
                        new
                        {
                            Id = 18,
                            AuthorName = "Leo Tolstoy",
                            IsDeleted = false,
                            PublicationYear = 1869,
                            Title = "War and Peace",
                            ViewsCount = 120
                        },
                        new
                        {
                            Id = 19,
                            AuthorName = "Alexandre Dumas",
                            IsDeleted = false,
                            PublicationYear = 1844,
                            Title = "The Count of Monte Cristo",
                            ViewsCount = 150
                        },
                        new
                        {
                            Id = 20,
                            AuthorName = "Leo Tolstoy",
                            IsDeleted = false,
                            PublicationYear = 1877,
                            Title = "Anna Karenina",
                            ViewsCount = 140
                        },
                        new
                        {
                            Id = 21,
                            AuthorName = "Victor Hugo",
                            IsDeleted = false,
                            PublicationYear = 1862,
                            Title = "Les Misérables",
                            ViewsCount = 130
                        },
                        new
                        {
                            Id = 22,
                            AuthorName = "Homer",
                            IsDeleted = false,
                            PublicationYear = -760,
                            Title = "The Iliad",
                            ViewsCount = 60
                        },
                        new
                        {
                            Id = 23,
                            AuthorName = "Mary Shelley",
                            IsDeleted = false,
                            PublicationYear = 1818,
                            Title = "Frankenstein",
                            ViewsCount = 170
                        },
                        new
                        {
                            Id = 24,
                            AuthorName = "Geoffrey Chaucer",
                            IsDeleted = false,
                            PublicationYear = 1392,
                            Title = "The Canterbury Tales",
                            ViewsCount = 50
                        },
                        new
                        {
                            Id = 25,
                            AuthorName = "Herman Melville",
                            IsDeleted = false,
                            PublicationYear = 1851,
                            Title = "Moby-Dick",
                            ViewsCount = 140
                        },
                        new
                        {
                            Id = 26,
                            AuthorName = "Charles Dickens",
                            IsDeleted = false,
                            PublicationYear = 1837,
                            Title = "Oliver Twist",
                            ViewsCount = 120
                        },
                        new
                        {
                            Id = 27,
                            AuthorName = "Bram Stoker",
                            IsDeleted = false,
                            PublicationYear = 1897,
                            Title = "Dracula",
                            ViewsCount = 180
                        },
                        new
                        {
                            Id = 28,
                            AuthorName = "Alexandre Dumas",
                            IsDeleted = false,
                            PublicationYear = 1844,
                            Title = "The Three Musketeers",
                            ViewsCount = 130
                        },
                        new
                        {
                            Id = 29,
                            AuthorName = "Charles Dickens",
                            IsDeleted = false,
                            PublicationYear = 1861,
                            Title = "Great Expectations",
                            ViewsCount = 140
                        },
                        new
                        {
                            Id = 30,
                            AuthorName = "Arthur Conan Doyle",
                            IsDeleted = false,
                            PublicationYear = 1892,
                            Title = "The Adventures of Sherlock Holmes",
                            ViewsCount = 190
                        });
                });

            modelBuilder.Entity("BookManagement.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
