using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CHS_Auction_Site.Models
{
    public partial class EventBasedAuctionSoftwareContext : DbContext
    {
        public EventBasedAuctionSoftwareContext()
        {
        }

        public EventBasedAuctionSoftwareContext(DbContextOptions<EventBasedAuctionSoftwareContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Guests> Guests { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Organizations> Organizations { get; set; }
        public virtual DbSet<Packages> Packages { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:chsebas.database.windows.net,1433;Initial Catalog=EventBasedAuctionSoftware;Persist Security Info=False;User ID=arsunis;Password=SeniorProject18;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admins>(entity =>
            {
                entity.HasKey(e => e.AdminUsername);

                entity.Property(e => e.AdminUsername)
                    .HasColumnName("Admin_Username")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AdminEmail)
                    .IsRequired()
                    .HasColumnName("Admin_Email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AdminPassword)
                    .IsRequired()
                    .HasColumnName("Admin_Password")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryId).HasColumnName("Category_ID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("Category_Name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.Property(e => e.EventId).HasColumnName("Event_ID");

                entity.Property(e => e.EventEnd)
                    .HasColumnName("Event_End")
                    .HasColumnType("datetime");

                entity.Property(e => e.EventLocation)
                    .IsRequired()
                    .HasColumnName("Event_Location")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EventStart)
                    .HasColumnName("Event_Start")
                    .HasColumnType("datetime");

                entity.Property(e => e.EventTicketNum).HasColumnName("Event_TicketNum");
            });

            modelBuilder.Entity<Guests>(entity =>
            {
                entity.HasKey(e => e.GuestId);

                entity.Property(e => e.GuestId).HasColumnName("Guest_ID");

                entity.Property(e => e.GuestAddress)
                    .IsRequired()
                    .HasColumnName("Guest_Address")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GuestCity)
                    .IsRequired()
                    .HasColumnName("Guest_City")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GuestEmail)
                    .IsRequired()
                    .HasColumnName("Guest_Email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GuestFirstName)
                    .IsRequired()
                    .HasColumnName("Guest_FirstName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GuestLastName)
                    .IsRequired()
                    .HasColumnName("Guest_LastName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GuestPhone)
                    .IsRequired()
                    .HasColumnName("Guest_Phone")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GuestState)
                    .IsRequired()
                    .HasColumnName("Guest_State")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GuestZip).HasColumnName("Guest_ZIP");

                entity.Property(e => e.OrganizationId).HasColumnName("Organization_ID");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Guests)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK__Guests__Organiza__75A278F5");
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.Property(e => e.ItemId).HasColumnName("Item_ID");

                entity.Property(e => e.GuestId).HasColumnName("Guest_ID");

                entity.Property(e => e.CategoryId).HasColumnName("Category_ID");

                entity.Property(e => e.ItemDescription)
                    .IsRequired()
                    .HasColumnName("Item_Description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ItemImage)
                    .IsRequired()
                    .HasColumnName("Item_Image")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnName("Item_Name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ItemValue).HasColumnName("Item_Value");

                entity.Property(e => e.PackageId).HasColumnName("Package_ID");

                entity.HasOne(d => d.Guest)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.GuestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Items__Guest_ID__73BA3083");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("FK__Items__Package_I__72C60C4A");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Items__Category___160F4887");
            });

            modelBuilder.Entity<Organizations>(entity =>
            {
                entity.HasKey(e => e.OrganizationId);

                entity.Property(e => e.OrganizationId).HasColumnName("Organization_ID");

                entity.Property(e => e.OrganizationName)
                    .IsRequired()
                    .HasColumnName("Organization_Name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Packages>(entity =>
            {
                entity.HasKey(e => e.PackageId);

                entity.Property(e => e.PackageId).HasColumnName("Package_ID");

                entity.Property(e => e.EventId).HasColumnName("Event_ID");

                entity.Property(e => e.PackageBidIncrement).HasColumnName("Package_BidIncrement");

                entity.Property(e => e.PackageDescription)
                    .IsRequired()
                    .HasColumnName("Package_Description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PackageFinalPrice).HasColumnName("Package_FinalPrice");

                entity.Property(e => e.PackageStartBid).HasColumnName("Package_StartBid");

                entity.Property(e => e.TransactionId).HasColumnName("Transaction_ID");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Packages)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Packages__Event___70DDC3D8");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.Packages)
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("FK__Packages__Transa__71D1E811");
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.Property(e => e.TransactionId).HasColumnName("Transaction_ID");

                entity.Property(e => e.GuestId).HasColumnName("Guest_ID");

                entity.Property(e => e.TransactionTotalPrice).HasColumnName("Transaction_TotalPrice");

                entity.HasOne(d => d.Guest)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.GuestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__Guest__74AE54BC");
            });
        }
    }
}
