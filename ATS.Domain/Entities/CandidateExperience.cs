using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Domain.Entities
{
    public class CandidateExperience
    {
        public int IdCandidateExperience { get; private set; }
        public int IdCandidate { get; private set; }
        public string Company { get; private set; } = string.Empty;
        public string Job { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public decimal Salary { get; private set; }
        public DateTime BeginDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public DateTime InsertDate { get; private set; }
        public DateTime ModifyDate { get; private set; }

        public virtual Candidate Candidate { get; private set; }

        protected CandidateExperience() { }

        public CandidateExperience(int idCandidate,
                                   int idCandidateExperience, 
                                   string company,
                                   string job,
                                   DateTime beginDate,
                                   DateTime endDate,
                                   DateTime insertDate,
                                   DateTime modifyDate,
                                   string description = "",
                                   decimal salary = 0)
        {
            IdCandidate = idCandidate;
            IdCandidateExperience = idCandidateExperience;
            Company = company;
            Job = job;
            Description = description;
            Salary = salary;
            BeginDate = beginDate;
            EndDate = endDate;
            InsertDate = insertDate;
            ModifyDate = modifyDate;
        }

        public void UpdateFrom(CandidateExperience experience)
        {
            Company = experience.Company;
            Job = experience.Job;
            Description = experience.Description;
            Salary = experience.Salary;
            BeginDate = experience.BeginDate;
            EndDate = experience.EndDate;
            InsertDate = experience.InsertDate;
            ModifyDate = DateTime.Now;
        }
    }
}
