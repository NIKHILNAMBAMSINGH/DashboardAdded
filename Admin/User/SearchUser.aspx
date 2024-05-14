<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="SearchUser.aspx.cs" Inherits="Admin_User_SearchUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                 <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/User/UserDashboard.aspx">Username Dashboard</asp:HyperLink>
            </h6>
        </div>
        <br />
               <div class="input-group">
    <label for="txtDeptId" style="margin-left:10px;margin-right:10px">Username :</label>         
    <asp:TextBox ID="txtDeptId" runat="server"  Height="30px"></asp:TextBox>
    
                   <label for="lblStatus" style="margin-left:10px;margin-right:10px">Status :</label>
<asp:DropDownList ID="ddlStatus" runat="server" Height="30px" Width="100px">
   <asp:ListItem Text="Active" Value="1"></asp:ListItem>
    <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
    
</asp:DropDownList>
    
                    <br />
                <asp:Button ID="btnSearchDesignation" runat="server" Text="Search" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px;margin-bottom:5px" OnClick="btnSearchDesignation_Click"  />
                    <asp:Button ID="btnResetDesignation" runat="server" Text="Reset" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px; margin-bottom:5px" OnClick="btnResetDesignation_Click" />  
       
    </div>                   
            </div>
      
</div>
     <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                 Username List
            </h6>
        </div>
        <div class="card-body">
            <div class="table-responsive">
              <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="4" 
    CellPadding="0" DataKeyNames="UserId" style="margin-left: 0px" EmptyDataText="No data found" 
    ShowHeaderWhenEmpty="true" CssClass="table table-bordered" HeaderStyle-CssClass="thead-dark"
    OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating" OnRowCancelingEdit="GridView2_RowCancelingEdit"
    OnRowDeleting="GridView2_RowDeleting">
    <Columns>
        <asp:BoundField DataField="UserId" HeaderText="UserId" SortExpression="UserId" 
            ItemStyle-CssClass="align-middle" ReadOnly="True" />
        <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" 
            ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" 
            ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" SortExpression="EmployeeName" 
            ItemStyle-CssClass="align-middle" ReadOnly="True" />
        <asp:BoundField DataField="AddedDate" HeaderText="Added Date" SortExpression="AddedDate" 
            ItemStyle-CssClass="align-middle" ReadOnly="True" />
        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" ButtonType="Button" />
    </Columns>
    <PagerSettings Mode="NumericFirstLast" Position="Bottom" />
    <PagerStyle CssClass="justify-content-center" HorizontalAlign="Center" />
</asp:GridView>

            </div>
        </div>
    </div>
</div>
</asp:Content>

