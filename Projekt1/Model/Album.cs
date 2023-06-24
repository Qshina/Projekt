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
    public class Albums
    {
        // KLUCZ GŁÓWNY
        //[Key] public int id_album { get; set; }
        [Key] public string album_name { get; set; }
        public DateTime release_date { get; set; }

        // KLUCZE OBCE
        //public virtual int? artist_NAME { get; set; }
        public virtual string? artist_NAME { get; set; }

        public virtual Artists Artists { get; set; }


    }
}
