using System;
using System.Configuration;
using TCDUtils.Properties;
using Tricentis.TCAddOns;

namespace TCDUtils.Options
{
    public class TCDRenameAddOnOptions : TCAddOnOptionsDialogPage
    {
        protected override ApplicationSettingsBase GetSettingsObject()
        {
            return Settings.Default;
        }

        protected override bool CastValue(Type requestedType, ref object Value)
        {
            if (requestedType.IsEnum && Value is string)
            {
                Value = Enum.Parse(requestedType, Value as string);
                return true;
            }

            return base.CastValue(requestedType, ref Value);
        }
    }
}
