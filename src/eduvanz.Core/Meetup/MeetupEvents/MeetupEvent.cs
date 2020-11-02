using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace eduvanz.Meetup.MeetupEvents
{
	[Table("MeetupEvents")]
    public class MeetupEvent : FullAuditedEntity
	{
	
		[Required]
		[StringLength(MeetupEventConsts.MaxFirstNameLength, MinimumLength = MeetupEventConsts.MinFirstNameLength)]
		public virtual string FirstName { get; set; }
		
		[StringLength(MeetupEventConsts.MaxMiddleNameLength, MinimumLength = MeetupEventConsts.MinMiddleNameLength)]
		public virtual string MiddleName { get; set; }
		
		[Required]
		[StringLength(MeetupEventConsts.MaxLastNameLength, MinimumLength = MeetupEventConsts.MinLastNameLength)]
		public virtual string LastName { get; set; }
		
		public virtual DateTime DOB { get; set; }
		
		public virtual int Profession { get; set; }
		
		[Required]
		[StringLength(MeetupEventConsts.MaxAddressLine1Length, MinimumLength = MeetupEventConsts.MinAddressLine1Length)]
		public virtual string AddressLine1 { get; set; }
		
		[StringLength(MeetupEventConsts.MaxAddressLine2Length, MinimumLength = MeetupEventConsts.MinAddressLine2Length)]
		public virtual string AddressLine2 { get; set; }
		
		public virtual int Country { get; set; }
		
		public virtual int State { get; set; }
		
		[Required]
		[StringLength(MeetupEventConsts.MaxCityLength, MinimumLength = MeetupEventConsts.MinCityLength)]
		public virtual string City { get; set; }
		
		[Required]
		[StringLength(MeetupEventConsts.MaxPincodeLength, MinimumLength = MeetupEventConsts.MinPincodeLength)]
		public virtual string Pincode { get; set; }
		
		[Range(MeetupEventConsts.MinTotalGuestValue, MeetupEventConsts.MaxTotalGuestValue)]
		public virtual int TotalGuest { get; set; }
		
		public virtual bool ParentUser { get; set; }


	}
}