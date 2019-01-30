<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="MyConferences.aspx.cs" Inherits="finalProject.MyConferences" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      
    <asp:GridView ID="GridView1" datakeynames="id" runat="server" AutoGenerateColumns="False"  Font-Size="Small" Height="200px" Width="500px" OnRowDeleting="GridView1_RowDeleting1" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
        <Columns>
           
        <asp:BoundField DataField="conferenceName" HeaderText="conferenceName" />
        <asp:BoundField DataField="conferenceDate" HeaderText="conferenceDate" />
        <asp:BoundField DataField="conferencePlace" HeaderText="conferencePlace" />
       <%-- <asp:TemplateField HeaderText="submissionDueDate">

            <ItemTemplate>
                <p>
                <asp:TextBox ID="textduedate" runat="server">
                </asp:TextBox><ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="true" TargetControlID="textduedate" />
                    </p>
            </ItemTemplate>
        </asp:TemplateField>--%>
        <asp:BoundField DataField="submissionDueDate" HeaderText="submissionDueDate" />
        <asp:BoundField DataField="category" HeaderText="category" />
        <asp:BoundField DataField="status" HeaderText="status" />
        <asp:BoundField DataField="conferenceDescription" HeaderText="conferenceDescription" />
        <asp:BoundField DataField="Id" HeaderText="Id" />
        <asp:CommandField ShowEditButton="true" />
        <asp:CommandField ShowDeleteButton="true" />
            
          
        </Columns>
    </asp:GridView>

 
    <asp:Label ID="lblresult" runat="server"></asp:Label>

</asp:Content>
