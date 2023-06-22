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
        /*
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tracks()
        {
            this.Genres = new ObservableCollection<Genres>();
        }
        */
        [Key] public int id_track { get; set; }
        public string title { get; set; }
        public int creation_year { get; set; }
        public virtual int id_album { get; set; }
        public virtual int id_genre { get; set; }
        public virtual Albums Albums { get; set; }
        public virtual Genres Genres { get; set; }
        /*
        [ForeignKey("id_album")] public virtual Albums Albums { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Genres> Genres { get; set; }
        */
    }
}
