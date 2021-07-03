using DndBruschiEd.Core;
using DndBruschiEd.Core.Characters;
using DndBruschiEd.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndBruschiEd.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand GeneralViewCommand { get; set; }
        public RelayCommand EquipViewCommand { get; set; }

        public RelayCommand SaveCharacterCommand { get; set; }
        public RelayCommand LoadCharacterCommand { get; set; }


        public CharacterModel CurrentLoadedModel { get; set; }

        public GeneralViewModel GeneralViewModel { get; set; }
        public EquipViewModel EquipViewModel { get; set; }


        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            GeneralViewModel = new GeneralViewModel();
            EquipViewModel = new EquipViewModel();

            CurrentView = GeneralViewModel;

            GeneralViewCommand = new RelayCommand(o =>
            {
                CurrentView = GeneralViewModel;
            });

            EquipViewCommand = new RelayCommand(o =>
            {
                CurrentView = EquipViewModel;
            });

            LoadCharacterCommand = new RelayCommand(o =>
            {
                CurrentLoadedModel = CharacterModel.Import();
            });

            SaveCharacterCommand = new RelayCommand(o =>
            {
                CurrentLoadedModel.Export();
            },
            o => { return CurrentLoadedModel != null; });

            CurrentLoadedModel = null;
        }
            
    }
}
