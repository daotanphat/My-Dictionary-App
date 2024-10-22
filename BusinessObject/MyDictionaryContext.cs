using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BusinessObject
{
	public partial class MyDictionaryContext : DbContext
	{
		public MyDictionaryContext()
		{
		}

		public MyDictionaryContext(DbContextOptions<MyDictionaryContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Dictionary> Dictionaries { get; set; } = null!;
		public virtual DbSet<EditHistory> EditHistories { get; set; } = null!;
		public virtual DbSet<Role> Roles { get; set; } = null!;
		public virtual DbSet<User> Users { get; set; } = null!;
		public virtual DbSet<WordType> WordTypes { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var builder = new ConfigurationBuilder()
							   .SetBasePath(Directory.GetCurrentDirectory())
							   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
			IConfigurationRoot configuration = builder.Build();
			optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Dictionary>(entity =>
			{
				entity.ToTable("Dictionary");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.CreateBy).HasColumnName("createBy");

				entity.Property(e => e.EditDate)
					.HasColumnType("datetime")
					.HasColumnName("editDate")
					.HasDefaultValueSql("(getdate())");

				entity.Property(e => e.IsApproved).HasColumnName("isApproved");

				entity.Property(e => e.Meaning)
					.HasMaxLength(1)
					.HasColumnName("meaning");

				entity.Property(e => e.Vietnamese)
					.HasMaxLength(25)
					.HasColumnName("vietnamese");

				entity.Property(e => e.Word)
					.HasMaxLength(25)
					.HasColumnName("word");

				entity.Property(e => e.WordType).HasColumnName("wordType");

				entity.HasOne(d => d.CreateByNavigation)
					.WithMany(p => p.Dictionaries)
					.HasForeignKey(d => d.CreateBy)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__Dictionar__creat__412EB0B6");

				entity.HasOne(d => d.WordTypeNavigation)
					.WithMany(p => p.Dictionaries)
					.HasForeignKey(d => d.WordType)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__Dictionar__wordT__403A8C7D");
			});

			modelBuilder.Entity<EditHistory>(entity =>
			{
				entity.ToTable("EditHistory");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.EditBy).HasColumnName("editBy");

				entity.Property(e => e.EditDate)
					.HasColumnType("datetime")
					.HasColumnName("editDate")
					.HasDefaultValueSql("(getdate())");

				entity.Property(e => e.NewVietnamese)
					.HasMaxLength(25)
					.HasColumnName("newVietnamese");

				entity.Property(e => e.NewWord)
					.HasMaxLength(25)
					.HasColumnName("newWord");

				entity.Property(e => e.OldVietnamese)
					.HasMaxLength(25)
					.HasColumnName("oldVietnamese");

				entity.Property(e => e.OldWord)
					.HasMaxLength(25)
					.HasColumnName("oldWord");

				entity.Property(e => e.WordId).HasColumnName("wordId");

				entity.HasOne(d => d.EditByNavigation)
					.WithMany(p => p.EditHistories)
					.HasForeignKey(d => d.EditBy)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__EditHisto__editB__5165187F");

				entity.HasOne(d => d.Word)
					.WithMany(p => p.EditHistories)
					.HasForeignKey(d => d.WordId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__EditHisto__wordI__44FF419A");
			});

			modelBuilder.Entity<Role>(entity =>
			{
				entity.ToTable("Role");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.RoleName)
					.HasMaxLength(25)
					.HasColumnName("roleName");
			});

			modelBuilder.Entity<User>(entity =>
			{
				entity.ToTable("User");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.CreateAt)
					.HasColumnType("datetime")
					.HasColumnName("createAt")
					.HasDefaultValueSql("(getdate())");

				entity.Property(e => e.Email)
					.HasMaxLength(50)
					.HasColumnName("email");

				entity.Property(e => e.Password)
					.HasMaxLength(25)
					.HasColumnName("password");

				entity.Property(e => e.Role).HasColumnName("role");

				entity.Property(e => e.Status).HasColumnName("status");

				entity.Property(e => e.Username)
					.HasMaxLength(25)
					.HasColumnName("username");

				entity.HasOne(d => d.RoleNavigation)
					.WithMany(p => p.Users)
					.HasForeignKey(d => d.Role)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__User__role__3A81B327");
			});

			modelBuilder.Entity<WordType>(entity =>
			{
				entity.ToTable("WordType");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.TypeName)
					.HasMaxLength(25)
					.HasColumnName("typeName");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
