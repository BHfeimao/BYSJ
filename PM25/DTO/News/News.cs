using PM25.InterfaceFile.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PM25.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace PM25.DTO.News
{
    public class News : INews
    {
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool DeleteNew(int ID)
        {
            string connSQL = ConfigurationManager.ConnectionStrings["LocationConnection"].ToString();
            SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder(connSQL);
            using (SqlConnection conn = new SqlConnection(connStr.ConnectionString))
            {
                string strSQL = "delete from News where ID = " + ID;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strSQL;
                cmd.Connection = conn;
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        /// <summary>
        /// 获取ALL
        /// </summary>
        /// <returns></returns>
        public List<New> GetAllNew()
        {
            var resultList = new List<New>();
            string connSQL = ConfigurationManager.ConnectionStrings["LocationConnection"].ToString();
            SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder(connSQL);
            using (SqlConnection conn = new SqlConnection(connStr.ConnectionString))
            {
                string strSQL = "select * from News";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strSQL;
                cmd.Connection = conn;
                conn.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();//执行ExecuteReader
                    while (dr.Read())
                    {
                        var result = new New();
                        result.ID = !Convert.IsDBNull(dr["ID"]) ? Convert.ToInt32(dr["ID"]) : 0;
                        var uniimg = !Convert.IsDBNull(dr["img"]) ? dr["img"].ToString() : string.Empty;
                        var unisummary = !Convert.IsDBNull(dr["summary"]) ? dr["summary"].ToString() : string.Empty;
                        var unidetail = !Convert.IsDBNull(dr["detail"]) ? dr["detail"].ToString() : string.Empty;
                        result.createTime = !Convert.IsDBNull(dr["createTime"]) ? dr["createTime"].ToString() : string.Empty;
                        result.img = uniimg.FromUnicodeString();
                        result.summary = unisummary.FromUnicodeString();
                        result.detail = "";
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
        /// ID获取
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public New GetNewById(int ID)
        {
            var result = new New();
            string connSQL = ConfigurationManager.ConnectionStrings["LocationConnection"].ToString();
            SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder(connSQL);
            using (SqlConnection conn = new SqlConnection(connStr.ConnectionString))
            {
                string strSQL = "select * from News where id = " + ID;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strSQL;
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();//执行ExecuteReader
                while (dr.Read())
                {
                    result.ID = !Convert.IsDBNull(dr["ID"]) ? Convert.ToInt32(dr["ID"]) : 0;
                    var uniimg = !Convert.IsDBNull(dr["img"]) ? dr["img"].ToString() : string.Empty;
                    var unisummary = !Convert.IsDBNull(dr["summary"]) ? dr["summary"].ToString() : string.Empty;
                    var unidetail = !Convert.IsDBNull(dr["detail"]) ? dr["detail"].ToString() : string.Empty;
                    result.createTime = !Convert.IsDBNull(dr["createTime"]) ? dr["createTime"].ToString() : string.Empty;
                    result.img = uniimg.FromUnicodeString();
                    result.summary = unisummary.FromUnicodeString();
                    result.detail = unidetail.FromUnicodeString();
                }
            }
            return result;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="img"></param>
        /// <param name="summary"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        public bool InsertNew(string img, string summary, string detail)
        {
            var uniimg = img.ToUnicodeString();
            var unisummary = summary.ToUnicodeString();
            var unidetail = detail.ToUnicodeString();
            string connSQL = ConfigurationManager.ConnectionStrings["LocationConnection"].ToString();
            SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder(connSQL);
            using (SqlConnection conn = new SqlConnection(connStr.ConnectionString))
            {
                string strSQL = "Insert into News(img,summary,detail,createTime)" +
                    "values(" +
                    "'" + uniimg + "'" + "," +
                    "'" + unisummary + "'" + "," +
                    "'" + unidetail + "'" + "," +
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
        /// <param name="img"></param>
        /// <param name="summary"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        public bool UpdataNew(int ID, string img, string summary, string detail)
        {
            var uniimg = img.ToUnicodeString();
            var unisummary = summary.ToUnicodeString();
            var unidetail = detail.ToUnicodeString();
            string connSQL = ConfigurationManager.ConnectionStrings["LocationConnection"].ToString();
            SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder(connSQL);
            using (SqlConnection conn = new SqlConnection(connStr.ConnectionString))
            {
                string strSQL = "update News set img = " +
                    "'" + uniimg + "'" + ",summary = " +
                    "'" + unisummary + "'" + ",detail = " +
                    "'" + unidetail + "'" +
                    " where ID = " + ID;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strSQL;
                cmd.Connection = conn;
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}