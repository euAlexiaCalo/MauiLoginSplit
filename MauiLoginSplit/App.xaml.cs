namespace MauiLoginSplit
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);
            window.Width = 1100;
            window.Height = 700;

            window.MinimumWidth = 900;
            window.MinimumHeight = 600;

            return window;
        }
    }
}