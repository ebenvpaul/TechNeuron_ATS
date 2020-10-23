using CoreATS.Model;
using CoreATS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreATS.Translators;
using System.Data.SqlClient;
using System.Data;

namespace CoreATS.Repository
{
    public class RankDbClient
    {
        public List<Rank> GetAllCandidates(string connString)
        {
            return SqlHelper.ExtecuteProcedureReturnData<List<Rank>>(connString,
                "sp_GetAllCandidate", r => r.TranslateAsRankList());
        }

       
        public CandidatesModel GetCandidatesById(int CandidateId, string connString)
        
        {
            SqlParameter[] param = {
                       new SqlParameter("@CandidateId",CandidateId)
                        };

            return SqlHelper.ExtecuteProcedureReturnData<CandidatesModel>(connString,
                 "sp_GetCandidate_Id", r => r.TranslateAsCandidate(), param);

                   
        }

        



        public string SaveCandidateMaster(CandidatesModel model, string connString)
        {
            var outParam = new SqlParameter("@CandidateId", SqlDbType.Int, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param = {
               new SqlParameter("@Name",model.Name),
               new SqlParameter("@Age",model.Age),
               new SqlParameter("@DOB",model.DOB),
               new SqlParameter("@Qualification",model.Qualification),
               new SqlParameter("@AppliedJobId",model.AppliedJobId),
               new SqlParameter("@IsActive",model.IsActive),
               new SqlParameter("@StatusId",model.StatusId),
               new SqlParameter("@MobileNo",model.MobileNo),
               new SqlParameter("@EmailId",model.EmailId),
               outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connString, "sp_CandidateMaster_Insert", param);
            return outParam.Value.ToString();
        }



        public string SaveCandidateDetail(CandidatesModel model, string connString)
        {
            var outParam = new SqlParameter("@CandidateDetailGuid", SqlDbType.NVarChar, 50)
            {
                Direction = ParameterDirection.Output
            };

            SqlParameter[] param = {
               new SqlParameter("@CandidateGuid",model.CandidateGuid),
               new SqlParameter("@CandidateId",model.CandidateId),
               new SqlParameter("@SkillId",model.SkillId),
               new SqlParameter("@RankingId",model.RankingId),
               new SqlParameter("@RankingScore",model.RankingScore),
               new SqlParameter("@CVFileLocation",model.CVFileLocation),
               new SqlParameter("@IsActive",model.IsActive),
               outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connString, "sp_CandidateDetail_Insert", param);
            return outParam.Value.ToString();
        }


        public string UpdateCandidatesMaster(CandidatesModel model, string connString)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param = {
               new SqlParameter("@CandidateId",model.CandidateId),
               new SqlParameter("@Name",model.Name),
               new SqlParameter("@Age",model.Age),
               new SqlParameter("@DOB",model.DOB),
               new SqlParameter("@Qualification",model.Qualification),
               new SqlParameter("@AppliedJobId",model.AppliedJobId),
               new SqlParameter("@IsActive",model.IsActive),
               new SqlParameter("@StatusId",model.StatusId),
               new SqlParameter("@MobileNo",model.MobileNo),
               new SqlParameter("@EmailId",model.EmailId),
                outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connString, "sp_CandidateMaster_Update", param);
            return (string)outParam.Value;
        }


      
        public string DeleteCandidatesMaster(int id,string connString)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param = {
                new SqlParameter("@Id",id),
                outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connString, "DeleteUser", param);
            return (string)outParam.Value;
        }
    }
}
