using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WhuGIS.Forms.FormPhoto;

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
    }
    
}