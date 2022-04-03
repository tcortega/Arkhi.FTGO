using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Arkhi.FTGO.Libs.Common.Enums
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value, bool isLower = false)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attributes =
                (DescriptionAttribute[]) fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            var description = attributes.Length > 0 ? attributes[0].Description : value.ToString();
            return isLower ? description.ToLower() : description;
        }

        public static EnumValue GetValue(this Enum value)
        {
            return new EnumValue {Value = value.ToString(), Description = value.GetDescription()};
        }

        public static IList<EnumValue> GetValues<T>()
        {
            var values = new List<EnumValue>();
            var type = typeof(T);

            foreach (var item in Enum.GetNames(type))
            {
                var enun = (Enum) Enum.Parse(type, item);

                values.Add(new EnumValue
                {
                    Value = enun.ToString(),
                    Description = enun.GetDescription()
                });
            }

            return values.OrderBy(x => x.Description).ToList();
        }
    }
}