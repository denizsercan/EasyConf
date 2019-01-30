using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace finalProject
{
    public partial class submitPaper : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }


        private void BindGrid()
        {
            Object conference = Session["ConfData"];
            string constr = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select topic from Topics where fk_Conferences = @confId";
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@confId", conference.ToString());
                    con.Open();
                    DropDownList1.DataSource = cmd.ExecuteReader();
                    DropDownList1.DataBind();
                    con.Close();
                }
            }
        }

        protected void Upload(object sender, EventArgs e)
        {
            Object kullanici = Session["kullaniciadi"];
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string contentType = FileUpload1.PostedFile.ContentType;
            string topic = DropDownList1.SelectedValue;

            using (Stream fs = FileUpload1.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    string constr = ConfigurationManager.ConnectionStrings[0].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        string query = "insert into Papers (filename , paper, contentType, submissionDate, status, fk_Users, fk_Topics) values (@filename, @paper, @contentType, @submissionDate, 1, (Select Id from Users where email = @email), (Select Id from Topics where topic = @topic))";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@filename", filename);
                            cmd.Parameters.AddWithValue("@contentType", contentType);
                            cmd.Parameters.AddWithValue("@paper", bytes);
                            cmd.Parameters.AddWithValue("@submissionDate", DateTime.Now);
                            cmd.Parameters.AddWithValue("@email", kullanici.ToString());
                            cmd.Parameters.AddWithValue("@topic", topic);


                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                            lblSonuc.Text = "Kağıt Gönderildi";

                        }
                    }
                }
            }
            Response.Redirect(Request.Url.AbsoluteUri);
        }
       
    }
}