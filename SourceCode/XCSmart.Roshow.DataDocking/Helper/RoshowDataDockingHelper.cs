using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using XCSmart.Roshow.DataDocking.Models;

namespace XCSmart.Roshow.DataDocking.Helper
{
    public class RoshowDataDockingHelper
    {

        //电池厂调用接口令牌
        private readonly string _token = null;
        //电池厂调用接口密钥
        private readonly string _aesEncryptKey = null;           // 通过 Java 中的AES Key 转换为 CSharp 中的AES Key
        private readonly string _md5EncryptKey = null;           // Java 中的 Key

        // 请求地址
        private readonly string _url = null;

        public RoshowDataDockingHelper()
        {
            _url = ConfigurationManager.AppSettings["roshowDockingUrl"];
            _token = ConfigurationManager.AppSettings["roshowDockingToken"];
            _aesEncryptKey = ConfigurationManager.AppSettings["roshowDockingAESEncryptKey"];
            _md5EncryptKey = ConfigurationManager.AppSettings["roshowDockingMD5EncryptKey"];
        }

        public string DockingData(List<Dictionary<string, object>> dockingData)
        {
            string resultMessage = "";

            // 测试数据
            // dockingData = GetPackList(2);

            string dockingJson = Newtonsoft.Json.JsonConvert.SerializeObject(dockingData);

            // 对Json数据进行加密
            string enStr = AESEncode(dockingJson, _aesEncryptKey);
            // 进行Sign 的信息加密
            string sign = GetSign(enStr, _md5EncryptKey);

            // 定义请求对象信息
            Dictionary<string, object> requestMap = new Dictionary<string, object>();
            requestMap.Add("requestMsg", enStr);
            requestMap.Add("timestamp", ConvertDateTimeToInt(DateTime.Now));
            requestMap.Add("sign", sign);

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(_url);
            req.Method = "POST";
            req.Headers.Add("Authorization", "Bearer " + _token);
            req.ContentType = "application/json; charset=utf-8";

            byte[] inputs = Encoding.Default.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(requestMap));
            req.ContentLength = inputs.Length;

            // 获取输入参数
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(inputs, 0, inputs.Length);
                reqStream.Close();
            }

            // 发送通讯请求
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                resultMessage = reader.ReadToEnd();
            }

            return ResolveDockingResult(resultMessage);
        }

        /// <summary>
        /// 解析 对接返回信息
        /// </summary>
        /// <param name="resultMessage"></param>
        /// <returns></returns>
        private string ResolveDockingResult(string resultMessage)
        {
            StringBuilder stringBuilder = new StringBuilder();

            RoshowResultModel roshowResult = Newtonsoft.Json.JsonConvert.DeserializeObject<RoshowResultModel>(resultMessage);

            stringBuilder.AppendFormat("通讯情况：{0}", roshowResult.Msg);
            stringBuilder.AppendLine();

            string dataJson = AESDecrypt(roshowResult.Data, _aesEncryptKey);
            if (dataJson != null)
            {
                RoshowDataModel roshowData = Newtonsoft.Json.JsonConvert.DeserializeObject<RoshowDataModel>(dataJson);

                roshowData.ErrorMessages.ForEach((errorMessage) =>
                {
                    stringBuilder.AppendFormat("{0}:{1}", errorMessage.id, errorMessage.Message);
                    stringBuilder.AppendLine();
                });
            }


            return stringBuilder.ToString();
        }

        /// <summary>
        /// 将时间转换位时间戳
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns>时间戳</returns>
        private long ConvertDateTimeToInt(DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            long t = (time.Ticks - startTime.Ticks) / 10000;   //除10000调整为13位      
            return t;
        }


        #region 测试数据生成

        public List<Dictionary<string, object>> GetPackList(int packCount)
        {
            // string currentTime = DateTime.Now.ToString("mmssfff");
            string currentTime = "";
            //电池模组数据集
            List<Dictionary<string, object>> packList = new List<Dictionary<string, object>>();

            for (int i = 0; i < packCount; i++)
            {
                Dictionary<string, object> pack = new Dictionary<string, object>();

                //电池包编码
                string packCode = $"CSP{currentTime}{i.ToString("0#")}";
                pack.Add("code", packCode);

                //电池模组数据集
                IList<Dictionary<string, object>> moduleList = GetModuleList(packCode, 10);
                pack.Add("moduleList", moduleList);

                pack.Add("serial", "1");                                    //储能装置中的编号
                pack.Add("modelId", "LX-P-LFP-02P100S");                    //电池包型号
                pack.Add("systemId", packCode);           //所属储能装置编码
                pack.Add("systemModelId", "LX-P-LFP-02P100S");              //储能装置型号
                pack.Add("orderNo", "4500063142");                          //订单号

                packList.Add(pack);
            }

            return packList;
        }

        private IList<Dictionary<string, object>> GetModuleList(string prefix, int moduleCount)
        {
            //电池模组数据集
            List<Dictionary<string, object>> moduleList = new List<Dictionary<string, object>>();

            for (int i = 0; i < moduleCount; i++)
            {
                Dictionary<string, object> module = new Dictionary<string, object>();

                //电池包模组
                string moduleCode = $"{prefix}MM{i.ToString("0#")}";
                module.Add("code", moduleCode);
                //电池单体数据集
                IList<string> cellList = GetModuleCellList(moduleCode, 20);
                module.Add("cellList", cellList);
                //模块型号
                module.Add("modelId", "BNB-M-2P10S");
                //单体型号
                module.Add("cellModelId", "BNB-M-2P10S");

                moduleList.Add(module);
            }

            return moduleList;
        }

        private IList<string> GetModuleCellList(string prefix, int cellCount)
        {
            //电池单体数据集
            List<string> cellList = new List<string>();

            for (int i = 0; i < cellCount; i++)
            {
                //电池单体编码
                cellList.Add($"{prefix}C{i.ToString("0#")}");
            }

            return cellList;
        }
        #endregion


        #region AES 加解密 MD5加解密
        /// <summary>
        /// 加密可用
        /// </summary>
        /// <param name="encryptString">明文信息</param>
        /// <param name="encryptKey">密钥</param>
        /// <returns>加密后的信息</returns>
        private string AESEncode(string encryptString, string encryptKey)
        {
            if (string.IsNullOrEmpty(encryptString)) return null;
            Byte[] toEncryptArray = Encoding.UTF8.GetBytes(encryptString);
            RijndaelManaged rm = new RijndaelManaged
            {
                Key = Convert.FromBase64String(encryptKey),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform = rm.CreateEncryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// 解密可用
        /// </summary>
        /// <param name="dencryptString">密文信息</param>
        /// <param name="encryptKey">密钥</param>
        /// <returns>明文信息</returns>
        private string AESDecrypt(string dencryptString, string encryptKey)
        {
            if (string.IsNullOrEmpty(dencryptString)) return null;
            Byte[] toEncryptArray = Convert.FromBase64String(dencryptString);

            System.Security.Cryptography.RijndaelManaged rm = new RijndaelManaged
            {
                Key = Convert.FromBase64String(encryptKey),
                Mode = System.Security.Cryptography.CipherMode.ECB,
                Padding = System.Security.Cryptography.PaddingMode.PKCS7
            };

            System.Security.Cryptography.ICryptoTransform cTransform = rm.CreateDecryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Encoding.UTF8.GetString(resultArray);
        }

        /// <summary>
        /// 获取MD5签名加密
        /// </summary>
        /// <param name="signStr">签名信息</param>
        /// <param name="encryptKey">密钥</param>
        /// <returns>获取签名</returns>
        private string GetSign(string signStr, string encryptKey)
        {
            HMACMD5 provider = new HMACMD5(Encoding.UTF8.GetBytes(encryptKey));
            byte[] hashedPassword = provider.ComputeHash(Encoding.UTF8.GetBytes(signStr));

            string t2 = BitConverter.ToString(hashedPassword);
            t2 = t2.Replace("-", "");
            return t2.ToLower();
        }
        #endregion
    }
}
