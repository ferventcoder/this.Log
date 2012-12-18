Public Module SampleRun

    ''' <summary>
    ''' The main entry point for the application.
    ''' </summary>
    Public Sub Main(ByVal args() As String)
        LoggingExtensions.Logging.Log.InitializeWith(Of LoggingExtensions.log4net.Log4NetLog)()

        Dim test As New TestClass()
        test.Noop()
    End Sub

End Module
