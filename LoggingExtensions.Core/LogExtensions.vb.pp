' ==============================================================================
' 
' RealDimensions Software, LLC - Copyright © 2012 - Present - Released under the Apache 2.0 License
' 
' Copyright 2007-2008 The Apache Software Foundation.
'  
' Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
' this file except in compliance with the License. You may obtain a copy of the 
' License at 
'
'     http://www.apache.org/licenses/LICENSE-2.0 
' 
' Unless required by applicable law or agreed to in writing, software distributed 
' under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
' CONDITIONS OF ANY KIND, either express or implied. See the License for the 
' specific language governing permissions and limitations under the License.
' ==============================================================================

Imports System.Collections.Concurrent
Imports System.Runtime.CompilerServices
Imports LoggingExtensions.Logging

''' <summary>
''' Extensions to help make logging awesome - this should be installed into the root namespace of your application
''' </summary>
Public Module LogExtensions

    ''' <summary>
    ''' Concurrent dictionary that ensures only one instance of a logger for a type.
    ''' </summary>
    Private ReadOnly _dictionary As ConcurrentDictionary(Of String, ILog) = New ConcurrentDictionary(Of String, ILog)

    ''' <summary>
    ''' Gets the logger for type indicated.
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="type">The type to get the logger for.</param>
    ''' <returns>Instance of a logger for the object.</returns>
    <Extension()>
    Public Function Log(Of T)(type As T) As ILog
        Dim objectName As String = GetType(T).FullName

        Return Log(objectName)
    End Function

    ''' <summary>
    ''' Gets the logger for the specified object name.
    ''' </summary>
    ''' <param name="objectName">Either use the fully qualified object name or the short. If used with Log(Of T)() you must use the fully qualified object name"/></param>
    ''' <returns>Instance of a logger for the object.</returns>
    <Extension()>
    Public Function Log(objectName As String) As ILog
        Return _dictionary.GetOrAdd(objectName, Function(name) (LoggingExtensions.Logging.Log.GetLoggerFor(name)))
    End Function

End Module