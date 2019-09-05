using DapperTast.Controllers;
using Sikiro.DapperLambdaExtension.MsSql.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperTast
{
    public class Test
    {
        public void Mydemo()
        {
            var con = new SqlConnection(
                      " Data Source=QUBER-PC-SAING\\SQL2012;Initial Catalog=MyDapper;Persist Security Info=True;User ID=sa;Password=123456");
            //插入
            var receivePersonData = new ReceivePerson
            {
                NewsReleaseId = Guid.NewGuid(),
                PersonId = Guid.NewGuid(),
                OrganizationId = Guid.NewGuid(),
                ReplyMsg = "223",
                Id = Guid.NewGuid()

            };
            var UpdataReceivePersonId = Guid.Parse("4433BE8D-C780-4D0D-9706-B39C5F059A48");
            //注意表达式内不支持参数类型转换
            //插入
            // var insertResult = con.CommandSet<ReceivePerson>().Insert(receivePersonData);
            //查询
            //var queryData = con.CommandSet<ReceivePerson>().Where(a => a.ReplyMsg == "56789");
            #region 更新

            // queryData.Update(a => new ReceivePerson { ReplyMsg = "444" });

            //var updateResult = con.CommandSet<ReceivePerson>().Where(a => a.Id == UpdataReceivePersonId)
            //.Update(a => new ReceivePerson { ReplyMsg = "123" });
            //---表达式内不支持参数类型转换
            //var updateResultc = con.CommandSet<ReceivePerson>().Where(a => a.Id == Guid.Parse("E180A4D8-B275-45D7-88F2-84C814480901"))
            //.Update(a => new ReceivePerson { ReplyMsg = "123" });
            //----UpdateSelect
            //var updateResult5 = con.QuerySet<ReceivePerson>().Where(a => a.Id == UpdataReceivePersonId)
            //    .Select(a => new ReceivePerson { ReplyMsg = a.ReplyMsg })
            //    .UpdateSelect(a => new ReceivePerson { ReplyMsg = "巴适的很" });
            #endregion
            #region 查询
            //查询默认第一行
            // var getResult = con.QuerySet<ReceivePerson>().Get();
            //查询List
            //var listResult = con.QuerySet<ReceivePerson>().ToList();
            //查询List
            //var listResultselect = con.QuerySet<ReceivePerson>().Select(x=>x.ReplyMsg).ToList();
            //查询排序List
            // var listOrderByselect = con.QuerySet<ReceivePerson>().OrderBy(a => a.ReplyMsg).Select(x => x.ReplyMsg).ToList();
            //OrderByDescing
            // var listDescByselect = con.QuerySet<ReceivePerson>().OrderByDescing(a => a.ReplyMsg).Select(x => x.ReplyMsg).ToList();
            #endregion
            #region top查询

            //var datatop1 = con.QuerySet<ReceivePerson>().Where(a => a.Id == ReceivePersonId && a.ReplyMsg == "444").OrderBy(b => b.ReplyMsg)
            // .Top(10).Select(a => a.ReplyMsg).ToList();
            //var datatop2 = con.QuerySet<ReceivePerson>().OrderBy(b => b.ReplyMsg).Top(10).ToList();
            #endregion
            #region  like
            // like"%123"
            //var likeDataStart = con.QuerySet<ReceivePerson>().Where(a => a.ReplyMsg.StartsWith( "44")).ToList();
            //like"123%"
            //var likeDataEnd = con.QuerySet<ReceivePerson>().Where(a => a.ReplyMsg.EndsWith("44")).ToList();
            //like"%123%"
            //var likeDataContains = con.QuerySet<ReceivePerson>().Where(a => a.ReplyMsg.Contains("44")).ToList();
            #endregion
            #region 函数
            //var sum = con.QuerySet<ReceivePerson>().Sum(a => a.ReplyMsg);
            var sum = con.QuerySet<ReceivePerson>().Sum(a => a.Num);
            //var Count = con.QuerySet<ReceivePerson>().Count();
            #endregion
            #region 分页时必须排序

            //var dataPage = con.QuerySet<ReceivePerson>().OrderBy(x=>x.ReplyMsg).PageList(1, 1);
            //var dataPage2 = con.QuerySet<ReceivePerson>().Where(x=>x.ReplyMsg== "444").OrderBy(x => x.ReplyMsg).
            //    Select(x=>x.ReplyMsg).PageList(1, 2);
            #endregion
            #region 删除
            //var resultData=  con.CommandSet<ReceivePerson>().Where(a => a.Id == UpdataReceivePersonId).Delete();
            #endregion
            #region 事务
            //con.Transaction(tc =>
            //{
            //    //插入
            //    tc.CommandSet<ReceivePerson>().Insert( new ReceivePerson
            //    {
            //        NewsReleaseId = Guid.NewGuid(),
            //        PersonId = Guid.NewGuid(),
            //        OrganizationId = Guid.NewGuid(),
            //        ReplyMsg = "11111",
            //        Id = Guid.NewGuid()

            //    });
            //    tc.CommandSet<ReceivePerson>().Insert(new ReceivePerson
            //    {
            //        NewsReleaseId = Guid.NewGuid(),
            //        PersonId = Guid.NewGuid(),
            //        OrganizationId = Guid.NewGuid(),
            //        ReplyMsg = "22222",
            //        Id = Guid.NewGuid()

            //    });

            //    tc.CommandSet<ReceivePerson>().Where(a => a.ReplyMsg == "11111").Delete();
            //});
            #endregion
            #region 运算符
            //var datatop3 = con.QuerySet<ReceivePerson>().Where(a => a.Id == UpdataReceivePersonId && a.ReplyMsg == "444").OrderBy(b => b.ReplyMsg)
            // .Top(10).Select(a => a.ReplyMsg).ToList();
            // var dataor= con.QuerySet<ReceivePerson>().Where(a => a.Id == UpdataReceivePersonId || a.ReplyMsg == "22222").ToList();
            // var data = con.QuerySet<ReceivePerson>().Where(a => a.ReplyMsg != "22222").ToList();
            //var data1 = con.QuerySet<ReceivePerson>().Where(a => a.Num >= 1).ToList();
            //var data2 = con.QuerySet<ReceivePerson>().Where(a => a.Num <= 2).ToList();
            #endregion
            con.Dispose();
        }
    }
}
