namespace WhuGIS.Forms.FormSchoolInfo
{
    public class Presenter
    {
        ISchoolView view;

        public Presenter(ISchoolView v)
        {
            view = v;
        }
    }
}