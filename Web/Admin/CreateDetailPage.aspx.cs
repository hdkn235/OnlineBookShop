using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;
using BookShop.Model;
using Lucene.Net.Store;
using Lucene.Net.Index;
using System.IO;
using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Documents;

namespace BookShop.Web.Admin
{
    public partial class CreateDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                BooksBLL bb = new BooksBLL();
                List<Books> list = bb.GetModelList("");
                foreach (Books b in list)
                {
                    bb.CreateSaticHtml(b.Id);
                }
            }
        }

        protected void btnCreateIndex_Click(object sender, EventArgs e)
        {
            CreateContent();
        }

        /// <summary>
        /// 创建索引，将数据库中的数据取出来给Lucene索引库
        /// </summary>
        protected void CreateContent()
        {
            string indexPath = @"D:\lucenedir";//注意和磁盘上文件夹的大小写一致，否则会报错。将创建的分词内容放在该目录下。
            FSDirectory directory = FSDirectory.Open(new DirectoryInfo(indexPath), new NativeFSLockFactory());//指定索引文件(打开索引目录) FS指的是就是FileSystem
            bool isUpdate = IndexReader.IndexExists(directory);//IndexReader:对索引进行读取的类。该语句的作用：判断索引库文件夹是否存在以及索引特征文件是否存在。
            if (isUpdate)
            {
                //同时只能有一段代码对索引库进行写操作。当使用IndexWriter打开directory时会自动对索引库文件上锁。
                //如果索引目录被锁定（比如索引过程中程序异常退出），则首先解锁（提示一下：如果我现在正在写着已经加锁了，但是还没有写完，这时候又来一个请求，那么不就解锁了吗？这个问题后面会解决）
                if (IndexWriter.IsLocked(directory))
                {
                    IndexWriter.Unlock(directory);
                }
            }
            IndexWriter writer = new IndexWriter(directory, new PanGuAnalyzer(), !isUpdate, Lucene.Net.Index.IndexWriter.MaxFieldLength.UNLIMITED);//向索引库中写索引。这时在这里加锁,使用盘古算法
            BLL.BooksBLL bll = new BLL.BooksBLL();
            List<Model.Books> list = bll.GetModelList("");
            foreach (Model.Books model in list)
            {
                writer.DeleteDocuments(new Term("id", model.Id.ToString()));//删除索引库中原有的项.也可以根据其他项删除文档

                Document document = new Document();//表示一篇文档。
                document.Add(new Field("id", model.Id.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                //Field.Store.YES:表示是否存储原值。只有当Field.Store.YES在后面才能用doc.Get("number")取出值来.
                //Field.Index.NOT_ANALYZED:不进行分词保存
                //Field.Index.ANALYZED:进行分词保存:也就是要进行全文的字段要设置分词 保存（因为要进行模糊查询）
                //Lucene.Net.Documents.Field.TermVector.WITH_POSITIONS_OFFSETS:不仅保存分词还保存分词的距离。
                document.Add(new Field("title", model.Title, Field.Store.YES, Field.Index.ANALYZED, Lucene.Net.Documents.Field.TermVector.WITH_POSITIONS_OFFSETS));
                document.Add(new Field("msg", model.ContentDescription, Field.Store.YES, Field.Index.ANALYZED, Lucene.Net.Documents.Field.TermVector.WITH_POSITIONS_OFFSETS));
                document.Add(new Field("PublishDate", model.PublishDate.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                document.Add(new Field("ISBN", model.ISBN, Field.Store.YES, Field.Index.NOT_ANALYZED));
                document.Add(new Field("Author", model.Author, Field.Store.YES, Field.Index.NOT_ANALYZED));
                document.Add(new Field("UnitPrice", model.UnitPrice.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                writer.AddDocument(document);
            }

            writer.Close();//会自动解锁。
            directory.Close();//不要忘了Close，否则索引结果搜不到
        }

        protected void btnAddBook_Click(object sender, EventArgs e)
        {
            Model.Books model = new Model.Books();
            model.AurhorDescription = "jlkfdjf";
            model.Author = "王承伟";
            model.CategoryId = 1;
            model.Clicks = 1;
            model.ContentDescription = "老王是大好人！老王是大好人！老王是大好人！老王是大好人！老王是大好人！";
            model.EditorComment = "adfsadfsadf";
            model.ISBN = "123452222222355553003333266222";
            model.PublishDate = DateTime.Now;
            model.PublisherId = 72;
            model.Title = "老王是大好人";
            model.TOC = "aaaaaaaaaaaaaaaa";
            model.UnitPrice = 22.3m;
            model.WordsCount = 1234;
            BLL.BooksBLL bll = new BLL.BooksBLL();
            int id = bll.Add(model);

            SearchResult result = new SearchResult();
            result.Id = id;
            result.ISBN = model.ISBN;
            result.PublishDate = model.PublishDate;
            result.Title = model.Title;
            result.UnitPrice = model.UnitPrice;
            result.ContentDescription = model.ContentDescription;
            result.Author = model.Author;
            Common.IndexManage.myManage.Add(result);
        }
    }
}