<%@ Page Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Conference.aspx.cs" Inherits="finalProject.Conference" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    
        
        <asp:Panel ID="pnlgiris" runat="server">
        
            <p style="padding: 15px; margin: 15px">
                <span>&nbsp;</span></p>
           

        <div class="form_settings">
            
              <h3>Konferens Yarat</h3>
            <p><span>Konferans Ad&#305;</span><asp:TextBox ID="txtKonferansAdi" class="contact" runat="server" /></p>

            


            <p><span>Tarih</span><asp:TextBox ID="txt_Konferanstarihi" runat="server"></asp:TextBox><ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="true" TargetControlID="txt_Konferanstarihi" /></p>
            <p><span>Kategori</span><asp:TextBox ID="txtKategori" class="contact" runat="server"/></p>     
            <p><span>Konferans Yeri</span><asp:TextBox ID="txtKonferansYeri" runat="server" Rows="4" TextMode="MultiLine"></asp:TextBox></p>
            <p><span>Konular(Konu1, Konu2, Konu3)</span><asp:TextBox ID="txtKonular" class="contact" runat="server"/></p>
            <p><span>Hakemler</span><asp:TextBox ID="txtRewivers" class="contact" runat="server"/></p> 
            
            

                <p><span>Submission Duedate</span><asp:TextBox ID="txt_Duedate" runat="server"></asp:TextBox><ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="true" TargetControlID="txt_Duedate"/>
                </p>
                <p><span>Conference Description</span><asp:TextBox ID="txt_Description" runat="server" Rows="5" TextMode="MultiLine"></asp:TextBox></p>
                <p>
                     <p style="padding-top: 50px"><span>&nbsp;
                         </span><asp:Button ID="btn_Conf" class="submit" Text=" Konferans Yarat " runat="server" OnClick="btn_ConfYarat" /></p>
                     
                    
                     <p>
                     </p>
                     <p>
                     </p>
                     <p>
                     </p>
                     <p>
                     </p>
                     <p>
                     </p>
                     <p>
                     </p>
                     <p>
                     </p>
                     <p>
                     </p>
                     <p>
                     </p>
                     <p>
                     </p>
                     <p>
                     </p>
                     <p>
                     </p>
                </p>
                

            
            
        </div>
        </asp:Panel>

            <asp:Label ID="lblSonuc" runat="server"></asp:Label>

</asp:Content>

