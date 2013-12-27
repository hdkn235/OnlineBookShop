using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using BookShop.Model;
using System.Threading;
using Lucene.Net.Store;
using System.IO;
using Lucene.Net.Index;
using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Documents;

namespace BookShop.Web.Common
{
    public class IndexManage
    {
        public readonly static IndexManage myManage = new IndexManage();
        private Queue<SearchResult> queue = new Queue<SearchResult>();

        private IndexManage() { }

        public void Add(SearchResult sr)
        {
            sr.JobType = JobType.Add;
            queue.Enqueue(sr);
        }

        public void Delete(SearchResult sr)
        {
            sr.JobType = JobType.Delete;
            queue.Enqueue(sr);
        }

        public void Update(SearchResult sr)
        {
            sr.JobType = JobType.Update;
            queue.Enqueue(sr);
        }

        public void Start()
        {
            Thread th = new Thread(OperateContent);
            th.IsBackground = true;
            th.Start();
        }

        private void OperateContent()
        {
            while (true)
            {
                if (queue.Count >0)
                {
                    try
                    {
                        OperateIndex();
                    }
                    catch (Exception ex)
                    {
                        //写日志
                    }
                }
                else
                {
                    Thread.Sleep(3000);
                }
            }
        }

        private void OperateIndex()
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

            while (queue.Count > 0)
            {
                SearchResult model = queue.Dequeue();
                writer.DeleteDocuments(new Term("id", model.Id.ToString()));//删除索引库中原有的项.也可以根据其他项删除文档
                if (model.JobType == JobType.Delete)
                {
                    continue;
                }

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
    }
}