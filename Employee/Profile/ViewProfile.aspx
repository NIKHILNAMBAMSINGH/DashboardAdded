<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeePage.master" AutoEventWireup="true" CodeFile="ViewProfile.aspx.cs" Inherits="Employee_Profile_ViewProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
            
                   <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/Employee/EmployeeDashboard.aspx">Employee Dashboard</asp:HyperLink>
                > Profile Details
            </h6>
        </div>
        <br />
               <div class="input-group">
              <div>     
 <label for="txtEmpId" style="margin-left:10px;margin-right:10px">Employee Code:</label>
<asp:TextBox ID="txtEmpId" runat="server" Width="100px"></asp:TextBox>

<label for="txtFirstName" style="margin-left:20px;margin-right:10px">Employee Name:</label>
<asp:TextBox ID="txtEmployeeName" runat="server"></asp:TextBox>
              
                 
<label for="txtEmail" style="margin-left:10px;margin-right:10px">Email Address:</label>
<asp:TextBox ID="txtEmail" runat="server" Width="300px"></asp:TextBox>


<div style="margin-top:30px">
<label for="txtDob" style="margin-left:10px;margin-right:10px">Date of Birth:</label>
<asp:TextBox ID="txtDob" runat="server"></asp:TextBox>

<label for="txtContactNumber" style="margin-left:20px;margin-right:10px">Contact Number:</label>
<asp:TextBox ID="txtContactNumber" runat="server"></asp:TextBox>

                  <label for="ddlGender" style="margin-left:10px;margin-right:10px">Gender:</label>
    <asp:TextBox ID="txtGender" runat="server" width="100px"></asp:TextBox>
    </div>
<div style="margin-top:30px">
<label for="txtAddress" style="margin-left:10px;margin-right:10px">Address:</label>
<asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>



<label for="ddlDepartment" style="margin-left:20px;margin-right:10px">Department:</label>
    <asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox>
   
<label for="ddlDesignation" style="margin-left:20px;margin-right:10px">Designation:</label>
    <asp:TextBox ID="txtDesignation" runat="server"></asp:TextBox>
    
   
<p />
    <br />   
              <asp:Button ID="btnSearchDesignation" runat="server" Text="Edit" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px;margin-bottom:5px" OnClick="btnSearchDesignation_Click" />
    <asp:Button ID="btnUpdateEmployee" runat="server" Text="Update" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px;margin-bottom:5px" OnClick="btnUpdateEmployee_Click" />
       
    </div>                  
            </div>
     
        </div>
        <div>
            <asp:Label ID="lbmsg" runat="server" Text=""></asp:Label>
        </div>
</asp:Content>

