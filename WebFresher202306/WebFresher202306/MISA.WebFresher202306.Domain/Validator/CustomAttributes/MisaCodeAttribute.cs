using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Domain
{
    /// <summary>
    /// attribute kiểm tra mã có phải kết thúc bằng số không
    /// </summary>
    /// author: Trương Mạnh Quang (9/9/2023)
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MisaCodeAttribute : ValidationAttribute
    {
        public MisaCodeAttribute() { }
        public override bool IsValid(object? value)
        {
            string strCode = value as string ?? "";
            if (int.TryParse(strCode[^1].ToString(), out _))
            {
                return true;
            }
            else return false;
        }
    }
}
