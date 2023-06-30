using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.TestTools;

namespace Ransom.Tests
{
    public class LogUtility_RuntimeTests
    {
        public class FileLogHandler : ILogHandler
        {
            private string _filePath = default;
            private FileStream _fileStream = default;
            private StreamWriter _streamWriter = default;
            private ILogHandler  _defaultLogHandler = Debug.unityLogger.logHandler;

            public FileLogHandler(string fileName)
            {
                // if (_fileStream is object) { return; }

                // LogUtility.Log($"Persistent Data Path: <color=yellow><b>{Application.persistentDataPath}</b></color>");
                
                _filePath = $"{Application.persistentDataPath}/LogUtility_RuntimeTests{fileName}.txt";
                _fileStream = File.Open(_filePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
                // _streamWriter = new StreamWriter(_fileStream);

                Debug.unityLogger.logHandler = this;
            }

            public FileLogHandler() : this(null) {}

            public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
            {
                // using (_streamWriter = File.AppendText(_filePath))
                // {
                //     _streamWriter.WriteLine(String.Format(format, args));
                //     _streamWriter.Flush();
                //     _streamWriter.Close();
                // }
                
                _defaultLogHandler.LogFormat(logType, context, format, args);
                // Debug.unityLogger.LogFormat(logType, context, format, args);
            }

            public void LogException(Exception exception, UnityEngine.Object context)
            {
                _defaultLogHandler.LogException(exception, context);
                // Debug.unityLogger.LogException(exception, context);
            }
        }

        [UnityTest]
        public IEnumerator Log_LogsCorrectMessage()
        {
            // var fileLogHandler = new FileLogHandler("_LogsCorrectMessage");

            LogUtility.UseLogger = true;
            var context = new GameObject();
            var expectedMessage = "Test Log Message";

            yield return null;

            LogUtility.Log(expectedMessage, context);
            LogAssert.Expect(LogType.Log, expectedMessage);
        }

        [UnityTest]
        public IEnumerator LogError_LogsCorrectMessage()
        {
            // var fileLogHandler = new FileLogHandler("_LogsCorrectMessage");

            LogUtility.UseLogger = true;
            var context = new GameObject();
            var expectedMessage = "Test Log Error Message";

            yield return null;

            LogUtility.LogError(expectedMessage, context);
            LogAssert.Expect(LogType.Error, expectedMessage);
        }

        [UnityTest]
        public IEnumerator LogWarning_LogsCorrectMessage()
        {
            // var fileLogHandler = new FileLogHandler("_LogsCorrectMessage");

            LogUtility.UseLogger = true;
            var context = new GameObject();
            var expectedMessage = "Test Log Warning Message";

            yield return null;

            LogUtility.LogWarning(expectedMessage, context);
            LogAssert.Expect(LogType.Warning, expectedMessage);
        }

        [UnityTest]
        public IEnumerator Log_DoesNotLog()
        {
            // var fileLogHandler = new FileLogHandler("_LogsCorrectMessage");

            LogUtility.UseLogger = false;
            var context = new GameObject();
            var expectedMessage = "Test Log Message";

            yield return null;

            LogUtility.Log(expectedMessage, context);
            LogAssert.NoUnexpectedReceived();
        }

        [UnityTest]
        public IEnumerator LogError_DoesNotLog()
        {
            // var fileLogHandler = new FileLogHandler("_LogsCorrectMessage");

            LogUtility.UseLogger = false;
            var context = new GameObject();
            var expectedMessage = "Test Log Error Message";

            yield return null;

            LogUtility.LogError(expectedMessage, context);
            LogAssert.NoUnexpectedReceived();
        }

        [UnityTest]
        public IEnumerator LogWarning_DoesNotLog()
        {
            // var fileLogHandler = new FileLogHandler("_LogsCorrectMessage");

            LogUtility.UseLogger = false;
            var context = new GameObject();
            var expectedMessage = "Test Log Warning Message";

            yield return null;

            LogUtility.LogWarning(expectedMessage, context);
            LogAssert.NoUnexpectedReceived();
        }
    }
}
