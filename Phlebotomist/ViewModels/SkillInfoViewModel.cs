using Phlebotomist.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                    OnPropertyChanged("SelectedSkill");
                }
            }
        }

        private ObservableCollection<SkillType> _types;
        public ObservableCollection<SkillType> Types
        {
            get
            {
                if (_types == null)
                {
                    _types = new ObservableCollection<SkillType>(
                        from s in Context.SkillType
                        select s);
                }
                return _types;
            }
            set
            {
                if (_types != value)
                {
                    _types = value;
                    OnPropertyChanged("Types");
                }
            }
        }

        private ObservableCollection<SkillGroup> _groups;
        public ObservableCollection<SkillGroup> Groups
        {
            get
            {
                if (_groups == null)
                {
                    _groups = new ObservableCollection<SkillGroup>(
                        from s in Context.SkillGroups
                        select s);
                }
                return _groups;
            }
            set
            {
                if (_groups != value)
                {
                    _groups = value;
                    OnPropertyChanged("Groups");
                }
            }
        }

        private ObservableCollection<SkillPattern> _patterns;
        public ObservableCollection<SkillPattern> Patterns
        {
            get
            {
                if (_patterns == null)
                {
                    _patterns = new ObservableCollection<SkillPattern>(
                        from s in Context.SkillPatterns
                        select s);
                }
                return _patterns;
            }
            set
            {
                if (_patterns != value)
                {
                    _patterns = value;
                    OnPropertyChanged("Patterns");
                }
            }
        }

        private ObservableCollection<Stat> _stats;
        public ObservableCollection<Stat> Stats
        {
            get
            {
                if (_stats == null)
                {
                    _stats = new ObservableCollection<Stat>(
                        from s in Context.Stats
                        select s);
                }
                return _stats;
            }
            set
            {
                if (_stats != value)
                {
                    _stats = value;
                    OnPropertyChanged("Stats");
                }
            }
        }

        public SkillInfoViewModel()
        {

        }

        public void SetIgnoresPosition(Nullable<bool> value)
        {
            try
            {
                if (!value.HasValue)
                {
                    SelectedSkill.IgnoresPosition = null;
                }
                else if (value.Value)
                {
                    SelectedSkill.IgnoresPosition = 1;
                }
                else
                {
                    SelectedSkill.IgnoresPosition = 0;
                }
            }
            catch (Exception ex)
            {
                var exception = ex;
            }
        }

        public void NewSkillSelection(SkillViewModel selectedSkill)
        {
            SelectedSkill = selectedSkill;
        }

        public void NewSelectedSkill()
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
