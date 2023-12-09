using BucksCoffeeShopBefore.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BucksCoffeeShopBefore.Infrastructure;

public partial class BucksCoffeeShopContext : DbContext, IBucksCoffeeShopContext
{
    private readonly IConfiguration _config;

    public BucksCoffeeShopContext(IConfiguration config)
    {
        _config = config;
    }

    public BucksCoffeeShopContext(DbContextOptions<BucksCoffeeShopContext> options,
        IConfiguration config)
        : base(options)
    {
        _config = config;
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;

        var connString = _config.GetConnectionString("Default");
        if (!string.IsNullOrEmpty(connString))
        {
            optionsBuilder.UseSqlServer(connString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Category");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.OrderDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.ToTable("OrderDetail");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Qty).HasDefaultValue(1);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetail_Order");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetail_Product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.Available).HasDefaultValue(true);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasDefaultValue("");
            entity.Property(e => e.Image).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Qty).HasDefaultValue(1);
        });

        if (!Categories.Any())
        {
            Categories.Add(new Category { Id = 1, Name="Cold Drinks"});
            Categories.Add(new Category { Id = 2, Name="Cold Coffees"});
            Categories.Add(new Category { Id = 3, Name="Iced Teas"});
            Categories.Add(new Category { Id = 4, Name="Hot Drinks"});
            Categories.Add(new Category { Id = 5, Name="Hot Teas"});
            Categories.Add(new Category { Id = 6, Name="Hot Coffee"});
            SaveChanges();
        }

        if (!Products.Any())
        {
            var list = new List<Product>
            {
                new()
                {
                    Id= new Guid("4B64CAA9-ECDE-4D59-8A15-04D8B72DF0CC")
                },
                new()
                {
                    Id= new Guid("660EA159-55D6-4D6F-9ED3-451A45EF1664")
                },
                new()
                {
                    Id= new Guid("93E8B6BA-7779-43D6-A866-9463B86E6D83")
                },
                new()
                {
                    Id= new Guid("D8680971-D553-4507-94A4-AA8C6EDC198B")
                },
                new()
                {
                    Id= new Guid("A625C343-6726-4AB2-AD6E-B71ECA7AB8BB")
                },
                new()
                {
                    Id= new Guid("12BD2BEA-AEC6-4D31-BF9E-DACA8E032498")
                },
                new()
                {
                    Id= new Guid("2F9E90E5-6431-46CE-9DC4-DBA828550846")
                }
            };
            Products.AddRangeAsync(list);
            SaveChanges();
        }

            //// Template Type
            //if (this.TableExists(this.TableName(typeof(TemplateType)), this.TableSchema(typeof(TemplateType)))
            //    && !this.TemplateType.Any())
            //{
            //    this.TemplateType.Add(new TemplateType { Id = "722d435e-2361-45e9-8026-94c6967df53e", TemplateName = "Social: Instagram"});
            //    this.TemplateType.Add(new TemplateType { Id = "84d8499e-cbe0-4556-aa14-0484dd294640", TemplateName = "Social: Twitter"});
            //    this.TemplateType.Add(new TemplateType { Id = "b3c89dcd-c970-4808-af2a-d633046c46b8", TemplateName = "Newsletter"});
            //    this.TemplateType.Add(new TemplateType { Id = "c201df34-450a-4bdf-869f-1c636a266003", TemplateName = "Social: LinkedIn"});
            //    this.TemplateType.Add(new TemplateType { Id = "c6dec59a-9ff3-4f08-b501-81db99cd292e", TemplateName = "Web Page"});
            //    this.TemplateType.Add(new TemplateType { Id = "cd50a92a-dde2-45a9-854e-4dc88b065461", TemplateName = "Social: Facebook"});
            //    this.TemplateType.Add(new TemplateType { Id = "e0eaa185-5b97-4586-babc-5a7de744d77d", TemplateName = "Social: Google+"});
            //    this.TemplateType.Add(new TemplateType { Id = "F0627039-4755-418A-BC7B-C299F7C7BFBF", TemplateName = "Email"});
            //    this.SaveChanges();
            //}

            //// Content Structure
            //if (this.TableExists(this.TableName(typeof(ContentStructure)), this.TableSchema(typeof(ContentStructure)))
            //    && !this.ContentStructure.Any())
            //{
            //    this.ContentStructure.Add(new ContentStructure { SiteId = null, ContentTypeId = 1, Name="Title", FieldTypeId = 2, Size=150, AllowNull = true, RelatesTo = null});
            //    this.ContentStructure.Add(new ContentStructure { SiteId = null, ContentTypeId = 1, Name="Hash", FieldTypeId = 2, Size=50, AllowNull = true, RelatesTo = null});
            //    this.ContentStructure.Add(new ContentStructure { SiteId = null, ContentTypeId = 1, Name="Keywords", FieldTypeId = 2, Size=200, AllowNull = true, RelatesTo = null});
            //    this.ContentStructure.Add(new ContentStructure { SiteId = null, ContentTypeId = 1, Name="Abstract", FieldTypeId = 2, Size=null, AllowNull = true, RelatesTo = null});
            //    this.ContentStructure.Add(new ContentStructure { SiteId = null, ContentTypeId = 1, Name="Description", FieldTypeId = 2, Size=null, AllowNull = true, RelatesTo = null});
            //    this.ContentStructure.Add(new ContentStructure { SiteId = null, ContentTypeId = 1, Name="CreatedOn", FieldTypeId = 8, Size=null, AllowNull = false, RelatesTo = null});
            //    this.ContentStructure.Add(new ContentStructure { SiteId = null, ContentTypeId = 1, Name="Approved", FieldTypeId = 9, Size=null, AllowNull = false, RelatesTo = null});
            //    this.ContentStructure.Add(new ContentStructure { SiteId = null, ContentTypeId = 1, Name="PublishOn", FieldTypeId = 8, Size=null, AllowNull = true, RelatesTo = null});
            //    this.ContentStructure.Add(new ContentStructure { SiteId = null, ContentTypeId = 1, Name="Hits", FieldTypeId = 4, Size=null, AllowNull = false, RelatesTo = null});
            //    this.ContentStructure.Add(new ContentStructure { SiteId = null, ContentTypeId = 1, Name="AllowComments", FieldTypeId = 9, Size=null, AllowNull = false, RelatesTo = null});
            //    this.ContentStructure.Add(new ContentStructure { SiteId = null, ContentTypeId = 1, Name="Url", FieldTypeId = 2, Size=null, AllowNull = true, RelatesTo = null});
            //    this.ContentStructure.Add(new ContentStructure { SiteId = null, ContentTypeId = 1, Name="Author", FieldTypeId = 10, Size=null, AllowNull = true, RelatesTo = 2});
            //    this.ContentStructure.Add(new ContentStructure { SiteId = null, ContentTypeId = 2, Name="AuthorName", FieldTypeId = 2, Size=50, AllowNull = false, RelatesTo = null});
            //    this.ContentStructure.Add(new ContentStructure { SiteId = null, ContentTypeId = 2, Name="EMail", FieldTypeId = 2, Size=100, AllowNull = true, RelatesTo = null});
            //    this.ContentStructure.Add(new ContentStructure { SiteId = null, ContentTypeId = 2, Name="URL", FieldTypeId = 2, Size=150, AllowNull = true, RelatesTo = null});
            //    this.ContentStructure.Add(new ContentStructure { SiteId = null, ContentTypeId = 2, Name="ImageUrl", FieldTypeId = 2, Size=100, AllowNull = true, RelatesTo = null});
            //    this.ContentStructure.Add(new ContentStructure { SiteId = null, ContentTypeId = 2, Name="Bio", FieldTypeId = 2, Size=null, AllowNull = false, RelatesTo = null});
            //    this.ContentStructure.Add(new ContentStructure { SiteId = null, ContentTypeId = 1, Name="Tags", FieldTypeId = 10, Size=null, AllowNull = false, RelatesTo = 3});
            //    this.ContentStructure.Add(new ContentStructure { SiteId = null, ContentTypeId = 3, Name="Name", FieldTypeId = 2, Size=100, AllowNull = false, RelatesTo = null});
            //    this.ContentStructure.Add(new ContentStructure { SiteId = null, ContentTypeId = 4, Name="SiteName", FieldTypeId = 2, Size=30, AllowNull = false, RelatesTo = null});
            //    this.ContentStructure.Add(new ContentStructure { SiteId = null, ContentTypeId = 4, Name="SiteUrl", FieldTypeId = 2, Size=200, AllowNull = false, RelatesTo = null});
            //    this.SaveChanges();
            //}

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
