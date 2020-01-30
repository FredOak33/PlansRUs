Imports System.IO
Imports System.Configuration
Imports System.Web
Imports System.Linq
Imports System.Collections.Generic
Imports System.Net
Imports System.Windows.Forms

Public Class FrmMain
    Private Const KfileName As String = "KeyPlanJSON.txt"
    Private Const UfileName As String = "UserPlanJSON.txt"
    Private Const PfileName As String = "PlanJSON.txt"
    Private ReadOnly filePath As String = "S:\Corp\CIS\BCD-DR\FRED\"

    Public _CurrentKey As DataTable
    Public _CurrentUser As DataTable
    Public _CurrentPlan As DataTable
    Public _ActualPlan As String

    Public Property ActualPlan As String
        Get
            Return _ActualPlan
        End Get
        Set(value As String)
            _ActualPlan = value
        End Set
    End Property
    Public Property CurrentKey As DataTable
        Get
            Return _CurrentKey
        End Get
        Set(value As DataTable)
            _CurrentKey = value
        End Set
    End Property

    Public Property CurrentUser As DataTable
        Get
            Return _CurrentUser
        End Get
        Set(value As DataTable)
            _CurrentUser = value
        End Set
    End Property

    Public Property CurrentPlan As DataTable
        Get
            Return _CurrentPlan
        End Get
        Set(value As DataTable)
            _CurrentPlan = value
        End Set
    End Property
    'KeyPlanJSON
    Public Class Attributes
        Public Property type As String
        Public Property url As String
    End Class

    Public Class Record
        Public Property attributes As Attributes
        Public Property Id As String
        Public Property Name As String
        Public Property FF__Full_Name__c As String
        Public Property FF__Last_Name__c As String
        Public Property FF__Title__c As String
        Public Property FF__Number_of_Rosters__c As Double
        Public Property FF__Number_of_Teams__c As Double
    End Class

    Public Class Example
        Public Property totalSize As Integer
        Public Property done As Boolean
        Public Property nextRecordsUrl As String
        Public Property records As Record()
    End Class

    Public Class UAttributes
        Public Property type As String
        Public Property url As String
    End Class

    Public Class URecord
        Public Property attributes As UAttributes
        Public Property Id As String
        Public Property LastName As String
        Public Property FirstName As String
        Public Property Name As String
    End Class

    Public Class UExample
        Public Property totalSize As Integer
        Public Property done As Boolean
        Public Property records As URecord()
    End Class

    'Plan JSON
    Public Class PAttributes
        Public Property type As String
        Public Property url As String
    End Class

    Public Class PRecord
        Public Property attributes As PAttributes
        Public Property OwnerId As String
        Public Property Name As String
        Public Property Approval_Status__c As String
        Public Property Last_Submitted_for_Approval__c As String
        Public Property Last_Approved__c As String
        Public Property Plan_Approver__c As String
        Public Property Subject_Matter_Expert__c As String
        Public Property DRP_Plan_Type__c As String
        Public Property HN_Leadership_Approver__c As String
        Public Property Primary_Business_Function_Lead__c As String
        Public Property Primary_Staff_Contact__c As String
        Public Property Approval_Path__c As String
        Public Property Priority__c As String
        Public Property Plan_Manager__c As String
        Public Property Plan_Director__c As String
    End Class

    Public Class PExample
        Public Property totalSize As Integer
        Public Property done As Boolean
        Public Property records As PRecord()
    End Class

    Public Function CreateClient() As SalesforceClient
        Return New SalesforceClient With {
            .Username = ConfigurationManager.AppSettings("username"),
            .Password = ConfigurationManager.AppSettings("password"),
            .Token = ConfigurationManager.AppSettings("token"),
            .ClientId = ConfigurationManager.AppSettings("clientId"),
            .ClientSecret = ConfigurationManager.AppSettings("clientSecret")
        }
    End Function

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        KeyFile()

        UserFile()

        PlanFile()

        Dim dtUser As New DataTable
        dtUser.Columns.Add("id", GetType(Integer))
        dtUser.Columns.Add("uID", GetType(String))
        dtUser.Columns.Add("Last", GetType(String))
        dtUser.Columns.Add("First", GetType(String))
        dtUser.Columns.Add("Name", GetType(String))

        Dim dtKey As New DataTable
        dtKey.Columns.Add("id", GetType(Integer))
        dtKey.Columns.Add("Uid", GetType(String))
        dtKey.Columns.Add("Name", GetType(String))
        dtKey.Columns.Add("FullName", GetType(String))
        dtKey.Columns.Add("Last", GetType(String))
        dtKey.Columns.Add("Title", GetType(String))
        dtKey.Columns.Add("Rosters", GetType(Double))
        dtKey.Columns.Add("Teams", GetType(Double))

        Dim dtPlan As New DataTable
        dtPlan.Columns.Add("id", GetType(Integer))
        dtPlan.Columns.Add("OwnerId", GetType(String))
        dtPlan.Columns.Add("Name", GetType(String))
        dtPlan.Columns.Add("ApprovalStatus", GetType(String))
        dtPlan.Columns.Add("LastSubmittedforApproval", GetType(String))
        dtPlan.Columns.Add("LastApproved", GetType(String))
        dtPlan.Columns.Add("PlanApprover", GetType(String))
        dtPlan.Columns.Add("SubjectMatterExpert", GetType(String))
        dtPlan.Columns.Add("DRPPlanType", GetType(String))
        dtPlan.Columns.Add("HNLeadershipApprover", GetType(String))
        dtPlan.Columns.Add("PrimaryBusinessFunctionLead", GetType(String))
        dtPlan.Columns.Add("PrimaryStaffContact", GetType(String))
        dtPlan.Columns.Add("Approval_Path__c", GetType(String))
        dtPlan.Columns.Add("Priority", GetType(String))
        dtPlan.Columns.Add("Plan_Manager", GetType(String))
        dtPlan.Columns.Add("Plan_Director", GetType(String))

        '=====================================================================================================================
        ' Process Plan JSON text file
        '=====================================================================================================================
        Dim ApprovalPath As String = ""
        Dim ApprovalStatus As String = ""
        Dim PlanType As String = ""
        Dim HNLead As String = ""
        Dim LastApprove As String = ""
        Dim LastSubmit As String = ""
        Dim PName As String = ""
        Dim Owner As String = ""
        Dim Approver As String = ""
        Dim Director As String = ""
        Dim Manager As String = ""
        Dim BFLead As String = ""
        Dim StafF As String = ""
        Dim Priority As String = ""
        Dim SME As String = ""

        If IO.File.Exists(filePath & PfileName) Then
            Dim jText As String = IO.File.ReadAllText(filePath & PfileName)

            If Not String.IsNullOrWhiteSpace(jText) Then

                Dim PteamObject As PExample = Newtonsoft.Json.JsonConvert.DeserializeObject(Of PExample)(jText)

                For i = 0 To PteamObject.records.Count - 1

                    If IsNothing(PteamObject.records(i).Approval_Path__c) Then
                        ApprovalPath = ""
                    Else
                        ApprovalPath = PteamObject.records(i).Approval_Path__c
                    End If
                    If IsNothing(PteamObject.records(i).Approval_Status__c) Then
                        ApprovalStatus = ""
                    Else
                        ApprovalStatus = PteamObject.records(i).Approval_Status__c
                    End If
                    If IsNothing(PteamObject.records(i).DRP_Plan_Type__c) Then
                        PlanType = ""
                    Else
                        PlanType = PteamObject.records(i).DRP_Plan_Type__c
                    End If
                    If IsNothing(PteamObject.records(i).HN_Leadership_Approver__c) Then
                        HNLead = ""
                    Else
                        HNLead = PteamObject.records(i).HN_Leadership_Approver__c
                    End If
                    If IsNothing(PteamObject.records(i).Last_Approved__c) Then
                        LastApprove = ""
                    Else
                        LastApprove = PteamObject.records(i).Last_Approved__c
                    End If
                    If IsNothing(PteamObject.records(i).Last_Submitted_for_Approval__c) Then
                        LastSubmit = ""
                    Else
                        LastSubmit = PteamObject.records(i).Last_Submitted_for_Approval__c
                    End If
                    If IsNothing(PteamObject.records(i).Name) Then
                        PName = ""
                    Else
                        PName = PteamObject.records(i).Name
                    End If
                    If IsNothing(PteamObject.records(i).OwnerId) Then
                        Owner = ""
                    Else
                        Owner = PteamObject.records(i).OwnerId
                    End If
                    If IsNothing(PteamObject.records(i).Plan_Approver__c) Then
                        Approver = ""
                    Else
                        Approver = PteamObject.records(i).Plan_Approver__c
                    End If
                    If IsNothing(PteamObject.records(i).Plan_Director__c) Then
                        Director = ""
                    Else
                        Director = PteamObject.records(i).Plan_Director__c
                    End If
                    If IsNothing(PteamObject.records(i).Plan_Manager__c) Then
                        Manager = ""
                    Else
                        Manager = PteamObject.records(i).Plan_Manager__c
                    End If
                    If IsNothing(PteamObject.records(i).Primary_Business_Function_Lead__c) Then
                        BFLead = ""
                    Else
                        BFLead = PteamObject.records(i).Primary_Business_Function_Lead__c
                    End If
                    If IsNothing(PteamObject.records(i).Primary_Staff_Contact__c) Then
                        StafF = ""
                    Else
                        StafF = PteamObject.records(i).Primary_Staff_Contact__c
                    End If
                    If IsNothing(PteamObject.records(i).Priority__c) Then
                        Priority = ""
                    Else
                        Priority = PteamObject.records(i).Priority__c
                    End If
                    If IsNothing(PteamObject.records(i).Subject_Matter_Expert__c) Then
                        SME = ""
                    Else
                        SME = PteamObject.records(i).Subject_Matter_Expert__c
                    End If


                    dtPlan.Rows.Add((i + 1), Owner, PName, ApprovalStatus, LastSubmit, LastApprove, Approver, SME, PlanType, HNLead, BFLead, StafF, ApprovalPath, Priority, Manager, Director)

                Next

                CurrentPlan = dtPlan.Copy()

                dtPlan.Dispose()

            End If
        End If

        '=====================================================================================================================
        ' Process Key JSON text file
        '=====================================================================================================================
        Dim KTitle As String = ""
        If IO.File.Exists(filePath & KfileName) Then
            Dim jText As String = IO.File.ReadAllText(filePath & KfileName)

            If Not String.IsNullOrWhiteSpace(jText) Then

                Dim KteamObject As Example = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Example)(jText)

                For i = 0 To KteamObject.records.Count - 1

                    If IsNothing(KteamObject.records(i).FF__Title__c) Then
                        KTitle = ""
                    Else
                        KTitle = KteamObject.records(i).FF__Title__c.ToString()
                    End If

                    dtKey.Rows.Add((i + 1), KteamObject.records(i).Id.ToString, KteamObject.records(i).Name.ToString, KteamObject.records(i).FF__Full_Name__c.ToString, KteamObject.records(i).FF__Last_Name__c.ToString, KTitle, KteamObject.records(i).FF__Number_of_Rosters__c, KteamObject.records(i).FF__Number_of_Teams__c)
                Next

                CurrentKey = dtKey.Copy()

                dtKey.Dispose()

            End If
        End If

        '=====================================================================================================================
        ' Process User JSON text file
        '=====================================================================================================================
        Dim ULast As String = ""
        Dim UFirst As String = ""

        If IO.File.Exists(filePath & UfileName) Then
            Dim jText As String = IO.File.ReadAllText(filePath & UfileName)

            If Not String.IsNullOrWhiteSpace(jText) Then

                Dim UteamObject As UExample = Newtonsoft.Json.JsonConvert.DeserializeObject(Of UExample)(jText)

                For i = 0 To UteamObject.totalSize - 1

                    If IsNothing(UteamObject.records(i).LastName) Then
                        ULast = ""
                    Else
                        ULast = UteamObject.records(i).LastName.ToString()
                    End If

                    If IsNothing(UteamObject.records(i).FirstName) Then
                        UFirst = ""
                    Else
                        UFirst = UteamObject.records(i).FirstName.ToString()
                    End If

                    dtUser.Rows.Add((i + 1), UteamObject.records(i).Id.ToString, ULast, UFirst, UteamObject.records(i).Name.ToString)
                Next

                CurrentUser = dtUser.Copy()

                dtUser.Dispose()

            End If
        End If
        LoadPlans(CurrentPlan)

    End Sub

    Private Sub KeyFile()
        Dim client = CreateClient()
        client.Login()
        '=====================================================================================================================
        'Process query for basic User information to compare
        System.IO.File.WriteAllText("S:\Corp\CIS\BCD-DR\FRED\KeyPlanJSON.txt", "")
        Using file As System.IO.StreamWriter = New System.IO.StreamWriter("S:\Corp\CIS\BCD-DR\FRED\KeyPlanJSON.txt", True)

            If True Then
                file.WriteLine(client.Query("SELECT Id,	Name, FF__Full_Name__c,	FF__Last_Name__c, FF__Title__c,	FF__Number_of_Rosters__c, FF__Number_of_Teams__c from FF__Key_Contact__c"))
            End If
        End Using

    End Sub

    Private Sub UserFile()
        Dim client = CreateClient()
        client.Login()
        '=====================================================================================================================
        'Process query for basic User information to compare
        System.IO.File.WriteAllText("S:\Corp\CIS\BCD-DR\FRED\UserPlanJSON.txt", "")
        Using file As System.IO.StreamWriter = New System.IO.StreamWriter("S:\Corp\CIS\BCD-DR\FRED\UserPlanJSON.txt", True)

            If True Then
                file.WriteLine(client.Query("SELECT Id, LastName, FirstName, Name from User"))
            End If
        End Using

    End Sub
    Private Sub PlanFile()
        Dim client = CreateClient()
        client.Login()
        '=====================================================================================================================
        'Process query for basic User information to compare
        System.IO.File.WriteAllText("S:\Corp\CIS\BCD-DR\FRED\PlanJSON.txt", "")
        Using file As System.IO.StreamWriter = New System.IO.StreamWriter("S:\Corp\CIS\BCD-DR\FRED\PlanJSON.txt", True)

            If True Then
                file.WriteLine(client.Query("SELECT OwnerId, Name, Approval_Status__c, Last_Submitted_for_Approval__c, Last_Approved__c, Plan_Approver__c,Subject_Matter_Expert__c,	DRP_Plan_Type__c, HN_Leadership_Approver__c,Primary_Business_Function_Lead__c, Primary_Staff_Contact__c,Approval_Path__c, Priority__c, Plan_Manager__c, Plan_Director__c from FF__Plan__c"))
            End If
        End Using

    End Sub

    Private Sub LoadPlans(ByVal CPlan As DataTable)
        Dim PlanDataTable As New DataTable

        With PlanDataTable
            PlanDataTable.Columns.Add("id")
            PlanDataTable.Columns.Add("OwnerId")
            PlanDataTable.Columns.Add("Name")
            PlanDataTable.Columns.Add("ApprovalStatus")
            PlanDataTable.Columns.Add("LastSubmittedforApproval")
            PlanDataTable.Columns.Add("LastApproved")
            PlanDataTable.Columns.Add("PlanApprover")
            PlanDataTable.Columns.Add("SubjectMatterExpert")
            PlanDataTable.Columns.Add("DRPPlanType")
            PlanDataTable.Columns.Add("HNLeadershipApprover")
            PlanDataTable.Columns.Add("PrimaryBusinessFunctionLead")
            PlanDataTable.Columns.Add("PrimaryStaffContact")
            PlanDataTable.Columns.Add("Approval_Path__c")
            PlanDataTable.Columns.Add("Priority")
            PlanDataTable.Columns.Add("Plan_Manager")
            PlanDataTable.Columns.Add("Plan_Director")
        End With

        PlanDataTable = CPlan.Copy()

        For i = 0 To PlanDataTable.Rows.Count - 1

            CboxPlans.Items.Add(PlanDataTable.Rows(i).Item(2))
        Next
    End Sub

    Private Sub CboxPlans_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboxPlans.SelectedIndexChanged
        TxtActualStatus.Text = ""
        TxtLastApprove.Text = ""
        TxtLastSubmit.Text = ""
        TxtPlanType.Text = ""
        TxtPriority.Text = ""
        'People
        TxtOwner.Text = ""
        TxtApprover.Text = ""
        TxtSME.Text = ""
        TxtLeadApprover.Text = ""
        TxtBFLead.Text = ""
        TxtStaff.Text = ""
        TxtManager.Text = ""
        TxtDirector.Text = ""

        ActualPlan = CboxPlans.SelectedItem.ToString()

        CompareDataTables(CurrentKey, CurrentUser, CurrentPlan, ActualPlan)

    End Sub
    Private Sub CompareDataTables(ByVal CKey As DataTable, ByVal CUser As DataTable, ByVal CPlan As DataTable, ByVal APlan As String)

        Dim KeyDataTable As New DataTable
        Dim UserDataTable As New DataTable
        Dim PlanDataTable As New DataTable


        With UserDataTable
            UserDataTable.Columns.Add("id")
            UserDataTable.Columns.Add("uID")
            UserDataTable.Columns.Add("Last")
            UserDataTable.Columns.Add("First")
            UserDataTable.Columns.Add("Name")
        End With

        With KeyDataTable
            KeyDataTable.Columns.Add("id")
            KeyDataTable.Columns.Add("Uid")
            KeyDataTable.Columns.Add("Name")
            KeyDataTable.Columns.Add("FullName")
            KeyDataTable.Columns.Add("Last")
            KeyDataTable.Columns.Add("Title")
            KeyDataTable.Columns.Add("Rosters")
            KeyDataTable.Columns.Add("Teams")
        End With

        With PlanDataTable
            PlanDataTable.Columns.Add("id")
            PlanDataTable.Columns.Add("OwnerId")
            PlanDataTable.Columns.Add("Name")
            PlanDataTable.Columns.Add("ApprovalStatus")
            PlanDataTable.Columns.Add("LastSubmittedforApproval")
            PlanDataTable.Columns.Add("LastApproved")
            PlanDataTable.Columns.Add("PlanApprover")
            PlanDataTable.Columns.Add("SubjectMatterExpert")
            PlanDataTable.Columns.Add("DRPPlanType")
            PlanDataTable.Columns.Add("HNLeadershipApprover")
            PlanDataTable.Columns.Add("PrimaryBusinessFunctionLead")
            PlanDataTable.Columns.Add("PrimaryStaffContact")
            PlanDataTable.Columns.Add("Approval_Path__c")
            PlanDataTable.Columns.Add("Priority")
            PlanDataTable.Columns.Add("Plan_Manager")
            PlanDataTable.Columns.Add("Plan_Director")
        End With

        KeyDataTable = CKey.Copy()
        UserDataTable = CUser.Copy()
        PlanDataTable = CPlan.Copy()


        For i = 0 To PlanDataTable.Rows.Count - 1
            If ActualPlan = PlanDataTable.Rows(i).Item(2) Then

                'Items
                TxtActualStatus.Text = PlanDataTable.Rows(i).Item(3)
                TxtLastApprove.Text = PlanDataTable.Rows(i).Item(5)
                TxtLastSubmit.Text = PlanDataTable.Rows(i).Item(4)
                TxtPlanType.Text = PlanDataTable.Rows(i).Item(8)
                TxtPriority.Text = PlanDataTable.Rows(i).Item(13)

                'Owner
                For u = 0 To UserDataTable.Rows.Count - 1
                    If PlanDataTable.Rows(i).Item(1) = UserDataTable.Rows(u).Item(1) Then
                        TxtOwner.Text = UserDataTable.Rows(u).Item(4)
                    End If
                Next

                'SME
                For u = 0 To KeyDataTable.Rows.Count - 1
                    If PlanDataTable.Rows(i).Item(7) = KeyDataTable.Rows(u).Item(1) Then
                        TxtSME.Text = KeyDataTable.Rows(u).Item(3)
                    End If
                Next


                'Director
                For u = 0 To UserDataTable.Rows.Count - 1
                    If PlanDataTable.Rows(i).Item(15) = UserDataTable.Rows(u).Item(1) Then
                        TxtDirector.Text = UserDataTable.Rows(u).Item(4)
                    End If
                Next

                'Manager
                For u = 0 To UserDataTable.Rows.Count - 1
                    If PlanDataTable.Rows(i).Item(14) = UserDataTable.Rows(u).Item(1) Then
                        TxtManager.Text = UserDataTable.Rows(u).Item(4)
                    End If
                Next


                'Approver
                For u = 0 To UserDataTable.Rows.Count - 1
                    If PlanDataTable.Rows(i).Item(6) = UserDataTable.Rows(u).Item(1) Then
                        TxtApprover.Text = UserDataTable.Rows(u).Item(4)
                    End If
                Next


                'LeadApprover
                For u = 0 To UserDataTable.Rows.Count - 1
                    If PlanDataTable.Rows(i).Item(9) = UserDataTable.Rows(u).Item(1) Then
                        TxtLeadApprover.Text = UserDataTable.Rows(u).Item(4)
                    End If
                Next

                'BFLead
                For u = 0 To UserDataTable.Rows.Count - 1
                    If PlanDataTable.Rows(i).Item(10) = UserDataTable.Rows(u).Item(4) Then
                        TxtBFLead.Text = UserDataTable.Rows(u).Item(4)
                    End If
                Next

                'Staff
                For u = 0 To UserDataTable.Rows.Count - 1
                    If PlanDataTable.Rows(i).Item(11) = UserDataTable.Rows(u).Item(1) Then
                        TxtStaff.Text = UserDataTable.Rows(u).Item(4)
                    End If
                Next
            End If
        Next



    End Sub



End Class
