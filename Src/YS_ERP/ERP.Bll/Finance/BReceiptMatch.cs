using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;

namespace CZZD.ERP.Bll
{
    public class BReceiptMatch
    {
        IReceiptMatch dal = DALFactory.DataAccess.CreateReceiptMatchManage();

    }
}
