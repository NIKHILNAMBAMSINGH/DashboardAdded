<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeePage.master" AutoEventWireup="true" CodeFile="EmptyPage.aspx.cs" Inherits="Employee_EmptyPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                 Holiday Lists
            </h6>
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="0"
    DataKeyNames="HolidayId" style="margin-left: 0px" ShowHeaderWhenEmpty="true" CssClass="table table-bordered"
    HeaderStyle-CssClass="thead-dark">
    <Columns>
        <asp:BoundField DataField="HolidayName" HeaderText="Holiday Name" SortExpression="DeptId" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="HolidayDate" HeaderText="Holiday Date" SortExpression="EmpName" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="HolidayDay" HeaderText="Holiday Day" SortExpression="Dob" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="HolidayMonth" HeaderText="Holiday Month" SortExpression="AddedDate" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="AddedDate" HeaderText="Added Date" SortExpression="AddedDate" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="align-middle" />
       
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

