using System;
using System.Collections.Generic;
using System.Text;

namespace Wis.Anes.Framework.Designer
{
    public class DictFieldNamesDropDownEditor : FieldNamesDropDownEditor
    {
        public DictFieldNamesDropDownEditor() : base("DictTableName",false) { }
    }

    public class ListFieldNamesDropDownEditor : FieldNamesDropDownEditor
    {
        public ListFieldNamesDropDownEditor() : base("ListTableName", true) { }
    }

    public class ListFieldNameDropDownEditor : FieldNamesDropDownEditor
    {
        public ListFieldNameDropDownEditor() : base("ListTableName", false) { }
    }

    public class SourceFieldNameDropDownEditor : FieldNamesDropDownEditor
    {
        public SourceFieldNameDropDownEditor() : base("SourceTableName", false) { }
    }

}
