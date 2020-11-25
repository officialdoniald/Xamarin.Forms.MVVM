using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.MVVM.ViewModel.Base;

namespace Demo.MVVM.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Properties

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged(() => Title);
            }
        }

        #endregion

        #region Commands

        public ICommand ClickOnButtonCommand => new Command<object>(ClickOnButton);

        private void ClickOnButton(object obj)
        {
            Device.BeginInvokeOnMainThread(() => {
                Title = "Clicked!";
            });
        }

        #endregion

        public MainPageViewModel()
        {

        }

        public override async Task InitializeAsync(INavigation navigation, params object[] navigationData)
        {
            await base.InitializeAsync(navigation, navigationData);

            Navigation = navigation;

            Title = "Hello, Xamarin.Forms.MVVM!";
        }
    }
}