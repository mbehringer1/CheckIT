using System.Collections.Generic;

namespace CheckIT.Configuration.Extensions
{
    public static class VolumeAppender
    {
        public static void AddBook(this Dictionary<string,Dictionary<string,string>> volume, Dictionary<string, string> book)
        {
            string index = book["index"];
            book.Remove("index");
            volume.Add(index, book);
        }
    }
}
