<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="setfacets.aspx.cs" Inherits="TestChannelApi.setfacets" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="FirstNameLabel" runat="server" Text="First Name"></asp:Label><asp:TextBox ID="FirstNameTextBox" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LastNameLabel" runat="server" Text="Last Name"></asp:Label><asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="EmailLabel" runat="server" Text="E-Mail"></asp:Label><asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="ChannelIdLabel" runat="server" Text="Channel ID"></asp:Label><asp:TextBox ID="ChannelIdTextBox" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="SetFacets" runat="server" Text="Save" OnClick="SetFacets_Click" />
        </div>
    </form>
</body>
</html>
