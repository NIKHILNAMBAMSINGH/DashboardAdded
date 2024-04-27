<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Welcome/Welcome.master" AutoEventWireup="true" CodeFile="EmptyWelcome.aspx.cs" Inherits="Employee_Welcome_EmptyWelcome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
     <table class="auto-style1" style="height: 100%">

          <tr>
              <div style="margin-top:100px">
                <h3 style="fit-position:center">Welcome Admin</h3>  

              </div>
          </tr>
        <tr>
            <td style="height: 100%; vertical-align: top;">
                <asp:Label ID="lblDepartments" runat="server" Text="Number of Departments:"></asp:Label>
                <asp:Label ID="lblDepartmentsValue" runat="server"></asp:Label><br />
                <asp:Label ID="lblEmployees" runat="server" Text="Number of Employees:"></asp:Label>
                <asp:Label ID="lblEmployeesValue" runat="server"></asp:Label><br />
                <asp:Label ID="lblLeave" runat="server" Text="Total Number of Leave Applied:"></asp:Label>
                <asp:Label ID="lblLeaveValue" runat="server"></asp:Label><br />
                <asp:Label ID="lblDate" runat="server" Text="Date:"></asp:Label>
                <asp:Label ID="lblDateValue" runat="server"></asp:Label><br />
                <asp:Label ID="lblTime" runat="server" Text="Time:"></asp:Label>
                <asp:Label ID="lblTimeValue" runat="server" Text='2'></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

