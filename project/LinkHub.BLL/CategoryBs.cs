using LinkHub.BOL;
using LinkHub.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkHub.BLL
{
    public class CategoryBs
    {

        private CategoryDb objDb;

        public CategoryBs()
        {
            this.objDb = new CategoryDb();
        }

        public IEnumerable<tbl_Category> GetAll()
        {
            return this.objDb.GetAll();
        }

        public tbl_Category GetByID(int id)
        {
            return this.objDb.GetByID(id);
        }

        public void Insert(tbl_Category category)
        {
            this.objDb.Insert(category);
        }

        public void Delete(int id)
        {
            this.objDb.Delete(id);
        }

        public void Update(tbl_Category category)
        {
            this.objDb.Update(category);
        }

    }
}
