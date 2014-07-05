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
    public class SkillsSearchViewModel : INotifyPropertyChanged
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

        private ObservableCollection<SkillViewModel> _skills;
        public ObservableCollection<SkillViewModel> Skills
        {
            get
            {
                if (_skills == null)
                {
                    var skillsTemp = new ObservableCollection<Skill>(
                        Context.Skills.OrderBy(s => s.Name));

                    _skills = new ObservableCollection<SkillViewModel>();
                    foreach (var skill in skillsTemp)
                    {
                        _skills.Add(new SkillViewModel(skill, Repository));
                    }
                }
                return _skills;
            }
            protected set
            {
                if (_skills != value)
                {
                    _skills = value;
                    OnPropertyChanged("Skills");
                }
            }
        }

        public SkillsSearchViewModel()
        {

        }

        public void SkillsUpdated()
        {
            // Blow away the Skills collection, so it is reloaded
            // from the database the next time it is needed.
            // This is an expensive operation, though, so if we could
            // only do it when a skill is added or deleted, it would
            // be better.
            Skills = null;
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
