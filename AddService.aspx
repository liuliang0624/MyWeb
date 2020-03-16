<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddService.aspx.cs" Inherits="AddService" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加地图服务</title>
    <link href="Styles/PublicCss.css" rel="Stylesheet" type="text/css"/>
    <style type="text/css">
        .style1
        {
            color: #008ad3;
            font-size: 13px;
            text-align: left;
            padding: 0;
            height: 30px;
            background: url('../Images/Background/list_headbg1.png') repeat-x 0 0;
            width: 734px;
        }
        .style2
        {
            width: 1500px;
        }
       .style5
       {
            width:1500px;
            height:30px;
            color: #008ad3;
            background: url('../Images/Background/list_headbg1.png') repeat-x 0 0;
       }
        .style6
        {
            width: 734px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="tableInfo" style="width: 800px;">
            <tr>
                <td class="style6">
                    <th class="style5"><span class="span_Title">服务信息添加</span></th>
                </td>
            </tr>
            <tr>
                <td class="style1" align="right" >
                     <asp:Label ID="Label1" runat="server" Text="服务名称："></asp:Label>
                </td>
                <td class="style2" align="left">
                    <asp:TextBox ID="TextBox1" runat="server" Width="170px"></asp:TextBox><span class="IsNeedSignal">&nbsp*</span>
                    <asp:Label ID="Label12" runat="server" Text=" "></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1" align="right">
                    <asp:Label ID="Label2" runat="server" Text="服务的URL："></asp:Label>
                </td>
                <td class="style2" align="left"> 
                    <asp:TextBox ID="TextBox2" runat="server" Width="400px"></asp:TextBox><span class="IsNeedSignal">&nbsp*</span>
                    <asp:Label ID="Label13" runat="server" Text=" "></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1" align="right">
                    <asp:Label ID="Label3" runat="server" Text="动态地图："></asp:Label>
                </td>
                <td align="left" class="style2">
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="90px">
                       <%-- <asp:ListItem Value="-请选择-" Text="-请选择-"></asp:ListItem>--%>
                        <asp:ListItem Value="是" Text="是"></asp:ListItem>
                        <asp:ListItem Value="否" Text="否"></asp:ListItem>
                    </asp:DropDownList>
                    <span class="IsNeedSignal">&nbsp*</span>
                    <asp:Label ID="Label14" runat="server" Text=" "></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1" align="right">
                    <asp:Label ID="Label4" runat="server" Text="服务平台："></asp:Label>
                </td>
                <td align="left" class="style2">
                    <asp:DropDownList ID="DropDownList2" runat="server">
                       <%-- <asp:ListItem Value="-请选择-" Text="-请选择-"></asp:ListItem>--%>
                        <asp:ListItem Value="ArcGIS Server" Text="ArcGIS Server"></asp:ListItem>
                        <asp:ListItem Value="ArcIMS Serveer" Text="ArcIMS Serveer"></asp:ListItem>
                    </asp:DropDownList>
                    <span class="IsNeedSignal">&nbsp*</span>
                    <asp:Label ID="Label15" runat="server" Text=" "></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1" align="right">
                    <asp:Label ID="Label5" runat="server" Text="分类："></asp:Label>
                </td>
                <td align="left" class="style2">
                    <asp:DropDownList ID="DropDownList3" runat="server" Width="90px">
                        <%--<asp:ListItem Value="-请选择-" Text="-请选择-"></asp:ListItem>--%>
                        <asp:ListItem Value="地形图" Text="地形图"></asp:ListItem>
                        <asp:ListItem Value="给水" Text="给水"></asp:ListItem>
                    </asp:DropDownList>
                    <span class="IsNeedSignal">&nbsp*</span>
                    <asp:Label ID="Label16" runat="server" Text=" "></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1" align="right">
                    <asp:Label ID="Label6" runat="server" Text="WMS服务URL："></asp:Label>
                </td>
                <td class="style2" align="left">
                    <asp:TextBox ID="TextBox3" runat="server" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1" align="right">
                    <asp:Label ID="Label7" runat="server" Text="WFS服务URL："></asp:Label>
                </td>
                <td class="style2" align="left">
                    <asp:TextBox ID="TextBox4" runat="server" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1" align="right">
                    <asp:Label ID="Label8" runat="server" Text="WCS服务URL："></asp:Label>
                </td>
                <td class="style2" align="left">
                    <asp:TextBox ID="TextBox5" runat="server" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1" align="right">
                    <asp:Label ID="Label9" runat="server" Text="KML服务URL："></asp:Label>
                </td>
                <td class="style2" align="left">
                    <asp:TextBox ID="TextBox6" runat="server" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1" align="right">
                    <asp:Label ID="Label10" runat="server" Text="缩略图："></asp:Label>
                </td>
                <td align="left" class="style4" style="width: 1500px">
                    <asp:TextBox ID="TextBox7" runat="server" Width="247px"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="浏览" />
                    <asp:Button ID="Button2" runat="server" Text="上传" />&nbsp;&nbsp;
                    <asp:Image ID="Image1" runat="server" />
                </td>
            </tr>
            <tr style="height: 100px">
                <td class="style1" align="right">
                    <asp:Label ID="Label11" runat="server" Text="备注："></asp:Label>
                </td>
                <td align="left" class="style2">
                    <asp:TextBox ID="TextBox8" runat="server" Width="417px" Height="95px" 
                        TextMode="MultiLine" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1"></td>
                <td align="center" class="style2">
                    <asp:Button ID="btnSave" runat="server" Text="保存" 
                        style="margin-left: 0px; height: 21px;" Width="51px" OnClick="btnSave_Click"></asp:Button>
                </td>
                <td style="width:600px"></td>
                <td></td>
            </tr>
        </table>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\ASPNETDB.MDF;Integrated Security=True;User Instance=True" 
            ProviderName="System.Data.SqlClient"></asp:SqlDataSource>


    </div>
    </form>
</body>
</html>
