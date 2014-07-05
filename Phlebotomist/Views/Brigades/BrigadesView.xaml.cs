using Phlebotomist.Model;
using Phlebotomist.Repositories;
using Phlebotomist.ViewModels;
using Phlebotomist.Views.Familiars;
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
    /// Interaction logic for BrigadesView.xaml
    /// </summary>
    public partial class BrigadesView : UserControl
    {
        public PhlebotomistModelContainer BrigadeContext;
        public PhlebotomistRepository PhlebotomistRepository;

        private BrigadesViewModel _viewModel;
        public BrigadesViewModel ViewModel
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

        public BrigadesView()
        {
            InitializeComponent();
            BrigadeContext = new PhlebotomistModelContainer();
            PhlebotomistRepository = new Repositories.PhlebotomistRepository(BrigadeContext);
            BrigadesSearch.ViewModel.Repository = PhlebotomistRepository;
            BrigadeInfo.ViewModel.Repository = PhlebotomistRepository;
            FamiliarTypesSearch.ViewModel.Repository = PhlebotomistRepository;

            this.ViewModel = new BrigadesViewModel(BrigadesSearch.ViewModel, FamiliarTypesSearch.ViewModel,
                BrigadeInfo.ViewModel);
            this.DataContext = ViewModel;
        }

        private void BrigadesSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BrigadesSearchView searchView = (BrigadesSearchView)sender;
            if (e.AddedItems.Count == 1)
            {
                var brigadeInfoViewModel = BrigadeInfo.DataContext as BrigadeInfoViewModel;
                brigadeInfoViewModel.NewBrigadeSelection(e.AddedItems[0] as BrigadeViewModel);
            }
        }

        public void BrigadesSearch_FamiliarTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FamiliarTypesSearchView searchView = (FamiliarTypesSearchView)sender;
            if (e.AddedItems.Count == 1)
            {
                var brigadeInfoViewModel = BrigadeInfo.DataContext as BrigadeInfoViewModel;
                brigadeInfoViewModel.NewFamiliarTypeSelection(e.AddedItems[0] as FamiliarTypeViewModel);
            }
        }

        public void BrigadeSearch_FamiliarTypeDoubleClick(object sender, RoutedEventArgs e)
        {
            var brigadeInfoViewModel = BrigadeInfo.DataContext as BrigadeInfoViewModel;
            brigadeInfoViewModel.AddSelectedFamiliarTypeToBrigade();
        }
    }
}
