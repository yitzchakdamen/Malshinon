namespace Malshinon
{
    class ManagementIntel
    {
        DalIntelReports dalIntelReports;
        public ManagementIntel(DatabaseManagement database)
        {
            dalIntelReports = new(database);

        }

        public void AddIntelReports(string text, int personID, int targetId)
        {

        }

        public int NumberReports(int persenId)
        {
            
        }

        
    }
    
}