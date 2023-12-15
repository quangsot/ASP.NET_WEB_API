using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Domain
{
    /// <summary>
    /// attribute kiểm tra ngày có lớn hơn ngày hiện tại không
    /// author: Trương Mạnh Quang (9/9/2023)
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MisaDateAttribute : ValidationAttribute
    {
        public MisaDateAttribute() { }
        public override bool IsValid(object? value)
        {
            if (value != null)
            {
                var date = (DateTime)value;
                if (date > DateTime.Now)
                {
                    return false;
                }
                else return true;

            }
            else return true;
        }
    }
}
