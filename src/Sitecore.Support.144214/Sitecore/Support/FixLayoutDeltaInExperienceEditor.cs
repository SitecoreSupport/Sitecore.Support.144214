using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Pipelines.Save;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Support
{
  public class FixLayoutDeltaInExperienceEditor
  {
    // Fields
    private static ID Layout = new ID("{E1D68787-D22B-4EA2-82B3-84C282E375EB}");

    // Methods
    public void Process(SaveArgs args)
    {
      if (Sitecore.Context.PageMode.IsExperienceEditor)
      {
        foreach (Item item in args.SavedItems)
        {
          Field field = item.Fields[Layout];
          LayoutField field2 = item.Fields[FieldIDs.LayoutField];
          if (((field != null) && (field2 != null)) && !string.IsNullOrEmpty(field2.Value))
          {
            item.Editing.BeginEdit();
            LayoutField.SetFieldValue(field2.InnerField, field2.Value);
            item.Editing.EndEdit();
          }
        }
      }
    }
  }
}