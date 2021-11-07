using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
