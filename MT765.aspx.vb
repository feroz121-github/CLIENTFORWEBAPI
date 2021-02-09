Imports System.Net.Http
Imports Newtonsoft.Json

Public Class MT765
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If (Page.IsPostBack = False) Then
            'DisableUnusedTags()
        End If
    End Sub

    Protected Sub DisableUnusedTags()
        UC1.FindControl("lblTag40").Visible = False
        UC1.FindControl("txtTag40").Visible = False
    End Sub

    Protected Sub btnSubmit_click() Handles btnSubmit.ServerClick

        Dim TagList As List(Of TagClass) = New List(Of TagClass)

        Dim TagItem_20 As TagClass = New TagClass
        TagItem_20.Tag = "20"
        TagItem_20.ValidationFunction = "Validate_Tag20"
        TagItem_20.Value = CType(UC1.FindControl("txtTag20"), TextBox).Text
        TagList.Add(TagItem_20)

        Dim TagItem_36 As TagClass = New TagClass
        TagItem_36.Tag = "36"
        TagItem_36.ValidationFunction = "Validate_Tag36"
        TagItem_36.Value = CType(UC2.FindControl("txtTag36"), TextBox).Text
        TagList.Add(TagItem_36)

        Dim client = New HttpClient()
        client.BaseAddress = New Uri("https://localhost:44381/api/")
        Dim payload = JsonConvert.SerializeObject(TagList)
        Dim c As HttpContent = New StringContent(payload, Encoding.UTF8, "application/json")
        Dim responseTask = client.PostAsync("Validation", c)
        responseTask.Wait()
        Dim result = responseTask.Result
        If result.IsSuccessStatusCode Then
            Dim readTask = result.Content.ReadAsAsync(Of IEnumerable(Of Errors)).Result()
        End If

    End Sub

End Class