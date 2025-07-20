namespace WX.Services.API.Interfaces
{
    public interface IAPISender
    {
        public string BaseURL { get; set; }
        public string CombinedURL { get; set; }

        public Task<string> Send();
        public void RegisterParameter(string parameterName, string parameterValue);
        public void UnregisterParameters();
    }
}
