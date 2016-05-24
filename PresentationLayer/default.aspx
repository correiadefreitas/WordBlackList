<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="PresentationLayer._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txt" runat="server"></asp:TextBox>
        <asp:Button ID="btn" runat="server" OnClick="btn_Click" />
        <hr />
        <asp:Literal ID="lt" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
