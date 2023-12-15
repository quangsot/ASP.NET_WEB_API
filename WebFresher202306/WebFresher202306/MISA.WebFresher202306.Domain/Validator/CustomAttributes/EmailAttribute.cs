using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebFresher202306.Domain
{
    /// <summary>
    /// attribute kiểm tra định dạng email
    /// </summary>
    /// author: Trương Mạnh Quang (9/9/2023)
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class EmailAttribute : ValidationAttribute
    {
        private readonly string _regex; 
        public EmailAttribute()
        {
            _regex = @"^([a-zA-Z0-9._%+-]+)@([a-zA-Z0-9.-]+\.[a-zA-Z]{2,})+$";
        }

        /// <summary>
        /// Hàm kiểm tra email khớp với định dạng không
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (24/8/2023)
        public override bool IsValid(object? value)
        {
            if (value is null) return true;
            string email = value?.ToString() ?? "";
            return Regex.IsMatch(email,_regex);
        }
    }
}
