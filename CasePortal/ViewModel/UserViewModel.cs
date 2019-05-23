using System;
using System.ComponentModel;

namespace CasePortal.ViewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
        public Nullable<int> ImageId { get; set; }
        [DisplayName("Image")]
        public string ImagePath { get; set; }
    }
}