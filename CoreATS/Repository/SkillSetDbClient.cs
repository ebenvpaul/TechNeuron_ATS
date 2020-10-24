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
    public class SkillSetDbClient
    {
        public List<SkillSet> GetAllSkillSet(string connString)
        {
            return SqlHelper.ExtecuteProcedureReturnData<List<SkillSet>>(connString,
                "sp_GetAllSkillSet", r => r.TranslateAsSkillSetList());
        }

       
        public SkillSet GetSkillSetById(int SkillId, string connString)
        
        {
            SqlParameter[] param = {
                       new SqlParameter("@SkillId",SkillId)
                        };

            return SqlHelper.ExtecuteProcedureReturnData<SkillSet>(connString,
                 "sp_GetSkillSet_Id", r => r.TranslateAsSkillSet(), param);

                   
        }

        public string SaveSkillSet(SkillSet model, string connString)
        {
            var outParam = new SqlParameter("@SkillId", SqlDbType.Int, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param = {
               new SqlParameter("@JobId",model.JobId),
               new SqlParameter("@SkillTitle",model.SkillTitle),
               new SqlParameter("@SkillDesc",model.SkillDesc),
               new SqlParameter("@IsActive",model.IsActive),
               new SqlParameter("@IsMandatory",model.IsMandatory),
               new SqlParameter("@RankingId",model.RankingId),
               outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connString, "sp_SkillSet_Insert", param);
            return outParam.Value.ToString();
        }



       


        public string UpdateSkillSet(SkillSet model, string connString)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param = {
               new SqlParameter("@SkillId",model.SkillId),
               new SqlParameter("@JobId",model.JobId),
               new SqlParameter("@SkillTitle",model.SkillTitle),
               new SqlParameter("@SkillDesc",model.SkillDesc),
               new SqlParameter("@IsActive",model.IsActive),
               new SqlParameter("@IsMandatory",model.IsMandatory),
               new SqlParameter("@RankingId",model.RankingId),
                outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connString, "sp_SkillSet_Update", param);
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
