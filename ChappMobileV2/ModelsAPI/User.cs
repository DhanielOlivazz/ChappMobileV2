﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChappMobileV2.ModelsAPI
{
    public class User
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public string url_img_avatar { get; set; }
        public string skills { get; set; }

    }
}
