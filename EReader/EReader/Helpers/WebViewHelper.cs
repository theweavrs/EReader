﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace EReader.Helpers
{
    public static class WebViewHelper
    {
        public static async Task ScrollToChapter(this WebView DocumentViewer, string link)
        {
            // string alternateScript = string.Format("var els = document.querySelectorAll(\"a[href~='{0}']\");var el = els[0];el.scrollIntoView();", args.Uri.Fragment.Replace("#", ""));
            string functionString = String.Format("elmnt = document.getElementById('{0}'); scrollTo(document.body, elmnt.offsetTop, 600);", link.Replace("#", ""));
            await DocumentViewer.InvokeScriptAsync("eval", new string[] { functionString });
        }
        public static async Task ChangeFontSize(this WebView DocumentViewer, int size)
        {
            string functionString = String.Format("document.body.style.fontSize = {0};", size);
            await DocumentViewer.InvokeScriptAsync("eval", new string[] { functionString });
        }
        public static async Task ChangeTheme(this WebView DocumentViewer, string background, string foreground)
        {
            string functionString = String.Format("document.body.style.background = '{0}'; document.body.style.color = '{1}';", background, foreground);
            await DocumentViewer.InvokeScriptAsync("eval", new string[] { functionString });
        }
        public static async Task SetTheme(this WebView DocumentViewer, string theme)
        {
            switch (theme)
            {
                case "Dark":
                    await ChangeTheme(DocumentViewer, "#2b2b2b", "#dbdbdb");
                    break;
                case "Light":
                    await ChangeTheme(DocumentViewer, "#dbdbdb", "#2b2b2b");
                    break;
            }
        }
        public static async Task IncreaseFontSize(this WebView DocumentViewer)
        {
            string incrementFunction = "var pElements = document.querySelector(\"p\");var style = window.getComputedStyle(pElements, null).getPropertyValue('font-size');var currentSize = parseInt(style);currentSize++;document.body.style.fontSize = currentSize;";
            await DocumentViewer.InvokeScriptAsync("eval", new string[] { incrementFunction });
        }
        public static async Task DecreaseFontSize(this WebView DocumentViewer)
        {
            string incrementFunction = "var pElements = document.querySelector(\"p\");var style = window.getComputedStyle(pElements, null).getPropertyValue('font-size');var currentSize = parseInt(style);currentSize--;document.body.style.fontSize = currentSize;";
            await DocumentViewer.InvokeScriptAsync("eval", new string[] { incrementFunction });
        }
    }
}
