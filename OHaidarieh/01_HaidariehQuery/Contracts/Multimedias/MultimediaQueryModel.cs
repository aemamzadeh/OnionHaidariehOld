using System;
using System.Collections.Generic;
using System.Text;

namespace _01_HaidariehQuery.Contracts.Multimedias
{
    public class MultimediaQueryModel
    {
        public long Id { get; set; }
        public string Title { get;  set; }
        public string FileAddress { get;  set; }
        public string FileTitle { get;  set; }
        public string FileAlt { get;  set; }
        public bool Status { get;  set; }
        public DateTime CeremonyDate { get; set; }
        public string Slug { get; set; }
    }
}
