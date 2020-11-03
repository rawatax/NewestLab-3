using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class HomePage : System.Web.UI.Page
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

                    SqlConnection sqlConnect = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    var accountId = Session["accountId"].ToString();
                    var table = Session["table"].ToString();
                    string sqlQuery = "SELECT (FirstName + ' ' + LastName) as NAME from " + table;
                        sqlQuery += " WHERE " + table +"ID = " + accountId;

                    SqlDataAdapter sqlAdapt = new SqlDataAdapter(sqlQuery, sqlConnect);
                    DataTable dataTable = new DataTable();
                    sqlAdapt.Fill(dataTable);
                    welcomeLabel.Text = "Welcome " + dataTable.Rows[0][0];

                    sqlQuery = "SELECT StudentID, (FirstName + ' ' + LastName) as NAME from Student";


                    SqlDataAdapter sqlAdapt2 = new SqlDataAdapter(sqlQuery, sqlConnect);

                    DataTable dataTable2 = new DataTable();
                    sqlAdapt2.Fill(dataTable2);
                    studentDropDown.DataSource = dataTable2;
                    studentDropDown.DataTextField = "NAME";
                    studentDropDown.DataValueField = "StudentID";
                    studentDropDown.DataBind();
                    studentDropDown.Items.Insert(0, new ListItem("Select", "0"));

                    sqlQuery = "SELECT EventID, EventName from Event";
                    SqlDataAdapter sqlAdapt3 = new SqlDataAdapter(sqlQuery, sqlConnect);

                    DataTable dataTable3 = new DataTable();
                    sqlAdapt3.Fill(dataTable3);
                    eventDropDown.DataSource = dataTable3;
                    eventDropDown.DataTextField = "EventName";
                    eventDropDown.DataValueField = "EventID";
                    eventDropDown.DataBind();
                    eventDropDown.Items.Insert(0, new ListItem("Select", "0"));
                }
            }
        }

        protected void Selected_student(object sender, EventArgs e)
        {
            if (Convert.ToInt32(studentDropDown.SelectedValue) > 0)
            {
                string sqlQuery = "Select * from StudentEvent ";
                sqlQuery += " inner join Event on Event.EventID = StudentEvent.EventID";
                sqlQuery += " where StudentEvent.StudentID = " + studentDropDown.SelectedValue;

                SqlConnection sqlConnect = new
                        SqlConnection(ConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                SqlDataAdapter sqlAdapt = new SqlDataAdapter(sqlQuery, sqlConnect);

                DataTable dataTable = new DataTable();
                sqlAdapt.Fill(dataTable);
                studentEventsTable.DataSource = dataTable;
                studentEventsTable.DataBind();

                sqlQuery = "Select (t.FirstName + ' ' + t.Lastname) AS TeacherName from Student s";
                sqlQuery += " inner join teacher t on t.TeacherID = s.TeacherID";
                sqlQuery += " WHERE s.StudentID = " + studentDropDown.SelectedValue;

                SqlDataAdapter sqlAdapt2 = new SqlDataAdapter(sqlQuery, sqlConnect);
                DataTable dataTable2 = new DataTable();
                sqlAdapt2.Fill(dataTable2);
                Teacherlabel.Text = "Teacher: " + dataTable2.Rows[0][0].ToString();
            }
        }

        protected void Selected_event(object sender, EventArgs e)
        {
            if (Convert.ToInt32(eventDropDown.SelectedValue) > 0)
            {
                string sqlQuery = "Select se.StudentEventID, (s.FirstName + ' ' + s.LastName) as Name, e.EventName, e.CalendarDate, e.TimeOfDay, e.RoomNumber from StudentEvent se";
                sqlQuery += " inner join Event e on e.EventID = se.EventID";
                sqlQuery += " inner join Student s on s.StudentID = se.StudentID";
                sqlQuery += " where se.EventID = " + eventDropDown.SelectedValue;

                SqlConnection sqlConnect = new
                        SqlConnection(ConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                SqlDataAdapter sqlAdapt = new SqlDataAdapter(sqlQuery, sqlConnect);

                DataTable dataTable = new DataTable();
                sqlAdapt.Fill(dataTable);
                eventTable.DataSource = dataTable;
                eventTable.DataBind();
                StudentEvents.Text = "Students registered for " + eventDropDown.SelectedItem;

                sqlQuery = "Select ce.CoordinatorEventID, (c.FirstName + ' ' + c.LastName) as Name, e.EventName, e.CalendarDate, e.TimeOfDay, e.RoomNumber from CoordinatorEvent ce";
                sqlQuery += " inner join Event e on e.EventID = ce.EventID";
                sqlQuery += " inner join Coordinator c on c.CoordinatorID = ce.CoordinatorID";
                sqlQuery += " where ce.EventID = " + eventDropDown.SelectedValue;

                SqlDataAdapter sqlAdapt2 = new SqlDataAdapter(sqlQuery, sqlConnect);
                DataTable dataTable2 = new DataTable();
                sqlAdapt2.Fill(dataTable2);
                cEventTable.DataSource = dataTable2;
                cEventTable.DataBind();
                cEvents.Text = "Coordinators registered for " + eventDropDown.SelectedItem;

                sqlQuery = "Select ve.VolunteerEventID, (v.FirstName + ' ' + v.LastName) as Name, e.EventName, e.CalendarDate, e.TimeOfDay, e.RoomNumber from VolunteerEvent ve";
                sqlQuery += " inner join Event e on e.EventID = ve.EventID";
                sqlQuery += " inner join Volunteer v on v.VolunteerID = ve.VolunteerID";
                sqlQuery += " where ve.EventID = " + eventDropDown.SelectedValue;

                SqlDataAdapter sqlAdapt3 = new SqlDataAdapter(sqlQuery, sqlConnect);
                DataTable dataTable3 = new DataTable();
                sqlAdapt3.Fill(dataTable3);
                vEventTable.DataSource = dataTable3;
                vEventTable.DataBind();
                vEvents.Text = "Volunteers registered for " + eventDropDown.SelectedItem;
            }
        }
    }
}