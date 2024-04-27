<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/LeaveMaster.master" AutoEventWireup="true" CodeFile="ApplyForLeave.aspx.cs" Inherits="Employee_ApplyForLeave" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>  
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <style>
        .successOrFail {
            margin-left:30px;
        }
    </style>
    <table class="auto-style1" style="height: 353px; width: 101%;">
        <tr>
            <td style="width: 110px; height: 37px">Leave Type</td>
            <td class="auto-style5" style="height: 37px">
                &nbsp;<asp:DropDownList ID="DropDownListLeaveType" runat="server" Height="19px" Width="114px">
                            <asp:ListItem Text="Casual Leave" Value="Casual Leave"></asp:ListItem>
                            <asp:ListItem Text="Unpaid Leave" Value="Unpaid Leave"></asp:ListItem>
                    
                </asp:DropDownList>
                <asp:Label ID="LabelForConfirm" runat="server" Class="successOrFail" Text=""></asp:Label>
            </td>
             
        </tr>
        <tr> 
            <td style="width: 110px; height: 5px">Leave From</td>
            <td class="auto-style5" style="height: 5px">
                <table class="auto-style1" style="height: 68px">
                    <tr>
                        <td style="width: 241px">
                            <asp:TextBox ID="TextBoxLeaveFrom" runat="server" Height="18px" Width="102px"  AutoPostBack="true" OnTextChanged="TextBoxLeaveFrom_TextChanged" ></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarFrom" PopupButtonID="imgPopup" runat="server" TargetControlID="TextBoxLeaveFrom" Format="dd/MM/yyyy"> </cc1:CalendarExtender> 
                        </td>
                        <td> <cc1:ToolkitScriptManager ID="toolScriptManageer1" runat="server"></cc1:ToolkitScriptManager>  </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 110px; height: 53px">Leave to </td>
            <td class="auto-style5" style="height: 53px">
                <asp:TextBox ID="TextBoxLeaveTo" runat="server" Height="18px" Width="102px" AutoPostBack="true" OnTextChanged="TextBoxLeaveTo_TextChanged"></asp:TextBox>
                  <cc1:CalendarExtender ID="CalendarTo" PopupButtonID="imgPopup" runat="server" TargetControlID="TextBoxLeaveTo" Format="dd/MM/yyyy" OnClientDateSelectionChanged="checkDateSelection"> </cc1:CalendarExtender>  
            </td>
        </tr>
        <tr>
            <td style="width: 110px; height: 57px">No of Days</td>
            <td style="height: 57px">
              
                <table class="auto-style1" style="height: 57px">
                    <tr>
                        <td style="width: 145px">
                      <asp:TextBox ID="TextBoxNoOfLeave" runat="server" Height="18px" Width="100px"></asp:TextBox>
                        </td>
                        <td> 
                            
                            &nbsp;&nbsp;Reason
                            <asp:TextBox ID="TextBoxLeaveReason" runat="server" style="margin-left: 21px" Width="151px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="mail" runat="server" ControlToValidate="TextBoxLeaveReason" ErrorMessage="Please enter an email(This field is required)" ForeColor="Red"></asp:RequiredFieldValidator>  
                            
                        </td>
                    </tr>
                </table>
              
            </td>
        </tr>
        <tr>
            <td style="width: 110px; height: 21px"></td>
            <td style="height: 21px; vertical-align: top;">
                <asp:Button ID="BtnSubmitLeave" runat="server" Text="Submit Leave" OnClick="BtnSubmitLeave_Click" style="margin-top: 0px"  />
            </td>
        </tr>
    </table>
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

