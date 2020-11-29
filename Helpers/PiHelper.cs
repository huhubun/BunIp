using System.IO;

namespace IpTest.Helpers
{
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

                if (model.StartsWith(MODEL_PREFIX))
                {
                    return model;
                }
            }

            return null;
        }
    }
}
