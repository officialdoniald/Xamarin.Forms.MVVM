# Xamarin.Forms.MVVM

This Package implement the https://docs.microsoft.com/en-us/xamarin/xamarin-forms/enterprise-application-patterns/dependency-injection TinyIoC Container. => You can use DI in your code.

Naming convention is very important!!!

MVVM:
You have to create the common folders: Model, View and ViewModel.

Model:
Not nessessary to create this folder, but the nice thing would be to make a separate folder for UI models.
If you want to Bind a model's Property, you have to derive your model class from ExtendedBindableObject.

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

If you change the Name Property Runtime, it will change on the UI too. (But first, we have to set up our ViewModel!)

ViewModel:
  1. Create a Folder, name: ViewMdoel.
  2. Create a ViewModel, <YourPageNamePage>ViewModel.
  3. You have to derive your ViewModel from ViewModelBase.
  4. If you want to override the InitializeAsync mehthod, you can do it:
        public override async Task InitializeAsync(INavigation navigation, params object[] navigationData)
        {
            await base.InitializeAsync(navigation, navigationData);

            Navigation = navigation;
        }
  5. You can create Commands and Property for you UI.
  
View:
Let's create your xaml/UI!
  1. Paste two lines into your Page's Code Behind:

  BindingContext = new MainPageViewModel(); //You will set the BindingContext of the Page
  ((ViewModelBase)BindingContext).InitializeAsync(Navigation); // You have to call the InitializedAsync method of the ViewModel
  
  2. In the Xaml code, you have to paste this two lines into the Page's Property section:
  
  xmlns:viewModelBase="clr-namespace:Xamarin.Forms.MVVM.ViewModel.Base;assembly=Xamarin.Forms.MVVM" 
  viewModelBase:ViewModelLocator.AutoWireViewModel="true"
  
  3. You can set the Bindings of the Page:
  
  <Label Text="{Binding Title}"
    VerticalOptions="CenterAndExpand" 
    HorizontalOptions="CenterAndExpand" />
    
  In the Demo.MVVM Project you can find some example, how can you use the MVVM, this NuGet, in you Xamarin.Forms Project.
    -ListView Binding
    -Label's Text Binding
    -Button's Command Binding (and CommandParameter Binding)
