<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="MT760.aspx.vb" Inherits="ClientForWebAPI.MT760" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <form>
        <div class="form-group mt-10">
            <label for="txtSender">Sender</label>
            <input type="text" class="form-control" id="txtSender" runat="server" />
        </div>
        <div class="form-group">
            <label for="drpMsgType">Msg Type</label>
            <select runat="server" id="drpMsgType">
                <option>Select</option>
                <option value="MT760">MT760</option>
                <option value="MT762">MT762</option>
                <option value="MT764">MT764</option>
            </select>
        </div>
        <div class="form-group">
            <label for="txtSenderRecieverInfo">Sender to Reciever Information</label>
            <asp:TextBox runat="server" TextMode="MultiLine" ID="txtSenderRecieverInfo"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtIssueDt">Issue Date</label>
            <input type="text" runat="server" class="form-control datepicker" id="txtIssueDt" />
        </div>
        <div class="form-group">
            <label for="rdSettlement">Money to be paid</label>
            <asp:RadioButtonList ID="rdSettlement" runat="server">
                <asp:ListItem Value="In Advance" Text="In Advance"></asp:ListItem>
                <asp:ListItem Value="In Arrears" Text="In Arrears"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <input type="submit" class="btn-danger" onclick="btnSubmit_click" runat="server" id="btnSubmit" />
    </form>

    <script type="text/javascript">
        $(document).ready(function () {
            $(".datepicker").datepicker();
        });
    </script>
</asp:Content>
