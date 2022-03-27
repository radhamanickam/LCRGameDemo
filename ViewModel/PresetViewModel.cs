using LCRGame.Model;
using System.Collections.Generic;
using System.ComponentModel;

namespace LCRGame.ViewModel
{
    public class PresetViewModel : INotifyPropertyChanged
    {
        public Dictionary<string, LCRGameModel> Presets { get; } = new Dictionary<string, LCRGameModel>()
                {
                { "3 players x 100 games", new LCRGameModel("3","100") },
                { "4 players x 100 games", new LCRGameModel("4","100") },
                { "5 players x 100 games", new LCRGameModel("5","100") },
                { "5 players x 1,000 games", new LCRGameModel("5","1000") },
                { "5 players x 10,000 games", new LCRGameModel("5","10000") },
                { "5 players x 100,000 games", new LCRGameModel("5","100000") },
                { "6 players x 100 games", new LCRGameModel("6","100") },
                { "7 players x 100 games", new LCRGameModel("7","100") }
                };

        private KeyValuePair<string, LCRGameModel>? _selectedKey = null;
        public KeyValuePair<string, LCRGameModel>? SelectedKey
        {
            get { return this._selectedKey; }
            set
            {
                this._selectedKey = value;
                this.OnPropertyChanged("SelectedKey");
                this.OnPropertyChanged("SelectedValue");
            }
        }

        public LCRGameModel SelectedValue
        {
            get
            {
                if (null == this.SelectedKey)
                {
                    return null;
                }

                return this.Presets[this.SelectedKey.Value.Key];
            }
            set
            {
                this.Presets[SelectedKey.Value.Key] = value;
                this.OnPropertyChanged("SelectedValue");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            var eh = this.PropertyChanged;
            if (null != eh)
            {
                eh(this, new PropertyChangedEventArgs(propName));
            }
        }

        #endregion

        public PresetViewModel()
        {
        }

    }
}
