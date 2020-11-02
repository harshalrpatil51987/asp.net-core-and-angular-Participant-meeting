
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Application.Services.Dto;
using Microsoft.EntityFrameworkCore;
using eduvanz.Meetup.MeetupEvents;
using eduvanz.Meetup.MeetupEvents.Dtos;
using Abp.AutoMapper;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace eduvanz.MeetupEvents
{
	public class statelist
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }
    public class MeetupEventsAppService : eduvanzAppServiceBase, IMeetupEventsAppService
    {
       
        private readonly IRepository<MeetupEvent> _meetupEventRepository;
        private readonly IRepository<StateMaster> _statemasterRepository;

        public MeetupEventsAppService(IRepository<MeetupEvent> meetupEventRepository, IRepository<StateMaster> statemasterRepository)
        {
            _meetupEventRepository = meetupEventRepository;
            _statemasterRepository = statemasterRepository;
        }


        public async Task<List<StateMaster>> getstates()
        {
            var _statemaster = _statemasterRepository.GetAll().ToList();
            return _statemaster;
        }

         public async Task<List<MeetupEventDto>> GetAll()
         {
            List<MeetupEvent> filteredMeetupEvents = new List<MeetupEvent>();
            if (AbpSession.UserId == 2)
                 filteredMeetupEvents =await _meetupEventRepository.GetAll().OrderBy(s=>s.Id).ThenBy(s=>s.CreatorUserId).ToListAsync();
            else
                filteredMeetupEvents = await _meetupEventRepository.GetAll().Where(s => s.CreatorUserId == AbpSession.UserId).OrderBy(s => s.Id).ToListAsync();

            var meetupEvents = (from o in filteredMeetupEvents
                               select new MeetupEventDto() {							
                                FirstName = o.FirstName,
                                MiddleName = o.MiddleName,
                                LastName = o.LastName,
                                DOB = o.DOB,
                                ProfessionName = o.Profession == 1 ? "Employed" : "Student",
                                AddressLine1 = o.AddressLine1,
                                AddressLine2 = o.AddressLine2,
                                Country = o.Country,
                                State = o.State,
                                City = o.City,
                                Pincode = o.Pincode,
                                TotalGuest = o.TotalGuest,
                                Id = o.Id,
                                ParentUser=o.ParentUser,
                                EntityType=o.ParentUser==true ? "Participant" : "Guest",
                                Age=DateTime.Today.Year- o.DOB.Year,
                                StateName=_statemasterRepository.GetAll().Where(s=>s.Id==o.State).Select(s=>s.Name).FirstOrDefault(),
                                GuestOf= (o.ParentUser == false && AbpSession.UserId==2) ? "(of "+ _meetupEventRepository.GetAll().Where(s=>s.ParentUser==true && s.CreatorUserId==o.CreatorUserId).Select(s=>s.FirstName+" "+s.LastName).FirstOrDefault() +")" : ""
                               }).ToList();
            return meetupEvents;
         }
		 
		
		 
		 public async Task<List<CreateOrEditMeetupEventDto>> GetMeetupEventForEdit(EntityDto input)
         {
           
                var creatorid = await _meetupEventRepository.GetAll().Where(s => s.Id == input.Id).Select(s => s.CreatorUserId).FirstOrDefaultAsync();
               var meetupEvent = await _meetupEventRepository.GetAll().Where(s => s.CreatorUserId == creatorid).ToListAsync();
           

            
            var output = (from o in meetupEvent
                          select new CreateOrEditMeetupEventDto()
                                {
                                    FirstName = o.FirstName,
                                    MiddleName = o.MiddleName,
                                    LastName = o.LastName,
                                    DOB = o.DOB,
                                    Profession = o.Profession,
                                    AddressLine1 = o.AddressLine1,
                                    AddressLine2 = o.AddressLine2,
                                    Country = o.Country,
                                    State = o.State,
                                    City = o.City,
                                    Pincode = o.Pincode,
                                    TotalGuest = o.TotalGuest,
                                    Id = o.Id,
                                    ParentUser = o.ParentUser,
                                    Age = DateTime.Today.Year - o.DOB.Year
                                }).ToList();

            return output;
         }

		 public async Task CreateOrEdit(CreateOrEditMeetupEventDto input)
         {
           
            if(input.Id == null || input.Id == 0)
            {
               await Create(input,true);
			}
			else{
                await Update(input);               
            }           
         }

        public async Task CreateOrEditList(List<CreateOrEditMeetupEventDto> inputdata)
        {
            foreach(var input in inputdata)
            {
                if (input.Id == null || input.Id == 0)
                {
                    await Create(input,false);
                }
                else
                {
                    await Update(input);
                }
            }
        }



         protected virtual async Task Create(CreateOrEditMeetupEventDto input,bool puser)
         {
            var meetupEvent = new MeetupEvent()
            {
                AddressLine1 = input.AddressLine1,
                AddressLine2 = input.AddressLine2,
                City = input.City,
                Country = input.Country,
                CreationTime = DateTime.Now,
                CreatorUserId=AbpSession.UserId,
                DOB=input.DOB,
                FirstName=input.FirstName,
                MiddleName=input.MiddleName,
                LastName=input.LastName,
                Pincode=input.Pincode,
                State=input.State,
                Profession=input.Profession,
                TotalGuest=input.TotalGuest,
                ParentUser= puser
            };
            await _meetupEventRepository.InsertAsync(meetupEvent);         
         }
      

        protected virtual async Task Update(CreateOrEditMeetupEventDto input)
         {
            var meetupEvent = await _meetupEventRepository.FirstOrDefaultAsync((int)input.Id);
            meetupEvent.AddressLine1 = input.AddressLine1;
                meetupEvent.AddressLine2 = input.AddressLine2;
                meetupEvent.City = input.City;
                meetupEvent.Country = input.Country;
                meetupEvent.CreationTime = DateTime.Now;
                meetupEvent.CreatorUserId = AbpSession.UserId;
                meetupEvent.DOB = input.DOB;
                meetupEvent.FirstName = input.FirstName;
                meetupEvent.MiddleName = input.MiddleName;
                meetupEvent.LastName = input.LastName;
                meetupEvent.Pincode = input.Pincode;
                meetupEvent.State = input.State;
                meetupEvent.Profession = input.Profession;
                meetupEvent.TotalGuest = input.TotalGuest;
                meetupEvent.ParentUser = input.ParentUser;
                meetupEvent.Id = input.Id.Value;
                meetupEvent.LastModificationTime = DateTime.Now;
            meetupEvent.LastModifierUserId = AbpSession.UserId;
          
            await _meetupEventRepository.UpdateAsync(meetupEvent);
           
        }

		
         public async Task Delete(EntityDto input)
         {
            var creatorId = await _meetupEventRepository.GetAll().Where(s => s.Id == input.Id && s.ParentUser==true).Select(s => s.CreatorUserId).FirstOrDefaultAsync();

            var deleteList = await _meetupEventRepository.GetAll().Where(s => s.CreatorUserId == creatorId).ToListAsync();

            foreach(var deleted in deleteList)
              await _meetupEventRepository.DeleteAsync(deleted.Id);
         }
        public async Task DeleteClield(EntityDto input)
        {           
                await _meetupEventRepository.DeleteAsync(input.Id);
        }


    }
}