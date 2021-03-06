﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Gallery.Views;
using System.Collections.Generic;
using Gallery.Data;
using System.Linq;
using Gallery.Services;
using Microsoft.EntityFrameworkCore;

namespace Gallery.ViewModels {
    public class ItemsViewModel : BaseViewModel {
        public ObservableCollection<PostListModel> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel() {
            Title = "Browse";
            Items = new ObservableCollection<PostListModel>();
            LoadItemsCommand = new Command(() => ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, PostListModel>(this, "AddItem", async (obj, item) => {
                var newItem = item as PostListModel;
                item.User = App.CurrentUser;
                Items.Add(newItem);
                //await App.DataContext.Posts.AddAsync(newItem);
            });
        }

        public async void ExecuteLoadItemsCommand() {
            if (IsBusy)
                return;

            IsBusy = true;

            Items.Clear();
            var items = App.DataContext.Posts
                .Include(p => p.User)
                .ToList();
            var fileService = DependencyService.Get<FileService>();
            foreach (var item in items) {
                var viewItem = new PostListModel() { Description = item.Description, ImageId = item.ImageId, Text = item.Text, User = item.User };
                viewItem.PostImage = await fileService.RetriveImage(item.ImageId);
                if (item.User.ProfilePicSource != null){
                    viewItem.UserImage = await fileService.RetriveImage(item.User.ProfilePicSource);
                }
                //viewItem.Image.Source = await fileService.("temp/" + item.ImageId);
                Items.Add(viewItem);
            }
            IsBusy = false;
            //try {
            //}
            //catch (Exception ex) {
            //    throw (ex);
            //}
            //finally {
            //    IsBusy = false;
            //}
        }
    }
}