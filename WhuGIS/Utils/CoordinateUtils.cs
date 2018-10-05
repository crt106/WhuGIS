using System;

namespace WhuGIS.Utils
{
    /// <summary>
    /// 坐标转换类
    /// </summary>
    public class CoordinateUtils
    {
        public static double pi = 3.1415926535897932384626;
        public static double a = 6378245.0;
        public static double ee = 0.00669342162296594323;

        public static LocateInfo wgs84_To_Gcj02(double lat, double lon)
        {
            LocateInfo info = new LocateInfo();
            if (outOfChina(lat, lon))
            {
                info.isChina = false;
                info.latitude = lat;
                info.longtitude = lon;
            }
            else
            {
                double dLat = transformLat(lon - 105.0, lat - 35.0);
                double dLon = transformLon(lon - 105.0, lat - 35.0);
                double radLat = lat / 180.0 * pi;
                double magic = Math.Sin(radLat);
                magic = 1 - ee * magic * magic;
                double sqrtMagic = Math.Sqrt(magic);
                dLat = (dLat * 180.0) / ((a * (1 - ee)) / (magic * sqrtMagic) * pi);
                dLon = (dLon * 180.0) / (a / sqrtMagic * Math.Cos(radLat) * pi);
                double mgLat = lat + dLat;
                double mgLon = lon + dLon;
                info.isChina = true;
                info.latitude = mgLat;
                info.longtitude = mgLon;
            }

            return info;
        }

        public static LocateInfo gcj02_To_Wgs84(double lat, double lon)
        {
            LocateInfo info = new LocateInfo();
            LocateInfo gps = transform(lat, lon);
            double lontitude = lon * 2 - gps.longtitude;
            double latitude = lat * 2 - gps.latitude;
            info.isChina = gps.isChina;
            info.latitude = latitude;
            info.longtitude = lontitude;
            return info;
        }

        private static Boolean outOfChina(double lat, double lon)
        {
            if (lon < 72.004 || lon > 137.8347)
                return true;
            if (lat < 0.8293 || lat > 55.8271)
                return true;
            return false;
        }

        private static double transformLat(double x, double y)
        {
            double ret = -100.0 + 2.0 * x + 3.0 * y + 0.2 * y * y + 0.1 * x * y
                         + 0.2 * Math.Sqrt(Math.Abs(x));
            ret += (20.0 * Math.Sin(6.0 * x * pi) + 20.0 * Math.Sin(2.0 * x * pi)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(y * pi) + 40.0 * Math.Sin(y / 3.0 * pi)) * 2.0 / 3.0;
            ret += (160.0 * Math.Sin(y / 12.0 * pi) + 320 * Math.Sin(y * pi / 30.0)) * 2.0 / 3.0;
            return ret;
        }

        private static double transformLon(double x, double y)
        {
            double ret = 300.0 + x + 2.0 * y + 0.1 * x * x + 0.1 * x * y + 0.1
                         * Math.Sqrt(Math.Abs(x));
            ret += (20.0 * Math.Sin(6.0 * x * pi) + 20.0 * Math.Sin(2.0 * x * pi)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(x * pi) + 40.0 * Math.Sin(x / 3.0 * pi)) * 2.0 / 3.0;
            ret += (150.0 * Math.Sin(x / 12.0 * pi) + 300.0 * Math.Sin(x / 30.0 * pi)) * 2.0 / 3.0;
            return ret;
        }

        private static LocateInfo transform(double lat, double lon)
        {
            LocateInfo info = new LocateInfo();
            if (outOfChina(lat, lon))
            {
                info.isChina = false;
                info.latitude = lat;
                info.longtitude = lon;
                return info;
            }

            double dLat = transformLat(lon - 105.0, lat - 35.0);
            double dLon = transformLon(lon - 105.0, lat - 35.0);
            double radLat = lat / 180.0 * pi;
            double magic = Math.Sin(radLat);
            magic = 1 - ee * magic * magic;
            double sqrtMagic = Math.Sqrt(magic);
            dLat = (dLat * 180.0) / ((a * (1 - ee)) / (magic * sqrtMagic) * pi);
            dLon = (dLon * 180.0) / (a / sqrtMagic * Math.Cos(radLat) * pi);
            double mgLat = lat + dLat;
            double mgLon = lon + dLon;
            info.isChina = true;
            info.latitude = mgLat;
            info.longtitude = mgLon;
            return info;
        }


        /// <summary>
        /// 定位的基本信息
        /// </summary>
        public class LocateInfo
        {
            public double longtitude { get; set; }
            public double latitude { get; set; }
            public bool isChina { get; set; }

            public LocateInfo()
            {
            }

            public LocateInfo(double longtitude, double latitude)
            {
                this.longtitude = longtitude;
                this.latitude = latitude;
            }
        }
    }

}