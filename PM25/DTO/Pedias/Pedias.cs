using PM25.InterfaceFile.Pedias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PM25.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace PM25.DTO.Pedias
{
    public class Pedias : IPedias
    {
        /// <summary>   
        /// 获取全部百科知识条目
        /// </summary>
        /// <returns></returns>
        public List<Pedia> GetAllPedia()
        {
            var pediaList = new List<Pedia>();
            string connSQL = ConfigurationManager.ConnectionStrings["LocationConnection"].ToString();
            SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder(connSQL);
            using (SqlConnection conn = new SqlConnection(connStr.ConnectionString))
            {
                string strSQL = "select * from Pedias";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strSQL;
                cmd.Connection = conn;
                conn.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();//执行ExecuteReader
                    while (dr.Read())
                    {
                        var pedia = new Pedia();
                        pedia.ID = !Convert.IsDBNull(dr["ID"]) ? Convert.ToInt32(dr["ID"]) : 0;
                        pedia.title = !Convert.IsDBNull(dr["title"]) ? dr["title"].ToString() : string.Empty;
                        var unitext = !Convert.IsDBNull(dr["text"]) ? dr["text"].ToString() : string.Empty;
                        pedia.text = "";
                        pedia.createTime= !Convert.IsDBNull(dr["createTime"]) ? dr["createTime"].ToString() : string.Empty;
                        if (pedia.ID > 0)
                        {
                            pediaList.Add(pedia);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return pediaList;
        }
        /// <summary>
        /// 删除百科知识条目
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool DeletePedia(int ID)
        {
            string connSQL = ConfigurationManager.ConnectionStrings["LocationConnection"].ToString();
            SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder(connSQL);
            using (SqlConnection conn = new SqlConnection(connStr.ConnectionString))
            {
                string strSQL = "delete from Pedias where ID = " + ID;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strSQL;
                cmd.Connection = conn;
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        /// <summary>
        /// 添加百科知识条目
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="title"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool InsertPedia(string title, string text)
        {
            var unitext = text.ToUnicodeString();
            string connSQL = ConfigurationManager.ConnectionStrings["LocationConnection"].ToString();
            SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder(connSQL);
            using (SqlConnection conn = new SqlConnection(connStr.ConnectionString))
            {
                string strSQL = "Insert into Pedias(title,text,createTime)" +
                    "values(" +
                    "'"+title+"'" + "," +
                    "'"+ unitext + "'"+ "," +
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
        /// 编辑修改百科知识条目
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="title"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool UpdataPedia(int ID, string title, string text)
        {
            var unitext = text.ToUnicodeString();
            string connSQL = ConfigurationManager.ConnectionStrings["LocationConnection"].ToString();
            SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder(connSQL);
            using (SqlConnection conn = new SqlConnection(connStr.ConnectionString))
            {
                string strSQL = "update Pedias set title = "+
                    "'"+title+"'"+ ",text = " +
                    "'"+ unitext + "'" +
                    " where ID = "+ID;
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
        public Pedia GetPediaById(int ID)
        {
            var result = new Pedia();
            string connSQL = ConfigurationManager.ConnectionStrings["LocationConnection"].ToString();
            SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder(connSQL);
            using (SqlConnection conn = new SqlConnection(connStr.ConnectionString))
            {
                string strSQL = "select * from Pedias where id = " + ID;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strSQL;
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();//执行ExecuteReader
                while (dr.Read())
                {
                    result.ID = !Convert.IsDBNull(dr["ID"]) ? Convert.ToInt32(dr["ID"]) : 0;
                    result.title = !Convert.IsDBNull(dr["title"]) ? dr["title"].ToString() : string.Empty;
                    var unitext = !Convert.IsDBNull(dr["text"]) ? dr["text"].ToString() : string.Empty;
                    result.text = unitext.FromUnicodeString();
                    result.createTime = !Convert.IsDBNull(dr["createTime"]) ? dr["createTime"].ToString() : string.Empty;
                }
            }
            return result;
        }
    }
}