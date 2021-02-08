Imports System.Net.Http
Imports Newtonsoft.Json

Public Class MT760
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSubmit_click() Handles btnSubmit.ServerClick
        Dim StrSenderInfo = txtSender.Value
        Dim StrMessageType = drpMsgType.Value
        Dim StrIssueDate = txtIssueDt.Value
        Dim SenderReciever = txtSenderRecieverInfo.Text
        Dim StrMoneyPaid = rdSettlement.SelectedValue

        Dim objMT760 As New MSG_MT760()
        objMT760.SenderInfo = StrSenderInfo
        objMT760.MessageType = StrMessageType
        objMT760.IssueDate = StrIssueDate
        objMT760.SenderReciever = SenderReciever
        objMT760.MoneyPaid = StrMoneyPaid
        Dim content = JsonConvert.SerializeObject(objMT760)
        Dim client = New HttpClient()
        client.BaseAddress = New Uri("https://localhost:44381/api/values")
        Dim payload = JsonConvert.SerializeObject(objMT760)
        Dim c As HttpContent = New StringContent(payload, Encoding.UTF8, "application/json")
        Dim responseTask = client.PostAsync("values", c)
        responseTask.Wait()
        Dim result = responseTask.Result
        If result.IsSuccessStatusCode Then
            Dim readTask = result.Content.ReadAsAsync(Of IEnumerable(Of Errors)).Result()
        End If
    End Sub

    Protected Sub btnSubmitGet_click() Handles btnSubmitGet.ServerClick
        Dim StrSenderInfo = txtSender.Value
        Dim StrMessageType = drpMsgType.Value
        Dim StrIssueDate = txtIssueDt.Value
        Dim SenderReciever = txtSenderRecieverInfo.Text
        Dim StrMoneyPaid = rdSettlement.SelectedValue

        Dim objMT760 As New MSG_MT760()
        objMT760.SenderInfo = StrSenderInfo
        objMT760.MessageType = StrMessageType
        objMT760.IssueDate = StrIssueDate
        objMT760.SenderReciever = SenderReciever
        objMT760.MoneyPaid = StrMoneyPaid
        Dim content = JsonConvert.SerializeObject(objMT760)
        Dim client = New HttpClient()
        client.BaseAddress = New Uri("https://localhost:44381/api/")
        Dim responseTask = client.GetAsync(String.Format("Values/?SenderInfo={0}", StrSenderInfo))
        responseTask.Wait()
        Dim result = responseTask.Result
        If result.IsSuccessStatusCode Then
            Dim readTask = result.Content.ReadAsAsync(Of IEnumerable(Of Street)).Result()
        End If
    End Sub
End Class