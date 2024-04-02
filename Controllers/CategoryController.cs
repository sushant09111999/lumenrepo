using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using LumenTechnology.Models;
namespace LumenTechnology.Controllers
{
    public class CategoryController : Controller
    {
        private IConfiguration configuration;
        string cstring;
        public CategoryController(IConfiguration configuration) {
            this.configuration = configuration;
            cstring = configuration.GetConnectionString("lumandb").ToString();
        }
        public IActionResult CategoryDetails()
        {
            List<Category> _category = new List<Category>();
            SqlConnection con = new SqlConnection(cstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from category", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                Category obj = new Category();
                obj.categoryId =Convert.ToInt32(dr["categoryId"]);
                obj.categoryName = dr["categoryName"].ToString();
                _category.Add(obj);
            }
            con.Close();
               
            return View(_category);
        }
    }
}
