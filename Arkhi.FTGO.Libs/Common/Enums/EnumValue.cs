using System;

namespace Arkhi.FTGO.Libs.Common.Enums
{
    public class EnumValue
    {
        public string Value { get; set; }
        public string Description { get; set; }

        public override bool Equals(object obj)
        {
            return obj is EnumValue value &&
                   Value == value.Value &&
                   Description == value.Description;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Description);
        }
    }
}