using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdminX.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Map the concrete ApplicationUser type to "Users" (do NOT map IdentityUser)
            builder.Entity<ApplicationUser>(b => b.ToTable("Auth_Users")); // AspNetUsers -> Users
            builder.Entity<IdentityRole>(b => b.ToTable("Auth_Roles")); // AspNetRoles -> Roles
            builder.Entity<IdentityUserRole<string>>(b => b.ToTable("Auth_UserRoles")); // AspNetUserRoles -> UserRoles
            builder.Entity<IdentityUserClaim<string>>(b => b.ToTable("Auth_UserClaims")); // AspNetUserClaims -> UserClaims
            builder.Entity<IdentityRoleClaim<string>>(b => b.ToTable("Auth_RoleClaims")); // AspNetRoleClaims -> RoleClaims
            builder.Entity<IdentityUserLogin<string>>(b => b.ToTable("Auth_UserLogins")); // AspNetUserLogins -> UserLogins
            builder.Entity<IdentityUserToken<string>>(b => b.ToTable("Auth_UserTokens")); // AspNetUserTokens -> UserTokens

            // Map the passkeys entity to "UserPassKeys" (rename AspNetUserPasskeys -> UserPassKeys)
            builder.Entity<IdentityUserPasskey<string>>(b => b.ToTable("Auth_UserPassKeys"));
        }
    }
}
