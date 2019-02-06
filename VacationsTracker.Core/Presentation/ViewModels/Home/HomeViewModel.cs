using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using FlexiMvvm;
using FlexiMvvm.Commands;
using VacationsTracker.Core.Presentation.ViewModels.Vacation;

namespace VacationsTracker.Core.Presentation.ViewModels.Home
{
    public class HomeViewModel : ViewModelBase
    {
        public ObservableCollection<VacationCellViewModel> Vacations { get; set; }

        public ICommand VacationSelectedCommand => CommandProvider.GetForAsync(NavigateToDetails);

        protected override void Initialize()
        {
            base.Initialize();

            //TODO login view initialization
            Vacations = new ObservableCollection<VacationCellViewModel>();
            Vacations.Add(new VacationCellViewModel());
            Vacations.Add(new VacationCellViewModel());
            Vacations.Add(new VacationCellViewModel());
        }

        private async Task NavigateToDetails()
        {
            return;
        }
    }
}
