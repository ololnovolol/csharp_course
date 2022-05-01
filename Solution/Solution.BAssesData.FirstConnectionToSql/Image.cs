using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Solution.BAssesData.FirstConnectionToSql
{
    internal class Image
    {
        public int? Id { get; private set; }
        public string? Filename { get; }
        public string? FileName { get; private set; }
        public string? Title { get; private set; }
        public byte[] Data { get; private set; }

        public Image(int id, string filename, string title, byte[] data)
        {
            Id = id;
            Filename = filename;
            Title = title;
            Data = data;
        }
    }
}
