using System;
using System.Collections.Generic;
using System.Text;

namespace Wis.Anes.Framework
{
    public class DrugSummeryItem
    {
        private string _itemName;
        public string ItemName
        {
            get
            {
                return _itemName;
            }
            set
            {
                _itemName = value;
            }
        }

        private string _value;
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public DrugSummeryItem(string itemName, string value)
        {
            _itemName = itemName;
            _value = value;
        }
    }
}
