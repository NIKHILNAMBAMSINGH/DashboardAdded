<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Employee/Employee.master" AutoEventWireup="true" CodeFile="addEmployee.aspx.cs" Inherits="Admin_Employee_addEmployee" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
     <table class="auto-style1" style="height: 335px">
        <tr>
                
                 <td style="width: 399px; vertical-align: top;"> 
                      <h3 style="color:red">Employee Registration Form</h3>
                  <div id="heading">
                  <asp:Label ID="lblEmpId" runat="server" Text="Employee ID:"></asp:Label>
                    <asp:TextBox ID="txtEmpId" runat="server"></asp:TextBox>

                    <asp:Label ID="lblFirstName" runat="server" Text="First Name:"></asp:Label>
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
               
                    <asp:Label ID="lblLastName" runat="server" Text="Last Name:"></asp:Label>
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>

                         <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>


               <p />
                    <asp:Label ID="lblDob" runat="server" Text="Date of Birth:" ></asp:Label>
                    <asp:TextBox ID="txtDob" runat="server"></asp:TextBox>       
              
                    <asp:Label ID="lblContactNumber" runat="server" Text="Contact Number:"></asp:Label>
                    <asp:TextBox ID="txtContactNumber" runat="server"></asp:TextBox>&nbsp;
                
                 

             
             <asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label>
         
                   <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
               <p style="height: 35px" />  
           <asp:Label ID="lblGender" runat="server" Text="Gender:"></asp:Label>
                    <asp:DropDownList ID="ddlGender" runat="server">
                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                            <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                        </asp:DropDownList>
                       <asp:Label ID="lblDepartment" runat="server" Text="Department:"></asp:Label>
                    <asp:DropDownList ID="ddlDepartment" runat="server"></asp:DropDownList>
                      <asp:Label ID="lblDesignation" runat="server" Text="Designation:"></asp:Label>
                    <asp:DropDownList ID="ddlDesignation" runat="server"></asp:DropDownList>
                      <p/>
             <asp:Button ID="btnAddEmployee" runat="server" Text="Add Employee" Class="btnEmployee" OnClick="btnAddEmployee_click"  />
                       <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </div>
                           </td> 
        </tr>
    </table>
</asp:Content>

