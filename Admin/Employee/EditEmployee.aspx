<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="EditEmployee.aspx.cs" Inherits="Admin_Employee_EditEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                 <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/Employee/EmployeeDashboard.aspx">Employee Dashboard</asp:HyperLink>
                > Search Employee
            </h6>
        </div>
        <br />
               <div class="input-group">
    <label for="txtEmployeeCode" style="margin-left:10px;margin-right:10px">Employee Code :</label>
                   
    <asp:TextBox ID="txtEmployeeCode" runat="server"  Height="30px"></asp:TextBox>
    <label for="txtDeptName" style="margin-left:20px;margin-right:10px">Employee Name :</label>
    <asp:TextBox ID="txtDeptName" runat="server" Height="30px"></asp:TextBox>
  <asp:Button ID="btnSearchDesignation" runat="server" Text="Search" OnClick="btnSearchDesignation_Click" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px;margin-bottom:5px"   />
    <asp:Button ID="btnResetDesignation" runat="server" Text="Reset" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px; margin-bottom:5px"  />  
   
    </div>
                
            </div>
        </div>


    <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
            
                  
                 Edit Employee
            </h6>
        </div>
        <br />
               <div class="input-group">
              <div>     
 <label for="txtEmpId" style="margin-left:10px;margin-right:10px">Employee Code:</label>
<asp:TextBox ID="txtEmpId" runat="server"></asp:TextBox>

<label for="txtFirstName" style="margin-left:20px;margin-right:10px">First Name:</label>
<asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>

<label for="txtLastName" style="margin-left:20px;margin-right:10px">Last Name:</label>
<asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                  </div>
                   <div style="margin-left:100px"></div>
                   <div style="margin-top:60px"></div>
<label for="txtEmail" style="margin-left:10px;margin-right:10px">Email Address:</label>
<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>



<label for="txtDob" style="margin-left:10px;margin-right:10px">Date of Birth:</label>
<asp:TextBox ID="txtDob" runat="server"></asp:TextBox>

<label for="txtContactNumber" style="margin-left:20px;margin-right:10px">Contact Number:</label>
<asp:TextBox ID="txtContactNumber" runat="server"></asp:TextBox>

<p />

<div style="margin-top:30px">
<label for="txtAddress" style="margin-left:10px;margin-right:10px">Address:</label>
<asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>

<label for="ddlGender" style="margin-left:10px;margin-right:10px">Gender:</label>
<asp:DropDownList ID="ddlGender" runat="server">
    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
    <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
</asp:DropDownList>

<label for="ddlDepartment" style="margin-left:20px;margin-right:10px">Department:</label>
<asp:DropDownList ID="ddlDepartment" runat="server"></asp:DropDownList>

<label for="ddlDesignation" style="margin-left:20px;margin-right:10px">Designation:</label>
<asp:DropDownList ID="ddlDesignation" runat="server"></asp:DropDownList>
    </div>
 
                 
                   
       
    </div>
        <div style="margin-top:10px">
            <asp:Button ID="btnEditEmployee" runat="server" Text="Edit" OnClick="btnEditEmployee_Click"  CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px;margin-bottom:5px" />
        </div>
                          
            </div>
      <div>
           <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
</div>
        </div>
      
    
</asp:Content>

