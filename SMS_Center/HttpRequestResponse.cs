using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.IO;

namespace SMS_Center
{
    public class HttpRequestResponse
    {
        #region Variables
        private string URI = String.Empty;
        private string Request = String.Empty;
        private string UserName = String.Empty;
        private string UserPwd = String.Empty;
        private string ProxyServer = String.Empty;
        private int ProxyPort = 0;
        private string RequestMethod = "GET";
        #endregion

        #region Constructor
        public HttpRequestResponse(string pRequest, string pURI)
        {
            Request = pRequest;
            URI = pURI;
        }
        #endregion

        #region Properties
        public string HTTP_USER_NAME
        {
            get { return UserName; }
            set { UserName = value;}
        }

        public string HTTP_USER_PASSWORD
        {
            get { return UserPwd; }
            set { UserPwd = value; }
        }

        public string PROXY_SERVER
        {
            get { return ProxyServer; }
            set { ProxyServer = value; }
        }

        public int PROXY_PORT
        {
            get { return ProxyPort; }
            set { ProxyPort = value; }
        }
        #endregion

        #region SendRequest
        //This public interface receives the request and send the response of type string.
        public string SendRequest()
        {
            string FinalResponse = "";
            string Cookie = "";

            NameValueCollection collHeader = new NameValueCollection();

            HttpWebResponse webresponse;

            HttpBaseClass BaseHttp = new
              HttpBaseClass(UserName, UserPwd,
              ProxyServer, ProxyPort, Request);
            try
            {
                HttpWebRequest webrequest =
                  BaseHttp.CreateWebRequest(URI,
                  collHeader, RequestMethod, false);
                webresponse =
                 (HttpWebResponse)webrequest.GetResponse();

                string ReUri =
                  BaseHttp.GetRedirectURL(webresponse,
                  ref Cookie);
                //Check if there is any redirected URI.

                webresponse.Close();
                ReUri = ReUri.Trim();
                if (ReUri.Length == 0) //No redirection URI
                {
                    ReUri = URI;
                }
                RequestMethod = Settings.Default.HTTP_METHOD;
                FinalResponse = BaseHttp.GetFinalResponse(ReUri,
                                   Cookie, RequestMethod, true);

            }//End of Try Block
            catch (WebException e)
            {
                throw CatchHttpExceptions(FinalResponse = e.Message);
            }
            catch (System.Exception e)
            {
                throw new Exception(FinalResponse = e.Message);
            }
            finally
            {
                BaseHttp = null;
            }
            return FinalResponse;
        } //End of SendRequestTo method
        
        private WebException CatchHttpExceptions(string ErrMsg)
        {
            ErrMsg = "Error During Web Interface. Error is: " + ErrMsg;
            return new WebException(ErrMsg);
        }
        #endregion
    }//End of RequestResponse Class
}
