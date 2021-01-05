using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;
using System.Linq;

using Debie.Models.DB;

namespace Debie.Models {
    public class ArticleForm {
        [Key]
        public int ID { get; set; }
        [Required, MaxLength(128)]
        public string Title { get; set; }
        [Required, MaxLength(16384)]
        public string Content { get; set; }

        [Required, Display(Name = "Author")]
        public int UserID { get; set; }
        public ImageForm Image { get; set; }
        public List<int> Tags { get; set; }

        public static ArticleForm FromModel(Article model) {
            return new ArticleForm {
                ID = model.ID,
                Title = model.Title,
                Content = model.Content,
                UserID = model.User.ID,
                Image = ImageForm.FromModel(model.Image),
                Tags = model.Tags.Select(c => c.ID).ToList()
            };
        }

        public Article ToModel(Article model, List<Tag> tags) {
            model.Title = Title;
            model.Content = Content;
            model.UserID = UserID;
            model.Image = model.Image is null ? null : Image.ToModel(model.Image);
            if (Tags is null)
                model.Tags.RemoveRange(0, model.Tags.Count);
            else {
                foreach (var tagID in Tags) {
                    if (!model.Tags.Any(t => t.ID == tagID))
                        model.Tags.Add(tags.First(t => t.ID == tagID));
                }
                model.Tags = model.Tags.Where(t => Tags.Contains(t.ID)).ToList();
            }
            return model;
        }
    }
}