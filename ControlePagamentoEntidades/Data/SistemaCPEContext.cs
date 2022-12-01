using ControlePagamentoEntidades.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlePagamentoEntidades.Data
{
    public class SistemaCPEContext : DbContext
    {
        public SistemaCPEContext(DbContextOptions<SistemaCPEContext> options) : base(options) { }

        public DbSet<EntidadeModel> Entidades { get; set; }
        public DbSet<ProcessoModel> Processos { get; set; }
        public DbSet<PagamentoModel> Pagamentos { get; set; }

    }



}
