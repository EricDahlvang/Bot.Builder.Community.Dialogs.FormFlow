﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Bot.Builder.TestBot.Resource {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class DynamicPizza {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal DynamicPizza() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.Bot.Builder.TestBot.Resource.DynamicPizza", typeof(DynamicPizza).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Your address is fine..
        /// </summary>
        public static string AddressFine {
            get {
                return ResourceManager.GetString("AddressFine", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Address must start with a number..
        /// </summary>
        public static string AddressHelp {
            get {
                return ResourceManager.GetString("AddressHelp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Your pizza will cost {0:C}.
        /// </summary>
        public static string Cost {
            get {
                return ResourceManager.GetString("Cost", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Your pizza will cost {0:C} is that OK?.
        /// </summary>
        public static string CostConfirm {
            get {
                return ResourceManager.GetString("CostConfirm", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Specials.
        /// </summary>
        public static string Special {
            get {
                return ResourceManager.GetString("Special", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Free drink.
        /// </summary>
        public static string Special1 {
            get {
                return ResourceManager.GetString("Special1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to drink; free drink.
        /// </summary>
        public static string Special1Terms {
            get {
                return ResourceManager.GetString("Special1Terms", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Free garlic bread.
        /// </summary>
        public static string Special2 {
            get {
                return ResourceManager.GetString("Special2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to bread; garlic; garlic bread; free garlic bread.
        /// </summary>
        public static string Special2Terms {
            get {
                return ResourceManager.GetString("Special2Terms", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to specials.
        /// </summary>
        public static string SpecialTerms {
            get {
                return ResourceManager.GetString("SpecialTerms", resourceCulture);
            }
        }
    }
}
