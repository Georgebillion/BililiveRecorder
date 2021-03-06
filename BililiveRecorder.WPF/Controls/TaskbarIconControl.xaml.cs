using System.Windows;
using System.Windows.Controls;
using Hardcodet.Wpf.TaskbarNotification;

namespace BililiveRecorder.WPF.Controls
{
    /// <summary>
    /// Interaction logic for TaskbarIconControl.xaml
    /// </summary>
    public partial class TaskbarIconControl : UserControl
    {
        public TaskbarIconControl()
        {
            InitializeComponent();

            // AddHandler(NewMainWindow.ShowBalloonTipEvent, (RoutedEventHandler)UserControl_ShowBalloonTip);
            if (Application.Current.MainWindow is NewMainWindow nmw)
            {
                nmw.ShowBalloonTipCallback = (title, msg, sym) =>
                {
                    TaskbarIcon.ShowBalloonTip(title, msg, sym);
                };
            }
        }

        private void TaskbarIcon_TrayLeftMouseUp(object sender, RoutedEventArgs e)
        {
            // RaiseEvent(new RoutedEventArgs(NewMainWindow.SuperActivateEvent));
            (Application.Current.MainWindow as NewMainWindow)?.SuperActivateAction();
        }

        /*
        private void UserControl_ShowBalloonTip(object sender, RoutedEventArgs e)
        {
            var f = e as NewMainWindow.ShowBalloonTipRoutedEventArgs;
            TaskbarIcon.ShowBalloonTip(f.Title, f.Message, f.Symbol);
        }
        */
    }
}
