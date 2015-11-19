using System;
using System.Collections.Generic;
using System.Linq;
using TCDUtils.Properties;
using Tricentis.TCAddOns;
using Tricentis.TCAPIObjects.Objects;

namespace TCDUtils.Tasks
{
    public class RenameTestSheetInstanceTask : TCAddOnTask
    {
        public override Type ApplicableType
        {
            get
            {
                return typeof(TDAttribute);
            }
        }

        public override string Name
        {
            get
            {
                return "Rename TestSheet Instances";
            }
        }

        public override bool IsTaskPossible(TCObject obj)
        {
            return (obj.OwningObject.GetType() == typeof(TestSheet));
        }

        public override bool RequiresChangeRights
        {
            get
            {
                return true;
            }
        }

        public override TCObject Execute(List<TCObject> objs, TCAddOnTaskContext taskContext)
        {
            try
            {
                TestSheet ts = (TestSheet)objs.First().OwningObject;
                List<string> selectedAttribs = new List<string>();
                foreach (TCObject obj in objs)
                {
                    selectedAttribs.Add(obj.UniqueId);
                }

                foreach (TDInstance inst in ts.Instances.Items)
                {

                    string instName = "";
                    foreach (TDInstanceValue instValue in inst.Values)
                    {
                        if (selectedAttribs.Contains(instValue.Element.UniqueId))
                        {
                            if ((instValue.ValueInstance == null) || (instValue.ValueInstance.Character != TDCharacterE.StraightThrough))
                            {
                                if (string.IsNullOrWhiteSpace(instName))
                                {
                                    instName = string.Format("{0}", Settings.Default.TSRenameSplit);
                                }
                                else
                                {
                                    instName += string.Format("{0}", Settings.Default.TSRenameAnd);
                                }
                                instName += string.Format("{0}{1}{2}",
                                    instValue.Element.Name,
                                    Settings.Default.TSRenameEquals,
                                    instValue.ValueInstance == null ? instValue.Value : instValue.ValueInstance.Name);
                            }
                        }
                    }

                    inst.Name = string.Format("{0} {1} {2}", Settings.Default.TSRenamePrefix, ts.Name, instName).Trim();
                    inst.EnsureUniqueName();
                }
            }
            catch (Exception e)
            {
                taskContext.ShowErrorMessage("Well, this is embarrassing",
                    string.Format("An unhandled exception has occured."
                    + Environment.NewLine + Environment.NewLine + "{0}", e.ToString()));
            }

            return null;
        }

        public override TCObject Execute(TCObject objectToExecuteOn, TCAddOnTaskContext taskContext)
        {
            List<TCObject> objs = new List<TCObject>();
            objs.Add(objectToExecuteOn);
            return Execute(objs, taskContext);
        }
    }
}
