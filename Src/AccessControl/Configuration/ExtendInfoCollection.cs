using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Wis.AccessControl.Configuration
{
    public sealed class ExtendInfoCollection : ConfigurationElementCollection
    {
        public new ExtendInfoItem this[string key]
        {
            get { return BaseGet(key) as ExtendInfoItem; }
        }

        public ExtendInfoItem this[int index]
        {
            get { return BaseGet(index) as ExtendInfoItem; }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ExtendInfoItem();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ExtendInfoItem)element).Name;
        }
    }
}
