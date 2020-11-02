using Abp.Application.Services.Dto;
using System;

namespace eduvanz.Meetup.MeetupEvents.Dtos
{
    public class GetAllMeetupEventsForExcelInput
    {
		public string Filter { get; set; }

		public int? MaxProfessionFilter { get; set; }
		public int? MinProfessionFilter { get; set; }



    }
}