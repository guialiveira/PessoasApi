using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlobalPessoas.Models;

namespace GlobalPessoas.Data
{
    public class GlobalPessoasContext : DbContext
    {
        public GlobalPessoasContext (DbContextOptions<GlobalPessoasContext> options)
            : base(options)
        {
        }

        public DbSet<GlobalPessoas.Models.Pessoa> Pessoa { get; set; }
    }
}
