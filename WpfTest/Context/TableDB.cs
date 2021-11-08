using Microsoft.EntityFrameworkCore;
using WpfTest.Models;

namespace WpfTest.Context
{
    public class TableDB : DbContext
    {
        public DbSet<Table> Tables { get; set; }
        public TableDB(DbContextOptions<TableDB> options) : base(options)
        {

        }
    }
}
