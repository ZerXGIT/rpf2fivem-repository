﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace rpf2fivem.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("rpf2fivem.Properties.Resources", typeof(Resources).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to fx_version &apos;cerulean&apos;
        ///game &apos;gta5&apos;
        /// 
        ///files {
        ///    &apos;data/*.meta&apos;
        ///}
        /// 
        ///data_file &apos;HANDLING_FILE&apos; &apos;data/handling.meta&apos;
        ///data_file &apos;VEHICLE_METADATA_FILE&apos; &apos;data/vehicles.meta&apos;
        ///data_file &apos;VEHICLE_METADATA_FILE&apos; &apos;data/vehiclelayouts.meta&apos;
        ///data_file &apos;CARCOLS_FILE&apos; &apos;data/carcols.meta&apos;
        ///data_file &apos;VEHICLE_VARIATION_FILE&apos; &apos;data/carvariations.meta&apos;
        ///-- data_file &apos;VEHICLE_LAYOUTS_FILE&apos; &apos;data/dlctext.meta&apos;
        ///-- data_file &apos;VEHICLE_METADATA_FILE&apos; &apos;data/contentunlocks.meta&apos;.
        /// </summary>
        internal static string fxmanifest_false {
            get {
                return ResourceManager.GetString("fxmanifest_false", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to fx_version &apos;cerulean&apos;
        ///game &apos;gta5&apos;
        /// 
        ///files {
        ///    &apos;data/**/*.meta&apos;
        ///}
        /// 
        ///data_file &apos;HANDLING_FILE&apos; &apos;data/**/handling.meta&apos;
        ///data_file &apos;VEHICLE_LAYOUTS_FILE&apos; &apos;data/**/vehiclelayouts.meta&apos;
        ///data_file &apos;VEHICLE_METADATA_FILE&apos; &apos;data/**/vehicles.meta&apos;
        ///data_file &apos;CARCOLS_FILE&apos; &apos;data/**/carcols.meta&apos;
        ///data_file &apos;VEHICLE_VARIATION_FILE&apos; &apos;data/**/carvariations.meta&apos;
        ///-- data_file &apos;DLCTEXT_FILE&apos; &apos;data/**/dlctext.meta&apos;
        ///-- data_file &apos;CARCONTENTUNLOCKS_FILE&apos; &apos;data/**/carcontentunlocks.meta&apos;.
        /// </summary>
        internal static string fxmanifest_true {
            get {
                return ResourceManager.GetString("fxmanifest_true", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] magic {
            get {
                object obj = ResourceManager.GetObject("magic", resourceCulture);
                return ((byte[])(obj));
            }
        }
    }
}
