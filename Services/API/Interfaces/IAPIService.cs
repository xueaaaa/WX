namespace WX.Services.API.Interfaces
{
    public interface IAPIService<T> where T : class
    {
        public string BaseURL { get; set; }
        public string CombinedURL { get; set; }

        public void SetDefaultParameters();
        public Task<IEnumerable<T>> FetchData();
        public void RegisterParameter(string parameterName, string parameterValue);
        public void UnregisterParameters();
    }
}
