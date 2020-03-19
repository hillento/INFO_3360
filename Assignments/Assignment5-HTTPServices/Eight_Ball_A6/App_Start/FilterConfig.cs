using System.Web;
using System.Web.Mvc;

namespace Eight_Ball_A6
{
  public class FilterConfig
  {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
    }
  }
}
