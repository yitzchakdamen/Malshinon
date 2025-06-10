namespace Malshinon
{
    public class PersonStatus
    {
        public int PeopleId { get; set; }
        public int NumReports { get; set; } = 0;
        public int NumMentions { get; set; } = 0;
        public bool Reporter { get; set; } = false;
        public bool Target { get; set; } = false;
        public int PotentialAgent { get; set; } = 0;
        public int TargetRisk { get; set; } = 0;
    }

}