using ApplicationCore.EF;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public partial class laptopContext : DbContext
    {
        public laptopContext()
        {
        }

        public laptopContext(DbContextOptions<laptopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Cartdetail> Cartdetail { get; set; }
        public virtual DbSet<Complain> Complain { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Intification> Intification { get; set; }
        public virtual DbSet<Orderproduct> Orderproduct { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Promotion> Promotion { get; set; }
        public virtual DbSet<Reviewproduct> Reviewproduct { get; set; }
        public virtual DbSet<Roleaccount> Roleaccount { get; set; }
        public virtual DbSet<Roledetail> Roledetail { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<Voucher> Voucher { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer("Server=ADMIN\\SQLTHAO;Database=laptop;Trusted_Connection=True;");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Idaccount)
                    .HasName("PK__account__513E0FD6AB8A88F0");

                entity.ToTable("account");

                entity.Property(e => e.Idaccount).HasColumnName("IDaccount");

                entity.Property(e => e.Accountname)
                    .HasColumnName("accountname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Pass)
                    .HasColumnName("pass")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Phone).HasColumnName("phone");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.Idcart)
                    .HasName("PK__cart__4581138D411F17B6");

                entity.ToTable("cart");

                entity.Property(e => e.Idcart).HasColumnName("IDcart");

                entity.Property(e => e.Createday)
                    .HasColumnName("createday")
                    .HasColumnType("date");

                entity.Property(e => e.Idaccount).HasColumnName("IDaccount");

                entity.Property(e => e.Totalprice)
                    .HasColumnName("totalprice")
                    .HasColumnType("money");

                entity.HasOne(d => d.IdaccountNavigation)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.Idaccount)
                    .HasConstraintName("FK__cart__IDaccount__2E1BDC42");
            });

            modelBuilder.Entity<Cartdetail>(entity =>
            {
                entity.HasKey(e => e.Idcartdetail)
                    .HasName("PK__cartdeta__6431700537954099");

                entity.ToTable("cartdetail");

                entity.Property(e => e.Idcartdetail).HasColumnName("IDcartdetail");

                entity.Property(e => e.Idcart).HasColumnName("IDcart");

                entity.Property(e => e.Idproduct).HasColumnName("IDproduct");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.IdcartNavigation)
                    .WithMany(p => p.Cartdetail)
                    .HasForeignKey(d => d.Idcart)
                    .HasConstraintName("FK__cartdetai__IDcar__2F10007B");

                entity.HasOne(d => d.IdproductNavigation)
                    .WithMany(p => p.Cartdetail)
                    .HasForeignKey(d => d.Idproduct)
                    .HasConstraintName("FK__cartdetai__IDpro__300424B4");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Idcategory)
                    .HasName("PK__category__D2F28D79B2A8E0BD");

                entity.ToTable("category");

                entity.Property(e => e.Idcategory).HasColumnName("IDcategory");

                entity.Property(e => e.Namecategory)
                    .HasColumnName("namecategory")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Complain>(entity =>
            {
                entity.HasKey(e => e.Idcomplain)
                    .HasName("PK__complain__9289DDF568DECFEB");

                entity.ToTable("complain");

                entity.Property(e => e.Idcomplain).HasColumnName("IDcomplain");

                entity.Property(e => e.Createday)
                    .HasColumnName("createday")
                    .HasColumnType("date");

                entity.Property(e => e.Idaccount).HasColumnName("IDaccount");

                entity.Property(e => e.Idcartdetail).HasColumnName("IDcartdetail");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdaccountNavigation)
                    .WithMany(p => p.Complain)
                    .HasForeignKey(d => d.Idaccount)
                    .HasConstraintName("FK__complain__IDacco__30F848ED");

                entity.HasOne(d => d.IdcartdetailNavigation)
                    .WithMany(p => p.Complain)
                    .HasForeignKey(d => d.Idcartdetail)
                    .HasConstraintName("FK__complain__IDcart__31EC6D26");
            });

            modelBuilder.Entity<Intification>(entity =>
            {
                entity.HasKey(e => e.Idintification)
                    .HasName("PK__intifica__C3DE428B9020A91A");

                entity.ToTable("intification");

                entity.Property(e => e.Idintification).HasColumnName("IDintification");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Idaccount).HasColumnName("IDaccount");

                entity.HasOne(d => d.IdaccountNavigation)
                    .WithMany(p => p.Intification)
                    .HasForeignKey(d => d.Idaccount)
                    .HasConstraintName("FK__intificat__IDacc__2B3F6F97");
            });

            modelBuilder.Entity<Orderproduct>(entity =>
            {
                entity.HasKey(e => e.Idorder)
                    .HasName("PK__orderpro__2F3207F7C8A0EBCC");

                entity.ToTable("orderproduct");

                entity.Property(e => e.Idorder).HasColumnName("IDorder");

                entity.Property(e => e.Createday)
                    .HasColumnName("createday")
                    .HasColumnType("date");

                entity.Property(e => e.Idaccount).HasColumnName("IDaccount");

                entity.Property(e => e.Idstore).HasColumnName("IDstore");

                entity.Property(e => e.Idvoucher).HasColumnName("IDvoucher");

                entity.Property(e => e.Shipaddress)
                    .HasColumnName("shipaddress")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Statusorder)
                    .HasColumnName("statusorder")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Totalprice)
                    .HasColumnName("totalprice")
                    .HasColumnType("money");

                entity.HasOne(d => d.IdaccountNavigation)
                    .WithMany(p => p.Orderproduct)
                    .HasForeignKey(d => d.Idaccount)
                    .HasConstraintName("FK__orderprod__IDacc__36B12243");

                entity.HasOne(d => d.IdstoreNavigation)
                    .WithMany(p => p.Orderproduct)
                    .HasForeignKey(d => d.Idstore)
                    .HasConstraintName("FK__orderprod__IDsto__37A5467C");

                entity.HasOne(d => d.IdvoucherNavigation)
                    .WithMany(p => p.Orderproduct)
                    .HasForeignKey(d => d.Idvoucher)
                    .HasConstraintName("FK__orderprod__IDvou__38996AB5");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Idproduct)
                    .HasName("PK__product__51762282A0B9076C");

                entity.ToTable("product");

                entity.Property(e => e.Idproduct).HasColumnName("IDproduct");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Idstore).HasColumnName("IDstore");

                entity.Property(e => e.LinkImg)
                    .HasColumnName("linkIMG")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nameproduct)
                    .HasColumnName("nameproduct")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.Trademark)
                    .HasColumnName("trademark")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdcategoryNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.Idcategory)
                    .HasConstraintName("FK__product__IDcateg__5CD6CB2B");

                entity.HasOne(d => d.IdstoreNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.Idstore)
                    .HasConstraintName("FK__product__IDstore__398D8EEE");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.HasKey(e => e.Idpromotion)
                    .HasName("PK__promotio__53DC425E8AC55A20");

                entity.ToTable("promotion");

                entity.Property(e => e.Idpromotion).HasColumnName("IDpromotion");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Createday)
                    .HasColumnName("createday")
                    .HasColumnType("date");

                entity.Property(e => e.LinkImg)
                    .HasColumnName("linkIMG")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Linkimgpromotion)
                    .HasColumnName("linkimgpromotion")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reviewproduct>(entity =>
            {
                entity.HasKey(e => e.Idreview)
                    .HasName("PK__reviewpr__0E4F3079B548D9C1");

                entity.ToTable("reviewproduct");

                entity.Property(e => e.Idreview).HasColumnName("IDreview");

                entity.Property(e => e.Createday)
                    .HasColumnName("createday")
                    .HasColumnType("date");

                entity.Property(e => e.Idaccount).HasColumnName("IDaccount");

                entity.Property(e => e.Idcartdetail).HasColumnName("IDcartdetail");

                entity.Property(e => e.Startnum).HasColumnName("startnum");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdaccountNavigation)
                    .WithMany(p => p.Reviewproduct)
                    .HasForeignKey(d => d.Idaccount)
                    .HasConstraintName("FK__reviewpro__IDacc__32E0915F");

                entity.HasOne(d => d.IdcartdetailNavigation)
                    .WithMany(p => p.Reviewproduct)
                    .HasForeignKey(d => d.Idcartdetail)
                    .HasConstraintName("FK__reviewpro__IDcar__33D4B598");
            });

            modelBuilder.Entity<Roleaccount>(entity =>
            {
                entity.HasKey(e => e.Idrole)
                    .HasName("PK__roleacco__8A79092272F75CD9");

                entity.ToTable("roleaccount");

                entity.Property(e => e.Idrole).HasColumnName("IDrole");

                entity.Property(e => e.Idaccount).HasColumnName("IDaccount");

                entity.Property(e => e.Rolename)
                    .HasColumnName("rolename")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdaccountNavigation)
                    .WithMany(p => p.Roleaccount)
                    .HasForeignKey(d => d.Idaccount)
                    .HasConstraintName("FK__roleaccou__IDacc__2C3393D0");
            });

            modelBuilder.Entity<Roledetail>(entity =>
            {
                entity.HasKey(e => e.Idroledetail)
                    .HasName("PK__roledeta__44E61052EA636781");

                entity.ToTable("roledetail");

                entity.Property(e => e.Idroledetail).HasColumnName("IDroledetail");

                entity.Property(e => e.Idrole).HasColumnName("IDrole");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdroleNavigation)
                    .WithMany(p => p.Roledetail)
                    .HasForeignKey(d => d.Idrole)
                    .HasConstraintName("FK__roledetai__IDrol__2D27B809");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.Idstore)
                    .HasName("PK__store__5ECEE99E88E4E1EC");

                entity.ToTable("store");

                entity.Property(e => e.Idstore).HasColumnName("IDstore");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Bankinfo).HasColumnName("bankinfo");

                entity.Property(e => e.IdaccountOwn).HasColumnName("IDaccountOWN");

                entity.Property(e => e.Information)
                    .HasColumnName("information")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.LinkImg)
                    .HasColumnName("linkIMG")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Namestore)
                    .HasColumnName("namestore")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.ShippingService)
                    .HasColumnName("shipping_service")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdaccountOwnNavigation)
                    .WithMany(p => p.Store)
                    .HasForeignKey(d => d.IdaccountOwn)
                    .HasConstraintName("FK__store__IDaccount__3A81B327");
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.HasKey(e => e.Idvoucher)
                    .HasName("PK__voucher__3F7F444E8BD93C81");

                entity.ToTable("voucher");

                entity.Property(e => e.Idvoucher).HasColumnName("IDvoucher");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.Finishday)
                    .HasColumnName("finishday")
                    .HasColumnType("date");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Startday)
                    .HasColumnName("startday")
                    .HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
