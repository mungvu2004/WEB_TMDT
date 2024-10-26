using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Web_Double.Context
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Aokhoac> Aokhoacs { get; set; }
        public virtual DbSet<Hoodee> Hoodees { get; set; }
        public virtual DbSet<Phukien> Phukiens { get; set; }
        public virtual DbSet<PoloShirt> PoloShirts { get; set; }
        public virtual DbSet<Quan> Quans { get; set; }
        public virtual DbSet<Shirt> Shirts { get; set; }
        public virtual DbSet<ShirtType> ShirtTypes { get; set; }
        public virtual DbSet<Somi> Somis { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tshirt> Tshirts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aokhoac>()
                .Property(e => e.discount)
                .HasPrecision(3, 2);

            modelBuilder.Entity<Hoodee>()
                .Property(e => e.discount)
                .HasPrecision(3, 2);

            modelBuilder.Entity<Phukien>()
                .Property(e => e.discount)
                .HasPrecision(3, 2);

            modelBuilder.Entity<PoloShirt>()
                .Property(e => e.discount)
                .HasPrecision(3, 2);

            modelBuilder.Entity<Quan>()
                .Property(e => e.discount)
                .HasPrecision(3, 2);

            modelBuilder.Entity<Shirt>()
                .Property(e => e.discount)
                .HasPrecision(3, 2);

            modelBuilder.Entity<Shirt>()
                .HasMany(e => e.Aokhoacs)
                .WithOptional(e => e.Shirt)
                .HasForeignKey(e => e.shirt_id);

            modelBuilder.Entity<Shirt>()
                .HasMany(e => e.Hoodees)
                .WithOptional(e => e.Shirt)
                .HasForeignKey(e => e.shirt_id);

            modelBuilder.Entity<Shirt>()
                .HasMany(e => e.Phukiens)
                .WithOptional(e => e.Shirt)
                .HasForeignKey(e => e.shirt_id);

            modelBuilder.Entity<Shirt>()
                .HasMany(e => e.PoloShirts)
                .WithOptional(e => e.Shirt)
                .HasForeignKey(e => e.shirt_id);

            modelBuilder.Entity<Shirt>()
                .HasMany(e => e.Quans)
                .WithOptional(e => e.Shirt)
                .HasForeignKey(e => e.shirt_id);

            modelBuilder.Entity<Shirt>()
                .HasMany(e => e.Somis)
                .WithOptional(e => e.Shirt)
                .HasForeignKey(e => e.shirt_id);

            modelBuilder.Entity<Shirt>()
                .HasMany(e => e.Tshirts)
                .WithOptional(e => e.Shirt)
                .HasForeignKey(e => e.shirt_id);

            modelBuilder.Entity<ShirtType>()
                .HasMany(e => e.Shirts)
                .WithOptional(e => e.ShirtType)
                .HasForeignKey(e => e.shirt_type_id);

            modelBuilder.Entity<Somi>()
                .Property(e => e.discount)
                .HasPrecision(3, 2);

            modelBuilder.Entity<Tshirt>()
                .Property(e => e.discount)
                .HasPrecision(3, 2);
        }
    }
}
