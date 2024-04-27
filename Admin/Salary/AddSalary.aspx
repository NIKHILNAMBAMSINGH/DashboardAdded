<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Salary/Salary.master" AutoEventWireup="true" CodeFile="AddSalary.aspx.cs" Inherits="Admin_Salary_AddSalary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
      <table class="auto-style1" style="height: 335px">
        <tr>
                
                 <td style="width: 399px; vertical-align: top;"> 
                     
                  <div id="heading"; style="margin-top:10px">
                  <asp:Label ID="lblEmpId" runat="server" Text="Employee ID:"></asp:Label>
                  
                      <asp:DropDownList ID="ddlEmpId" runat="server" Width="120px" AutoPostBack="true" OnSelectedIndexChanged="GetEmpId"></asp:DropDownList>

                    <asp:Label ID="lblEmpName" runat="server" Text="Employee Name:"></asp:Label>
                    <asp:TextBox ID="txtEmpName" runat="server"></asp:TextBox>
               
                      <asp:Button ID="btnSearch" runat="server" Text="Search" />
                      
               <p style="margin-top:40px" />
                      <h3 style="color:red">Enter Earning Details</h3>
       
                       <asp:Label ID="lblMonth" runat="server" Text="Month:"></asp:Label>
                    <asp:TextBox ID="txtMonth" runat="server" Width="70px"></asp:TextBox>&nbsp;

                      <asp:Label ID="lblYear" runat="server" Text="Year:"></asp:Label>
                    <asp:TextBox ID="txtYear" runat="server" Width="40px"></asp:TextBox>&nbsp;
                         <h4>Earning Component</h4>
                    <asp:Label ID="lblBasicSalary" runat="server" Text="Basic Salary" ></asp:Label>
                    <asp:TextBox ID="txtBasicSalary" runat="server" Width="70px" AutoPostBack="true" OnTextChanged="txtBasicSalary_TextChanged"></asp:TextBox>       
              
                    <asp:Label ID="Allowances" runat="server" Text="Allowances:"></asp:Label>
                    <asp:TextBox ID="txtAllowances" runat="server" Width="70px" AutoPostBack="true" OnTextChanged="txtAllowances_TextChanged"></asp:TextBox>

                      <asp:Label ID="lblBonus" runat="server" Text="Bonus:"></asp:Label>
                    <asp:TextBox ID="txtBonus" runat="server" Width="70px" AutoPostBack="true" OnTextChanged="txtBonus_TextChanged"></asp:TextBox>&nbsp;

                 <asp:Label ID="lblMiscellaneous" runat="server" Text="Miscellaneous:"></asp:Label>
                    <asp:TextBox ID="txtMiscellaneous" runat="server" Width="70px"  AutoPostBack="true" OnTextChanged="txtMiscellaneous_TextChanged"></asp:TextBox>&nbsp;
                       <p />
                  
                      <asp:Label ID="lblTotalEarning" runat="server" Text="Total Earning:"></asp:Label>
                    <asp:TextBox ID="txtTotalEarning" runat="server" Width="70px"></asp:TextBox>&nbsp;
                <p/>
              

             <asp:Button ID="btnSaveSalary" runat="server" Text="Save" Class="btnSaveSalary" OnClick="btnSaveSalary_Click"   />
                       <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </div>
                           </td> 
        </tr>
    </table>
</asp:Content>

