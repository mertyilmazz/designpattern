﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StrategyPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyPattern.Controllers
{
  
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            Settings settings = new();
            if (User.Claims.Where(x => x.Type == Settings.claimDatabaseType).FirstOrDefault() != null)            
                settings.DatabaseType = (EDatabaseType)int.Parse(User.Claims.First(x => x.Type == Settings.claimDatabaseType).Value);            
            else            
                settings.DatabaseType = settings.GetDefaultDatabaseType;            

            return View(settings);
        }
    }
}