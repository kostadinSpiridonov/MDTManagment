using MDTManagment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDTManagment.Services
{
    public class BaseService
    {
        protected ApplicationDbContext database;

        public BaseService()
        {
            this.database = new ApplicationDbContext();
        }
    }
}
