using Tricentis.TCAddOns;

namespace TCDUtils.Options
{
    public class TSRenamePrefixOption : TCAddOnOptionsDialogEntry
    {
        protected override string DisplayedName
        {
            get
            {
                return "Instance prefix";
            }
        }

        protected override string SettingName
        {
            get
            {
                return "TSRenamePrefix";
            }
        }
    }
}
