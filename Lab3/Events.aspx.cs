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
    public partial class Events : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["accountId"] == null)
                {
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    string sqlQuery = "SELECT VolunteerID, (FirstName + ' ' + LastName) as NAME from Volunteer";

                    SqlConnection sqlConnect = new
                        SqlConnection(ConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                    SqlDataAdapter sqlAdapt = new SqlDataAdapter(sqlQuery, sqlConnect);

                    DataTable dataTable = new DataTable();
                    sqlAdapt.Fill(dataTable);
                    vDropDown.DataSource = dataTable;
                    vDropDown.DataTextField = "NAME";
                    vDropDown.DataValueField = "VolunteerID";
                    vDropDown.DataBind();
                    vDropDown.Items.Insert(0, new ListItem("Select", "0"));

                    sqlQuery = "SELECT EventID, EventName from Event";
                    SqlDataAdapter sqlAdapt2 = new SqlDataAdapter(sqlQuery, sqlConnect);

                    DataTable dataTable2 = new DataTable();
                    sqlAdapt2.Fill(dataTable2);
                    eDropDown.DataSource = dataTable2;
                    eDropDown.DataTextField = "EventName";
                    eDropDown.DataValueField = "EventID";
                    eDropDown.DataBind();
                    eDropDown.Items.Insert(0, new ListItem("Select", "0"));
                    eDropDown2.DataSource = dataTable2;
                    eDropDown2.DataTextField = "EventName";
                    eDropDown2.DataValueField = "EventID";
                    eDropDown2.DataBind();
                    eDropDown2.Items.Insert(0, new ListItem("Select", "0"));


                    sqlQuery = "SELECT CoordinatorID, (FirstName + ' ' + LastName) as NAME from Coordinator";
                    SqlDataAdapter sqlAdapt3 = new SqlDataAdapter(sqlQuery, sqlConnect);

                    DataTable dataTable3 = new DataTable();
                    sqlAdapt3.Fill(dataTable3);
                    cDropDown.DataSource = dataTable3;
                    cDropDown.DataTextField = "NAME";
                    cDropDown.DataValueField = "CoordinatorID";
                    cDropDown.DataBind();
                    cDropDown.Items.Insert(0, new ListItem("Select", "0"));
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(vDropDown.SelectedValue) < 1)
            {
                SuccessLabel.Text = "";
                ErrorLabel.Text = "Please pick a Volunteer";
                ErrorLabel.ForeColor = Color.Red;

            }
            else if (Convert.ToInt32(eDropDown.SelectedValue) < 1)
            {
                SuccessLabel.Text = "";
                ErrorLabel.Text = "Please pick an Event";
                ErrorLabel.ForeColor = Color.Red;

            }
            else if (cEventTable.Rows.Count > 1)
            {
                SuccessLabel.Text = "";
                ErrorLabel.Text = "Volunteers can only register for 2 events";
                ErrorLabel.ForeColor = Color.Red;

            }
            else
            {
                SqlConnection sqlConnect = new
               SqlConnection(ConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                sqlConnect.Open();

                string dupSql = "SELECT COUNT(1) FROM VolunteerEvent WHERE ";
                dupSql += "VolunteerID = " + Convert.ToInt32(vDropDown.SelectedValue);
                dupSql += " AND EventID = " + Convert.ToInt32(eDropDown.SelectedValue);

                int dupCheck = 0;
                using (SqlCommand cmd = new SqlCommand(dupSql, sqlConnect))
                {
                    dupCheck = (Int32)cmd.ExecuteScalar();
                }

                if (dupCheck > 0)
                {
                    SuccessLabel.Text = "";
                    ErrorLabel.Text = "Volunteer is already registered.";
                    ErrorLabel.ForeColor = Color.Red;
                }
                else
                {
                    Int32 lastId = 0;
                    string lastIdSql = "SELECT TOP 1 VolunteerEventID FROM VolunteerEvent ORDER BY VolunteerEventID DESC";
                    using (SqlCommand cmd = new SqlCommand(lastIdSql, sqlConnect))
                    {
                        lastId = (Int32)cmd.ExecuteScalar();
                        lastId += 1;
                    }

                    string sql = "INSERT INTO VolunteerEvent(VolunteerEventID,VolunteerID,EventID) VALUES(@param1,@param2,@param3)";

                    using (SqlCommand cmd = new SqlCommand(sql, sqlConnect))
                    {
                        cmd.Parameters.Add("@param1", SqlDbType.Int).Value = lastId;
                        cmd.Parameters.Add("@param2", SqlDbType.Int).Value = Convert.ToInt32(vDropDown.SelectedValue);
                        cmd.Parameters.Add("@param3", SqlDbType.Int).Value = Convert.ToInt32(eDropDown.SelectedValue);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                    ErrorLabel.Text = "";
                    SuccessLabel.Text = "Volunteer has been registered";
                    SuccessLabel.ForeColor = Color.Green;
                    this.Selected_volunteer(sender, e);
                }
            }
        }

        protected void Selected_volunteer(object sender, EventArgs e)
        {
            if (Convert.ToInt32(vDropDown.SelectedValue) > 0)
            {
                string sqlQuery = "Select * from VolunteerEvent ";
                sqlQuery += " inner join Event on Event.EventID = VolunteerEvent.EventID";
                sqlQuery += " where VolunteerEvent.VolunteerID = " + vDropDown.SelectedValue;

                SqlConnection sqlConnect = new
                        SqlConnection(ConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                SqlDataAdapter sqlAdapt = new SqlDataAdapter(sqlQuery, sqlConnect);

                DataTable dataTable = new DataTable();
                sqlAdapt.Fill(dataTable);
                cEventTable.DataSource = dataTable;
                cEventTable.DataBind();
                cEventLabel.Text = "Volunteer's registered events";

                sqlQuery = "SELECT Phonenumber, Email FROM Volunteer WHERE VolunteerID =" + vDropDown.SelectedValue;
                SqlDataAdapter sqlAdapt2 = new SqlDataAdapter(sqlQuery, sqlConnect);

                DataTable dataTable2 = new DataTable();
                sqlAdapt2.Fill(dataTable2);
                contactTable.DataSource = dataTable2;
                contactTable.DataBind();
                contactLabel.Text = "Contact Info";
            }
        }

        protected void btnRegister2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cDropDown.SelectedValue) < 1)
            {
                SuccessLabel2.Text = "";
                ErrorLabel2.Text = "Please pick a Coordinator";
                ErrorLabel2.ForeColor = Color.Red;

            }
            else if (Convert.ToInt32(eDropDown2.SelectedValue) < 1)
            {
                SuccessLabel2.Text = "";
                ErrorLabel2.Text = "Please pick an Event";
                ErrorLabel2.ForeColor = Color.Red;

            }
            else
            {
                SqlConnection sqlConnect = new
                SqlConnection(ConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                sqlConnect.Open();

                string dupSql = "SELECT COUNT(1) FROM CoordinatorEvent WHERE ";
                dupSql += "CoordinatorID = " + Convert.ToInt32(cDropDown.SelectedValue);
                dupSql += " AND EventID = " + Convert.ToInt32(eDropDown2.SelectedValue);

                int dupCheck = 0;
                using (SqlCommand cmd = new SqlCommand(dupSql, sqlConnect))
                {
                    dupCheck = (Int32)cmd.ExecuteScalar();
                }

                if (dupCheck > 0)
                {
                    SuccessLabel2.Text = "";
                    ErrorLabel2.Text = "Coordinator is already registered.";
                    ErrorLabel2.ForeColor = Color.Red;
                }
                else
                {
                    Int32 lastId = 0;
                    string lastIdSql = "SELECT TOP 1 CoordinatorEventID FROM CoordinatorEvent ORDER BY CoordinatorEventID DESC";
                    using (SqlCommand cmd = new SqlCommand(lastIdSql, sqlConnect))
                    {
                        lastId = (Int32)cmd.ExecuteScalar();
                        lastId += 1;
                    }

                    string sql = "INSERT INTO CoordinatorEvent(CoordinatorEventID,CoordinatorID,EventID) VALUES(@param1,@param2,@param3)";

                    using (SqlCommand cmd = new SqlCommand(sql, sqlConnect))
                    {
                        cmd.Parameters.Add("@param1", SqlDbType.Int).Value = lastId;
                        cmd.Parameters.Add("@param2", SqlDbType.Int).Value = Convert.ToInt32(cDropDown.SelectedValue);
                        cmd.Parameters.Add("@param3", SqlDbType.Int).Value = Convert.ToInt32(eDropDown2.SelectedValue);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                    ErrorLabel2.Text = "";
                    SuccessLabel2.Text = "Coordinator has been registered";
                    SuccessLabel2.ForeColor = Color.Green;
                    this.Selected_coordinator(sender, e);
                }
            }
        }

        protected void Selected_coordinator(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cDropDown.SelectedValue) > 0)
            {
                string sqlQuery = "Select * from CoordinatorEvent ";
                sqlQuery += " inner join Event on Event.EventID = CoordinatorEvent.EventID";
                sqlQuery += " where CoordinatorEvent.CoordinatorID = " + cDropDown.SelectedValue;

                SqlConnection sqlConnect = new
                        SqlConnection(ConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                SqlDataAdapter sqlAdapt = new SqlDataAdapter(sqlQuery, sqlConnect);

                DataTable dataTable = new DataTable();
                sqlAdapt.Fill(dataTable);
                cEventTable2.DataSource = dataTable;
                cEventTable2.DataBind();
                cEventLabel2.Text = "Coordinator's registered events";

                sqlQuery = "SELECT Phonenumber, Email FROM Coordinator WHERE CoordinatorID =" + cDropDown.SelectedValue;
                SqlDataAdapter sqlAdapt2 = new SqlDataAdapter(sqlQuery, sqlConnect);

                DataTable dataTable2 = new DataTable();
                sqlAdapt2.Fill(dataTable2);
                contactTable2.DataSource = dataTable2;
                contactTable2.DataBind();
                contactLabel2.Text = "Contact Info";
            }
        }
    }
}