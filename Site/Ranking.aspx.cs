using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechNeuron_ATS.App_Code;
using TechNeuron_ATS.Model;

namespace TechNeuron_ATS.Site
{
    public partial class Ranking : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitPage();
            }

        }

        private void InitPage()
        {
            RankingId.Text = string.Empty;
            txtRankingTitle.Text = string.Empty;
            txtRankingDesc.Text = string.Empty;
            txtMinRank.Text = "0";
            txtMaxRank.Text = "0";
            LoadGVJobs();
        }

        private void LoadGVJobs()
        {
            PopulateGridView();
        }


        private void PopulateGridView()
        {
            var str_JobMaster = "";
            try
            {
                DbController ObjMain = new DbController();
                str_JobMaster = ObjMain.GetRanks();
                var myDeserializedClass2 = JsonConvert.DeserializeObject<List<Rank>>(str_JobMaster);

                GDJobs.DataSource = myDeserializedClass2;
                GDJobs.DataBind();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {

            }

        }

        private void UpdateForm()
        {

        }

        protected void GDJobs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow gvRow = GDJobs.Rows[index];

            RankingId .Text = GDJobs.Rows[index].Cells[1].Text;
            txtRankingTitle.Text = GDJobs.Rows[index].Cells[2].Text;
            txtRankingDesc.Text = GDJobs.Rows[index].Cells[3].Text;
            txtMinRank.Text = GDJobs.Rows[index].Cells[4].Text;
            txtMaxRank.Text = GDJobs.Rows[index].Cells[5].Text;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (validateForm() != true)
            {
                return;
            }

            var reponse = "";

            if (RankingId.Text.Trim() == string.Empty)
            {
                try
                {
                    var rank = new Rank
                    {
                        RankingId = 0,
                        RankingTitle = txtRankingTitle.Text,
                        RankingDesc = txtRankingDesc.Text,
                        MinRank=Int32.Parse(txtMinRank.Text),
                        MaxRank=Int32.Parse(txtMaxRank.Text),
                        IsActive = true,

                    };
                    DbController ObjMain = new DbController();
                    reponse = ObjMain.addRank(rank);
                    ERR_MSG("Rank Saved", false);
                    InitPage();
                }
                catch (Exception ex)
                {
                    ERR_MSG(ex.Message);
                }

            }


            if (RankingId.Text.Trim() != string.Empty)
            {
                try
                {
                    var rank = new Rank
                    {
                        RankingId =Int32.Parse(RankingId.Text),
                        RankingTitle = txtRankingTitle.Text,
                        RankingDesc = txtRankingDesc.Text,
                        MinRank = Int32.Parse(txtMinRank.Text),
                        MaxRank = Int32.Parse(txtMaxRank.Text),
                        IsActive = true,

                    };
                    DbController ObjMain = new DbController();
                    reponse = ObjMain.UpdateRank(rank);
                    ERR_MSG("Rank Updated", false);
                    InitPage();
                }
                catch (Exception ex)
                {
                    ERR_MSG(ex.Message);
                }

            }

            LoadGVJobs();


        }


        private bool validateForm()
        {

            try
            {


                if (txtRankingTitle.Text.Trim() == string.Empty)
                {
                    ERR_MSG("Please Enter Rank Title", true);
                    return false;
                }



                if (txtRankingDesc.Text.Trim() == string.Empty)
                {
                    ERR_MSG("Please Enter Rank Desc", true);
                    return false;
                }

                //if (txtMinRank.Text.Trim() == "0")
                //{
                //    ERR_MSG("Please Enter Min Rank", true);
                //    return false;
                //}

                if (txtMaxRank.Text.Trim() == "0")
                {
                    ERR_MSG("Please Enter Max Rank", true);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                ERR_MSG(ex.Message);
                return false;
            }
            finally
            {

            }
        }





        private void ERR_MSG(string strErr, bool isError = true)
        {
            try
            {

                if (!isError)
                {

                    AlertifySuccess(strErr);
                }
                else
                    AlertifyError(strErr);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }


        public void AlertifyError(string strErr)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script language='javascript'>");
            sb.Append("alertifyError('" + strErr + "');");
            sb.Append("</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", sb.ToString(), false);
        }

        public void AlertifySuccess(string strErr)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script language='javascript'>");
            sb.Append("alertifySuccess('" + strErr + "');");
            sb.Append("</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", sb.ToString(), false);
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            InitPage();
        }
    }
}