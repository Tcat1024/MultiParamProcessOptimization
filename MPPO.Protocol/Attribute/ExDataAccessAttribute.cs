using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPPO.Protocol.Attribute
{
    public class ExDataAccessClassAttribute: System.Attribute
    {
        public string Description { get; set; }
        public ExDataAccessClassAttribute()
        {

        }
        public ExDataAccessClassAttribute(string description)
        {
            this.Description = description;
        }
    }
    public class ExDataGetMethodAttribute:System.Attribute
    {
        public string Description { get; set; }
        public ExDataGetMethodAttribute()
        {

        }
        public ExDataGetMethodAttribute(string description)
        {
            this.Description = description;
        }
    }
}
