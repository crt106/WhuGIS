using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WhuGIS.Forms.FormPhoto;
using WhuGIS.Forms.FormSchoolInfo;

namespace WhuGIS.Utils
{
    public static class NetUtils
    {
        /// <summary>
        /// 从服务器获取图片数据 顺便直接返回图片链表
        /// </summary>
        /// <param name="list"></param>
        public static void GetPhotoList(out List<Photo> list)
        {
            string url = "http://120.79.7.230/whuseatsapi/api/winform/getallpics";
            list=new List<Photo>();
            using (HttpClient client = new HttpClient())
            {
                //这里直接同步获取Response了
                //这个傻吊项目基本上不敢异步
                HttpResponseMessage response = client.GetAsync(url).Result;
                string jsonstr = response.Content.ReadAsStringAsync().Result;
                JObject JsonObj=JObject.Parse(jsonstr);
                list = JsonConvert.DeserializeObject<List<Photo>>(JsonObj["data"].ToString());
            }
        }

        /// <summary>
        /// 从服务器获取ofo车辆的位置信息
        /// </summary>
        /// <param name="list"></param>
        public static void GetofoCars(out List<ofoInfo> list)
        {
            string url = "https://san.ofo.so/ofo/Api/nearbyofoCar";
            var list1=new List<ofoInfo>();
            var list2=new List<ofoInfo>();
//            var list1=new List<ofoInfo>();
            using (HttpClient client = new HttpClient())
            {
                //这里分成数次请求

                #region 第一次请求 友谊广场为中心
                var paralist = new List<KeyValuePair<string, string>>();
                paralist.Add(new KeyValuePair<string, string>("token", "96623ad0-a267-11e6-aa90-f922081c344e"));
                paralist.Add(new KeyValuePair<string, string>("lng", "114.361210"));
                paralist.Add(new KeyValuePair<string, string>("lat", "30.5267396"));
                paralist.Add(new KeyValuePair<string, string>("source", "-5"));
                paralist.Add(new KeyValuePair<string, string>("source-version", "11061"));
                FormUrlEncodedContent body = new FormUrlEncodedContent(paralist);
                HttpResponseMessage response = client.PostAsync(url, body).Result;

                string resultstr = response.Content.ReadAsStringAsync().Result;
                JObject resultJObject = JObject.Parse(resultstr);

                //提取出链表
                string jarry = (((resultJObject["values"])["info"])["cars"]).ToString();
                list1 = JsonConvert.DeserializeObject<List<ofoInfo>>(jarry);
                #endregion

                #region 第二次请求 德仁广场为中心
                paralist = new List<KeyValuePair<string, string>>();
                paralist.Add(new KeyValuePair<string, string>("token", "96623ad0-a267-11e6-aa90-f922081c344e"));
                paralist.Add(new KeyValuePair<string, string>("lng", "114.359145"));
                paralist.Add(new KeyValuePair<string, string>("lat", "30.529318"));
                paralist.Add(new KeyValuePair<string, string>("source", "-5"));
                paralist.Add(new KeyValuePair<string, string>("source-version", "11061"));
                body = new FormUrlEncodedContent(paralist);
                response = client.PostAsync(url, body).Result;

                resultstr = response.Content.ReadAsStringAsync().Result;
                resultJObject = JObject.Parse(resultstr);

                //提取出链表
                jarry = (((resultJObject["values"])["info"])["cars"]).ToString();
                list2 = JsonConvert.DeserializeObject<List<ofoInfo>>(jarry);
                
                #endregion
                //合并去重
                list = list1.Union(list2).ToList<ofoInfo>();   
            }
            
        }
    }
    
}