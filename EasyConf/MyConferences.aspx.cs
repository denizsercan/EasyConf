using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


namespace finalProject
{
    public partial class MyConferences : System.Web.UI.Page
    {
        private SqlConnection conn = new SqlConnection("Data Source=SERCANDENIZ\\SQLEXPRESS;Initial Catalog=Tez;Integrated Security=True");
        internal User user;

        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                BindGrid();
                BindGridView();
            }
        }

        private void BindGrid()
        {
            if(Session["user"] != null)
            {
                user = Session["user"] as User;
            }

            string constr = ConfigurationManager.ConnectionStrings[0].ConnectionString;

            using(SqlConnection con = new SqlConnection(constr))
            {
                string query = "select Conferences.Id, Conferences.conferenceName, Conferences.conferenceDate, Conferences.conferencePlace, Conferences.submissionDueDate , Conferences.category, Conferences.status, Conferences.conferenceDescription from Conferences inner join Users on Conferences.fk_Users = Users.Id where Users.Id = @UserId";

                using(SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;

                    SqlParameter prm = cmd.Parameters.AddWithValue("@UserId", user.Id);

                    if(user == null)
                    {
                        prm.Value = DBNull.Value;
                    }

                    con.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    con.Close();
                }
            }
        }

        protected void BindGridView()
        {
            if(Session["user"] != null)
            {
                user = Session["user"] as User;
            }
            SqlCommand cmd = new SqlCommand("select Conferences.Id, Conferences.conferenceName, Conferences.conferenceDate , Conferences.conferencePlace, Conferences.submissionDueDate , Conferences.category, Conferences.status, Conferences.conferenceDescription from Conferences inner join Users on Conferences.fk_Users = Users.Id where Users.Id = @UserId AND isActive =1", conn);
            SqlParameter prm = cmd.Parameters.AddWithValue("@UserId", user.Id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            DataTable dt = new DataTable();

            conn.Open();
            da.Fill(dt);
            conn.Close();

            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {

            SqlConnection cn = new SqlConnection("Data Source = SERCANDENIZ\\SQLEXPRESS; Initial Catalog = Tez; Integrated Security = True");
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "delete FROM Conferences where Id = @Id";
            cmd.CommandText = "UPDATE Conferences SET isActive = 0 WHERE Id =@Id";
            cmd.Connection = cn;
            cmd.Parameters.AddWithValue("@Id", GridView1.DataKeys[e.RowIndex].Value);
            cn.Open();
            cmd.ExecuteNonQuery();
            //cmd.CommandText = "delete from Conferences_Rewivers where fk_Conferences = @Id";
            //cmd.ExecuteNonQuery();
            //cmd.CommandText = "delete from Topics where fk_Conferences = @Id";
            //cmd.ExecuteNonQuery();
            cn.Close();
            BindGridView();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int confid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            Label lblID = (Label)row.FindControl("lblID");
            //TextBox txtname=(TextBox)gr.cell[].control[];
            //TextBox textId = (TextBox)row.Cells[0].Controls[0];
            TextBox textname = (TextBox)row.Cells[0].Controls[0];
            TextBox textdate = (TextBox)row.Cells[1].Controls[0];
            TextBox textplace = (TextBox)row.Cells[2].Controls[0];
            TextBox textduedate = (TextBox)row.Cells[3].Controls[0];
            TextBox textcategory = (TextBox)row.Cells[4].Controls[0];
            TextBox textstatus = (TextBox)row.Cells[5].Controls[0];
            TextBox textdesc = (TextBox)row.Cells[6].Controls[0];

            //TextBox textadd = (TextBox)row.FindControl("txtadd");
            //TextBox textc = (TextBox)row.FindControl("txtc");
            GridView1.EditIndex = -1;
            conn.Open();
            //SqlCommand cmd = new SqlCommand("SELECT * FROM detail", conn);
            SqlCommand cmd = new SqlCommand("update Conferences set conferenceName='" + textname.Text + "',conferenceDate=convert(datetime, '" + textdate.Text + "', 103),conferencePlace='" + textplace.Text + "',submissionDueDate = convert(datetime, '" + textduedate.Text + "', 103),category = '" + textcategory.Text + "',status = '" + textstatus.Text + "',conferenceDescription = '" + textdesc.Text + "'where Id='" + confid + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            GridView1.DataBind();
            BindGridView();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView();
        }
    }
}

