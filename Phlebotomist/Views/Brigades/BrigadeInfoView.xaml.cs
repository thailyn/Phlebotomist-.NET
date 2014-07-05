using Phlebotomist.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Phlebotomist.Views.Brigades
{
    /// <summary>
    /// Interaction logic for BrigadeInfoView.xaml
    /// </summary>
    public partial class BrigadeInfoView : UserControl
    {
        private BrigadeInfoViewModel _viewModel;
        public BrigadeInfoViewModel ViewModel
        {
            get
            {
                return _viewModel;
            }
            set
            {
                if (_viewModel != value)
                {
                    _viewModel = value;
                    //OnPropertyChanged("ViewModel");
                }
            }
        }

        public static readonly RoutedEvent BrigadesUpdatedEvent = EventManager.RegisterRoutedEvent(
            "BrigadesUpdated", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(BrigadeInfoView));

        public event RoutedEventHandler BrigadesUpdated
        {
            add { AddHandler(BrigadesUpdatedEvent, value); }
            remove { RemoveHandler(BrigadesUpdatedEvent, value); }
        }

        private void RaiseBrigadesUpdatedEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(BrigadesUpdatedEvent);
            RaiseEvent(newEventArgs);
        }

        public BrigadeInfoView()
        {
            InitializeComponent();
            this.ViewModel = new BrigadeInfoViewModel();
            this.DataContext = ViewModel;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            bool result = ViewModel.SaveSelectedBrigade();
            if (result)
            {
                RaiseBrigadesUpdatedEvent();
            }
        }

        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NewSelectedBrigade();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        #region Got/Lost Focus Event Handlers
        private void FarLeftFrontTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectBrigadePosition(BrigadeHorizontalPosition.FarLeft, false);
        }

        private void MidLeftFrontTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectBrigadePosition(BrigadeHorizontalPosition.MidLeft, false);
        }

        private void MiddleFrontTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectBrigadePosition(BrigadeHorizontalPosition.Middle, false);
        }

        private void MidRightFrontTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectBrigadePosition(BrigadeHorizontalPosition.MidRight, false);
        }

        private void FarRightFrontTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectBrigadePosition(BrigadeHorizontalPosition.FarRight, false);
        }

        private void FarLeftReserveTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectBrigadePosition(BrigadeHorizontalPosition.FarLeft, true);
        }

        private void MidLeftReserveTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectBrigadePosition(BrigadeHorizontalPosition.MidLeft, true);
        }

        private void MiddleReserveTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectBrigadePosition(BrigadeHorizontalPosition.Middle, true);
        }

        private void MidRightReserveTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectBrigadePosition(BrigadeHorizontalPosition.MidRight, true);
        }

        private void FarRightReserveTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectBrigadePosition(BrigadeHorizontalPosition.FarRight, true);
        }
        #endregion
    }
}
