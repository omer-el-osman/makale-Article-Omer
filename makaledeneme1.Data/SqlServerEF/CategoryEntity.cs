using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using makaledeneme1.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace makaledeneme1.Data.SqlServerEF
{
    public class CategoryEntity : IDataHelper<Category>
    {
        private DBContext db;
        private Category _Category;
        public CategoryEntity()
        {
            db = new DBContext();
        }
        public int Add(Category table)
        {
            if (db.Database.CanConnect())
            {
                db.Category.Add(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int delete(int Id)
        {
            _Category = Find(Id);
            if (db.Database.CanConnect())
            {
                db.Category.Remove(_Category);
                db.SaveChanges();

                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(int Id, Category table)
        {
            db = new DBContext();
            if (db.Database.CanConnect())
            {
                db.Category.Update(table);
                db.SaveChanges();

                return 1;
            }
            else
            {
                return 0;
            }
        }

        public Category Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                
                return db.Category.Where(x =>x.Id == Id).First();

            }
            else
            {
                return null;
            }
        }

        public List<Category> getAllData()
        {
            if (db.Database.CanConnect())
            {

                return db.Category.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<Category> getDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<Category> search(string searchItem)
        {
            if (db.Database.CanConnect())
            {
                return db.Category.Where(x=>x.Name.Contains(searchItem)||x.Id.ToString().Contains(searchItem)).ToList();
            }
            else
            {
                return null;
            }
        }
    }
}
