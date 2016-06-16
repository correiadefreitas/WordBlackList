<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="PresentationLayer._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div><asp:TextBox ID="txt" runat="server" TextMode="MultiLine" Columns="40" Rows="4"></asp:TextBox></div>
        <div><asp:Button ID="btn" runat="server" OnClick="btn_Click" Text="Filter" /></div>
        <hr />
        <asp:Literal ID="lt" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
