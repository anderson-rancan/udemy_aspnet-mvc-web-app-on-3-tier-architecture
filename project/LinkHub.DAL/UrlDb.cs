using LinkHub.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkHub.DAL
{
    public class UrlDb
    {

        private LinkHubDbEntities db;

        public UrlDb()
        {
            this.db = new LinkHubDbEntities();
        }

        public IEnumerable<tbl_Url> GetAll()
        {
            return this.db.tbl_Url.ToList();
        }

        public tbl_Url GetByID(int id)
        {
            return this.db.tbl_Url.Find(id);
        }

        public void Insert(tbl_Url url)
        {
            this.db.tbl_Url.Add(url);
            this.Save();
        }

        public void Delete(int id)
        {
            tbl_Url url = this.db.tbl_Url.Find(id);
            this.db.tbl_Url.Remove(url);
            this.Save();
        }

        public void Update(tbl_Url url)
        {
            this.db.Entry(url).State = System.Data.Entity.EntityState.Modified;
        }

        public void Save()
        {
            this.db.SaveChanges();
        }

    }
}
