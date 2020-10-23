using CoreATS.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CoreATS.Utility;

namespace CoreATS.Translators
{
    public static class CandidateTranslator
    {
        public static CandidatesModel TranslateAsCandidate(this SqlDataReader reader,bool isList = false)
        {
            if(!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new CandidatesModel();

            if (reader.IsColumnExists("CandidateGuid"))
                item.CandidateGuid = SqlHelper.GetNullableString(reader, "CandidateGuid");

            if (reader.IsColumnExists("CandidateId"))
                item.CandidateId = SqlHelper.GetNullableInt32(reader, "CandidateId");



            if (reader.IsColumnExists("Name"))
                item.Name = SqlHelper.GetNullableString(reader, "Name");


            if (reader.IsColumnExists("Age"))
                item.Age = SqlHelper.GetNullableInt32(reader, "Age");

            if (reader.IsColumnExists("DOB"))
                item.DOB = SqlHelper.GetNullableDate(reader, "DOB");

            

            if (reader.IsColumnExists("Qualification"))
                item.Qualification = SqlHelper.GetNullableString(reader, "Qualification");

            if (reader.IsColumnExists("AppliedJobId"))
                item.AppliedJobId = SqlHelper.GetNullableInt32(reader, "AppliedJobId");


            if (reader.IsColumnExists("CreatedDate"))
                item.CreatedDate = SqlHelper.GetNullableDate(reader, "CreatedDate");

            if (reader.IsColumnExists("IsActive"))
                item.IsActive = SqlHelper.GetBoolean(reader, "IsActive");


            if (reader.IsColumnExists("StatusId"))
                item.StatusId = SqlHelper.GetNullableInt32(reader, "StatusId");


            if (reader.IsColumnExists("MobileNo"))
                item.MobileNo = SqlHelper.GetNullableString(reader, "MobileNo");



            if (reader.IsColumnExists("EmailId"))
                item.EmailId = SqlHelper.GetNullableString(reader, "EmailId");


            if (reader.IsColumnExists("CandidateDetailGuid"))
                item.CandidateDetailGuid = SqlHelper.GetNullableString(reader, "CandidateDetailGuid");


            if (reader.IsColumnExists("SkillId"))
                item.SkillId = SqlHelper.GetNullableInt32(reader, "SkillId");


            if (reader.IsColumnExists("RankingId"))
                item.RankingId = SqlHelper.GetNullableInt32(reader, "RankingId");


            if (reader.IsColumnExists("RankingScore"))
                item.RankingScore = SqlHelper.GetNullableInt32(reader, "RankingScore");

            if (reader.IsColumnExists("CVFileLocation"))
                item.CVFileLocation = SqlHelper.GetNullableString(reader, "CVFileLocation");


            return item;
        }

        public static List<CandidatesModel> TranslateAsCandidatesList(this SqlDataReader reader)
        {
            var list = new List<CandidatesModel>();
            while(reader.Read())
            {
                list.Add(TranslateAsCandidate(reader, true));
            }
            return list;
        }
    }
}
