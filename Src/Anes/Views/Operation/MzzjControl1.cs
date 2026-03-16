using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Views;
using Wis.Anes.ServiceProxies;

namespace Wis.Anes.Views
{
    public partial class MzzjControl1 : BaseView
    {
        public MzzjControl1()
        {
            InitializeComponent();
        }

        private void MzzjControl1_Load(object sender, EventArgs e)
        {
            //BindDrop();
            BindData();
        }

        //private void BindDrop()
        //{
        //    string sql = string.Format(@"select * from WIS_DICT_ANES" );
        //    DataTable dt = CommonProxy.GetDataFromSQLString(sql);
        //    this.comboBox1.DataSource = dt;
        //    comboBox1.DisplayMember = "Anes_Name";
        //    comboBox1.ValueMember = "Anes_Name";
        //}

        private void BindSelect()
        {
            textBox3.Text = "";
        }
        private void BindData()
        {
            string sql = string.Format(@"select * from WIS_DICT_ANES_INPUT_DOCTOR where ITEM_CLASS='麻醉总结' and INPUT_CODE='{0}' order by SERIAL_NO", ExtendApplicationContext.Current.LoginUserContext.UserID);
            DataTable dt = CommonProxy.GetDataFromSQLString(sql);
            gridControl1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql ="";

            string sql1 = string.Format(@"select * from WIS_DICT_ANES_INPUT_DOCTOR where ITEM_CLASS='麻醉总结' and INPUT_CODE='{0}' order by SERIAL_NO", ExtendApplicationContext.Current.LoginUserContext.UserID);
            DataTable dt = CommonProxy.GetDataFromSQLString(sql1);

            int num = dt.Rows.Count + 1;

            if (textBox3.Text.Trim() != "")
            {
                sql = string.Format(@"update WIS_DICT_ANES_INPUT_DOCTOR set ITEM_NAME='{0}',ITEM_CODE='{1}' where SERIAL_NO='{2}' and input_code='{3}' and Item_class='麻醉总结'", textBox1.Text, textBox2.Text, textBox3.Text, ExtendApplicationContext.Current.LoginUserContext.UserID);
            }
            else
            {
                sql = string.Format(@"insert into WIS_DICT_ANES_INPUT_DOCTOR(SERIAL_NO,ITEM_CLASS,ITEM_NAME,ITEM_CODE,INPUT_CODE) values ('{0}','麻醉总结','{1}','{2}','{3}')", num, textBox1.Text, textBox2.Text, ExtendApplicationContext.Current.LoginUserContext.UserID);
            }
            //string sql2 = string.Format(@"select * from WIS_DICT_ANES_INPUT_DOCTOR where ITEM_CLASS='麻醉总结' and INPUT_CODE='{0}' and ITEM_CODE='{1}' order by SERIAL_NO", ExtendApplicationContext.Current.LoginUserContext.UserID, textBox2.Text);
            //DataTable dt2 = CommonProxy.GetDataFromSQLString(sql2);

            //if (dt2.Rows.Count > 0)
            //{
            //    sql = string.Format(@"update WIS_DICT_ANES_INPUT_DOCTOR set ITEM_NAME='{0}',ITEM_CODE='{1}' where SERIAL_NO='{2}' and input_code='{3}' and Item_class='麻醉总结'",  textBox1.Text, textBox2.Text, textBox3.Text, ExtendApplicationContext.Current.LoginUserContext.UserID);
            //}
            //else
            //{
            //    sql = string.Format(@"insert into WIS_DICT_ANES_INPUT_DOCTOR(SERIAL_NO,ITEM_CLASS,ITEM_NAME,ITEM_CODE,INPUT_CODE) values ('{0}','麻醉总结','{1}','{2}','{3}')", num, textBox1.Text, textBox2.Text, ExtendApplicationContext.Current.LoginUserContext.UserID);
                
            //}
            
            int res = CommonProxy.ExecuteNonQuery(sql);
            BindData();
        }


        private void buttonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view =(DevExpress.XtraGrid.Views.Grid.GridView)(gridControl1.MainView);
            int rowhandle = view.FocusedRowHandle;
            DataRow dr = view.GetDataRow(rowhandle);

            textBox2.Text = dr["ITEM_CODE"].ToString();
            textBox1.Text = dr["ITEM_NAME"].ToString();
            textBox3.Text = dr["SERIAL_NO"].ToString();

        }

        private void ButtonDel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (MessageBox.Show("确定要删除吗？", "删除前确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)(gridControl1.MainView);
                int rowhandle = view.FocusedRowHandle;
                DataRow dr = view.GetDataRow(rowhandle);

                string serialno = dr["SERIAL_NO"].ToString();
                string sql = string.Format(@"delete from WIS_DICT_ANES_INPUT_DOCTOR where SERIAL_NO='{0}' and input_code='{1}' and Item_class='麻醉总结'", serialno, ExtendApplicationContext.Current.LoginUserContext.UserID);
                int res = CommonProxy.ExecuteNonQuery(sql);

                BindData();
            }
               
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text ="";
            textBox1.Text ="";
            textBox3.Text ="";
        }

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string sql = string.Format(@"select * from WIS_DICT_ANES_INPUT_DOCTOR where ITEM_CLASS='麻醉总结' and INPUT_CODE='{0}' and ITEM_CODE='{1}' order by SERIAL_NO", ExtendApplicationContext.Current.LoginUserContext.UserID, comboBox1.SelectedValue);
        //    DataTable dt = CommonProxy.GetDataFromSQLString(sql);

        //    string sql1 = string.Format(@"select * from WIS_DICT_ANES_INPUT_DOCTOR where ITEM_CLASS='麻醉总结'  and ITEM_CODE='{0}' order by SERIAL_NO", comboBox1.SelectedValue);
        //    DataTable dt1 = CommonProxy.GetDataFromSQLString(sql1);

        //    if (dt.Rows.Count > 0)
        //    {
        //        textBox1.Text = dt.Rows[0]["ITEM_NAME"].ToString();
        //    }
        //    else
        //    {
        //        textBox1.Text = dt1.Rows[0]["ITEM_NAME"].ToString();
        //    }
        //}
    }
}
