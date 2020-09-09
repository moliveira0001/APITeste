using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class ColumnInDataBase : System.Attribute
    {
        private string _columnName;

        public ColumnInDataBase(string nameColumn_)
        {
            this._columnName = nameColumn_;
        }

        public string ColumnName()
        {
            return this._columnName;
        }
    }

}
