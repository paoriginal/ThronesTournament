using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    interface iDal
    {
        List<string> ExecSelectRequest(string request);
        void ExecRequest(string request);
    }
}
