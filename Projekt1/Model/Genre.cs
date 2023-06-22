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
        /*
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Genres()
        {
            this.Tracks = new ObservableCollection<Tracks>();
        }
        */
        public string genre { get; set; }
        [Key] public int id_genre { get; set; }
        public virtual int? id_track { get; set; }
        public virtual Tracks Tracks { get; set; }
       
        /*
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [ForeignKey("id_track")] public virtual ObservableCollection<Tracks> Tracks { get; set; }
        */
    }
}
