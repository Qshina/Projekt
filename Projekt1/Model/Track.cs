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
    public class Tracks
    {
        // KLUCZ GŁÓWNY
        [Key] public int id_track { get; set; }
        public string title { get; set; }
        public DateTime creation_year { get; set; }

        // KLUCZE OBCE
        //public virtual int? album_NAME { get; set; }
        public virtual string? album_NAME { get; set; }
        public virtual Albums Albums { get; set; }
        //public virtual int? genre_NAME { get; set; }
        public virtual string? genre_NAME { get; set; }
        public virtual Genres Genres { get; set; }


    }
}
