<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="EmployeeDashboard.aspx.cs" Inherits="Admin_Employee_EmployeeDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                  <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/Department/DepartmentDashboard.aspx">Employee Dasboard</asp:HyperLink>
            </h6>
        </div>
        <div class="card-body">
            <div class="table-responsive">
            
                <table class="auto-style1" style="text-align:center">
                        <tr>
                            <td >
                                <div style="margin-right:50px ">
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/Employee/AddEmployee.aspx">Add Employee</asp:HyperLink>
                                    </div>
                            </td>
                            <td >
                                  <div style="margin-left:270px">
                                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Admin/Employee/SearchEmployee.aspx">Search Employee</asp:HyperLink>
                                       </div>
                            </td>
                            <td >
                                <div style="margin-left:350px">
                                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Admin/Employee/EmployeeList.aspx">Employee List</asp:HyperLink>
                                    </div>
                            </td>
                            
                        </tr>
                    </table>
            </div>
        </div>
    </div>
</div>
</asp:Content>

