using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GlobalPessoas.Data
{
    public class GlobalPessoasContext : IdentityDbContext
    {
        public GlobalPessoasContext (DbContextOptions<GlobalPessoasContext> options)
            : base(options)
        {
        }

        public DbSet<GlobalPessoas.Models.Pessoa> Pessoa { get; set; }
    }
}
