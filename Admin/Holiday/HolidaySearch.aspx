<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="HolidaySearch.aspx.cs" Inherits="Admin_Holiday_HolidaySearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                 <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/Holiday/HolidayDashboard.aspx">Holiday Dashboard</asp:HyperLink>
                > Search Holiday
            </h6>
        </div>
        <br />
               <div class="input-group">
    <label for="lblDeptId" style="margin-left:10px;margin-right:10px">Holiday Name :</label>
                   
    <asp:TextBox ID="txtHolidayName" runat="server"  Height="30px"></asp:TextBox>
    <label for="lblHolidayDate" style="margin-left:20px;margin-right:10px">Holiday Date :</label>
    <asp:TextBox ID="txtHolidayDate" runat="server" Height="30px"></asp:TextBox>
    <br />
                    <br />
                <asp:Button ID="btnSearchDesignation" runat="server" Text="Search" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px;margin-bottom:5px" OnClick="btnSearchDesignation_Click"  />
                   <asp:Button ID="btnShowAllHolidayLists" runat="server" Text="Show All Lists" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px;margin-bottom:5px" OnClick="btnShowAllHolidayLists_Click"  />
       
    </div>                   
            </div>
      
</div>

     <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                 Holiday Lists
            </h6>
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3" CellPadding="0"  OnPageIndexChanging="OnPageIndexChanging"
    DataKeyNames="HolidayId" style="margin-left: 0px" ShowHeaderWhenEmpty="true" CssClass="table table-bordered"
    HeaderStyle-CssClass="thead-dark">
    <Columns>
        <asp:BoundField DataField="HolidayName" HeaderText="Holiday Name" SortExpression="DeptId" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="HolidayDate" HeaderText="Holiday Date" SortExpression="EmpName" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="HolidayDay" HeaderText="Holiday Day" SortExpression="Dob" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="HolidayMonth" HeaderText="Holiday Month" SortExpression="AddedDate" ItemStyle-CssClass="align-middle" />
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

