using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using makaledeneme1.Core;
using Microsoft.EntityFrameworkCore;


namespace makaledeneme1.Data.SqlServerEF
{
    public class DBContext:DbContext
    {
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseSqlServer("Server=OMER\\SQLEXPRESS;Database=makaledeneme1;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=false");
        }


        //ilk migration ekleken Add-Migration AddAuthor -Context makaledeneme1.Data.SqlServerEF.DBContext boyle 
        
        public DbSet<Category> Category { get; set; }
        //Add-Migration : A parameter cannot be found that matches parameter name 'Context'. bu hata icin
        //ikinci migration eklerken  EntityFrameworkCore\Add-Migration AddAuthor -Context makaledeneme1.Data.SqlServerEF.DBContext
        //update icin da EntityFrameworkCore\update-database -Context makaledeneme1.Data.SqlServerEF.DBContext
        public DbSet<Author> Author { get; set; }
        public DbSet<AuthorPost>  authorPosts { get; set; }




    }
}
