
public class User 
{
    public int OwnerID { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Password { get; set; }

    public User(int ownerID, string firstname, string lastname, string password)
    {
        OwnerID = ownerID;
        Firstname = firstname;
        Lastname = lastname;
        Password = password;

    }

}

