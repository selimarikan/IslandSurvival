using System;
using System.Media;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using IslandSurvivalDatatypes.Buildings;
using IslandSurvivalDatatypes.Characters;
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
            GatherStoneCommand = new RelayCommand<object>((o) => GatherStone());
            BuildCotCommand = new RelayCommand<object>((o) => BuildCot());

            m_ThePlayer = new Player();

            m_Timer.Interval = 2000;
            m_Timer.Elapsed += M_Timer_Elapsed;
            m_Timer.Start();
        }

        public void Tick()
        {
            Dispatcher.Invoke(UpdateInventoryVariables);
            Dispatcher.Invoke(PassTheTime);
            Dispatcher.Invoke((Action)(() => { m_ThePlayer.Tick(); }));
        }

        private void UpdateInventoryVariables()
        {
            if (CurrentLocation != null)
            {
                InventoryCapacity = CurrentLocation.Inventory.Capacity;
                PopulationCapacity = CurrentLocation.Population.Capacity;
                InventoryWoodCount = CurrentLocation.Inventory.GetItemCount<Wood>();
                InventoryStoneCount = CurrentLocation.Inventory.GetItemCount<Stone>();
                BuildingCotCount = CurrentLocation.Construction.GetBuildingCount<Cot>();
                PlayerEnergy = m_ThePlayer.Energy;

                CurrentLocation.UpdateLocationValues();
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
        private Player m_ThePlayer = null;

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

        public ICommand GatherStoneCommand
        {
            get { return (ICommand)GetValue(GatherStoneCommandProperty); }
            set { SetValue(GatherStoneCommandProperty, value); }
        }
        public static readonly DependencyProperty GatherStoneCommandProperty =
            DependencyProperty.Register("GatherStoneCommand", typeof(ICommand), typeof(IslandSurvivalVM), null);


        public ICommand BuildCotCommand
        {
            get { return (ICommand)GetValue(BuildCotCommandProperty); }
            set { SetValue(BuildCotCommandProperty, value); }
        }
        public static readonly DependencyProperty BuildCotCommandProperty =
            DependencyProperty.Register("BuildCotCommand", typeof(ICommand), typeof(IslandSurvivalVM), null);


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

        public Visibility ButtonGatherStoneVisibility
        {
            get { return (Visibility)GetValue(ButtonGatherStoneVisibilityProperty); }
            set { SetValue(ButtonGatherStoneVisibilityProperty, value); }
        }
        public static readonly DependencyProperty ButtonGatherStoneVisibilityProperty =
            DependencyProperty.Register("ButtonGatherStoneVisibility", typeof(Visibility), typeof(IslandSurvivalVM), new PropertyMetadata(Visibility.Visible));

        public string TheButtonText
        {
            get { return (string)GetValue(TheButtonTextProperty); }
            set { SetValue(TheButtonTextProperty, value); }
        }
        public static readonly DependencyProperty TheButtonTextProperty =
            DependencyProperty.Register("TheButtonText", typeof(string), typeof(IslandSurvivalVM), new PropertyMetadata(string.Empty));

        public double PlayerEnergy
        {
            get { return (double)GetValue(PlayerEnergyProperty); }
            set { SetValue(PlayerEnergyProperty, value); }
        }
        public static readonly DependencyProperty PlayerEnergyProperty =
            DependencyProperty.Register("PlayerEnergy", typeof(double), typeof(IslandSurvivalVM), new PropertyMetadata(50.0));

        public uint InventoryCapacity
        {
            get { return (uint)GetValue(InventoryCapacityProperty); }
            set { SetValue(InventoryCapacityProperty, value); }
        }
        public static readonly DependencyProperty InventoryCapacityProperty =
            DependencyProperty.Register("InventoryCapacity", typeof(uint), typeof(IslandSurvivalVM), new PropertyMetadata((uint)0));

        public uint PopulationCapacity
        {
            get { return (uint)GetValue(PopulationCapacityProperty); }
            set { SetValue(PopulationCapacityProperty, value); }
        }
        public static readonly DependencyProperty PopulationCapacityProperty =
            DependencyProperty.Register("PopulationCapacity", typeof(uint), typeof(IslandSurvivalVM), new PropertyMetadata((uint)0));

        public uint InventoryWoodCount
        {
            get { return (uint)GetValue(InventoryWoodCountProperty); }
            set { SetValue(InventoryWoodCountProperty, value); }
        }
        public static readonly DependencyProperty InventoryWoodCountProperty =
            DependencyProperty.Register("InventoryWoodCount", typeof(uint), typeof(IslandSurvivalVM), new PropertyMetadata((uint)0));

        public uint InventoryStoneCount
        {
            get { return (uint)GetValue(InventoryStoneCountProperty); }
            set { SetValue(InventoryStoneCountProperty, value); }
        }
        public static readonly DependencyProperty InventoryStoneCountProperty =
            DependencyProperty.Register("InventoryStoneCount", typeof(uint), typeof(IslandSurvivalVM), new PropertyMetadata((uint)0));


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

        // Handle these as quests or tasks
        private static void OnMessageCounterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is IslandSurvivalVM)
            {
                var VM = d as IslandSurvivalVM;

                switch (VM.MessageCounter)
                {
                    case 1:
                        VM.LastMessage = "You wake up on a shore, tired, wet and thirsty.";
                        VM.m_ThePlayer.Health = 45;
                        VM.m_ThePlayer.Energy = 50;
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
                SoundController.PlayEffect(SoundEffects.FireCrack);
                m_ThePlayer.Energy += 0.5;

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
            BuildingsTabVisibility = Visibility.Visible;

            TheButtonText = "Add wood to fire";
        }

        // Make them "Action"
        private void GatherWood()
        {
            if (m_ThePlayer.Energy < 2)
            {
                return;
            }

            m_ThePlayer.Energy -= 2;
            var rng = new Random();
            uint gatheredWoodAmount = (uint)(rng.Next(5) + 2);

            CurrentLocation.Inventory.AddItem<Wood>(gatheredWoodAmount);

            SoundController.PlayEffect(SoundEffects.ChopWood);
        }

        // Make them "Action"
        private void GatherStone()
        {
            if (m_ThePlayer.Energy < 2)
            {
                return;
            }

            m_ThePlayer.Energy -= 2;
            var rng = new Random();
            uint gatheredStoneAmount = (uint)(rng.Next(2) + 1);

            CurrentLocation.Inventory.AddItem<Stone>(gatheredStoneAmount);
            SoundController.PlayEffect(SoundEffects.StoneCollect);
        }

        private void BuildCot()
        {
            // TODO: Do not create an object to just access its property. 
            // Making cost static would prevent changing it between different derived types????
            var cot = new Cot();

            if (CurrentLocation.Inventory.GetItemCount<Wood>() >= cot.WoodCost)
            {
                SoundController.PlayEffect(SoundEffects.Build);
                CurrentLocation.Inventory.RemoveItem<Wood>(cot.WoodCost);
                CurrentLocation.Construction.AddBuilding<Cot>();
            }
        }

    }
}
