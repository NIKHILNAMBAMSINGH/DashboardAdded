<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="LeaveList.aspx.cs" Inherits="Admin_Leave_LeaveList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                 <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/Leave/LeaveDashboard.aspx">Leave Dashboard </asp:HyperLink>
                 > Approved Leave 
            </h6>
        </div>
        <br />
               <div class="input-group">
    <label for="txtDeptId" style="margin-left:10px;margin-right:10px">Employee ID :</label>
                   
    <asp:TextBox ID="txtDeptId" runat="server" Width="100px"  Height="30px"></asp:TextBox>
    <label for="txtDeptName" style="margin-left:20px;margin-right:10px">Employee Name :</label>
    <asp:TextBox ID="txtDeptName" runat="server" Height="30px"></asp:TextBox>

                    <label for="txtDeptName" style="margin-left:20px;margin-right:10px">Date From :</label>
                   <asp:TextBox ID="TextBoxLeaveFrom" runat="server" Width="100px" Height="30px"></asp:TextBox>
       <cc1:CalendarExtender ID="CalendarFrom" PopupButtonID="imgPopup" runat="server" TargetControlID="TextBoxLeaveFrom" Format="dd/MM/yyyy"> </cc1:CalendarExtender>

                   <label for="ddlGender" style="margin-left:10px;margin-right:10px">Leave Status:</label>
<asp:DropDownList ID="ddlGender" runat="server" Height="30px">
    <asp:ListItem Text="Approved" Value="Approved"></asp:ListItem>
    <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
    <asp:ListItem Text="Rejected" Value="Rejected"></asp:ListItem>
</asp:DropDownList>
    <br />
                    <br />
                <asp:Button ID="BtnSearchLeave" runat="server" Text="Search" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px;margin-bottom:5px" OnClick="BtnSearchLeave_Click" />
                    <asp:Button ID="BtnShowAll" runat="server" Text="Show All" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px;margin-bottom:5px" OnClick="BtnShowAll_Click" />
         <cc1:ToolkitScriptManager ID="toolScriptManageer1" runat="server"></cc1:ToolkitScriptManager>
    </div>                   
            </div>
      
</div>
     <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                 Leave Approved List
            </h6>
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" CellPadding="0" OnPageIndexChanging="OnPageIndexChanging"
    DataKeyNames="LeaveId" style="margin-left: 0px" ShowHeaderWhenEmpty="true" CssClass="table table-bordered"
    HeaderStyle-CssClass="thead-dark">
    <Columns>
     <asp:BoundField DataField="LeaveId" HeaderText="LeaveId" SortExpression="DeptId" ItemStyle-CssClass="align-middle" />
       <asp:BoundField DataField="EmpName" HeaderText="Employee Name" SortExpression="EmpName" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="EmpId" HeaderText="EmpId" SortExpression="Dob" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="AddedDate" HeaderText="Added Date" SortExpression="AddedDate" ItemStyle-CssClass="align-middle" />
       <asp:BoundField DataField="LeaveType" HeaderText="Leave Type" ItemStyle-CssClass="align-middle" />
        <asp:BoundField DataField="NoOfDays" HeaderText="No Of Days" SortExpression="ContactNumber" ItemStyle-CssClass="align-middle" />
         <asp:BoundField DataField="LeaveStatus" HeaderText="Status"  SortExpression="Email" ItemStyle-CssClass="align-middle" />
           <asp:BoundField DataField="Reason" HeaderText="Reason"  SortExpression="Email" ItemStyle-CssClass="align-middle" />
          <asp:BoundField DataField="StartDate" HeaderText="Leave From" DataFormatString="{0:dd/MM/yyyy}" SortExpression="Email" ItemStyle-CssClass="align-middle" />
             <asp:BoundField DataField="EndDate" HeaderText="Leave To"  DataFormatString="{0:dd/MM/yyyy}" SortExpression="Email" ItemStyle-CssClass="align-middle" />
        
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

