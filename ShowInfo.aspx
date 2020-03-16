<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowInfo.aspx.cs" Inherits="ShowInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>服务详细信息</title>
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
    <script type="text/javascript" language="javascript">
        function ShowA() {
            window.ShowDialog("ModifyInfo.aspx", window, "dialogWidth=500px;dialogHeight=300px");
          }
    </script>
</head>
<body>
    <form id="form1" runat="server" style="width:1200px; height: 348px;">
    <div>
        <div  class="tableInfo" style="text-align: center; font-size: medium; font-weight: bold;">服务详细信息</div>
    </div>
    <br />
     <div style="text-align:left;font-size: 15px;color: Blue;">
        <asp:Label ID="Label1" runat="server" Text="查询条件(服务名称)："></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Width="171px"></asp:TextBox>&nbsp;
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnQuery" runat="server" Text="查询"  BackColor="#99ccff" OnClick="btnQuery_Click"/>&nbsp;
        <asp:Button ID="btnDelete" runat="server" Text="删除" BackColor="#99ccff" 
            onclick="btnDelete_Click" />&nbsp;
        <asp:Button ID="btnModify" Text="修改" runat="server" BackColor="#99ccff"
            onclick="ShowA"/>&nbsp;
        <asp:Button ID="btnShowAll" runat="server" Text="显示全部" BackColor="#99ccff" 
            onclick="btnShowAll_Click"/>
    </div>
    <br />
    <div style="text-align:center; word-break :break-all ; word-wrap:break-word ">
       <asp:GridView ID="GridView1" runat="server" Width="1200px" 
            AutoGenerateColumns="False" AllowPaging="True" 
            AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" 
            GridLines="None" >
            <PagerSettings FirstPageText="首页" LastPageText="末页"/>
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" 
                Font-Size="14px" Font-Underline="true" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField  DataField="SERVICENAME" ItemStyle-Width="80px" 
                    HeaderText="服务名称" SortExpression="服务名称"  >
                <ItemStyle Width="80px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="服务URL" SortExpression="服务URL" ItemStyle-Width="100px"  >
                    <ItemTemplate>
                        <%# Eval("SERVICEURL").ToString().Length > 5 ? Eval("SERVICEURL").ToString().Substring(0, 5) + "..." : Eval("SERVICEURL").ToString()%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField  DataField="ISDYNAMIC" HeaderText="动态地图" SortExpression="动态地图" 
                    ItemStyle-Width="60px" >
                <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField  DataField="PLATFORM" HeaderText="服务平台" SortExpression="服务平台" 
                    ItemStyle-Width="60px"  >
                <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField  DataField="CATEGORY" HeaderText="分类" SortExpression="分类" 
                    ItemStyle-Width="60px" >
                <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField  DataField="WMSURL" HeaderText="WMS服务URL" 
                    SortExpression="WMS服务URL" ItemStyle-Width="100px" >
                <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField  DataField="WFSURL" HeaderText="WFS服务URL" 
                    SortExpression="WFS服务URL" ItemStyle-Width="100px">
                <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField  DataField="WCSURL" HeaderText="WCS服务URL" 
                    SortExpression="WCS服务URL" ItemStyle-Width="100px">
                <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField  DataField="KMLURL" HeaderText="KML服务URL" 
                    SortExpression="KML服务URL" ItemStyle-Width="100px">
                <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField  DataField="SERVICENAILURL" HeaderText="缩略图" 
                    SortExpression="缩略图" ItemStyle-Width="100px">
                <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField  DataField="MEMO" HeaderText="备注" SortExpression="备注" 
                    ControlStyle-Width="150px" >  
                <ControlStyle Width="150px" />
                </asp:BoundField>
            </Columns>
           
            <EditRowStyle BackColor="#999999" />
           
            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
       </asp:GridView>
    </div>
    <br />
    <asp:Panel ID="Panel1" runat="server" Visible="False">
        <div>
            <table class="tableInfo" style="width: 670px; height: 455px;">
            <tr>
                <td class="style1">
                    <th class="style2"><span class="span_Title">服务信息修改</span></th>
                </td>
            </tr>
            <tr>
                <td class="style1" align="right" >
                    <asp:Label ID="Label3" runat="server" Text="服务名称："></asp:Label>
                </td>
                <td class="style2" align="left">
                    <asp:TextBox ID="TextBox2" runat="server" Width="203px"></asp:TextBox><span class="IsNeedSignal">&nbsp*</span>
                    <asp:Label ID="Label12" runat="server" Text=" "></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1" align="right">
                    <asp:Label ID="Label4" runat="server" Text="服务的URL："></asp:Label>
                </td>
                <td class="style2" align="left"> 
                    <asp:TextBox ID="TextBox3" runat="server" Width="334px"></asp:TextBox><span class="IsNeedSignal">&nbsp*</span>
                    <asp:Label ID="Label13" runat="server" Text=" "></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1" align="right">
                    <asp:Label ID="Label5" runat="server" Text="动态地图："></asp:Label>
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
                    <asp:Label ID="Label6" runat="server" Text="服务平台："></asp:Label>
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
                    <asp:Label ID="Label7" runat="server" Text="分类："></asp:Label>
                </td>
                <td align="left" class="style2">
                   <asp:DropDownList ID="DropDownList3" runat="server" Width="90px">
                       <%-- <asp:ListItem Value="-请选择-" Text="-请选择-"></asp:ListItem>--%>
                        <asp:ListItem Value="地形图" Text="地形图"></asp:ListItem>
                        <asp:ListItem Value="给水" Text="给水"></asp:ListItem>
                    </asp:DropDownList>
                    <span class="IsNeedSignal">&nbsp*</span>
                    <asp:Label ID="Label16" runat="server" Text=" "></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1" align="right">
                    <asp:Label ID="Label8" runat="server" Text="WMS服务URL："></asp:Label>
                </td>
                <td class="style2" align="left">
                    <asp:TextBox ID="TextBox4" runat="server" Width="351px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1" align="right">
                    <asp:Label ID="Label9" runat="server" Text="WFS服务URL："></asp:Label>
                </td>
                <td class="style2" align="left">
                    <asp:TextBox ID="TextBox5" runat="server" Width="349px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1" align="right">
                    <asp:Label ID="Label10" runat="server" Text="WCS服务URL："></asp:Label>
                </td>
                <td class="style2" align="left">
                    <asp:TextBox ID="TextBox6" runat="server" Width="347px" Height="19px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1" align="right">
                    <asp:Label ID="Label11" runat="server" Text="KML服务URL："></asp:Label>
                </td>
                <td class="style2" align="left">
                    <asp:TextBox ID="TextBox7" runat="server" Width="347px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1" align="right">
                   <%-- <asp:Label ID="Label12" runat="server" Text="缩略图："></asp:Label>--%>
                    <asp:Label ID="Label17" runat="server" Text="缩略图:"></asp:Label>
                </td>
                <td align="left" class="style2">
                    <asp:TextBox ID="TextBox8" runat="server" Width="247px"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr style="height: 100px">
                <td class="style1" align="right">
                   <%-- <asp:Label ID="Label13" runat="server" Text="备注："></asp:Label>--%>
                    <asp:Label ID="Label18" runat="server" Text="备注:"></asp:Label>
                </td>
                <td align="left" class="style2">
                    <asp:TextBox ID="TextBox9" runat="server" Width="347px" Height="95px" 
                        TextMode="MultiLine" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1"></td>
                <td align="center" class="style2">
                    <asp:Button ID="btnSave" runat="server" Text="修改" 
                        style="margin-left: 0px; height: 21px;" Width="51px" OnClick="btnModify_Click"></asp:Button>
                </td>
                <td style="width:600px"></td>
                <td></td>
            </tr>
        </table>
        </div>
    </asp:Panel>
    </form>
</body>
</html>
