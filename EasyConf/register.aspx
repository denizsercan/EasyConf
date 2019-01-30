<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="finalProject.register"  EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3>Kayıt Ol</h3>
    
        <div class="form_settings">
            <p><span>Name</span><asp:TextBox ID="txtName" class="contact" runat="server" /></p>
            <p><span>Surname</span><asp:TextBox ID="txtSurname" class="contact" runat="server" /></p>
            <p><span>Password</span><asp:TextBox ID="txtPassword" class="contact" runat="server" TextMode="Password"/></p>
            <p><span>Email Address</span><asp:TextBox ID="txtEmail" class="contact" runat="server" TextMode="Email"/></p>
            <p><span>Degree</span><asp:TextBox ID="txtDegree" class="contact" runat="server" /></p>
            <p><span>User Role</span><asp:DropDownList ID="DropDownList1" runat="server">

                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Conference Manager</asp:ListItem>
                <asp:ListItem>Rewiver</asp:ListItem>
                <asp:ListItem>Author</asp:ListItem>                
                </asp:DropDownList></p>

            <p style="padding-top: 15px"><span>&nbsp;</span><asp:Button class="submit" Text="Kayıt Ol" runat="server" OnClick="btnKayit_Click" /></p>
            <p>
                <asp:Label ID="lblSonuc" Text="" runat="server" />
            </p>
        </div>
    
</asp:Content>
