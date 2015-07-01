using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
