using PeopleList.Data;

namespace PeopleList.Web.Models
{
    public class PeopleViewModel
    {
        public List<Person> People { get; set; }
        public string Message { get; set; }
    }
}
