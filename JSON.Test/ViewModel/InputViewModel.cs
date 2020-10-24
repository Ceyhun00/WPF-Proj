using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;
using JSON.Test.Data;

namespace JSON.Test.ViewModel
{
    public class InputViewModel : ViewModelBase
    {
        #region Binding Property
        OutputViewModel outputVM; public OutputViewModel OutputVM
        {
            get => outputVM;
            set
            {
                outputVM = value;
                Set("OutputVM", ref value);
            }
        }
        string jsonCount;
        public string JsonCount
        {
            get { return jsonCount; }
            set
            {
                jsonCount = value;
                Set("JsonCount", ref value);
            }
        }
        string input; public string Input
        {
            get { return input; }
            set
            {
                input = value;
                Set("Input", ref value);
                string datatype = "";
                bool start = false;
                int open = 0;
                foreach (char c in Input)
                {
                    if (c == '{')
                    {
                        start = true;
                        open++;
                    }
                    else if (c == '}')
                    {
                        open--;
                    }
                    if (start)
                    {
                        datatype += c;
                        if (open == 0)
                            start = false;
                    }
                    else
                    {
                        if (datatype.Length > 0)
                        {
                            Json.Add(datatype);
                            datatype = "";
                        }
                    }
                }
                Parse();
                JsonCount = Json.Count.ToString();
            }
        }

        List<string> json;
        public List<string> Json
        {
            get { return json; }
            set
            {
                json = value;
                Set("Json", ref value);
            }
        }
        #endregion

        #region Constructor
        public InputViewModel(OutputViewModel outputVM)
        {
            OutputVM = outputVM;
            Json = new List<string>();
            DropCommand = new RelayCommand<DragEventArgs>(Drop);
            ReadCommand = new RelayCommand(Read);
            ClearCommand = new RelayCommand(Clear);
        }
        #endregion

        #region Binding Commands
        public ICommand DropCommand { get; private set; }
        private void Drop(DragEventArgs e)
        {
            Json.Clear();
            if (e.Data.GetData("FileNameW") is string[])
            {
                Input = File.ReadAllText(((string[])e.Data.GetData("FileNameW"))[0]);
            }
        }
        public ICommand ReadCommand { get; private set; }
        private void Read()
        {
            if (File.Exists(Environment.CurrentDirectory + @"\input"))
            {
                Json.Clear();
                Input = File.ReadAllText(Environment.CurrentDirectory + @"\input");
            }
            else
                MessageBox.Show(Environment.CurrentDirectory + @"\input", "File not found");
        }
        public ICommand ClearCommand { get; private set; }
        private void Clear()
        {
            Json.Clear();
            Input = "";
        }
        #endregion

        #region Methods
        void Parse()
        {
            OutputVM.Clear();
            foreach (string json in Json)
            {
                try
                {
                    Item item = new JSON.Test.Data.Item();
                    object o = item.GetData(json);
                    if (o is Base<HouseItem>)
                    {
                        OutputVM.Tabs.Add(new HousesTab(OutputVM, (Base<HouseItem>)o));
                    }
                    else if (o is Base<UserItem>)
                    {
                        OutputVM.Tabs.Add(new UsersTab(OutputVM, (Base<UserItem>)o));
                    }
                    if (o is Base<AutorItem>)
                    {
                        OutputVM.Tabs.Add(new AutorTab(OutputVM, (Base<AutorItem>)o));
                    }
                    else if (o is Base<BookItem>)
                    {
                        OutputVM.Tabs.Add(new BookTab(OutputVM, (Base<BookItem>)o));
                    }
                    else
                        OutputVM.Tabs.Add(new UnrecognizedTab(OutputVM, json));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion
    }
}
