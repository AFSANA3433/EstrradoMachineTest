using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace EstrradoMachineTest
{
    public partial class Login : System.Web.UI.Page
    {
        ConCls obj = new ConCls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "select count(Student_Id) from Student  where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
            string cid = obj.Fn_Scalar(s);
            if (cid == "1")
            {
                int id1 = 0;
                string str = "select Student_Id from Student where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
                SqlDataReader dr = obj.Fn_Reader(str);
                while (dr.Read())
                {
                    id1 = Convert.ToInt32(dr["Student_Id"].ToString());
                }

                Session["sid"] = id1;
                Response.Redirect("StudentProfile.aspx");
            }
            else
            {
                Label3.Visible = true;
                Label3.Text = "Invalid Username or Password";
            }
        }

    }
}