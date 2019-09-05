using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperTast.Param
{
    public class QueryReportListDto
    {
        public string ReportId { get; set; }
        public string ReportDateTime { get; set; }
        public string ReportName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string  ReportPdf   { get; set; }
}
}
