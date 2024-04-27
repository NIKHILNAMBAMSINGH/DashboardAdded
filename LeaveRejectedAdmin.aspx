<%@ Page Title="" Language="C#" MasterPageFile="~/LeaveAdmin.master" AutoEventWireup="true" CodeFile="LeaveRejectedAdmin.aspx.cs" Inherits="LeaveRejectedAdmin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    
                <table class="auto-style1" style="height: 335px">
                    <tr>
                        <td style="height: 149px; vertical-align: top;">
                            
                            <table class="auto-style1" style="height: 106px">
                                <tr>
                                    <td style="height: 69px; vertical-align: top;">
                                        <table class="auto-style1" style="height: 81px">
                                            <tr>
                                                <td class="auto-style4" style="width: 39px; height: 73px">&nbsp;From</td>
                                                <td style="width: 175px; height: 73px">
                                                    <asp:TextBox ID="TextBoxLeaveFrom" runat="server"></asp:TextBox>
                                                     <cc1:CalendarExtender ID="CalendarFrom" PopupButtonID="imgPopup" runat="server" TargetControlID="TextBoxLeaveFrom" Format="dd/MM/yyyy"> </cc1:CalendarExtender> 
                                                </td>
                                                <td class="auto-style2" style="width: 23px; height: 73px">&nbsp;&nbsp;&nbsp;&nbsp;To</td>
                                                <td style="width: 191px; height: 73px">
                                                    <asp:TextBox ID="TextBoxLeaveTo" runat="server"></asp:TextBox>
                                                      <cc1:CalendarExtender ID="CalendarTo" PopupButtonID="imgPopup" runat="server" TargetControlID="TextBoxLeaveTo" Format="dd/MM/yyyy"> </cc1:CalendarExtender>  
                                                </td>
                                                <td style="height: 73px">
                                                    <cc1:ToolkitScriptManager ID="toolScriptManageer1" runat="server"></cc1:ToolkitScriptManager>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="vertical-align: middle">
                                        &nbsp;
                                        <asp:Button ID="BtnSearch" runat="server" Text="Search" Width="68px" OnClick="BtnSearch_Click" />
                                    </td>
                                </tr>
                            </table>
                            
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top" >
   <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" DataKeyNames="LeaveId" 
        AllowPaging="True" PageSize="2" OnPageIndexChanging="GridView1_PageIndexChanging" EmptyDataText="No data found" ShowHeaderWhenEmpty="true"> 
   <Columns>
    <asp:BoundField DataField="LeaveId" HeaderText="LeaveId" ReadOnly="true"  />
        <asp:BoundField DataField="EmpId" HeaderText="EmpId" ReadOnly="true"  />
    <asp:BoundField DataField="LeaveType" HeaderText="Leave Type"  ReadOnly="true" />
    <asp:BoundField DataField="StartDate" HeaderText="Leave From"  DataFormatString="{0:dd/MM/yyyy}" />
    <asp:BoundField DataField="EndDate" HeaderText="Leave To"  DataFormatString="{0:dd/MM/yyyy}" />
    <asp:BoundField DataField="NoOfDays" HeaderText="No Of Days"  />
    <asp:BoundField DataField="LeaveStatus" HeaderText="Status"  />
    <asp:BoundField DataField="Reason" HeaderText="Reason" />
    <asp:BoundField DataField="AddedDate" HeaderText="Applied Date" DataFormatString="{0:dd/MM/yyyy}"/>
    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
</Columns>
                 
                 <HeaderStyle Width="100px" />
                 <PagerStyle Width="100px" />
                 
</asp:GridView></td>
                    </tr>
                </table>
           
</asp:Content>


