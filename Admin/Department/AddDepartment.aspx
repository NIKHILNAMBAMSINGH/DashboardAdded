<<<<<<< HEAD
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Department/Department.master" AutoEventWireup="true" CodeFile="AddDepartment.aspx.cs" Inherits="Admin_Department_AddDepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
     <table class="auto-style1" style="height: 335px">
        <tr>
                
                 <td style="width: 399px; vertical-align: top;"> 
                            <h3 style="color:red">Department Registration Form</h3>
                            <div id="inputTable">
        <label for="txtDeptId">Department ID:</label>
        <asp:TextBox ID="txtDeptId" runat="server"></asp:TextBox>
                               
        <label for="txtDeptName">Department Name:</label>
        <asp:TextBox ID="txtDeptName" runat="server"></asp:TextBox>
                                <br />
                                <br />
        <asp:Button ID="btnAddDesignation" runat="server" Text="Add Designation" OnClick="btnAddDesignation_Click"/>
        <asp:Button ID="btnResetDepartment" runat="server" Text="Reset" OnClick="btnResetDesignation_Click" />
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
       </div></td> 
        </tr>
    </table>
=======
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="AddDepartment.aspx.cs" Inherits="Admin_Department_AddDepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                 <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/Department/DepartmentDashboard.aspx">Department Dashboard</asp:HyperLink>
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
                <asp:Button ID="btnSearchDesignation" runat="server" Text="Add Department" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px;margin-bottom:5px"  OnClick="btnAddDesignation_Click" />
                    <asp:Button ID="btnResetDepartment" runat="server" Text="Reset Department" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px;margin-bottom:5px"  OnClick="btnAddDesignation_Click" />
                   
       
    </div>                  
            </div>
      <div>
           <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
</div>
        </div>
>>>>>>> cb92eb5b2e9038612fdacf5d98757c880099271b
</asp:Content>

