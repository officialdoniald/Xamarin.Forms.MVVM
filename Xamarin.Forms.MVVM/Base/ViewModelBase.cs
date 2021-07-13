using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.Forms.MVVM.ViewModel.Base
{
    public class ViewModelBase : ExtendedBindableObject
    {
        #region Properties

        protected INavigation Navigation { get; set; }

        private bool _isNavigationEnabled;

        public bool IsNavigationEnabled
        {
            get
            {
                return _isNavigationEnabled;
            }

            set
            {
                _isNavigationEnabled = value;
                RaisePropertyChanged(() => IsNavigationEnabled);
            }
        }


        private bool _isLoading;

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }

            set
            {
                _isLoading = value;
                RaisePropertyChanged(() => IsLoading);
            }
        }

        #endregion

        #region Commands

        #endregion

        public ViewModelBase() { }

        public virtual Task InitializeAsync(INavigation navigation, params object[] navigationData)
        {
            Navigation = navigation;
            return Task.FromResult(false);
        }

        public virtual async void Navigate(Page page)
        {
            if (IsNavigationEnabled)
            {
                IsNavigationEnabled = false;
                await Navigation.PushAsync(page);
            }
        }
    }
}