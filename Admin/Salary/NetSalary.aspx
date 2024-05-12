<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="NetSalary.aspx.cs" Inherits="Admin_Salary_NetSalary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                 <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/Salary/DashboardSalary.aspx">Salary Dashboard</asp:HyperLink>
                > Net Salary
            </h6>
        </div>
        <br />
               <div class="input-group">
    <label for="txtEmptId" style="margin-left:10px;margin-right:10px">Employee Code :</label>
                   
    <asp:DropDownList ID="ddlEmpId" runat="server" Width="150px" Height="30px" AutoPostBack="true" OnSelectedIndexChanged="GetEmpId"></asp:DropDownList>
    <label for="lblEmpName" style="margin-left:20px;margin-right:10px">Employee Name :</label>
    <asp:TextBox ID="txtEmpName" runat="server" Height="30px"></asp:TextBox>
   <label for="lblMonth" style="margin-left:10px;margin-right:10px">Month :</label>
<asp:DropDownList ID="ddlMonth" runat="server" Height="30px" Width="100px">
   <asp:ListItem Text="January" Value="January"></asp:ListItem>
    <asp:ListItem Text="February" Value="February"></asp:ListItem>
    <asp:ListItem Text="March" Value="March"></asp:ListItem>
    <asp:ListItem Text="April" Value="April"></asp:ListItem>
    <asp:ListItem Text="May" Value="May"></asp:ListItem>
    <asp:ListItem Text="June" Value="June"></asp:ListItem>
    <asp:ListItem Text="July" Value="July"></asp:ListItem>
    <asp:ListItem Text="August" Value="August"></asp:ListItem>
    <asp:ListItem Text="September" Value="September"></asp:ListItem>
    <asp:ListItem Text="October" Value="October"></asp:ListItem>
    <asp:ListItem Text="November" Value="November"></asp:ListItem>
    <asp:ListItem Text="December" Value="December"></asp:ListItem>
</asp:DropDownList>
    <br />
                    <br />
                <asp:Button ID="btnSearchSalary" runat="server" Text="Search" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px;margin-bottom:5px" OnClick="btnSearchSalary_Click"/>
       
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
    <label for="lblNetTotalEarning" style="margin-left:10px;margin-right:10px">Total Earning :</label>
                   
    <asp:TextBox ID="txtNetTotalEarning" runat="server"  Height="30px" ></asp:TextBox>
  
                     <label for="lblNetTotalDeduction" style="margin-left:20px;margin-right:10px">Total Deduction :</label>
    <asp:TextBox ID="txtNetTotalDeduction" runat="server" Height="30px"> </asp:TextBox>

    <label for="lblNetPayable" style="margin-left:20px;margin-right:10px">Net Payable :</label>
    <asp:TextBox ID="txtNetPayable" runat="server" Height="30px"></asp:TextBox>
                  

    </div> 
             
                   
       
    
            </div>
        <div>
            <asp:Button ID="btnSaveNetSalary" runat="server" Text="Add Payable" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px;margin-bottom:5px" OnClick="btnSaveNetSalary_Click" />
        </div>
     
        </div>





</asp:Content>

