using Project2.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace Project2.Controllers
{
    public class HomeController : Controller
    {
        private readonly MobildevEntities db = new MobildevEntities();
        private SqlConnection con;

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetUsers()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var users = db.Users.ToList();
            return Json(new { data = users }, JsonRequestBehavior.AllowGet);
        }

        public void AddUser(User obj)
        {
            string constr = ConfigurationManager.ConnectionStrings["SqlCon"].ToString();
            con = new SqlConnection(constr);

            SqlCommand connect = new SqlCommand("SP_user_Add", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            connect.Parameters.AddWithValue("@FirstName", obj.FirstName);
            connect.Parameters.AddWithValue("@LastName", obj.LastName);
            connect.Parameters.AddWithValue("@Phone", obj.Phone);
            connect.Parameters.AddWithValue("@Email", obj.Email);
            con.Open();
            connect.ExecuteNonQuery();
            con.Close();
        }
    }
}