<<<<<<< HEAD
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Employee/Employee.master" AutoEventWireup="true" CodeFile="SearchEmployee.aspx.cs" Inherits="Admin_Employee_SearchEmployee" %>

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
=======
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="SearchEmployee.aspx.cs" Inherits="Admin_Employee_SearchEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                 <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/Employee/EmployeeDashboard.aspx">Employee Dashboard</asp:HyperLink>
            </h6>
        </div>
        <br />
               <div class="input-group">
    <label for="txtDeptId" style="margin-left:10px;margin-right:10px">Employee ID :</label>
                   
    <asp:TextBox ID="txtDeptId" runat="server"  Height="30px"></asp:TextBox>
    <label for="txtDeptName" style="margin-left:20px;margin-right:10px">Employee Name :</label>
    <asp:TextBox ID="txtDeptName" runat="server" Height="30px"></asp:TextBox>
    <br />
                    <br />
                <asp:Button ID="btnSearchDesignation" runat="server" Text="Search" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px;margin-bottom:5px" OnClick="btnSearchDesignation_Click"  />
                    <asp:Button ID="btnResetDesignation" runat="server" Text="Reset" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px; margin-bottom:5px" OnClick="btnResetDesignation_Click" />  
       
    </div>                   
            </div>
      
</div>
     <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                 Employee List
            </h6>
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3" CellPadding="0"
    DataKeyNames="EmpId" style="margin-left: 0px" ShowHeaderWhenEmpty="true" CssClass="table table-bordered"
    HeaderStyle-CssClass="thead-dark">
    <Columns>
        <asp:BoundField DataField="EmpId" HeaderText="Employee ID" SortExpression="DeptId" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="Dob" HeaderText="DOB" SortExpression="Dob" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="AddedDate" HeaderText="Added Date" SortExpression="AddedDate" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number" SortExpression="ContactNumber" ItemStyle-CssClass="align-middle" />
         <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" ItemStyle-CssClass="align-middle" />
         <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" ItemStyle-CssClass="align-middle" />
    </Columns>
    <PagerSettings Mode="NumericFirstLast" Position="Bottom" />
    <PagerStyle CssClass="justify-content-center" />
    <PagerStyle HorizontalAlign="Center" />
</asp:GridView>

            </div>
        </div>
    </div>
</div>

>>>>>>> cb92eb5b2e9038612fdacf5d98757c880099271b
</asp:Content>

