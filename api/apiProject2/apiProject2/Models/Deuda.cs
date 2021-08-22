using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiProject2.Models
{
    public class Deuda
    {
       public int id { get; set; }
       public string label { get; set; }
       public double amount { get; set; }
       public string description { get; set; }
    }
}