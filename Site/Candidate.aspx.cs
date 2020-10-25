using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechNeuron_ATS.App_Code;
using TechNeuron_ATS.Model;
namespace TechNeuron_ATS.Site
{
    public partial class Candidate : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                InitPage();
            }

        }
        protected void InitPage()
        {

            InitCmb();
            txtDOB.Text = DateTime.Now.Year.ToString();
        }



        protected void InitCmb()
        {
            InitddlJob();
            InitddlSkill();

        }

        protected void InitddlJob()
        {
            var str_JobMaster = "";
            try
            {
                DbController ObjMain = new DbController();
                str_JobMaster = ObjMain.GetJobs();
                var myDeserializedClass2 = JsonConvert.DeserializeObject<List<JobMaster>>(str_JobMaster);
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


        protected void InitddlSkill()
        {
            var str_GetSkillSet = "";
            try
            {
                DbController ObjMain = new DbController();
                str_GetSkillSet = ObjMain.GetSkillSet();
                var myDeserializedClass2 = JsonConvert.DeserializeObject<List<SkillSets>>(str_GetSkillSet);
                Session["SkillSetList"] = myDeserializedClass2;
                foreach (SkillSets p in myDeserializedClass2)
                {
                    ListItem item = new ListItem(p.SkillTitle, p.SkillId.ToString());
                    ddlSkills.Items.Add(item);
                }
                ddlSkills.DataBind();
                GetRanking();
                ddlSkills_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {

            }

        }



        protected void GetRanking()
        {
            var str_GetRanking = "";
            try
            {
                DbController ObjMain = new DbController();
                str_GetRanking = ObjMain.GetRanks();
                var myDeserializedClass2 = JsonConvert.DeserializeObject<List<Rank>>(str_GetRanking);
                Session["RankingList"] = myDeserializedClass2;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {

            }

        }



        protected void ddlSkills_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetRankDetails();

        }
        protected void GetRankDetails()
        {

            int SelectedSkillId = 0;
            var SelectedSkill = String.Empty;

            SelectedSkillId = Int32.Parse(ddlSkills.SelectedValue);
            SelectedSkill = ddlSkills.SelectedItem.Text.ToString();
            try
            {
                List<SkillSets> SkillSetList = new List<SkillSets>();
                List<Rank> RankList = new List<Rank>();
                if (Session["SkillSetList"] != null)
                    SkillSetList = Session["SkillSetList"] as List<SkillSets>;

                var SelectedSkills = SkillSetList.Where(skill => skill.SkillId == SelectedSkillId);
                var RankingIdForSkill = SelectedSkills.First().RankingId;

                if (Session["RankingList"] != null)
                    RankList = Session["RankingList"] as List<Rank>;

                var SelectedRank = RankList.Where(rank => rank.RankingId == RankingIdForSkill);
                var MinRankingScore = SelectedRank.First().MinRank;
                var MaxRankingScore = SelectedRank.First().MaxRank;
                HFMinValue.Value = MinRankingScore.ToString();
                HFMaxValue.Value = MaxRankingScore.ToString();
                txtRatingScore.Text = MinRankingScore.ToString() + " - " + MaxRankingScore.ToString();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddGridRow(ddlSkills.SelectedItem.Text, ddlSkills.SelectedValue, txtRating.Text);
        }



        private void AddGridRow(string SelectedSkill, string SelectedSkillId, string Rating)
        {
            try
            {
                int Rateing = Int32.Parse(txtRating.Text);
                int MinRank = Int32.Parse(HFMinValue.Value);
                int MaxRank = Int32.Parse(HFMaxValue.Value);
                if (MinRank > Rateing || Rateing > MaxRank)
                {

                    ERR_MSG(Rateing + " Rating Score Invalid", true);
                    return;
                }

                foreach (GridViewRow dgRow in GVSkillSet.Rows)
                {
                    var cell = dgRow.Cells[1];
                    if (cell.Text == SelectedSkillId)   //Check for null reference
                    {
                        ERR_MSG("SkillSet Already Exists", true);
                        return;
                    }
                }


                DataTable dt = new DataTable();



                dt.Columns.Add("Skill");
                dt.Columns.Add("SkillId");
                dt.Columns.Add("Rating");

                if (Session["GVSkillSet"] != null)
                {

                    dt = (DataTable)Session["GVSkillSet"];
                }

                DataRow dr = dt.NewRow();
                dr["Skill"] = SelectedSkill;
                dr["SkillId"] = SelectedSkillId;
                dr["Rating"] = Rating;


                dt.Rows.Add(dr);
                GVSkillSet.DataSource = dt;
                GVSkillSet.DataBind();

                Session["GVSkillSet"] = dt;
                ERR_MSG(SelectedSkill + "  Added", false);
            }
            catch (Exception ex)
            {
                ERR_MSG(ex.Message, true);
                Console.WriteLine(ex.Message.ToString());
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





        private bool validateForm()
        {

            try
            {


                if (txtName.Text.Trim() == string.Empty)
                {
                    ERR_MSG("Please enter Name", true);
                    return false; 
                }

              

                if (txtMobileNo.Text.Trim() == string.Empty)
                {
                    ERR_MSG("Please enter Rating", true);
                    return false; 
                }


                if (txtfilelocation.Text.Trim() == string.Empty)
                {
                    ERR_MSG("Please add CV Location", true);
                    return false; 
                }

                if (txtDOB.Text.Trim() == string.Empty)
                {
                    ERR_MSG("Please enter DOB", true);
                    return false;
                }
                //try
                //{
                //    txtDOB.Text = Convert.ToDateTime(txtDOB.Text).ToString("dd-MMM-yyyy");
                //}
                //catch (Exception ex)
                //{
                //    txtDOB.Text = "";
                //    ERR_MSG("Please enter DOB", true);
                //    return false;

                //}

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



        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (validateForm() != true)
            {
                return;
            }
            Guid guid = Guid.NewGuid();
            Random random = new Random();
            int i = random.Next();
            
            
            var reponse = "";
            string DOB = txtDOB.Text;
            DateTime dt = Convert.ToDateTime(DOB);

            try
            {
                var candidate = new CandidatesModel
                {
                    CandidateGuid = "0",
                    CandidateId = i,
                    Name = txtName.Text,
                    Age = CalculateAge(),
                    DOB = dt,
                    Qualification = txtQualification.Text,
                    AppliedJobId = Int32.Parse(ddlSkills.SelectedValue),
                    IsActive = true,
                    StatusId = 1,
                    MobileNo = txtMobileNo.Text,
                    EmailId = txtEmailId.Text
                };
                DbController ObjMain = new DbController();
                reponse = ObjMain.addCandidateMaster(candidate);
                ERR_MSG("Candidate Saved",false);
                initForm();
            }
            catch (Exception ex)
            {
                ERR_MSG(ex.Message);
            }
            

        }

        private void initForm()
        {
            txtName.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtEmailId.Text = string.Empty;
            txtQualification.Text = string.Empty;
        }

        private int CalculateAge()
        {
            try
            {
                var today = DateTime.Today;


                // Calculate the age.
                string DOB = txtDOB.Text;
                DateTime dt = Convert.ToDateTime(DOB);

                //Know the year

                int year = dt.Year;
                var age = today.Year - year;

                return age;


            }
            catch(Exception ex)
            {
                ERR_MSG(ex.Message);
                return 0;
            }
        }

        protected void txtDOB_TextChanged(object sender, EventArgs e)
        {
            int age = CalculateAge();
        }
    }
      
}