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
    /// Interaction logic for BrigadesSearchView.xaml
    /// </summary>
    public partial class BrigadesSearchView : UserControl
    {
        private BrigadesSearchViewModel _viewModel;
        public BrigadesSearchViewModel ViewModel
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

        public BrigadesSearchView()
        {
            InitializeComponent();
            ViewModel = new BrigadesSearchViewModel();
            this.DataContext = ViewModel;
        }
    }
}
