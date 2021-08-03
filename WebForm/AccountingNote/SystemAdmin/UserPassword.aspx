<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPassword.aspx.cs" Inherits="AccountingNote.SystemAdmin.UserPassword" %>

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
                <td class="auto-style1">
                    <h3>會員管理</h3>
                    帳號:<asp:Label ID="lblAccount" runat="server"></asp:Label><br/>
                    <%--<asp:TextBox ID="txtAccount" runat="server" Enabled="False"></asp:TextBox>--%>
                    原密碼:<asp:TextBox ID="txtPWD" TextMode="Password" runat="server"></asp:TextBox><br/>
                    確認密碼:<asp:TextBox ID="txtCurretPWD" TextMode="Password" runat="server"></asp:TextBox><br/><br/>
                    新密碼:<asp:TextBox ID="txtNewPWD" TextMode="Password" runat="server"></asp:TextBox><br/>
                    <asp:Button ID="btnChange" runat="server" Text="變更密碼" OnClick="btnChange_Click" Visible="true" />&nbsp;
                    <asp:Button ID="btnYes" runat="server" Text="確認" OnClick="btnYes_Click" Visible="False" />&nbsp;
                    <asp:Button ID="btnNo" runat="server" Text="取消" OnClick="btnNo_Click" Visible="False" />
                    <br/>
                    <asp:Literal ID="ltMsg" runat="server"></asp:Literal>

                </td>
            </tr>
        </table>
    </form>
</body>
</html>
