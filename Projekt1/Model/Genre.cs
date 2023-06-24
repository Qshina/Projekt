using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Model
{
    public class Genres
    {
        // KLUCZ GŁÓWNY
        [Key] public string genre { get; set; }
        //[Key] public int id_genre { get; set; }

        // KLUCZE OBCE
        //public virtual int? track_NAME { get; set; }
        //public virtual Tracks Tracks { get; set; }

    }
}
