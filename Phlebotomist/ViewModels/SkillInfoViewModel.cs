using Phlebotomist.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phlebotomist.ViewModels
{
    public class SkillInfoViewModel : INotifyPropertyChanged
    {
        private Phlebotomist.Model.PhlebotomistModelContainer _context;
        protected internal Phlebotomist.Model.PhlebotomistModelContainer Context
        {
            get
            {
                return Repository.Context;
            }
        }

        private Phlebotomist.Repositories.PhlebotomistRepository _repository;
        protected internal Phlebotomist.Repositories.PhlebotomistRepository Repository
        {
            get;
            set;
        }

        private SkillViewModel _selectedSkill;
        public SkillViewModel SelectedSkill
        {
            get
            {
                return _selectedSkill;
            }
            set
            {
                if (_selectedSkill != value)
                {
                    _selectedSkill = value;
                    OnPropertyChanged("SelectedFamiliarType");
                }
            }
        }

        public SkillInfoViewModel()
        {

        }

        public void NewSkillSelection(SkillViewModel selectedSkill)
        {
            SelectedSkill = selectedSkill;
        }

        public void NewSelectedFamiliarType()
        {
            SelectedSkill = new SkillViewModel(new Skill
                {
                    Id = -1
                }, Repository);
        }

        public bool SaveSelectedSkill()
        {
            var skill = SelectedSkill;

            if (skill == null)
            {
                return false;
            }

            skill.Save();

            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
