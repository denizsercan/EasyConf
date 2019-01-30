<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="AllConferences.aspx.cs" Inherits="finalProject.AllConferences" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="style/gridview.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Font-Size="Small" Height="200px" Width="500px">
        <Columns>
           
            <asp:BoundField DataField="conferenceName" HeaderText="conferenceName" SortExpression="conferenceName" />
            <asp:BoundField DataField="conferenceDate" HeaderText="conferenceDate" SortExpression="conferenceDate" />
            <asp:BoundField DataField="conferencePlace" HeaderText="conferencePlace" SortExpression="conferencePlace" />
            <asp:BoundField DataField="submissionDueDate" HeaderText="submissionDueDate" SortExpression="submissionDueDate" />
            <asp:BoundField DataField="category" HeaderText="category" SortExpression="category" />
            
          
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TezConnectionString %>" SelectCommand="SELECT [conferenceName], [conferenceDate], [conferencePlace], [submissionDueDate], [category] FROM [Conferences] WHERE [isActive] = 1 "></asp:SqlDataSource>
    </asp:Content>
