using Haidarieh.Application.Contracts.Guest;

namespace Haidarieh.Application.Contracts.CeremonyGuest
{
    public class EditCeremonyGuest : CreateCeremonyGuest
    {
        public long Id { get; set; }        
    }
}