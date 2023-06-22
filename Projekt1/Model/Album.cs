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
        /*
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Albums()
        {
            this.Tracks = new ObservableCollection<Tracks>();

        }
        */
        [Key] public int id_album { get; set; }
        public string album_name { get; set; }
        
        public virtual int id_artist { get; set; }
        public virtual int id_track { get; set; }
        public virtual Artists Artists { get; set; }
        public virtual Tracks Tracks { get; set; }

        /*
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Tracks> Tracks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Purchases> Purchases { get; set; }
        [ForeignKey("id_artist")] public virtual Artists Artists { get; set; }
        */
    }
}
