<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeePage.master" AutoEventWireup="true" CodeFile="EmployeeLeaveList.aspx.cs" Inherits="Employee_Leave_EmployeeLeaveList" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                 <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Employee/Leave/LeaveDashboard.aspx">Leave Dashboard </asp:HyperLink>
                 > Leave List
            </h6>
        </div>
        <br />
               <div class="input-group">
    <label for="lblEmpCode" style="margin-left:10px;margin-right:10px">Employee Code :</label>              
    <asp:TextBox ID="txtEmpCode" runat="server" Width="100px"  Height="30px"></asp:TextBox>
    <label for="lblEmpName" style="margin-left:20px;margin-right:10px">Employee Name :</label>
    <asp:TextBox ID="txtEmpName" runat="server" Height="30px"></asp:TextBox>

                    <label for="txtDeptName" style="margin-left:20px;margin-right:10px">Date From :</label>
                   <asp:TextBox ID="TextBoxLeaveFrom" runat="server" Width="100px" Height="30px"></asp:TextBox>
       <cc1:CalendarExtender ID="CalendarFrom" PopupButtonID="imgPopup" runat="server" TargetControlID="TextBoxLeaveFrom" Format="dd/MM/yyyy"> </cc1:CalendarExtender>

                   <label for="txtDeptName" style="margin-left:20px;margin-right:10px">Date To :</label>
                   <asp:TextBox ID="TextBoxLeaveTo" runat="server" Width="100px" Height="30px"></asp:TextBox>
       <cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="imgPopup" runat="server" TargetControlID="TextBoxLeaveTo" Format="dd/MM/yyyy"> </cc1:CalendarExtender>
                   
                   <div style="margin-top:20px">
                   <label for="lblLeaveStatus" style="margin-left:10px;margin-right:10px">Leave Status:</label>
<asp:DropDownList ID="dddlLeaveStatus" runat="server" Height="30px">
    <asp:ListItem Text="Approved" Value="Approved"></asp:ListItem>
    <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
    <asp:ListItem Text="Rejected" Value="Rejected"></asp:ListItem>
</asp:DropDownList>
                       </div>
    <br />
                    <br />
                    <div style="margin-top:20px">
                <asp:Button ID="ShowLeaveByCode" runat="server" Text="Search" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 50px;margin-bottom:5px" OnClick="ShowLeaveByCode_Click"/>
                    <asp:Button ID="ShowAllLeaves" runat="server" Text="Show All" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px;margin-bottom:5px" OnClick="ShowAllLeaves_Click"/>
         <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
    </div>                   
                 
            </div>
           
      </div>
</div>
     <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                  <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </h6>
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging" CellPadding="0"
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

