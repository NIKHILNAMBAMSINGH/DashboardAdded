<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Designation/Designation.master" AutoEventWireup="true" CodeFile="DesignationList.aspx.cs" Inherits="Admin_Designation_DesignationList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
     <table class="auto-style1" style="height: 335px">
        <tr>
            <td style="width: 399px; vertical-align: top;">
                
                 <h3 style="color:red">Department List</h3>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="OnPageIndexChanging" PageSize="4" CellPadding="0"
                        DataKeyNames="DesignationId" style="margin-left: 0px" EmptyDataText="No data found" ShowHeaderWhenEmpty="true">
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

