using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lucene.Net.Store;
using Lucene.Net.Index;
using Lucene.Net.Search;
using BookShop.Model;
using Lucene.Net.Documents;
using System.IO;
using BookShop.Web.Common;
using BookShop.BLL;

namespace BookShop.Web.Member
{
    public partial class SearchBooks : System.Web.UI.Page
    {
        protected string txt="请输入搜索内容";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["w"]))
            {
                txt = Request.QueryString["w"];
                SearchContent(txt);
            }
        }

        /// <summary>
        /// 搜索
        /// </summary>
        protected void SearchContent(string kw)
        {
            string indexPath = @"D:\lucenedir";
            kw = kw.ToLower();//默认情况下盘古分词区分大小写，需转换成小写进行搜索
            FSDirectory directory = FSDirectory.Open(new DirectoryInfo(indexPath), new NoLockFactory());
            IndexReader reader = IndexReader.Open(directory, true);
            IndexSearcher searcher = new IndexSearcher(reader);
            //搜索条件
            PhraseQuery queryMsg = new PhraseQuery();
            foreach (string word in Common.WebCommon.PanGuSplit(kw))//先用空格，让用户去分词，空格分隔的就是词“计算机   专业”
            {
                queryMsg.Add(new Term("msg", word));//根据文章内容进行搜索
            }
            //query.Add(new Term("body","语言"));--可以添加查询条件，两者是add关系.顺序没有关系.
            //query.Add(new Term("body", "大学生"));
            queryMsg.SetSlop(100);//多个查询条件的词之间的最大距离.在文章中相隔太远 也就无意义.（例如 “大学生”这个查询条件和"简历"这个查询条件之间如果间隔的词太多也就没有意义了。）

            PhraseQuery queryTitle = new PhraseQuery();
            foreach (string word in Common.WebCommon.PanGuSplit(kw))
            {
                queryTitle.Add(new Term("title", word));
            }
            queryTitle.SetSlop(100);
            BooleanQuery query = new BooleanQuery();
            query.Add(queryMsg, BooleanClause.Occur.SHOULD);
            query.Add(queryTitle, BooleanClause.Occur.SHOULD);

            //TopScoreDocCollector是盛放查询结果的容器
            TopScoreDocCollector collector = TopScoreDocCollector.create(1000, true);
            searcher.Search(query, null, collector);//根据query查询条件进行查询，查询结果放入collector容器
            ScoreDoc[] docs = collector.TopDocs(0, collector.GetTotalHits()).scoreDocs;//得到所有查询结果中的文档,GetTotalHits():表示总条数   TopDocs(300, 20);//表示得到 300（从300开始）到320（结束）的文档内容.可以用来实现分页功能
            List<SearchResult> list = new List<SearchResult>();
            for (int i = 0; i < docs.Length; i++)
            {
                //搜索ScoreDoc[]只能获得文档的id,这样不会把查询结果的Document一次性加载到内存中。降低了内存压力，需要获得文档的详细内容的时候通过searcher.Doc来根据文档id来获得文档的详细内容对象Document.
                int docId = docs[i].doc;//得到查询结果文档的id（Lucene内部分配的id）
                Document doc = searcher.Doc(docId);//找到文档id对应的文档详细信息
                SearchResult result = new SearchResult();
                result.ContentDescription = WebCommon.Highlight(kw,WebCommon.CutString(doc.Get("msg"),150));//分词高亮显示
                result.Title = doc.Get("title");
                result.Id = Convert.ToInt32(doc.Get("id"));
                result.PublishDate = Convert.ToDateTime(doc.Get("PublishDate"));
                result.ISBN = doc.Get("ISBN");
                result.Author = doc.Get("Author");
                result.UnitPrice = Convert.ToDecimal(doc.Get("UnitPrice"));

                list.Add(result);
            }
            this.BookListRepeater.DataSource = list;
            this.BookListRepeater.DataBind();

            AddKeyWord(kw);
        }

        private void AddKeyWord(string keyWord)
        {
            SearchDetails model = new SearchDetails();
            model.KeyWords = keyWord;
            model.DateTime = DateTime.Now;

            SearchDetailsBLL bll = new SearchDetailsBLL();
            bll.Add(model);
        }
    }
}