using machine_test2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace machine_test2.DAL
{
    public class CategoryDal
    {
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

        public int insert(Categories category)
        {
            try
            {
                string sql = "insert into categories (name) values('" + category.name + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                int status = cmd.ExecuteNonQuery();
                if (status > 0)
                {
                    return status;
                }
                else
                {
                    return status;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return 0;
        }



        public int delete(int id)
        {
            try
            {
                string sql = "update categories set active = 0  where id = '" + id + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                int status = cmd.ExecuteNonQuery();
                if (status > 0)
                {
                    return status;
                }
                else
                {
                    return status;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return 0;
        }


        public List<Categories> CategoriesList()
        {
            List<Categories> categories = new List<Categories>();
            try
            {
                con.Open();
                using (SqlCommand cmd1 = new SqlCommand("select id, name  from categories where active = 1", con))
                {
                    cmd1.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd1))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            foreach (DataRow dr in dt.Rows)
                            {
                                Categories cat = new Categories();
                                cat.id = Convert.ToInt32(dr[0].ToString());
                                cat.name = dr[1].ToString(); ;
                                categories.Add(cat);
                            }
                        }
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return categories;
        }

        public List<Categories> findById(string id)
        {
            List<Categories> categories = new List<Categories>();
            try
            {
                con.Open();
                using (SqlCommand cmd1 = new SqlCommand("select id, name  from categories where id = '" + id + "'", con))
                {
                    cmd1.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd1))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            foreach (DataRow dr in dt.Rows)
                            {
                                Categories cat = new Categories();
                                cat.id = Convert.ToInt32(dr[0].ToString());
                                cat.name = dr[1].ToString(); ;
                                categories.Add(cat);
                            }
                        }
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return categories;
        }


        public int update(Categories categories)
        {
            try
            {
                string sql = "update categories set name = '" + categories.name + "' where id = '" + categories.id + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                int status = cmd.ExecuteNonQuery();
                if (status > 0)
                {
                    return status;
                }
                else
                {
                    return status;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return 0;
        }
    }
}