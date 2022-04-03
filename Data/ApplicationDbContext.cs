using APIMuhasibat.Models;
using APIMuhasibat.Models.LOGER;
using APIMuhasibat.Models.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APIMuhasibat.Data
{
   public class ApplicationDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //https://docs.microsoft.com/en-us/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-6.0
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // builder.Conventions.Remove<Plua>
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            //modelBuilder.Entity<IdentityUser>(b =>
            //{
            //    b.ToTable("kamUsers");
            //});

            //modelBuilder.Entity<IdentityUserClaim<string>>(b =>
            //{
            //    b.ToTable("kamUserClaims");
            //});

            //modelBuilder.Entity<IdentityUserLogin<string>>(b =>
            //{
            //    b.ToTable("kamUserLogins");
            //});

            //modelBuilder.Entity<IdentityUserToken<string>>(b =>
            //{
            //    b.ToTable("kamUserTokens");
            //});

            //modelBuilder.Entity<IdentityRole>(b =>
            //{
            //    b.ToTable("kamRoles");
            //});

            //modelBuilder.Entity<IdentityRoleClaim<string>>(b =>
            //{
            //    b.ToTable("kamRoleClaims");
            //});

            //modelBuilder.Entity<IdentityUserRole<string>>(b =>
            //{
            //    b.ToTable("kamUserRoles");
            //});
        }      
        public DbSet<Navbar> navbars { get; set; }
        public DbSet<NavbarRole> navroles { get; set; }
        public DbSet<Shirket> shirkets { get; set; }
        public DbSet<Mushteri> mushteris { get; set; }
        public DbSet<Madde> maddes { get; set; }
        public DbSet<Bolme> bolmes { get; set; }
        public DbSet<Hesab> hesabs { get; set; }
        public DbSet<Activler> aktivs { get; set; }
        public DbSet<Tipler> tips { get; set; }
        public DbSet<Vergi> vergis { get; set; }
        public DbSet<fealsahe> fealsahes { get; set; }
        public DbSet<Qrup> qrups { get; set; }        
        public DbSet<Vahid> vahids { get; set; }
        public DbSet<operation> operations { get; set; }
        public DbSet<Productmaster> productmasters { get; set; }
        public DbSet<Productdetal> Productdetals { get; set; }
        public DbSet<Valyuta> valyutas { get; set; }
        public DbSet<logger> loggers { get; set; }
        public DbSet<anbar> anbars { get; set; }
        // public DbSet<Cart> Carts { get; set; }
        // public DbSet<vido> vidos { get; set; }
        // public DbSet<Cont> conts { get; set; }
        // public DbSet<Balans> Balans { get; set; }
        // public DbSet<Tarifim> Tarifims { get; set; }
        // public DbSet<muxabir> muxabirs { get; set; }
        // public DbSet<_bashkitab> bashkitabs { get; set; }     
        // public DbSet<Komp> komps { get; set; }
        // public DbSet<RepoMas> RepoMass { get; set; }
        // public DbSet<RepoDet> RepoDets { get; set; }


    }
}
