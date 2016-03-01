using PM25.InterfaceFile.Nows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PM25.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace PM25.DTO.Nows
{
    public class Nows : INows
    {
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool DeleteNow(int ID)
        {
            string connSQL = ConfigurationManager.ConnectionStrings["LocationConnection"].ToString();
            SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder(connSQL);
            using (SqlConnection conn = new SqlConnection(connStr.ConnectionString))
            {
                string strSQL = "delete from Nows where ID = " + ID;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strSQL;
                cmd.Connection = conn;
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        /// <summary>
        /// 获取All
        /// </summary>
        /// <returns></returns>
        public List<Now> GetAllNow()
        {
            var resultList = new List<Now>();
            string connSQL = ConfigurationManager.ConnectionStrings["LocationConnection"].ToString();
            SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder(connSQL);
            using (SqlConnection conn = new SqlConnection(connStr.ConnectionString))
            {
                string strSQL = "select * from Nows";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strSQL;
                cmd.Connection = conn;
                conn.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();//执行ExecuteReader
                    while (dr.Read())
                    {
                        var result = new Now();
                        result.ID = !Convert.IsDBNull(dr["ID"]) ? Convert.ToInt32(dr["ID"]) : 0;
                        var unititle = !Convert.IsDBNull(dr["title"]) ? dr["title"].ToString() : string.Empty;
                        var unisummary = !Convert.IsDBNull(dr["summary"]) ? dr["summary"].ToString() : string.Empty;
                        var unidownloadURL = !Convert.IsDBNull(dr["downloadURL"]) ? dr["downloadURL"].ToString() : string.Empty;
                        result.createTime = !Convert.IsDBNull(dr["createTime"]) ? dr["createTime"].ToString() : string.Empty;
                        result.title = unititle.FromUnicodeString();
                        result.summary = "";
                        result.downloadURL = "";
                        if (result.ID > 0)
                        {
                            resultList.Add(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resultList;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="title"></param>
        /// <param name="summary"></param>
        /// <param name="downloadURL"></param>
        /// <returns></returns>
        public bool InsertNow(string title, string summary, string downloadURL)
        {
            var unititle = title.ToUnicodeString();
            var unisummary = summary.ToUnicodeString();
            var unidownloadURL = downloadURL.ToUnicodeString();
            string connSQL = ConfigurationManager.ConnectionStrings["LocationConnection"].ToString();
            SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder(connSQL);
            using (SqlConnection conn = new SqlConnection(connStr.ConnectionString))
            {
                string strSQL = "Insert into Nows(title,summary,downloadURL,createTime)" +
                    "values(" +
                    "'" + unititle + "'" + "," +
                    "'" + unisummary + "'" + "," +
                    "'" + unidownloadURL + "'" + "," +
                    "'" + DateTime.Now.ToString("MM月dd日") + "'" + 
                    ")";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strSQL;
                cmd.Connection = conn;
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        /// <summary>
        /// 编辑修改
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="title"></param>
        /// <param name="summary"></param>
        /// <param name="downloadURL"></param>
        /// <returns></returns>
        public bool UpdataNow(int ID, string title, string summary, string downloadURL)
        {
            var unititle = title.ToUnicodeString();
            var unisummary = summary.ToUnicodeString();
            var unidownloadURL = downloadURL.ToUnicodeString();
            string connSQL = ConfigurationManager.ConnectionStrings["LocationConnection"].ToString();
            SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder(connSQL);
            using (SqlConnection conn = new SqlConnection(connStr.ConnectionString))
            {
                string strSQL = "update Nows set title = " +
                    "'" + unititle + "'" + ",summary = " +
                    "'" + unisummary + "'" + ",downloadURL = " +
                    "'" + unidownloadURL + "'" +
                    " where ID = " + ID;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strSQL;
                cmd.Connection = conn;
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public Now GetNowById(int ID)
        {
            var result = new Now();
            string connSQL = ConfigurationManager.ConnectionStrings["LocationConnection"].ToString();
            SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder(connSQL);
            using (SqlConnection conn = new SqlConnection(connStr.ConnectionString))
            {
                string strSQL = "select * from Nows where id = " + ID;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strSQL;
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();//执行ExecuteReader
                while (dr.Read())
                {
                    result.ID = !Convert.IsDBNull(dr["ID"]) ? Convert.ToInt32(dr["ID"]) : 0;
                    var unititle = !Convert.IsDBNull(dr["title"]) ? dr["title"].ToString() : string.Empty;
                    var unisummary = !Convert.IsDBNull(dr["summary"]) ? dr["summary"].ToString() : string.Empty;
                    var unidownloadURL = !Convert.IsDBNull(dr["downloadURL"]) ? dr["downloadURL"].ToString() : string.Empty;
                    result.createTime = !Convert.IsDBNull(dr["createTime"]) ? dr["createTime"].ToString() : string.Empty;
                    result.title = unititle.FromUnicodeString();
                    result.summary = unisummary.FromUnicodeString();
                    result.downloadURL = unidownloadURL.FromUnicodeString();
                }
            }
            return result;
        }
    }
}