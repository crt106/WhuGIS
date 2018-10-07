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
            try
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                list = null;
            }
        }

        /// <summary>
        /// 从服务器获取ofo车辆的位置信息
        /// </summary>
        /// <param name="list"></param>
        public static void GetofoCars(out List<ofoInfo> list)
        {
            try
            {
                string url = "https://san.ofo.so/ofo/Api/nearbyofoCar";
                var list1=new List<ofoInfo>();
                var list2=new List<ofoInfo>();
                using (HttpClient client = new HttpClient())
                {
                    //这里分成两次请求 因为ofo能获取到的范围还是比较广的
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                list = null;
            }
            
        }


        /// <summary>
        /// 从服务器获取mobike车辆的位置信息 由于mobike单次请求返回较少 故多次请求
        /// </summary>
        /// <param name="list"></param>
        public static void GetmobikeCars(out List<mobikeInfo> list)
        {
            try
            {
                string url = "https://mwx.mobike.com/nearby/nearbyBikeInfo";
                Tuple<double, double>[] CoorDinateArray =
                {
                    new Tuple<double, double>(30.525601,114.361083), 
                    new Tuple<double, double>(30.527962,114.360895), 
                    new Tuple<double, double>(30.530642,114.360938), 
                    new Tuple<double, double>(30.531123,114.358513), 
                    new Tuple<double, double>(30.528868,114.357655), 
                    new Tuple<double, double>(30.526520,114.356947), 
                    new Tuple<double, double>(30.529570,114.362912), 
                };
                list = new List<mobikeInfo>();
                
                using (HttpClient client = new HttpClient())
                {
                    for (int i = 0; i < CoorDinateArray.Length; i++)
                    {
                        var paralist = new List<KeyValuePair<string, string>>();
                        paralist.Add(new KeyValuePair<string, string>("biketype", "0"));
                        paralist.Add(new KeyValuePair<string, string>("latitude", CoorDinateArray[i].Item1.ToString()));
                        paralist.Add(new KeyValuePair<string, string>("errMsg", "getMapCenterLocation:ok"));
                        paralist.Add(new KeyValuePair<string, string>("longitude", CoorDinateArray[i].Item2.ToString()));
                        paralist.Add(new KeyValuePair<string, string>("citycode", "027"));
                       
                        FormUrlEncodedContent body = new FormUrlEncodedContent(paralist);
                        HttpResponseMessage response = client.PostAsync(url, body).Result;
                        string resultstr = response.Content.ReadAsStringAsync().Result;
                        JObject resultJObject = JObject.Parse(resultstr);
                        string jarry = resultJObject["object"].ToString();
                        var tmplist = JsonConvert.DeserializeObject<List<mobikeInfo>>(jarry);

                        //合并链表
                        list = list.Union(tmplist).ToList<mobikeInfo>();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                list = null;
            }
        }
    }
    
}