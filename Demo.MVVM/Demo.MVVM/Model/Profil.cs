using Xamarin.Forms.MVVM.ViewModel.Base;

namespace Demo.MVVM.Model
{
    public class Profil : ExtendedBindableObject
    {
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }
    }
}