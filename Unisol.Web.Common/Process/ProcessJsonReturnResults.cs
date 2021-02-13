using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Common.Process
{
    public  class ProcessJsonReturnResults<T> 
    {
        public  ReturnData<T> UnisolApiData;

        public  ProcessJsonReturnResults(string result)
        {
            UnisolApiData = JsonConvert.DeserializeObject<ReturnData<T>>(result);
        }
    }
}