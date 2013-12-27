using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using BookShop.BLL;

namespace BookShop.Web.Common
{
    public class IndexJob:IJob
    {
        #region IJob 成员

        public void Execute(JobExecutionContext context)
        {
            KeyWordsRankBLL bll = new KeyWordsRankBLL();
            bll.DeleteAll();
            bll.AddBySearchDetails();
        }

        #endregion
    }
}