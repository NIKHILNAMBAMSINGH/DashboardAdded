<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="SalarySearch.aspx.cs" Inherits="Admin_Salary_SalarySearch" %>

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
                <asp:Button ID="btnSearchSalary" runat="server" Text="Search" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px;margin-bottom:5px" OnClick="btnSearchSalary_Click"/>
       
    </div>                  
            </div>
      
           

       <div>
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>

        </div>

    <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                 Salary Lists
            </h6>
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3" CellPadding="0"  OnPageIndexChanging="OnPageIndexChanging"
    DataKeyNames="EarningId" style="margin-left: 0px" ShowHeaderWhenEmpty="true" CssClass="table table-bordered"
    HeaderStyle-CssClass="thead-dark">
    <Columns>
        <asp:BoundField DataField="EarningId" HeaderText="Earning Id" SortExpression="DeptId" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="EmpId" HeaderText="Emp Id" SortExpression="EmpName" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="BasicSalary" HeaderText="Basic Salary" SortExpression="Dob" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="Allowances" HeaderText="Allowances" SortExpression="AddedDate" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="AddedDate" HeaderText="Added Date" SortExpression="AddedDate" ItemStyle-CssClass="align-middle" />
       
    </Columns>
    <PagerSettings Mode="NumericFirstLast" Position="Bottom" />
    <PagerStyle CssClass="justify-content-center" />
    <PagerStyle HorizontalAlign="Center" />
</asp:GridView>

            </div>
        </div>
    </div>
</div>
</asp:Content>

