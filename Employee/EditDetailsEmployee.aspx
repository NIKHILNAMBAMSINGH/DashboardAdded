<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/EmployeeProfile.master" AutoEventWireup="true" CodeFile="EditDetailsEmployee.aspx.cs" Inherits="Employee_EditDetailsEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
      <style>
        .label-space {
            margin-left:20px;
        }
        .first-row {
            margin-top:30px;
            margin-bottom:30px;
        }
        .row {
            margin-bottom:30px;
        }
    </style>
   
      <table class="auto-style1" style="height: 353px">
        <tr>
            <td style="vertical-align: top">
              <div class="div-for-employee-box">
  
                   <div class="first-row">
                    <asp:Label ID="LabelEmpID" runat="server" Text="Employee ID :" ></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
                      <asp:Label ID="Label1" class="label-space" runat="server" Text="Department ID :"></asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                   </div>
                      <div class="row">
                           <asp:Label ID="Label2" runat="server" Text="First Name :"></asp:Label>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                      <asp:Label ID="Label3"  class="label-space" runat="server" Text="Last Name :"></asp:Label>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                      </div>
                     <div class="row">
                           <asp:Label ID="Label4" runat="server" Text="Date Of Birth :"></asp:Label>
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                      <asp:Label ID="Label5" class="label-space" runat="server" Text="Gender :"></asp:Label>
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                      </div>
                    <div class="row">
                           <asp:Label ID="Label6" runat="server" Text="Email :"></asp:Label>
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                      <asp:Label ID="Label7" class="label-space" runat ="server" Text="Contact No :"></asp:Label>
                    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                      </div>
                    <div class="row">
                           <asp:Label ID="Label8" runat="server" Text="Address :"></asp:Label>
                    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                     
                      </div>
                  <div class="button">

                      <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />

                  </div>
              </div>
                
                     
            </td>
            
        </tr>
    </table>
</asp:Content>

