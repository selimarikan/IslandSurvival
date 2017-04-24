using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace IslandSurvivalGUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new IslandSurvivalVM();
            VM.NotificationCommand = new RelayCommand<object>((o) => ShowNotification((string)o));
        }
         
        private void MessagesPanel_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            VM.MessageCounter++;
            VM.ElapsedHours++;
        }

        public IslandSurvivalVM VM => DataContext as IslandSurvivalVM;

        public string NotificationMessage
        {
            get { return (string)GetValue(NotificationMessageProperty); }
            set { SetValue(NotificationMessageProperty, value); }
        }
        public static readonly DependencyProperty NotificationMessageProperty =
            DependencyProperty.Register("NotificationMessage", typeof(string), typeof(MainWindow), new PropertyMetadata(string.Empty));

        public void ShowNotification(string message)
        {
            NotificationMessage = message;
            NotificationTB.Visibility = Visibility.Visible;

            var t = Task.Factory.StartNew(() =>
            {
                System.Threading.Thread.Sleep(2000);  
            }).ContinueWith(prevTask =>
            {
                NotificationTB.Visibility = Visibility.Collapsed;
                NotificationMessage = string.Empty;
            }, TaskScheduler.FromCurrentSynchronizationContext());

        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            VM.MessageCounter++;
        }

        private void TheButton_OnClick(object sender, RoutedEventArgs e)
        {
            VM.TheButtonCommand?.Execute(null);
        }

        private void ButtonChopWood_OnClick(object sender, RoutedEventArgs e)
        {
            VM.GatherWoodCommand.Execute(null);
        }

        private void ButtonBuildCot_OnClick(object sender, RoutedEventArgs e)
        {
            VM.BuildCotCommand.Execute(null);
        }

        private void ButtonGatherStone_OnClick(object sender, RoutedEventArgs e)
        {
            VM.GatherStoneCommand.Execute(null);
        }
    }
}
