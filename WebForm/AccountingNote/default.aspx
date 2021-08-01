<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="AccountingNote._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/default.css" rel="stylesheet" type="text/css">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td colspan="2" width="500" height="150" valign="top">
                    <h1 id="title">流水帳管理系統</h1>
                    <a href="Login.aspx">登入系統</a>
                </td>
            </tr>
            <tr>
                <td>
                    <table align="left" style="font-size:20px"width="500">
                        <tr align="left">
                            <th>初次記帳</th>
                            <td>
                                <asp:Label ID="FirstTime" runat="server"></asp:Label>  
                            </td>
                        </tr>
                        <tr align="left">
                            <th>最後記帳</th>
                            <td>
                                <asp:Label ID="LastTime" runat="server"></asp:Label>  
                            </td>
                        </tr>
                        <tr align="left">
                            <th>記帳數量</th>
                            <td>
                                <asp:Label ID="AccountCount" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr align="left">
                            <th>會員數</th>
                            <td>
                                <asp:Label ID="UserCount" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
