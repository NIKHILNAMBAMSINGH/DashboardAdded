<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="LeaveDashboard.aspx.cs" Inherits="Admin_Leave_LeaveDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
    
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                  <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Empty.aspx">Home</asp:HyperLink>
                > Leave Dashboard
            </h6>
        </div>
        <div class="card-body">
            <div class="table-responsive">
            
                <table class="auto-style1" style="text-align:center">
                        <tr>
                            <td >
                                <div style="margin-right:50px ">
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/Leave/LeavePending.aspx">Pending Leave</asp:HyperLink>
                                    </div>
                            </td>
                            <td >
                                  <div style="margin-left:160px">
                                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Admin/Leave/LeaveRejected.aspx">Rejected Leave</asp:HyperLink>
                                       </div>
                            </td>

                             <td >
                                <div style="margin-left:180px">
                                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Admin/Leave/LeaveApproved.aspx">Approved List</asp:HyperLink>
                                    </div>
                            </td>


                            <td >
                                <div style="margin-left:230px">
                                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Admin/Employee/EmployeeList.aspx">Leave List</asp:HyperLink>
                                    </div>
                            </td>
                            
                        </tr>
                    </table>
            </div>
        </div>
    </div>
</div>
</asp:Content>

