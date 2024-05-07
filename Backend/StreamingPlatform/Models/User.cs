using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using StreamingPlatform.Dao.Properties;
using StreamingPlatform.Models.Enums;

namespace StreamingPlatform.Models
{
    /// <summary>
    /// Represents a User.
    /// </summary>
    public class User : IdentityUser
    {
        public User()
        {
            this.UserName = string.Empty;
            this.Email = string.Empty;
            this.Name = string.Empty;
            this.Age = 0;
            this.Address = string.Empty;
            this.CreateOn = DateTime.Now;
        }

        public User(string username, string email, string name, int age, string address, string pepper)
        {
            this.Id = Guid.NewGuid().ToString();
            this.UserName = username;
            this.Email = email;
            this.Name = name;
            this.Age = age;
            this.Address = address;
            this.CreateOn = DateTime.Now;
        }

        /// <summary>
        /// The user's password.
        /// </summary>
        //public Password Password { get; set; }

        /// <summary>
        /// The user's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The user's age.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// The user's address.
        /// </summary>
        [SecureProperty]
        public string Address { get; set; }

        /// <summary>
        /// The user's role.
        /// </summary>
        //public Role Role { get; set; }

        /// <summary>
        /// The user's registration date.
        /// </summary>
        public DateTime CreateOn { get; set; }
    }
}