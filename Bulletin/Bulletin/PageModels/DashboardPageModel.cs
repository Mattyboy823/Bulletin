using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bulletin.PageModels.Base;

namespace Bulletin.PageModels
{
    public class DashboardPageModel : PageModelBase 
    {

        private ProfilePageModel profilePM;
        public ProfilePageModel ProfilePageModel
        {
            get => profilePM;
            set => SetProperty(ref profilePM, value);
        }
        private SettingsPageModel settingsPM;
        public SettingsPageModel SettingsPageModel
        {
            get => settingsPM;
            set => SetProperty(ref settingsPM, value);
        }
        private SummaryPageModel summaryPM;
        public SummaryPageModel SummaryPageModel
        {
            get => summaryPM;
            set => SetProperty(ref summaryPM, value);
        }
        private TimeClockPageModel timeClockPM;
        public TimeClockPageModel TimeClockPageModel
        {
            get => timeClockPM;
            set => SetProperty(ref timeClockPM, value);
        }

        public DashboardPageModel(ProfilePageModel profilePM, SettingsPageModel settingsPM, 
            SummaryPageModel summaryPM, TimeClockPageModel timeClockPM)
        {
            ProfilePageModel = profilePM;
            SettingsPageModel = settingsPM;
            SummaryPageModel = summaryPM;
            TimeClockPageModel = timeClockPM;
        }

        public override Task InitializeAsync(object navigationData)
        {
            return Task.WhenAny(base.InitializeAsync(navigationData),
                ProfilePageModel.InitializeAsync(null),
                SettingsPageModel.InitializeAsync(null),
                SummaryPageModel.InitializeAsync(null),
                TimeClockPageModel.InitializeAsync(null));
        }
    }
}
