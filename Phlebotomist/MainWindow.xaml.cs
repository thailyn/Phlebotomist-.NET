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

namespace Phlebotomist
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string APPLICATION_TITLE = "Phlebotomist";
        private const string VERSION_NUMBER = "0.01";

        public MainWindow()
        {
            InitializeComponent();

            Title = string.Format("{0} (v. {1})", APPLICATION_TITLE, VERSION_NUMBER);
        }

        private void FamiliarTypesInfoView_FamiliarTypesUpdated(object sender, RoutedEventArgs e)
        {
            var familiarTypesViewModel = FamiliarTypesView.ViewModel;
            familiarTypesViewModel.FamiliarTypesUpdated();

            var brigadesViewModel = BrigadesView.ViewModel;
            brigadesViewModel.FamiliarTypesUpdated();
        }


        private void SkillsInfoView_SkillsUpdated(object sender, RoutedEventArgs e)
        {
            var familiarTypesViewModel = FamiliarTypesView.ViewModel;
            familiarTypesViewModel.SkillsUpdated();

            var skillsViewModel = SkillsView.ViewModel;
            skillsViewModel.SkillsUpdated();
        }

        private void BrigadesInfoView_BrigadesUpdated(object sender, RoutedEventArgs e)
        {
            var brigadesViewModel = BrigadesView.ViewModel;
            brigadesViewModel.BrigadesUpdated();
        }
    }
}
