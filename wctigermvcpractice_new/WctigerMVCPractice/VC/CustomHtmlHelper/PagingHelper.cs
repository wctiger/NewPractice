using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using VC.UIModels;

namespace VC.CustomHtmlHelper
{
    public static class PagingHelper
    {
        public static IHtmlString Paging(this HtmlHelper helper, PagingInfo info, Func<int, string> pageUrl)
        {
            StringBuilder sbResult = new StringBuilder();
            for (int i = 1; i <= info.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == info.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }                
                    tag.AddCssClass("btn btn-default");
                
                sbResult.Append(tag.ToString());
            }

            return new HtmlString(sbResult.ToString());
        }
    }
}