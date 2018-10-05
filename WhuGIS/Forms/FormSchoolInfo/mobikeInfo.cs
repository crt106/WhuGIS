namespace WhuGIS.Forms.FormSchoolInfo
{
    /// <summary>
    /// 摩拜单车数据结构
    /// </summary>
    public struct mobikeInfo
    {
        public string distId{get;set;}
        public double distX { get; set; }
        public double distY { get; set; }
        public int distNum { get; set; }
        public int distance { get; set; }
        public string bikeIds { get; set; }
        public int biketype { get; set; }
        public int type { get; set; }
        public string boundary { get; set; }
        public int operateType { get; set; }
    }
}