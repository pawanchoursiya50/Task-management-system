using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCore.Models;

namespace TaskManagerCore.DBContext
{
    class TaskManagerDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
