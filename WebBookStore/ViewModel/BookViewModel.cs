using WebBookStore.Models;

namespace WebBookStore.ViewModel
{
    public class BookViewModel
    {
        public IEnumerable<Books> Books { get; set; }

        public Books BookDetail { get; set; }
        public Publisher Publishers{ get; set; }

        public Category Categories { get; set; }

        public string categoryName { get; set; }
    }
}
