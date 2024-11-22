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
    public partial class StudentProfile : System.Web.UI.Page
    {
        ConCls obj = new ConCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gridbindfun();


                string sel = "select First_Name,Last_Name,Age,DOB,Gender,Email,Phone_Number from Student Where Student_Id=" + Session["sid"] + "";
                SqlDataReader dr = obj.Fn_Reader(sel);
                while (dr.Read())
                {
                    Label8.Text = dr["First_Name"].ToString();
                    Label9.Text = dr["Last_Name"].ToString();
                    Label10.Text = dr["Age"].ToString();
                    //Label11.Text = dr["DOB"].ToString();
                    DateTime date = Convert.ToDateTime(dr["DOB"]);
                    Label11.Text = date.ToString("dd/MM/yyyy");
                    Label12.Text = dr["Gender"].ToString();
                    Label13.Text = dr["Email"].ToString();
                    Label14.Text = dr["Phone_Number"].ToString();

                }
            }
        }
            public void gridbindfun()
            {
              string s= "select Course,University,Year,Percentage from Qualification  where Student_Id='" + Session["sid"] + "'";
              DataSet ds = obj.Fn_Dataset(s);
              GridView1.DataSource = ds;
             GridView1.DataBind();
        }

    }
}

