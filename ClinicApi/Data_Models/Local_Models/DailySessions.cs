using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicApi.Data_Models.Local_Models
{
    public class DailySessions
    {
        public DateTime Date { get; set; }

        public int Count { get; set; }
    }
}