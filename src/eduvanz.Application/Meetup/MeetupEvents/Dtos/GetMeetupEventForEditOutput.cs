using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace eduvanz.Meetup.MeetupEvents.Dtos
{
    public class GetMeetupEventForEditOutput
    {
		public CreateOrEditMeetupEventDto MeetupEvent { get; set; }


    }
}