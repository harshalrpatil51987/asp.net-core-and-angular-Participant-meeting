
using System;
using Abp.Application.Services.Dto;

namespace eduvanz.Meetup.MeetupEvents.Dtos
{
    public class MeetupEventDto : EntityDto
    {
		public string FirstName { get; set; }

		public string MiddleName { get; set; }

		public string LastName { get; set; }

		public DateTime DOB { get; set; }

		public int Profession { get; set; }

		public string AddressLine1 { get; set; }

		public string AddressLine2 { get; set; }

		public int Country { get; set; }

		public int State { get; set; }

		public string City { get; set; }

		public string Pincode { get; set; }

		public int TotalGuest { get; set; }

		public string EntityType { get; set; }

		public string StateName { get; set; }

        public int Age { get; set; }

		public string ProfessionName { get; set; }

        public bool ParentUser { get; set; }

		public string GuestOf { get; set; }
	}
}