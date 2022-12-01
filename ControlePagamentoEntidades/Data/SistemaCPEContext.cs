using ControlePagamentoEntidades.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlePagamentoEntidades.Data
{
    public class SistemaCPEContext : DbContext
    {
        public SistemaCPEContext(DbContextOptions<SistemaCPEContext> options) : base(options) { }

        public DbSet<EntidadeModel> Endidades { get; set; }




    }



}
