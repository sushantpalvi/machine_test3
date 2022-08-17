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
    public class ProductDal
    {
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

        public int insert(Products products)
        {
            try
            {
                string sql = "insert into products (name, categoryid) values('" + products.name + "', '" + products.categoryid + "')";
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
                string sql = "update products set active = 0  where id = '" + id + "'";
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


        public List<Products> ProductList()
        {
            List<Products> products = new List<Products>();
            try
            {
                con.Open();
                using (SqlCommand cmd1 = new SqlCommand("select TOP 10 p.id, p.name, c.id as categoryid, c.name as categoryname  from products p JOIN categories c on p.categoryid = c.id WHERE p.active = 1 AND c.active = 1 ORDER BY p.id DESC", con))
                {
                    cmd1.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd1))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            foreach (DataRow dr in dt.Rows)
                            {
                                Products cat = new Products();
                                cat.id = Convert.ToInt32(dr[0].ToString());
                                cat.name = dr[1].ToString();
                                cat.categoryid = Convert.ToInt32(dr[2].ToString());
                                cat.categoryname = dr[3].ToString();
                                products.Add(cat);
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
            return products;
        }



        public List<Products> ProductCount()
        {
            List<Products> products = new List<Products>();
            try
            {
                con.Open();
                using (SqlCommand cmd1 = new SqlCommand("select  p.id, p.name, c.id as categoryid, c.name as categoryname  from products p JOIN categories c on p.categoryid = c.id WHERE p.active = 1 AND c.active = 1 ORDER BY p.id DESC", con))
                {
                    cmd1.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd1))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            foreach (DataRow dr in dt.Rows)
                            {
                                Products cat = new Products();
                                cat.id = Convert.ToInt32(dr[0].ToString());
                                cat.name = dr[1].ToString();
                                cat.categoryid = Convert.ToInt32(dr[2].ToString());
                                cat.categoryname = dr[3].ToString();
                                products.Add(cat);
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
            return products;
        }





        public List<Categories> findById(string id)
        {
            List<Categories> categories = new List<Categories>();
            try
            {
                con.Open();
                using (SqlCommand cmd1 = new SqlCommand("select p.id, p.name, c.id as categoryid, c.name as categoryname  from products p JOIN categories c on p.categoryid = c.id WHERE p.active = 1 AND c.active = 1 AND  p.id = '" + id + "'", con))
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


        public int update(Products products)
        {
            try
            {
                string sql = "update products set name = '" + products.name + "', categoryid = '" + products.categoryid + "' where id = '" + products.id + "'";
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


        public List<Products> Pagination(string pageNo)
        {
            List<Products> products = new List<Products>();
            try
            {
                con.Open();
                using (SqlCommand cmd1 = new SqlCommand("select p.id, p.name, c.id as categoryid, c.name as categoryname  from products p JOIN categories c on p.categoryid = c.id WHERE p.active = 1 AND c.active = 1 ORDER BY p.id DESC  OFFSET ('" + pageNo + "' - 1) * 10 ROWS FETCH NEXT 10 ROWS ONLY", con))
                {
                    cmd1.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd1))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            foreach (DataRow dr in dt.Rows)
                            {
                                Products cat = new Products();
                                cat.id = Convert.ToInt32(dr[0].ToString());
                                cat.name = dr[1].ToString();
                                cat.categoryid = Convert.ToInt32(dr[2].ToString());
                                cat.categoryname = dr[3].ToString();
                                products.Add(cat);
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
            return products;
        }
    }
}