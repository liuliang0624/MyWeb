using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections;
using System.Web.Services.Description;

public partial class AddService : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// 保存数据到数据库
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region  方法一：直接使用sql语句插入
        ////数据库的连接字符串
        //string strCon = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\ASPNETDB.MDF;Integrated Security=True;User Instance=True";
        //SqlConnection sqlCon = new SqlConnection(strCon);
        //sqlCon.Open();
        //if (!Checkinsert())
        //    return;
        ////插入数据的SQL语句
        //string strSql = "insert into " +
        //                "ServiceInfo(" +
        //                    "SERVICENAME," +
        //                    "SERVICEURL," +
        //                    "ISDYNAMIC," +
        //                    "PLATFORM," + 
        //                    "CATEGORY," +
        //                    "WMSURL," +
        //                    "WFSURL," +
        //                    "WCSURL," +
        //                    "KMLURL," +
        //                    "SERVICENAILURL," +
        //                    "MEMO) " +
        //                    "values ('" +
        //                    TextBox1.Text + "','" +
        //                    TextBox2.Text + "','" +
        //                    DropDownList1.Text + "','" +
        //                    DropDownList2.Text + "','" +
        //                    DropDownList3.Text + "','" +
        //                    TextBox3.Text + "','" +
        //                    TextBox4.Text + "','" +
        //                    TextBox5.Text + "','" +
        //                    TextBox6.Text + "','" +
        //                    TextBox7.Text + "','" +
        //                    TextBox8.Text + "')";
        ////执行SQL语句
        //SqlCommand sqlCommand = new SqlCommand();
        //sqlCommand.Connection = sqlCon;
        //sqlCommand.CommandText = strSql;
        //sqlCommand.ExecuteNonQuery();

        #endregion

        #region 方法二：先将输入的数据保存到HashTable中，再将HashTable中的值通过SQL语句插入到数据库表中
        ////使用HashTable
        //Hashtable hashTable = new Hashtable();

        //hashTable.Add("SERVICENAME", this.TextBox1.Text.Trim());
        //hashTable.Add("SERVICEURL", this.TextBox2.Text.Trim());
        //hashTable.Add("ISDYNAMIC", this.DropDownList1.Text.Trim());
        //hashTable.Add("PLATFORM", this.DropDownList2.Text.Trim());
        //hashTable.Add("CATEGORY", this.DropDownList3.Text.Trim());
        //hashTable.Add("WMSURL", this.TextBox3.Text.Trim());
        //hashTable.Add("WFSURL", this.TextBox4.Text.Trim());
        //hashTable.Add("WCSURL", this.TextBox5.Text.Trim());
        //hashTable.Add("KMLURL", this.TextBox6.Text.Trim());
        //hashTable.Add("SERVICENAILURL", this.TextBox7.Text.Trim());
        //hashTable.Add("MEMO", this.TextBox8.Text.Trim());

        //if (Checkinsert())
        //{
            //string tableName = "ServiceInfo";
            //Insert(tableName, hashTable);
        //}
       

        #endregion

        #region  方法三：利用实体模型
        //数据库的连接字符串
        string strCon = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\ASPNETDB.MDF;Integrated Security=True;User Instance=True";
        SqlConnection sqlCon = new SqlConnection(strCon);
        sqlCon.Open();

        ServiceInfo obj = new ServiceInfo();

        obj.ServiceName = this.TextBox1.Text.Trim().ToString();
        obj.ServiceUrl = this.TextBox2.Text.Trim().ToString();
        obj.IsDynamic = this.DropDownList1.Text.Trim().ToString();
        obj.ServiceNailUrl = this.DropDownList2.Text.Trim().ToString();
        obj.PlatForm = this.DropDownList3.Text.Trim().ToString();
        obj.CateGorp = this.TextBox3.Text.Trim().ToString();
        obj.WmsUrl = this.TextBox4.Text.Trim().ToString();
        obj.Wfsurl = this.TextBox5.Text.Trim().ToString();
        obj.WcsUrl = this.TextBox6.Text.Trim().ToString();
        obj.Kmlurl = this.TextBox7.Text.Trim().ToString();
        obj.Memo = this.TextBox8.Text.Trim().ToString();

        //检查必填信息项
        if (!Checkinsert())
            return;
        //构建插入数据的SQL语句
        string strSql = "insert into " +
                        "ServiceInfo(" +
                            "SERVICENAME," +
                            "SERVICEURL," +
                            "ISDYNAMIC," +
                            "PLATFORM," +
                            "CATEGORY," +
                            "WMSURL," +
                            "WFSURL," +
                            "WCSURL," +
                            "KMLURL," +
                            "SERVICENAILURL," +
                            "MEMO) " +
                        "values ('" +
                            obj.ServiceName + "','" +
                            obj.ServiceUrl + "','" +
                            obj.IsDynamic + "','" +
                            obj.PlatForm + "','" +
                            obj.CateGorp + "','" +
                            obj.WmsUrl + "','" +
                            obj.Wfsurl + "','" +
                            obj.WcsUrl + "','" +
                            obj.Kmlurl + "','" +
                            obj.ServiceNailUrl + "','" +
                            obj.Memo + "')";

        //执行SQL语句
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlCon;
        sqlCommand.CommandText = strSql;
        sqlCommand.ExecuteNonQuery();
        
        #endregion
    }
    /// <summary>
    /// 插入数据
    /// </summary>
    /// <param name="tableName"></param>
    /// <param name="hashTable"></param>
    private void Insert(string tableName, Hashtable hashTable)
    {
        //数据库的连接字符串
        string strCon = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\ASPNETDB.MDF;Integrated Security=True;User Instance=True";
        SqlConnection sqlCon = new SqlConnection(strCon);
        sqlCon.Open();

        //构建Sql语句
        string strField = "(";
        string strValue = "Values(";

        int count = 0;
        foreach(DictionaryEntry item in hashTable)
        {
            if (count != 0)
            {
                strField += ",";
                strValue += ",";
            }
            strField += item.Key.ToString();
            strValue += "'" + item.Value.ToString() + "'";
            count++;
        }

        strField += ")";
        strValue += ")";
        
        //最终sql语句
        string sqlString = "Insert into " + tableName + strField + strValue;

        try
        {
            //执行插入
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlCon;
            sqlCommand.CommandText = sqlString;
            sqlCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        { 
        
        }
            

    }
    /// <summary>
    /// 检查输入数据（必填信息）
    /// </summary>
    private bool Checkinsert()
    {
        if (this.TextBox1.Text.Trim().ToString() == "" || this.TextBox1.Text.Trim().ToString() == null)
        {
            this.Label12.Text = "“服务名称”为必填项！";
            return false;
        }
        else
        {
            this.Label12.Text = " ";
        }
        if (this.TextBox2.Text.Trim().ToString() == "" || this.TextBox2.Text.Trim().ToString() == null)
        {
            this.Label13.Text = "“服务URL”为必填项！";
            return false;
        }
        else
        {
            this.Label13.Text = " ";
        }
        if (this.DropDownList1.Text.Trim().ToString() == "" || this.DropDownList1.Text.Trim().ToString() == null)
        {
            this.DropDownList1.Text = "“动态地图”为必填项！";
            return false;
        }
        else
        {
            this.DropDownList1.Text = " ";
        }
        if (this.DropDownList2.Text.Trim().ToString() == "" || this.DropDownList2.Text.Trim().ToString() == null)
        {
            this.DropDownList2.Text = "“服务平台”为必填项！";
            return false;
        }
        else
        {
            this.DropDownList2.Text = " ";
        }
        if (this.DropDownList3.Text.Trim().ToString() == "" || this.DropDownList3.Text.Trim().ToString() == null)
        {
            this.DropDownList3.Text = "“分类”为必填项！";
            return false;
        }
        else
        {
            this.DropDownList3.Text = " ";
        }

        return true;
    }
}