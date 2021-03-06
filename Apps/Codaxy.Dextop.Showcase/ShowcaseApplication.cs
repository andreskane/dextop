﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Codaxy.Dextop.Modules;

namespace Codaxy.Dextop.Showcase
{
    public partial class ShowcaseApplication : DextopApplication
    {       
        protected override void RegisterModules()
        {
			RegisterModule("client/lib/ext", new DextopExtJSModule { CssThemeSuffix = "-gray" });
            RegisterModule("client/lib/ext/examples", new ExtJSDataViewModule());
            RegisterModule("client/lib/dextop", new DextopCoreModule());
			
			var soundModule = new DextopSoundModule();
			soundModule.AddSound("error", "client/sound/notify.mp3");
			RegisterModule("client/lib/sound", soundModule);            
			
			RegisterModule("", new ShowcaseApplicationModule());
        }

        protected override void OnModulesInitialized()
        {
            base.OnModulesInitialized();
#if !DEBUG
            OptimizeModules("client/js/cache");
#endif
        }
    }
}