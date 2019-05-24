<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormHtml.aspx.cs" Inherits="GetDataHtml.FormHtml" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <style type="text/css">
        body {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       
        <td><asp:Button ID="send" runat="server" Text="Submit" OnClick="send_Click" /></td>
        
    </form>
</body>
</html>
