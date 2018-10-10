using System;
using System.Data;
using System.Windows.Forms;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Geodatabase;
using WeifenLuo.WinFormsUI.Docking;

namespace WhuGIS.Forms.FormClassroomQuery
{
    public partial class FormClassroomQuery : DockContent
    {
        DataTable dt = new DataTable();
        public FormClassroomQuery()
        {
            InitializeComponent();
            LoadDataset();
        }

        private void LoadDataset()
        {
            IWorkspaceFactory pAccessWorkspaceFactory;
            string pFullPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\data\\教室数据\\classroom.mdb";
            pAccessWorkspaceFactory = new AccessWorkspaceFactory(); //using ESRI.ArcGIS.DataSourcesGDB;
            
            //获取工作空间
            IWorkspace pWorkspace = pAccessWorkspaceFactory.OpenFromFile(pFullPath, 0);
            IEnumDataset pEnumDataset = pWorkspace.get_Datasets(ESRI.ArcGIS.Geodatabase.esriDatasetType.esriDTAny);
            pEnumDataset.Reset();
            
            //将Enum数据集中的数据一个个读到DataSet中
            IDataset pDataset = pEnumDataset.Next();

            //使用IQueryDef接口的对象来定义和查询属性信息。通过IWorkspace接口的CreateQueryDef()方法创建该对象。
            IQueryDef queryDef = ((IFeatureWorkspace)pDataset.Workspace).CreateQueryDef();

            //设置所需查询的表格名称为dataset的名称
            queryDef.Tables = pDataset.Name;
            string que = null;
            
            //返回所有值
            queryDef.WhereClause = que;
            //执行查询并返回ICursor接口的对象来访问整个结果的集合
            ICursor cursor = queryDef.Evaluate();

            IRow row = cursor.NextRow();
            dt.Columns.Add(new DataColumn("学部", typeof(string)));//在表中添加int类型的列
            dt.Columns.Add(new DataColumn("教室", typeof(string)));//在表中添加string类型的Name列
            dt.Columns.Add(new DataColumn("教学楼", typeof(string)));//在表中添加string类型的Name列
            dt.Columns.Add(new DataColumn("人数", typeof(string)));//在表中添加string类型的Name列
            dt.Columns.Add(new DataColumn("语音多媒体", typeof(string)));//在表中添加string类型的Name列
            dt.Columns.Add(new DataColumn("周次", typeof(string)));//在表中添加string类型的Name列
            dt.Columns.Add(new DataColumn("日期", typeof(string)));//在表中添加string类型的Name列
            dt.Columns.Add(new DataColumn("1-2", typeof(string)));//在表中添加string类型的Name列
            dt.Columns.Add(new DataColumn("3-4", typeof(string)));//在表中添加string类型的Name列
            dt.Columns.Add(new DataColumn("3-5", typeof(string)));//在表中添加string类型的Name列
            dt.Columns.Add(new DataColumn("6-7", typeof(string)));//在表中添加string类型的Name列
            dt.Columns.Add(new DataColumn("8-9", typeof(string)));//在表中添加string类型的Name列
            dt.Columns.Add(new DataColumn("8-10", typeof(string)));//在表中添加string类型的Name列
            dt.Columns.Add(new DataColumn("11-13", typeof(string)));//在表中添加string类型的Name列
            while (row != null)
            {

                DataRow dr1 = dt.NewRow();
                for (int i = 1; i < 15; i++)
                {
                    dr1[i - 1] = row.get_Value(i).ToString();
                }
                dt.Rows.Add(dr1);
                row = cursor.NextRow();
            }
            dataGridView_classquery1.DataSource = dt;
            dataGridView_classquery2.DataSource = dt;

        }


        private void buttonque1_Click(object sender, EventArgs e)
        {
            try
            {

                string que = null;
                DataTable rentTable = dt;//获取数据源
                this.dataGridView_classquery1.DataSource = null;
                DataTable NewTable = dt.Clone();

                string que1 = "学部" + " = " + comboBox1.Text.ToString();
                string que2 = "教学楼" + " = " + "\'" + comboBox2.Text.ToString() + "\'";
                string que3 = "教室" + " = " + "\'" + comboBox3.Text + "\'";
                que = que1 + " and " + que2 + " and " + que3;
                DataRow[] dr = dt.Select(que);

                if (dr.Length > 0)
                {
                    for (int i = 0; i < dr.Length; i++)
                    {
                        NewTable.ImportRow((DataRow)dr[i]);
                    }
                    dataGridView_classquery1.DataSource = NewTable;
                }
                else
                {
                    MessageBox.Show("教室查询为无");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                MessageBox.Show("查询条件错误");
            }
            
        }

        private void buttonque2_Click(object sender, EventArgs e)
        {
            try
            {
                string que = null;
                DataTable rentTable = dt;//获取数据源
                this.dataGridView_classquery1.DataSource = null;
                DataTable NewTable = dt.Clone();

                string que1 = "学部" + " = " + comboBox5.Text.ToString();
                string que2 = "教学楼" + " = " + "\'" + comboBox4.Text.ToString() + "\'";
                string que3 = "日期" + " = " + "\'" + comboBox6.Text + "\'";
                string que4 = "[" + comboBox7.Text.ToString() + "]" + " = " + "'" + "无" + "'";
                que = que1 + " and " + que2 + " and " + que3 + " and " + que4;
                //que = que1 + " and " + que2 + " and " + que3 ;
                //que = que4;
                DataRow[] dr = dt.Select(que);
                if (dr.Length > 0)
                {
                    for (int i = 0; i < dr.Length; i++)
                    {
                        NewTable.ImportRow((DataRow)dr[i]);
                    }
                    dataGridView_classquery2.DataSource = NewTable;
                }
                else
                {
                    MessageBox.Show("空教室查询为无");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                MessageBox.Show("查询条件错误");
            }
        }


    }


}
