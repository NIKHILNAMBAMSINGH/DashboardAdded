<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="EmployeeList.aspx.cs" Inherits="Admin_Employee_EmployeeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                 <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/Department/DepartmentDashboard.aspx">Employee</asp:HyperLink>
            </h6>
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="OnPageIndexChanging" PageSize="3" CellPadding="0"
    DataKeyNames="EmpId" style="margin-left: 0px" EmptyDataText="No data found" ShowHeaderWhenEmpty="true" CssClass="table table-bordered"
    HeaderStyle-CssClass="thead-dark">
    <Columns>
        <asp:BoundField DataField="EmpId" HeaderText="Employee ID" SortExpression="DeptId" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="Dob" HeaderText="DOB" SortExpression="Dob" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="AddedDate" HeaderText="Added Date" SortExpression="AddedDate" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number" SortExpression="ContactNumber" ItemStyle-CssClass="align-middle" />
         <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" ItemStyle-CssClass="align-middle" />
         <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" ItemStyle-CssClass="align-middle" />
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

