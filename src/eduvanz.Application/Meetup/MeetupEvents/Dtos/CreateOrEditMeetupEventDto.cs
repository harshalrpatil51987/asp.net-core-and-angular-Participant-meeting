
using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace eduvanz.Meetup.MeetupEvents.Dtos
{
    public class CreateOrEditMeetupEventDto : EntityDto<int?>
    {

		[Required]
		[StringLength(MeetupEventConsts.MaxFirstNameLength, MinimumLength = MeetupEventConsts.MinFirstNameLength)]
		public string FirstName { get; set; }
		
		
		[StringLength(MeetupEventConsts.MaxMiddleNameLength, MinimumLength = MeetupEventConsts.MinMiddleNameLength)]
		public string MiddleName { get; set; }
		
		
		[Required]
		[StringLength(MeetupEventConsts.MaxLastNameLength, MinimumLength = MeetupEventConsts.MinLastNameLength)]
		public string LastName { get; set; }
		
		
		public DateTime DOB { get; set; }
		
		
		public int Profession { get; set; }
		
		
		[Required]
		[StringLength(MeetupEventConsts.MaxAddressLine1Length, MinimumLength = MeetupEventConsts.MinAddressLine1Length)]
		public string AddressLine1 { get; set; }
		
		
		[StringLength(MeetupEventConsts.MaxAddressLine2Length, MinimumLength = MeetupEventConsts.MinAddressLine2Length)]
		public string AddressLine2 { get; set; }
		
		
		public int Country { get; set; }
		
		
		public int State { get; set; }
		
		
		[Required]
		[StringLength(MeetupEventConsts.MaxCityLength, MinimumLength = MeetupEventConsts.MinCityLength)]
		public string City { get; set; }
		
		
		[Required]
		[StringLength(MeetupEventConsts.MaxPincodeLength, MinimumLength = MeetupEventConsts.MinPincodeLength)]
		public string Pincode { get; set; }
		
		
		[Range(MeetupEventConsts.MinTotalGuestValue, MeetupEventConsts.MaxTotalGuestValue)]
		public int TotalGuest { get; set; }

        public bool ParentUser { get; set; }

        public int Age { get; set; }
    }
}