namespace WX
{
    public partial class App : Application
    {
        readonly IServiceProvider _serviceProvider;

        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var rootPage = _serviceProvider.GetRequiredService<RootPage>();
            return new Window(rootPage);
        }
    }
}