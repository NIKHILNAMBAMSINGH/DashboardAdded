<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Employee/Employee.master" AutoEventWireup="true" CodeFile="UserManager.aspx.cs" Inherits="Admin_Employee_UserManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <table class="auto-style1" style="height: 335px">
        <tr>
                
                 <td style="width: 399px; vertical-align: top;"> 
                      <h3 style="color:red">Create Login Details</h3>
                  <div id="heading">
                  <asp:Label ID="lblUsername" runat="server" Text="Username:"></asp:Label>
                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>

                    <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
                    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
               
                    

                      <asp:Label ID="lblDesignation" runat="server" Text="Employee Name:"></asp:Label>
                    <asp:DropDownList ID="ddlDesignation" runat="server"></asp:DropDownList>
                      <p />
             <asp:Button ID="btnAddEmployee" runat="server" Text="Add Employee" Class="btnEmployee" OnClick="btnAddEmployee_Click"  />
                       <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </div>
                           </td> 
        </tr>
    </table>
</asp:Content>

