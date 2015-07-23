<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="accountMod.aspx.cs" Inherits="EC_Assignment2.admin.accountMod" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
    <h1>Add/Update Account</h1>
    <h5>All fields are required</h5>

    <fieldset>
        <label for="lblCategory" class="col-sm-2">Category:</label>
        <asp:DropDownList ID="ddlCategory" runat="server" >
        </asp:DropDownList>
    </fieldset>

    <fieldset>
        <label for="lblAccountName" class="col-sm-2">Account Name:</label>
        <asp:TextBox ID="txtAccountName" runat="server" required MaxLength="50" />
    </fieldset>

    <fieldset>
        <label for="lblIsActive" class="col-sm-2">Activate this account?:</label>
        <asp:CheckBox ID="ckbIsActive" runat="server" />
    </fieldset>

    <div class="col-sm-offset-2">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    </div>
    
</asp:Content>
