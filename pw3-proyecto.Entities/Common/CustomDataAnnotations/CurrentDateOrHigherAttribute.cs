using System;
using System.ComponentModel.DataAnnotations;

namespace pw3_proyecto.Common.CustomDataAnnotations
{
    public class CurrentDateOrHigherAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var date = (DateTime) value;
            return date > DateTime.Now;
        }
    }
}
