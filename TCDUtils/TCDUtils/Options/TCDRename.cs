using Tricentis.TCAddOns;

namespace TCDUtils.Options
{
    public class TCDRename : TCAddOnOptionsDialogEntry
    {
        protected override string DisplayedName
        {
            get
            {
                return "Character(s) used to split TestSheet name and attribute values";
            }
        }

        protected override string SettingName
        {
            get
            {
                return "TSRenameSplit";
            }
        }
    }
}
