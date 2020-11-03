using Lab1;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateUploadedFiles();
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

                    DataTable dataTable = new DataTable();
                    sqlAdapt.Fill(dataTable);
                    teacherDropDown.DataSource = dataTable;
                    teacherDropDown.DataTextField = "NAME";
                    teacherDropDown.DataValueField = "TeacherID";
                    teacherDropDown.DataBind();
                    teacherDropDown.Items.Insert(0, new ListItem("Select", "0"));
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnect = new
                SqlConnection(ConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            sqlConnect.Open();

            Int32 lastId = 0;
            string lastIdSql = "SELECT TOP 1 TshirtID FROM Tshirt ORDER BY TshirtID DESC";
            using (SqlCommand cmd = new SqlCommand(lastIdSql, sqlConnect))
            {
                lastId = (Int32)cmd.ExecuteScalar();
                lastId += 1;
            }

            Tshirt newShirt = new Tshirt(lastId, dropShirtSize.SelectedItem.Text, dropShirtColor.SelectedItem.Text);

            string sql = "INSERT INTO Tshirt(TshirtID,Size,Color) VALUES(@param1,@param2,@param3)";

            using (SqlCommand cmd = new SqlCommand(sql, sqlConnect))
            {
                cmd.Parameters.Add("@param1", SqlDbType.Int).Value = newShirt.TshirtID;
                cmd.Parameters.Add("@param2", SqlDbType.VarChar, 50).Value = newShirt.Size;
                cmd.Parameters.Add("@param3", SqlDbType.VarChar, 50).Value = newShirt.Color;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }

            Int32 lastStudentId = 0;
            string lastStudentIdSql = "SELECT TOP 1 StudentId FROM Student ORDER BY StudentId DESC";
            using (SqlCommand cmd = new SqlCommand(lastStudentIdSql, sqlConnect))
            {
                lastStudentId = (Int32)cmd.ExecuteScalar();
                lastStudentId += 1;
            }


            Student newStudent = new Student(lastStudentId, FirstName.Text, LastName.Text, Convert.ToInt32(Age.Text), Notes.Text, Convert.ToInt32(teacherDropDown.SelectedValue), newShirt.TshirtID);

            string dupSql = "SELECT COUNT(1) FROM Student WHERE ";
            dupSql += "FirstName = '" + newStudent.FirstName + "'";
            dupSql += " AND LastName = '" + newStudent.LastName + "'";
            dupSql += " AND Age = " + newStudent.Age.ToString();
            dupSql += " AND TeacherId = " + newStudent.TeacherId.ToString();

            int dupCheck = 0;
            using (SqlCommand cmd = new SqlCommand(dupSql, sqlConnect))
            {
                dupCheck = (Int32)cmd.ExecuteScalar();
            }

            if (dupCheck < 1)
            {
                string studentSql = "INSERT INTO Student(StudentID,FirstName,LastName,Age,Notes,TeacherId,TshirtId) VALUES(@param1,@param2,@param3,@param4,@param5,@param6,@param7)";

                try
                {
                    using (SqlCommand cmd = new SqlCommand(studentSql, sqlConnect))
                    {
                        cmd.Parameters.Add("@param1", SqlDbType.Int).Value = newStudent.StudentId;
                        cmd.Parameters.Add("@param2", SqlDbType.VarChar, 50).Value = newStudent.FirstName;
                        cmd.Parameters.Add("@param3", SqlDbType.VarChar, 50).Value = newStudent.LastName;
                        cmd.Parameters.Add("@param4", SqlDbType.Int).Value = newStudent.Age;
                        cmd.Parameters.Add("@param5", SqlDbType.VarChar, 50).Value = newStudent.Notes;
                        cmd.Parameters.Add("@param6", SqlDbType.Int).Value = newStudent.TeacherId;
                        cmd.Parameters.Add("@param7", SqlDbType.Int).Value = newStudent.TshirtId;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                    this.btnClear_Click(sender, e);

                    Errorlabel.Text = "New student added.";
                    Errorlabel.ForeColor = Color.Green;

                }
                catch (Exception ex)
                {
                    Errorlabel.Text = "Could not add Student.";
                    Errorlabel.ForeColor = Color.Red;
                }

            }
            else
            {
                Errorlabel.Text = "Student already exists.";
                Errorlabel.ForeColor = Color.Red;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            FirstName.Text = "";
            LastName.Text = "";
            Age.Text = "";
            Notes.Text = "";
            dropShirtSize.SelectedIndex = 0;
            dropShirtColor.SelectedIndex = 0;
            teacherDropDown.SelectedIndex = 0;
            Errorlabel.Text = "";
            SuccessLabel.Text = "";
        }

        protected void btnPopulate_Click(object sender, EventArgs e)
        {
            FirstName.Text = "Anu";
            LastName.Text = "Rawat";
            Age.Text = "12";
            Notes.Text = "New Student";
            dropShirtSize.SelectedIndex = 1;
            dropShirtColor.SelectedIndex = 2;
            teacherDropDown.SelectedIndex = 1;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnect = new
                SqlConnection(ConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            sqlConnect.Open();

            var searchQuery = searchStudent.Text.Split(' ');

            string sql = "SELECT * FROM Student WHERE";
            sql += " TeacherID = " + Session["accountId"] + " AND";

            foreach (var q in searchQuery)
            {
                if (searchQuery.Count() < 2)
                {
                    sql += " (FirstName LIKE '" + q + "'";
                    sql += " OR LastName LIKE '" + q + "')";
                } else if (searchQuery.FirstOrDefault() == q)
                {
                    sql += " (FirstName LIKE '" + q + "'";
                    sql += " OR LastName LIKE '" + q + "'";
                } else if (searchQuery.LastOrDefault() == q)
                {
                    sql += " OR FirstName LIKE '" + q + "'";
                    sql += " OR LastName LIKE '" + q + "')";
                } else
                {
                    sql += " OR FirstName LIKE '" + q + "'";
                    sql += " OR LastName LIKE '" + q + "'";
                }
            }



            SqlCommand cmd = new SqlCommand(sql, sqlConnect);
            cmd.CommandType = CommandType.Text;

            List<Student> searchResults = new List<Student>();


            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    TableCell firstName = new TableCell() { Text = rdr["FirstName"].ToString() };
                    TableCell lastName = new TableCell() { Text = rdr["LastName"].ToString() };
                    TableCell edit = new TableCell();
                    Button button = new Button();
                    button.Text = "EDIT";
                    button.CausesValidation = false;
                    button.UseSubmitBehavior = false;
                    //button.OnClientClick = "";
                    button.PostBackUrl = "EditStudent.aspx?studentID=" + rdr["StudentID"].ToString();
                    button.ID = "btnEdit" + rdr["StudentID"].ToString();
                    edit.Controls.Add(button);

                    TableRow row = new TableRow();
                    row.Cells.Add(firstName);
                    row.Cells.Add(lastName);
                    row.Cells.Add(edit);
                    searchTable.Rows.Add(row);

                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var studentId = btn.CommandArgument.ToString();
            Console.WriteLine(studentId);
        }

        private void PopulateUploadedFiles()
        {
            string strcon = ConfigurationManager.ConnectionStrings["Lab3"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            String sqlQuery = "SELECT * from [File]";
            List<Lab1.File> allFiles = new List<Lab1.File>();

            con.Open();
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Lab1.File newFile = new Lab1.File()
                        {
                            FileID = Convert.ToInt32(reader["FileID"]),
                            FileName = reader["FileName"].ToString(),
                            FileSize = Convert.ToInt32(reader["FileSize"]),
                            ContentType = reader["ContentType"].ToString(),
                            FileExtension = reader["FileExtension"].ToString(),
                            FileContent = Encoding.ASCII.GetBytes(reader["FileContent"].ToString())
                        };
                        allFiles.Add(newFile);
                    }
                }
                FileList.DataSource = allFiles;
                FileList.DataBind();
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            // Code for Upload file to database
            if (FileUpload1.HasFile)
            {
                HttpPostedFile file = FileUpload1.PostedFile;
                BinaryReader br = new BinaryReader(file.InputStream);
                byte[] buffer = br.ReadBytes(file.ContentLength);

                string strcon = ConfigurationManager.ConnectionStrings["Lab3"].ConnectionString;
                SqlConnection con = new SqlConnection(strcon);
                String sqlQuery = "INSERT INTO [File](FileName,FileSize,ContentType,FileExtension,FileContent) VALUES(@param1,@param2,@param3,@param4,@param5)";
                List<Lab1.File> allFiles = new List<Lab1.File>();


                con.Open();

                //Int32 lastId = 0;
                //string lastIdSql = "SELECT TOP 1 FileID FROM [File] ORDER BY FileID DESC";
                //using (SqlCommand cmd = new SqlCommand(lastIdSql, con))
                //{
                //    if (cmd.ExecuteScalar() == null)
                //    {
                //        lastId = 1;
                //    }
                //    else
                //    {
                //        lastId = (Int32)cmd.ExecuteScalar();
                //        lastId += 1;
                //    }
                //}

                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    cmd.Parameters.Add("@param1", SqlDbType.VarChar, 200).Value = file.FileName;
                    cmd.Parameters.Add("@param2", SqlDbType.Int).Value = file.ContentLength;
                    cmd.Parameters.Add("@param3", SqlDbType.VarChar, 200).Value = file.ContentType;
                    cmd.Parameters.Add("@param4", SqlDbType.VarChar, 10).Value = Path.GetExtension(file.FileName);
                    cmd.Parameters.Add("@param5", SqlDbType.VarBinary).Value = buffer;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }

                PopulateUploadedFiles();
            }
        }

        protected void FileList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                int fileID = Convert.ToInt32(e.CommandArgument);

                string strcon = ConfigurationManager.ConnectionStrings["Lab3"].ConnectionString;
                SqlConnection con = new SqlConnection(strcon);
                String sqlQuery = "SELECT * from [File] WHERE FileID =" + fileID;

                con.Open();
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    Lab1.File newFile = new Lab1.File();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            newFile.FileID = Convert.ToInt32(reader["FileID"]);
                            newFile.FileName = reader["FileName"].ToString();
                            newFile.FileSize = Convert.ToInt32(reader["FileSize"]);
                            newFile.ContentType = reader["ContentType"].ToString();
                            newFile.FileExtension = reader["FileExtension"].ToString();
                            newFile.FileContent = (byte[])reader["FileContent"];
                        }

                        if (newFile.FileID > 0)
                        {
                            byte[] fileData = newFile.FileContent;
                            Response.AddHeader("Content-type", newFile.ContentType);
                            Response.AddHeader("Content-Disposition", "attachment; filename=" + newFile.FileName);

                            byte[] dataBlock = new byte[0x1000];
                            long fileSize;
                            int bytesRead;
                            long totalsBytesRead = 0;

                            using (Stream st = new MemoryStream(fileData))
                            {
                                fileSize = st.Length;
                                while (totalsBytesRead < fileSize)
                                {
                                    if (Response.IsClientConnected)
                                    {
                                        bytesRead = st.Read(dataBlock, 0, dataBlock.Length);
                                        Response.OutputStream.Write(dataBlock, 0, bytesRead);

                                        Response.Flush();
                                        totalsBytesRead += bytesRead;
                                    }
                                }
                            }
                            Response.End();
                        }
                    }
                }
            }
        }
    }
}