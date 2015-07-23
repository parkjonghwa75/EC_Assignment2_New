<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="monthlyexpenses.aspx.cs" Inherits="EC_Assignment2.admin.monthlyexpenses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Managing Income and Expenses</h1>
    <h3>Please Input this month's actual amount and next month's anticipated amount.</h3>
    <div>
        <asp:Label ID="Year" runat="server" Text="Year: "></asp:Label>
        <asp:DropDownList ID="ddlYear" runat="server">
            <asp:ListItem Value="2015" Text="2015"></asp:ListItem>
            <asp:ListItem Value="2016" Text="2016"></asp:ListItem>
            <asp:ListItem Value="2017" Text="2017"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div>
        <asp:Label ID="Month" runat="server" Text="Month: "></asp:Label>
        <asp:DropDownList ID="ddlMonth" runat="server">
            <asp:ListItem Value="1" Text="1"></asp:ListItem>
            <asp:ListItem Value="2" Text="2"></asp:ListItem>
            <asp:ListItem Value="3" Text="3"></asp:ListItem>
            <asp:ListItem Value="4" Text="4"></asp:ListItem>
            <asp:ListItem Value="5" Text="5"></asp:ListItem>
            <asp:ListItem Value="6" Text="6"></asp:ListItem>
            <asp:ListItem Value="7" Text="7"></asp:ListItem>
            <asp:ListItem Value="8" Text="8"></asp:ListItem>
            <asp:ListItem Value="9" Text="9"></asp:ListItem>
            <asp:ListItem Value="10" Text="10"></asp:ListItem>
            <asp:ListItem Value="11" Text="11"></asp:ListItem>
            <asp:ListItem Value="12" Text="12"></asp:ListItem>
        </asp:DropDownList>
    </div>

    <asp:GridView ID="grdMonthly" runat="server" CssClass="table table-striped table-hover"
        AutoGenerateColumns="false" DataKeyNames="ExpenseID" AllowSorting="true" OnSorting="grdMonthly_Sorting" >
        <Columns>
            <asp:BoundField DataField="CategoryName" HeaderText="Category" SortExpression="CategoryName" />
            <asp:BoundField DataField="AccountName" HeaderText="Account" SortExpression="AccountName" />
            
            <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="expenseMod.aspx"
                DataNavigateUrlFields="ExpenseID" DataNavigateUrlFormatString="expenseMod.aspx?expenseID={0}" />
        </Columns>
    </asp:GridView>
</asp:Content>
