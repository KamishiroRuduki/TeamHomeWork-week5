<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="AccountingNote.SystemAdmin.UserList" %>

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
                <td>
                <td colspan="2">
                    <h1>流水帳管理系統-後台</h1>
                </td>
            </tr>
            <tr>
                <td>
                    <a href="UserInfo.aspx">使用者資訊</a><br />
                    <a href="AccountingList.aspx">流水帳管理</a><br />
                    <a href="UserList.aspx">會員管理</a>
                </td>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="AddAccounting" OnClick="btnAdd_Click" Visible="False" />
                    <asp:GridView ID="gvUserList" runat="server" AutoGenerateColumns="False" OnRowDataBound ="gvUserList_RowDataBound" >
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
                                    <a href="/SystemAdmin/UserList.aspx?ID=<%# Eval("ID") %>">Edit</a>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
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
