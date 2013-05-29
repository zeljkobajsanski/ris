using System;
using System.Web.Optimization;

namespace Ris.AgencijskeVesti {
  public class DurandalBundleConfig {
    public static void RegisterBundles(BundleCollection bundles) {
      bundles.IgnoreList.Clear();
      AddDefaultIgnorePatterns(bundles.IgnoreList);

      bundles.Add(
        new ScriptBundle("~/scripts/vendor")
          .Include("~/Scripts/jquery.min.js")
          .Include("~/Scripts/kendo.web.min.js")
          .Include("~/Scripts/knockout-2.2.1.js")
          .Include("~/Scripts/knockout-kendo.min.js")
          .Include("~/Scripts/sammy-0.7.4.min.js")
          .Include("~/Scripts/bootstrap.min.js")
        );

      bundles.Add(
        new StyleBundle("~/Content/css")
          .Include("~/Content/ie10mobile.css")
          .Include("~/Content/bootstrap.min.css")
          .Include("~/Content/bootstrap-responsive.min.css")
          .Include("~/Content/font-awesome.min.css")
          .Include("~/Content/app.css")
          .Include("~/Content/kendo.common.min.css")
          .Include("~/Content/kendo.metro.min.css")
        );
    }

    public static void AddDefaultIgnorePatterns(IgnoreList ignoreList) {
      if(ignoreList == null) {
        throw new ArgumentNullException("ignoreList");
      }

      ignoreList.Ignore("*.intellisense.js");
      ignoreList.Ignore("*-vsdoc.js");
      ignoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
      //ignoreList.Ignore("*.min.js", OptimizationMode.WhenDisabled);
      //ignoreList.Ignore("*.min.css", OptimizationMode.WhenDisabled);
    }
  }
}