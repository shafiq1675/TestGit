using ImasTestFromWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ImasTestFromWeb.DAL
{
    public class BridgeBetweenSQLNDB2
    {
        public bool DeleteDataFromImas()
        {
            try
            {
                OdbcConnection conn = new OdbcConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ImasConnection"].ConnectionString;//"Dsn=QTEST;uid=IMASGRNF;pwd=IMAS321";

                conn.Open();

                using (OdbcCommand cmd = new OdbcCommand())
                {
                    string inquery = @"DELETE FROM QTESTRRE.XOITL WHERE USRTTL IN ('DSP004','DSP008')";

                    cmd.Connection = conn;
                    cmd.CommandText = inquery;
                    cmd.ExecuteNonQuery();
                }


                using (OdbcCommand cmd = new OdbcCommand())
                {
                    string inquery = @"DELETE FROM QTESTRRE.XOITC WHERE INSDTC IN ('DSP004','DSP008')";

                    cmd.Connection = conn;
                    cmd.CommandText = inquery;                   
                    cmd.ExecuteNonQuery();
                }


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public string ReadDataFromSql()
        {
            string st = ConfigurationManager.ConnectionStrings["rasolarmisentities"].ConnectionString;
            SqlConnection con = new SqlConnection(st);
            try
            {
                List<ImasDataViewModel> aList = new List<ImasDataViewModel>();
                List<ImasDataDetailsViewModel> detailsList = new List<ImasDataDetailsViewModel>();

                DataTable dt;
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Integration_IMAS_Sal_SalesOrderMaster WHERE LocationCode IN ('DSP004','DSP008'); SELECT * FROM Integration_IMAS_Sal_SalesOrderItems WHERE LocationCode IN ('DSP004','DSP008')", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ImasDataViewModel item = new ImasDataViewModel();
                    item.IMAS_TRNNTC = Convert.ToDecimal(dt.Rows[i]["IMAS_TRNNTC"]);
                    item.IMAS_TRNSTC = dt.Rows[i]["IMAS_TRNSTC"].ToString();
                    item.IMAS_USRDTC = dt.Rows[i]["IMAS_USRDTC"].ToString();
                    item.IMAS_FRCFTC = dt.Rows[i]["IMAS_FRCFTC"].ToString();
                    item.IMAS_ORXSTC = dt.Rows[i]["IMAS_ORXSTC"].ToString();
                    item.IMAS_WHSNTC = dt.Rows[i]["IMAS_WHSNTC"].ToString();
                    item.IMAS_CUSNTC = dt.Rows[i]["IMAS_CUSNTC"].ToString();
                    item.IMAS_CURCTC = dt.Rows[i]["IMAS_CURCTC"].ToString();
                    item.IMAS_OIDTTC = Convert.ToDateTime(dt.Rows[i]["IMAS_OIDTTC"]);
                    item.IMAS_INSDTC = dt.Rows[i]["IMAS_INSDTC"].ToString();
                    item.IMAS_CORNTC = dt.Rows[i]["IMAS_CORNTC"].ToString();
                    item.IMAS_OCDTTC = Convert.ToDateTime(dt.Rows[i]["IMAS_OCDTTC"]);
                    item.IMAS_ORDTTC = Convert.ToDateTime(dt.Rows[i]["IMAS_ORDTTC"]);
                    item.IMAS_XRDTTC = Convert.ToDateTime(dt.Rows[i]["IMAS_XRDTTC"]);
                    item.IMAS_CASFTC = dt.Rows[i]["IMAS_CASFTC"].ToString();
                    item.IMAS_TRDTTC = Convert.ToDateTime(dt.Rows[i]["IMAS_TRDTTC"]);
                    item.IMAS_EICNTC = Convert.ToDecimal(dt.Rows[i]["IMAS_EICNTC"]);
                    item.IMAS_USRTTC = dt.Rows[i]["IMAS_USRTTC"].ToString();
                    item.IMAS_DEDTTC = Convert.ToDateTime(dt.Rows[i]["IMAS_DEDTTC"]);
                    item.IMAS_DETMTC = dt.Rows[i]["IMAS_DETMTC"].ToString();
                    item.IMAS_COMPTC = dt.Rows[i]["IMAS_COMPTC"].ToString();
                    item.IMAS_MODUTC = dt.Rows[i]["IMAS_MODUTC"].ToString();
                    item.IMAS_REM1TC = dt.Rows[i]["IMAS_REM1TC"].ToString();
                    item.IMAS_REM2TC = dt.Rows[i]["IMAS_REM2TC"].ToString();

                    aList.Add(item);

                }

                dt = ds.Tables[1];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ImasDataDetailsViewModel item = new ImasDataDetailsViewModel();

                    item.IMAS_TRNNTL = Convert.ToDecimal(dt.Rows[i]["IMAS_TRNNTL"]);
                    item.IMAS_OLINTL = Convert.ToDecimal(dt.Rows[i]["IMAS_OLINTL"]);
                    item.IMAS_TRNSTL = dt.Rows[i]["IMAS_TRNSTL"].ToString();
                    item.IMAS_ITMNTL = dt.Rows[i]["IMAS_ITMNTL"].ToString();
                    item.IMAS_ORSQTL = Convert.ToDecimal(dt.Rows[i]["IMAS_ORSQTL"]);
                    item.IMAS_ITMDTL = dt.Rows[i]["IMAS_ITMDTL"].ToString();
                    item.IMAS_SHSQTL = Convert.ToDecimal(dt.Rows[i]["IMAS_SHSQTL"]);
                    item.IMAS_USRTTL = dt.Rows[i]["IMAS_USRTTL"].ToString();
                    item.IMAS_DEDTTL = Convert.ToDateTime(dt.Rows[i]["IMAS_DEDTTL"]);
                    item.IMAS_DETMTL = dt.Rows[i]["IMAS_DETMTL"].ToString();
                    item.IMAS_COMPTL = dt.Rows[i]["IMAS_COMPTL"].ToString();
                    item.IMAS_MODUTL = dt.Rows[i]["IMAS_MODUTL"].ToString();
                    item.IMAS_REM1TL = dt.Rows[i]["IMAS_REM1TL"].ToString();
                    item.IMAS_REM2TL = dt.Rows[i]["IMAS_REM2TL"].ToString();
                    detailsList.Add(item);

                }

                con.Close();
                this.SaveDataIntoDB2(aList, detailsList);
                return "Success";
            }
            catch (Exception ex)
            {
                con.Close();
                throw ex;
            }
        }

        public string SaveDataIntoDB2(List<ImasDataViewModel> aList, List<ImasDataDetailsViewModel> detailsList)
        {
            OdbcConnection conn = new OdbcConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ImasConnection"].ConnectionString;//"Dsn=QTEST;uid=IMASGRNF;pwd=IMAS321";

            try
            {
                conn.Open();

                foreach (var item in aList)
                {
                    using (OdbcCommand cmd = new OdbcCommand())
                    {
                        string inquery = @"INSERT INTO QTESTRRE.XOITC(TRNNTC,TRNSTC,USRDTC,FRCFTC,ORXSTC,WHSNTC,CUSNTC,CURCTC,OIDTTC,INSDTC,CORNTC,OCDTTC,
                                                                   ORDTTC,XRDTTC,CASFTC, TRDTTC,EICNTC, USRTTC, DEDTTC, DETMTC,COMPTC,MODUTC,REM1TC,REM2TC)
                                                                   VALUES(?, ?, ?, ?,?, ?, ?, ?, ?, ?,?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?,?,?,?)";

                        cmd.Connection = conn;
                        cmd.CommandText = inquery;
                        cmd.Parameters.AddWithValue("TRNNTC", OdbcType.Decimal).Value = item.IMAS_TRNNTC;
                        cmd.Parameters.AddWithValue("TRNSTC", OdbcType.VarChar).Value = item.IMAS_TRNSTC;
                        cmd.Parameters.AddWithValue("USRDTC", OdbcType.VarChar).Value = item.IMAS_USRDTC;
                        cmd.Parameters.AddWithValue("FRCFTC", OdbcType.VarChar).Value = item.IMAS_FRCFTC;
                        cmd.Parameters.AddWithValue("ORXSTC", OdbcType.VarChar).Value = item.IMAS_ORXSTC;
                        cmd.Parameters.AddWithValue("WHSNTC", OdbcType.VarChar).Value = item.IMAS_WHSNTC;
                        cmd.Parameters.AddWithValue("CUSNTC", OdbcType.VarChar).Value = item.IMAS_CUSNTC;
                        cmd.Parameters.AddWithValue("CURCTC", OdbcType.VarChar).Value = item.IMAS_CURCTC;
                        cmd.Parameters.AddWithValue("OIDTTC", OdbcType.DateTime).Value = item.IMAS_OIDTTC;
                        cmd.Parameters.AddWithValue("INSDTC", OdbcType.VarChar).Value = item.IMAS_INSDTC;
                        cmd.Parameters.AddWithValue("CORNTC", OdbcType.VarChar).Value = item.IMAS_CORNTC;
                        cmd.Parameters.AddWithValue("OCDTTC", OdbcType.DateTime).Value = item.IMAS_OCDTTC;
                        cmd.Parameters.AddWithValue("ORDTTC", OdbcType.DateTime).Value = item.IMAS_ORDTTC;
                        cmd.Parameters.AddWithValue("XRDTTC", OdbcType.DateTime).Value = item.IMAS_XRDTTC;
                        cmd.Parameters.AddWithValue("CASFTC", OdbcType.VarChar).Value = item.IMAS_CASFTC;
                        cmd.Parameters.AddWithValue("TRDTTC", OdbcType.DateTime).Value = item.IMAS_TRDTTC;
                        cmd.Parameters.AddWithValue("EICNTC", OdbcType.VarChar).Value = item.IMAS_EICNTC;
                        cmd.Parameters.AddWithValue("USRTTC", OdbcType.VarChar).Value = item.IMAS_USRTTC;
                        cmd.Parameters.AddWithValue("DEDTTC", OdbcType.DateTime).Value = item.IMAS_DEDTTC;
                        cmd.Parameters.AddWithValue("DETMTC", OdbcType.Time).Value = "151257";
                        cmd.Parameters.AddWithValue("COMPTC", OdbcType.VarChar).Value = item.IMAS_COMPTC;
                        cmd.Parameters.AddWithValue("MODUTC", OdbcType.VarChar).Value = item.IMAS_MODUTC;
                        cmd.Parameters.AddWithValue("REM1TC", OdbcType.VarChar).Value = item.IMAS_REM1TC;
                        cmd.Parameters.AddWithValue("REM2TC", OdbcType.VarChar).Value = item.IMAS_REM2TC;
                        cmd.ExecuteNonQuery();
                    }
                }

                foreach (var item1 in detailsList)
                {
                    using (OdbcCommand cmd = new OdbcCommand())
                    {
                        string inquery1 = @"INSERT INTO QTESTRRE.XOITL(TRNNTL,OLINTL,TRNSTL,ITMNTL,ORSQTL,ITMDTL,SHSQTL,USRTTL,DEDTTL,DETMTL,COMPTL,MODUTL,REM1TL,REM2TL) 
                                                                   VALUES(?,?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                        cmd.Connection = conn;
                        cmd.CommandText = inquery1;
                        cmd.Parameters.AddWithValue("TRNNTL", OdbcType.Decimal).Value = item1.IMAS_TRNNTL;
                        cmd.Parameters.AddWithValue("OLINTL", OdbcType.Int).Value = item1.IMAS_OLINTL;
                        cmd.Parameters.AddWithValue("TRNSTL", OdbcType.VarChar).Value = item1.IMAS_TRNSTL;
                        cmd.Parameters.AddWithValue("ITMNTL", OdbcType.VarChar).Value = item1.IMAS_ITMNTL;
                        cmd.Parameters.AddWithValue("ORSQTL", OdbcType.Int).Value = item1.IMAS_ORSQTL;
                        cmd.Parameters.AddWithValue("ITMDTL", OdbcType.VarChar).Value = item1.IMAS_ITMDTL;
                        cmd.Parameters.AddWithValue("SHSQTL", OdbcType.Int).Value = item1.IMAS_SHSQTL;
                        cmd.Parameters.AddWithValue("USRTTL", OdbcType.VarChar).Value = item1.IMAS_USRTTL;
                        cmd.Parameters.AddWithValue("DEDTTL", OdbcType.DateTime).Value = item1.IMAS_DEDTTL;
                        cmd.Parameters.AddWithValue("DETMTL", OdbcType.VarChar).Value = "121212";
                        cmd.Parameters.AddWithValue("COMPTL", OdbcType.VarChar).Value = item1.IMAS_COMPTL;
                        cmd.Parameters.AddWithValue("MODUTL", OdbcType.VarChar).Value = item1.IMAS_MODUTL;
                        cmd.Parameters.AddWithValue("REM1TL", OdbcType.VarChar).Value = item1.IMAS_REM1TL;
                        cmd.Parameters.AddWithValue("REM2TL", OdbcType.VarChar).Value = item1.IMAS_REM2TL;
                        cmd.ExecuteNonQuery();
                    }

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
            return null;
        }
    }
}