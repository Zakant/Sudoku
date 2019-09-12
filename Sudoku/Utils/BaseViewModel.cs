using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Sudoku.Utils
{
    public abstract class BaseViewModel : NotifyBase
    {
        public event EventHandler RequestClose;
        protected void RaiseRequestClose() => RequestClose?.Invoke(this, null);

        public Dispatcher Dispatcher { get; set; }

        protected void ChangeView<TView>() where TView : Window, new()
        {
            Dispatcher.Invoke(() =>
                {
                    (new TView()).Show();
                    RaiseRequestClose();
                });
        }


    }
}
