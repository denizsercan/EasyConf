<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="rewiverPage.aspx.cs" Inherits="finalProject.rewiverPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Bilgilerini Güncelle</h1>
          

        <div class="form_settings">
            <p><span>İsim*</span><asp:TextBox ID="txtName" class="contact" runat="server" /></p>
            <p><span>Soy İsim*</span><asp:TextBox ID="txtSurname" class="contact" runat="server" /></p>
            <p><span>Şifre*</span><asp:TextBox ID="txtPassword" class="contact" runat="server" TextMode="Password"/></p>
            <p><span>Ünvan</span><asp:TextBox ID="txtDegree" class="contact" runat="server" /></p>
            <p><span>İlgi Alanları</span><asp:CheckBoxList ID="chkInterest"  runat="server"> </asp:CheckBoxList></p>
            

            <p style="padding-top: 15px"><span>&nbsp;</span><asp:Button class="submit" Text="Kayıt Ol" runat="server" OnClick="btnKayit_Click" /></p>
            <p>
                <asp:Label ID="lblSonuc" Text="" runat="server" />
            </p>
        </div>

        

</asp:Content>
