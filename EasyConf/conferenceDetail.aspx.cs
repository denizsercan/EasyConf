using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace finalProject
{
    public partial class conferenceDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.KonferansDetayi();

        }


        private void KonferansDetayi()
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);

            string sorgu = "SELECT conferenceName, conferenceDate, conferencePlace, submissionDuedate, conferenceDescription , category, Users.name, Users.surname FROM Conferences inner join Users ON Conferences.fk_Users = Users.Id WHERE Conferences.Id = @confId";

            Object conference = Session["ConfData"];


            cnn.Open();

            SqlCommand cmd = new SqlCommand(sorgu, cnn);

            


            try {

                cmd.Parameters.AddWithValue("@confId", conference.ToString());

                SqlDataReader dr = cmd.ExecuteReader();

                Console.WriteLine(dr);

                if (dr.Read())
                {

                    lblConferenceName.Text = dr.GetString(0);
                    lblConferenceDate.Text = dr.GetDateTime(1).ToString();
                    lblConferencePlace.Text = dr.GetString(2);
                    lblSubmissionDate.Text = dr.GetDateTime(3).ToString();
                    lblDescription.Text = dr.GetString(4);
                    lblCategory.Text = dr.GetString(5);
                    lblOwner.Text = dr.GetString(6) + " " + dr.GetString(7);




                }
                else {

                    lblSonuc.Text = "Olmadı";

                }


                cnn.Close();

            } catch(Exception e) {

                lblSonuc.Text = e.ToString();
            }
            


          
        }

        protected void btn_SubmitPaper(object sender, EventArgs e)
        {
            Response.Redirect("submitPaper.aspx");
        }
    }
}