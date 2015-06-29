using LinkHub.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkHub.DAL
{
    public class CategoryDb
    {

        private LinkHubDbEntities db;

        public CategoryDb()
        {
            this.db = new LinkHubDbEntities();
        }

        public IEnumerable<tbl_Category> GetAll()
        {
            return this.db.tbl_Category.ToList();
        }

        public tbl_Category GetByID(int id)
        {
            return this.db.tbl_Category.Find(id);
        }

        public void Insert(tbl_Category category)
        {
            this.db.tbl_Category.Add(category);
            this.Save();
        }

        public void Delete(int id)
        {
            tbl_Category category = this.db.tbl_Category.Find(id);
            this.db.tbl_Category.Remove(category);
            this.Save();
        }

        public void Update(tbl_Category category)
        {
            this.db.Entry(category).State = System.Data.Entity.EntityState.Modified;
        }

        public void Save()
        {
            this.db.SaveChanges();
        }

    }
}
