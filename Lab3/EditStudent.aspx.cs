using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class EditStudent : System.Web.UI.Page
    {
        public string StudentID { get; set; }
        public string TshirtID { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.StudentID = Request.QueryString["studentID"];

            if (!IsPostBack)
            {
                if (Session["accountId"] == null)
                {
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    string sqlQuery = "SELECT TeacherID, (FirstName + ' ' + LastName) as NAME from Teacher";

                    SqlConnection sqlConnect = new
                        SqlConnection(ConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                    SqlDataAdapter sqlAdapt = new SqlDataAdapter(sqlQuery, sqlConnect);

                    sqlConnect.Open();

                    DataTable dataTable = new DataTable();
                    sqlAdapt.Fill(dataTable);
                    teacherDropDown.DataSource = dataTable;
                    teacherDropDown.DataTextField = "NAME";
                    teacherDropDown.DataValueField = "TeacherID";
                    teacherDropDown.DataBind();
                    teacherDropDown.Items.Insert(0, new ListItem("Select", "0"));

                    sqlQuery = "SELECT * FROM Student WHERE StudentID =" + this.StudentID;

                    SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnect);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            FirstName.Text = rdr["FirstName"].ToString();
                            LastName.Text = rdr["LastName"].ToString();
                            Age.Text = rdr["Age"].ToString();
                            Notes.Text = rdr["Notes"].ToString();
                            teacherDropDown.SelectedValue = rdr["TeacherID"].ToString();
                            this.TshirtID = rdr["TshirtID"].ToString();
                        }
                    }

                    sqlQuery = "SELECT * FROM Tshirt WHERE TshirtID =" + this.TshirtID;
                    SqlCommand cmd2 = new SqlCommand(sqlQuery, sqlConnect);
                    cmd2.CommandType = CommandType.Text;
                    using (SqlDataReader rdr = cmd2.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            dropShirtSize.SelectedValue = dropShirtSize.Items.FindByText(rdr["Size"].ToString()).Value ?? "0";
                            dropShirtColor.SelectedValue = dropShirtColor.Items.FindByText(rdr["Color"].ToString()).Value ?? "0";
                        }
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnect = new
                SqlConnection(ConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            sqlConnect.Open();

            string sql = "SELECT TshirtID FROM Student WHERE StudentID =" + this.StudentID;

            SqlCommand cmd = new SqlCommand(sql, sqlConnect);
            cmd.CommandType = CommandType.Text;
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    this.TshirtID = rdr["TshirtID"].ToString();
                }
            }

            try
            {
                string sql2 = "UPDATE Tshirt SET Size = @param1, Color = @param2 WHERE TshirtID = @param3";

                using (SqlCommand cmd2 = new SqlCommand(sql2, sqlConnect))
                {
                    cmd2.Parameters.Add("@param1", SqlDbType.VarChar, 50).Value = dropShirtSize.SelectedItem.Text;
                    cmd2.Parameters.Add("@param2", SqlDbType.VarChar, 50).Value = dropShirtColor.SelectedItem.Text;
                    cmd2.Parameters.Add("@param3", SqlDbType.VarChar, 50).Value = this.TshirtID;
                    cmd2.CommandType = CommandType.Text;
                    cmd2.ExecuteNonQuery();
                }

                string sql3 = "UPDATE Student SET FirstName ='" + FirstName.Text + "', LastName = '" + LastName.Text + "',";
                sql3 += " Age = '" + Age.Text + "', Notes = '" + Notes.Text + "', TeacherID = '" + teacherDropDown.SelectedValue + "'";
                sql3 += " WHERE StudentID = " + this.StudentID;

                using (SqlCommand cmd3 = new SqlCommand(sql3, sqlConnect))
                {
                    cmd3.CommandType = CommandType.Text;
                    cmd3.ExecuteNonQuery();
                }

                Errorlabel.Text = "";
                Errorlabel.ForeColor = Color.Green;
                Errorlabel.Text = "Student updated Successfully";
            } catch (Exception ex)
            {
                Errorlabel.Text = "";
                Errorlabel.ForeColor = Color.Red;
                Errorlabel.Text = "Failed to update student";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Students.aspx", false);
        }
    }
}