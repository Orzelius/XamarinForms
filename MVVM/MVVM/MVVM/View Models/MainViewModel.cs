using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MVVM.ViewModels {
    public class MainViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private string _input;
        private double _tip;

        public string Tip {
            get {
                var num = _tip.ToString().Split('.')[0];
                return num;
            }
        }
        public string Input {
            get { return _input; }
            set {
                _input = value;
                _tip = Convert.ToDouble(value) * 0.8f;
                OnPropertyChanged(nameof(Input));
                OnPropertyChanged(nameof(Tip));
            }
        }
    }
}