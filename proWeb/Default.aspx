<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Product management
    </h1>
    <form id ="form1" runat="server">
        <div>
            <p>
                Code <asp:TextBox ID="codeTextBox" TextMode="SingleLine"
                    Columns="50" runat="server"/>
            </p>
            <p>
                Name <asp:TextBox ID="nameTextBox" TextMode="SingleLine"
                    Columns="50" runat="server"/>
            </p>
            <p>
                Amount <asp:TextBox ID="amountTextBox" TextMode="SingleLine"
                    Columns="20" runat="server"/>
            </p>
            <p>
                Category <select id="categoriasBD" runat="server"></select>
            </p>
            <p>
                Price <asp:TextBox ID="priceTextBox" TextMode="SingleLine"
                    Columns="20" runat="server"/>
            </p>
            <p>
                Creation Date <asp:TextBox ID="dateTextBox" TextMode="SingleLine"
                    Columns="40" runat="server"/>
            </p>

            <asp:Button id="BotonCrear" Text="Create" runat="server" OnClick="createText"/>
            <asp:Button id="BotonUpdate" Text="Update" runat="server" OnClick="updateText"/>
            <asp:Button id="BotonDelete" Text="Delete" runat="server" OnClick="deleteText"/>
            <asp:Button id="BotonRead" Text="Read" runat="server" OnClick="readText"/>
            <asp:Button id="BotonReadFirst" Text="Read First" runat="server" OnClick="readFirstText"/>
            <asp:Button id="BotonReadNext" Text="Read Next" runat="server" OnClick="readNextText"/>
            <asp:Button id="BotonReadPrev" Text="Read Prev" runat="server" OnClick="readPrevText"/>
        </div>
    </form>
    <asp:Label ID="mostrarProducto" runat="server"></asp:Label>
    <asp:Label ID="salidaLabel" runat="server"></asp:Label>
</asp:Content>