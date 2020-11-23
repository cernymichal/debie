using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Debie.Models.DB;

namespace Debie.Models {
    public class ImageForm {
        [Key]
        public int ID { get; set; }
        [MaxLength(256), Display(Name = "Image title")]
        public string Title { get; set; }

        public static ImageForm FromModel(Image model) {
            return new ImageForm {
                ID = model.ID,
                Title = model.Title
            };
        }

        public Image ToModel(Image model) {
            model.Title = Title;
            return model;
        }
    }
}