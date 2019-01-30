<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="finalProject.login" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    
        
        <asp:Panel ID="pnlgiris" runat="server">
        
        <h3>Giri&#351; Yap</h3>

        <div class="form_settings">
            
             
            <p><span>Email Address</span><asp:TextBox ID="txtEmail" class="contact" runat="server" TextMode="Email"/></p>
            <p><span>Password</span><asp:TextBox ID="txtPassword" class="contact" runat="server" TextMode="Password"/></p>
            <p style="padding-top: 15px"><span>&nbsp;</span><asp:Button class="submit" Text=" Giri&#351; " runat="server" OnClick="btnGiris_Click" /></p>
            <p>
                <asp:Label ID="lblSonuc" Text="" runat="server" />
            </p>
        </div>

    

</html>


        </asp:Panel>

       

</asp:Content>
