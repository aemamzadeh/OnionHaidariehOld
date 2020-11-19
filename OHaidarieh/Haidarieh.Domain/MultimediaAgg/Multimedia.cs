using _0_Framework.Domain;
using Haidarieh.Domain.CeremonyAgg;
using Haidarieh.Domain.CeremonyGuestAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Haidarieh.Domain.MultimediaAgg
{
    public class Multimedia : EntityBase
    {
        public string Title { get; private set; }
        public string FileAddress { get; private set; }
        public string FileTitle { get; private set; }
        public string FileAlt { get; private set; }
        public bool Status { get; private set; }
        public long CeremonyId { get; private set; }
        public Ceremony Ceremony { get; private set; }

        public Multimedia(string title, string fileAddress, string fileTitle, string fileAlt,long ceremonyId)
        {
            Title = title;
            FileAddress = fileAddress;
            FileTitle = fileTitle;
            FileAlt = fileAlt;
            CeremonyId = ceremonyId;
            Status = true;

        }
        public void Edit(string title, string fileAddress, string fileTitle, string fileAlt, long ceremonyId)
        {
            Title = title;
            if(!string.IsNullOrWhiteSpace(fileAddress))
                FileAddress = fileAddress;
            FileTitle = fileTitle;
            FileAlt = fileAlt;
            CeremonyId = ceremonyId;
            Status = true;

        }
    }
}
