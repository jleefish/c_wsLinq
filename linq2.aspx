<%@ Page Language="C#" AutoEventWireup="true" CodeFile="linq2.aspx.cs" Inherits="linq2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Linq2</title>
</head>
<body style="font-family: Arial, Helvetica, sans-serif">
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Username: "></asp:Label>
        <asp:TextBox ID="txtUName" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Passwrod: "></asp:Label>
        <asp:TextBox ID="txtPWord" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="username" EmptyDataText="tUsers tabel is empty">
            <Columns>
                <asp:BoundField DataField="username" HeaderText="Username" ReadOnly="True" SortExpression="username" />
                <asp:BoundField DataField="password" HeaderText="Password" SortExpression="password" />
                <asp:ButtonField ButtonType="Button" CommandName="select" HeaderText="Select" Text="Button" />
            </Columns>
            <EmptyDataRowStyle ForeColor="Red" />
        </asp:GridView>
        <br />
        <br />
        <asp:Button ID="cmdInsert" runat="server" OnClick="cmdInsert_Click" Text="Insert Row" />
&nbsp;&nbsp;
        <asp:Button ID="cmdUpdate" runat="server" OnClick="cmdUpdate_Click" Text="Update Row" />
&nbsp;&nbsp;
        <asp:Button ID="cmdDelete" runat="server" OnClick="cmdDelete_Click" Text="Delete Row" />
    
    </div>
    </form>
</body>
</html>
