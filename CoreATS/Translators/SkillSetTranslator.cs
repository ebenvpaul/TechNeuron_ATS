using CoreATS.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CoreATS.Utility;

namespace CoreATS.Translators
{
    public static class SkillSetTranslator
    {
        public static SkillSet TranslateAsSkillSet(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
                               
            var item = new SkillSet();
         
            if (reader.IsColumnExists("SkillId"))
                item.SkillId = SqlHelper.GetNullableInt32(reader, "SkillId");
          
            if (reader.IsColumnExists("JobId"))
                item.JobId = SqlHelper.GetNullableInt32(reader, "JobId");

            if (reader.IsColumnExists("SkillTitle"))
                item.SkillTitle = SqlHelper.GetNullableString(reader, "SkillTitle");

            if (reader.IsColumnExists("SkillDesc"))
                item.SkillDesc = SqlHelper.GetNullableString(reader, "SkillDesc");


            if (reader.IsColumnExists("IsActive"))
                item.IsActive = SqlHelper.GetBoolean(reader, "IsActive");


            if (reader.IsColumnExists("IsMandatory"))
                item.IsMandatory = SqlHelper.GetBoolean(reader, "IsMandatory");


            if (reader.IsColumnExists("CreatedDate"))
                item.CreatedDate = SqlHelper.GetNullableDate(reader, "CreatedDate");

            if (reader.IsColumnExists("RankingId"))
                item.RankingId = SqlHelper.GetNullableInt32(reader, "RankingId");

            return item;
        }

        public static List<SkillSet> TranslateAsSkillSetList(this SqlDataReader reader)
        {
            var list = new List<SkillSet>();
            while (reader.Read())
            {
                list.Add(TranslateAsSkillSet(reader, true));
            }
            return list;
        }
    }
}
