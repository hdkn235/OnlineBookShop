using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using BookShop.Model;
using BookShop.DAL;

namespace BookShop.BLL
{
    public partial class SettingsBLL
    {
        SettingsDAL sd = new SettingsDAL();

        /// <summary>
        /// 根据name 获取值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetValueByName(string name)
        {
            if (HttpRuntime.Cache["setting_" + name] == null)
            {
                Settings s = sd.GetModel(name);
                HttpRuntime.Cache["setting_" + name] = s.Value;
                return s.Value;
            }
            else
            {
                return HttpRuntime.Cache["setting_" + name].ToString();
            }
        }

        public void SetNameValue(string name, string value)
        {
            Settings s = sd.GetModel(name);
            if (s == null)
            {
                s = new Settings();
                s.Name = name;
                s.Value = value;
                dal.Add(s);
            }
            else
            {
                s.Value = value;
                dal.Update(s);
            }
            HttpRuntime.Cache["setting_" + name] = value;
        }
    }
}
