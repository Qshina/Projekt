using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Model
{
    public class Artists
    {
        // KLUCZ GŁÓWNY
        //[Key] public int id_artist { get; set; }
        [Key]public string? artist_name { get; set; }
        public string? First_Name { get; set;}
        public string? Last_Name { get; set; }
        public int Age { get; set; }

    }
}
