using CurrencyBot.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyBot.Infrastructure.Database.Context
{
    public class ScheduleContext : DbContext
    {
        public DbSet<Schedule> Schedules { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("SheduleDb.db3");
        }
    }
}
