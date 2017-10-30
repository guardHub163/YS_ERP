using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CZZD.ERP.IDAL
{
    public interface IProduce
    {
        System.Data.DataSet GetBomList(string slipNumbers);


    }
}
