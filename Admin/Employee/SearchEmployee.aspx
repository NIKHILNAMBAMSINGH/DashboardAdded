<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Employee/Employee.master" AutoEventWireup="true" CodeFile="SearchEmployee.aspx.cs" Inherits="Admin_Employee_SearchEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
     <table class="auto-style1" style="height: 335px">
        <tr>
             <td style="width: 399px; vertical-align: top;">
                <h3 style="color:red">Search Employee</h3>
                <div id="inputTable">
                    <label for="txtDeptId">Employee ID:</label>
                    <asp:TextBox ID="txtDeptId" runat="server"></asp:TextBox>
                    <label for="txtDeptName">Employee Name:</label>
                    <asp:TextBox ID="txtDeptName" runat="server"></asp:TextBox>
                    <asp:Button ID="btnShowAll" runat="server" Text="Show All Users" OnClick="btnShowAll_Click" />
                    <br />
                    <br />
                    <asp:Button ID="btnSearchDesignation" runat="server" Text="Search Employee" OnClick="btnSearchDesignation_Click" />
                    <asp:Button ID="btnResetDesignation" runat="server" Text="Reset" OnClick="btnResetDesignation_Click" />
                </div>
                  
                 <h3 style="color:red">Employee Details</h3>
                 <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="0"
    DataKeyNames="EmpId" style="margin-left: 0px" OnRowDeleting="GridView1_RowDeleting" EmptyDataText="No data found" ShowHeaderWhenEmpty="true">
    <Columns>  
        <asp:BoundField DataField="EmpId" HeaderText="Employee ID" ReadOnly="true" />
        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
        <asp:BoundField DataField="LastName" HeaderText="Last Name"/>
        <asp:BoundField DataField="Dob" HeaderText="Date of Birth"/>
        <asp:BoundField DataField="Gender" HeaderText="Gender"  />
        <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number"  />
        <asp:BoundField DataField="Email" HeaderText="Email" />
        <asp:BoundField DataField="Address" HeaderText="Address" />
        <asp:CommandField ShowDeleteButton="True" ItemStyle-Width="50px" />
       
    </Columns>
</asp:GridView>

        </tr>
    </table>
</asp:Content>

