using System;
using System.Collections.Generic;
using TCDUtils.Tasks;
using Tricentis.TCAddOns;

namespace TCDUtils
{
    public class TCDUtilsAddon : TCAddOn
    {
        public override string UniqueName
        {
            get
            {
                return "Tosca TCD Utilities";
            }
        }

        public override Dictionary<Type, string> TaskToIconDefinition
        {
            get
            {
                Dictionary<Type, string> retVal = new Dictionary<Type, string>();
                retVal.Add(typeof(RenameTestSheetInstanceTask), "Resources.TDInstances.png");

                return retVal;
            }
        }

        public override string AddOnIcon
        {
            get
            {
                return "Resources.TestSheet.png";
            }
        }
    }
}
