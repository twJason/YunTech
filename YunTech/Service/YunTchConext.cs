using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using YunTech.Model;

namespace YunTech.Service
{
    public class YunTchConext : DbContext
    {
        public YunTchConext() : base("data source=.;initial catalog=筆試_STUDB;integrated security=True;")
        {
        }

        public DbSet<系所資料> Depts { get; set; }
        public DbSet<課程資料> Subjects { get; set; }
        public DbSet<學生學籍資料> Students { get; set; }
        public DbSet<學生選課資料> StudentCourses { get; set; }
        public DbSet<學期課程資料> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }
    }
}