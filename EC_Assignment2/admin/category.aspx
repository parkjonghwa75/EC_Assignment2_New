<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="category.aspx.cs" Inherits="EC_Assignment2.admin.category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>Category</h1>
    <a href="categoryMod.aspx">Add new category</a>

    <div>
        <label>Records per page: </label>
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
            <asp:ListItem Value="5" Text="5" />
            <asp:ListItem Value="10" Text="10" />
            <asp:ListItem Value="30" Text="30" />
        </asp:DropDownList>
    </div>

    <asp:GridView ID="grdCategory" runat="server" CssClass="table table-striped table-hover"
        AutoGenerateColumns="false" DataKeyNames="CategoryID"
        AllowPaging="true" PageSize="5" OnPageIndexChanging="grdCategory_PageIndexChanging"
         AllowSorting="true"  OnSorting="grdCategory_Sorting" OnRowDataBound="grdCategory_RowDataBound">
        <Columns>
            <asp:BoundField DataField="CategoryID" HeaderText="Category ID" Visible="false" SortExpression="CategoryID"/>
            <asp:BoundField DataField="CategoryName" HeaderText="Category Name" SortExpression="CategoryName"/>
            <asp:BoundField DataField="isExpense" HeaderText="Expense?"   />
            <asp:BoundField DataField="isActive" HeaderText="Activated?"   />
            <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="categoryMod.aspx"
                DataNavigateUrlFields="CategoryID" DataNavigateUrlFormatString="categoryMod.aspx?CategoryID={0}" />
        </Columns>
    </asp:GridView>
</asp:Content>
