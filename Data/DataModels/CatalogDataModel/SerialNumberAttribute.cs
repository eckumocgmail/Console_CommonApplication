using System;

namespace DataEntities
{
    public class SerialNumberAttribute : Attribute
    {
        private string v;

        public SerialNumberAttribute(string v)
        {
            this.v = v;
        }
    }
}