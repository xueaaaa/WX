namespace WX.Services
{
    public static class ServiceHelper
    {
        public static T GetService<T>()
        {
            var service = IPlatformApplication.Current.Services.GetService<T>();
            return service;
        }
    }
}
