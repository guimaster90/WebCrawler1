using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler1
{
    class MangaContext: DbContext
    {
        public DbSet<Manga> Manga { get; set; }
        public void Iniciar()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Data Source = localhost\\SQLEXPRESS; Initial Catalog = MangaDB; Integrated Security = True");
    }
}
