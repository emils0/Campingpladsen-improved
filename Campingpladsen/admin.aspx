<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Campingpladsen.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>admin page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <asp:GridView ID="adminGrid" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
