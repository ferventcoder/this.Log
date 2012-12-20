// ==============================================================================
// 
// RealDimensions Software, LLC - Copyright © 2012 - Present - Released under the Apache 2.0 License
// 
// Copyright 2007-2008 The Apache Software Foundation.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
//
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
// ==============================================================================

namespace $rootnamespace$
{

    /// <summary>
    /// Make sure this is added to a console x86 project (not Client Profile). Set the startup object to SampleRun. Take a look at the logging folder afterwards.
    /// </summary>
    public class SampleRun
    {
        private static void Main(string[] args)
        {
            LoggingExtensions.Logging.Log.InitializeWith<LoggingExtensions.NLog.NLogLog>();

            "Main".Log().Info(() => "This is a logging message");
        } 
    }
}