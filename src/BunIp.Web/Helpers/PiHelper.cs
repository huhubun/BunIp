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
                var model = File.ReadAllText(MODEL_PATH).TrimEnd((char)0);
                // 只有真的是树莓派前缀开头的才返回
                if (model.StartsWith(MODEL_PREFIX, StringComparison.InvariantCultureIgnoreCase))
                {
                    return model;
                }
            }

            return null;
        }
    }
}
