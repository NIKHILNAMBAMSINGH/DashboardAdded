<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Designation/Designation.master" AutoEventWireup="true" CodeFile="searchDesignation.aspx.cs" Inherits="Admin_Designation_searchDesignation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <table class="auto-style1" style="height: 335px">
        <tr>
            <td style="width: 399px; vertical-align: top;">
                <h3 style="color:red">Search Designation</h3>
                <div id="inputTable">
                    <label for="txtDeptId">Designation ID:</label>
                    <asp:TextBox ID="txtDeptId" runat="server"></asp:TextBox>
                    <label for="txtDeptName">Designation Name:</label>
                    <asp:TextBox ID="txtDeptName" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="btnSearchDesignation" runat="server" Text="Search Designation" OnClick="btnSearchDesignation_Click" />
                    <asp:Button ID="btnResetDesignation" runat="server" Text="Reset" OnClick="btnResetDesignation_Click" />
                </div>
                 <h3 style="color:red">Designation Details</h3>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="0"
                        DataKeyNames=" DesignationId" style="margin-left: 0px" Width="544px">
                        <Columns>
                            <asp:BoundField DataField="DesignationId" HeaderText="Department ID" SortExpression="DeptId" />
                            <asp:BoundField DataField="DesignationName" HeaderText="Department Name" SortExpression="DeptName" />
                            <asp:BoundField DataField="AddedDate" HeaderText="Added Date" SortExpression="AddedDate" />
                        </Columns>
                    </asp:GridView>
            </td>
            
              
        </tr>
    </table>
</asp:Content>
