using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quote.Service.Interfaces
{
    public interface IHospitalService
    {
        Task<dynamic> ExecutingSql(string name, string strParams);
        Task<string> ExecutingSqlQueryReport(string name, string strParams);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldUrl"></param>
        /// <param name="newUrl"></param>
        void CopyFolder(string oldUrl, string newUrl);
    }
}
