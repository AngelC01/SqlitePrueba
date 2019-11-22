using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace SqlitePrueba.Models
{
    public class User2 : User
    {
        public ImageSource ImgProfile  { get; set; }
        public string NombreCompleto { get; set; }

        public MemoryStream Stream1 { get; set; }

    }
}
