using Demo.MVVM.Model;
using System.Collections.ObjectModel;
using System.Linq;
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


        private ObservableCollection<Profil> _profils;

        public ObservableCollection<Profil> Profils
        {
            get { return _profils; }
            set
            {
                _profils = value;
                RaisePropertyChanged(() => Profils);
            }
        }

        #endregion

        #region Commands

        public ICommand ClickOnButtonCommand => new Command<object>(ClickOnButton);

        private void ClickOnButton(object obj)
        {
            Device.BeginInvokeOnMainThread(() => {
                Title = "Clicked!";
                Profils.FirstOrDefault().Name = "Other";
                Profils.Add(
                    new Profil()
                    {
                        Name = "Somebody"
                    }
                );
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

            Profils = new ObservableCollection<Profil>
            {
                new Profil()
                {
                    Name = "Somebody"
                }
            };
        }
    }
}