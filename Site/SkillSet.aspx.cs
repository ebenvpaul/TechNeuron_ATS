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
    public partial class SkillSet : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitPage();
                Loadddl();
            }

        }

        private void InitPage()
        {
            SkillId.Text = string.Empty;
            txtSkillTitle.Text = string.Empty;
            txtSkillDesc.Text = string.Empty;
           
        }

        private void Loadddl()
        {
            Populateddl();
        }
        protected void InitddlJobs()
        {
            var str_GetSkillSet = "";
            try
            {
                DbController ObjMain = new DbController();
                str_GetSkillSet = ObjMain.GetJobs();
                var myDeserializedClass2 = JsonConvert.DeserializeObject<List<JobMaster>>(str_GetSkillSet);
                Session["Jobs"] = myDeserializedClass2;
                foreach (JobMaster p in myDeserializedClass2)
                {
                    ListItem item = new ListItem(p.JobTitle, p.JobId.ToString());
                    ddlJob.Items.Add(item);
                }
                ddlJob.DataBind();
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {

            }

        }


        protected void InitddlRanks()
        {
            var str_GetSkillSet = "";
            try
            {
                DbController ObjMain = new DbController();
                str_GetSkillSet = ObjMain.GetRanks();
                var myDeserializedClass2 = JsonConvert.DeserializeObject<List<Rank>>(str_GetSkillSet);
                Session["Rank"] = myDeserializedClass2;
                foreach (Rank p in myDeserializedClass2)
                {
                    ListItem item = new ListItem(p.RankingTitle, p.RankingId.ToString());
                    ddlRank.Items.Add(item);
                }
                ddlRank.DataBind();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {

            }

        }

        private void Populateddl()
        {
            InitddlJobs();
            InitddlRanks();
            PopulateGridView();


        }




        private void PopulateGridView()
        {
            var str_JobMaster = "";
            try
            {
                DbController ObjMain = new DbController();
                str_JobMaster = ObjMain.GetSkillSet();
                var myDeserializedClass2 = JsonConvert.DeserializeObject<List<SkillSets>>(str_JobMaster);

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

            SkillId.Text = GDJobs.Rows[index].Cells[1].Text;
            txtSkillTitle.Text = GDJobs.Rows[index].Cells[3].Text;
            txtSkillDesc.Text = GDJobs.Rows[index].Cells[4].Text;


            ddlRank.SelectedIndex =
ddlRank.Items.IndexOf(ddlRank.Items.FindByValue(GDJobs.Rows[index].Cells[8].Text));

            ddlJob.SelectedIndex =
ddlJob.Items.IndexOf(ddlJob.Items.FindByValue(GDJobs.Rows[index].Cells[2].Text));

            //ddlRank.Items.FindByValue(GDJobs.Rows[index].Cells[8].Text).Selected = true;

            //ddlJob.Items.FindByText(GDJobs.Rows[index].Cells[2].Text).Selected = true;

           



        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (validateForm() != true)
            {
                return;
            }

            var reponse = "";

            if (SkillId.Text.Trim() == string.Empty)
            {
                try
                {
                    var skill = new SkillSets
                    {
                        SkillId = 0,
                        SkillTitle = txtSkillTitle.Text,
                        SkillDesc = txtSkillDesc.Text,
                        RankingId = Int32.Parse(ddlRank.SelectedValue),
                        JobId = Int32.Parse(ddlJob.SelectedValue),
                        IsActive = true,

                    };
                    DbController ObjMain = new DbController();
                    reponse = ObjMain.addSkill(skill);
                    ERR_MSG("Skills Saved", false);
                    InitPage();
                }
                catch (Exception ex)
                {
                    ERR_MSG(ex.Message);
                }

            }


            if (SkillId.Text.Trim() != string.Empty)
            {
                try
                {
                    var skill = new SkillSets
                    {
                        SkillId = Int32.Parse(SkillId.Text),
                        SkillTitle = txtSkillTitle.Text,
                        SkillDesc = txtSkillDesc.Text,
                        RankingId = Int32.Parse(ddlRank.SelectedValue),
                        JobId = Int32.Parse(ddlJob.SelectedValue),
                        IsActive = true,

                    };
                    DbController ObjMain = new DbController();
                    reponse = ObjMain.UpdateSkill(skill);
                    ERR_MSG("Skills Updated", false);
                    InitPage();
                }
                catch (Exception ex)
                {
                    ERR_MSG(ex.Message);
                }

            }


            PopulateGridView();

        }


        private bool validateForm()
        {

            try
            {


                if (txtSkillTitle.Text.Trim() == string.Empty)
                {
                    ERR_MSG("Please Enter skill Title", true);
                    return false;
                }



                if (txtSkillDesc.Text.Trim() == string.Empty)
                {
                    ERR_MSG("Please Enter skill Desc", true);
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