namespace UserRegistrationApi.Application.Contract.Response
{
    public class CommandResponse
    {
        public Data Data { get; set; }
        public List<Notification> Notification { get; set; }
    }
    public class Data
    {
        public Status Status { get; set; }
        public string Message { get; set; }
    }
    public class Notification 
    {
        public string Exception { get; set; }
        public string Message { get; set; }
    }
    public enum Status
    {
        Error = 0,
        Sucessed = 1
    }
}
