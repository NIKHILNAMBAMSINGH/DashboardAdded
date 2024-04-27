<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Department/Department.master" AutoEventWireup="true" CodeFile="SearchDepartment.aspx.cs" Inherits="Admin_Department_SearchDepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
     <table class="auto-style1" style="height: 335px">
        <tr>
            <td style="width: 399px; vertical-align: top;">
                <h3 style="color:red">Search Department</h3>
                <div id="inputTable">
                    <label for="txtDeptId">Department ID:</label>
                    <asp:TextBox ID="txtDeptId" runat="server"></asp:TextBox>
                    <label for="txtDeptName">Department Name:</label>
                    <asp:TextBox ID="txtDeptName" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="btnSearchDesignation" runat="server" Text="Search Designation" OnClick="btnSearchDesignation_Click" />
                    <asp:Button ID="btnResetDesignation" runat="server" Text="Reset" OnClick="btnResetDesignation_Click" />
                </div>
                 <h3 style="color:red">Department Details</h3>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="0"
                        DataKeyNames=" DeptId" style="margin-left: 0px" Width="544px">
                        <Columns>
                            <asp:BoundField DataField="DeptId" HeaderText="Department ID" SortExpression="DeptId" />
                            <asp:BoundField DataField="DeptName" HeaderText="Department Name" SortExpression="DeptName" />
                            <asp:BoundField DataField="AddedDate" HeaderText="Added Date" SortExpression="AddedDate" />
                        </Columns>
                    </asp:GridView>
            </td>
            
              
        </tr>
    </table>
</asp:Content>

