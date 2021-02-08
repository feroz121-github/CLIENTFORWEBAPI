Imports System.Net
Imports System.Net.Http
Imports System.Web.Script.Serialization
Imports ClientForWebAPI.Street
Imports System.Net.Http.Formatting

Public Class Contact
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ''populateStreetList()
        populateNewList()
    End Sub

    Public Function populateStreetList() As String
        Dim apiUrl As String = "https://localhost:44381/api/"
        Dim client As WebClient = New WebClient()

        Dim input As Street = New Street()
        input.City = "Singapore"

        client.Headers("Content-type") = "application/json"
        client.Encoding = Encoding.UTF8
        Dim json = client.UploadString(apiUrl, "Values", New JavaScriptSerializer().Serialize(input))
        ''Dim json = client.BaseAddress(apiUrl)
        Return ""
    End Function

    Public Function populateNewList() As IEnumerable(Of Street)
        Dim client = New HttpClient()
        client.BaseAddress = New Uri("https://localhost:44381/api/")
        Dim responseTask = client.GetAsync(String.Format("Values/?City={0}", "Singapore"))
        responseTask.Wait()
        Dim result = responseTask.Result
        If result.IsSuccessStatusCode Then
            Dim readTask = result.Content.ReadAsAsync(Of IEnumerable(Of Street)).Result()
            Return readTask
        End If

        Return Nothing
    End Function

End Class

Public Class CityClass
    Public Property City As String
End Class


