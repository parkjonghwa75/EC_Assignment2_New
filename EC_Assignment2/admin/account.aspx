<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="EC_Assignment2.admin.account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Account</h1>
    <a href="accountMod.aspx">Add a new account</a>
    <div>
        <label>Records per page: </label>
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
            <asp:ListItem Value="5" Text="5" />
            <asp:ListItem Value="10" Text="10" />
            <asp:ListItem Value="30" Text="30" />
        </asp:DropDownList>
    </div>
    <asp:GridView ID="grdAccounts" runat="server" CssClass="table table-striped table-hover"
        AutoGenerateColumns="false" OnRowDeleting="grdAccounts_RowDeleting" DataKeyNames="AccountID"
        AllowPaging="true" PageSize="10" OnPageIndexChanging="grdAccounts_PageIndexChanging"
        AllowSorting="true" OnSorting="grdAccounts_Sorting" OnRowDataBound="grdAccounts_RowDataBound">
        <Columns>
            <asp:BoundField DataField="AccountID" HeaderText="Account ID" SortExpression="AccountID" />
            <asp:BoundField DataField="AccountName" HeaderText="Account Name" SortExpression="AccountName" />
            <asp:BoundField DataField="CategoryName" HeaderText="Category" SortExpression="CategoryName" />
            <asp:BoundField DataField="isActive" HeaderText="is Active?" />
            <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="accountMod.aspx"
                DataNavigateUrlFields="AccountID"
                DataNavigateUrlFormatString="accountMod.aspx?AccountID={0}" />
            <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
</asp:Content>
