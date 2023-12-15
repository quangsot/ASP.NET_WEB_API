using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Application
{
    public class PositionCreate
    {
        /// <summary>
        /// id chức danh
        /// </summary>
        public Guid PositionId { get; set; }

        /// <summary>
        /// mã chức danh
        /// </summary>
        public string PositionCode { get; set; }

        /// <summary>
        /// tên chức danh
        /// </summary>
        public string PositionName { get; set; }
    }
}
