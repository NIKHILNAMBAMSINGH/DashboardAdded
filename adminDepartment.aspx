<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="adminDepartment.aspx.cs" Inherits="adminDepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table class="auto-style1" style="height: 433px">
        <tr>
            <td style="height: 101px; vertical-align: top;padding-left:50px">
                <table class="auto-style1" style="border-color: #000000; height: 92px">
                    <tr>
                        <td style="width: 399px; vertical-align: top;"> 
                            <h3 style="color:red">Department Registration Form</h3>
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
                             <h3 style="color:red">Search By Department ID</h3>
                            <div id="Div1">
        <label for="txtDeptId">Department ID:</label>
        <asp:TextBox ID="TextBoxDepartmentId" runat="server" ></asp:TextBox>
        <asp:Button ID="btnSearchDepartment" runat="server" Text="Search" OnClick="btnSearchDepartment_Click"/>
                            <br /><p />
        <asp:Button ID="Button2" runat="server" Text="Show All Departments" />
    </div></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 234px; vertical-align: top;padding-left:50px"> 
                <div id="GridViewContainer">
                    <h3 style="color:red">&nbsp; Department Details</h3>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="OnPageIndexChanging" PageSize="5" CellPadding="0"
                        DataKeyNames="DeptId" style="margin-left: 0px" Width="544px" EmptyDataText="No data found" ShowHeaderWhenEmpty="true">
                        <Columns>
                            <asp:BoundField DataField="DeptId" HeaderText="Department ID" SortExpression="deptId" />
                            <asp:BoundField DataField="DeptName" HeaderText="Department Name" SortExpression="deptName" />
                            <asp:BoundField DataField="AddedDate" HeaderText="Added Date" SortExpression="addedDate" />
                          
                        </Columns>
                    </asp:GridView>
                </div></td>
        </tr>
    </table>
</asp:Content>

