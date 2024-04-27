<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Employee/Employee.master" AutoEventWireup="true" CodeFile="UserDetails.aspx.cs" Inherits="Admin_Employee_UserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <table class="auto-style1" style="height: 335px">
        <tr>
             <td style="width: 399px; vertical-align: top;">
                <h3 style="color:red">Search User</h3>
                <div id="inputTable">
                    <label for="txtDeptId">User ID:</label>
                    <asp:TextBox ID="txtDeptId" runat="server"></asp:TextBox>
                    <label for="txtDeptName">User Name:</label>
                    <asp:TextBox ID="txtDeptName" runat="server"></asp:TextBox>
                     <asp:Button ID="btnShowAll" runat="server" Text="Show All Users" OnClick="btnShowAll_Click" />
                    <br />
                    <br />
                    <asp:Button ID="btnSearchDesignation" runat="server" Text="Search Employee" OnClick="btnSearchDesignation_Click" />
                    <asp:Button ID="btnResetDesignation" runat="server" Text="Reset" OnClick="btnResetDesignation_Click" />
                </div>
                  
                 <h3 style="color:red">User Details</h3>
                 <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="0"
    DataKeyNames="EmpId" style="margin-left: 0px" >
    <Columns>  
        <asp:BoundField DataField="UserId" HeaderText="User ID" ReadOnly="true" ItemStyle-Width="100px" />
        <asp:BoundField DataField="Username" HeaderText="Username" ItemStyle-Width="150px" />
        <asp:BoundField DataField="Password" HeaderText="Password" ItemStyle-Width="150px" />
        
    </Columns>
</asp:GridView>

        </tr>
    </table>
</asp:Content>

