namespace Malshinon
{
    class ManagementAlerts : Management
    {

        public ManagementAlerts(DatabaseManagement database) : base(database) { }

        public void AddAlert(int personId, string description)
        {
            Alert alert = Create.CreateAlert(personId, description);
            _dalAlerts.Insert(alert);
        }

        public List<Alert> GetAllAlertsByList()
        {
            return _dalAlerts.GetAllAlerts();
        }

    }

}