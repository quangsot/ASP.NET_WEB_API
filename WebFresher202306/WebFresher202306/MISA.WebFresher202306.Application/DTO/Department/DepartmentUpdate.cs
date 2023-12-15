using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Application
{
    public class DepartmentUpdate
    {
        /// <summary>
        /// id phòng ban
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// mã phòng ban
        /// </summary>
        public string DepartmentCode { get; set; }

        /// <summary>
        /// tên phòng ban
        /// </summary>
        public string DepartmentName { get; set; }
    }
}
