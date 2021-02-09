<%@ Page Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="MT765.aspx.vb" Inherits="ClientForWebAPI.MT765" %>

<%@ Register Src="~/UC/UC1.ascx" TagName="UC1" TagPrefix="TUC1" %>
<%@ Register Src="~/UC/UC2.ascx" TagName="UC2" TagPrefix="TUC2" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <TUC1:UC1 ID="UC1" runat="server" />
    <TUC2:UC2 ID="UC2" runat="server" />

    <input type="submit" value="Submit" id="btnSubmit" runat="server"/>
</asp:Content>
