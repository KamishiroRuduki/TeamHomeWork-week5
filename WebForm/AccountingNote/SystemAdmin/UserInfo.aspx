<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="AccountingNote.SystemAdmin.UserInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 144px;
        }
        .auto-style2 {
            height: 304px;
            width: 797px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table  frame="void" border="1" class="auto-style2">
            <tr>
                <td colspan="2">
                    <h1>流水帳管理系統-後台</h1>
                </td>
            </tr>
            <tr>
                <td valign ="Top" class="auto-style1">
                    <div style="height: 21px; width: 117px"></div>
                    <a href="UserInfo.aspx">使用者資訊</a><br />
                    <a href="AccountingList.aspx">流水帳管理</a><br />
                    <a href="UserList.aspx">會員管理</a>
                </td>
                <td>
               <table valign ="Top"> 
                    <tr>
                        <th>帳號</th>
                        <td>
                            <asp:Literal ID="ltAccount" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th>姓名</th>
                        <td>
                            <asp:Literal ID="ltName" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th>Email</th>
                        <td>
                            <asp:Literal ID="ltEmail" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="Button1" runat="server" Text="LogOut" OnClick="Button1_Click" />
               </td>
                </tr>
        </table>
    </form>
</body>
</html>
