<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/AttendanceMaster.master" AutoEventWireup="true" CodeFile="AttendanceEmployee.aspx.cs" Inherits="Employee_AttendanceEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <style>
        .mark-in-section .form-group:first-child {
    margin-top: 20px;
}
        .form-group {
            margin-bottom: 50px; 
        }
    </style>
    <table class="auto-style1" style="height: 353px">
        <tr>
            <td style="vertical-align: top">
                <div >
        <div class="attendance-section">
          
            <div class="mark-in-section">
                <div class="form-group">
                    <label for="lblEmpIdMarkIn">Employee ID:</label>
                    <asp:TextBox ID="txtEmpIdMarkIn" runat="server"></asp:TextBox>
                </div>
            
                <div class="form-group">
                    <label for="lblDateMarkIn">Present Date:</label>
                    <asp:TextBox ID="txtDateMarkIn" runat="server" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
           
            <div class="mark-out-section">
                <div ></div> 
               
                <div class="form-group">
                    <label for="lblMarkInTime">Mark In Time:</label>
                    <asp:TextBox ID="txtMarkInTime" runat="server" ReadOnly="true"></asp:TextBox>
                </div>
                <div ></div> 
               
                <div class="form-group">
                    <label for="lblMarkOutTime">Mark Out Time:</label>
                    <asp:TextBox ID="txtMarkOutTime" runat="server"></asp:TextBox>
                </div>
                 
            </div>
            <div class="total-hours-worked">
                 <div class="form-group-total-hours">
                    <label for="lblTotalHoursWorked">Total Hours Worked:</label>
                    <asp:TextBox ID="txtTotalHoursWorked" runat="server"></asp:TextBox>
                </div>
                
            </div>

        </div>
    </div>

            </td>
        </tr>
    </table>
</asp:Content>

