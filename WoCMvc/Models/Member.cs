using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoCMvc.Models
{
    public class Member
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Ethnicity { get; set; }
        public string Education { get; set; }
        public string ResumeID { get; set; }
        public List<Skill> SkillSet { get; set; }
    }
}
