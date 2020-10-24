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
        public List<Rank> GetAllRanks(string connString)
        {
            return SqlHelper.ExtecuteProcedureReturnData<List<Rank>>(connString,
                "sp_GetAllRank", r => r.TranslateAsRankList());
        }

       
        public Rank GetRankById(int RankingId, string connString)
        
        {
            SqlParameter[] param = {
                       new SqlParameter("@RankingId",RankingId)
                        };

            return SqlHelper.ExtecuteProcedureReturnData<Rank>(connString,
                 "sp_GetRank_Id", r => r.TranslateAsRanks(), param);

                   
        }

        



        public string SaveRank(Rank model, string connString)
        {
            var outParam = new SqlParameter("@RankingId", SqlDbType.Int, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param = {
              new SqlParameter("@RankingTitle",model.RankingTitle),
               new SqlParameter("@RankingDesc",model.RankingDesc),
               new SqlParameter("@MinRank",model.MinRank),
               new SqlParameter("@MaxRank",model.MaxRank),
               new SqlParameter("@IsActive",model.IsActive),
               outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connString, "sp_Rank_Insert", param);
            return outParam.Value.ToString();
        }



       

        public string UpdateRank(Rank model, string connString)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param = {
               new SqlParameter("@RankingTitle",model.RankingTitle),
               new SqlParameter("@RankingDesc",model.RankingDesc),
               new SqlParameter("@MinRank",model.MinRank),
               new SqlParameter("@MaxRank",model.MaxRank),
               new SqlParameter("@IsActive",model.IsActive),
               new SqlParameter("@RankingId",model.RankingId),
               outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connString, "sp_Rank_Update", param);
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
