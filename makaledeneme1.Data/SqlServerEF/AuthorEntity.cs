using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using makaledeneme1.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace makaledeneme1.Data.SqlServerEF
{
    public class AuthorEntity : IDataHelper<Author>
    {
        private DBContext db;
        private Author _Author;
        public AuthorEntity()
        {
            db = new DBContext();
        }
        public int Add(Author table)
        {
            if (db.Database.CanConnect())
            {
                db.Author.Add(table);
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
            _Author = Find(Id);
            if (db.Database.CanConnect())
            {
                db.Author.Remove(_Author);
                db.SaveChanges();

                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(int Id, Author table)
        {
            db = new DBContext();
            if (db.Database.CanConnect())
            {
                db.Author.Update(table);
                db.SaveChanges();

                return 1;
            }
            else
            {
                return 0;
            }
        }

        public Author Find(int Id)
        {
            if (db.Database.CanConnect())
            {

                return db.Author.Where(x => x.Id == Id).First();

            }
            else
            {
                return null;
            }
        }

        public List<Author> getAllData()
        {
            if (db.Database.CanConnect())
            {

                return db.Author.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<Author> getDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<Author>? search(string searchItem)
        {
            if (db.Database.CanConnect())
            {
                return db.Author.Where(x => x.FullName.Contains(searchItem) 
              || x.Id.ToString().Contains(searchItem)
              || x.UserId.Contains(searchItem)
             || x.Bio.Contains(searchItem)
                || x.Facebook.Contains(searchItem)
                || x.twitter.Contains(searchItem)
              || x.instagram.Contains(searchItem)).ToList();





            }
            else
            {
                return null;
            }

        }




    }
}
