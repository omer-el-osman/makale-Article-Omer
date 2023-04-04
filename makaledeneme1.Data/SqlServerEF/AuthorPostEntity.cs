using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using makaledeneme1.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace makaledeneme1.Data.SqlServerEF
{
    public class AuthorPostEntity : IDataHelper<AuthorPost>
    {
        private DBContext db;
        private AuthorPost _Author;
        public AuthorPostEntity()
        {
            db = new DBContext();
        }
        public int Add(AuthorPost table)
        {
            if (db.Database.CanConnect())
            {
                db.authorPosts.Add(table);
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
                db.authorPosts.Remove(_Author);
                db.SaveChanges();

                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(int Id, AuthorPost table)
        {
            db = new DBContext();
            if (db.Database.CanConnect())
            {
                db.authorPosts.Update(table);
                db.SaveChanges();

                return 1;
            }
            else
            {
                return 0;
            }
        }

        public AuthorPost Find(int Id)
        {
            if (db.Database.CanConnect())
            {

                return db.authorPosts.Where(x => x.Id == Id).FirstOrDefault();

            }
            else
            {
                return null;
            }
        }

        public List<AuthorPost> getAllData()
        {
            if (db.Database.CanConnect())
            {

                return db.authorPosts.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<AuthorPost> getDataByUser(string UserId)
        {

            if (db.Database.CanConnect())
            {

                return db.authorPosts.Where(x=>x.UserId==UserId).ToList();
            }
            else
            {
                return null;
            }
        }

        public List<AuthorPost>? search(string searchItem)
        {
            if (db.Database.CanConnect())
            {
                return db.authorPosts.Where(x => x.FullName.Contains(searchItem) 
              || x.Id.ToString().Contains(searchItem)
              || x.UserId.Contains(searchItem)
             || x.UserName.Contains(searchItem)
                || x.FullName.Contains(searchItem)
                || x.PostTitle.Contains(searchItem)
              || x.PostDescriptoin.Contains(searchItem)
                || x.CategoryId.ToString().Contains(searchItem)
                  || x.AuthorId.ToString().Contains(searchItem)
                    || x.AddedDAte.ToString().Contains(searchItem)
              ).ToList();





            }
            else
            {
                return null;
            }

        }




    }
}
