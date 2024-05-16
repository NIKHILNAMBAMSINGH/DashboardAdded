<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="AddDepartment.aspx.cs" Inherits="Admin_Department_AddDepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                 <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/Department/DepartmentDashboard.aspx">Department Dashboard</asp:HyperLink>
                > Add Department
            </h6>
        </div>
        <br />
               <div class="input-group">
    <label for="txtDeptId" style="margin-left:10px;margin-right:10px">Department Code :</label>
                   
    <asp:TextBox ID="txtDeptId" runat="server"  Height="30px" ></asp:TextBox>
    <label for="txtDeptName" style="margin-left:20px;margin-right:10px">Department Name :</label>
    <asp:TextBox ID="txtDeptName" runat="server" Height="30px"></asp:TextBox>
    <br />
                    <br />
                   </div>
        <div style="margin-top:20px">
                <asp:Button ID="btnSearchDesignation" runat="server" Text="Add Department" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px;margin-bottom:5px"  OnClick="btnAddDesignation_Click" OnClientClick="return validateForm();" />
                    <asp:Button ID="btnResetDepartment" runat="server" Text="Reset Department" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px;margin-bottom:5px"  OnClick="btnAddDesignation_Click" />
                   
   
                     
            </div>
      <div>
           <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
</div>
        </div>
    <script>
        function validateForm() {
            var deptId = document.getElementById('<%= txtDeptId.ClientID %>').value;
            var deptName = document.getElementById('<%= txtDeptName.ClientID %>').value;

            if (deptId.trim() === '' || deptName.trim() === '') {
                alert('Please fill in all the details.');
                return false;
            } else {
                return true;
            }
        }
</script>
</asp:Content>

