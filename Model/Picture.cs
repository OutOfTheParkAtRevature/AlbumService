using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Picture
    {
        [Key]
        [DisplayName("Picture ID")]
        public Guid PictureID { get; set; }
        [DisplayName("Submitted By")]
        public string SubmitterID { get; set; }
        [DisplayName("Image String")]
        public string ImageString { get; set; }
        [DisplayName("Image Array")]
        public byte[] ImageArray { get; set; }
    }
}
