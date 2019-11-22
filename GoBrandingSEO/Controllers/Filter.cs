using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;


namespace GoBrandingSEO.Filters {
    public class OutputCompress : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        try
        {
            filterContext.HttpContext.Response.Filter = new WhitespaceFilter(filterContext.HttpContext.Response);
        }
        catch (System.Exception)
        {
            //  Do Nothing
        };
    }
}


public class WhitespaceFilter : MemoryStream
{
    private string Source = string.Empty;
    private Stream Filter = null;


    public WhitespaceFilter(HttpResponseBase HttpResponseBase)
    {
        Filter = HttpResponseBase.Filter;
    }


    public override void Write(byte[] buffer, int offset, int count)
    {
        Source = UTF8Encoding.UTF8.GetString(buffer);
        Source = new Regex("(<pre>[^<>]*(((?<Open><)[^<>]*)+((?<Close-Open>>)[^<>]*)+)*(?(Open)(?!))</pre>)|\\s\\s+|[\\t\\n\\r]", RegexOptions.Compiled | RegexOptions.Singleline).Replace(Source, "$1");
        Source = new Regex("<!--.*?-->", RegexOptions.Compiled | RegexOptions.Singleline).Replace(Source, string.Empty);


        Filter.Write(UTF8Encoding.UTF8.GetBytes(Source), offset, UTF8Encoding.UTF8.GetByteCount(Source));
    }
}
}