using GalaSoft.MvvmLight;

namespace JSON.Test.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        InputViewModel inputVM;
        public InputViewModel InputVM
        {
            get => inputVM;
            set
            {
                inputVM = value;
                Set("InputVM", ref value);
            }
        }
        OutputViewModel outputVM;
        public OutputViewModel OutputVM
        {
            get => outputVM;
            set
            {
                outputVM = value;
                Set("OutputVM", ref value);
            }
        }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            OutputVM = new OutputViewModel();
            InputVM = new InputViewModel(OutputVM);
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }
    }
}