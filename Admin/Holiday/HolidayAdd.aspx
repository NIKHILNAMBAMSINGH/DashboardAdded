<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="HolidayAdd.aspx.cs" Inherits="Admin_Holiday_HolidayAdd" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container-fluid">
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/Holiday/HolidayDashboard.aspx"> Holiday Dashboard</asp:HyperLink>
                > Add Holiday
            </h6>
        </div>
        <br />
        <div class="input-group">
            <label for="lblHolidayName" style="margin-left:10px;margin-right:10px">Holiday Name :</label>
            <asp:TextBox ID="txtHolidayName" runat="server" Height="30px"></asp:TextBox>
            <label for="lblHolidayDate" style="margin-left:20px;margin-right:10px">Holiday Date :</label>
            <asp:TextBox ID="txtHolidayDate" runat="server" Height="30px"></asp:TextBox>

            <cc1:CalendarExtender ID="CalendarFrom" PopupButtonID="imgPopup" runat="server" TargetControlID="txtHolidayDate" Format="dd/MM/yyyy"> </cc1:CalendarExtender>

            <br />
            <br />
            <asp:Button ID="btnAddHoliday" runat="server" Text="Add Holiday" CssClass="btn btn-primary" Height="40px" style="margin-right: 20px; margin-left: 20px;margin-bottom:5px" OnClick="btnAddDesignation_Click" />
          
             <cc1:ToolkitScriptManager ID="toolScriptManageer1" runat="server"></cc1:ToolkitScriptManager>
        </div>                  
    </div>
    <div>
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    </div>
</div>

    
</asp:Content>

