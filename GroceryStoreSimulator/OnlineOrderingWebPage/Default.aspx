﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Ordering</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Image ID="imgGroceries" runat="server" ImageUrl="~/App_Themes/DefaultTheme/Groceries.bmp" />
        <asp:DropDownList ID="ddlLoyaltyNumbers" runat="server"></asp:DropDownList>
        <asp:DropDownList ID="ddlStores" runat="server" AutoPostBack="true"></asp:DropDownList>
    </div>
    </form>
</body>
</html>
