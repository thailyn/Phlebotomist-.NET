using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phlebotomist.ViewModels
{
    public class SkillsViewModel
    {
        protected internal SkillsSearchViewModel SearchViewModel { get; set; }
        protected internal SkillInfoViewModel InfoViewModel { get; set; }

        public SkillsViewModel(SkillsSearchViewModel searchViewModel,
            SkillInfoViewModel infoViewModel)
        {
            SearchViewModel = searchViewModel;
            InfoViewModel = infoViewModel;
        }

        public void SkillsUpdated()
        {
            SearchViewModel.SkillsUpdated();
        }
    }
}
