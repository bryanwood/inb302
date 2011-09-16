using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UFiles.Web.Kits.Page
{
    public class PageKit
    {
        /// <summary>
        /// Returns one of two strings depending on
        /// the boolean value passed.
        /// </summary>
        /// <param name="toCheck">Boolean value to check.</param>
        /// <param name="ifTrue">String to return if true.</param>
        /// <param name="ifFalse">String to return if false.</param>
        /// <returns></returns>
        public static String ConditionalOutput(bool toCheck, String ifTrue, String ifFalse)
        {
            return toCheck ? ifTrue : ifFalse;
        }
    }
}