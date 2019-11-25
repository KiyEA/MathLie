
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Transport1.Services;
using Xamarin.Forms;

namespace Transport1.ViewModel
{
    class RegisterViewModel
    {
       readonly ApiService apiService = new ApiService();
        public string Email { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }
        public string ConfirmPassword { get; set; }

        public bool IsDriver { get; set; }
        public ICommand RerigesterCommand
        {
            get
            {
                return new Command(async() =>
                {
                    var isSuccess = await apiService.RegisterAsync(Email, Password, ConfirmPassword);
                    if (isSuccess)
                        Message = "Register Successfully";
                    else Message = "Retry later";
                });
            }
        }
    }
}
