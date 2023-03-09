namespace MVC_API_Test.Models
{
    public class APIUser
    {
        // ATTRIBUTES
        public int id { get; private set; }
        public string first_name { get; private set; }
        public string last_name { get; private set; }
        public string email { get; private set; }
        public string avatar { get; private set; }

        // CONSTRUCTOR I
        public APIUser(int id, string first_name, string last_name, string email, string avatar)
        {
            this.id = id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.email = email;
            this.avatar = avatar;
        }

        // DISPLAY FULL NAME
        public string DisplayFullName()
        {
            return first_name + " " + last_name;
        }
    }
}
