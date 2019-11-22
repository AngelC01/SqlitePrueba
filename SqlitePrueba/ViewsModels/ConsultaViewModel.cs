using GalaSoft.MvvmLight.Command;
using SqlitePrueba.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SqlitePrueba.ViewsModels
{
   public class ConsultaViewModel:BaseViewModel

   {
        #region Atributos
        private ObservableCollection<User> usersCollection;
        private ObservableCollection<User2> users2Collection;
        private ImageSource imageProf;
        private User2 selectedUser;

        #endregion

        #region Propiedades
        public ImageSource ImageProf
        {
            get { return this.imageProf; }
            set { SetValue(ref this.imageProf, value); }

        }
        public ObservableCollection<User> UsersColleciton
        {

            get { return this.usersCollection; }
            set { SetValue(ref this.usersCollection, value); }
        }
        public User2 SelectedUser
        {
            get { return selectedUser; }
            set
            {
                if (selectedUser != value)
                {
                    selectedUser = value;
                    HandleSelectedItem();
                }
            }
        }
        public ObservableCollection<User2> Users2Colleciton
        {

            get { return this.users2Collection; }
            set { SetValue(ref this.users2Collection, value); }
        }
        #endregion

        #region Metodos
        private async void HandleSelectedItem()
        {
            await Application.Current.MainPage.DisplayAlert(
                  "Usuario",
                  SelectedUser.NombreCompleto + "" + SelectedUser.Id,
                  "Aceptar");
            return;

        }
        public void LoadUsers()
        {
            var allUsers = UserRepository.Instancia.GetAllUsers();

            this.UsersColleciton = new ObservableCollection<User>(allUsers);
            this.Users2Colleciton = new ObservableCollection<User2>();
            this.UsersColleciton.Select(u => new User2
            {
                Name = u.Name,
                LastName=u.LastName,
                NombreCompleto=u.Name +" "+ u.LastName,
                Id=u.Id,
                Stream1= new MemoryStream(u.ImageProfile),
                ImgProfile=ImageSource.FromStream(()=>Stream)



             });;
            for (int i = 0; i < this.UsersColleciton.Count; i++)
            {
                User2 userItem = new User2();
                userItem.Name = this.UsersColleciton[i].Name;
                userItem.LastName = this.UsersColleciton[i].LastName;
                userItem.Id = this.UsersColleciton[i].Id;
                userItem.NombreCompleto = this.UsersColleciton[i].Name + " " + this.UsersColleciton[i].LastName;


                var stream1 = new MemoryStream(this.UsersColleciton[i].ImageProfile);

                userItem.ImgProfile = ImageSource.FromStream(() => stream1);

               
                this.Users2Colleciton.Add(userItem);

            }
        }
        #endregion

        #region Comandos
        public ICommand MenuCCommand
        {
            get
            {
                return new RelayCommand(MenuC);
            }

        }

        private  void MenuC()
        {
           

            Console.WriteLine("HOLAAAAAA XDDDD");
            
        }

        #endregion

        public ConsultaViewModel()
            {

                LoadUsers();
            
            }

   }
}
