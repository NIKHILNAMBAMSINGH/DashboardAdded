<<<<<<< HEAD
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Department/Department.master" AutoEventWireup="true" CodeFile="SearchDepartment.aspx.cs" Inherits="Admin_Department_SearchDepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
     <table class="auto-style1" style="height: 335px">
        <tr>
            <td style="width: 399px; vertical-align: top;">
                <h3 style="color:red">Search Department</h3>
                <div id="inputTable">
                    <label for="txtDeptId">Department ID:</label>
                    <asp:TextBox ID="txtDeptId" runat="server"></asp:TextBox>
                    <label for="txtDeptName">Department Name:</label>
                    <asp:TextBox ID="txtDeptName" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="btnSearchDesignation" runat="server" Text="Search Designation" OnClick="btnSearchDesignation_Click" />
                    <asp:Button ID="btnResetDesignation" runat="server" Text="Reset" OnClick="btnResetDesignation_Click" />
                </div>
                 <h3 style="color:red">Department Details</h3>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="0"
                        DataKeyNames=" DeptId" style="margin-left: 0px" Width="544px">
                        <Columns>
                            <asp:BoundField DataField="DeptId" HeaderText="Department ID" SortExpression="DeptId" />
                            <asp:BoundField DataField="DeptName" HeaderText="Department Name" SortExpression="DeptName" />
                            <asp:BoundField DataField="AddedDate" HeaderText="Added Date" SortExpression="AddedDate" />
                        </Columns>
                    </asp:GridView>
            </td>
            
              
        </tr>
    </table>
=======
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="SearchDepartment.aspx.cs" Inherits="Admin_Department_SearchDepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                 <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/Department/DepartmentDashboard.aspx">Department</asp:HyperLink>
            </h6>
        </div>
        <br />
               <div class="input-group">
    <label for="txtDeptId" style="margin-left:10px;margin-right:10px">Department ID :</label>
                   
    <asp:TextBox ID="txtDeptId" runat="server"  Height="30px"></asp:TextBox>
    <label for="txtDeptName" style="margin-left:20px;margin-right:10px">Department Name :</label>
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
                 Department List
            </h6>
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="4" CellPadding="0"
    DataKeyNames="DeptId" style="margin-left: 0px" EmptyDataText="No data found" ShowHeaderWhenEmpty="true" CssClass="table table-bordered"
    HeaderStyle-CssClass="thead-dark">
    <Columns>
        <asp:BoundField DataField="DeptId" HeaderText="Department ID" SortExpression="DeptId" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="DeptName" HeaderText="Department Name" SortExpression="DeptName" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="AddedDate" HeaderText="Added Date" SortExpression="AddedDate" ItemStyle-CssClass="align-middle" />
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

