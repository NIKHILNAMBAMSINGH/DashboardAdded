<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="SearchDepartment.aspx.cs" Inherits="Admin_Department_SearchDepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                 <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/Department/DepartmentDashboard.aspx">Department Dashboard</asp:HyperLink>
                > Search Department
            </h6>
        </div>
        <br />
               <div class="input-group">
    <label for="txtDeptId" style="margin-left:10px;margin-right:10px">Department Code :</label>
                   
    <asp:TextBox ID="txtDeptId" runat="server"  Height="30px"></asp:TextBox>
    <label for="txtDeptName" style="margin-left:20px;margin-right:10px">Department Name :</label>
    <asp:TextBox ID="txtDeptName" runat="server" Height="30px"></asp:TextBox>

                   <label for="lblStatus" style="margin-left:10px;margin-right:10px">Status :</label>
<asp:DropDownList ID="ddlStatus" runat="server" Height="30px" Width="100px">
   <asp:ListItem Text="Active" Value="1"></asp:ListItem>
    <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
    
</asp:DropDownList>
    <br />
                   </div>
                    <div style="margin-top:20px">
                <asp:Button ID="btnSearchDesignation" runat="server" Text="Search" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px;margin-bottom:5px" OnClick="btnSearchDesignation_Click" OnClientClick="return validateForm();"  />
                    <asp:Button ID="btnResetDesignation" runat="server" Text="Reset" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px; margin-bottom:5px" OnClick="btnResetDesignation_Click" />  
       
    </div>                   
           
      
</div>
     <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                 Department List
            </h6>
        </div>
        <div class="card-body">
            <div class="table-responsive">
               <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="4" CellPadding="0"
    DataKeyNames="DeptId" style="margin-left: 0px" EmptyDataText="No data found" ShowHeaderWhenEmpty="true" CssClass="table table-bordered"
    HeaderStyle-CssClass="thead-dark" OnRowDeleting="GridView2_RowDeleting">
    <Columns>
        <asp:BoundField DataField="DeptId" HeaderText="Department ID" SortExpression="DeptId" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="DeptName" HeaderText="Department Name" SortExpression="DeptName" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="AddedDate" HeaderText="Added Date" SortExpression="AddedDate" ItemStyle-CssClass="align-middle" />
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
    <script>
        function validateForm() {
            var deptId = document.getElementById('<%= txtDeptId.ClientID %>').value;
            var deptName = document.getElementById('<%= txtDeptName.ClientID %>').value;

            if (deptId.trim() === '' && deptName.trim() === '') {
                alert('Please fill in at least one field (Department ID or Department Name).');
                return false;
            }
            return true;
        }
</script>


</asp:Content>

