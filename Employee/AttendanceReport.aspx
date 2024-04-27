<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/AttendanceMaster.master" AutoEventWireup="true" CodeFile="AttendanceReport.aspx.cs" Inherits="Employee_AttendanceReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>  
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    
    <style>
        .Search-Bar {
        margin-top: 20px;
    }

    .date-from .textbox {
        margin-right: 20px; 
    }
        .Grid-View-div {
            margin-top:20px;
        }

        .Grid-View-Search-Result {
            margin-top:100px;
        }
    </style> 
   
    <table class="auto-style1" style="height: 353px">
        <tr>
            <td style="vertical-align: top">
                 <div class="Search-Bar">
                     <div class="date-from">
                         <asp:Label ID="Label1" runat="server" Text="Date From:"></asp:Label>
                         <asp:TextBox ID="TextBoxFromDate" runat="server" CssClass="textbox"></asp:TextBox>
                          <cc1:CalendarExtender ID="CalendarFrom" PopupButtonID="imgPopup" runat="server" TargetControlID="TextBoxFromDate" Format="dd/MM/yyyy"> </cc1:CalendarExtender> 
                         <asp:Label ID="Label2" runat="server" Text="Date To:"></asp:Label>
                         <asp:TextBox ID="TextBoxToDate" runat="server" CssClass="textbox"></asp:TextBox>
                          <cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="imgPopup" runat="server" TargetControlID="TextBoxToDate" Format="dd/MM/yyyy"> </cc1:CalendarExtender> 
                         <asp:Button ID="ButtonSearch" runat="server" Text="Search" OnClick="ButtonSearch_Click" />
                          <cc1:ToolkitScriptManager ID="toolScriptManageer1" runat="server"></cc1:ToolkitScriptManager> 
                     </div>
                     <div class="Grid-View-Search-Result">
                         <div class="Grid=View-Value">
                        <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" Width="480px" AllowPaging="true"  DataKeyNames="EmpId" PageSize="4" OnPageIndexChanging="GridView1_PageIndexChanging" > 
                     <Columns>
                     <asp:BoundField DataField="EmpId" HeaderText="EmpId" />
                    <asp:BoundField DataField="Date" HeaderText="Date"   DataFormatString="{0:dd/MM/yyyy}"  />
                    <asp:BoundField DataField="TimeIn" HeaderText="Time In" />
                    <asp:BoundField DataField="TimeOut" HeaderText="Time Out"  />
                    <asp:BoundField DataField="TotalHoursWorked" HeaderText="Total Hours Worked" />
                     </Columns>
                                  </asp:GridView>
                         </div>

                     </div>
                
            </td>
            
        </tr>
    </table>
   
</asp:Content>

