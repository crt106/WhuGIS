namespace WhuGIS.Forms.FormPhoto
{
    /// <summary>
    ///     存储要下发的照片信息
    /// </summary>
    public struct Photo
    {
        public string name { get; set; }
        public double latitude { get; set; }
        public double longtitude { get; set; }
        public string osspath { get; set; }

        public Photo(string name, double latitude, double longtitude, string osspath) : this()
        {
            this.name = name;
            this.latitude = latitude;
            this.longtitude = longtitude;
            this.osspath = osspath;
        }
    }
}