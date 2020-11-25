using Demo.MVVM.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.MVVM.ViewModel.Base;
using Xamarin.Forms.Xaml;

namespace Demo.MVVM.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainPageViewModel();

            ((ViewModelBase)BindingContext).InitializeAsync(Navigation);
        }
    }
}