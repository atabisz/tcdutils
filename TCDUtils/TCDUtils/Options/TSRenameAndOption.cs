using Tricentis.TCAddOns;

namespace TCDUtils.Options
{
    public class TSRenameAndOption : TCAddOnOptionsDialogEntry
    {
        protected override string DisplayedName
        {
            get
            {
                return "Character(s) to use for \"and\"";
            }
        }

        protected override string SettingName
        {
            get
            {
                return "TSRenameAnd";
            }
        }
    }
}
