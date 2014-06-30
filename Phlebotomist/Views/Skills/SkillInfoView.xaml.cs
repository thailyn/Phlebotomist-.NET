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
    /// Interaction logic for SkillInfoView.xaml
    /// </summary>
    public partial class SkillInfoView : UserControl
    {
        private SkillInfoViewModel _viewModel;
        public SkillInfoViewModel ViewModel
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

        public SkillInfoView()
        {
            InitializeComponent();
            this.ViewModel = new SkillInfoViewModel();
            this.DataContext = ViewModel;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SaveSelectedSkill();
        }

        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NewSelectedSkill();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ignoresPosition_Checked(object sender, RoutedEventArgs e)
        {
            ViewModel.SetIgnoresPosition(true);
        }

        private void ignoresPosition_Unchecked(object sender, RoutedEventArgs e)
        {
            ViewModel.SetIgnoresPosition(false);
        }

        private void ignoresPosition_Indeterminate(object sender, RoutedEventArgs e)
        {
            ViewModel.SetIgnoresPosition(null);
        }
    }
}
