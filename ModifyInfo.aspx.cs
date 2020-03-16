using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ModifyInfo : System.Web.UI.Page
{
    DataRow _datarow = null;
    DataRow pDataRow
    {
        get
        {
            return _datarow;
        }
        set
        {
            _datarow = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// 确定“修改”按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnModify_Click(object sender, EventArgs e)
    {
        this.Panel1.Visible = true;
    }
}