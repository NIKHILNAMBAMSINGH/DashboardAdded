<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Department/Department.master" AutoEventWireup="true" CodeFile="DepartmentList.aspx.cs" Inherits="Admin_Department_DepartmentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
     <table class="auto-style1" style="height: 335px">
        <tr>
            <td style="width: 399px; vertical-align: top;">
                
                 <h3 style="color:red">Department List</h3>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="OnPageIndexChanging" PageSize="4" CellPadding="0"
                        DataKeyNames="DeptId" style="margin-left: 0px" EmptyDataText="No data found" ShowHeaderWhenEmpty="true">
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

