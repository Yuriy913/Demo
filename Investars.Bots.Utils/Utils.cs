using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Reflection;
using System.Xml.XPath;
using System.Collections.Generic;
using Investars.Bots.Utils.Misc;

namespace Investars.Bots.Utils.Application
{
    public class App
    {
        #region Variables
            public bool Debug = false;
            public string ConnString = "";
            public string ConnString_Quotes = "";
            public string ConnString_Master = "";
            public string ConnString_SupportDB = "";
            public string ConnString_InvestarsDB = "";
            public string ConnString_InvestarsTestDB = "";
            public string ConnString_SQL_DATA_SUPPORT_SupportDB = "";
            public string arg1 = "";
        #endregion
        public App(string[] args)
        {
            int argIndex = 0;
            foreach (string str in args)
            {
                argIndex++;
                if (str.ToLower() == "debug") Debug = true;
                if (argIndex == 1) arg1 = str;
            }

            //http://www.tweesta.com/WebAppCodeGod/XPathDocument-XPathNavigator-XPathNodeIterator-sample-with-C-AID504.aspx

            string bots_config = "bots.config";
            XPathDocument doc = null;

            if ((File.Exists(bots_config)) && (doc == null))
                doc = new XPathDocument(bots_config);

            if ((File.Exists(@"..\" + bots_config)) && (doc == null))
                doc = new XPathDocument(@"..\" + bots_config);

            if ((File.Exists(@"..\Bots\" + bots_config)) && (doc == null))
                doc = new XPathDocument(@"..\Bots\" + bots_config);

            if ((File.Exists(@"..\..\Bots\" + bots_config)) && (doc == null))
                doc = new XPathDocument(@"..\..\Bots\" + bots_config);

            if ((File.Exists(@"..\..\" + bots_config)) && (doc == null))
                doc = new XPathDocument(@"..\..\" + bots_config);

            if ((File.Exists(@"..\..\..\" + bots_config)) && (doc == null))
                doc = new XPathDocument(@"..\..\..\" + bots_config);

            if ((File.Exists(@"..\..\..\..\" + bots_config)) && (doc == null))
                doc = new XPathDocument(@"..\..\..\..\" + bots_config);

            if ((File.Exists(@"..\..\..\..\..\" + bots_config)) && (doc == null))
                doc = new XPathDocument(@"..\..\..\..\..\" + bots_config);

            if ((File.Exists(@"..\..\..\..\..\..\" + bots_config)) && (doc == null))
                doc = new XPathDocument(@"..\..\..\..\..\..\" + bots_config);

            if ((File.Exists(@"..\..\..\..\..\..\..\" + bots_config)) && (doc == null))
                doc = new XPathDocument(@"..\..\..\..\..\..\..\" + bots_config);

            if (doc != null)
            {
                XPathNavigator nav = doc.CreateNavigator();
                XPathNodeIterator iter = nav.Select("configuration/appSettings/add");
                foreach (XPathNavigator iNav in iter)
                {
                    if (iNav.GetAttribute("key", String.Empty) == "ConnString")
                        ConnString = iNav.GetAttribute("value", String.Empty);

                    if (iNav.GetAttribute("key", String.Empty) == "ConnString_Quotes")
                        ConnString_Quotes = iNav.GetAttribute("value", String.Empty);

                    if (iNav.GetAttribute("key", String.Empty) == "ConnString_Master")
                        ConnString_Master = iNav.GetAttribute("value", String.Empty);

                    if (iNav.GetAttribute("key", String.Empty) == "ConnString_SupportDB")
                        ConnString_SupportDB = iNav.GetAttribute("value", String.Empty);

                    if (iNav.GetAttribute("key", String.Empty) == "ConnString_InvestarsDB")
                        ConnString_InvestarsDB = iNav.GetAttribute("value", String.Empty);

                    if (iNav.GetAttribute("key", String.Empty) == "ConnString_InvestarsTestDB")
                        ConnString_InvestarsTestDB = iNav.GetAttribute("value", String.Empty);
                }
                iter = null;
                nav = null;
            }
            doc = null;
        }
    }
}

namespace Investars.Bots.Utils
{

	/// Type of Log Message
	public enum LogType
	{
		None = 0,
		Info = 1,
		Warning = 2,
		Error = 3
	}

	/// <summary>
	/// Sql Utils
	/// </summary>
	public class SqlUtils
	{
		/// <summary>
		/// SqlErrors
		/// </summary>
		public static int SqlErrors { get; set; }

		/// <summary>
		/// SqlErrorDescription
		/// </summary>
		public static string SqlErrorDescription { get; set; }

		/// <summary>
		/// ExecuteSqlCommand
		/// </summary>
		/// <param name="connstr"></param>
		/// <param name="sqlQuery"></param>
		/// <returns>DataSet</returns>
		public static DataSet ExecuteSqlCommand(string connstr, string sqlQuery)
		{
			var results = new DataSet();
			try
			{
				var conn = new SqlConnection(connstr);
				var command = new SqlCommand(sqlQuery, conn)
								  {
									  CommandType = CommandType.Text,
									  CommandTimeout = 0
								  };
				conn.Open();

				var da = new SqlDataAdapter(command);
				da.Fill(results, "Result");

                conn.Close(); //Added for fclose pool connection
				return results;
			}
			catch (Exception ex)
			{
				SqlErrors++;
				SqlErrorDescription = ex.Message;
				return new DataSet();
			}

		}

		/// <summary>
		/// Is Server Available
		/// </summary>
		/// <param name="connstr"></param>
		/// <returns></returns>
		public static bool IsServerAvailable(string connstr)
		{
			var conn = new SqlConnection(connstr);
			try
			{
				conn.Open();
				conn.Close();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}

	/// <summary>
	/// Strings Utils
	/// </summary>
	public class StringsUtils
	{
		/// <summary>
		/// GetWordByNumber
		/// </summary>
		/// <param name="source"></param>
		/// <param name="delimiterchar"></param>
		/// <param name="wordnumber"></param>
		/// <returns>string</returns>
		public static string GetWordByNumber(string source, char delimiterchar, int wordnumber)
		{
			source = Regex.Replace(source, @"\s{2,}", " ");
			var arr = source.Split(delimiterchar);

			if (arr.Length > 0 && wordnumber > 0)
			{
				if (wordnumber <= arr.Length)
					return arr[wordnumber - 1];
			}
			return String.Empty;
		}

		/// <summary>
		/// InvertString
		/// </summary>
		/// <param name="source"></param>
		/// <returns>string</returns>
		public static string InvertString(string source)
		{
			var len = source.Length;
			var res = new StringBuilder();
			for (var i = 0; i < len; i++)
				res.AppendLine(source.Substring(len - 1 - i, 1));
			return res.ToString();
		}

		/// <summary>
		/// CountWords
		/// </summary>
		/// <param name="source"></param>
		/// <returns>int</returns>
		public static int CountWords(string source)
		{
			var arr = source.Split(' ');
			return arr.Count(t => !string.IsNullOrEmpty(t));
		}

		/// <summary>
		/// CountWords
		/// </summary>
		/// <param name="source"></param>
		/// <param name="delim"></param>
		/// <returns></returns>
		public static int CountWords(string source, char delim)
		{
			var arr = source.Split(delim);
			return arr.Count(t => !string.IsNullOrEmpty(t));
		}

		/// <summary>
		/// IsLetterPresent
		/// </summary>
		/// <param name="source"></param>
		/// <returns>bool</returns>
		public static bool IsLetterPresent(string source)
		{
			return Regex.IsMatch(source, "[a-zA-Z]");
		}

		/// <summary>
		/// IsDigitPresent
		/// </summary>
		/// <param name="source"></param>
		/// <returns>bool</returns>
		public static bool IsDigitPresent(string source)
		{
			return Regex.IsMatch(source, "[0-9]");
		}

		/// <summary>
		/// IsNumeric
		/// </summary>
		/// <param name="source"></param>
		/// <returns>bool</returns>
		public static bool IsNumeric(string source)
		{
			return Regex.IsMatch(source, "^[0-9]+$");
		}

		/// <summary>
		/// IsValidDate
		/// </summary>
		/// <param name="source"></param>
		/// <returns>bool</returns>
		public static bool IsValidDate(string source)
		{
			DateTime dt;
			return DateTime.TryParse(source, out dt);
		}

		/// <summary>
		/// RemoveLastSymbol
		/// </summary>
		/// <param name="source"></param>
		/// <param name="symbol"></param>
		/// <returns>string</returns>
		public static string RemoveLastSymbol(string source, string symbol)
		{
			if (source.Substring(source.Length - 1) == symbol)
			{
				source = source.Remove(source.Length - 1, 1);
			}
			return source;
		}

		/// <summary>
		/// RemoveLettersFromString
		/// </summary>
		/// <param name="source"></param>
		/// <returns>string</returns>
		public static string RemoveLettersFromString(string source)
		{
			return Regex.Replace(source, @"[a-zA-Z]", String.Empty);
		}

		/// <summary>
		/// IsTextExistInFile
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="texttofind"></param>
		/// <returns>bool</returns>
		public static bool IsTextExistInFile(string fileName, string texttofind)
		{
			var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
			using (var sr = new StreamReader(fs))
			{
				var fullBody = sr.ReadToEnd();
				sr.Close();
				return (fullBody.ToLower(CultureInfo.InvariantCulture).Contains(texttofind));
			}
		}
	}

	/// <summary>
	/// Web Utils
	/// </summary>
	public class WebUtils
	{
		/// <summary>
		/// FileSize
		/// </summary>
		public static int FileSize { get; set; }

		/// <summary>
		/// sCookies
		/// </summary>
		public static string SCookies { get; set; }

		/// <summary>
		/// ErrorsCount
		/// </summary>
		public static int ErrorsCount { get; set; }

		/// <summary>
		/// ErrorDescription
		/// </summary>
		public static string ErrorDescription { get; set; }

		/// <summary>
		/// GetFileFromFtp
		/// </summary>
		/// <param name="fileNameToSave"></param>
		/// <param name="ftpaddress"></param>
		/// <param name="userName"></param>
		/// <param name="password"></param>
		/// <returns>bool</returns>
		public static bool GetFileFromFtp(string fileNameToSave, string ftpaddress, string userName, string password)
		{
			var outputStream = new FileStream(fileNameToSave, FileMode.Create);

			var reqFtp = (FtpWebRequest)WebRequest.Create(new Uri(ftpaddress));
			reqFtp.Method = WebRequestMethods.Ftp.DownloadFile;
			reqFtp.UseBinary = true;
			reqFtp.Credentials = new NetworkCredential(userName, password);
			var response = (FtpWebResponse)reqFtp.GetResponse();

			var ftpStream = response.GetResponseStream();
			const int bufferSize = 2048;
			var buffer = new byte[bufferSize];

			if (ftpStream != null)
			{
				var readCount = ftpStream.Read(buffer, 0, bufferSize);
				while (readCount > 0)
				{
					outputStream.Write(buffer, 0, readCount);
					readCount = ftpStream.Read(buffer, 0, bufferSize);
				}
				ftpStream.Close();
			}
			response.Close();

			outputStream.Close();
			return true;
		}

       
        /// <summary>
        /// getPageByURIUsedProxy
        /// </summary>
        /// <param name="address"></param>
        /// <returns>string</returns>
        ///used new lib xNet
<<<<<<< HEAD
        /*public static string getPageByURIUsedProxy(string URI)
=======
      /*  public static string getPageByURIUsedProxy(string URI)
>>>>>>> 2f5bbe1cd899246af2d68ee893c9681cf57ffe9d
        {
            string content;
            using (var request = new xNet.HttpRequest())
            {
                string IP = "186.148.189.27:8080"; //"91.215.176.27:81");
                //request.UserAgent = Http.ChromeUserAgent();
                var proxyClient = xNet.HttpProxyClient.Parse(IP);
                // request.Proxy = Socks5ProxyClient.Parse("91.215.176.27:81");
                content = request.Get(URI).ToString();
                //request.Post("/").None();

                // But in this request they will be gone.
                //request.Post("/").None();
                //   }
            }
            return content;
        }*/


		/// <summary>
		/// GetPageByUrl
		/// </summary>
		/// <param name="address"></param>
		/// <returns>string</returns>
		public static string GetPageByUrl(string address)
		{
			var ret = string.Empty;
			try
			{
                System.Net.ServicePointManager.SecurityProtocol |= System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12; 
                var wReq = HttpWebRequest.Create(address) as HttpWebRequest;
                wReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:51.0) Gecko/20100101 Firefox/51.0";
                //System.Net.ServicePointManager.SecurityProtocol|= System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12; //System.Net.SecurityProtocolType.Tls11 | 
                wReq.Timeout = 60 * 1000; //Timeout.Infinite; // 1 минута максимум
				var wRsp = wReq.GetResponse();

				var respStream = wRsp.GetResponseStream();
				if (respStream != null)
				{
					var reader = new StreamReader(respStream);
					ret = reader.ReadToEnd();
					reader.Close();
				}
				wRsp.Close();

				FileSize = ret.Length;
				ErrorsCount = 0;
				return ret;
			}
			catch (Exception e)
			{
				ErrorDescription = e.Message;
				ErrorsCount++;
				return ret;
			}
		}

	

        /// <summary>
        /// GetPageByUrl
        /// </summary>
        /// <param name="address"></param>
        /// <param name="saveToFileName"></param>
        /// <returns>sting</returns>
        public static string GetPageByUrl(string address, string saveToFileName)
        {
            var body = GetPageByUrl(address);
            using (var sw = new StreamWriter(saveToFileName))
            {
                sw.Write(body);
                sw.Close();
            }
            return body;
        }

		/// <summary>
		/// GetPageByPostMethod
		/// </summary>
		/// <param name="address"></param>
		/// <param name="postparams"></param>
		/// <returns>string</returns>
		public static string GetPageByPostMethod(string address, string postparams)
		{
			HttpWebRequest myHttpWebRequest;
			HttpWebResponse myHttpWebResponse;

			if (String.IsNullOrEmpty(SCookies))
			{
                System.Net.ServicePointManager.SecurityProtocol |= System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12;
				myHttpWebRequest = (HttpWebRequest)WebRequest.Create(address);
				myHttpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; MyIE2;";
               
				myHttpWebRequest.Accept =
					"image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
				myHttpWebRequest.Headers.Add("Accept-Language", "en-us;q=0.7,en;q=0.3");
				myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

				if (!String.IsNullOrEmpty(myHttpWebResponse.Headers["Set-Cookie"]))
				{
					SCookies = myHttpWebResponse.Headers["Set-Cookie"];
				}
			}

			myHttpWebRequest = (HttpWebRequest)WebRequest.Create(address);
			myHttpWebRequest.Method = "POST";
			myHttpWebRequest.Referer = address;
			myHttpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; MyIE2;";
			myHttpWebRequest.Accept =
				"image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
			myHttpWebRequest.Headers.Add("Accept-Language", "en-us;q=0.7,en;q=0.3");
			myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";

			if (!String.IsNullOrEmpty(SCookies))
			{
				myHttpWebRequest.Headers.Add(HttpRequestHeader.Cookie, SCookies);
			}

			myHttpWebRequest.AllowAutoRedirect = false;

			var byteArr = Encoding.GetEncoding(1251).GetBytes(postparams);
			myHttpWebRequest.ContentLength = byteArr.Length;
			myHttpWebRequest.GetRequestStream().Write(byteArr, 0, byteArr.Length);

			myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

			var datastream = myHttpWebResponse.GetResponseStream();
			return datastream != null ? new StreamReader(datastream).ReadToEnd() : string.Empty;
		}

		/// <summary>
		/// GetPageByPostMethod
		/// </summary>
		/// <param name="address"></param>
		/// <param name="postparams"></param>
		/// <param name="saveToFileName"></param>
		/// <returns>string</returns>
		public static string GetPageByPostMethod(string address, string postparams, string saveToFileName)
		{
			var body = GetPageByPostMethod(address, postparams);
			using (var sw = new StreamWriter(saveToFileName))
			{
				sw.Write(body);
				sw.Close();
			}
			return body;
		}

		/// <summary>
		///  GetPageByPostMethod WithoutCookies
		/// </summary>
		/// <param name="address"></param>
		/// <param name="postparams"></param>
		/// <param name="?"></param>
		/// <param name="saveToFileName"></param>
		/// <returns></returns>
		public static string GetPageByPostMethodWithoutCookies(string address, string postparams, string saveToFileName)
		{
			var body = GetPageByPostMethodWithoutCookies(address, postparams);
			using (var sw = new StreamWriter(saveToFileName))
			{
				sw.Write(body);
				sw.Close();
			}
			return body;
		}

		/// <summary>
		/// GetPageByPostMethod Without Cookies
		/// </summary>
		/// <param name="address"></param>
		/// <param name="postparams"></param>
		/// <returns></returns>
		public static string GetPageByPostMethodWithoutCookies(string address, string postparams)
		{
            System.Net.ServicePointManager.SecurityProtocol |= System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12;
			var myHttpWebRequest = (HttpWebRequest)WebRequest.Create(address);
			myHttpWebRequest.Method = "POST";
			myHttpWebRequest.Referer = address;
			myHttpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; MyIE2;";
            
			myHttpWebRequest.Accept =
				"image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
			myHttpWebRequest.Headers.Add("Accept-Language", "en-us;q=0.7,en;q=0.3");
			myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";

			myHttpWebRequest.AllowAutoRedirect = false;

			var byteArr = Encoding.GetEncoding(1251).GetBytes(postparams);
			myHttpWebRequest.ContentLength = byteArr.Length;
			myHttpWebRequest.GetRequestStream().Write(byteArr, 0, byteArr.Length);

			var myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

			var datastream = myHttpWebResponse.GetResponseStream();
			return datastream != null ? new StreamReader(datastream).ReadToEnd() : string.Empty;
		}

     /*   /// <summary>
        /// GetPageByPostMetodSpesial
        /// </summary>
        /// <param name="address"></param>
        /// <param name="saveToFileName"></param>
        /// <returns>sting</returns>
        public static string GetPageByPostMetodSpesial(string address)

        {
            address = @"https://publicresearch.barclays.com/priceTable/10005295.htm";
            System.Net.WebRequest reqPOST = (HttpWebRequest)WebRequest.Create(address);
            reqPOST.Method = "POST";
            reqPOST.Timeout = 120000;
            reqPOST.ContentType = "application/x-www-form-urlencoded";
            byte[] sentData = Encoding.GetEncoding(1251).GetBytes("");//sort_by=acceptance_datetime&page=3"); //здесь данные которые передаются на страницу php
            reqPOST.ContentLength = sentData.Length;
            System.IO.Stream sendStream = reqPOST.GetRequestStream();
            sendStream.Write(sentData, 0, sentData.Length);
            sendStream.Close();
            System.Net.WebResponse myHttpWebResponse = (HttpWebResponse)reqPOST.GetResponse();
            System.IO.Stream datastream = myHttpWebResponse.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(datastream);
            Console.WriteLine(sr);
            Console.WriteLine(address);
            return datastream != null ? new StreamReader(datastream).ReadToEnd() : string.Empty;
        }*/


		/// <summary>
		/// SendEmail
		/// </summary>
		/// <param name="host"></param>
		/// <param name="addressFrom"></param>
		/// <param name="addressTo"></param>
		/// <param name="messageSubject"></param>
		/// <param name="bodyHtml"></param>
		/// <param name="messageBody"></param>
		/// <param name="attachFileName"></param>
		public static void SendEmail(string host, string addressFrom, string addressTo, string messageSubject,
									 bool bodyHtml, string messageBody, string attachFileName)
		{
			var message = new MailMessage { IsBodyHtml = true, From = new MailAddress(addressFrom) };
			var sAddressTo = addressTo.Split(',');
			foreach (var t in sAddressTo)
			{
				message.To.Add(new MailAddress(t.Trim()));
			}
			message.IsBodyHtml = bodyHtml;

			message.Subject = messageSubject;
			message.Body = messageBody;
			if (attachFileName != null)
			{
				var data = new Attachment(attachFileName, MediaTypeNames.Application.Octet);
				message.Attachments.Add(data);
			}

			var client = new SmtpClient { Host = host, Port = 25 };
			client.Send(message);
		}

		/// <summary>
		/// SendEmail
		/// </summary>
		/// <param name="host"></param>
		/// <param name="port"></param>
		/// <param name="addressFrom"></param>
		/// <param name="addressTo"></param>
		/// <param name="messageSubject"></param>
		/// <param name="bodyHtml"></param>
		/// <param name="messageBody"></param>
		/// <param name="attachFileName"></param>
		public static void SendEmail(string host, int port, string addressFrom, string addressTo, string messageSubject,
									 bool bodyHtml, string messageBody, string attachFileName)
		{
			var message = new MailMessage
							  {
								  IsBodyHtml = bodyHtml,
								  From = new MailAddress(addressFrom),
								  Subject = messageSubject,
								  Body = messageBody
							  };

			var sAddressTo = addressTo.Split(',');
			foreach (var t in sAddressTo)
			{
				message.To.Add(new MailAddress(t.Trim()));
			}

			if (attachFileName != null)
			{
				message.Attachments.Add(new Attachment(attachFileName, MediaTypeNames.Application.Octet));
			}

			var client = new SmtpClient { Host = host, Port = port };
			client.Send(message);
		}
	}

	/// <summary>
	/// Logger
	/// </summary>
	public class Logger
	{
		private readonly string strLogFile;
		private bool isReady;
		private StreamWriter swLog;

		/// <summary>
		/// Logger
		/// </summary>
		/// <param name="LogFileName"></param>
		public Logger(string LogFileName)
		{
			strLogFile = LogFileName;
			openFile();
			closeFile();
		}

		/// <summary>
		/// Open File
		/// </summary>
		private void openFile()
		{
			try
			{
				swLog = File.AppendText(strLogFile);
				swLog.AutoFlush = true;
				isReady = true;
			}
			catch
			{
				isReady = false;
			}
		}

		/// <summary>
		/// Close File
		/// </summary>
		private void closeFile()
		{
			if (isReady)
			{
				swLog.Close();
			}
		}

		/// <summary>
		/// Write Line
		/// </summary>
		/// <param name="message"></param>
		/// <param name="logtype"></param>
		public void WriteLine(string message, LogType logtype)
		{
			var stub = new StringBuilder(DateTime.Now.ToString());
			switch (logtype)
			{
				case LogType.Info:
					stub.AppendLine(" Info: ");
					break;
				case LogType.Warning:
					stub.AppendLine(" Warning: ");
					break;
				case LogType.Error:
					stub.AppendLine(" Error: ");
					break;
				case LogType.None:
					stub.AppendLine(string.Empty);
					break;
			}
			stub.AppendLine(message);
			openFile();
			_writelog(stub.ToString());
			closeFile();
			if (logtype == LogType.Error)
				Console.WriteLine(stub);
		}

		/// <summary>
		/// Write Log
		/// </summary>
		/// <param name="msg"></param>
		private void _writelog(string msg)
		{
			if (isReady)
			{
				swLog.WriteLine(msg);
			}
		}
	}
}

namespace Investars.Bots.Utils.Misc
{

    public class TaskType_Param
    {
        public int TaskTypeID;
        public int ScheduleID;
        public string connectionString;
        public bool ConsoleDebug = false;
        public int TaskID;


        public TaskType_Param(int _TaskTypeID, int _ScheduleID, string _connectionString, int _TaskID)
        {
            TaskTypeID = _TaskTypeID;
            ScheduleID = _ScheduleID;
            connectionString = _connectionString;
            TaskID = _TaskID;
        }
    }

    public class TaskType_Param_2
    {
        public int TaskTypeID;
        public string connectionString;
        public bool ConsoleDebug = false;
        public int TaskID;

        public TaskType_Param_2(int _TaskTypeID, int _TaskID, string _connectionString)
        {
            TaskTypeID = _TaskTypeID;
            TaskID = _TaskID;
            connectionString = _connectionString;
        }
    }
    
    public class TaskTypeID_Execute
    {
        public TaskTypeID_Execute(object p)
        {
            Util util = new Util();
            int Version = 0;
            bool ConsoleDebug = false;
            TaskType_Param ttp = null;
            TaskType_Param_2 ttp2 = null;
            string connectionString;
            //------------------------------------------------ 
            try {
                ttp2 = (TaskType_Param_2)p; 
                Version = 2;
            }
            catch //(Exception ex)
            {}

            if (Version == 0)
                try{
                    ttp = (TaskType_Param)p;
                    Version = 1;
                }
                catch //(Exception ex)
                {}
            //------------------------------------------------ 
            int TaskTypeID = 0, TaskID = 0, Trace_TaskID = 0;
            if (Version == 1)
            {
                TaskTypeID = ttp.TaskTypeID;
                TaskID = ttp.TaskID;
                connectionString = ttp.connectionString;
                ConsoleDebug = ttp.ConsoleDebug;
            }
            else
            {
                TaskTypeID = ttp2.TaskTypeID;
                TaskID = ttp2.TaskID;
                connectionString = ttp2.connectionString;
                ConsoleDebug = ttp2.ConsoleDebug;
            }
            try
            {
                if (File.Exists("TaskType" + TaskTypeID + ".dll"))
                {
                    if (Trace_TaskID==TaskID)
                        util.CHECK_POINT_SendMail_v2(connectionString, "TaskID[" + TaskID.ToString() + "], Version=" + Version.ToString() + " - PASSED:0", "17");

                    Assembly SampleAssembly = Assembly.LoadFrom("TaskType" + TaskTypeID + ".dll");

                    if (Trace_TaskID == TaskID)
                        util.CHECK_POINT_SendMail_v2(connectionString, "TaskID[" + TaskID.ToString() + "], Version=" + Version.ToString() + " - PASSED:1", "17");

                    Type type = SampleAssembly.GetType("TaskType" + TaskTypeID + ".TaskType");

                    if (Trace_TaskID == TaskID)
                        util.CHECK_POINT_SendMail_v2(connectionString, "TaskID[" + TaskID.ToString() + "], Version=" + Version.ToString() + " - PASSED:2", "17");
                    
                    object obj = Activator.CreateInstance(type);

                    if (Trace_TaskID == TaskID)
                        util.CHECK_POINT_SendMail_v2(connectionString, "TaskID[" + TaskID.ToString() + "], Version=" + Version.ToString() + " - PASSED:3", "17");
                    
                    MethodInfo Method = type.GetMethod("work");

                    if (Trace_TaskID == TaskID)
                        util.CHECK_POINT_SendMail_v2(connectionString, "TaskID[" + TaskID.ToString() + "], Version=" + Version.ToString() + " - PASSED:4", "17");
                    
                    object[] parametersArray = new object[] { p };

                    if (Trace_TaskID == TaskID)
                        util.CHECK_POINT_SendMail_v2(connectionString, "TaskID[" + TaskID.ToString() + "], Version=" + Version.ToString() + " - PASSED:5", "17");
                    
                    Method.Invoke(obj, parametersArray);

                    if (Trace_TaskID == TaskID)
                        util.CHECK_POINT_SendMail_v2(connectionString, "TaskID[" + TaskID.ToString() + "], Version=" + Version.ToString() + " - PASSED:6", "17");
                }
                else
                    if (ConsoleDebug)
                        Console.WriteLine("TaskTypeID_Execute: Not Exists TaskType" + TaskTypeID.ToString() + ".dll");
                    else
                        util.CHECK_POINT_SendMail_v2(connectionString, "TaskTypeID_Execute: Not Exists TaskType" + TaskTypeID.ToString() + ".dll", "17");

                if (ConsoleDebug)
                    Console.WriteLine("thread_done");
            }
            catch (Exception ex)
            {
                if (ConsoleDebug)
                    Console.WriteLine(ex.Message);
                else
                    util.CHECK_POINT_SendMail_v2(connectionString, "TaskID=[" + TaskID.ToString() + "], Version=" + Version .ToString()+ ", " + ex.Message, "17");
            }
        }

        private void SendMail(string Text)
        {
            Mail mail = new Mail("yuri@investars.com");
            mail.AddString(Text);
            mail.Send();
        }
    }

    public class Util
    {
        public string sr_HHMMSS = DateTime.Now.ToString("hhmmss"); //{HHMMSS}
        //----------------------------------------------------------------------------
        public string sr_YYYYMMDD = DateTime.Today.ToString("yyyyMMdd"); //{YYYYMMDD}
        public string sr_MMDDYYYY = DateTime.Today.ToString("MMddyyyy"); //{MMDDYYYY}
        public string sr_DDMMYYYY = DateTime.Today.ToString("ddMMyyyy"); //{DDMMYYYY}

        public string sr_YYMMDD = DateTime.Today.ToString("yyMMdd"); //{YYMMDD}
        public string sr_MMDDYY = DateTime.Today.ToString("MMddyy"); //{MMDDYY}
        public string sr_DDMMYY = DateTime.Today.ToString("ddMMyy"); //{DDMMYY}

        public string sr_YYYYMM = DateTime.Today.ToString("yyyyMM"); //{YYYYMM}
        public string sr_YYMM = DateTime.Today.ToString("yyMM");    //{YYMM}

        public string sr_MMdd = DateTime.Today.ToString("MMdd");        //{MM}

        public string sr_MM = DateTime.Today.ToString("MM");        //{MM}
        public string sr_DD = DateTime.Today.ToString("dd");        //{DD}
        public string sr_YYYY = DateTime.Today.ToString("yyyy");    //{YYYY}
        public string sr_YY = DateTime.Today.ToString("yy");        //{YY}

        public string sr_YYYYMMDD_HHMMSS = DateTime.Now.ToString("yyyyMMdd_HHmmss"); //{YYYYMMDD_HHMMSS}
        public string sr_YYYYMMDD_HHMM = DateTime.Now.ToString("yyyyMMdd_HHmm"); //{YYYYMMDD_HHMM}
        //----------------------------------------------------------------------------
        public DateTime PreviousDate;// = DateTime.Today.AddDays(-1);
        public DateTime PreviousDateTime;// = DateTime.Now.AddDays(-1);

        public string sr_YYYYMMDD_D1;// = PreviousDate.ToString("yyyyMMdd"); //{YYYYMMDD-D1}
        public string sr_MMDDYYYY_D1;// = PreviousDate.ToString("MMddyyyy"); //{MMDDYYYY-D1}
        public string sr_DDMMYYYY_D1;// = PreviousDate.ToString("ddMMyyyy"); //{DDMMYYYY-D1}

        public string sr_YYMMDD_D1;// = PreviousDate.ToString("yyMMdd"); //{YYMMDD-D1}
        public string sr_MMDDYY_D1;// = PreviousDate.ToString("MMddyy"); //{MMDDYY-D1}
        public string sr_DDMMYY_D1;// = PreviousDate.ToString("ddMMyy"); //{DDMMYY-D1}

        public string sr_YYYYMM_D1;// = PreviousDate.ToString("yyyyMM"); //{YYYYMM-D1}
        public string sr_YYMM_D1;// = PreviousDate.ToString("yyMM");    //{YYMM-D1}

        public string sr_MMdd_D1;// = PreviousDate.ToString("MMdd");        //{MM-D1}

        public string sr_MM_D1;// = PreviousDate.ToString("MM");        //{MM-D1}
        public string sr_DD_D1;// = PreviousDate.ToString("dd");        //{DD-D1}
        public string sr_YYYY_D1;// = PreviousDate.ToString("yyyy");    //{YYYY-D1}
        public string sr_YY_D1;// = PreviousDate.ToString("yy");        //{YY-D1}

        public string sr_YYYYMMDD_HHMMSS_D1;// = PreviousDateTime.ToString("yyyyMMdd_HHmmss"); //{YYYYMMDD_HHMMSS-D1}
        public string sr_YYYYMMDD_HHMM_D1;// = PreviousDateTime.ToString("yyyyMMdd_HHmm"); //{YYYYMMDD_HHMM-D1}
        //----------------------------------------------------------------------------

        public string sr_QUOTE = "\"";
        public string sr_AMP = "&";
        public string sr_LESS = "<";
        public string sr_MORE = ">";
        public string sr_APO = "'";

        public Util()
        {
            PreviousDate = DateTime.Today.AddDays(-1);
            PreviousDateTime = DateTime.Now.AddDays(-1);

            sr_YYYYMMDD_D1 = PreviousDate.ToString("yyyyMMdd"); //{YYYYMMDD-D1}
            sr_MMDDYYYY_D1 = PreviousDate.ToString("MMddyyyy"); //{MMDDYYYY-D1}
            sr_DDMMYYYY_D1 = PreviousDate.ToString("ddMMyyyy"); //{DDMMYYYY-D1}

            sr_YYMMDD_D1 = PreviousDate.ToString("yyMMdd"); //{YYMMDD-D1}
            sr_MMDDYY_D1 = PreviousDate.ToString("MMddyy"); //{MMDDYY-D1}
            sr_DDMMYY_D1 = PreviousDate.ToString("ddMMyy"); //{DDMMYY-D1}

            sr_YYYYMM_D1 = PreviousDate.ToString("yyyyMM"); //{YYYYMM-D1}
            sr_YYMM_D1 = PreviousDate.ToString("yyMM");    //{YYMM-D1}

            sr_MMdd_D1 = PreviousDate.ToString("MMdd");        //{MM-D1}

            sr_MM_D1 = PreviousDate.ToString("MM");        //{MM-D1}
            sr_DD_D1 = PreviousDate.ToString("dd");        //{DD-D1}
            sr_YYYY_D1 = PreviousDate.ToString("yyyy");    //{YYYY-D1}
            sr_YY_D1 = PreviousDate.ToString("yy");        //{YY-D1}

            sr_YYYYMMDD_HHMMSS_D1 = PreviousDateTime.ToString("yyyyMMdd_HHmmss"); //{YYYYMMDD_HHMMSS-D1}
            sr_YYYYMMDD_HHMM_D1 = PreviousDateTime.ToString("yyyyMMdd_HHmm"); //{YYYYMMDD_HHMM-D1}
        }

        public string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public string clear_value(string s)
        {
            string value = s;
            value = value.Replace("&#39;", "'");
            value = value.Replace("&#40;", "(");
            value = value.Replace("&#41;", ")");
            value = value.Replace("&rsquo;", "'");
            value = value.Replace("'", "''");
            value = value.Replace("&amp;", "&");
            MatchCollection mc = Regex.Matches(value, ".*?(?<Clear>[<].*?[>]).*?");
            if (mc.Count > 0)
                foreach (Match mv in mc)
                {
                    string clearSubStr = mv.Groups["Clear"].Value;
                    value = value.Replace(clearSubStr, "");
                }
            return value;
        }

        public string replace_place_to_value(string str)
        {
            str = str.Replace("{Q}", sr_QUOTE);
            str = str.Replace("{A}", sr_AMP);
            str = str.Replace("{P}", sr_APO);
            str = str.Replace("{L}", sr_LESS);
            str = str.Replace("{M}", sr_MORE);
            str = change_date_mask(str);
            return str;
        }

        public string change_date_mask(string str)
        {
            str = str.Replace("{HHMMSS}", sr_HHMMSS);
            //---------------------------------------------
            str = str.Replace("{YYYYMMDD}", sr_YYYYMMDD);
            str = str.Replace("{MMDDYYYY}", sr_MMDDYYYY);
            str = str.Replace("{DDMMYYYY}", sr_DDMMYYYY);

            str = str.Replace("{YYMMDD}", sr_YYMMDD);
            str = str.Replace("{MMDDYY}", sr_MMDDYY);
            str = str.Replace("{DDMMYY}", sr_DDMMYY);

            str = str.Replace("{YYYYMM}", sr_YYYYMM);
            str = str.Replace("{YYMM}", sr_YYMM);

            str = str.Replace("{MMDD}", sr_MMdd);

            str = str.Replace("{MM}", sr_MM);
            str = str.Replace("{DD}", sr_DD);
            str = str.Replace("{YYYY}", sr_YYYY);
            str = str.Replace("{YY}", sr_YY);

            str = str.Replace("{YYYYMMDD_HHMMSS}", sr_YYYYMMDD_HHMMSS);
            str = str.Replace("{YYYYMMDD_HHMM}", sr_YYYYMMDD_HHMM);
            //---------------------------------------------
            str = str.Replace("{YYYYMMDD-D1}", sr_YYYYMMDD_D1);
            str = str.Replace("{MMDDYYYY-D1}", sr_MMDDYYYY_D1);
            str = str.Replace("{DDMMYYYY-D1}", sr_DDMMYYYY_D1);

            str = str.Replace("{YYMMDD-D1}", sr_YYMMDD_D1);
            str = str.Replace("{MMDDYY-D1}", sr_MMDDYY_D1);
            str = str.Replace("{DDMMYY-D1}", sr_DDMMYY_D1);

            str = str.Replace("{YYYYMM-D1}", sr_YYYYMM_D1);
            str = str.Replace("{YYMM-D1}", sr_YYMM_D1);

            str = str.Replace("{MMDD-D1}", sr_MMdd_D1);

            str = str.Replace("{MM-D1}", sr_MM_D1);
            str = str.Replace("{DD-D1}", sr_DD_D1);
            str = str.Replace("{YYYY-D1}", sr_YYYY_D1);
            str = str.Replace("{YY-D1}", sr_YY_D1);

            str = str.Replace("{YYYYMMDD_HHMMSS-D1}", sr_YYYYMMDD_HHMMSS_D1);
            str = str.Replace("{YYYYMMDD_HHMM-D1}", sr_YYYYMMDD_HHMM_D1);
            //---------------------------------------------
            return str;
        }

        public string full_time()
        {
            string result = "";
            DateTime time1 = DateTime.Now;
            int Year, Month, Day, Hour, Minute, Second, Millisecond;
            Year = time1.Year; result += Year.ToString(); result += "-";
            Month = time1.Month; if (Month < 10) result += "0"; result += Month.ToString(); result += "-";
            Day = time1.Day; if (Day < 10) result += "0"; result += Day.ToString(); result += " ";
            Hour = time1.Hour; if (Hour < 10) result += "0"; result += Hour.ToString(); result += ":";
            Minute = time1.Minute; if (Minute < 10) result += "0"; result += Minute.ToString(); result += ":";
            Second = time1.Second; if (Second < 10) result += "0"; result += Second.ToString(); result += ":";
            Millisecond = time1.Millisecond;
            if (Millisecond < 10) result += "0";
            if (Millisecond < 100) result += "0";
            result += Millisecond.ToString();
            return result;
        }

        public void CHECK_POINT_SendMail(string connStr, string Text, string TaskID = "")
        {
            CHECK_POINT_SendMail_v2(connStr, Text, "", "", TaskID);
        }
        public void CHECK_POINT_SendMail_v2(string connStr, string Message, string UnitID = "", string TypeID = "", string ForeignID = "", string NodeCode = "")
        {
            try
            {
                if (UnitID == "") UnitID = "1";
                if (TypeID == "") TypeID = "1";
                if (ForeignID == "") ForeignID = "0";
                if ((ForeignID != "0") && (UnitID == "1")) UnitID = "2";
                //if (Text.Length > 899)
                //    Text = Text.Substring(1, 899);
                Message = Message.Replace("'", "''"); // + "*"
                //string sqlCmd = "EXEC SupportDB.dbo.bot_errors_add @Message='" + Text + "', @TaskID='" + TaskID + "'";
                string sqlCmd = "EXEC SupportDB.dbo.alert_message_add";
                sqlCmd += " @Message='" + Message + "'";
                sqlCmd += ",@UnitID='" + UnitID + "'";
                sqlCmd += ",@TypeID='" + TypeID + "'";
                sqlCmd += ",@ForeignID='" + ForeignID + "'";
                sqlCmd += ",@NodeCode='" + NodeCode + "'";
                Sql sql = new Sql(connStr);
                sql.Execute(sqlCmd);
                if (sql.error)
                {
                    Mail mail = new Mail("yuri@investars.com");
                    //Mail mail = new Mail("support@investars.com");
                    mail.AddString("Investars.Bots.Utils.dll:CHECK_POINT_SendMail:" + Message + ": [SqlError]:" + sql.errorMessage + ", [SQL:]" + sqlCmd);
                    mail.Send();
                }
            }
            catch 
            {
            }
        }

    }

    public class Mail
    {
        private string MailHost, MailFrom, MailTo, MailSublect;
        private StringBuilder sb = new StringBuilder();
        public bool addedStrings = false;
        public bool mailSended = false; 
        //----------------------------
        public Mail(string EmailTo, bool Mobile = false, int AnyID = -1, string Name_AnyID = "", string tableTitle = "")
        {
            this.MailHost = "investars.com";
            this.MailFrom = "errors@investars.com";
            this.MailTo = EmailTo;
            this.MailSublect = "MultiTask_FormBot";
            if (!Mobile)
            {
                sb.Append("<HTML><BODY>");
                if (Name_AnyID !="")
                    sb.Append("<P>" + Name_AnyID + ": " + AnyID.ToString() + " </P>");
                else
                    sb.Append("<P>TaskScheduleID: " + AnyID.ToString() + " </P>");
                sb.Append("<TABLE border cellspacing='0' cellpadding='0' style='font-size: 12px;'>");
                if (tableTitle.Trim() !="")
                    sb.Append("<TR><TH bgcolor=red align=left>" + tableTitle + "</TH></TR>");
                else 
                    sb.Append("<TR><TH bgcolor=red>Object Errors</TH></TR>");
            }
        }
        public void AddString(string str1, bool MultiLines = false)
        {
            if (!addedStrings)
            {
                if (!MultiLines)
                    addedStrings = true;
                sb.Append("<TR><TD>" + str1 + "</TD></TR>");
            }
        }
        public void Send(bool Mobile = false)
        {
            if (!Mobile)
                sb.Append("</TABLE></BODY></HTML>");
            if (!mailSended)
                WebUtils.SendEmail(MailHost, MailFrom, MailTo, MailSublect, true, sb.ToString(), null);
            addedStrings = false;
            mailSended = true;
        }
    }

    public class Sql
    {
        #region Variables
        private SqlConnection sqlConnection = new SqlConnection();
        private SqlCommand sqlCommand = new SqlCommand();
        private bool connectionKeep;
        public SqlParameter[] Parameters;
        public DataSet dataSet;
        public bool error = false;
        public string errorMessage = "";
        #endregion
        public Sql(string connectionString, bool keepConnection = false)
        {
            connectionKeep = keepConnection;
            sqlConnection.ConnectionString = connectionString;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandTimeout = 120;
        }

        /*
         Sql Sql1 = new Sql(); 
         * 
         String Value1              = Sql1.sqlCommandExecute("DELETE Table1 WHERE ID = 114", null, "Nonquery").ToString();
         String Value1              = Sql1.sqlCommandExecute("SELECT COUNT(*) FROM Table1", null, "Nonquery").ToString(); 
         GridView1.DataSource       = Sql1.sqlCommandExecute("SELECT TOP 10 * FROM Table1", null, "Reader");
         SomeGridView.DataSource    = Sql1.sqlCommandExecute("SELECT TOP 10 * FROM someTable", null, "DataSet");
         SqlDataReader reader       = Sql1.sqlCommandExecute("StoredProcedureName or SQL command, SqlParameters, "Reader") as SqlDataReader;
         * 
         *with Parameters
         SqlParameter[] SqlParameters = new SqlParameter[2];
         * 
         SqlParameters[0] = new SqlParameter("@SomeParam1", Param1Value);
         * 
         SqlParameter SomeParam1 = new SqlParameter("@SomeParam1", SqlDbType.NVarChar, 100);   
         SomeParam1.Value = "Param1Value"; 
         SqlParameters[0] = SomeParam1; 
      
         SqlParameters[1] = new SqlParameter("@SomeParam2", Param2Value);
      
      
         */

        public void Execute(String sqlCommandString, bool withParameters = false)
        {
            if (withParameters)
                sqlCommandExecute(sqlCommandString, Parameters);
            else
                sqlCommandExecute(sqlCommandString, null);
        }

        public void sqlCommandExecute(String sqlCommandString, SqlParameter[] sqlParameters = null)
        {
            if (sqlCommandString.Trim().IndexOf(" ") == -1)
                sqlCommand.CommandType = CommandType.StoredProcedure;
            else
                sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlCommandString;
            if (sqlParameters != null)
            {
                if (sqlCommand.Parameters.Count > 0)
                    sqlCommand.Parameters.Clear();
                foreach (SqlParameter sqlParameter in sqlParameters)
                    if (sqlParameter != null)
                        sqlCommand.Parameters.Add(sqlParameter);
            }
            error = false; errorMessage = "";

            dataSet = new DataSet();
            try //TRY: First
            {
                if (sqlConnection.State != ConnectionState.Open)
                    sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                error = true;
                errorMessage = ex.Message;
            }
            if (sqlConnection.State == ConnectionState.Open)
                sqlConnection.Close();

            if (error) 
            {
                error = false; errorMessage = "";
                try //TRY: Second
                {
                    if (sqlConnection.State != ConnectionState.Open)
                        sqlConnection.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(dataSet);
                }
                catch (Exception ex)
                {
                    error = true;
                    errorMessage = ex.Message;
                }
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
            }
        }
    }

    public class Ftp
    {
        #region Variables & Members
            public bool error = false;
            public string errorMessage = "";
            //FtpWebRequest request;
            //FtpWebResponse response;
            string ftpDirURI, userName, password;
            DataTable dataTable;
            public int last_check_file_code = 0;
            public string last_check_file_message = "";
            public DateTime last_check_file_time = DateTime.Parse("1900-01-01 01:01");
            Util util = new Util();
        #endregion  

        public Ftp(string FtpDirURI, string UserName = "", string Password = "")
        {
            ftpDirURI = FtpDirURI;
            userName = UserName;

            int indexOf = ftpDirURI.IndexOf("://");
            if (indexOf == -1)
                ftpDirURI = "ftp://" + ftpDirURI;
                //ftpDirURI = "ftp://" + userName +"@"+ ftpDirURI;

            password = Password;
            dataTable = new DataTable();
            dataTable.Columns.Add("FileName", typeof(string));
            dataTable.Columns.Add("FileTime", typeof(DateTime));
            dataTable.Columns.Add("FileSize", typeof(int));
        }

        public void Download_File(string FileName, string ToDir, string RemoteDir = "")
        {
            try
            {
                string FtpURI = "";
                if (RemoteDir == "")
                    FtpURI = ftpDirURI + "//" + FileName;
                else
                    FtpURI = ftpDirURI + RemoteDir + FileName;

                ToDir = util.ReverseString(ToDir);
                if (ToDir.Substring(0, 1) == "\\")
                    ToDir = ToDir.Substring(1);
                ToDir = util.ReverseString(ToDir);
                string fileNameToSave = ToDir + "\\" + FileName;
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FtpURI);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(userName, password);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                var outputStream = new FileStream(fileNameToSave, FileMode.Create);
                var ftpStream = response.GetResponseStream();
                const int bufferSize = 2048;
                var buffer = new byte[bufferSize];
                if (ftpStream != null)
                {
                    var readCount = ftpStream.Read(buffer, 0, bufferSize);
                    while (readCount > 0)
                    {
                        outputStream.Write(buffer, 0, readCount);
                        readCount = ftpStream.Read(buffer, 0, bufferSize);
                    }
                    ftpStream.Close();
                }
                response.Close();
                outputStream.Close();
            }
            catch (Exception ex)
            {
                error = true;
                errorMessage = ex.Message;
            }
        }

        public string Get_String_Of_Files()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpDirURI);//"ftp://ftp.investars.com/"
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            request.Credentials = new NetworkCredential(userName, password);
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string result = reader.ReadToEnd();
            reader.Close();
            response.Close();
            return result;
        }

        public DataTable Get_DataTable_Of_Files()
        {
            string strYear = DateTime.Today.Year.ToString();
            if (dataTable.Rows.Count > 0)
                dataTable.Rows.Clear();
            string List_Of_Items = Get_String_Of_Files();
            List_Of_Items = List_Of_Items.Replace("\n", "");
            char[] delim = new char[2] { '\r', '\n' };
            string[] Items = List_Of_Items.Split(delim);
            foreach (string Item in Items)
            {
                if (Item.Length > 0)
                    if (Item.Substring(0, 1) != "d")
                    {
                        string item = Item.Substring(Item.IndexOf("group") + 5).Trim();
                        string FileSize = item.Substring(0, item.IndexOf(' '));
                        item = item.Substring(item.IndexOf(' ') + 1);
                        string FileTime = strYear+" "+item.Substring(0, item.IndexOf(':') + 3);
                        string FileName = item.Substring(item.IndexOf(':') + 4);
                        DataRow row = dataTable.NewRow();
                        row["FileSize"] = FileSize;
                        row["FileTime"] = FileTime;
                        row["FileName"] = FileName;
                        dataTable.Rows.Add(row);
                    }
            }
            return dataTable;
        }

        public int Check_File(string FileName, DateTime FileTime)
        {
            int result = 0; 
            if (dataTable.Rows.Count == 0)
                Get_DataTable_Of_Files();

            foreach (DataRow row in dataTable.Rows)
            {
                if (result != 0) break;
                string fileName = (string)row["FileName"];
                if (fileName == FileName)
                {
                    result = 1;
                    last_check_file_message = "FileName Detected";
                    DateTime fileTime = (DateTime)row["FileTime"];
                    last_check_file_time = fileTime;
                    if (fileTime == FileTime)
                    {
                        result = 2;
                        last_check_file_message = "FileTime Equal";
                    }
                    else
                        if (fileTime < FileTime)
                        {
                            result = 3;
                            last_check_file_message = "FileTime Old";
                        }
                        else
                        {
                            result = 4;
                            last_check_file_message = "FileTime New";
                        }
                }
            }
            last_check_file_code = result;
            return result;
        }

        public void Check_And_Download_New_File(string FileName, DateTime FileTime, string ToDir)
        {
            if (Check_File(FileName, FileTime) == 4) //NewFile
                Download_File(FileName, ToDir);
        }

        public bool Exists_Downloaded_New_Files(string LocalDir)
        {
            bool result = false;
            string[] files = Directory.GetFiles(LocalDir, "*.*");
            if (files.Length > 0)
                result = true;
            return result;
        }

        //Download
        //http://msdn.microsoft.com/en-us/library/ms229711%28v=vs.110%29.aspx
        //Upload
        //http://msdn.microsoft.com/en-us/library/ms229715%28v=vs.110%29.aspx

    }

    public class Web2
    {
        #region Variables
        #endregion

        public Web2()
        {
        }

        //=====================================================================
        public string Proxy_GetPageByUrl(int ProxyID, string address)
        {
            string response = string.Empty;
            string sqlCmd = "EXEC bot_proxy_params @ProxyID=" + ProxyID.ToString();
            string connectionString = "user id=botclient;password=tatamas4k;data source=SQL_DATA_SUPPORT;persist security info=True;initial catalog=SupportDB";
            Sql sql = new Sql(connectionString);
            sql.Execute(sqlCmd);
            if (sql.error) { }
            else
            {
                string IP         = sql.dataSet.Tables[0].Rows[0]["IP"].ToString();
                int Port          = int.Parse(sql.dataSet.Tables[0].Rows[0]["Port"].ToString());
                //string PortType = sql.dataSet.Tables[0].Rows[0]["PortType"].ToString();
                Console.WriteLine("PROXY: ID : " + ProxyID.ToString() + ", IP : " + IP + ", Port : " + Port.ToString());
                WebRequest webRequest = WebRequest.Create(address);
                webRequest.Proxy = new WebProxy(IP, Port);

                //https://bozza.ru/art-280.html                

                //((System.Net.HttpWebRequest)webRequest).UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)";

                //webRequest.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                //webRequest.Headers.Add("user-agent", "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)");
                                                    //Mozilla/5.0 (compatible; Googlebot/2.1; +http://www.google.com/bot.html)"
                                                    //Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)
                //webRequest.Headers.Add("user-agent", "Opera/9.80 (Windows NT 5.1; U; ru) Presto/2.9.168 Version/11.51");

                try
                {
                    DateTime Time1 = DateTime.Now;
                    using (Stream responseStream = webRequest.GetResponse().GetResponseStream())
                    {
                        DateTime Time2 = DateTime.Now;
                        var reader = new StreamReader(responseStream);
                        response   = reader.ReadToEnd();
                        reader.Close();
                        Console.WriteLine("RESPONSE RECEIVED.");
                        TimeSpan span = Time2 - Time1;
                        double Speed = span.Milliseconds;
                        Speed /= 1000;
                        sqlCmd = "EXEC bot_proxy_response @ProxyID = " + ProxyID.ToString() + ", @Speed = " + Speed.ToString() + ", @GoodResp = 1";
                        sql.Execute(sqlCmd);
                        if (sql.error) { }
                    }
                }
                catch (WebException wex)
                {
                    Console.WriteLine(wex.Message);
                    sqlCmd = "EXEC bot_proxy_response @ProxyID = " + ProxyID.ToString() + ", @Speed = 0, @GoodResp = 0";
                    sql.Execute(sqlCmd);
                }
            }
            return response;
        }

    }
}