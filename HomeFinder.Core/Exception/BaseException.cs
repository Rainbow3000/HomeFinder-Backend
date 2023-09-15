using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HomeFinder.Core.Exception
{
    public class BaseException
    {
        #region Properties
        public int ErrorCode { get; set; }
        public string? DevMsg { get; set; }
        public string? UserMsg { get; set; }
        public string? TraceId { get; set; }
        public string? MoreInfo { get; set; }
        public List<dynamic>? ErrorMsgs { get; set; }


        #endregion

        #region Methods

        /// <summary>
        /// Hàm ghi đè phương thức toString chuyển đối tượng error về Json
        /// </summary>
        /// <returns>Object thông tin lỗi</returns>
        /// Created by: ndthinh (13/06/2023)
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
        #endregion
    }
}
