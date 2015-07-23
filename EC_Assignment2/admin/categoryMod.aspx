<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="categoryMod.aspx.cs" Inherits="EC_Assignment2.admin.categoryMod" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Add/Update Category</h1>
    <h3>All fields are required.</h3>
    <fieldset>
        <label for="txtCtgname" class="col-sm-2">Category Name: </label>
        <asp:TextBox ID="txtCtgname" runat="server" required MaxLength="30"></asp:TextBox>
    </fieldset>

    <fieldset>
        <label for="txtIsExpense" class="col-sm-2">is it Expense?: </label>
        <asp:CheckBox ID="ckbIsExpense" runat="server" />
    </fieldset>
    <fieldset>
        <label for="txtIsActive" class="col-sm-2">Activate this Category?: </label>
        <asp:CheckBox ID="ckbActivated" runat="server" />
    </fieldset>

    <div class="col-sm-offset-2">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    </div>
</asp:Content>
