<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Salary/Salary.master" AutoEventWireup="true" CodeFile="ViewEarning.aspx.cs" Inherits="Employee_Salary_ViewEarning" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <style>
         
        .first-row {
            margin-top:30px;
            margin-bottom:30px;
        }
        .first-header {
            margin-top:20px;
            margin-bottom:30px;
        }
       
    </style>
    <table class="auto-style1" style="height: 335px">
        <tr>
                
                 <td style="width: 399px; vertical-align: top;"> 
                     
                  <div id="heading"; style="margin-top:10px">
                  <asp:Label ID="lblEmpId" runat="server" Text="Employee ID:"></asp:Label>
                      <asp:TextBox ID="txtEmpId" runat="server" Width="40px"></asp:TextBox>

                    <asp:Label ID="lblEmpName" runat="server" Text="Employee Name:"></asp:Label>
                    <asp:TextBox ID="txtEmpName" runat="server"></asp:TextBox>
               
                      
               <p style="margin-top:30px" />
                      <h3 style="color:red">Earning Component Details</h3>
       <div class="first-row">
                       <asp:Label ID="lblMonth" runat="server" Text="Month:"></asp:Label>
                    <asp:TextBox ID="txtMonth" runat="server" Width="70px"></asp:TextBox>&nbsp;

                      <asp:Label ID="lblYear" runat="server" Text="Year:"></asp:Label>
                    <asp:TextBox ID="txtYear" runat="server" Width="40px"></asp:TextBox>&nbsp;
            </div>      
                   
             <div class="first-row"">             
                    <asp:Label ID="lblBasicSalary" runat="server" Text="Basic Salary( Rs ) :" ></asp:Label>
                    <asp:TextBox ID="txtBasicSalary" runat="server" Width="70px"></asp:TextBox>       
              
                    <asp:Label ID="Allowances" runat="server" Text="Allowances( Rs ) :"></asp:Label>
                    <asp:TextBox ID="txtAllowances" runat="server" Width="70px"></asp:TextBox>

                      <asp:Label ID="lblBonus" runat="server" Text="Bonus( Rs ) :"></asp:Label>
                    <asp:TextBox ID="txtBonus" runat="server" Width="70px"></asp:TextBox>&nbsp;

                 <asp:Label ID="lblMiscellaneous" runat="server" Text="Miscellaneous( Rs ) :"></asp:Label>
                    <asp:TextBox ID="txtMiscellaneous" runat="server" Width="70px"></asp:TextBox>&nbsp;
                 </div>     
                       <p />
             <div class="first-row">
                      <asp:Label ID="lblTotalEarning" runat="server" Text="Total Earning( Rs ) :"></asp:Label>
                    <asp:TextBox ID="txtTotalEarning" runat="server" Width="70px"></asp:TextBox>&nbsp;
                 </div>
                <p/>
              

            
                       <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </div>
                           </td> 
        </tr>
    </table>
</asp:Content>

