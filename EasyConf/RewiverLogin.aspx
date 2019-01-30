<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="RewiverLogin.aspx.cs" Inherits="finalProject.RewiverLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="pnlgiris" runat="server">
        
        <h1>Rewiver Girişi</h1>

        <div class="form_settings">
           
             
            <p><span>Email Address</span><asp:TextBox ID="txtEmail" class="contact" runat="server" TextMode="Email"/></p>
            <p><span>Password</span><asp:TextBox ID="txtPassword" class="contact" runat="server" TextMode="Password"/></p>
            <p style="padding-top: 15px"><span>&nbsp;</span><asp:Button class="submit" Text=" Giriş " runat="server" OnClick="btnGiris_Click" /></p>
            <p>
                <asp:Label ID="lblSonuc" Text="" runat="server" />
            </p>
        </div>
        </asp:Panel>

</asp:Content>
