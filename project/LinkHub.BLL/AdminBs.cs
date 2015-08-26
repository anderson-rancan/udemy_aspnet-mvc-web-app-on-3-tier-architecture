using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LinkHub.BOL;
using System.Transactions;

namespace LinkHub.BLL
{
    public class AdminBs
    {

        public CategoryBs Category { get; private set; }
        public UserBs User { get; private set; }
        public UrlBs Url { get; private set; }

        public AdminBs()
        {
            this.Category = new CategoryBs();
            this.User = new UserBs();
            this.Url = new UrlBs();
        }

        public void InsertQuickURL(BOL.QuickURLSubmitModel model)
        {
            // HACK - acrescentei referência a System.Transations
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    tbl_User user = model.User;
                    user.Password = user.ConfirmPassword = "1234";
                    user.Role = "U";
                    this.User.Insert(user);

                    tbl_Url url = model.Url;
                    url.UserId = user.UserId;
                    url.UrlDesc = url.UrlTitle;
                    url.IsApproved = "P";
                    this.Url.Insert(url);

                    trans.Complete();
                }
                catch
                {
                    throw;
                }
            }

        }

        public void ApproveOrReject(List<int> Ids, string Status)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    foreach (var item in Ids)
                    {
                        var myUrl = this.Url.GetByID(item);
                        myUrl.IsApproved = Status;
                        this.Url.Update(myUrl);
                    }

                    trans.Complete();
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }
    }
}
