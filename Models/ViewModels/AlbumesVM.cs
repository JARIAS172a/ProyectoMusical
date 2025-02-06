﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models.ViewModels
{
    public class AlbumesVM
    {
        public Albumes Album { get; set; }
        public IEnumerable<SelectListItem> ListaArtistas { get; set; }

    }
}
