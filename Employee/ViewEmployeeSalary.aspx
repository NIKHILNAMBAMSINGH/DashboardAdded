<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/EmployeeSalaryMasterPage.master" AutoEventWireup="true" CodeFile="ViewEmployeeSalary.aspx.cs" Inherits="Employee_ViewEmployeeSalary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <style>
         
        .first-row {
            margin-top:30px;
            margin-bottom:30px;
        }
        .row {
            margin-bottom:30px;
        }
        .Year-Month {
            margin-top:30px;
        }
    </style>
    <table class="auto-style1" style="height: 353px">
        <tr>
            <td style="vertical-align: top">
             <div class="conatiner">
                 <%--<div class="Year-Month">
                      
                      <asp:Label ID="LabelMonth" runat="server" Class="label-space" Text="Month :"></asp:Label>
                     <asp:DropDownList ID="DropDownListForMonths" runat="server" AutoPostBack = "true" OnSelectedIndexChanged="OnSelectedIndexChanged">
                         <asp:ListItem Value="">Select Month</asp:ListItem>
                        <asp:ListItem Text="January" Value="1"></asp:ListItem>
                        <asp:ListItem Text="February" Value="2"></asp:ListItem>
                         <asp:ListItem Text="March" Value="3"></asp:ListItem>
                         <asp:ListItem Text="April" Value="4"></asp:ListItem>
                         <asp:ListItem Text="May" Value="5"></asp:ListItem>
                         <asp:ListItem Text="June" Value="6"></asp:ListItem>
                         <asp:ListItem Text="July" Value="7"></asp:ListItem>
                         <asp:ListItem Text="August" Value="8"></asp:ListItem>
                         <asp:ListItem Text="September" Value="9"></asp:ListItem>
                         <asp:ListItem Text="October" Value="10"></asp:ListItem>
                         <asp:ListItem Text="November" Value="11"></asp:ListItem>
                         <asp:ListItem Text="December" Value="12"></asp:ListItem>
                     </asp:DropDownList>
             </div>--%>
                <div class="div-for-employee-box">
  
                    <div class="first-row">
                    <asp:Label ID="LabelEmpID" runat="server" Text="Employee ID :"></asp:Label>
                    <asp:TextBox ID="TextBoxEmpID" runat="server"></asp:TextBox>
                      <asp:Label ID="LabelEmployeeName" class="label-space" runat="server" Text="Employee Name :"></asp:Label>
                    <asp:TextBox ID="TextBoxEmployeeName" runat="server"></asp:TextBox>
                   </div>
                      <div class="row">
                           <asp:Label ID="LabelDesignation" runat="server" Text="Designation :"></asp:Label>
                    <asp:TextBox ID="TextBoxDesignation" runat="server"></asp:TextBox>
                      <asp:Label ID="LabelDepartmentName"  class="label-space" runat="server" Text="Department Name :"></asp:Label>
                    <asp:TextBox ID="TextBoxDepartmentName" runat="server"></asp:TextBox>
                      </div>
                     <div class="row">
                           <asp:Label ID="LabelBasicPay" runat="server" Text="Basic Pay :"></asp:Label>
                    <asp:TextBox ID="TextBoxBasicPay" runat="server"></asp:TextBox>
                      <asp:Label ID="LabelAllowances" class="label-space" runat="server" Text="Allowances :"></asp:Label>
                    <asp:TextBox ID="TextBoxAllowances" runat="server"></asp:TextBox>
                      </div>

                    <div class="row">
                           <asp:Label ID="LabelTotalLeaveDays" runat="server" Text="Total Leave Days :"></asp:Label>
                    <asp:TextBox ID="TextBoxTotalLeaveDays" runat="server"></asp:TextBox>
                      <asp:Label ID="LabelTotalWorkedDays" class="label-space" runat ="server" Text="Total Worked Days :"></asp:Label>
                    <asp:TextBox ID="TextBoxTotalWorkedDays" runat="server"></asp:TextBox>
                      </div>

                    <div class="row">
                           <asp:Label ID="LabelDeductions" runat="server" Text="Deductions :"></asp:Label>
                    <asp:TextBox ID="TextBoxDeductions" runat="server"></asp:TextBox>
                      <asp:Label ID="LabelNetSalary" class="label-space" runat ="server" Text="Net Salary :"></asp:Label>
                    <asp:TextBox ID="TextBoxNetSalary" runat="server"></asp:TextBox>
                      </div>
                   
              </div>
                

             </div>
                
            </td>
            
        </tr>
    </table>
   
     
</asp:Content>

