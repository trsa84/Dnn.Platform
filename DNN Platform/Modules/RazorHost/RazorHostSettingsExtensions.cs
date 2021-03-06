﻿// 
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// 
using System;
using System.Web.UI;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Security;

namespace DotNetNuke.Modules.RazorHost
{
    [Obsolete("Deprecated in 9.3.2, will be removed in 11.0.0, use Razor Pages instead")]
    public static class RazorHostSettingsExtensions
    {
        [Obsolete("Deprecated in 9.3.2, will be removed in 11.0.0, use Razor Pages instead")]
        public static Settings LoadRazorSettingsControl(this UserControl parent, ModuleInfo configuration, string localResourceFile)
        {
            var control = (Settings) parent.LoadControl("~/DesktopModules/RazorModules/RazorHost/Settings.ascx");
            control.ModuleConfiguration = configuration;
            control.LocalResourceFile = localResourceFile;
            EnsureEditScriptControlIsRegistered(configuration.ModuleDefID);
            return control;
        }


        private static void EnsureEditScriptControlIsRegistered(int moduleDefId)
        {
            if (ModuleControlController.GetModuleControlByControlKey("EditRazorScript", moduleDefId) != null) return;
            var m = new ModuleControlInfo
                        {
                            ControlKey = "EditRazorScript",
                            ControlSrc = "DesktopModules/RazorModules/RazorHost/EditScript.ascx",
                            ControlTitle = "Edit Script",
                            ControlType = SecurityAccessLevel.Host,
                            ModuleDefID = moduleDefId
                        };
            ModuleControlController.UpdateModuleControl(m);
        }
    }
}
