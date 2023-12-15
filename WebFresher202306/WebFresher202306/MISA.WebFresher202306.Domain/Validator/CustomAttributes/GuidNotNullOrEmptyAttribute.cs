using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Domain
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class GuidNotNullOrEmptyAttribute : ValidationAttribute
    {
        public GuidNotNullOrEmptyAttribute() { }
        public override bool IsValid(object? value)
        {
            if (value == null) return false;

            if(string.IsNullOrEmpty(value.ToString())) return false;

            return true;
        }
    }
}
