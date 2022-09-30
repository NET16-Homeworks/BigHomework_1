namespace BigHomework_1.Classes
{
    internal class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public User(string fitstName, string lastName, string email, int age)
        {
            FirstName = fitstName;
            LastName = lastName;
            Email = email;
            Age = age;
        }
    }
}
