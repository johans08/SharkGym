using System.Web;
using System.Web.Optimization;

namespace SharkGym.UI
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/scrollreveal.min.js",
                        "~/Scripts/waypoints.min.js",
                        "~/Scripts/jquery.counterup.min.js",
                        "~/Scripts/imgfix.min.js",
                        "~/Scripts/mixitup.js",
                        "~/Scripts/accordions.js",
                        "~/Scripts/custom.js",
                        "~/Scripts/jquery-2.1.0.min.js",
                        "~/Scripts/popper.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                        "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/font-awesome.css",
                      "~/Content/templatemo-training-studio.css",
                      "~/Content/templatemo-finance-business.css"));
        }
    }
}
