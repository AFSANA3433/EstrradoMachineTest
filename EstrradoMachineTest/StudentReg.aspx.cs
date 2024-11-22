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
    public partial class StudentReg : System.Web.UI.Page
    {
        ConCls obj = new ConCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string ch = "";
            for (int j = 0; j < CheckBoxList1.Items.Count; j++)
            {
                if (CheckBoxList1.Items[j].Selected)
                {
                    ch += CheckBoxList1.Items[j].Text + ",";
                }
            }

            string strins = "Insert into Student (First_Name, Last_Name, Age, DOB, Gender, Email, Phone_Number, Username, Password) " + "values('" + TextBox1.Text + "', '" + TextBox2.Text + "', " + TextBox3.Text + ", '" + TextBox4.Text + "', '" + RadioButtonList1.SelectedValue + "', '" + TextBox5.Text + "', '" + TextBox6.Text + "', '" + TextBox7.Text + "', '" + TextBox8.Text + "')";
            int i = obj.Fn_NonQuery(strins);
           
            if (i == 1)
            {

                string selid = "SELECT IDENT_CURRENT('Student')";
                int studentId = Convert.ToInt32(obj.Fn_Scalar(selid));


                string insert = "Insert into Qualification (Student_Id, Course, University, Year, Percentage) " +
                                "values(" + studentId + ", '" + ch + "', '" + DropDownList1.SelectedItem.Text + "', '" + TextBox9.Text + "', '" + TextBox10.Text + "')";
                int j = obj.Fn_NonQuery(insert);


                Label13.Visible = true;
                Label13.Text = "Successfully Registered";
            }
        }
    }

}

