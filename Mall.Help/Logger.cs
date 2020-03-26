using log4net;
using log4net.Config;
using System;
using System.IO;

namespace Mall.Help
{
    public static class Logger
    {
        private static readonly ILog logdebug = LogManager.GetLogger("logdebug");
        private static readonly ILog loginfo = LogManager.GetLogger("loginfo");
        private static readonly ILog logerror = LogManager.GetLogger("logerror");

        static Logger()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + @"\Log4net.config";
            XmlConfigurator.ConfigureAndWatch(new FileInfo(path));
        }

        /// <summary>
        /// 写DEBUG日志
        /// </summary>
        /// <param name="debug">日志内容</param>
        public static void Debug(string debug)
        {
            if (logdebug.IsDebugEnabled)
            {
                logdebug.Debug(debug);
            }
        }

        /// <summary>
        /// 写DEBUG日志
        /// </summary>
        /// <param name="debug">日志内容</param>
        /// <param name="ex">将异常信息也写入日志</param>
        public static void Debug(string debug, Exception ex)
        {
            if (logdebug.IsDebugEnabled)
            {
                if (ex == null)
                {
                    logdebug.Debug(debug);
                }
                else
                {
                    logdebug.Debug(debug, ex);
                }
            }
        }

        /// <summary>
        /// 写Info信息到日志
        /// </summary>
        /// <param name="info">日志内容</param>
        public static void Info(string info)
        {
            if (loginfo.IsInfoEnabled)
            {
                loginfo.Info(info);
            }
        }

        /// <summary>
        /// 写error信息到日志
        /// </summary>
        /// <param name="error">日志内容</param>
        public static void Error(string error)
        {
            if (logerror.IsErrorEnabled)
            {
                logerror.Error(error);
            }
        }

        /// <summary>
        /// 写error信息到日志
        /// </summary>
        /// <param name="error">日志内容</param>
        /// <param name="ex">将异常信息也写入日志</param>
        public static void Error(string error, Exception ex)
        {
            if (logerror.IsErrorEnabled)
            {
                if (ex == null)
                {
                    logerror.Error(error);
                }
                else
                {
                    logerror.Error(error, ex);
                }
            }
        }

        /// <summary>
        /// 写error信息到日志
        /// </summary>
        /// <param name="error">日志内容</param>
        /// <param name="ex">将异常信息也写入日志</param>
        public static void Error(Exception ex)
        {
            if (logerror.IsErrorEnabled)
            {
                logerror.Error("", ex);
            }
        }

        private static string FormatErrorMsg(Exception ex)
        {
            var errorMsg = string.Format("【异常类型】：{0} <br>【异常信息】：{1} <br>【堆栈调用】：{2}",
                new object[] { ex.GetType().Name, ex.Message, ex.StackTrace });
            errorMsg = errorMsg.Replace("\r\n", "<br>");
            errorMsg = errorMsg.Replace("位置", "<strong style='color:red;'>位置</strong><br>");
            return errorMsg;
        }
    }
}