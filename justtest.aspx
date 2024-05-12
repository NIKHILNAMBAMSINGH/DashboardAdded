<%@ Page Language="C#" AutoEventWireup="true" CodeFile="justtest.aspx.cs" Inherits="justtest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .tooltip-container {
            position: relative;
        }

        .tooltip-content {
            display: none;
            position: absolute;
            background-color: #f9f9f9;
            border: 1px solid #ccc;
            padding: 5px;
            border-radius: 5px;
            z-index: 1;
        }

        .tooltip-trigger:hover + .tooltip-content,
        .tooltip-content:hover {
            display: block;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <asp:Panel ID="pnlEmployee" runat="server" CssClass="tooltip-container">
    <asp:Label ID="lblEmployee" runat="server" CssClass="tooltip-trigger">Employee</asp:Label>
    <asp:Panel ID="pnlTooltip" runat="server" CssClass="tooltip-content">
        <ul>
            <li><a href="CreateEmployee.aspx">Create Employee</a></li>
            <li><a href="EditEmployee.aspx">Edit Employee</a></li>
            <!-- Add other options as needed -->
        </ul>
    </asp:Panel>
</asp:Panel>
    </div>
    </form>
</body>
</html>
