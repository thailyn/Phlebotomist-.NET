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

        public BrigadeInfoView()
        {
            InitializeComponent();
            this.ViewModel = new BrigadeInfoViewModel();
            this.DataContext = ViewModel;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SaveSelectedBrigade();
        }

        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NewSelectedBrigade();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
