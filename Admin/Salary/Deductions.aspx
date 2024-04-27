<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Salary/Salary.master" AutoEventWireup="true" CodeFile="Deductions.aspx.cs" Inherits="Admin_Salary_Deductions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

     <table class="auto-style1" style="height: 335px">
        <tr>
                
                 <td style="width: 399px; vertical-align: top;"> 
                     
                  <div id="heading"; style="margin-top:10px">
                  <asp:Label ID="lblEmpId" runat="server" Text="Employee ID:"></asp:Label>
                      <asp:DropDownList ID="ddlEmpId" runat="server" Width="100px" AutoPostBack="true" OnSelectedIndexChanged="GetEmpId"></asp:DropDownList>

                    <asp:Label ID="lblEmpName" runat="server" Text="Employee Name:"></asp:Label>
                    <asp:TextBox ID="txtEmpName" runat="server"></asp:TextBox>

                         

               <asp:Button ID="btnSearch" runat="server" Text="Search" />
                      
                    
               <p style="margin-top:30px" />
                      <h3 style="color:red">Enter Deduction Details</h3>
       
                       <asp:Label ID="lblMonth" runat="server" Text="Month:"></asp:Label>
                    <asp:TextBox ID="txtMonth" runat="server" Width="70px"></asp:TextBox>&nbsp;

                      <asp:Label ID="lblYear" runat="server" Text="Year:"></asp:Label>
                    <asp:TextBox ID="txtYear" runat="server" Width="40px"></asp:TextBox>&nbsp;
                         <h4>Deduction Component</h4>
                    <asp:Label ID="lblIncomeTax" runat="server" Text="Income Tax" ></asp:Label>
                    <asp:TextBox ID="txtIncomeTax" runat="server" Width="70px" AutoPostBack="true" OnTextChanged="txtIncome_TaxChanged"></asp:TextBox>       
              
                    <asp:Label ID="lblProvidentFund" runat="server" Text="Provident Fund:"></asp:Label>
                    <asp:TextBox ID="txtProvidentFund" runat="server" Width="70px" AutoPostBack="true" OnTextChanged="txtProvidentFund_TaxChanged"></asp:TextBox>

                      <asp:Label ID="lblProfessionalTax" runat="server" Text="Professional Tax:"></asp:Label>
                    <asp:TextBox ID="txtProfessionalTax" runat="server" Width="70px" AutoPostBack="true" OnTextChanged="txtProfessional_TaxChanged"></asp:TextBox>&nbsp;

                       <asp:Label ID="lblOtherDeduction" runat="server" Text="Other Deduction:"></asp:Label>
                    <asp:TextBox ID="txtOtherDeduction" runat="server" Width="70px" AutoPostBack="true" OnTextChanged="txtOtherDeduction_TaxChanged"></asp:TextBox>&nbsp;

                       <asp:Label ID="lblTotalDeduction" runat="server" Text="Total Deduction:"></asp:Label>
                    <asp:TextBox ID="txtTotalDeduction" runat="server" Width="70px"></asp:TextBox>&nbsp;
                      <p />
                
              

             <asp:Button ID="btnDeductionSave" runat="server" Text="Save" Class="btnSaveSalary" OnClick="btnSaveDeduction_Click"  />
                       <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </div>
                           </td> 
        </tr>
    </table>
</asp:Content>

