using System;

using Gallery.Data;

namespace Gallery.ViewModels {
    public class ItemDetailViewModel : BaseViewModel {
        public Post Item { get; set; }
        public ItemDetailViewModel(Post item = null) {
            Title = item?.Text;
            Item = item;
        }
    }
}
