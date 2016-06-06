//------------------------------------------------------------------------------
//
// Copyright (c) Microsoft Corporation.
// All rights reserved.
//
// This code is licensed under the MIT License.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files(the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and / or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions :
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//------------------------------------------------------------------------------

using System;
using System.Globalization;

namespace Microsoft.IdentityModel.Clients.ActiveDirectory
{
    internal class Logger : LoggerBase
    {
        static Logger()
        {
            AdalEventSource = new AdalEventSource();
        }

        internal static AdalEventSource AdalEventSource { get; private set; }

        internal override void Error(CallState callState, Exception ex, [System.Runtime.CompilerServices.CallerFilePath] string callerFilePath = "")
        {
            string log = PrepareLogMessage(callState, GetCallerFilename(callerFilePath), ex.ToString());
            AdalEventSource.Error(log);
            LoggerCallbackHandler.ExecuteCallback(LogLevel.Error, log);
        }

        internal override void Verbose(CallState callState, string message, [System.Runtime.CompilerServices.CallerFilePath] string callerFilePath = "")
        {
            string log = PrepareLogMessage(callState, GetCallerFilename(callerFilePath), message);
            AdalEventSource.Verbose(log);
            LoggerCallbackHandler.ExecuteCallback(LogLevel.Verbose, log);
        }

        internal override void Information(CallState callState, string message, [System.Runtime.CompilerServices.CallerFilePath] string callerFilePath = "")
        {
            string log = PrepareLogMessage(callState, GetCallerFilename(callerFilePath), message);
            AdalEventSource.Information(log);
            LoggerCallbackHandler.ExecuteCallback(LogLevel.Information, log);
        }

        internal override void Warning(CallState callState, string message, [System.Runtime.CompilerServices.CallerFilePath] string callerFilePath = "")
        {
            string log = PrepareLogMessage(callState, GetCallerFilename(callerFilePath), message);
            AdalEventSource.Warning(log);
            LoggerCallbackHandler.ExecuteCallback(LogLevel.Warning, log);
        }
    }
}
