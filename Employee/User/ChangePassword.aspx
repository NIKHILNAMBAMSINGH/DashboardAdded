<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeePage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Employee_User_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                 <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/User/UserDashboard.aspx">User Dashboard</asp:HyperLink>
            </h6>
        </div>
        <br />
               <div class="input-group">

    <label for="lblUsername" style="margin-left:10px;margin-right:10px">Username :</label>
                   
    <asp:TextBox ID="txtUsername" runat="server"  Height="30px"></asp:TextBox>
    <label for="lblPassword" style="margin-left:10px;margin-right:10px">Password :</label>
    <asp:TextBox ID="txtPassword" runat="server" Height="30px"></asp:TextBox>
                   
                    <asp:Button ID="btnSearchDesignation" runat="server" Text="Change Password" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px;margin-bottom:5px" OnClick="btnSearchDesignation_Click" />      

</div>
              
           <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
</div>
        </div>
</asp:Content>

