namespace ATS.Domain.Entities
{
    public class Candidate
    {
        public int IdCandidate { get; private set; }
        public string Name { get; private set; }
        public DateTime Birthdate { get; private set; }
        public string Email { get; private set; }
        public DateTime InsertDate { get; private set; }
        public DateTime ModifyDate { get; private set; }

        private readonly List<CandidateExperience> _experiences = new();
        public IReadOnlyCollection<CandidateExperience> Experiences => _experiences;

        protected Candidate() { }

        public Candidate(string name, DateTime birthdate, DateTime insertDate, string email = "")
        {
            Name = name;
            Birthdate = birthdate;
            Email = email;
            InsertDate = insertDate;
        }

        public void Update(string name, DateTime birthdate, DateTime modifyDate, List<CandidateExperience> experiences, string email = "")
        {
            Name = name;
            Birthdate = birthdate;
            Email = email;
            ModifyDate = modifyDate;

            var experienceToDelete = _experiences
                .Where(e => !experiences.Any(n => n.IdCandidateExperience == e.IdCandidateExperience))
                .ToList();

            experienceToDelete.ForEach(e => _experiences.Remove(e));

            var newExperiences = experiences
                .Where(e => e.IdCandidateExperience == 0)
                .ToList();

            foreach (var e in newExperiences)
            {
                AddExperience(IdCandidate, e.Company, e.Job, e.Description, e.Salary, e.BeginDate, e.EndDate, DateTime.Now, e.ModifyDate);
            }

            var experiencesToUpdate = experiences
                .Where(e => _experiences.Any(n => n.IdCandidateExperience == e.IdCandidateExperience))
                .ToList();

            foreach (var e in experiencesToUpdate)
            {
                var original = _experiences.First(n => n.IdCandidateExperience == e.IdCandidateExperience);
                original.UpdateFrom(e);
            }
        }

        public void AddExperience(int idCandidate, string company, string job, string description, decimal salary, DateTime beginDate, DateTime endDate, DateTime insertDate, DateTime modifyDate)
        {
            _experiences.Add(new CandidateExperience(idCandidate, 0, company, job, beginDate, endDate, insertDate, modifyDate, description, salary));
        }

        public void RemoveExperience(int idCandidateExperience)
        {
            var exp = _experiences.FirstOrDefault(e => e.IdCandidateExperience == idCandidateExperience);
            if (exp != null) _experiences.Remove(exp);
        }
    }
}
