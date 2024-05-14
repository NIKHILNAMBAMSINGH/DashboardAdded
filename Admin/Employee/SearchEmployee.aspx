<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="SearchEmployee.aspx.cs" Inherits="Admin_Employee_SearchEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                 <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/Employee/EmployeeDashboard.aspx">Employee Dashboard</asp:HyperLink>
                > Search Employee
            </h6>
        </div>
        <br />
               <div class="input-group">
    <label for="txtDeptId" style="margin-left:10px;margin-right:10px">Employee Code :</label>
                   
    <asp:TextBox ID="txtDeptId" runat="server"  Height="30px"></asp:TextBox>
    <label for="txtDeptName" style="margin-left:20px;margin-right:10px">Employee Name :</label>
    <asp:TextBox ID="txtDeptName" runat="server" Height="30px"></asp:TextBox>

                    <label for="lblStatus" style="margin-left:10px;margin-right:10px">Status :</label>
<asp:DropDownList ID="ddlStatus" runat="server" Height="30px" Width="100px">
   <asp:ListItem Text="Active" Value="1"></asp:ListItem>
    <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
    
</asp:DropDownList>
    </div>
                 <div style="margin-top:30px">
                <asp:Button ID="btnSearchDesignation" runat="server" Text="Search" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px;margin-bottom:5px" OnClick="btnSearchDesignation_Click"  />
                    <asp:Button ID="btnResetDesignation" runat="server" Text="Reset" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px; margin-bottom:5px" OnClick="btnResetDesignation_Click" />  
       
    </div>                   
            </div>
      
</div>
     <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                 Employee List
            </h6>
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3" CellPadding="0"
    DataKeyNames="EmpId" style="margin-left: 0px" ShowHeaderWhenEmpty="true" CssClass="table table-bordered"
    HeaderStyle-CssClass="thead-dark" OnRowDeleting="GridView2_RowDeleting" >
    <Columns>
        <asp:BoundField DataField="EmpId" HeaderText="Employee Code" SortExpression="DeptId" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="EmpName" HeaderText="Employee Name" SortExpression="EmpName" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="Dob" HeaderText="DOB" SortExpression="Dob" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number" SortExpression="ContactNumber" ItemStyle-CssClass="align-middle" />
         <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" ItemStyle-CssClass="align-middle" />
         <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" ItemStyle-CssClass="align-middle" />
       <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
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

