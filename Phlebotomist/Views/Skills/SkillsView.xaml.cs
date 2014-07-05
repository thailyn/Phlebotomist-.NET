using Phlebotomist.Model;
using Phlebotomist.Repositories;
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
    /// Interaction logic for SkillsView.xaml
    /// </summary>
    public partial class SkillsView : UserControl
    {
        public PhlebotomistModelContainer SkillContext;
        public PhlebotomistRepository PhlebotomistRepository;

        public SkillsView()
        {
            InitializeComponent();
            SkillContext = new PhlebotomistModelContainer();
            PhlebotomistRepository = new Repositories.PhlebotomistRepository(SkillContext);
            SkillsSearch.ViewModel.Repository = PhlebotomistRepository;
            SkillInfo.ViewModel.Repository = PhlebotomistRepository;
        }

        private void SkillsSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SkillsSearchView searchView = (SkillsSearchView)sender;
            if (e.AddedItems.Count == 1)
            {
                var skillInfoViewModel = SkillInfo.DataContext as SkillInfoViewModel;
                skillInfoViewModel.NewSkillSelection(e.AddedItems[0] as SkillViewModel);
            }
        }

        private void SkillsInfoView_SkillsUpdated(object sender, RoutedEventArgs e)
        {
            var skillsSearchViewModel = SkillsSearch.ViewModel;
            skillsSearchViewModel.SkillsUpdated();
        }
    }
}
