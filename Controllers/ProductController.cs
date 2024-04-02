using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using LumenTechnology.Models;
using Microsoft.Extensions.Configuration;

namespace LumenTechnology.Controllers
{
    public class ProductController : Controller
    {
        private IConfiguration configuration;
        string cstring;
        public ProductController(IConfiguration configuration)
        {
            this.configuration = configuration;
            cstring = configuration.GetConnectionString("lumandb").ToString();
        }
        public IActionResult ProductDetails()
        {
            List<Product> _product = new List<Product>();
            SqlConnection con = new SqlConnection(cstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from product", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Product obj = new Product();
                obj.productId = Convert.ToInt32(dr["productId"]);
                obj.productName = dr["productName"].ToString();
                obj.productDesc = dr["productDesc"].ToString();
                obj.categoryId = Convert.ToInt32(dr["categoryId"]);

                _product.Add(obj);
            }
            con.Close();

            return View(_product);
        }
    }
}
