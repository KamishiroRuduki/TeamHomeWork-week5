<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AccountingNote.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <link href="css/default.css" rel="stylesheet" type="text/css">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 505px;
            height: 64px;
        }
        .auto-style2 {
            height: 105px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
                            <table class="auto-style1">
            <tr>
                <td colspan="2"  valign="top" class="auto-style2">
                    <h1 id="title">流水帳管理系統</h1>
                    <a href="default.aspx" style="background-color:bisque">回首頁</a>
                </td>
            </tr>
                        </table>
        <asp:PlaceHolder ID="plcLogin" runat="server" Visible="false">

        Account:<asp:TextBox ID="txtAccount" runat="server"></asp:TextBox><br />
        Password:<asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /><br />
        <asp:Literal ID="ltMsg" runat="server"></asp:Literal><br />
                        
            </asp:PlaceHolder>
    </form>
</body>
</html>
