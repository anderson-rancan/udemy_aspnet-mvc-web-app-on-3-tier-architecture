using LinkHub.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkHub.DAL
{
    public class UserDb
    {

        private LinkHubDbEntities db;

        public UserDb()
        {
            this.db = new LinkHubDbEntities();
        }

        public IEnumerable<tbl_User> GetAll()
        {
            return this.db.tbl_User.ToList();
        }

        public tbl_User GetByID(int id)
        {
            return this.db.tbl_User.Find(id);
        }

        public void Insert(tbl_User user)
        {
            this.db.tbl_User.Add(user);
            this.Save();
        }

        public void Delete(int id)
        {
            tbl_User user = this.db.tbl_User.Find(id);
            this.db.tbl_User.Remove(user);
            this.Save();
        }

        public void Update(tbl_User user)
        {
            this.db.Entry(user).State = System.Data.Entity.EntityState.Modified;
        }

        public void Save()
        {
            this.db.SaveChanges();
        }

    }
}
