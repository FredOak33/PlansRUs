Imports System
Imports System.Collections.Generic
Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports Newtonsoft.Json


Public Class SalesforceClient

    'Full Copy
    'Private Const LOGIN_ENDPOINT As String = "https://fusion-3928--fullcopy.cloudforce.com/services/oauth2/token"
    'Production
    ' Private Const LOGIN_ENDPOINT As String = "https://fusion-3928.cloudforce.com//services/oauth2/token"


    Private Const LOGIN_ENDPOINT As String = "https://fusion-3928.cloudforce.com//services/oauth2/token"
    Private Const API_ENDPOINT As String = "/services/data/v36.0/"
    Public Property Username As String
    Public Property Password As String
    Public Property Token As String
    Public Property ClientId As String
    Public Property ClientSecret As String
    Public Property AuthToken As String
    Public Property InstanceUrl As String

    Public Sub New()
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 Or SecurityProtocolType.Tls11
    End Sub

    Public Sub Login()
        Dim jsonResponse As String
        'Production
        '{"client_id","3MVG9fMtCkV6eLheKQD.Wa_EAoOAzcVDKsJ.WBMmhogU0wT5vOJLmSIQEybGNbQUqyBZEAJdxhK4wyWgx4A4K"},
        '{"client_secret", "B3B9AE0E247B04D00E9FDB98CA36752836221C2D5D434A2032E5FE63774854BE"},
        '{"username", "eichinger.frederick@healthnow.org"},
        '{"password", "Kbe33Sje%" & "OJowV1R9vvyNEwmTr3oLJch31"}

        '==============================================================================================================
        'FullCopy
        '{"client_id", "3MVG9PE4xB9wtoY9bHX7OCcJJg3Ct9BFXP1w3m9MsjDlGEsd8aGFctDSNSHe6ZQeuTZNWLxRrOUwZFROe5e2n"},
        '{"client_secret", "8B616682E1A60A3AB667E953B227AA46964BA2D7963C0D881A5123F4CB7940B3"},
        '{"username", "eichinger.frederick@healthnow.org.fullcopy"},
        '{"password", "Kbe33Sje%" & "DQZuXotm7b0D1fqktxBSBRO4"}

        Using client = New HttpClient()
            Dim request = New FormUrlEncodedContent(New Dictionary(Of String, String) From {
                {"grant_type", "password"},
                {"client_id", "3MVG9fMtCkV6eLheKQD.Wa_EAoOAzcVDKsJ.WBMmhogU0wT5vOJLmSIQEybGNbQUqyBZEAJdxhK4wyWgx4A4K"},
                {"client_secret", "B3B9AE0E247B04D00E9FDB98CA36752836221C2D5D434A2032E5FE63774854BE"},
                {"username", "eichinger.frederick@healthnow.org"},
                {"password", "Kbe33Sje%" & "OJowV1R9vvyNEwmTr3oLJch31"}
                })
            request.Headers.Add("X-PrettyPrint", "1")
            Dim response = client.PostAsync(LOGIN_ENDPOINT, request).Result
            jsonResponse = response.Content.ReadAsStringAsync().Result
        End Using

        Dim values = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(jsonResponse)
        AuthToken = values("access_token")
        InstanceUrl = values("instance_url")
    End Sub

    Public Function QueryEndpoints() As String
        Using client = New HttpClient()
            Dim restQuery As String = InstanceUrl & API_ENDPOINT
            Dim request = New HttpRequestMessage(HttpMethod.[Get], restQuery)
            request.Headers.Add("Authorization", "Bearer " & AuthToken)
            request.Headers.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
            request.Headers.Add("X-PrettyPrint", "1")
            Dim response = client.SendAsync(request).Result
            Return response.Content.ReadAsStringAsync().Result
        End Using
    End Function

    Public Function Describe(ByVal sObject As String) As String
        Using client = New HttpClient()
            Dim restQuery As String = InstanceUrl & API_ENDPOINT & "sobjects/" & sObject
            Dim request = New HttpRequestMessage(HttpMethod.[Get], restQuery)
            request.Headers.Add("Authorization", "Bearer " & AuthToken)
            request.Headers.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
            request.Headers.Add("X-PrettyPrint", "1")
            Dim response = client.SendAsync(request).Result
            Return response.Content.ReadAsStringAsync().Result
        End Using
    End Function

    Public Function Query(ByVal soqlQuery As String) As String
        Using client = New HttpClient()
            Dim restRequest As String = InstanceUrl & API_ENDPOINT & "query/?q=" & soqlQuery
            Dim request = New HttpRequestMessage(HttpMethod.[Get], restRequest)
            request.Headers.Add("Authorization", "Bearer " & AuthToken)
            request.Headers.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
            request.Headers.Add("X-PrettyPrint", "1")
            Dim response = client.SendAsync(request).Result
            Return response.Content.ReadAsStringAsync().Result
        End Using
    End Function

    Public Function Query2(ByVal soqlQuery As String) As String
        Using client = New HttpClient()
            Dim restRequest As String = InstanceUrl & soqlQuery
            Dim request = New HttpRequestMessage(HttpMethod.[Get], restRequest)
            request.Headers.Add("Authorization", "Bearer " & AuthToken)
            request.Headers.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
            request.Headers.Add("X-PrettyPrint", "1")
            Dim response = client.SendAsync(request).Result
            Return response.Content.ReadAsStringAsync().Result
        End Using
    End Function
End Class
