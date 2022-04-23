using DataAccess.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;

namespace DataAccess
{
    public class ApiData
    {
        public List<ItTask> ItTasksApiGet()
        {
            var json = new WebClient().DownloadString("http://www.mocky.io/v2/5d47f24c330000623fa3ebfa");

            return JsonConvert.DeserializeObject<List<ItTask>>(json);
        }
        public List<BusinessTask> BusinessTasksApiGet()
        {
            List<BusinessTask> list = new List<BusinessTask>();
            var json = new WebClient().DownloadString("http://www.mocky.io/v2/5d47f235330000623fa3ebf7");
            var res = JsonConvert.DeserializeObject<List<JObject>>(json);
            for (int i = 0; i < res.Count; i++)
            {
                BusinessTask businessTask = new BusinessTask();
                var item = JObject.Parse(res[i].ToString());
                string business = "Business Task " + i.ToString();
                var deneme = item[business];
                businessTask.Level = Convert.ToInt32(deneme["level"]);
                businessTask.Estimated_Duration = Convert.ToInt32(deneme["estimated_duration"]);
                businessTask.BusinessId = business;
                list.Add(businessTask);
            }
            return list;
        }
    }
}
