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

namespace Phlebotomist.Views.Skills
{
    /// <summary>
    /// Interaction logic for SkillSearchView.xaml
    /// </summary>
    public partial class SkillsSearchView : UserControl
    {
        private SkillsSearchViewModel _viewModel;
        public SkillsSearchViewModel ViewModel
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

        public SkillsSearchView()
        {
            InitializeComponent();
            ViewModel = new SkillsSearchViewModel();
            this.DataContext = ViewModel;
        }
    }
}
