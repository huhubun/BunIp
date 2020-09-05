using System;
using System.IO;

namespace BunIp.Web.Helpers
{
    /// <summary>
    /// 树莓派帮助类
    /// </summary>
    public static class PiHelper
    {
        const string MODEL_PATH = "/proc/device-tree/model";
        const string MODEL_PREFIX = "Raspberry Pi";

        /// <summary>
        /// 获取树莓派版本号
        /// </summary>
        /// <returns></returns>
        public static string GetModel()
        {
            if (File.Exists(MODEL_PATH))
            {
                using (var fs = File.Open(MODEL_PATH, FileMode.Open, FileAccess.Read))
                using (var sr = new StreamReader(fs))
                {
                    var result = sr.ReadToEnd();

                    // 只有真的是树莓派前缀开头的才返回
                    if (result.StartsWith(MODEL_PREFIX, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return result;
                    }
                }
            }

            return null;
        }
    }
}
