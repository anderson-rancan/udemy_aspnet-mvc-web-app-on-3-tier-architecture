using LinkHub.BOL;
using LinkHub.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkHub.BLL
{
    public class UserBs
    {

        private UserDb objDb;

        public UserBs()
        {
            this.objDb = new UserDb();
        }

        public IEnumerable<tbl_User> GetAll()
        {
            return this.objDb.GetAll();
        }

        public tbl_User GetByID(int id)
        {
            return this.objDb.GetByID(id);
        }

        public void Insert(tbl_User user)
        {
            this.objDb.Insert(user);
        }

        public void Delete(int id)
        {
            this.objDb.Delete(id);
        }

        public void Update(tbl_User user)
        {
            this.objDb.Update(user);
        }

    }
}
