using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phlebotomist.ViewModels
{
    public class FamiliarTypesViewModel
    {
        protected internal FamiliarsSearchViewModel SearchViewModel { get; set; }
        protected internal FamiliarTypeInfoViewModel InfoViewModel { get; set; }

        public FamiliarTypesViewModel(FamiliarsSearchViewModel searchViewModel,
            FamiliarTypeInfoViewModel infoViewModel)
        {
            SearchViewModel = searchViewModel;
            InfoViewModel = infoViewModel;
        }

        public void FamiliarTypesUpdated()
        {
            SearchViewModel.FamiliarTypesUpdated();
            InfoViewModel.FamiliarTypesUpdated();
        }

        public void SkillsUpdated()
        {
            InfoViewModel.SkillsUpdated();
        }
    }
}
