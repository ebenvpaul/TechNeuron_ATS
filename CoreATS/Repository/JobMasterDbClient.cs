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
    public class JobMasterDbClient
    {
        public List<JobMaster> GetAllJobs(string connString)
        {
            return SqlHelper.ExtecuteProcedureReturnData<List<JobMaster>>(connString,
                "sp_GetAllJobs", r => r.TranslateAsJobMasterList());
        }

       
        public CandidatesModel GetJobById(int JobId, string connString)
        
        {
            SqlParameter[] param = {
                       new SqlParameter("@JobId",JobId)
                        };

            return SqlHelper.ExtecuteProcedureReturnData<CandidatesModel>(connString,
                 "sp_GetJob_Id", r => r.TranslateAsCandidate(), param);

                   
        }

        



        public string SaveJob(JobMaster model, string connString)
        {
            var outParam = new SqlParameter("@JobId", SqlDbType.Int, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param = {
               new SqlParameter("@JobTitle",model.JobTitle),
               new SqlParameter("@JobDescription",model.JobDescription),
               new SqlParameter("@IsActive",model.IsActive),
               outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connString, "sp_JobMaster_Insert", param);
            return outParam.Value.ToString();
        }



       

        public string UpdateJob(JobMaster  model, string connString)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param = {
               new SqlParameter("@JobId",model.JobId),
               new SqlParameter("@JobTitle",model.JobTitle),
               new SqlParameter("@JobDescription",model.JobDescription),
               new SqlParameter("@IsActive",model.IsActive),
                outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connString, "sp_JobMaster_Update", param);
            return (string)outParam.Value;
        }


      
        public string DeleteJob(int id,string connString)
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
