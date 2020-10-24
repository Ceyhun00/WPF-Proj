using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows;
using System.Windows.Input;
using JSON.Test.Data;

namespace JSON.Test.ViewModel
{
    public abstract class TabVM : ViewModelBase
    {
        
        #region Fields
        int CurrentUserIndex { get; set; }
        int CurrentBookIndex { get; set; }
        #endregion

        #region Binding Property
        Base<UserItem> usersVM;
        public Base<UserItem> UsersVM
        {
            get { return usersVM; }
            set
            {
                usersVM = value;
                Set("UsersVM", ref value);
            }
            
        }
        Base<HouseItem> housesVM;
        public Base<HouseItem> HousesVM
        {
            get { return housesVM; }
            set
            {
                housesVM = value;
                Set("HousesVM", ref value);
            }
        }
        Base<AutorItem> autorsVM;
        public Base<AutorItem> AutorsVM
        {
            get { return autorsVM; }
            set
            {
                autorsVM = value;
                Set("AutorsVM", ref value);
            }

        }
        Base<BookItem> booksVM;
        public Base<BookItem> BooksVM
        {
            get { return booksVM; }
            set
            {
                booksVM = value;
                Set("BooksVM", ref value);
            }

        }
        UnrecognizedItem unrecognizedVM;
        public UnrecognizedItem UnrecognizedVM
        {
            get { return unrecognizedVM; }
            set
            {
                unrecognizedVM = value;
                Set("UnrecognizedVM", ref value);
            }
        }

        public string TabHeader { get; }
        public OutputViewModel OutputVM { get; }
        #endregion

        #region Constructor
        public TabVM(string header, OutputViewModel outputVM)
        {
            TabHeader = header;
            OutputVM = outputVM;
            CloseTabCommand = new RelayCommand(CloseTab);
            DeleteCommand = new RelayCommand<object>(Delete);
            AddItemCommand = new RelayCommand(AddItem);
            AddPhoneCommand = new RelayCommand<object>(AddPhone);
            DeletePhoneCommand = new RelayCommand<object>(DeletePhone);
            UserSelectionCommand = new RelayCommand<object>(ChangeSelectedUser);
            BookSelectionCommand = new RelayCommand<object>(ChangeSelectedBook);
            AddAutorCommand = new RelayCommand<object>(AddAutor);
        }

        private void ChangeSelectedBook(object obj)
        {
            CurrentBookIndex = (int)obj;
            //throw new NotImplementedException();
        }

        #endregion

        #region Commands

        
        public ICommand CloseTabCommand { get; private set; }
        public virtual void CloseTab()
        {
            OutputVM.Tabs.Remove(this);
        }
        public ICommand DeleteCommand { get; private set; }
        private void Delete(object obj)
        {
            if (UsersVM != null)
            {
                Base<UserItem> tmp = new Base<UserItem>();
                tmp.Q = UsersVM.Q;
                tmp.R = UsersVM.R;
                tmp.T = UsersVM.T;
                tmp.D = new D<UserItem>();
                tmp.D.count = UsersVM.D.count;
                tmp.D.items = new List<UserItem>();
                UsersVM.D.items.RemoveAt((int)obj);
                foreach (UserItem item in UsersVM.D.items)
                {
                    UserItem itmp = new UserItem();
                    itmp.group = item.group;
                    itmp.login = item.login;
                    itmp.name = item.name;
                    itmp.phones = item.phones;
                    tmp.D.items.Add(itmp);
                }
                UsersVM = tmp;
            }
            else if (HousesVM != null)
            {
                Base<HouseItem> tmp = new Base<HouseItem>();
                tmp.Q = HousesVM.Q;
                tmp.R = HousesVM.R;
                tmp.T = HousesVM.T;
                tmp.D = new D<HouseItem>();
                tmp.D.count = HousesVM.D.count;
                tmp.D.items = new List<HouseItem>();
                HousesVM.D.items.RemoveAt((int)obj);
                foreach (HouseItem item in HousesVM.D.items)
                {
                    HouseItem itmp = new HouseItem();
                    itmp.address = item.address;
                    itmp.flors = item.flors;
                    itmp.name = item.name;
                    itmp.type = item.type;
                    tmp.D.items.Add(itmp);
                }
                HousesVM = tmp;
            }
        }
        public ICommand AddItemCommand { get; private set; }
        private void AddItem()
        {
           
            if (UsersVM != null)
            {
                Base<UserItem> tmp = new Base<UserItem>();
                tmp.Q = UsersVM.Q;
                tmp.R = UsersVM.R;
                tmp.T = UsersVM.T;
                tmp.D = new D<UserItem>();
                tmp.D.count = UsersVM.D.count;
                tmp.D.items = new List<UserItem>();
                foreach (UserItem item in UsersVM.D.items)
                {
                    UserItem itmp = new UserItem();
                    itmp.group = item.group;
                    itmp.login = item.login;
                    itmp.name = item.name;
                    itmp.phones = item.phones;
                    tmp.D.items.Add(itmp);
                }
                tmp.D.items.Add(new UserItem());
                UsersVM = tmp;
            }
            if (HousesVM != null)
            {
                Base<HouseItem> tmp = new Base<HouseItem>();
                tmp.Q = HousesVM.Q;
                tmp.R = HousesVM.R;
                tmp.T = HousesVM.T;
                tmp.D = new D<HouseItem>();
                tmp.D.count = HousesVM.D.count;
                tmp.D.items = new List<HouseItem>();
                foreach (HouseItem item in HousesVM.D.items)
                {
                    HouseItem itmp = new HouseItem();
                    itmp.name = item.name;
                    itmp.address = item.address;
                    itmp.name = item.name;
                    itmp.flors = item.flors;
                    itmp.type = item.type;
                    tmp.D.items.Add(itmp);
                }
                tmp.D.items.Add(new HouseItem());
                HousesVM = tmp;
            }
            else if (BooksVM != null)
            {
                Base<BookItem> tmp = new Base<BookItem>();
                tmp.Q = BooksVM.Q;
                tmp.R = BooksVM.R;
                tmp.T = BooksVM.T;
                tmp.D = new D<BookItem>();
                tmp.D.count = BooksVM.D.count;
                tmp.D.items = new List<BookItem>();
                foreach (BookItem item in BooksVM.D.items)
                {
                    BookItem itmp = new BookItem();
                    itmp.name = item.name;
                    itmp.id = item.id;
                    tmp.D.items.Add(itmp);
                }
                tmp.D.items.Add(new BookItem());
                BooksVM = tmp;
            }
            else if (AutorsVM != null)
            {
                Base<AutorItem> tmp = new Base<AutorItem>();
                tmp.Q = AutorsVM.Q;
                tmp.R = AutorsVM.R;
                tmp.T = AutorsVM.T;
                tmp.D = new D<AutorItem>();
                tmp.D.count = AutorsVM.D.count;
                tmp.D.items = new List<AutorItem>();
                foreach (AutorItem item in AutorsVM.D.items)
                {
                    AutorItem itmp = new AutorItem();
                    itmp.name = item.name;
                    itmp.id = item.id;
                    tmp.D.items.Add(itmp);
                }
                tmp.D.items.Add(new AutorItem());
                AutorsVM = tmp;
            }
        }

        public ICommand AddAutorCommand { get; private set; }
        private void AddAutor(object obj)
        {
            if (BooksVM != null)
            {
                Base<BookItem> tmp = new Base<BookItem>();
                tmp.Q = BooksVM.Q;
                tmp.R = BooksVM.R;
                tmp.T = BooksVM.T;
                tmp.D = new D<BookItem>();
                tmp.D.count = BooksVM.D.count;
                tmp.D.items = new List<BookItem>();
                foreach (BookItem item in BooksVM.D.items)
                {
                    BookItem itmp = new BookItem();
                    itmp.id = item.id;
                    itmp.name = item.name;
                    itmp.AutorItems = item.AutorItems;
                    tmp.D.items.Add(itmp);
                }
                if (tmp.D.items[(int)obj].AutorItems == null)
                {
                    tmp.D.items[(int)obj].AutorItems = new List<AutorItem>();
                }
                int lastId = 0;
                foreach (AutorItem phone in tmp.D.items[(int)obj].AutorItems)
                {
                    if (phone.id > lastId) lastId = phone.id;
                }
                AutorItem newPhone = new AutorItem();
                newPhone.id = lastId + 1;
                tmp.D.items[(int)obj].AutorItems.Add(newPhone);
                BooksVM = tmp;
            }
        }
        public ICommand AddPhoneCommand { get; private set; }
        private void AddPhone(object obj)
        {
            if (UsersVM != null)
            {
                Base<UserItem> tmp = new Base<UserItem>();
                tmp.Q = UsersVM.Q;
                tmp.R = UsersVM.R;
                tmp.T = UsersVM.T;
                tmp.D = new D<UserItem>();
                tmp.D.count = UsersVM.D.count;
                tmp.D.items = new List<UserItem>();
                foreach (UserItem item in UsersVM.D.items)
                {
                    UserItem itmp = new UserItem();
                    itmp.group = item.group;
                    itmp.login = item.login;
                    itmp.name = item.name;
                    itmp.phones = item.phones;
                    tmp.D.items.Add(itmp);
                }
                if (tmp.D.items[(int)obj].phones == null)
                {
                    tmp.D.items[(int)obj].phones = new List<PhoneItem>();
                }
                int lastId = 0;
                foreach (PhoneItem phone in tmp.D.items[(int)obj].phones)
                {
                    if (phone.id > lastId) lastId = phone.id;
                }
                PhoneItem newPhone = new PhoneItem();
                newPhone.id = lastId + 1;
                tmp.D.items[(int)obj].phones.Add(newPhone);
                UsersVM = tmp;
            }
        }
        public ICommand DeletePhoneCommand { get; private set; }
        private void DeletePhone(object obj)
        {
            if (UsersVM != null)
            {
                Base<UserItem> tmp = new Base<UserItem>();
                tmp.Q = UsersVM.Q;
                tmp.R = UsersVM.R;
                tmp.T = UsersVM.T;
                tmp.D = new D<UserItem>();
                tmp.D.count = UsersVM.D.count;
                tmp.D.items = new List<UserItem>();
                foreach (UserItem item in UsersVM.D.items)
                {
                    UserItem itmp = new UserItem();
                    itmp.group = item.group;
                    itmp.login = item.login;
                    itmp.name = item.name;
                    itmp.phones = item.phones;
                    tmp.D.items.Add(itmp);
                }
                tmp.D.items[CurrentUserIndex].phones.RemoveAt((int)obj);
                UsersVM = tmp;
            }
        }
        public ICommand UserSelectionCommand { get; private set; }
        public ICommand BookSelectionCommand { get; private set; }

        private void ChangeSelectedUser(object obj)
        {
            CurrentUserIndex = (int)obj;
        }
        #endregion
    }

    public class StartTab : TabVM
    {
        #region Constructor
        public StartTab(OutputViewModel outputVM) : base("Стартовая страница", null)
        {
        }
        #endregion

        #region Override Command
        public override void CloseTab()
        {
            MessageBox.Show("Ничего не выйдет");
        }
        #endregion
    }
    public class HousesTab : TabVM
    {
        #region Constructor
        public HousesTab(OutputViewModel outputVM, Base<HouseItem> housesVM) : base("Адреса", outputVM)
        {
            if (housesVM.D == null)
            {
                housesVM.Q = "HOUSES";
                housesVM.D = new D<HouseItem>();
                housesVM.D.items = new List<HouseItem>();
            }
            HousesVM = housesVM;
            OutputVM.RecognizedCount = ((int.Parse(OutputVM.RecognizedCount)) + 1).ToString();
        }
        #endregion
    }

    public class UsersTab : TabVM
    {
        #region Constructor
        public UsersTab(OutputViewModel outputVM, Base<UserItem> usersVM) : base("Пользователи", outputVM)
        {
            if (usersVM.D == null)
            {
                usersVM.Q = "USERS";
                usersVM.D = new D<UserItem>();
                usersVM.D.items = new List<UserItem>();
            }
            UsersVM = usersVM;
            OutputVM.RecognizedCount = ((int.Parse(OutputVM.RecognizedCount)) + 1).ToString();
        }
        #endregion
    }
    public class AutorTab : TabVM
    {
        #region Constructor
        public AutorTab(OutputViewModel outputVM, Base<AutorItem> autorsVM) : base("Авторы", outputVM)
        {
            if (autorsVM.D == null)
            {
                autorsVM.Q = "AUTORS";
                autorsVM.D = new D<AutorItem>();
                autorsVM.D.items = new List<AutorItem>();
            }
            AutorsVM = autorsVM;
            OutputVM.RecognizedCount = ((int.Parse(OutputVM.RecognizedCount)) + 1).ToString();
        }
        #endregion
    }
    public class BookTab : TabVM
    {
        #region Constructor
        public BookTab(OutputViewModel outputVM, Base<BookItem> booksVM) : base("Книги", outputVM)
        {
            if (booksVM.D == null)
            {
                booksVM.Q = "BOOKS";
                booksVM.D = new D<BookItem>();
                booksVM.D.items = new List<BookItem>();
            }
            BooksVM = booksVM;
            OutputVM.RecognizedCount = ((int.Parse(OutputVM.RecognizedCount)) + 1).ToString();
        }
        #endregion
    }
    public class UnrecognizedTab : TabVM
    {
        #region Constructor
        public UnrecognizedTab(OutputViewModel outputVM, string input) : base("Данные", outputVM)
        {
            UnrecognizedVM = new UnrecognizedItem(input);
        }
        #endregion
    }

    public class OutputViewModel : ViewModelBase
    {
        #region Binding Property



        string recognizedCount = "0";
        public string RecognizedCount
        {
            get { return recognizedCount; }
            set
            {
                recognizedCount = value;
                Set("RecognizedCount", ref value);
            }
        }
        private ObservableCollection<TabVM> tabs;
        public ObservableCollection<TabVM> Tabs
        {
            get { return tabs ?? (tabs = new ObservableCollection<TabVM>()); }
        }
        private TabVM selectedTab;
        public TabVM SelectedTab
        {
            get { return selectedTab; }
            set
            {
                selectedTab = value;
                Set("SelectedTab", ref value);
            }
        }
        #endregion

        #region Constructor
        public OutputViewModel()
        {
            AddAutorCommand = new RelayCommand(AddAutor);
            AddBookCommand = new RelayCommand(AddBook);
            AddUserCommand = new RelayCommand(AddUser);
            AddHouseCommand = new RelayCommand(AddHouse);
            SaveCommand = new RelayCommand(Save);
            SaveBdCommand = new RelayCommand(SaveBd);
            Clear();


            AutorItem.Autors.Add(new AutorItem(){name="Fedya"});
            AutorItem.Autors.Add(new AutorItem() { name = "Kolya" });
        }
        #endregion

        #region Commands
        public ICommand AddAutorCommand { get; private set; }
        public void AddAutor()
        {
            Tabs.Add(new AutorTab(this, new Base<AutorItem>()));
        }
        public ICommand AddBookCommand { get; private set; }
        public void AddBook()
        {
            Tabs.Add(new BookTab(this, new Base<BookItem>()));
        }
        public ICommand AddUserCommand { get; private set; }
        private void AddUser()
        {
            Tabs.Add(new UsersTab(this, new Base<UserItem>()));
        }
        public ICommand AddHouseCommand { get; private set; }
        private void AddHouse()
        {
            Tabs.Add(new HousesTab(this, new Base<HouseItem>()));
        }
        public ICommand SaveCommand { get; private set; }

        private void Save()
        {
           
                if (Tabs.Count > 0)
                {
                    System.IO.File.WriteAllText(Environment.CurrentDirectory + @"\output", "-----\r\n");
                    foreach (TabVM tab in Tabs)
                    {
                        if (tab is UnrecognizedTab)
                        {
                            System.IO.File.AppendAllText(Environment.CurrentDirectory + @"\output",
                                tab.UnrecognizedVM.Input);
                        }
                        else if (tab is UsersTab)
                        {
                            string data = JsonConvert.SerializeObject(tab.UsersVM);
                            System.IO.File.AppendAllText(Environment.CurrentDirectory + @"\output", data);
                        }
                        else if (tab is HousesTab)
                        {
                            string data = JsonConvert.SerializeObject(tab.HousesVM);
                            System.IO.File.AppendAllText(Environment.CurrentDirectory + @"\output", data);
                        }
                        else if (tab is AutorTab)
                        {

                            string data = JsonConvert.SerializeObject(tab.AutorsVM);
                            System.IO.File.AppendAllText(Environment.CurrentDirectory + @"\output", data);
                        }
                        else if (tab is BookTab)
                        {
                            string data = JsonConvert.SerializeObject(tab.BooksVM);
                            System.IO.File.AppendAllText(Environment.CurrentDirectory + @"\output", data);
                        }

                        System.IO.File.AppendAllText(Environment.CurrentDirectory + @"\output", "\r\n/-----\r\n");
                    }

                    MessageBox.Show(Environment.CurrentDirectory + @"\output", "Запрос сформирован");
                }
                else
                    MessageBox.Show("Запрос не был сформирован");
            
        }
        public ICommand SaveBdCommand { get; private set; }
        private void SaveBd()
        {
            using (var db = new LibraryContext())
            {
                if (Tabs.Count > 0)
                {

                    foreach (TabVM tab in Tabs)
                    {
                        if (tab is AutorTab)
                        {
                            var test = tab.AutorsVM;
                            var parameters=new Base{Q = test.Q,R = test.R,T = test.T};
                            db.baseParameters.Add(parameters);
                            foreach (var d in test.D.items)
                            {
                                
                                var autor = new Author{id=d.id,name =d.name};
                                db.Authors.Add(autor);
                            }
                        }
                        else if (tab is BookTab)
                        {
                            var test = tab.BooksVM;
                            var parameters = new Base { Q = test.Q, R = test.R, T = test.T };
                            db.baseParameters.Add(parameters);
                            var autors=new List<Author>();
                            foreach (var d in test.D.items)
                            {
                                var book = new Book() { id = d.id, name = d.name };
                                if (d.AutorItems != null)
                                {
                                    foreach (var item in d.AutorItems)
                                    {
                                        var authorId = item.id;
                                        var author = db.Authors.First(x => x.id == authorId);
                                        autors.Add(author);
                                    }
                                    book.authors = autors;
                                }
                                db.Books.Add(book);
                            }
                        }
                    }
                    db.SaveChanges();
                    MessageBox.Show("Успех"); ;
                }
                else
                    MessageBox.Show("Запрос не был сформирован");
            }
        }

        #endregion

        #region Methods
        public void Clear()
        {
            Tabs.Clear();
            Tabs.Add(new StartTab(this));
            SelectedTab = Tabs.Last();
            RecognizedCount = "0";
        }
        #endregion
    }
}
