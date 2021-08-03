﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountingList.aspx.cs" Inherits="AccountingNote.SystemAdmin.AccountingList" %>

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
                    <div>
                    <h3>流水帳管理</h3>
                    <asp:Button ID="btnAdd" runat="server" Text="AddAccounting" OnClick="btnAdd_Click" />
                    <asp:Label ID="lblAmount" runat="server" Text="Label"></asp:Label>
                        </div> 
                    <asp:GridView ID="gvAccountList" runat="server" AutoGenerateColumns="False" OnRowDataBound ="gvAccountList_RowDataBound" >
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
