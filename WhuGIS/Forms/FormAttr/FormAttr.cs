﻿using System;
using System.Data;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using WeifenLuo.WinFormsUI.Docking;

namespace WhuGIS.Forms.FormAttr
{
    public partial class FormAttr : DockContent
    {
        public FormAttr(IFeatureLayer layer)
        {
            InitializeComponent();
            CurFeatureLayer = layer;
            
        }


        //要查询的属性图层
        private IFeatureLayer _curFeatureLayer;

        public IFeatureLayer CurFeatureLayer
        {
            get { return _curFeatureLayer; }
            set { _curFeatureLayer = value; }
        }


        public void InitUI()
        {
            if (_curFeatureLayer == null) return;

            IFeature pFeature = null;
            DataTable pFeatDT = new DataTable(); //创建数据表
            DataRow pDataRow = null; //数据表行变量
            DataColumn pDataCol = null; //数据表列变量
            IField pField = null;

            for (int i = 0; i < _curFeatureLayer.FeatureClass.Fields.FieldCount; i++)
            {
                pDataCol = new DataColumn();
                pField = _curFeatureLayer.FeatureClass.Fields.get_Field(i);
                pDataCol.ColumnName = pField.AliasName; //获取字段名作为列标题
                pDataCol.DataType = Type.GetType("System.Object");//定义列字段类型
                pFeatDT.Columns.Add(pDataCol); //在数据表中添加字段信息
            }

            IFeatureCursor pFeatureCursor = _curFeatureLayer.Search(null, true);
            pFeature = pFeatureCursor.NextFeature();
            while (pFeature != null)
            {
                pDataRow = pFeatDT.NewRow();
                //获取字段属性
                for (int k = 0; k < pFeatDT.Columns.Count; k++)
                {
                    pDataRow[k] = pFeature.get_Value(k);
                }
                
                pFeatDT.Rows.Add(pDataRow); //在数据表中添加字段属性信息
                pFeature = pFeatureCursor.NextFeature();
            }
            //释放指针
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pFeatureCursor);

            
            dataGridAttribute.DataSource = pFeatDT;
            dataGridAttribute.Invalidate();          
        }

        private void FormAtrribute_Load(object sender, EventArgs e)
        {
            InitUI();
        }
    }
}
