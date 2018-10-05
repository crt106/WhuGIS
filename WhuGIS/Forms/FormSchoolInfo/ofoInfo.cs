namespace WhuGIS.Forms.FormSchoolInfo
{
    /// <summary>
    /// 小黄车位置信息
    /// </summary>
    public struct ofoInfo
    {
        public string carno { get; set; }
        public string ordernum { get; set; }
        public int userIdLast { get; set; }
        public double lng { get; set; }
        public double lat { get; set; }
        public int bicycleType { get; set; }
        public string icon { get; set; }

        public ofoInfo(string carno, string ordernum, int userIdLast, double lng, double lat, int bicycleType, string icon) : this()
        {
            this.carno = carno;
            this.ordernum = ordernum;
            this.userIdLast = userIdLast;
            this.lng = lng;
            this.lat = lat;
            this.bicycleType = bicycleType;
            this.icon = icon;
        }
    }
}