using Abp.Application.Services.Dto;

namespace eduvanz.Meetup.MeetupEvents.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
		public string Filter { get; set; }
    }
}