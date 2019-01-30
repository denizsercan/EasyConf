<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="submitPaper.aspx.cs" Inherits="finalProject.submitPaper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <div>
        
        <asp:DropDownList  DataValueField="topic" ID="DropDownList1" runat="server">
        
        <asp:ListItem > </asp:ListItem>
        </asp:DropDownList>

        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="btnUpload" class="submit" runat="server" Text="Upload" OnClick="Upload" />
        
        <p><asp:Label ID="lblSonuc" Text="" runat="server"/></p>
    </div>
   


</asp:Content>
