# Opinionated MVVM For UWP

This repo contains an example project for implementing UWP with goal of making it as easy as possible to unit test and to make unit tests as useful as possible.

To achieve these goals, this project does the following.

- Views (XAML) have no code behind logic.
- View Models have no logic.
- All service code is written in a .Net Standard 2.0 project.

## Avoiding Code-Behind Logic in MVVM

### Problems

Code behind logic invites bad developer practices such as the following.

```CSharp
public sealed partial class MainPage : Page
{
    // If we handle events in the code-behind, we can't test them without running a UWP application.
    private void Button_Click(object sender, RoutedEventArgs e)
    {        
        // Some bad habits that creep into the code behind include:

        // Directly manipulating the data.
        this.DataContext.SomeProperty = "New Value";

        // Using a Singleton or service locator to access a service.
        SomeServiceSingleton.Instance.SomeMethod();

        // Directly modify the state of UI elements.
        SomeUIElement.Visibility = Visibility.Collapsed;
    }
}
```

### Binding to Commands instead of Events

User actions like clicking a button or system events like a page load are by default handled with a corresponding `Button_Click` or `Page_Load` event handling method that can only exist in the code behind of a view.

Instead of using events we can instead bind to Commands on the ViewModel using `Microsoft.Xaml.Interactivity` and `Microsoft.Xaml.Interactions.Core`.

```Xml
<Button Content="Submit">
    <Interactivity:Interaction.Behaviors>
        <Core:EventTriggerBehavior EventName="Click">
            <Core:InvokeCommandAction Command="{Binding SubmitCommand}"/>
        </Core:EventTriggerBehavior>
    </Interactivity:Interaction.Behaviors>
</Button>
```

## Avoiding Logic in View Models

### Problems

View Model arguably should have logic in them that strictly relates to the UI. I find in practice that domain logic seeps in. As well, even stick adheration to view only logic can lead to a bloated view model that is difficult to test.

```CSharp
public class MainPageViewModel : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler PropertyChanged;

	private string _someProperty;
	public string SomeProperty
	{
		get => _someProperty;
		set
		{
			_someProperty = value;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SomeProperty)));
		}
	}

	private Visibility _someUIElementVisibility;
	public Visibility SomeUIElementVisibility
	{
		get => _someUIElementVisibility;
		set
		{
			_someUIElementVisibility = value;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SomeUIElementVisibility)));
		}
	}

	//Commands can sneak domain logic into the view model.
	public ICommand SubmitCommand { get; private set;}

	public MainPageViewModel()
	{
		SubmitCommand = new RelayCommand(Submit);
	}

	private void Submit()
	{
		// Some logic that should be in a service.
		SomeProperty = "New Value";
		SomeServiceSingleton.Instance.SomeMethod();
		SomeUIElementVisibility = Visibility.Collapsed;
	}
}
```

### Move Logic to Services and move the wiring up code to a ViewModel factory.

Instead of having logic in the view model, we can move the logic to a seperate command class and have a view model factory handle wiring up the command.

```CSharp
public MainPageViewModelFactory(
 ISomeService someService) : IMainPageViewModelFactory
{

	public MainPageViewModel Create()
	{
		var vm = new MainPageViewModel();
		vm.SubmitCommand = new SubmitCommand(someService, vm);
		return vm;
	}
}

public class SubmitCommand(
	ISomeService someService,
	MainPageViewModel vm) : ICommand
{
	public void Execute()
	{
		// Some logic that should be in a service.
		vm.SomeProperty = "New Value";
		someService.SomeMethod();
		vm.SomeUIElementVisibility = Visibility.Collapsed;
	}
}

// With all logic removed from the view model, it is now a simple class that only contains properties.
public class MainPageViewModel : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler PropertyChanged;

	private string _someProperty;
	public string SomeProperty
	{
		get => _someProperty;
		set
		{
			_someProperty = value;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SomeProperty)));
		}
	}

	private Visibility _someUIElementVisibility;
	public Visibility SomeUIElementVisibility
	{
		get => _someUIElementVisibility;
		set
		{
			_someUIElementVisibility = value;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SomeUIElementVisibility)));
		}
	}

	public ICommand SubmitCommand { get; set; }
}

```

This pattern leaves us with 2 classes that are easy to test and an anemic view model that requires no testing.

## Running Tests and Getting Code Coverage in UWP projects

### Problems

UWP projects are difficult to test because they require a running UWP application to run tests. This makes it difficult to run tests in a CI/CD pipeline. Additionally, UWP projects do not support code coverage.

### Move all logic to a .Net Standard 2.0 project

Incredibly, .Net Standard 2.0 projects can reference the `Microsoft.Windows.SDK.Contracts` nuget package to have access to the vast majority of UWP APIs. This allows us to move all of our logic to a .Net Standard 2.0 project.

```Xml
<PackageReference Include="Microsoft.Windows.SDK.Contracts" Version="10.0.26100.1">
	<PrivateAssets>all</PrivateAssets>
</PackageReference>
```

Additionally, we can run tests against our .Net Standard 2.0 project by using a .Net Core 3.1 test project that references the `Windows.Foundation.UniversalApiContract.winmd` file in the Windows Kits folder. 

```Xml
<ItemGroup>
<Reference Include="Windows.Foundation.UniversalApiContract">
    <HintPath>C:\Program Files (x86)\Windows Kits\10\References\10.0.22621.0\Windows.Foundation.UniversalApiContract\15.0.0.0\Windows.Foundation.UniversalApiContract.winmd</HintPath>
    <IsWinMDFile>true</IsWinMDFile>
</Reference>
</ItemGroup>
```

Now we can run tests in a .Net Core 3.1 project and get code coverage!

There are of course limitations to this approach. Directly interacting with UI elements is not possible, however this can be worked around by creating wrapper classes for UI elements and passing them to services instead.
