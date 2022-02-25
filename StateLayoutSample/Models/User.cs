namespace StateLayoutSample.Models
{
    public class User
    {
        public User(string name, string photo, string phone, string email)
        {
            Name = name;
            Photo = photo;
            Phone = phone;
            Email = email;
        }

        public string Name { get; }
        public string Photo { get; }
        public string Phone { get; }
        public string Email { get; }
    }
}
