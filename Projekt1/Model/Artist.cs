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
        /*
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Artists()
        {
            this.Albums = new ObservableCollection<Albums>();
        }
        */

        [Key] public int id_artist { get; set; }
        public string artist_name { get; set; }
        //public virtual int id_album { get; set; }
        //public virtual Albums albums { get; set; }
        /*
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Albums> Albums { get; set; }
        */

    }
}
