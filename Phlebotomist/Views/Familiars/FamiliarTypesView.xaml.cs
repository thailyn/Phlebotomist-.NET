using Phlebotomist.Model;
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
    /// Interaction logic for FamiliarsView.xaml
    /// </summary>
    public partial class FamiliarTypesView : UserControl
    {
        public PhlebotomistModelContainer FamiliarTypeContext;

        public FamiliarTypesView()
        {
            InitializeComponent();
            FamiliarTypeContext = new PhlebotomistModelContainer();
            FamiliarTypesSearch.ViewModel.Context = FamiliarTypeContext;
            FamiliarTypeInfo.ViewModel.Context = FamiliarTypeContext;
        }

        private void FamiliarTypesSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FamiliarTypesSearchView searchView = (FamiliarTypesSearchView)sender;
            if (e.AddedItems.Count == 1)
            {
                var familiarTypeInfoViewModel = FamiliarTypeInfo.DataContext as FamiliarTypeInfoViewModel;
                familiarTypeInfoViewModel.NewFamiliarTypeSelection(e.AddedItems[0] as FamiliarType);
            }
        }
    }
}
