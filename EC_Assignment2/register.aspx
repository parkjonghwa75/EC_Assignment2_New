<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="EC_Assignment2.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Register</h1>
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
        <fieldset>
            <label class="col-sm-2">Confirm:</label>
            <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server"  Operator="Equal" 
                ErrorMessage="Passwords must match" ControlToCompare="txtConfirm" ControlToValidate="txtPassword"></asp:CompareValidator>
        </fieldset>
        <fieldset class="col-sm-offset-2">
            <asp:Button ID="btnRegister" runat="server" Text="Register"  OnClick="btnRegister_Click" />
        </fieldset>

    </div>
</asp:Content>
