using System;
using System.Collections.Generic;
using System.Text;

namespace _01_HaidariehQuery.Contracts.Multimedias
{
    public class MultimediaQueryModel
    {
        public string Title { get;  set; }
        public string FileAddress { get;  set; }
        public string FileTitle { get;  set; }
        public string FileAlt { get;  set; }
        public bool Status { get;  set; }
        public long CeremonyGuestId { get;  set; }
    }
}
