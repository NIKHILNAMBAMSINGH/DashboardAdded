<<<<<<< HEAD
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Designation/Designation.master" AutoEventWireup="true" CodeFile="DesignationList.aspx.cs" Inherits="Admin_Designation_DesignationList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
     <table class="auto-style1" style="height: 335px">
        <tr>
            <td style="width: 399px; vertical-align: top;">
                
                 <h3 style="color:red">Department List</h3>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="OnPageIndexChanging" PageSize="4" CellPadding="0"
                        DataKeyNames="DesignationId" style="margin-left: 0px" EmptyDataText="No data found" ShowHeaderWhenEmpty="true">
                        <Columns>
                            <asp:BoundField DataField="DesignationId" HeaderText="Department ID" SortExpression="DeptId" />
                            <asp:BoundField DataField="DesignationName" HeaderText="Department Name" SortExpression="DeptName" />
                            <asp:BoundField DataField="AddedDate" HeaderText="Added Date" SortExpression="AddedDate" />
                        </Columns>
                    </asp:GridView>
            </td>
            
              
        </tr>
    </table>
=======
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="DesignationList.aspx.cs" Inherits="Admin_Designation_DesignationList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                 <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/Department/DepartmentDashboard.aspx">Designation Dashboard</asp:HyperLink>
            </h6>
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="OnPageIndexChanging" PageSize="4" CellPadding="0"
    DataKeyNames="DesignationId" style="margin-left: 0px" EmptyDataText="No data found" ShowHeaderWhenEmpty="true" CssClass="table table-bordered"
    HeaderStyle-CssClass="thead-dark">
   <Columns>
                            <asp:BoundField DataField="DesignationId" HeaderText="Designation ID" SortExpression="DesignationtId" />
                            <asp:BoundField DataField="DesignationName" HeaderText="Designation Name" SortExpression="DesignationName" />
                            <asp:BoundField DataField="AddedDate" HeaderText="Added Date" SortExpression="AddedDate" />
                        </Columns>
    <PagerSettings Mode="NumericFirstLast" Position="Bottom" />
    <PagerStyle CssClass="justify-content-center" />
    <PagerStyle HorizontalAlign="Center" />
</asp:GridView>

            </div>
        </div>
    </div>
</div>
>>>>>>> cb92eb5b2e9038612fdacf5d98757c880099271b
</asp:Content>

