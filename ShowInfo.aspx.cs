using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class ShowInfo : System.Web.UI.Page
{
    #region 变量
    //表名
    public string strTableName = "ServiceInfo";
    DataRow dataRow = null;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        ////进入页面便显示所有的表中数据
        //string strSql = "select * from ServiceInfo";
        //Selecte(strSql);
        
    }
    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        this.Label2.Text = "";
        string strValue = this.TextBox1.Text.Trim().ToString();
        if (IsNull(strValue))
        {
            string strSql = "select * from ServiceInfo where SERVICENAME='" + strValue + "'";
            Selecte(strSql);
        }
        else
        {
            this.Label2.Text = "查询条件不能为空";
        }
    }
    /// <summary>
    /// 判断输入值是否为空
    /// </summary>
    /// <param name="strValue"></param>
    /// <returns></returns>
    private bool IsNull(string strValue)
    {
        if (strValue == null || strValue == "")
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        #region 方法一：通过所以先删除改行，再将删除后的表绑定到GridView.

        //数据库连接字符串
        string strCon = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\ASPNETDB.MDF;Integrated Security=True;User Instance=True";
        SqlConnection sqlCon = new SqlConnection(strCon);
        sqlCon.Open();
        //清空Label2提示信息
        this.Label2.Text = "";
        //索引
        int intID = this.GridView1.SelectedIndex;
        string strSql = "select * from ServiceInfo";

        if (intID >= 0)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(strSql, strCon);
            //新建一个命令执行器(必须要有，否则会报错)
            //ERROR:当传递具有已删除行的 DataRow 集合时，更新要求有效的 DeleteCommand”
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);

            da.Fill(ds, "ServiceInfo");
            DataTable dt = ds.Tables["ServiceInfo"];
            //选中的行，删除
            DataRow dr = dt.Rows[intID];
            dr.Delete();
            //更新数据集
            da.Update(ds, "ServiceInfo");
            //删除数据更新以后的表
            DataTable dt1 = ds.Tables["ServiceInfo"];
            this.GridView1.DataSource = dt1.DefaultView;
            this.GridView1.DataBind();
            sqlCon.Close();
            this.Label2.Text = "删除成功！";
        }
        else
        {
            this.Label2.Text = "请选择要删除的行！";
        }
        #endregion

        #region 方法二：直接通过SQL语句删除
        //string strCon = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\ASPNETDB.MDF;Integrated Security=True;User Instance=True";
        //SqlConnection sqlCon = new SqlConnection(strCon);
        //sqlCon.Open();

        //string strSql = "select * from ServiceInfo";
        //int intID = this.GridView1.SelectedIndex;

        //DataSet ds = new DataSet();
        //SqlDataAdapter da = new SqlDataAdapter(strSql, strCon);
        //SqlCommandBuilder cmd = new SqlCommandBuilder(da);
        //da.Fill(ds, "ServiceInfo");
        //DataTable dt = ds.Tables["ServiceInfo"];
        //DataRow dr = dt.Rows[intID];
        ////获取所选行的"服务名"
        //string strValue = dr["SERVICENAME"].ToString();
        ////删除的sql语句
        //strSql = "delete from ServiceInfo where SERVICENAME='" + strValue + "'";
        ////执行
        //SqlCommand sqlCmd = new SqlCommand();
        //sqlCmd.Connection = sqlCon;
        //sqlCmd.CommandText = strSql;
        //sqlCmd.ExecuteNonQuery();
        ////重新绑定
        //da.Update(ds, "ServiceInfo");
        //DataTable dt1 = ds.Tables["ServiceInfo"];
        //this.GridView1.DataSource = dt1.DefaultView;
        //this.GridView1.DataBind();

        #endregion

    }
    /// <summary>
    /// 显示全部数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        this.GridView1.Visible = true;
        this.Panel1.Visible = false;

        string strSql = "select * from ServiceInfo";
        Selecte(strSql);
    }
    /// <summary>
    /// 选择
    /// </summary>
    /// <param name="strSql"></param>
    private void Selecte(string strSql)
    {
        string strCon = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\ASPNETDB.MDF;Integrated Security=True;User Instance=True";
        SqlConnection sqlCon = new SqlConnection(strCon);
        sqlCon.Open();

        this.Label2.Text = "";

        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(strSql, strCon);
        //da.Fill(ds);
        da.Fill(ds, "ServiceInfo");
        DataTable dt = ds.Tables["ServiceInfo"];

        if (dt.Rows.Count == 0)
        {
            this.Label2.Text = "无查询结果值！";
            this.GridView1.Visible = false;
            return;
        }

        //绑定数据源
        this.GridView1.Visible = true;
        GridView1.DataSource = dt.DefaultView;
        GridView1.DataBind();
        sqlCon.Close();
    }

    /// <summary>
    /// 弹出修改信息界面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ShowA(object sender, EventArgs e)
    {
        #region 弹出对话框页面
        //string  str="<script type=\"text/javascript\" language=\"javascript\">";
        //        str += "window.showModalDialog(\"ModifyInfo.aspx\", \"dialogWidth=500px;dialogHeight=300px\");";
        //        str+="</script>";

        //Response.Write(str);
        //Response.End();
   

        //GetValue();

        ////弹出一个页面，前一个页面不关闭
        //this.Response.Write("<script language=javascript>window.open('ModifyInfo.aspx','newwindow')</script>");
        #endregion

        this.GridView1.Visible = false;
        this.Panel1.Visible = true;

        int intID = this.GridView1.SelectedIndex;
        if (intID < 0)
        {
            this.Label2.Text = "请选择要编辑的行";
        }

        string strCon = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\ASPNETDB.MDF;Integrated Security=True;User Instance=True";
        SqlConnection sqlCon = new SqlConnection(strCon);
        sqlCon.Open();
        string Sql = "select * from ServiceInfo";

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter(Sql, strCon);
        SqlCommandBuilder cmd = new SqlCommandBuilder(da);

        da.Fill(ds, "ServiceInfo");
        DataTable dt = ds.Tables["ServiceInfo"];
        //选中的该行
        DataRow dr = dt.Rows[intID];

        this.TextBox2.Text = dr.ItemArray[1].ToString();
        this.TextBox3.Text = dr.ItemArray[2].ToString();
        this.DropDownList1.Text = dr.ItemArray[3].ToString();
        //this.DropDownList2.Text = dr.ItemArray[4].ToString();
        //this.DropDownList3.Text = dr.ItemArray[10].ToString();
        this.TextBox4.Text = dr.ItemArray[6].ToString();
        this.TextBox5.Text = dr.ItemArray[7].ToString();
        this.TextBox6.Text = dr.ItemArray[8].ToString();
        this.TextBox7.Text = dr.ItemArray[9].ToString();
        this.TextBox8.Text = dr.ItemArray[5].ToString();
        this.TextBox9.Text = dr.ItemArray[11].ToString();
    }
    /// <summary>
    /// 获取要编辑行的值，存入一个table中
    /// </summary>
    private void GetValue()
    {
        string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Persist Security Info=True;Data Source = " + System.Web.HttpContext.Current.Server.MapPath("./App_Data/登录信息.mdb");
        string Sql = "select * from Infor";
        SqlConnection con = new SqlConnection(connectString);
        con.Open();

        int selectid = this.GridView1.SelectedIndex;
        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter(Sql, connectString);
        SqlCommandBuilder cmd = new SqlCommandBuilder(da);              //新建命令执行器

        da.Fill(ds, "Infor");
        DataTable dt = ds.Tables["Infor"];
        DataRow dr = dt.Rows[selectid];
        dataRow = dr;
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        #region  利用实体模型
        //数据库的连接字符串
        string strCon = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\ASPNETDB.MDF;Integrated Security=True;User Instance=True";
        SqlConnection sqlCon = new SqlConnection(strCon);
        sqlCon.Open();

        int intID = this.GridView1.SelectedIndex;
        string Sql = "select * from ServiceInfo";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(Sql, strCon);
        SqlCommandBuilder cmd = new SqlCommandBuilder(da);
        da.Fill(ds, "ServiceInfo");
        DataTable dt = ds.Tables["ServiceInfo"];
        //选中的该行
        DataRow dr = dt.Rows[intID];
        string strID = dr.ItemArray[0].ToString();

        ServiceInfo obj = new ServiceInfo();

        obj.ServiceName = this.TextBox2.Text.Trim().ToString();
        obj.ServiceUrl = this.TextBox3.Text.Trim().ToString();
        obj.IsDynamic = this.DropDownList1.Text.Trim().ToString();
        obj.PlatForm = this.DropDownList2.Text.Trim().ToString();
        obj.CateGorp = this.DropDownList3.Text.Trim().ToString(); 
        obj.WmsUrl = this.TextBox4.Text.Trim().ToString();
        obj.Wfsurl = this.TextBox5.Text.Trim().ToString();
        obj.WcsUrl = this.TextBox6.Text.Trim().ToString();
        obj.Kmlurl = this.TextBox7.Text.Trim().ToString();
        obj.ServiceNailUrl = this.TextBox8.Text.Trim().ToString();
        obj.Memo = this.TextBox9.Text.Trim().ToString();

        //检查必填信息项
        if (!Checkinsert())
            return;
        //构建插入数据的SQL语句
        string strSql = "update ServiceInfo set SERVICENAME='" + obj.ServiceName + "',SERVICEURL='" + obj.ServiceUrl + "',ISDYNAMIC='" + obj.IsDynamic + "',PLATFORM='" + obj.PlatForm + "',CATEGORY='" + obj.CateGorp + "',WMSURL='" + obj.WmsUrl + "',WFSURL='" + obj.Wfsurl + "',WCSURL='" + obj.WcsUrl + "',KMLURL='" + obj.Kmlurl + "',SERVICENAILURL='" + obj.ServiceNailUrl + "',MEMO='";
        strSql += obj.Memo + "'" + "where ID= '" + strID + "'";
        //执行SQL语句
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlCon;
        sqlCommand.CommandText = strSql;
        sqlCommand.ExecuteNonQuery();

        #endregion
    }

    /// <summary>
    /// 检查输入数据（必填信息）
    /// </summary>
    private bool Checkinsert()
    {
        if (this.TextBox2.Text.Trim().ToString() == "" || this.TextBox2.Text.Trim().ToString() == null)
        {
            this.Label12.Text = "“服务名称”为必填项！";
            return false;
        }
        else
        {
            this.Label12.Text = " ";
        }
        if (this.TextBox3.Text.Trim().ToString() == "" || this.TextBox3.Text.Trim().ToString() == null)
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
            this.Label14.Text = "“动态地图”为必填项！";
            return false;
        }
        else
        {
            this.DropDownList1.Text = " ";
        }
        return true;
    }
 
}