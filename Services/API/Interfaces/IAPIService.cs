namespace WX.Services.API.Interfaces
{
    public interface IAPIService<TDataObject> where TDataObject : class
    {
        public string BaseURL { get; set; }
        public string CombinedURL { get; set; }

        public void SetDefaultParameters();
        public Task<IEnumerable<TDataObject>> FetchData();
        public void RegisterParameter(string parameterName, string parameterValue);
        public void UnregisterParameters();
    }
}
