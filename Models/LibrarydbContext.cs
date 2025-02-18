using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace lab4.Models;

public partial class LibrarydbContext : DbContext
{
    public LibrarydbContext()
    {
    }

    public LibrarydbContext(DbContextOptions<LibrarydbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Borrower> Borrowers { get; set; }

    public virtual DbSet<Loan> Loans { get; set; }

    public virtual DbSet<Pupularbook> Pupularbooks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=librarydb;Username=postgres;Password=postgrespassword");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("authors_pkey");

            entity.ToTable("authors");

            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasColumnName("country");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("books_pkey");

            entity.ToTable("books");

            entity.HasIndex(e => e.Isbn, "books_isbn_key").IsUnique();

            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.Isbn)
                .HasMaxLength(20)
                .HasColumnName("isbn");
            entity.Property(e => e.PublishedYear).HasColumnName("published_year");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("books_author_id_fkey");
        });

        modelBuilder.Entity<Borrower>(entity =>
        {
            entity.HasKey(e => e.BorrowerId).HasName("borrowers_pkey");

            entity.ToTable("borrowers");

            entity.HasIndex(e => e.Email, "borrowers_email_key").IsUnique();

            entity.HasIndex(e => e.Phone, "borrowers_phone_key").IsUnique();

            entity.Property(e => e.BorrowerId).HasColumnName("borrower_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Loan>(entity =>
        {
            entity.HasKey(e => e.LoanId).HasName("loans_pkey");

            entity.ToTable("loans");

            entity.Property(e => e.LoanId).HasColumnName("loan_id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.BorrowerId).HasColumnName("borrower_id");
            entity.Property(e => e.LoanDate)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("loan_date");
            entity.Property(e => e.ReturnDate).HasColumnName("return_date");
            entity.Property(e => e.Returned)
                .HasDefaultValue(false)
                .HasColumnName("returned");

            entity.HasOne(d => d.Book).WithMany(p => p.Loans)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("loans_book_id_fkey");

            entity.HasOne(d => d.Borrower).WithMany(p => p.Loans)
                .HasForeignKey(d => d.BorrowerId)
                .HasConstraintName("loans_borrower_id_fkey");
        });

        modelBuilder.Entity<Pupularbook>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("pupularbooks");

            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.Isbn)
                .HasMaxLength(20)
                .HasColumnName("isbn");
            entity.Property(e => e.PublishedYear).HasColumnName("published_year");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.TotalLoans).HasColumnName("total_loans");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
