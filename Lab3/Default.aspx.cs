using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["accountId"] != null)
                {
                    Response.Redirect("HomePage.aspx", false);
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnect = new
                SqlConnection(ConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);
            var accountType = "";
            var accountId = "";
            var salt = "";
            var pwd = "";

            using (sqlConnect)
            {
                sqlConnect.Open();

                SqlCommand cmd = new SqlCommand("dbo.JeremyEzellLab3", sqlConnect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@UserName", Username.Text));

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        accountType = rdr["AccountType"].ToString();
                        accountId = rdr["AccountTypeID"].ToString();
                        salt = rdr["Salt"].ToString();
                        pwd = rdr["PassWord"].ToString();
                    }
                }
            }

            if (string.IsNullOrEmpty(accountType) || string.IsNullOrEmpty(accountId))
            {
                Errorlabel.Text = "UserName not Found.";
                Errorlabel.ForeColor = Color.Red;
            }
            else
            {
                var textPwd = Password.Text;
                Password newPwd = new Password();
                bool isMatch = newPwd.CheckHash(Convert.FromBase64String(salt), textPwd, pwd);

                if (isMatch)
                {
                    Session["accountId"] = accountId;
                    Session["table"] = accountType;
                    Response.Redirect("HomePage.aspx", false);
                } else
                {
                    Errorlabel.Text = "Password is incorrect.";
                    Errorlabel.ForeColor = Color.Red;
                }
            }
        }
    }
}