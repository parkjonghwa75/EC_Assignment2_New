<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="EC_Assignment2.admin.admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Adminstration</h1>
    <div class="well">
        <h3>Category</h3>
        <ul class="list-group">
            <li class="list-group-item"><a href="category.aspx">List categories</a></li>
            <li class="list-group-item"><a href="categoryMod.aspx">Add new category</a></li>
        </ul>
    </div>
    <div class="well">
        <h3>Account</h3>
        <ul class="list-group">
            <li class="list-group-item"><a href="account.aspx">List accounts</a></li>
            <li class="list-group-item"><a href="accountMod.aspx">Add new account</a></li>
        </ul>
    </div>
</asp:Content>
