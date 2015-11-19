using Tricentis.TCAddOns;

namespace TCDUtils.Options
{
    public class TSRenameEqualsOption : TCAddOnOptionsDialogEntry
    {
        protected override string DisplayedName
        {
            get
            {
                return "Character(s) for \"equals\"";
            }
        }

        protected override string SettingName
        {
            get
            {
                return "TSRenameEquals";
            }
        }
    }
}
