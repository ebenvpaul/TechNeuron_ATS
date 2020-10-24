using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
        DbController ObjMain = new DbController();
       
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                InitPage();
            }
            
        }
        protected void InitPage() {

            InitCmb();
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

        public Rank[] Filter(Rank[] input,int RankId)
        {
            return input.Where(c => c.RankingId== RankId).ToArray();
        }

        protected void ddlSkills_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            int SkillId = Int32.Parse(ddlSkills.SelectedValue);
           
            try 
                {
                List<SkillSets> SkillSetList = new List<SkillSets>();
                List<Rank> RankList = new List<Rank>();
                if (Session["SkillSetList"] != null)
                    SkillSetList = Session["SkillSetList"] as List<SkillSets>;
                
                var SelectedSkill = SkillSetList.Where(skill => skill.SkillId == SkillId);
                var RankingIdForSkill = SelectedSkill.First().RankingId;

                if (Session["RankingList"] != null)
                    RankList = Session["RankingList"] as List<Rank>;

                var SelectedRank = RankList.Where(rank => rank.RankingId == RankingIdForSkill);
                var MinRankingScore = SelectedRank.First().MinRank;
                var MaxRankingScore = SelectedRank.First().MaxRank;
                txtRatingScore.Text = MinRankingScore.ToString() + " - "+ MaxRankingScore.ToString();


                 }
            catch (Exception ex)
                {
                Console.WriteLine(ex.Message.ToString());
                }

}

        
    }
}