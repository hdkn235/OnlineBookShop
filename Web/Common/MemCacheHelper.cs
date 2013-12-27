using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Memcached.ClientLibrary;
using System.Configuration;

namespace BookShop.Web.Common
{
    /// <summary>
    /// 分布式缓存帮助类
    /// </summary>
    public class MemCacheHelper
    {
        public static readonly MemcachedClient mc;
        static MemCacheHelper()
        {
            //分布Memcached服务IP 端口
            string[] servers = ConfigurationManager.AppSettings["MemcachedServers"].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            //初始化池
            SockIOPool pool = SockIOPool.GetInstance();
            pool.SetServers(servers);
            pool.InitConnections = 3;
            pool.MinConnections = 3;
            pool.MaxConnections = 5;
            pool.SocketConnectTimeout = 1000;
            pool.SocketTimeout = 3000;
            pool.MaintenanceSleep = 30;
            pool.Failover = true;
            pool.Nagle = false;
            pool.Initialize();

            //客户端实例
            mc = new Memcached.ClientLibrary.MemcachedClient();
            mc.EnableCompression = false;
        }

        /// <summary>
        /// 向分布式缓存中插入数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Insert(string key, object value)
        {
            mc.Set(key, value);
            return true;
        }

        /// <summary>
        /// 向分布式缓存中插入数据及过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Insert(string key, object value, DateTime time)
        {
            mc.Set(key, value, time);
            return true;
        }

        /// <summary>
        /// 删除分布式缓存中的数据 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Delete(string key)
        {
            if (mc.KeyExists(key))
            {
                mc.Delete(key);
            }
            return true;
        }

        /// <summary>
        /// 获取分布式缓存中的数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetValue(string key)
        {
            return mc.Get(key);
        }

        /// <summary>
        /// 获取分布式缓存中的数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetValue(string key, DateTime time)
        {
            object obj = GetValue(key);
            if (obj != null)
            {
                mc.Replace(key, obj, time);
            }
            return obj;
        }
    }
}