<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="Admin_User_AddUser" %>

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


                   <div style="margin-top:20px">
                   <asp:Label ID="lblDesignation" runat="server" style="margin-left:20px; margin-right:10px" Text="Employee Name:"></asp:Label>
                    <asp:DropDownList ID="ddlDesignation" runat="server" Height="30px"></asp:DropDownList>
                
   <label for="lblMonth" style="margin-left:10px;margin-right:10px">Role :</label>

<asp:DropDownList ID="ddlMonth" runat="server" Height="30px" Width="100px">
   <asp:ListItem Text="Admin" Value="1"></asp:ListItem>
    <asp:ListItem Text="Employee" Value="2"></asp:ListItem>
    
</asp:DropDownList>
                       


                <asp:Button ID="btnAddEmployee" runat="server" Text="Add Employee" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px;margin-bottom:5px"  OnClick="btnAddEmployee_Click" />
                    </div>
                   
       
    </div>                  
            </div>
      <div>
           <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
</div>
        </div>
</asp:Content>

