﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Products management
    </h1>
    <p>
        Code
        <asp:TextBox ID="ProductCode" runat="server" />
    </p>
    <p>
        Name
        <asp:TextBox ID="ProductName" runat="server" />
    </p>
    <p>
        Amount
        <asp:TextBox ID="ProductAmount" runat="server" />
    </p>
    <p>
        Category
        <asp:DropDownList ID="ProductCategory" runat="server">
            <asp:ListItem value="Computing" selected="False" />
            <asp:ListItem value="Telephony" selected="False" />
            <asp:ListItem value="Gaming" selected="False" />
            <asp:ListItem value="Home appliances" selected="False" />
        </asp:DropDownList>
    </p>
    <p>
        Price
        <asp:TextBox ID="ProductPrice" runat="server" />
    </p>
    <p>
        Creation Date
        <asp:TextBox ID="ProductCreationDate" runat="server" />
    </p>
    <p>
        <asp:Button ID="CreateButton" runat="server" Text="Create" />
        <asp:Button ID="UpdateButton" runat="server" Text="Update" />
        <asp:Button ID="DeleteButton" runat="server" Text="Delete" />
        <asp:Button ID="ReadButton" runat="server" Text="Read" />
        <asp:Button ID="ReadFirstButton" runat="server" Text="Read First" />
        <asp:Button ID="ReadPrevButton" runat="server" Text="Read Prev" />
        <asp:Button ID="ReadNextButton" runat="server" Text="Read Next" />
    </p>
</asp:Content>