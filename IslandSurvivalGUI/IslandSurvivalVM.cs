using System;
using System.Media;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using IslandSurvivalDatatypes.Buildings;
using IslandSurvivalDatatypes.Items;
using IslandSurvivalDatatypes.Locations;

namespace IslandSurvivalGUI
{
    public sealed class IslandSurvivalVM : DependencyObject
    {
        public IslandSurvivalVM()
        {
            TheButtonCommand = new RelayCommand<object>((o) => OnTheButtonClicked());
            GatherWoodCommand = new RelayCommand<object>((o) => GatherWood());

            m_Timer.Interval = 2000;
            m_Timer.Elapsed += M_Timer_Elapsed;
            m_Timer.Start();
        }

        public void Tick()
        {
            Dispatcher.Invoke(UpdateInventoryVariables);
            Dispatcher.Invoke(PassTheTime);
        }

        private void UpdateInventoryVariables()
        {
            if (CurrentLocation != null)
            {
                InventoryWoodCount = CurrentLocation.Inventory.GetItemCount<Wood>();
                BuildingCotCount = CurrentLocation.Construction.GetBuildingCount<Cot>();
            }
        }

        private void PassTheTime()
        {
            ElapsedHours++;
        }

        private void M_Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Tick();
        }

        private readonly Timer m_Timer = new Timer();

        public uint ElapsedHours
        {
            get { return (uint)GetValue(ElapsedHoursProperty); }
            set { SetValue(ElapsedHoursProperty, value); }
        }
        public static readonly DependencyProperty ElapsedHoursProperty =
            DependencyProperty.Register("ElapsedHours", typeof(uint), typeof(IslandSurvivalVM), new UIPropertyMetadata((uint)0));

        public string LastMessage
        {
            get { return (string)GetValue(LastMessageProperty); }
            set { SetValue(LastMessageProperty, value); }
        }
        public static readonly DependencyProperty LastMessageProperty =
            DependencyProperty.Register("LastMessage", typeof(string), typeof(IslandSurvivalVM), new UIPropertyMetadata(string.Empty));

        public ICommand NotificationCommand
        {
            get { return (ICommand)GetValue(NotificationCommandProperty); }
            set { SetValue(NotificationCommandProperty, value); }
        }
        public static readonly DependencyProperty NotificationCommandProperty =
            DependencyProperty.Register("NotificationCommand", typeof(ICommand), typeof(IslandSurvivalVM), null);

        public ICommand TheButtonCommand
        {
            get { return (ICommand)GetValue(TheButtonCommandProperty); }
            set { SetValue(TheButtonCommandProperty, value); }
        }
        public static readonly DependencyProperty TheButtonCommandProperty =
            DependencyProperty.Register("TheButtonCommand", typeof(ICommand), typeof(IslandSurvivalVM), null);

        public ICommand GatherWoodCommand
        {
            get { return (ICommand)GetValue(GatherWoodCommandProperty); }
            set { SetValue(GatherWoodCommandProperty, value); }
        }
        public static readonly DependencyProperty GatherWoodCommandProperty =
            DependencyProperty.Register("GatherWoodCommand", typeof(ICommand), typeof(IslandSurvivalVM), null);

        public Location CurrentLocation
        {
            get { return (Location)GetValue(CurrentLocationProperty); }
            set { SetValue(CurrentLocationProperty, value); }
        }
        public static readonly DependencyProperty CurrentLocationProperty =
            DependencyProperty.Register("CurrentLocation", typeof(Location), typeof(IslandSurvivalVM), null);

        public Visibility OverviewTabVisibility
        {
            get { return (Visibility)GetValue(OverviewTabVisibilityProperty); }
            set { SetValue(OverviewTabVisibilityProperty, value); }
        }
        public static readonly DependencyProperty OverviewTabVisibilityProperty =
            DependencyProperty.Register("OverviewTabVisibility", typeof(Visibility), typeof(IslandSurvivalVM), new PropertyMetadata(Visibility.Collapsed));

        public Visibility SuppliesTabVisibility
        {
            get { return (Visibility)GetValue(SuppliesTabVisibilityProperty); }
            set { SetValue(SuppliesTabVisibilityProperty, value); }
        }
        public static readonly DependencyProperty SuppliesTabVisibilityProperty =
            DependencyProperty.Register("SuppliesTabVisibility", typeof(Visibility), typeof(IslandSurvivalVM), new PropertyMetadata(Visibility.Collapsed));

        public Visibility BuildingsTabVisibility
        {
            get { return (Visibility)GetValue(BuildingsTabVisibilityProperty); }
            set { SetValue(BuildingsTabVisibilityProperty, value); }
        }
        public static readonly DependencyProperty BuildingsTabVisibilityProperty =
            DependencyProperty.Register("BuildingsTabVisibility", typeof(Visibility), typeof(IslandSurvivalVM), new PropertyMetadata(Visibility.Collapsed));

        public Visibility TheButtonVisibility
        {
            get { return (Visibility)GetValue(TheButtonVisibilityProperty); }
            set { SetValue(TheButtonVisibilityProperty, value); }
        }
        public static readonly DependencyProperty TheButtonVisibilityProperty =
            DependencyProperty.Register("TheButtonVisibility", typeof(Visibility), typeof(IslandSurvivalVM), new PropertyMetadata(Visibility.Collapsed));

        public Visibility ButtonChopWoodVisibility
        {
            get { return (Visibility)GetValue(ButtonChopWoodVisibilityProperty); }
            set { SetValue(ButtonChopWoodVisibilityProperty, value); }
        }
        public static readonly DependencyProperty ButtonChopWoodVisibilityProperty =
            DependencyProperty.Register("ButtonChopWoodVisibility", typeof(Visibility), typeof(IslandSurvivalVM), new PropertyMetadata(Visibility.Collapsed));

        public uint ButtonChopWoodProgress
        {
            get { return (uint)GetValue(ButtonChopWoodProgressProperty); }
            set { SetValue(ButtonChopWoodProgressProperty, value); }
        }
        public static readonly DependencyProperty ButtonChopWoodProgressProperty =
            DependencyProperty.Register("ButtonChopWoodProgress", typeof(uint), typeof(IslandSurvivalVM), new PropertyMetadata((uint)0));

        public string TheButtonText
        {
            get { return (string)GetValue(TheButtonTextProperty); }
            set { SetValue(TheButtonTextProperty, value); }
        }
        public static readonly DependencyProperty TheButtonTextProperty =
            DependencyProperty.Register("TheButtonText", typeof(string), typeof(IslandSurvivalVM), new PropertyMetadata(string.Empty));

        public uint InventoryWoodCount
        {
            get { return (uint)GetValue(InventoryWoodCountProperty); }
            set { SetValue(InventoryWoodCountProperty, value); }
        }
        public static readonly DependencyProperty InventoryWoodCountProperty =
            DependencyProperty.Register("InventoryWoodCount", typeof(uint), typeof(IslandSurvivalVM), new PropertyMetadata((uint)0));

        public uint BuildingCotCount
        {
            get { return (uint)GetValue(BuildingCotCountProperty); }
            set { SetValue(BuildingCotCountProperty, value); }
        }
        public static readonly DependencyProperty BuildingCotCountProperty =
            DependencyProperty.Register("BuildingCotCount", typeof(uint), typeof(IslandSurvivalVM), new PropertyMetadata((uint)0));


        public uint MessageCounter
        {
            get { return (uint)GetValue(MessageCounterProperty); }
            set { SetValue(MessageCounterProperty, value); }
        }
        public static readonly DependencyProperty MessageCounterProperty =
            DependencyProperty.Register("MessageCounter", typeof(uint), typeof(IslandSurvivalVM), new UIPropertyMetadata((uint)0, OnMessageCounterChanged));

        private static void OnMessageCounterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is IslandSurvivalVM)
            {
                var VM = d as IslandSurvivalVM;

                switch (VM.MessageCounter)
                {
                    case 1:
                        VM.LastMessage = "You wake up on a shore, tired, wet and thirsty.";
                        break;

                    case 2:
                        VM.LastMessage = "After you open your eyes, you feel the thirst.";
                        break;
                    case 3:
                        VM.LastMessage = "You try to get up with difficulty and try to stand.";
                        break;
                    case 4:
                        VM.LastMessage = "Sun is setting and you must light a fire.";
                        VM.CurrentLocation = new Shore();
                        break;
                    case 5:
                        VM.ExecuteQuestIntroduction();
                        break;
                    case 6:
                        VM.LastMessage = string.Empty;
                        break;

                    default:
                        break;
                }
            }
        }

        private void OnTheButtonClicked()
        {
            if (CurrentLocation.Inventory.GetItemCount<Wood>() > 0)
            {
                CurrentLocation.Inventory.RemoveItem<Wood>();
                NotificationCommand.Execute("You feel warmer.");
                var soundPlayer = new SoundPlayer("Resources/Audio/Effects/fireCrackle.wav");
                soundPlayer.Play();
                // TODO: add game saving here
            }
        }

        private void ExecuteQuestIntroduction()
        {
            LastMessage = "You collect some firewood and light a fire.";

            for (var i = 0; i < 5; i++)
            {
                CurrentLocation.Inventory.Items.Add(new Wood());
            }

            NotificationCommand.Execute("Got 5 wood.");

            OverviewTabVisibility = Visibility.Visible;
            SuppliesTabVisibility = Visibility.Visible;
            TheButtonVisibility = Visibility.Visible;
            ButtonChopWoodVisibility = Visibility.Visible;

            TheButtonText = "Add wood to fire";
        }

        private void GatherWood()
        {
            var soundPlayer = new SoundPlayer("Resources/Audio/Effects/woodChop.wav");
            soundPlayer.Play();

            var rng = new Random();
            int gatheredWoodAmount = rng.Next(15) + 5;

            CurrentLocation.Inventory.AddItem<Wood>(gatheredWoodAmount);
        }
    }
}
