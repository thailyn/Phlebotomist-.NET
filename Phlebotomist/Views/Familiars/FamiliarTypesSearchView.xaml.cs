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

namespace Phlebotomist.Views.Familiars
{
    /// <summary>
    /// Interaction logic for FamiliarsSearchView.xaml
    /// </summary>
    public partial class FamiliarTypesSearchView : UserControl
    {
        private FamiliarsSearchViewModel _viewModel;
        public FamiliarsSearchViewModel ViewModel
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

        public FamiliarTypesSearchView()
        {
            InitializeComponent();
            ViewModel = new FamiliarsSearchViewModel();
            this.DataContext = ViewModel;
        }
    }
}
