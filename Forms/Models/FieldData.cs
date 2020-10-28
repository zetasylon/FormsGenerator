using Forms.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forms.Models
{
    public class FieldData
    {
        public string Name { get; set; }
        public EnumTypeComponent TypeComponent { get; set; }
        public List<FieldData> Fields { get; set; }
    }
}
