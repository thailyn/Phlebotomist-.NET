using Phlebotomist.Model;
using Phlebotomist.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Phlebotomist.Views.Familiars
{
    /// <summary>
    /// Interaction logic for FamiliarInfoView.xaml
    /// </summary>
    public partial class FamiliarTypeInfoView : UserControl
    {
        private FamiliarTypeInfoViewModel _viewModel;
        public FamiliarTypeInfoViewModel ViewModel
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

        public FamiliarTypeInfoView()
        {
            InitializeComponent();
            this.ViewModel = new FamiliarTypeInfoViewModel();
            this.DataContext = ViewModel;
        }

        internal void FamiliarType (object familiarType)
        {
            throw new NotImplementedException();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SaveSelectedFamiliarType();
        }

        private void newButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
