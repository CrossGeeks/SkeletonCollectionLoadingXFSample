using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using StateLayoutSample.Models;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace StateLayoutSample
{
    public class MainViewModel: INotifyPropertyChanged
	{
		public ObservableRangeCollection<User> Users { get; private set; } 
		LayoutState _currentState = LayoutState.Loading;
		bool _isLoadingMore;
		int _itemThreshold = 10;

		public LayoutState CurrentState
		{
			set
			{
				if (_currentState != value)
				{
					_currentState = value;
					OnPropertyChanged(nameof(CurrentState));
				}
			}
			get => _currentState;
		}

		public bool IsLoadingMore
		{
			set
			{
				if (_isLoadingMore != value)
				{
					_isLoadingMore = value;
					OnPropertyChanged(nameof(IsLoadingMore));
				}
			}
			get => _isLoadingMore;
		}

		public int ItemThreshold
		{
			set
			{
				if (_itemThreshold != value)
				{
					_itemThreshold = value;
					OnPropertyChanged(nameof(ItemThreshold));
				}
			}
			get => _itemThreshold;
		}

		public ICommand LoadDataCommand { get; }
		public ICommand LoadMoreCommand { get; }

		public MainViewModel()
		{
			LoadDataCommand = new Command(async () =>
			{
				CurrentState = LayoutState.Loading;

				await Task.Delay(2000);

				Users = new ObservableRangeCollection<User>()
				{
					new User("Lori Larson", "https://randomuser.me/api/portraits/women/75.jpg", "(950)-753-0140", "jeanette.lewis@example.com"),
					new User("Dennis Lambert", "https://randomuser.me/api/portraits/men/90.jpg", "(950)-753-0140", "Dennis.Lambert@example.com"),
					new User("Chad Willis", "https://randomuser.me/api/portraits/men/6.jpg", "(950)-753-0140", "Chad.Willis@example.com"),
					new User("Jeanette Lewis", "https://randomuser.me/api/portraits/women/48.jpg", "(950)-753-0140", "Jeanette.Willis@example.com"),
					new User("Lori Larson", "https://randomuser.me/api/portraits/women/75.jpg", "(950)-753-0140", "jeanette.lewis@example.com"),
					new User("Dennis Lambert", "https://randomuser.me/api/portraits/men/90.jpg", "(950)-753-0140", "Dennis.Lambert@example.com"),
					new User("Chad Willis", "https://randomuser.me/api/portraits/men/6.jpg", "(950)-753-0140", "Chad.Willis@example.com"),
					new User("Jeanette Lewis", "https://randomuser.me/api/portraits/women/48.jpg", "(950)-753-0140", "Jeanette.Willis@example.com")
				};

				CurrentState = LayoutState.None;
			});

			LoadMoreCommand = new Command(async () =>
			{
                if (IsLoadingMore)
					return;

				
				IsLoadingMore = true;

				await Task.Delay(200000);

				Users.Add(new User("Lori Larson", "https://randomuser.me/api/portraits/women/75.jpg", "(950)-753-0140", "jeanette.lewis@example.com"));
				Users.Add(new User("Lori Larson", "https://randomuser.me/api/portraits/women/75.jpg", "(950)-753-0140", "jeanette.lewis@example.com"));
				Users.Add(new User("Lori Larson", "https://randomuser.me/api/portraits/women/75.jpg", "(950)-753-0140", "jeanette.lewis@example.com"));
				Users.Add(new User("Lori Larson", "https://randomuser.me/api/portraits/women/75.jpg", "(950)-753-0140", "jeanette.lewis@example.com"));
				Users.Add(new User("Lori Larson", "https://randomuser.me/api/portraits/women/75.jpg", "(950)-753-0140", "jeanette.lewis@example.com"));
				Users.Add(new User("Lori Larson", "https://randomuser.me/api/portraits/women/75.jpg", "(950)-753-0140", "jeanette.lewis@example.com"));

				if(Users.Count > 30)
                {
					ItemThreshold = -1;
				}

				IsLoadingMore = false;
			});

			LoadDataCommand.Execute(null);
		}


		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}