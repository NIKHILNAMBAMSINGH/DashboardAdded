<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="adminEmployee.aspx.cs" Inherits="adminEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table class="auto-style1" style="height: 438px">
        <tr>
            <td style="height: 114px; vertical-align: top;">
                  <div id="heading">
                  <asp:Label ID="lblEmpId" runat="server" Text="Employee ID:"></asp:Label>
                    <asp:TextBox ID="txtEmpId" runat="server"></asp:TextBox>
             
                    <asp:Label ID="lblUserId" runat="server" Text="User ID:"></asp:Label>
                    <asp:TextBox ID="txtUserId" runat="server"></asp:TextBox>
              
                    <asp:Label ID="lblFirstName" runat="server" Text="First Name:"></asp:Label>
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
               
                    <asp:Label ID="lblLastName" runat="server" Text="Last Name:"></asp:Label>
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
               <p />
                    <asp:Label ID="lblDob" runat="server" Text="Date of Birth:" ></asp:Label>
                    <asp:TextBox ID="txtDob" runat="server"></asp:TextBox>       
              
                    <asp:Label ID="lblContactNumber" runat="server" Text="Contact Number:"></asp:Label>
                    <asp:TextBox ID="txtContactNumber" runat="server"></asp:TextBox>&nbsp;
                
                    <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
             <asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label>
         
                   <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
               <p style="height: 35px" />
                   <asp:Label ID="lblDepartmentId" runat="server" Text="Department ID:"></asp:Label>
                   <asp:TextBox ID="txtDepartmentId" runat="server"></asp:TextBox>
           <asp:Label ID="lblGender" runat="server" Text="Gender:"></asp:Label>
                    <asp:DropDownList ID="ddlGender" runat="server">
                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                            <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                        </asp:DropDownList>
             <asp:Button ID="btnSubmit" runat="server" Text="Add Employee" Class="btnEmployee"  />
            </div>


            </td>
        </tr>
        <tr>
            <td style="vertical-align: top">&nbsp;</td>
        </tr>
    </table>
</asp:Content>

