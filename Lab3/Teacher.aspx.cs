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
    public partial class Teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                
                    string sqlQuery = "SELECT SchoolID, SchoolName from School";

                    SqlConnection sqlConnect = new
                        SqlConnection(ConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                    SqlDataAdapter sqlAdapt = new SqlDataAdapter(sqlQuery, sqlConnect);

                    DataTable dataTable = new DataTable();
                    sqlAdapt.Fill(dataTable);
                    schoolDropDown.DataSource = dataTable;
                    schoolDropDown.DataTextField = "SchoolName";
                    schoolDropDown.DataValueField = "SchoolID";
                    schoolDropDown.DataBind();
                

            }
        }

        public void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Password.Text != Password2.Text)
            {
                Errorlabel.Text = "Password does not match.";
                Errorlabel.ForeColor = Color.Red;
            }
            else
            {
                try
                {
                    SqlConnection sqlConnect = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    sqlConnect.Open();

                    Int32 lastTeacherId = 0;
                    string lastTeacherIdSql = "SELECT TOP 1 TeacherId FROM Teacher ORDER BY TeacherId DESC";
                    using (SqlCommand cmd = new SqlCommand(lastTeacherIdSql, sqlConnect))
                    {
                        lastTeacherId = (Int32)cmd.ExecuteScalar();
                        lastTeacherId += 1;
                    }

                    string sql = "INSERT INTO Teacher(TeacherId,FirstName,LastName,PhoneNumber,EmailAddress,Grade,SchoolID) VALUES(@param1,@param2,@param3,@param4,@param5,@param6,@param7)";

                    using (SqlCommand cmd = new SqlCommand(sql, sqlConnect))
                    {
                        cmd.Parameters.Add("@param1", SqlDbType.Int).Value = lastTeacherId;
                        cmd.Parameters.Add("@param2", SqlDbType.VarChar, 50).Value = FirstName.Text;
                        cmd.Parameters.Add("@param3", SqlDbType.VarChar, 50).Value = LastName.Text;
                        cmd.Parameters.Add("@param4", SqlDbType.VarChar, 50).Value = PhoneNumber.Text;
                        cmd.Parameters.Add("@param5", SqlDbType.VarChar, 50).Value = Email.Text;
                        cmd.Parameters.Add("@param6", SqlDbType.Int).Value = dropGrade.SelectedValue;
                        cmd.Parameters.Add("@param7", SqlDbType.Int).Value = schoolDropDown.SelectedValue;

                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }

                    Password newPwd = new Password();

                    newPwd.Hash(Password.Text);


                    SqlConnection sqlConnect2 = new
                        SqlConnection(ConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);

                    sqlConnect2.Open();

                    Int32 lastAccountId = 0;
                    string lastAccountIdSql = "SELECT TOP 1 AccountID FROM Account ORDER BY AccountID DESC";
                    using (SqlCommand cmd = new SqlCommand(lastAccountIdSql, sqlConnect2))
                    {
                        lastAccountId = (Int32)cmd.ExecuteScalar();
                        lastAccountId += 1;
                    }

                    sql = "INSERT INTO Account(AccountID,AccountType,AccountTypeID,UserName,PassWord,Salt) VALUES(@param1,@param2,@param3,@param4,@param5,@param6)";

                    using (SqlCommand cmd = new SqlCommand(sql, sqlConnect2))
                    {
                        cmd.Parameters.Add("@param1", SqlDbType.Int).Value = lastAccountId;
                        cmd.Parameters.Add("@param2", SqlDbType.VarChar, 50).Value = "Teacher";
                        cmd.Parameters.Add("@param3", SqlDbType.Int).Value = lastTeacherId;
                        cmd.Parameters.Add("@param4", SqlDbType.VarChar, 255).Value = UserName.Text;
                        cmd.Parameters.Add("@param5", SqlDbType.VarChar, 255).Value = newPwd.Hashed;
                        cmd.Parameters.Add("@param6", SqlDbType.VarChar, 255).Value = newPwd.Salt;

                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }

                    btnClear_Click(sender, e);

                    Errorlabel.Text = "New teacher added.";
                    Errorlabel.ForeColor = Color.Green;

                }
                catch (Exception ex)
                {
                    Errorlabel.Text = "Could not add Teacher.";
                    Errorlabel.ForeColor = Color.Red;
                }
            }
        }

        public void btnClear_Click(object sender, EventArgs e)
        {
            Errorlabel.Text = "";
            FirstName.Text = "";
            LastName.Text = "";
            PhoneNumber.Text = "";
            Email.Text = "";
            UserName.Text = "";
            Password.Text = "";
            Password2.Text = "";
        }
    }
}