﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SolrExpress {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///    A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        internal Resource() {
        }
        
        /// <summary>
        ///    Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SolrExpress.Resource", typeof(Resource).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///    Overrides the current thread's CurrentUICulture property for all
        ///    resource lookups using this strongly typed resource class.
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
        ///    Looks up a localized string similar to Parameter &quot;{0}&quot; is not allowed because another instance of the same type was added.
        /// </summary>
        public static string AllowMultipleInstancesException {
            get {
                return ResourceManager.GetString("AllowMultipleInstancesException", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to A field must be &quot;indexed=true&quot; to be used in this function.
        /// </summary>
        public static string FieldMustBeIndexedTrueToBeUsedInThisFunctionException {
            get {
                return ResourceManager.GetString("FieldMustBeIndexedTrueToBeUsedInThisFunctionException", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to A field must be numeric or DateTime to be used in a facet range.
        /// </summary>
        public static string FieldMustBeNumericOrDateTimeToBeUsedInFacetRangeException {
            get {
                return ResourceManager.GetString("FieldMustBeNumericOrDateTimeToBeUsedInFacetRangeException", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to A field must be &quot;stored=true&quot; to be used in this function.
        /// </summary>
        public static string FieldMustBeStoredTrueToBeUsedInThisFunctionException {
            get {
                return ResourceManager.GetString("FieldMustBeStoredTrueToBeUsedInThisFunctionException", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Latitude must be between -90.0 and 90.0.
        /// </summary>
        public static string InvalidLatitudeException {
            get {
                return ResourceManager.GetString("InvalidLatitudeException", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Longitude must be between -180.0 and 180.0.
        /// </summary>
        public static string InvalidLongitudeException {
            get {
                return ResourceManager.GetString("InvalidLongitudeException", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Parameter &quot;{0}&quot; is invalid
        ///Error message: {1}.
        /// </summary>
        public static string SearchParameterIsInvalidException {
            get {
                return ResourceManager.GetString("SearchParameterIsInvalidException", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Descending sort type is an unsupported feature in Solr 4.
        /// </summary>
        public static string UnsupportedSortTypeException {
            get {
                return ResourceManager.GetString("UnsupportedSortTypeException", resourceCulture);
            }
        }
        
        /// <summary>
        ///    Looks up a localized string similar to Parameter &quot;{0}&quot; has a specific version.
        /// </summary>
        public static string UseSpecificParameterRatherThanAnyException {
            get {
                return ResourceManager.GetString("UseSpecificParameterRatherThanAnyException", resourceCulture);
            }
        }
    }
}
