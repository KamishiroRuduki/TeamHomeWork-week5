<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountingList.aspx.cs" Inherits="AccountingNote.SystemAdmin.AccountingList" %>

<%@ Register Src="~/UserControl/UcPager.ascx" TagPrefix="uc1" TagName="UcPager" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <link href="css/AccountingList.css" rel="stylesheet" type="text/css">
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
                     <div style="height: 78px; width: 105px"></div>
                    <a href="UserInfo.aspx">使用者資訊</a><br />
                    <a href="AccountingList.aspx">流水帳管理</a><br />
                    <a href="UserList.aspx">會員管理</a>
                </td>
                <td>
                    <div style="height: 76px; width: 506px">
                    <h3>流水帳管理</h3>
                    <asp:Button ID="btnAdd" runat="server" Text="AddAccounting" OnClick="btnAdd_Click" />&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblAmount" runat="server" Text="Label"></asp:Label>
                        </div> 
                    <asp:GridView ID="gvAccountList" runat="server" AutoGenerateColumns="False" OnRowDataBound ="gvAccountList_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None" >
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>

                            <asp:BoundField DataField="Caption" HeaderText="標題" />
                            <asp:BoundField DataField="Amount" HeaderText="金額" />
                           <%-- <asp:BoundField DataField="ActType" HeaderText="IN/OUT" />--%>

                            <asp:TemplateField HeaderText="IN/OUT">
                                  <ItemTemplate>
                                     <%--<%# ((int)Eval("ActType") == 0) ? "支出" : "收入" %>--%>
                                      <%--<asp:Literal ID="ltlActType" runat="server"></asp:Literal>--%>
                                      <asp:Label ID="lbl" runat="server" Text="Label"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="CreateDate" DataFormatString="{0:yyyy-MM-dd}" HeaderText="建立日期" />

                            <asp:TemplateField HeaderText="Act">
                                <ItemTemplate>
                                    <a href="/SystemAdmin/AccountingDetail.aspx?ID=<%# Eval("ID") %>">Edit</a>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                    <asp:Literal runat="server" ID="ltPage">
                    </asp:Literal> 
                    <uc1:UcPager runat="server" id="UcPager" PageSize="10" Url="/SystemAdmin/AccountingList.aspx"></uc1:UcPager>
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
