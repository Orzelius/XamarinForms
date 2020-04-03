using System;

using Gallery.Data;

namespace Gallery.ViewModels {
    public class ItemDetailViewModel : BaseViewModel {
        public PostListModel Item { get; set; }
        public ItemDetailViewModel(PostListModel item = null) {
            Title = item?.Text;
            Item = item;
            
        }
    }
}
