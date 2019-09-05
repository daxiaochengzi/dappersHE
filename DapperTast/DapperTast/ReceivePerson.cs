using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperTast
{
    public class ReceivePerson
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        /// <summary>
        /// 部门id
        /// </summary>
        public Guid OrganizationId { get; set; }
        /// <summary>
        /// 发布信息id
        /// </summary>
        public Guid NewsReleaseId { get; set; }
        /// <summary>
        /// 是否阅读
        /// </summary>
        public bool IsRead { get; set; }
        /// <summary>
        /// 回复信息
        /// </summary>
        public string ReplyMsg { get; set; }
        /// <summary>
        /// 回复时间
        /// </summary>
        public DateTime? ReplyTime { get; set; }
        public int Num { get; set; }
    }
    public class ErrorTest
    {
        public List<Guid> guids { get; set; }
    }
}
