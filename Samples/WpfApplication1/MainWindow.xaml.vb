Imports System.Reflection
Imports IdeaRS.OpenModel.Message
Imports IdeaRS.OpenModel
Imports IdeaRS.OpenModel.Connection
Imports IdeaRS.OpenModel.CrossSection
Imports IdeaRS.OpenModel.Geometry3D
Imports IdeaRS.OpenModel.Loading
Imports IdeaRS.OpenModel.Material
Imports IdeaRS.OpenModel.Model
Imports IdeaRS.OpenModel.Result
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Text


Class MainWindow

  Dim openModel As IdeaRS.OpenModel.OpenModel
  Dim openModelR As OpenModelResult

  Private Sub Button_Click(sender As Object, e As RoutedEventArgs)

    Dim p As New ProcessStartInfo

    ' Specify the location of the binary
    p.FileName = "k:\IDEA_RS\SVN\Release_8_2\_Sources\bin\Debug\IOM_IDEAConnectionRunner.exe"

    Dim w As String = Chr(34) '34 is the ascii code for the sign "
    Dim SettingFile As String = "k:\IDEA_RS\SVN\NewDocs\Docs_Deve\01 Live projects\P47_Steel\IOM packet\Samples\WpfApplication1\Test\Settings_IOM.ini"

    p.Arguments = w & w & w & SettingFile & w & w & w

    ' Use these arguments for the process
    ' p.Arguments = "k:IDEA_RS\Projects\BugFix31\Settings_IOM.ini\"
    Dim saveFileDialog As String
    saveFileDialog = "k:\IDEA_RS\SVN\NewDocs\Docs_Deve\01 Live projects\P47_Steel\IOM packet\Samples\WpfApplication1\Test\testProject.xml"

    CreateIOM(saveFileDialog)
    ' Use a hidden window
    p.WindowStyle = ProcessWindowStyle.Normal

    ' Start the process
    Process.Start(p)
  End Sub

  Public Sub CreateIOM(saveFileDialog As string)
    CreateIDEAOpenModel()

    AddMaterialsToOpenModel()

    AddCrossSectionToOpenModel()

    AddNodesToOpenModel()

    CreateIDEAOpenModelConnection()

    AddLoadCasesToOpenModel()

    AddCombinationToOpenModel()

    CreateIDEAOpenModelResults()

    SaveToFiles(openModel, openModelR, saveFileDialog)

  End Sub

  Public Sub CreateIDEAOpenModel()

    openModel = New IdeaRS.OpenModel.OpenModel()

    openModel.OriginSettings = New OriginSettings()
    openModel.OriginSettings.CrossSectionConversionTable = CrossSectionConversionTable.NoUsed
    openModel.OriginSettings.ProjectName = "Project 1"
    openModel.OriginSettings.Author = "Author prj"
    openModel.OriginSettings.ProjectDescription = "Part 27"
    openModel.OriginSettings.DateOfCreate = DateTime.Now

  End Sub

  Private Sub AddMaterialsToOpenModel()
    Dim matOM As New MatSteelEc2()
    matOM.Id = openModel.GetMaxId(matOM) + 1
    matOM.Name = "S275"
    matOM.E = 210000000000.0
    matOM.G = matOM.E / (2 * (1 + 0.3))
    matOM.Poisson = 0.3
    matOM.UnitMass = 7870 / 9.81
    matOM.fu = 430000000
    matOM.fy = 275000000
    matOM.fu40 = 410000000
    matOM.fy40 = 255000000
    matOM.SpecificHeat = 0.49
    matOM.ThermalConductivity = 50.2
    matOM.ThermalExpansion = 0.000012

    openModel.AddObject(matOM)
  End Sub

  Private Sub AddCrossSectionToOpenModel()
    AddWeldedI()
  End Sub

  Private Sub AddWeldedI()
    'Example of custom I section
    Dim cssWI As New CrossSectionParameter()
    cssWI.Id = 1
    cssWI.Material = New ReferenceElement(openModel.MatSteel.FirstOrDefault())
    ' I have only one material, I take the first one
    CrossSectionFactory.FillWeldedI(cssWI, 0.2, 0.4, 0.025, 0.02)
    openModel.AddObject(cssWI)

    cssWI = New CrossSectionParameter()
    cssWI.Id = 2
    cssWI.Material = New ReferenceElement(openModel.MatSteel.FirstOrDefault())
    ' I have only one material, I take the first one
    cssWI.CrossSectionType = CrossSectionType.RolledI
    cssWI.Parameters.Add(New ParameterString() With {.Name = "UniqueName", .Value = "IPE80"})

    'openMessages.Add(OpenMessage.Create(MessageNumber.[Error], cssWI, "Nemam CssWi", "fofo"))
    openModel.AddObject(cssWI)
  End Sub

  Private Sub AddNodesToOpenModel()
    Dim pointA As New Point3D() With {.X = 3, .Y = 0, .Z = 0.0}
    pointA.Name = "N1"
    pointA.Id = 1
    openModel.AddObject(pointA)

    Dim pointB As New Point3D() With {.X = 3, .Y = 3, .Z = 3.6}
    pointB.Name = "N2"
    pointB.Id = 2
    openModel.AddObject(pointB)

    Dim pointC As New Point3D() With {.X = 3, .Y = 0, .Z = 3.6}
    pointC.Name = "N3"
    pointC.Id = 3
    openModel.AddObject(pointC)

    Dim pointD As New Point3D() With {.X = 6, .Y = 0, .Z = 3.6}
    pointD.Name = "N4"
    pointD.Id = 4
    openModel.AddObject(pointD)

    Dim pointE As New Point3D() With {.X = 3.0, .Y = 0, .Z = 7.2}
    pointE.Name = "N5"
    pointE.Id = 5
    openModel.AddObject(pointE)

    Dim pointF As New Point3D() With {.X = 6.0, .Y = 0, .Z = 7.2}
    pointF.Name = "N6"
    pointF.Id = 6
    openModel.AddObject(pointF)
  End Sub

  Private Sub CreateIDEAOpenModelConnection()
    Dim connection As New ConnectionPoint()
    connection.Node = New ReferenceElement(openModel.Point3D.FirstOrDefault(Function(n) n.Id = 3))
    connection.Id = 1
    connection.Name = "Con " + "N3"

    Dim conMb1 As ConnectedMember = AddConnectedMember(1, 1, 1, 3, 5)
    Dim conMb2 As ConnectedMember = AddConnectedMember(2, 2, 2, 3)
    Dim conMb3 As ConnectedMember = AddConnectedMember(3, 1, 3, 4)
    connection.ConnectedMembers.Add(conMb1)
    connection.ConnectedMembers.Add(conMb2)
    connection.ConnectedMembers.Add(conMb3)

    openModel.AddObject(connection)

    connection = New ConnectionPoint()
    connection.Node = New ReferenceElement(openModel.Point3D.FirstOrDefault(Function(n) n.Id = 6))
    connection.Id = 2
    connection.Name = "Con " + "N6"

    Dim con2Mb1 As ConnectedMember = AddConnectedMember(4, 1, 4, 6)
    Dim con2Mb2 As ConnectedMember = AddConnectedMember(5, 2, 5, 6)
    connection.ConnectedMembers.Add(con2Mb1)
    connection.ConnectedMembers.Add(con2Mb2)

    openModel.AddObject(connection)

  End Sub

  Private Function AddConnectedMember(idMember As Integer, idCss As Integer, idPointA As Integer, idPointB As Integer, idPointC As Integer) As ConnectedMember
    '		String name = "B" + mb.Id.ToString();

    Dim polyLine3D As New PolyLine3D()
    polyLine3D.Id = idMember
    Dim ls1 As New LineSegment3D()

    ls1.Id = openModel.GetMaxId(ls1) + 1
    openModel.AddObject(ls1)

    Dim ls2 As New LineSegment3D()
    ls2.Id = openModel.GetMaxId(ls2) + 1
    openModel.AddObject(ls2)

    openModel.AddObject(polyLine3D)

    ls1.StartPoint = New ReferenceElement(openModel.Point3D.FirstOrDefault(Function(c) c.Id = idPointA))
    ls1.EndPoint = New ReferenceElement(openModel.Point3D.FirstOrDefault(Function(c) c.Id = idPointB))
    polyLine3D.Segments.Add(New ReferenceElement(ls1))

    ls2.StartPoint = New ReferenceElement(openModel.Point3D.FirstOrDefault(Function(c) c.Id = idPointB))
    ls2.EndPoint = New ReferenceElement(openModel.Point3D.FirstOrDefault(Function(c) c.Id = idPointC))
    polyLine3D.Segments.Add(New ReferenceElement(ls2))

    Dim el1 As New Element1D()
    el1.Id = openModel.GetMaxId(el1) + 1
    el1.Name = "E" + (openModel.GetMaxId(el1) + 1).ToString()
    el1.Segment = New ReferenceElement(ls1)
    el1.CrossSectionBegin = New ReferenceElement(openModel.CrossSection.FirstOrDefault(Function(c) c.Id = idCss))
    el1.CrossSectionEnd = New ReferenceElement(openModel.CrossSection.FirstOrDefault(Function(c) c.Id = idCss))
    openModel.AddObject(el1)

    Dim el2 As New Element1D()
    el2.Id = openModel.GetMaxId(el2) + 1
    el2.Name = "E" + (openModel.GetMaxId(el2) + 1).ToString()
    el2.Segment = New ReferenceElement(ls2)
    el2.CrossSectionBegin = New ReferenceElement(openModel.CrossSection.FirstOrDefault(Function(c) c.Id = idCss))
    el2.CrossSectionEnd = New ReferenceElement(openModel.CrossSection.FirstOrDefault(Function(c) c.Id = idCss))
    openModel.AddObject(el2)

    Dim mb As New Member1D()
    mb.Id = idMember
    mb.Name = "B" + (openModel.GetMaxId(mb) + 1).ToString()
    mb.Elements1D.Add(New ReferenceElement(el1))
    mb.Elements1D.Add(New ReferenceElement(el2))
    openModel.Member1D.Add(mb)

    Dim conMb As New ConnectedMember()
    conMb.Id = mb.Id
    conMb.MemberId = New ReferenceElement(mb)
    Return conMb
  End Function

  Private Function AddConnectedMember(idMember As Integer, idCss As Integer, idPointA As Integer, idPointB As Integer) As ConnectedMember
    '		String name = "B" + mb.Id.ToString();

    Dim polyLine3D As New PolyLine3D()
    polyLine3D.Id = openModel.GetMaxId(polyLine3D) + 1
    Dim ls As New LineSegment3D()
    ls.Id = openModel.GetMaxId(ls) + 1

    openModel.AddObject(polyLine3D)
    openModel.AddObject(ls)

    ls.StartPoint = New ReferenceElement(openModel.Point3D.FirstOrDefault(Function(c) c.Id = idPointA))
    ls.EndPoint = New ReferenceElement(openModel.Point3D.FirstOrDefault(Function(c) c.Id = idPointB))
    polyLine3D.Segments.Add(New ReferenceElement(ls))

    Dim el As New Element1D()
    el.Id = openModel.GetMaxId(el) + 1
    el.Name = "E" + el.Id.ToString()
    el.Segment = New ReferenceElement(ls)
    el.CrossSectionBegin = New ReferenceElement(openModel.CrossSection.FirstOrDefault(Function(c) c.Id = idCss))
    el.CrossSectionEnd = New ReferenceElement(openModel.CrossSection.FirstOrDefault(Function(c) c.Id = idCss))
    openModel.AddObject(el)

    Dim mb As New Member1D()
    mb.Id = idMember
    mb.Name = "B" + mb.Id.ToString()
    mb.Elements1D.Add(New ReferenceElement(el))
    openModel.Member1D.Add(mb)

    Dim conMb As New ConnectedMember()
    conMb.Id = mb.Id
    conMb.MemberId = New ReferenceElement(mb)
    Return conMb
  End Function

  Private Sub AddLoadCasesToOpenModel()
    Dim loadCase As New LoadCase()
    loadCase.Name = "LC1"
    loadCase.Id = 1
    loadCase.Type = LoadCaseSubType.PermanentStandard

    Dim loadGroup As LoadGroupEC = Nothing

    loadGroup = New LoadGroupEC()
    loadGroup.Id = 1
    loadGroup.Name = "LG1"
    loadGroup.GammaQ = 1.5
    loadGroup.Psi0 = 0.7
    loadGroup.Psi1 = 0.5
    loadGroup.Psi2 = 0.3
    loadGroup.GammaGInf = 1.0
    loadGroup.GammaGSup = 1.35
    loadGroup.Dzeta = 0.85
    openModel.AddObject(loadGroup)

    loadCase.LoadGroup = New ReferenceElement(loadGroup)

    openModel.AddObject(loadCase)
  End Sub
  Private Sub AddCombinationToOpenModel()
    Dim combi As New CombiInputEC()
    combi.Name = "CO1"
    combi.TypeCombiEC = TypeOfCombiEC.ULS
    combi.TypeCalculationCombi = TypeCalculationCombiEC.Linear
    combi.Items = New List(Of CombiItem)()
    Dim it As New CombiItem()
    it.Id = 1
    it.LoadCase = New ReferenceElement(openModel.LoadCase.FirstOrDefault())
    it.Coeff = 1.0
    combi.Items.Add(it)
    openModel.AddObject(combi)
  End Sub

  Private Sub CreateIDEAOpenModelResults()
    openModelR = New OpenModelResult()
    openModelR.ResultOnMembers = New List(Of ResultOnMembers)()
    Dim resIF As New ResultOnMembers()
    'ResultType.InternalForces);
    For ib As Integer = 0 To openModel.Member1D.Count - 1
      'RobotBar barPtr = Collection.Get(ib) as RobotBar;
      Dim mb As Member1D = openModel.Member1D(ib)
      For iel As Integer = 0 To mb.Elements1D.Count - 1
        Dim elem As Element1D = openModel.Element1D.FirstOrDefault(Function(c) c.Id = mb.Elements1D(iel).Id)
        Dim resMember As New ResultOnMember(New Member() With {.Id = elem.Id, .MemberType = MemberType.Element1D}, ResultType.InternalForces)
        Dim numPoints As Integer = 1
        For ip As Integer = 0 To numPoints
          Dim resSec As New ResultOnSection()
          resSec.AbsoluteRelative = AbsoluteRelative.Relative

          resSec.Position = CDbl(ip) / CDbl(numPoints)
          'resSec.ResultOfLoading = new List<ResultOfLoading>();

          Dim num As Integer = openModel.LoadCase.Count
          For i As Integer = 1 To num
            Dim resLc As New ResultOfInternalForces()
            Dim loadCaseNumber As Integer = i
            resLc.Loading = New ResultOfLoading() With {.Id = loadCaseNumber, .LoadingType = LoadingType.LoadCase}
            resLc.Loading.Items.Add(New ResultOfLoadingItem() With {.Coefficient = 1.0})
            resLc.N = 5000
            resLc.Qy = 2
            resLc.Qz = 3
            resLc.Mx = 4
            resLc.My = (ip + 1) * 5000
            'Math.Sin(resSec.Position / lenght);
            resLc.Mz = 6
            'Debug.WriteLine(string.Format("No {0};{1};{2};{3};{4};{5}", resLc.N, resLc.Qy, resLc.Qz, resLc.Mx, resLc.My, resLc.Mz));
            resSec.Results.Add(resLc)
          Next
          resMember.Results.Add(resSec)
        Next
        resIF.Members.Add(resMember)
      Next
    Next
    openModelR.ResultOnMembers.Add(resIF)
  End Sub

  Protected Function SaveToFiles(openStructModel As OpenModel, openStructModelR As OpenModelResult, saveFileDialog As String) As Boolean
    Try
      If True Then
        Dim xs As New XmlSerializer(GetType(OpenModel))
        Dim fs As Stream = New FileStream(saveFileDialog, FileMode.Create)
        Dim writer As New XmlTextWriter(fs, Encoding.Unicode)
        ' Serialize using the XmlTextWriter.
        writer.Formatting = Formatting.Indented
        xs.Serialize(writer, openStructModel)
        writer.Close()
        fs.Close()
      End If
      If openStructModelR IsNot Nothing Then

        Dim xs As New XmlSerializer(GetType(OpenModelResult))

        Dim fs As Stream = New FileStream(saveFileDialog & Convert.ToString("R"), FileMode.Create)
        Dim writer As New XmlTextWriter(fs, Encoding.Unicode)
        ' Serialize using the XmlTextWriter.
        writer.Formatting = Formatting.Indented
        xs.Serialize(writer, openStructModelR)
        writer.Close()

        fs.Close()
      End If
      Return True
    Catch generatedExceptionName As Exception
      Return False
    End Try
  End Function


End Class
