<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="AddSalary.aspx.cs" Inherits="Admin_Salary_AddSalary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                 <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/Salary/DashboardSalary.aspx">Salary Dashboard</asp:HyperLink>
                > Add Salary
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
    <label for="lblBasicSalary" style="margin-left:10px;margin-right:10px">Basic Salary :</label>
                   
    <asp:TextBox ID="txtBasicSalary" runat="server"  Height="30px" AutoPostBack="true"  OnTextChanged="txtBasicSalary_TextChanged"></asp:TextBox>
    <label for="lblAllowances" style="margin-left:20px;margin-right:10px">Allowances :</label>
    <asp:TextBox ID="txtAllowances" runat="server" Height="30px" AutoPostBack="true" OnTextChanged="txtAllowances_TextChanged"></asp:TextBox>

    <label for="lblBonus" style="margin-left:20px;margin-right:10px">Bonus :</label>
    <asp:TextBox ID="txtBonus" runat="server" Height="30px" AutoPostBack="true" OnTextChanged="txtBonus_TextChanged"></asp:TextBox>
                   <br />
                   <br />
          <div style="margin-top:20px">         
                  <label for="lblMiscellaneous" style="margin-left:10px;margin-right:10px">Miscellaneous :</label>
    <asp:TextBox ID="txtMiscellaneous" runat="server" Height="30px" AutoPostBack="true" OnTextChanged="txtMiscellaneous_TextChanged"></asp:TextBox>

              <label for="lblTotal Earning" style="margin-left:10px;margin-right:10px">Total Earning :</label>
    <asp:TextBox ID="txtTotalEarning" runat="server" Height="30px"></asp:TextBox>


    </div> 
             
                   
       
    </div>                  
            </div>
        <div>
            <asp:Button ID="btnSaveSalary" runat="server" Text="Add Department" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px;margin-bottom:5px"  OnClick="btnSaveSalary_Click" />
        </div>
     
        </div>
  


</asp:Content>

