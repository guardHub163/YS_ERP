using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class ListItem
    {
        private string _value;
        private string _text;
        private decimal _quantity;

        public ListItem(string value, string text)
        {
            this._value = value;
            this._text = text;
        }

        public ListItem(string value, string text, decimal quantity)
        {
            this._value = value;
            this._text = text;
            this._quantity = quantity;
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public decimal Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public override string ToString()
        {
            return _text;
        }
    }//end class
}
