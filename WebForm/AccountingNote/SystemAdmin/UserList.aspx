<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="AccountingNote.SystemAdmin.UserList" %>

<%@ Register Src="~/UserControl/UcPager.ascx" TagPrefix="uc1" TagName="UcPager" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                
                <td colspan="2">
                    <h1>流水帳管理系統-後台</h1>
                </td>
            </tr>
            <tr>
               
                <td valign ="Top">
                     <div style="height: 69px; width: 104px"></div>
                    <a href="UserInfo.aspx">使用者資訊</a><br />
                    <a href="AccountingList.aspx">流水帳管理</a><br />
                    <a href="UserList.aspx">會員管理</a>
                </td>
                <td>
                    
                    <h3>會員管理</h3>
                    <asp:Button ID="btnAdd" runat="server" Text="AddAccounting" OnClick="btnAdd_Click" Visible="true" />
                    <asp:GridView ID="gvUserList" runat="server" AutoGenerateColumns="False" OnRowDataBound ="gvUserList_RowDataBound" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" >
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <Columns>
                            <asp:BoundField DataField="Account" HeaderText="帳號" />
                            <asp:BoundField DataField="Name" HeaderText="姓名" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                           <%-- <asp:BoundField DataField="ActType" HeaderText="IN/OUT" />--%>

                            <asp:TemplateField HeaderText="等級">
                                  <ItemTemplate>
                                     <%--<%# ((int)Eval("ActType") == 0) ? "支出" : "收入" %>--%>
                                      <%--<asp:Literal ID="ltlActType" runat="server"></asp:Literal>--%>
                                      <asp:Label ID="lbl" runat="server" Text="Label"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="CreateDate" DataFormatString="{0:yyyy-MM-dd}" HeaderText="建立日期" />

                            <asp:TemplateField HeaderText="Act">
                                <ItemTemplate>
                                    <a href="/SystemAdmin/UserDetail.aspx?ID=<%# Eval("ID") %>">Edit</a>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#000065" />
                    </asp:GridView>
                     <asp:Literal runat="server" ID="ltPage">
                    </asp:Literal>
                    <uc1:UcPager runat="server" ID="UcPager" PageSize="10" Url="/SystemAdmin/AccountingList.aspx"/>
                    <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
                        <p style="color:red">
                            No Data
                        </p>
                    </asp:PlaceHolder>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
