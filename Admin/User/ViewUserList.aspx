<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="ViewUserList.aspx.cs" Inherits="Admin_User_ViewUserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                 <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/User/UserDashboard.aspx">User Dashboard</asp:HyperLink>
            </h6>
        </div>
        <div class="card-body">

            <div class="table-responsive">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="OnPageIndexChanging" PageSize="4" CellPadding="0"
    DataKeyNames="Username" style="margin-left: 0px" EmptyDataText="No data found" ShowHeaderWhenEmpty="true" CssClass="table table-bordered"
    HeaderStyle-CssClass="thead-dark">
    <Columns>
          <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="Password" HeaderText="Passwrord" SortExpression="Password" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" SortExpression="EmployeeName" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="AddedDate" HeaderText="AddedDate" SortExpression="AddedDate" ItemStyle-CssClass="align-middle" />
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

