namespace Malshinon
{
    class AnalysisHandling : HandlingBase
    {
        public AnalysisHandling(DatabaseManagement database) : base(database) {}

        public void Analysis(int personID, int targetId, DateTime data)
        {
            int averageLength = managementIntel.AverageLengthReports(personID);
            int numberReportsByReporter = managementIntel.NumberReportsByReporter(personID);
            int numberReportsByTarget = managementIntel.NumberReportsByTarget(targetId);
            int numberReportsByTime = managementIntel.NumberReportsByTime(data, targetId);

            AnalyzeMessageLength(personID, averageLength);
            AnalyzeReporterActivity(personID, numberReportsByReporter);
            AnalyzeTargetReports(targetId, numberReportsByTarget);
            AnalyzeTimeBasedReports(targetId, numberReportsByTime);

            UpdatePotentialAgentStatus(personID, averageLength, numberReportsByReporter);
            UpdateTargetRiskStatus(targetId, numberReportsByTarget, numberReportsByTime);

            Console.WriteLine($"Analysis complete for Person ID: {personID} and Target ID: {targetId}");
        }

        private void AnalyzeMessageLength(int personID, int averageLength)
        {
            if (averageLength >= 100)
                managementAlerts.AddAlert(personID, "High message length detected.");
        }

        private void AnalyzeReporterActivity(int personID, int numberReportsByReporter)
        {
            if (numberReportsByReporter >= 10)
                managementAlerts.AddAlert(personID, "High activity detected from this reporter.");
        }

        private void AnalyzeTargetReports(int targetId, int numberReportsByTarget)
        {
            if (numberReportsByTarget >= 20)
                managementAlerts.AddAlert(targetId, "High number of reports detected for this target.");
        }

        private void AnalyzeTimeBasedReports(int targetId, int numberReportsByTime)
        {
            if (numberReportsByTime >= 5)
                managementAlerts.AddAlert(targetId, "Multiple reports received within a short time frame.");
        }

        private void UpdatePotentialAgentStatus(int personID, int averageLength, int numberReportsByReporter)
        {
            if (averageLength >= 100 && numberReportsByReporter >= 10)
            {
                PersonStatus? personStatus = managementPerson._dalPeopleStatus.GetPersonStatusById(personID);
                if (personStatus?.PotentialAgent == 0)
                {
                    managementPeopleStatus.UpdatePotentialAgent(personID, 1);
                    managementAlerts.AddAlert(personID, "Potential agent status updated based on message analysis.");
                    Console.WriteLine($" >===>> >===>> Potential agent status updated for Person ID: {personID} based on message analysis. Number of reports: {numberReportsByReporter}.");
                }
            }
            else
            {
                managementPeopleStatus.UpdatePotentialAgent(personID, 0);
            }
        }

        private void UpdateTargetRiskStatus(int targetId, int numberReportsByTarget, int numberReportsByTime)
        {
            if (numberReportsByTarget >= 20 && numberReportsByTime >= 5)
            {
                PersonStatus? targetStatus = managementPerson._dalPeopleStatus.GetPersonStatusById(targetId);
                if (targetStatus?.TargetRisk == 0)
                {
                    managementPeopleStatus.UpdateTargetRisk(targetId, 1);
                    managementAlerts.AddAlert(targetId, "Target risk status updated based on message analysis.");
                    Console.WriteLine($"  >===>> >===>> Target risk status updated for Target ID: {targetId} based on message analysis. Number of reports: {numberReportsByTarget}.");
                }
            }
            else
            {
                managementPeopleStatus.UpdateTargetRisk(targetId, 0);
            }
        }
    }
}
