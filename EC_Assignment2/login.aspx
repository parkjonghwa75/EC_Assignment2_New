<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="EC_Assignment2.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Login</h1>
        <div>
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
        <fieldset>
        <label class="col-sm-2">Username:</label>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            </fieldset>
        <fieldset>
            <label class="col-sm-2">Password:</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        </fieldset>

        <fieldset class="col-sm-offset-2">
            <asp:Button ID="btnLogin" runat="server" Text="Login"  OnClick="btnLogin_Click" />
        </fieldset>

    </div>
</asp:Content>
