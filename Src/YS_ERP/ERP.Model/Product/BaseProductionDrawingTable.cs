using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model.Product
{
    public class BaseProductionDrawingTable
    {
        public BaseProductionDrawingTable()
        { }
        private string _slip_number;
        private string _drawing_code;
        private string _file_name;
        private string _server_file_name;

        private List<BaseProductionDrawingTable> _items = new List<BaseProductionDrawingTable>();

        public List<BaseProductionDrawingTable> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public void AddItem(BaseProductionDrawingTable model)
        {
            _items.Add(model);
        }
        public string SLIPNUMBER
        {
            set { _slip_number = value; }
            get { return _slip_number; }
        }

        public string DRAWINGCODE
        {
            set { _drawing_code = value; }
            get { return _drawing_code; }
        }

        public string FILENAME
        {
            set { _file_name = value; }
            get { return _file_name; }
        }
        public string SERVERFILENAME
        {
            set { _server_file_name = value; }
            get { return _server_file_name; }
        }
    }
}
