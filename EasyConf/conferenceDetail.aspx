<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="conferenceDetail.aspx.cs" Inherits="finalProject.conferenceDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
        <asp:Panel ID="pnlgiris" runat="server">
        
        <h3>Konferans Detayları</h3>

        <div class="conferencesDetails ">
           
         
                       

            <p><span>Ad:</span><asp:Label ID="lblConferenceName" class="detailLbl" Text="" runat="server" /></p><br />  
            <p><span>Yer:</span><asp:Label ID="lblConferencePlace" class="detailLbl" Text="" runat="server" /></p><br/>
            <p><span>Tarih:</span><asp:Label ID="lblConferenceDate" class="detailLbl" Text="" runat="server" /></p><br/>
            <p><span>Kategori:</span><asp:Label ID="lblCategory" class="detailLbl" Text="" runat="server" /></p><br/>
            <p><span>Açıklama:</span><asp:Label ID="lblDescription" class="detailLbl" Text="" runat="server" /></p><br/>
            <p><span>Son Kağıt Gönderim Tarihi:</span><asp:Label ID="lblSubmissionDate" class="detailLbl" Text="" runat="server" /></p><br/>
            <p><span>Sahibi:</span><asp:Label ID="lblOwner" class="contact" Text="" runat="server" /></p><br/>

            <p style="padding-top: 15px"><span>&nbsp;</span><asp:Button class="submit" Text="Kağıt Gönder" runat="server" OnClick="btn_SubmitPaper" /></p>


            <p><asp:Label ID="lblSonuc" Text="" runat="server"/></p>

        </div>
        </asp:Panel>
   

</asp:Content>
