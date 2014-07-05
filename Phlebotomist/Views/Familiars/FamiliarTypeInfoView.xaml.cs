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

        public static readonly RoutedEvent FamiliarTypesUpdatedEvent = EventManager.RegisterRoutedEvent(
            "FamiliarTypesUpdated", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FamiliarTypeInfoView));

        public event RoutedEventHandler FamiliarTypesUpdated
        {
            add { AddHandler(FamiliarTypesUpdatedEvent, value); }
            remove { RemoveHandler(FamiliarTypesUpdatedEvent, value); }
        }

        private void RaiseFamiliarTypesUpdatedEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(FamiliarTypesUpdatedEvent);
            RaiseEvent(newEventArgs);
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

        private void clearPreviousEvolutionButton_Click(Object sender, RoutedEventArgs e)
        {
            ViewModel.ClearPreviousEvolution();
            PreviousEvolutionComboBox.SelectedItem = null;
        }

        private void clearNextEvolutionButton_Click(Object sender, RoutedEventArgs e)
        {
            ViewModel.ClearNextEvolution();
            NextEvolutionComboBox.SelectedItem = null;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            bool result = ViewModel.SaveSelectedFamiliarType();
            if (result)
            {
                RaiseFamiliarTypesUpdatedEvent();
            }
        }

        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NewSelectedFamiliarType();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addSkillButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedSkill = SkillsSourceListBox.SelectedItem as Skill;
            if (selectedSkill == null)
            {
                return;
            }

            ViewModel.AddSkill(selectedSkill);
        }

        private void removeSkillButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedSkill = SkillsDestinationListBox.SelectedItem as FamiliarTypeSkill;
            if (selectedSkill == null)
            {
                return;
            }

            ViewModel.RemoveSkill(selectedSkill.Skill);
        }
    }
}
