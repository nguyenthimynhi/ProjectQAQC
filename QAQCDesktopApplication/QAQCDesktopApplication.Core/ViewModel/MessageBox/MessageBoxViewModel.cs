using MaterialDesignThemes.Wpf;
using QAQCDesktopApplication.Core.ViewModel.ViewModelBase;
using System.Windows.Input;

namespace QAQCDesktopApplication.Core.ViewModel;

public delegate void Notify();  // delegate
public class MessageBoxViewModel : BaseViewModel
{
    private string _contentText;
    private PackIconKind _icon = PackIconKind.User;
    public static MessageBoxViewModel Instance => new MessageBoxViewModel();
    public string ContentText { get => _contentText; set { _contentText = value; OnPropertyChanged(); } }
    public PackIconKind Icon { get => _icon; set { _icon = value; OnPropertyChanged(); } }
    public ICommand ConfirmCommand { get; set; }
    public ICommand CancelCommand { get; set; }
    public event Notify Confirm;
    public event Notify Cancel;
    public MessageBoxViewModel()
    {
        CancelCommand = new RelayCommand(() => Cancel.Invoke());
        ConfirmCommand = new RelayCommand(() => Confirm.Invoke());
    }
}
