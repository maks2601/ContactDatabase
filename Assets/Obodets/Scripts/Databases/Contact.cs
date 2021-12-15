using SQLite;

namespace Obodets.Scripts.Databases
{
    public class Contact 
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
    }
}