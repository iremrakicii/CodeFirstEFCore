# CodeFirstRelation Projesi

---

## Proje Açıklaması
Bu proje, Entity Framework Core kullanılarak oluşturulmuş bir Code First uygulamasıdır. Kullanıcılar (**User**) ve onların yazdığı gönderiler (**Post**) arasında bire-çok ilişkisi modellenmiştir.

---

## Kullanılan Teknolojiler
- **C#**
- **Entity Framework Core**
- **SQL Server**

---

## Yapı
- **User**: Sistemdeki kullanıcıları temsil eder.
- **Post**: Kullanıcıların yazdığı gönderileri temsil eder.
- **İlişki**: Bir kullanıcı birden fazla gönderiye sahip olabilir (**Bire-Çok**).

---

## Kodlar

### Post Sınıfı
```csharp
public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}
```
### User Sınıfı
```
public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public ICollection<Post> Posts { get; set; }
}
```
### DbContext Yapılandırması
```
public class PatikaSecondDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=LAKICI53;Database=PatikaCodeFirstDb2;Trusted_Connection=True;TrustServerCertificate=True;");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>()
            .HasOne(p => p.User)
            .WithMany(u => u.Posts)
            .HasForeignKey(p => p.UserId);

        base.OnModelCreating(modelBuilder);
    }
}
```
### Kurulum ve Çalıştırma
## Bağımlılıkları Yükleyin
```
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```
## Migration Oluşturma
```
dotnet ef migrations add InitialCreate
```
## Veritabanını Güncelleme
```
dotnet ef database update
```
## Projeyi Çalıştırın
```
dotnet run
```


