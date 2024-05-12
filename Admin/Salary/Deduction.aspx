<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Deduction.aspx.cs" Inherits="Admin_Salary_Deduction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
   <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                 <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/Salary/DashboardSalary.aspx">Salary Dashboard</asp:HyperLink>
                > Add Deduction
            </h6>
        </div>
        <br />
               <div class="input-group">
    <label for="txtEmptId" style="margin-left:10px;margin-right:10px">Employee Code :</label>
                   
    <asp:DropDownList ID="ddlEmpId" runat="server" Width="150px" Height="30px" AutoPostBack="true" OnSelectedIndexChanged="GetEmpId"></asp:DropDownList>
    <label for="lblEmpName" style="margin-left:20px;margin-right:10px">Employee Name :</label>
    <asp:TextBox ID="txtEmpName" runat="server" Height="30px"></asp:TextBox>
     <label for="lblMonth" style="margin-left:20px;margin-right:10px";>Month</label>
    <asp:DropDownList ID="ddlMonth" runat="server" Width="100px" Height="30px"></asp:DropDownList>
    <br />
                    <br />
                <asp:Button ID="btnSearchSalary" runat="server" Text="Search" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px;margin-bottom:5px" OnClick="btnSearchSalary_Click" />
       
    </div>                  
            </div>
      
           

       <div>
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>

        </div>

    <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <br />
               <div class="input-group">
    <label for="lblIncomeTax" style="margin-left:10px;margin-right:10px">Income Tax :</label>
                   
    <asp:TextBox ID="txtIncomeTax" runat="server"  Height="30px" AutoPostBack="true"  OnTextChanged="txtBasicSalary_TextChanged"></asp:TextBox>
    <label for="lblProvidentFund" style="margin-left:20px;margin-right:10px">Provident Fund :</label>
    <asp:TextBox ID="txtProvidentFund" runat="server" Height="30px" AutoPostBack="true" OnTextChanged="txtAllowances_TextChanged"></asp:TextBox>

    <label for="lblProfessionalTax" style="margin-left:20px;margin-right:10px">Professional Tax :</label>
    <asp:TextBox ID="txtProfessionalTax" runat="server" Height="30px" AutoPostBack="true" OnTextChanged="txtBonus_TextChanged"></asp:TextBox>
                   
          <div style="margin-top:30px">         
                  <label for="lblOtherDeduction" style="margin-left:10px;margin-right:10px">Other Deduction :</label>
    <asp:TextBox ID="txtOtherDeduction" runat="server" Height="30px" AutoPostBack="true" OnTextChanged="txtMiscellaneous_TextChanged"></asp:TextBox>

  <label for="lblAttedanceDeduction" style="margin-left:10px;margin-right:10px">Attendance Deduction :</label>
    <asp:TextBox ID="txtAttendanceDeduction" runat="server" Height="30px"></asp:TextBox>
            
              <div style="margin-top:30px">
                <label for="lblLeaveDeduction" style="margin-left:10px;margin-right:10px">Leave Deduction :</label>
    <asp:TextBox ID="txtLeaveDeduction" runat="server" Height="30px"></asp:TextBox>


              <label for="lblTotalEarning" style="margin-left:10px;margin-right:10px">Total Deduction :</label>
    <asp:TextBox ID="txtTotalEarning" runat="server" Height="30px"></asp:TextBox>

                  </div>
    </div> 
             
                   
       
    </div>                  
            </div>
        <div>
            <asp:Button ID="btnSaveSalary" runat="server" Text="Add Department" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px;margin-bottom:5px"  OnClick="btnSaveSalary_Click" />
        </div>
     
        </div>
  
</asp:Content>

