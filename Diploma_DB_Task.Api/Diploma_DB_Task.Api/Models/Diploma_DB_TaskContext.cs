using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Diploma_DB_Task.Api.Models
{
    public partial class Diploma_DB_TaskContext : DbContext
    {
        public Diploma_DB_TaskContext()
        {
        }

        public Diploma_DB_TaskContext(DbContextOptions<Diploma_DB_TaskContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accountpayment3778> Accountpayment3778 { get; set; }
        public virtual DbSet<Authorisedperson3778> Authorisedperson3778 { get; set; }
        public virtual DbSet<Clientaccount3778> Clientaccount3778 { get; set; }
        public virtual DbSet<Generalledger3778> Generalledger3778 { get; set; }
        public virtual DbSet<Inventory3778> Inventory3778 { get; set; }
        public virtual DbSet<Location3778> Location3778 { get; set; }
        public virtual DbSet<Order3778> Order3778 { get; set; }
        public virtual DbSet<Orderline3778> Orderline3778 { get; set; }
        public virtual DbSet<Product3778> Product3778 { get; set; }
        public virtual DbSet<Purchaseorder3778> Purchaseorder3778 { get; set; }
        public virtual DbSet<ClientAuthPerson> ClienAuthPerson { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. 
                //See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Diploma_DB_Task;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Orderid).HasColumnName("ORDERID");

                entity.Property(e => e.Shippingaddress)
                    .IsRequired()
                    .HasColumnName("SHIPPINGADDRESS")
                    .HasMaxLength(200);

                entity.Property(e => e.Datetimecreated)
                    .HasColumnName("DATETIMECREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.Datetimedispatched)
                    .HasColumnName("DATETIMEDISPATCHED")
                    .HasColumnType("datetime");

                entity.Property(e => e.Total)
                    .HasColumnName("TOTAL")
                    .HasColumnType("money");

                entity.Property(e => e.Userid).HasColumnName("USERID");

                entity.Property(e => e.Productid).HasColumnName("PRODUCTID");

                entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

                entity.Property(e => e.Discount)
                    .HasColumnName("DISCOUNT")
                    .HasColumnType("decimal(3, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Subtotal)
                    .HasColumnName("SUBTOTAL")
                    .HasColumnType("money");

            });

            modelBuilder.Entity<ClientAuthPerson>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Accountid).HasColumnName("ACCOUNTID");

                entity.Property(e => e.Acctname)
                    .IsRequired()
                    .HasColumnName("ACCTNAME")
                    .HasMaxLength(100);

                entity.Property(e => e.Balance)
                    .HasColumnName("BALANCE")
                    .HasColumnType("money");

                entity.Property(e => e.Creditlimit)
                    .HasColumnName("CREDITLIMIT")
                    .HasColumnType("money");

                entity.Property(e => e.Userid).HasColumnName("USERID");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("FIRSTNAME")
                    .HasMaxLength(100);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("SURNAME")
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100);

            });

            modelBuilder.Entity<Accountpayment3778>(entity =>
            {
                entity.HasKey(e => new { e.Accountid, e.Datetimereceived })
                    .HasName("PK_ACCOUNTPAYMENT");

                entity.ToTable("ACCOUNTPAYMENT3778");

                entity.Property(e => e.Accountid).HasColumnName("ACCOUNTID");

                entity.Property(e => e.Datetimereceived)
                    .HasColumnName("DATETIMERECEIVED")
                    .HasColumnType("datetime");

                entity.Property(e => e.Amount)
                    .HasColumnName("AMOUNT")
                    .HasColumnType("money");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Accountpayment3778)
                    .HasForeignKey(d => d.Accountid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ACCOUNTPAYMENT_ACCOUNT");
            });

            modelBuilder.Entity<Authorisedperson3778>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK_AUTHORISEDPERSON");

                entity.ToTable("AUTHORISEDPERSON3778");

                entity.Property(e => e.Userid).HasColumnName("USERID");

                entity.Property(e => e.Accountid).HasColumnName("ACCOUNTID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("FIRSTNAME")
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(100);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("SURNAME")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Authorisedperson3778)
                    .HasForeignKey(d => d.Accountid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AUTHORISEDPERSON_CLIENTACCOUNT");
            });

            modelBuilder.Entity<Clientaccount3778>(entity =>
            {
                entity.HasKey(e => e.Accountid)
                    .HasName("PK_CLIENTACCOUNT");

                entity.ToTable("CLIENTACCOUNT3778");

                entity.HasIndex(e => e.Acctname)
                    .HasName("UQ_CLENTACCOUNT_NAME")
                    .IsUnique();

                entity.Property(e => e.Accountid).HasColumnName("ACCOUNTID");

                entity.Property(e => e.Acctname)
                    .IsRequired()
                    .HasColumnName("ACCTNAME")
                    .HasMaxLength(100);

                entity.Property(e => e.Balance)
                    .HasColumnName("BALANCE")
                    .HasColumnType("money");

                entity.Property(e => e.Creditlimit)
                    .HasColumnName("CREDITLIMIT")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<Generalledger3778>(entity =>
            {
                entity.HasKey(e => e.Itemid)
                    .HasName("PK_GENERALLEDGER");

                entity.ToTable("GENERALLEDGER3778");

                entity.HasIndex(e => e.Description)
                    .HasName("UQ_GENERALEDGER_DESCRIPTION")
                    .IsUnique();

                entity.Property(e => e.Itemid)
                    .HasColumnName("ITEMID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount)
                    .HasColumnName("AMOUNT")
                    .HasColumnType("money");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Inventory3778>(entity =>
            {
                entity.HasKey(e => new { e.Productid, e.Locationid })
                    .HasName("PK_INVENTORY");

                entity.ToTable("INVENTORY3778");

                entity.Property(e => e.Productid).HasColumnName("PRODUCTID");

                entity.Property(e => e.Locationid)
                    .HasColumnName("LOCATIONID")
                    .HasMaxLength(8);

                entity.Property(e => e.Numinstock).HasColumnName("NUMINSTOCK");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Inventory3778)
                    .HasForeignKey(d => d.Locationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_INVENTORY_LOCATION");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventory3778)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_INVENTORY_PRODUCT");
            });

            modelBuilder.Entity<Location3778>(entity =>
            {
                entity.HasKey(e => e.Locationid)
                    .HasName("PK_LOCATION");

                entity.ToTable("LOCATION3778");

                entity.Property(e => e.Locationid)
                    .HasColumnName("LOCATIONID")
                    .HasMaxLength(8);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(200);

                entity.Property(e => e.Locname)
                    .IsRequired()
                    .HasColumnName("LOCNAME")
                    .HasMaxLength(50);

                entity.Property(e => e.Manager)
                    .HasColumnName("MANAGER")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Order3778>(entity =>
            {
                entity.HasKey(e => e.Orderid)
                    .HasName("PK_ORDER");

                entity.ToTable("ORDER3778");

                entity.Property(e => e.Orderid).HasColumnName("ORDERID");

                entity.Property(e => e.Datetimecreated)
                    .HasColumnName("DATETIMECREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.Datetimedispatched)
                    .HasColumnName("DATETIMEDISPATCHED")
                    .HasColumnType("datetime");

                entity.Property(e => e.Shippingaddress)
                    .IsRequired()
                    .HasColumnName("SHIPPINGADDRESS")
                    .HasMaxLength(200);

                entity.Property(e => e.Total)
                    .HasColumnName("TOTAL")
                    .HasColumnType("money");

                entity.Property(e => e.Userid).HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Order3778)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDER_AUTHORISEDPERSON");
            });

            modelBuilder.Entity<Orderline3778>(entity =>
            {
                entity.HasKey(e => new { e.Orderid, e.Productid })
                    .HasName("PK_ORDERLINE");

                entity.ToTable("ORDERLINE3778");

                entity.Property(e => e.Orderid).HasColumnName("ORDERID");

                entity.Property(e => e.Productid).HasColumnName("PRODUCTID");

                entity.Property(e => e.Discount)
                    .HasColumnName("DISCOUNT")
                    .HasColumnType("decimal(3, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

                entity.Property(e => e.Subtotal)
                    .HasColumnName("SUBTOTAL")
                    .HasColumnType("money");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderline3778)
                    .HasForeignKey(d => d.Orderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDERLINE_ORDER");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orderline3778)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDERLINE_PRODUCT");
            });

            modelBuilder.Entity<Product3778>(entity =>
            {
                entity.HasKey(e => e.Productid)
                    .HasName("PK_PRODUCT");

                entity.ToTable("PRODUCT3778");

                entity.Property(e => e.Productid).HasColumnName("PRODUCTID");

                entity.Property(e => e.Buyprice)
                    .HasColumnName("BUYPRICE")
                    .HasColumnType("money");

                entity.Property(e => e.Prodname)
                    .IsRequired()
                    .HasColumnName("PRODNAME")
                    .HasMaxLength(100);

                entity.Property(e => e.Sellprice)
                    .HasColumnName("SELLPRICE")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<Purchaseorder3778>(entity =>
            {
                entity.HasKey(e => new { e.Productid, e.Locationid, e.Datetimecreated })
                    .HasName("PK_PURCHASEORDER");

                entity.ToTable("PURCHASEORDER3778");

                entity.Property(e => e.Productid).HasColumnName("PRODUCTID");

                entity.Property(e => e.Locationid)
                    .HasColumnName("LOCATIONID")
                    .HasMaxLength(8);

                entity.Property(e => e.Datetimecreated)
                    .HasColumnName("DATETIMECREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

                entity.Property(e => e.Total)
                    .HasColumnName("TOTAL")
                    .HasColumnType("money");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Purchaseorder3778)
                    .HasForeignKey(d => d.Locationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PURCHASEORDER_LOCATION");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Purchaseorder3778)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PURCHASEORDER_PRODUCT");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
