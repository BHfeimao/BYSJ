using PM25.InterfaceFile.IllnessStus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PM25.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace PM25.DTO.IllnessStus
{
    public class IllnessStus : IIllnessStus
    {
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool DeleteIllnessStu(int ID)
        {
            string connSQL = ConfigurationManager.ConnectionStrings["LocationConnection"].ToString();
            SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder(connSQL);
            using (SqlConnection conn = new SqlConnection(connStr.ConnectionString))
            {
                string strSQL = "delete from IllnessStus where ID = " + ID;
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
        public List<IllnessStu> GetAllIllnessStu()
        {
            var resultList = new List<IllnessStu>();
            string connSQL = ConfigurationManager.ConnectionStrings["LocationConnection"].ToString();
            SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder(connSQL);
            using (SqlConnection conn = new SqlConnection(connStr.ConnectionString))
            {
                string strSQL = "select * from IllnessStus";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strSQL;
                cmd.Connection = conn;
                conn.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();//执行ExecuteReader
                    while (dr.Read())
                    {
                        var result = new IllnessStu();
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
        public IllnessStu GetIllnessStuById(int ID)
        {
            var result = new IllnessStu();
            string connSQL = ConfigurationManager.ConnectionStrings["LocationConnection"].ToString();
            SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder(connSQL);
            using (SqlConnection conn = new SqlConnection(connStr.ConnectionString))
            {
                string strSQL = "select * from IllnessStus where id = " + ID;
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
        public bool InsertIllnessStu(string img, string summary, string detail)
        {
            var uniimg = img.ToUnicodeString();
            var unisummary = summary.ToUnicodeString();
            var unidetail = detail.ToUnicodeString();
            string connSQL = ConfigurationManager.ConnectionStrings["LocationConnection"].ToString();
            SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder(connSQL);
            using (SqlConnection conn = new SqlConnection(connStr.ConnectionString))
            {
                string strSQL = "Insert into IllnessStus(img,summary,detail,createTime)" +
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
        public bool UpdataIllnessStu(int ID, string img, string summary, string detail)
        {
            var uniimg = img.ToUnicodeString();
            var unisummary = summary.ToUnicodeString();
            var unidetail = detail.ToUnicodeString();
            string connSQL = ConfigurationManager.ConnectionStrings["LocationConnection"].ToString();
            SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder(connSQL);
            using (SqlConnection conn = new SqlConnection(connStr.ConnectionString))
            {
                string strSQL = "update IllnessStus set img = " +
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