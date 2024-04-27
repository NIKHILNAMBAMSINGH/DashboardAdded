<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Salary/Salary.master" AutoEventWireup="true" CodeFile="TotalSalary.aspx.cs" Inherits="Admin_Salary_TotalSalary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
     <table class="auto-style1" style="height: 335px">
        <tr>
                
                 <td style="width: 399px; vertical-align: top;"> 
                     
                  <div id="heading"; style="margin-top:10px">
                  <asp:Label ID="lblEmpId" runat="server" Text="Employee ID:"></asp:Label>
                    <asp:TextBox ID="txtEmpId" runat="server" Width="40px"></asp:TextBox>

                    <asp:Label ID="lblEmpName" runat="server" Text="Employee Name:"></asp:Label>
                    <asp:TextBox ID="txtEmpName" runat="server"></asp:TextBox>
               
                      <asp:Button ID="btnSearch" runat="server" Text="Search" />
                      
               <p style="margin-top:30px" />
                      <h3 style="color:red">Total Salary Details</h3>
       
                       <asp:Label ID="lblMonth" runat="server" Text="Month:"></asp:Label>
                    <asp:TextBox ID="txtMonth" runat="server" Width="70px"></asp:TextBox>&nbsp;

                      <asp:Label ID="lblYear" runat="server" Text="Year:"></asp:Label>
                    <asp:TextBox ID="txtYear" runat="server" Width="40px"></asp:TextBox>&nbsp;
                        <p />
                      <asp:Label ID="lblTotalEarning" runat="server" Text="Total Earning:"></asp:Label>
                    <asp:TextBox ID="txtTotalEarning" runat="server" Width="70px"></asp:TextBox>&nbsp;

                      <asp:Label ID="lblTotalDeduction" runat="server" Text="Total Deduction:"></asp:Label>
                    <asp:TextBox ID="txtTotalDeduction" runat="server" Width="70px"></asp:TextBox>&nbsp;

                      <asp:Label ID="lblNetPayable" runat="server" Text="Net Payable:"></asp:Label>
                    <asp:TextBox ID="txtNetPayable" runat="server" Width="70px"></asp:TextBox>&nbsp;
                <p/>

              

             <asp:Button ID="btnSaveSalary" runat="server" Text="Save" Class="btnSaveSalary"   />
                       <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </div>
                           </td> 
        </tr>
    </table>
</asp:Content>

