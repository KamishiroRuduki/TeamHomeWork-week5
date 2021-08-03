<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDetail.aspx.cs" Inherits="AccountingNote.SystemAdmin.UserDetail" %>

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
                <td>
                    <a href="UserInfo.aspx">使用者資訊</a><br />
                    <a href="AccountingList.aspx">流水帳管理</a><br />
                    <a href="UserList.aspx">會員管理</a>
                </td>
                <td>
                    <asp:DropDownList ID="ddlActType" runat="server" Visible="False">
                        <asp:ListItem Value="0">管理員</asp:ListItem>
                        <asp:ListItem Value="1">一般會員</asp:ListItem>
                         </asp:DropDownList><br />
                    <asp:Panel ID="AccountPanel" runat="server" Width="225px">
                    </asp:Panel>
                    <%--<asp:TextBox ID="txtAccount" runat="server" Enabled="False"></asp:TextBox>--%>
                    姓名:<asp:TextBox ID="txtName" runat="server"></asp:TextBox><br/>
                    Email:<asp:TextBox ID="txtMail" TextMode="Email" runat="server"></asp:TextBox><br/>
                    等級:<asp:Label ID="lblLevel" runat="server"></asp:Label><br />
                    建立日期<asp:Label ID="lblDate" runat="server"></asp:Label><br />
                    <asp:Button ID="btnSave" runat="server" Text="save" OnClick="btnSave_Click" />&nbsp;
                    <asp:Button ID="btnDel" runat="server" Text="Delete" OnClick="btnDel_Click" Visible="False" /><br/>
                    <asp:Literal ID="ltMsg" runat="server"></asp:Literal>

                </td>
            </tr>
        </table>
    </form>
</body>
</html>
