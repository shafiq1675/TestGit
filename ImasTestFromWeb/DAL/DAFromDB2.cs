using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Xml;
using System.Net;
using System.Text;
using System.IO;

namespace ImasTestFromWeb.DAL
{
    public class DAFromDB2
    {
        public void InsertTest()
        {
            OdbcConnection conn = new OdbcConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ImasConnection"].ConnectionString;//"Dsn=QTEST;uid=IMASGRNF;pwd=IMAS321";

            try
            {

                conn.Open();
                using (OdbcCommand cmd = new OdbcCommand())
                {

                    string inquery1 = @"INSERT INTO QTESTRRE.XOITC(TRNNTC,TRNSTC,USRDTC,FRCFTC,ORXSTC,WHSNTC,CUSNTC,CURCTC,OIDTTC,INSDTC,CORNTC,OCDTTC,
                                                                   ORDTTC,XRDTTC,CASFTC, TRDTTC,EICNTC, USRTTC, DEDTTC, DETMTC,COMPTC,MODUTC,REM1TC,REM2TC)
                                                                   VALUES(?, ?, ?, ?,?, ?, ?, ?, ?, ?,?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?,?,?,?)";

                    cmd.Connection = conn;
                    cmd.CommandText = inquery1;
                    cmd.Parameters.AddWithValue("TRNNTC", OdbcType.Decimal).Value = "20";
                    cmd.Parameters.AddWithValue("TRNSTC", OdbcType.VarChar).Value = "E";
                    cmd.Parameters.AddWithValue("USRDTC", OdbcType.VarChar).Value = "IMASGRNF";
                    cmd.Parameters.AddWithValue("FRCFTC", OdbcType.VarChar).Value = "N";
                    cmd.Parameters.AddWithValue("ORXSTC", OdbcType.VarChar).Value = "I";
                    cmd.Parameters.AddWithValue("WHSNTC", OdbcType.VarChar).Value = "R01";
                    cmd.Parameters.AddWithValue("CUSNTC", OdbcType.VarChar).Value = "MRS001";
                    cmd.Parameters.AddWithValue("CURCTC", OdbcType.VarChar).Value = "BDT";
                    cmd.Parameters.AddWithValue("OIDTTC", OdbcType.DateTime).Value = DateTime.Now.Date;
                    cmd.Parameters.AddWithValue("INSDTC", OdbcType.VarChar).Value = "Greenforce001";
                    cmd.Parameters.AddWithValue("CORNTC", OdbcType.VarChar).Value = "100007";
                    cmd.Parameters.AddWithValue("OCDTTC", OdbcType.DateTime).Value = DateTime.Now.Date;
                    cmd.Parameters.AddWithValue("ORDTTC", OdbcType.DateTime).Value = DateTime.Now.Date;
                    cmd.Parameters.AddWithValue("XRDTTC", OdbcType.DateTime).Value = DateTime.Now.Date;
                    cmd.Parameters.AddWithValue("CASFTC", OdbcType.VarChar).Value = "N";
                    cmd.Parameters.AddWithValue("TRDTTC", OdbcType.DateTime).Value = DateTime.Now.Date;
                    cmd.Parameters.AddWithValue("EICNTC", OdbcType.VarChar).Value = "002";
                    cmd.Parameters.AddWithValue("USRTTC", OdbcType.VarChar).Value = "IMASGRNF";
                    cmd.Parameters.AddWithValue("DEDTTC", OdbcType.DateTime).Value = DateTime.Now.Date;
                    cmd.Parameters.AddWithValue("DETMTC", OdbcType.Time).Value = "152357";
                    cmd.Parameters.AddWithValue("COMPTC", OdbcType.VarChar).Value = "RRE";
                    cmd.Parameters.AddWithValue("MODUTC", OdbcType.VarChar).Value = "OEI";
                    cmd.Parameters.AddWithValue("REM1TC", OdbcType.VarChar).Value = "ABC";
                    cmd.Parameters.AddWithValue("REM2TC", OdbcType.VarChar).Value = "Please Deliver ASAP";
                    cmd.ExecuteNonQuery();


                }



            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

        }

        public DataTable GetData()
        {
            OdbcConnection conn = new OdbcConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ImasConnection"].ConnectionString;//"Dsn=QTEST;uid=IMASGRNF;pwd=IMAS321";
            try
            {
                //conn.Open();
                using (OdbcCommand cmd = new OdbcCommand())
                {
                    OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT TRNNTC,TRNSTC,USRDTC,FRCFTC,ORXSTC,WHSNTC,CUSNTC,CURCTC,OIDTTC,INSDTC,CORNTC,OCDTTC,
                                                                                ORDTTC,XRDTTC,CASFTC, TRDTTC,EICNTC,USRTTC,DEDTTC,DETMTC,COMPTC,MODUTC,REM1TC,REM2TC FROM QTESTRRE.XOITC", conn);

                    conn.Open();
                    //OdbcDataReader reader = cmd.ExecuteReader();
                    //string getValue = cmd.ExecuteScalar().ToString();

                    //int fCount = reader.FieldCount;
                    //Console.Write(":");
                    //for (int i = 0; i < fCount; i++)
                    //{
                    //    String fName = reader.GetName(i);
                    //    //Console.Write(fName + ":");
                    //}

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //dataGridView1.DataSource = dt;
                    return dt;
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.InnerException.ToString());
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public void DeliveryAgainstIndentEntry()
        {
            OdbcConnection conn = new OdbcConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ImasConnection"].ConnectionString;//"Dsn=QTEST;uid=IMASGRNF;pwd=IMAS321";

            try
            {

                conn.Open();
                using (OdbcCommand cmd = new OdbcCommand())
                {

                    string insertQuery = @"INSERT INTO QTESTRRE.ICJCMTRTST(COMNCM,PORNCM,TRDTTR,FWHSCM,TWHSCM,ITMNTR,TRNQTR) VALUES(?, ?, ?, ?, ?, ?, ?)";
                    cmd.Connection = conn;
                    cmd.CommandText = insertQuery;
                    cmd.Parameters.AddWithValue("", OdbcType.VarChar).Value = "2017121200001";
                    cmd.Parameters.AddWithValue("", OdbcType.VarChar).Value = "2017120001";
                    cmd.Parameters.AddWithValue("", OdbcType.VarChar).Value = (DateTime.Now.Date.Year).ToString("dd") + "/" + (DateTime.Now.Date.Month).ToString("MM") + "/" + (DateTime.Now.Date.Year).ToString("YY");
                    cmd.Parameters.AddWithValue("", OdbcType.VarChar).Value = "R01";
                    cmd.Parameters.AddWithValue("", OdbcType.VarChar).Value = "S01";
                    cmd.Parameters.AddWithValue("", OdbcType.VarChar).Value = "201712120000001";
                    cmd.Parameters.AddWithValue("", OdbcType.Int).Value = 20;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        public DataTable DeliveryAgainstIndentView()
        {
            //OdbcConnection conn = new OdbcConnection();
            //conn.ConnectionString = ConfigurationManager.ConnectionStrings["ImasConnection"].ConnectionString;//"Dsn=QTEST;uid=IMASGRNF;pwd=IMAS321";
            OdbcConnection odbcCon = new OdbcConnection("Driver={iSeries Access ODBC Driver};System=10.32.1.10; uid=IMASGRNF; pwd=IMAS321;DBQ=QTEST;");

            try
            {
                odbcCon.Open();

                //conn.Open();
                using (OdbcCommand cmd = new OdbcCommand())
                {
                    OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT DISTINCT COMNCM, ITMNCM, FWHSCM, TWHSCM, TRNQCM FROM QTESTRRE.ICJCMTRTST", odbcCon);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                odbcCon.Close();
                throw ex;
            }
            finally
            {
                odbcCon.Close();
            }
        }

        public XmlDocument CallWebService(string method, string operation, string xmlPayload)
        {
            xmlPayload = @"auth=RSFRRE&CustomerCode=100022542&CustomerName=Test111&PhoneNo=01755555555&CustomerType=New-Household&VillageName=Ghorokhati&UnionName=Amadi Union Parishad&UpazillaName=Koyra&DistrictName=Khulna&FathersOrHusbandName=’’&Gender=’’&UnitCode=9000&UnitName=Head Office&Occupation=’ ’";
            string result = "";
           
            string URL_ADDRESS = "http://10.32.132.5/icareAPI/iCareCustomer.asmx/AddCustomerInfo?";  //TODO: customize to your needs

            // ===== You shoudn't need to edit the lines below =====

            // Create the web request
            HttpWebRequest request = WebRequest.Create(new Uri(URL_ADDRESS)) as HttpWebRequest;

            // Set type to POST
            request.Method = "GET";
            request.ContentType = "text/xml; charset=utf-8";
            request.Host = "10.32.132.5";

            // Create the data we want to send
            StringBuilder data = new StringBuilder();
            data.Append(xmlPayload);
            byte[] byteData = Encoding.UTF8.GetBytes(data.ToString());      // Create a byte array of the data we want to send
            request.ContentLength = byteData.Length;                        // Set the content length in the request headers

            // Write data to request
            using (Stream postStream = request.GetRequestStream())
            {
                postStream.Write(byteData, 0, byteData.Length);
            }

            // Get response and return it
            XmlDocument xmlResult = new XmlDocument();
            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    result = reader.ReadToEnd();
                    reader.Close();
                }
                xmlResult.LoadXml(result);
            }
            catch (Exception e)
            {
                //xmlResult = CreateErrorXML(e.Message, "");  //TODO: returns an XML with the error message
            }
            return xmlResult;
        }

        public string postXMLData(string destinationUrl, string requestXml)
        {
            destinationUrl = "http://10.32.132.5/icareAPI/iCareCustomer.asmx/AddCustomerInfo?auth=RSFRRE&CustomerCode=118600590&CustomerName=Md: Fozlul Haque&PhoneNo=01738778381 &CustomerType=House Hold &VillageName=Bihigram&UnionName=Adamdighi Union Parishad&UpazillaName=’’&DistrictName=Bogra&FathersOrHusbandName=Late.Afsar Ali&Gender=M&UnitCode=ABA001&UnitName=Abadpukur Raninagar&Occupation=Farmer";
                        
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(destinationUrl);            

            request.ContentType = "text/xml; charset=utf-8";
            request.Method = "GET";
            request.Host = "10.32.132.5";

            HttpWebResponse response;
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                string responseStr = new StreamReader(responseStream).ReadToEnd();
                return responseStr;
            }
            return null;
        }

        public string XmlCalling()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender1, certificate, chain, sslPolicyErrors) => true);
            WebClient webClient = new WebClient();
            string striCareWebAPIURL;
            Byte[] requestedHTML;
            UTF8Encoding objUTF8;

            striCareWebAPIURL = "http://10.32.132.5/icareAPI/iCareCustomer.asmx/AddCustomerInfo?auth=RSFRRE&CustomerCode=118600590&CustomerName=Md: Fozlul Haque&PhoneNo=01738778381 &CustomerType=House Hold &VillageName=Bihigram&UnionName=Adamdighi Union Parishad&UpazillaName=’’&DistrictName=Bogra&FathersOrHusbandName=Late.Afsar Ali&Gender=M&UnitCode=ABA001&UnitName=Abadpukur Raninagar&Occupation=Farmer";
            requestedHTML = webClient.DownloadData(striCareWebAPIURL);

            objUTF8 = new UTF8Encoding();
            string strAPIReturnedResult = objUTF8.GetString(requestedHTML);
            XmlDocument xmlResult = new XmlDocument();
            xmlResult.LoadXml(strAPIReturnedResult);
            return xmlResult.DocumentElement.InnerText; 
        }

//        using (OdbcConnection connection = new OdbcConnection(ConfigurationManager.ConnectionStrings["ImasConnection"].ConnectionString))
//            {
//                OdbcCommand command = new OdbcCommand();
//                OdbcTransaction transaction = null;

//                // Set the Connection to the new OdbcConnection.
//                command.Connection = connection;

//                // Open the connection and execute the transaction.
//                try
//                {
//                    connection.Open();
//                    // Start a local transaction
//                    transaction = connection.BeginTransaction();

//                    // Assign transaction object for a pending local transaction.
//                    command.Connection = connection;
//                    command.Transaction = transaction;

//                    foreach (var item in aList)
//                    {
//                        string inquery = @"INSERT INTO QTESTRRE.XOITC(TRNNTC,TRNSTC,USRDTC,FRCFTC,ORXSTC,WHSNTC,CUSNTC,CURCTC,OIDTTC,INSDTC,CORNTC,OCDTTC,
//                                                                   ORDTTC,XRDTTC,CASFTC, TRDTTC,EICNTC, USRTTC, DEDTTC, DETMTC,COMPTC,MODUTC,REM1TC,REM2TC)
//                                                                   VALUES(?, ?, ?, ?,?, ?, ?, ?, ?, ?,?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?,?,?,?)";
//                        command.CommandText = inquery;
//                        command.Parameters.AddWithValue("TRNNTC", OdbcType.Decimal).Value = item.IMAS_TRNNTC;
//                        command.Parameters.AddWithValue("TRNSTC", OdbcType.VarChar).Value = item.IMAS_TRNSTC;
//                        command.Parameters.AddWithValue("USRDTC", OdbcType.VarChar).Value = item.IMAS_USRDTC;
//                        command.Parameters.AddWithValue("FRCFTC", OdbcType.VarChar).Value = item.IMAS_FRCFTC;
//                        command.Parameters.AddWithValue("ORXSTC", OdbcType.VarChar).Value = item.IMAS_ORXSTC;
//                        command.Parameters.AddWithValue("WHSNTC", OdbcType.VarChar).Value = item.IMAS_WHSNTC;
//                        command.Parameters.AddWithValue("CUSNTC", OdbcType.VarChar).Value = item.IMAS_CUSNTC;
//                        command.Parameters.AddWithValue("CURCTC", OdbcType.VarChar).Value = item.IMAS_CURCTC;
//                        command.Parameters.AddWithValue("OIDTTC", OdbcType.DateTime).Value = item.IMAS_OIDTTC;
//                        command.Parameters.AddWithValue("INSDTC", OdbcType.VarChar).Value = item.IMAS_INSDTC;
//                        command.Parameters.AddWithValue("CORNTC", OdbcType.VarChar).Value = item.IMAS_CORNTC;
//                        command.Parameters.AddWithValue("OCDTTC", OdbcType.DateTime).Value = item.IMAS_OCDTTC;
//                        command.Parameters.AddWithValue("ORDTTC", OdbcType.DateTime).Value = item.IMAS_ORDTTC;
//                        command.Parameters.AddWithValue("XRDTTC", OdbcType.DateTime).Value = item.IMAS_XRDTTC;
//                        command.Parameters.AddWithValue("CASFTC", OdbcType.VarChar).Value = item.IMAS_CASFTC;
//                        command.Parameters.AddWithValue("TRDTTC", OdbcType.DateTime).Value = item.IMAS_TRDTTC;
//                        command.Parameters.AddWithValue("EICNTC", OdbcType.VarChar).Value = item.IMAS_EICNTC;
//                        command.Parameters.AddWithValue("USRTTC", OdbcType.VarChar).Value = item.IMAS_USRTTC;
//                        command.Parameters.AddWithValue("DEDTTC", OdbcType.DateTime).Value = item.IMAS_DEDTTC;
//                        command.Parameters.AddWithValue("DETMTC", OdbcType.Time).Value = "151257";
//                        command.Parameters.AddWithValue("COMPTC", OdbcType.VarChar).Value = item.IMAS_COMPTC;
//                        command.Parameters.AddWithValue("MODUTC", OdbcType.VarChar).Value = item.IMAS_MODUTC;
//                        command.Parameters.AddWithValue("REM1TC", OdbcType.VarChar).Value = item.IMAS_REM1TC;
//                        command.Parameters.AddWithValue("REM2TC", OdbcType.VarChar).Value = item.IMAS_REM2TC;
//                        command.ExecuteNonQuery();
//                    }
//                    // Commit the transaction.
//                    transaction.Commit();
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine(ex.Message);
//                    try
//                    {
//                        // Attempt to roll back the transaction.
//                        transaction.Rollback();
//                    }
//                    catch
//                    {
//                        // Do nothing here; transaction is not active.
//                    }
//                }
//            }
    }
}