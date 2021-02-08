<%@ Page Title="Contact" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.vb" Inherits="ClientForWebAPI.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form mt-10">
        <form>
            <div class="form-group">
                <label for="exampleInputName">Name</label>
                <input type="email" class="form-control" id="exampleInputName" data-model="Name" aria-describedby="emailHelp">
                <small></small>
            </div>
            <div class="form-group">
                <label for="exampleInputAge">Age</label>
                <input type="number" class="form-control" id="exampleInputAge" data-model="Age">
                <small></small>
            </div>
            <button type="submit" class="btn btn-primary">Submit</button>
        </form>
    </div>
    <script type="text/javascript">
        $("#exampleInputName").change(function () {
            var objData = new Object();
            objData.Name = $(this).val();
            objData.msgType = 'MT700';
            $.ajax({
                method: 'GET',
                url: 'https://localhost:44381/api/values/',
                contentType: 'application/json; charset=utf-8',
                data: objData,
                success: function (data) {
                    $("#exampleInputName").siblings('small').html('');
                    data.forEach((val) => {
                        $("#exampleInputName").siblings('small').html(`*${val.VError}`);
                    })
                },
                error: function (err) {
                    console.log(err);
                }
            });
        });


        $("#exampleInputAge").change(function () {
            var ControlVal = $(this).val();
            var MsgType = 'MT700'
            validate(this, ControlVal, MsgType)
        });


        function validate(ControlID, ControlVal, MsgType) {
            //ControlID = $("#" + ControlID);
            console.log(1,ControlID);
            var APIPropertyName = ControlID.attr("data-model");
            var objData = new Object();
            objData[APIPropertyName] = ControlVal;
            objData['MsgType'] = MsgType;
            $.ajax({
                method: 'GET',
                url: 'https://localhost:44381/api/values/',
                contentType: 'application/json; charset=utf-8',
                data: objData,
                success: function (data) {
                    ControlID.siblings('small').html('');
                    data.forEach((val) => {
                        ControlID.siblings('small').html(`*${val.VError}`);
                    })
                },
                error: function (err) {
                    console.log(err);
                }
            });
        }

    </script>
</asp:Content>
