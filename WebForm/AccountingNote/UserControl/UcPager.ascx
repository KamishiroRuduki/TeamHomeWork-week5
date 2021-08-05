<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcPager.ascx.cs" Inherits="AccountingNote.UserControl.UcPager" %>
<div>
    <a runat="server" id="alinkFirst" href="#">First</a> &nbsp;
    <a runat="server" id="alink1" href="#">1</a> &nbsp;
    <a runat="server" id="alink2" href="#">2</a> &nbsp;
    <asp:Literal runat="server" ID="ltlCurrentPage"></asp:Literal>
    <a runat="server" id="alink4" href="#">4</a> &nbsp;
    <a runat="server" id="alink5" href="#">5</a> &nbsp;
    <a runat="server" id="alinkLast" href="#">Last</a> &nbsp;
        <asp:Literal runat="server" ID="ltPager"></asp:Literal>
</div>