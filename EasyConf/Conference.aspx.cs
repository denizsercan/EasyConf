using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

using System.Data;

using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;

namespace finalProject
{
    public partial class Conference : System.Web.UI.Page
    {
        internal User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            CalendarExtender1.StartDate = DateTime.Now;
            CalendarExtender2.StartDate = DateTime.Now;

            if(Session["user"] != null)
            {
                user = Session["user"] as User;
                
            }
            else
            {
                pnlgiris.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                          "alert('Kullanıcı girisi yapınız'); window.location='" +
                          Request.ApplicationPath + "home.aspx';", true);
            }
          
        }


        protected void btn_ConfYarat(object sender, EventArgs e)
        {
            if(txtKonferansAdi.Text != "" && txt_Konferanstarihi.Text != "" && txtKategori.Text != "" && txtKonferansYeri.Text != "" && txt_Duedate.Text != "" && txt_Description.Text != "")
            {
                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);

                if(Session["user"] != null)
                {
                    user = Session["user"] as User;
                }

                cnn.Open();



                String sorgu = "Insert into Conferences (conferenceName, conferenceDate, conferencePlace, submissionDuedate, conferenceDescription , category, status, fk_Users, isActive)"
                                               + "Values(@conferenceName, @conferenceDate, @conferencePlace, @submissionDuedate, @conferenceDescription, @category, 1, (Select Id From Users Where Id = @Id),1)";

                //   String sorgu = "Insert into Conferences (conferenceName, conferenceDate, conferencePlace, submissionDuedate, conferenceDescription , category, status, fk_Users) Values (@conferenceName, @conferenceDate, @conferencePlace, @submissionDuedate, @conferenceDescription, @category, 1, )";


                SqlCommand cmd = new SqlCommand(sorgu, cnn);

                try
                {

                    cmd.Parameters.AddWithValue("@conferenceName", txtKonferansAdi.Text);
                    cmd.Parameters.AddWithValue("@conferenceDate", txt_Konferanstarihi.Text);
                    cmd.Parameters.AddWithValue("@conferencePlace", txtKonferansYeri.Text);
                    cmd.Parameters.AddWithValue("@submissionDuedate", txt_Duedate.Text);
                    cmd.Parameters.AddWithValue("@conferenceDescription", txt_Description.Text);
                    cmd.Parameters.AddWithValue("@category", txtKategori.Text);
                    cmd.Parameters.AddWithValue("@Id", user.Id);


                    cmd.ExecuteNonQuery();

                    cnn.Close();

                    ExtractTopics(txtKonular.Text, txtKonferansAdi.Text);

                    ExtractEmails(txtRewivers.Text, txtKonferansAdi.Text);

                    //   lblSonuc.Text = "Konferans yaratıldı!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
               "alert('Konferans yaratıldı!'); window.location='" +
               Request.ApplicationPath + "home.aspx';", true);
                }

                catch(Exception)
                {

                    lblSonuc.Text = "Konferans yaratılamadı!";

                }

            }

            else { lblSonuc.Text = "Boş Alanları Doldurunuz."; }



        }



        public static void ExtractEmails(string emails, string confname)
        {

            Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
                RegexOptions.IgnoreCase);
            //find items that matches with our pattern
            MatchCollection emailMatches = emailRegex.Matches(emails);



            foreach(Match emailMatch in emailMatches)
            {
                SendActivationEmail(emailMatch.Value, confname);

            }


        }

        public static void ExtractTopics(string topics, string confname)
        {

            string[] separators = { ",", "." };
            string[] words = topics.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach(var word in words)
            {

                addConfTopics(word.ToString(), confname);

            }


        }

        private static void addConfTopics(String topic, String confName)
        {

            string connection = ConfigurationManager.ConnectionStrings[0].ConnectionString;


            using(SqlConnection con = new SqlConnection(connection))
            {
                using(SqlCommand cmd = new SqlCommand("Insert into Topics (topic, fk_Conferences) Values(@topic, (Select Id From Conferences Where conferenceName = @confname)) "))
                {
                    using(SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@topic", topic);
                        cmd.Parameters.AddWithValue("@confname", confName);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }


        }






        private static void SendActivationEmail(String email, String confname)
        {
            string constr = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            string password = Guid.NewGuid().ToString();


            using(SqlConnection con = new SqlConnection(constr))
            {
                con.Open();

                // 1.  create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("SP_RewiverEkle", con);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@reviwerEmail", email));
                cmd.Parameters.Add(new SqlParameter("@reviwerPassword", password));
                cmd.Parameters.Add(new SqlParameter("@conferenceName", confname));

                cmd.ExecuteNonQuery();
                con.Close();

            }
            using(MailMessage mm = new MailMessage("easyconftr@gmail.com", email))
            {
                mm.Subject = "EasyConf Rewiver Request";
                string body = "Merhaba ,";
                body += "<br /><br />Kullanıcı Adınız: " + email;
                body += "<br /><br />Şifreniz: " + password;
                body += "<br /><a href=" + "http://localhost:50300/RewiverLogin.aspx" + ">Buraya Tıklayınız</a>";
                body += "<br /><br />Teşekkürler";
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("easyconftr@gmail.com", "izmir2016");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
        }



    }
}
