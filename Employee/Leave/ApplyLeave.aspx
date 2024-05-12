<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeePage.master" AutoEventWireup="true" CodeFile="ApplyLeave.aspx.cs" Inherits="Employee_Leave_ApplyLeave" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                 <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Employee/Leave/LeaveDashboard.aspx">Leave Dashboard</asp:HyperLink>
                > Apply Leave 
            </h6>
        </div>
        <br />
               <div class="input-group">
    <label for="txtDeptId" style="margin-left:10px;margin-right:10px">Employee Code :</label>
    <asp:TextBox ID="txtEmpCode" runat="server"  Height="30px"></asp:TextBox>
   
                   <label for="txtDeptName" style="margin-left:20px;margin-right:10px">Employee Name :</label>
    <asp:TextBox ID="txtEmpName" runat="server" Height="30px"></asp:TextBox>

                    <label for="ddlGender" style="margin-left:10px;margin-right:10px">Leave Type:</label>
<asp:DropDownList ID="DropDownListLeaveType" runat="server" Height="30px">
    <asp:ListItem Text="Paid Leave" Value="Paid Leave"></asp:ListItem>
    <asp:ListItem Text="Unpaid Leave" Value="Unpaid Leave"></asp:ListItem>
    </asp:DropDownList>
                   <div style="margin-top:30px">
                    <label for="txtDeptName" style="margin-left:20px;margin-right:10px">Date From :</label>
                   <asp:TextBox ID="TextBoxLeaveFrom" runat="server" Width="100px" Height="30px" AutoPostBack="true" OnTextChanged="TextBoxLeaveFrom_TextChanged"></asp:TextBox>
       <cc1:CalendarExtender ID="CalendarFrom" PopupButtonID="imgPopup" runat="server" TargetControlID="TextBoxLeaveFrom" Format="dd/MM/yyyy" > </cc1:CalendarExtender>

                   
                    <label for="txtDeptName" style="margin-left:20px;margin-right:10px">Date To :</label>
                   <asp:TextBox ID="TextBoxLeaveTo" runat="server" Width="100px" Height="30px" AutoPostBack="true" OnTextChanged="TextBoxLeaveTo_TextChanged"></asp:TextBox>
       <cc1:CalendarExtender ID="CalendarTo" PopupButtonID="imgPopup" runat="server" TargetControlID="TextBoxLeaveTo" OnClientDateSelectionChanged="checkDateSelection" Format="dd/MM/yyyy"> </cc1:CalendarExtender>

  </div>
                    
<div style="margin-top:30px">
     <label for="txtLeaveReason" style="margin-left:10px;margin-right:10px">Leave Reason :</label>
    <asp:TextBox ID="txtLeaveReason" runat="server"  Height="30px"></asp:TextBox>

     <label for="txtLeaveNoOfDays" style="margin-left:10px;margin-right:10px">No of Days :</label>
    <asp:TextBox ID="txtBoxNoOfDays" runat="server"  Height="30px" Width="80px"></asp:TextBox>


   </div>
                    
            </div>
        
                   <div style="margin-top:30px">
   
                <asp:Button ID="btnSearchDesignation" runat="server" Text="Apply Leave" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px;margin-bottom:5px" OnClick="BtnSubmitLeave_Click"  />
                    
       
                   <cc1:ToolkitScriptManager ID="toolScriptManageer1" runat="server"></cc1:ToolkitScriptManager>
    </div>              
      </div>

         <div>
           <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
</div>
        

    <script type="text/javascript">
        function checkDateSelection(sender, args) {
            var leaveFrom = new Date(document.getElementById('<%=TextBoxLeaveFrom.ClientID %>').value);
            var leaveTo = new Date(document.getElementById('<%=TextBoxLeaveTo.ClientID %>').value);
            if (leaveTo < leaveFrom) {
                alert("You cannot select date before Leave From date.");
                args.set_cancel(true);
            } else if (leaveTo.getTime() === leaveFrom.getTime()) {
                alert("You cannot select date same as From Leave Date.")
                args.set_cancel(true);

            }
        }
    </script>
</asp:Content>

