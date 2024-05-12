<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeePage.master" AutoEventWireup="true" CodeFile="Salary.aspx.cs" Inherits="Employee_Salary_Salary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
   <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                 <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Employee/EmptyPage.aspx">Dashboard</asp:HyperLink>
                > Search Salary
            </h6>
        </div>
        <br />
               <div class="input-group">

   <label for="txtDeptId" style="margin-left:10px;margin-right:10px">Employee Code :</label>
    <asp:TextBox ID="txtEmpCode" runat="server"  Height="30px" Width="100px"></asp:TextBox>
   
                   <label for="txtDeptName" style="margin-left:20px;margin-right:10px">Employee Name :</label>
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

                   <label for="lblLeaveStatus" style="margin-left:10px;margin-right:10px">Type :</label>
<asp:DropDownList ID="dddType" runat="server" Height="30px" Width="100px">
    <asp:ListItem Text="Earning" Value="EarningDetailsTbl"></asp:ListItem>
    <asp:ListItem Text="Deduction" Value="DeductionDetailsTbl"></asp:ListItem>
</asp:DropDownList>
    <br />
                    <br />
                   
               
       
    </div>     
        <div style="margin-top:20px">
         <asp:Button ID="btnSearchSalary" runat="server" Text="Search" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px;margin-bottom:5px" OnClick="btnSearchSalary_Click" />            
            </div>

        </div>
       </div>

      <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                  <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </h6>
        </div>
        <div class="card-body">
            <div class="table-responsive">
              <asp:GridView ID="GridViewEarning" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" CellPadding="0"
    DataKeyNames="EarningId" ShowHeaderWhenEmpty="true" CssClass="table table-bordered"
    HeaderStyle-CssClass="thead-dark">
    <Columns>
        <asp:BoundField DataField="EarningId" HeaderText="Earning Id" SortExpression="EarningId" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="EmpId" HeaderText="Employee Code" SortExpression="EmpId" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="BasicSalary" HeaderText="Basic Salary" SortExpression="BasicSalary" ItemStyle-CssClass="align-middle" />
         <asp:BoundField DataField="Allowances" HeaderText="Allowances" SortExpression="BasicSalary" ItemStyle-CssClass="align-middle" />
         <asp:BoundField DataField="Bonus" HeaderText="Bonus" SortExpression="BasicSalary" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="AddedDate" HeaderText="Added Date" SortExpression="AddedDate" ItemStyle-CssClass="align-middle" />
    </Columns>
    <PagerSettings Mode="NumericFirstLast" Position="Bottom" />
    <PagerStyle CssClass="justify-content-center" />
    <PagerStyle HorizontalAlign="Center" />
</asp:GridView>

<asp:GridView ID="GridViewDeduction" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" CellPadding="0"
    DataKeyNames="DeductionId" ShowHeaderWhenEmpty="true" CssClass="table table-bordered"
    HeaderStyle-CssClass="thead-dark">
    <Columns>
        <asp:BoundField DataField="DeductionId" HeaderText="Deduction Id" SortExpression="DeductionId" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="EmpId" HeaderText="Employee Code" SortExpression="EmpId" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="ProvidentFund" HeaderText="Provident Fund" SortExpression="EmpId" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="ProfessionalTax" HeaderText="Professional Tax" SortExpression="EmpId" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="AttendanceDeduction" HeaderText="Attendance Deduction" SortExpression="EmpId" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="LeaveDeduction" HeaderText="Leave Deduction" SortExpression="EmpId" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="OtherDeduction" HeaderText="Other Deductions" SortExpression="OtherDeductions" ItemStyle-CssClass="align-middle" />
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

