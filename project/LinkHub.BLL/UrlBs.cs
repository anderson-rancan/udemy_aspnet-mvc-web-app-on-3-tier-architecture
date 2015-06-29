using LinkHub.BOL;
using LinkHub.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkHub.BLL
{
    public class UrlBs
    {

        private UrlDb objDb;

        public UrlBs()
        {
            this.objDb = new UrlDb();
        }

        public IEnumerable<tbl_Url> GetAll()
        {
            return this.objDb.GetAll();
        }

        public tbl_Url GetByID(int id)
        {
            return this.objDb.GetByID(id);
        }

        public void Insert(tbl_Url url)
        {
            this.objDb.Insert(url);
        }

        public void Delete(int id)
        {
            this.objDb.Delete(id);
        }

        public void Update(tbl_Url url)
        {
            this.objDb.Update(url);
        }

    }
}
