<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDetail.aspx.cs" Inherits="AccountingNote.SystemAdmin.UserDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 460px;
        }
    </style>
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
                <td >
                    <a href="UserInfo.aspx">使用者資訊</a><br />
                    <a href="AccountingList.aspx">流水帳管理</a><br />
                    <a href="UserList.aspx">會員管理</a>
                </td>
                <td class="auto-style1">
                    <h3>會員管理</h3>
                    <asp:DropDownList ID="ddlActType" runat="server" Visible="False">
                        <asp:ListItem Value="0">管理員</asp:ListItem>
                        <asp:ListItem Value="1">一般會員</asp:ListItem>
                         </asp:DropDownList><br />
                    <asp:Panel ID="AccountPanel" runat="server" Width="225px">
                    </asp:Panel>
                    <%--<asp:TextBox ID="txtAccount" runat="server" Enabled="False"></asp:TextBox>--%>
                    姓名:<asp:TextBox ID="txtName" runat="server"></asp:TextBox><br/>
                    Email:<asp:TextBox ID="txtMail" TextMode="Email" runat="server"></asp:TextBox><br/>
                    <asp:Label ID="Label1" runat="server" Text="等級:"></asp:Label><asp:Label ID="lblLevel" runat="server"></asp:Label><br />
                    <asp:Label ID="Label2" runat="server" Text="建立日期:"></asp:Label><asp:Label ID="lblDate" runat="server"></asp:Label><br />
                    <asp:Button ID="btnSave" runat="server" Text="save" OnClick="btnSave_Click" />&nbsp;
                    <asp:Button ID="btnDel" runat="server" Text="Delete" OnClick="btnDel_Click" Visible="False" />&nbsp;&nbsp;
                    <asp:Button ID="btnPwd" align="right top" runat="server"  Text="前往變更密碼" OnClick="btnPwd_Click" Visible="False" /><br/>
                    <asp:Literal ID="ltMsg" runat="server"></asp:Literal>

                </td>
            </tr>
        </table>
    </form>
</body>
</html>
