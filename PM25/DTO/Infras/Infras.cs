using PM25.InterfaceFile.Infras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PM25.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace PM25.DTO.Infras
{
    public class Infras : IInfras
    {
        /// <summary>
        /// 删除红外医学应用条目
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool DeleteInfra(int ID)
        {
            string connSQL = ConfigurationManager.ConnectionStrings["LocationConnection"].ToString();
            SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder(connSQL);
            using (SqlConnection conn = new SqlConnection(connStr.ConnectionString))
            {
                string strSQL = "delete from Infras where ID = " + ID;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strSQL;
                cmd.Connection = conn;
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        /// <summary>
        /// 获取全部红外医学应用条目
        /// </summary>
        /// <returns></returns>
        public List<Infra> GetAllInfra()
        {
            var resultList = new List<Infra>();
            string connSQL = ConfigurationManager.ConnectionStrings["LocationConnection"].ToString();
            SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder(connSQL);
            using (SqlConnection conn = new SqlConnection(connStr.ConnectionString))
            {
                string strSQL = "select * from Infras";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strSQL;
                cmd.Connection = conn;
                conn.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();//执行ExecuteReader
                    while (dr.Read())
                    {
                        var result = new Infra();
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
        /// 添加红外医学应用条目
        /// </summary>
        /// <param name="img"></param>
        /// <param name="summary"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        public bool InsertInfra(string img, string summary, string detail)
        {
            var uniimg = img.ToUnicodeString();
            var unisummary = summary.ToUnicodeString();
            var unidetail = detail.ToUnicodeString();
            string connSQL = ConfigurationManager.ConnectionStrings["LocationConnection"].ToString();
            SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder(connSQL);
            using (SqlConnection conn = new SqlConnection(connStr.ConnectionString))
            {
                string strSQL = "Insert into Infras(img,summary,detail,createTime)" +
                    "values(" +
                    "'" + uniimg + "'" + "," +
                    "'" + unisummary + "'" + "," +
                    "'" + unidetail + "'" + "," +
                    "'" + DateTime.Now.ToString("MM月dd日") + "'"+
                    ")";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strSQL;
                cmd.Connection = conn;
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
            throw new NotImplementedException();
        }
        /// <summary>
        /// 编辑修改红外医学应用条目
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="img"></param>
        /// <param name="summary"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        public bool UpdataInfra(int ID, string img, string summary, string detail)
        {
            var uniimg = img.ToUnicodeString();
            var unisummary = summary.ToUnicodeString();
            var unidetail = detail.ToUnicodeString();
            string connSQL = ConfigurationManager.ConnectionStrings["LocationConnection"].ToString();
            SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder(connSQL);
            using (SqlConnection conn = new SqlConnection(connStr.ConnectionString))
            {
                string strSQL = "update Infras set img = " +
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
        /// <summary>
        /// ID获取
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Infra GetInfraById(int ID)
        {
            var result = new Infra();
            string connSQL = ConfigurationManager.ConnectionStrings["LocationConnection"].ToString();
            SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder(connSQL);
            using (SqlConnection conn = new SqlConnection(connStr.ConnectionString))
            {
                string strSQL = "select * from Infras where id = " + ID;
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
    }
}