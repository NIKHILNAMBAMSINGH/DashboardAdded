<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="adminDepartment.aspx.cs" Inherits="adminDepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table class="auto-style1" style="height: 434px">
        <tr>
            <td style="height: 101px; vertical-align: top;">
                <table class="auto-style1" style="border-color: #000000; height: 92px">
                    <tr>
                        <td style="width: 399px; vertical-align: top;"> 
                            <div id="inputTable">
        <label for="txtDeptId">Department ID:</label>
        <asp:TextBox ID="txtDeptId" runat="server"></asp:TextBox>
                                <br />
                                <br />
        <label for="txtDeptName">Department Name:</label>
        <asp:TextBox ID="txtDeptName" runat="server"></asp:TextBox>
                                <br />
                                <br />
        <asp:Button ID="btnAddDepartment" runat="server" Text="Add Department" OnClick="btnAddDepartment_Click"/>
        <asp:Button ID="btnResetDepartment" runat="server" Text="Reset" OnClick="btnResetDepartment_Click" />
       </div></td>
                        <td style="vertical-align: top">
                            <div id="Div1">
        <label for="txtDeptId">Department ID:</label>
        <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Search" />
                            <br /><p />
        <asp:Button ID="Button2" runat="server" Text="Show All Departments" />
    </div></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 234px; vertical-align: top;"> 
                <div id="GridViewContainer">
                    <h2>&nbsp; Department Details</h2>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                        OnPageIndexChanging="OnPageIndexChanging" PageSize="5" CellPadding="0"
                        OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting"
                        OnRowCancelingEdit="GridView1_RowCancelingEdit" DataKeyNames="deptId" style="margin-left: 0px" Width="544px">
                        <Columns>
                            <asp:BoundField DataField="deptId" HeaderText="Department ID" SortExpression="deptId" />
                            <asp:BoundField DataField="deptName" HeaderText="Department Name" SortExpression="deptName" />
                            <asp:BoundField DataField="addedDate" HeaderText="Added Date" SortExpression="addedDate" />
                            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                </div></td>
        </tr>
    </table>
</asp:Content>

