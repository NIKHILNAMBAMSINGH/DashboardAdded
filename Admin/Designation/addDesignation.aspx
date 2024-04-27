<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Designation/Designation.master" AutoEventWireup="true" CodeFile="addDesignation.aspx.cs" Inherits="Admin_Designation_addDesignation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
      <table class="auto-style1" style="height: 335px">
        <tr>
                
                 <td style="width: 399px; vertical-align: top;"> 
                            <h3 style="color:red">Designation Registration Form</h3>
                            <div id="inputTable">
        <label for="txtDeptId">Designation ID:</label>
        <asp:TextBox ID="txtDeptId" runat="server"></asp:TextBox>
                               
        <label for="txtDeptName">Designation Name:</label>
        <asp:TextBox ID="txtDeptName" runat="server"></asp:TextBox>
                                <br />
                                <br />
        <asp:Button ID="btnAddDesignation" runat="server" Text="Add Designation" OnClick="btnAddDesignation_Click"/>
        <asp:Button ID="btnResetDepartment" runat="server" Text="Reset" OnClick="btnResetDesignation_Click" />
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
       </div></td> 
        </tr>
    </table>
     
</asp:Content>

