using Abp.Application.Services;
using Abp.Application.Services.Dto;
using eduvanz.Meetup.MeetupEvents;
using eduvanz.Meetup.MeetupEvents.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eduvanz.MeetupEvents
{
    public interface IMeetupEventsAppService : IApplicationService
    {
        Task<List<MeetupEventDto>> GetAll();

       
        Task<List<CreateOrEditMeetupEventDto>> GetMeetupEventForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditMeetupEventDto input);

        Task Delete(EntityDto input);

        Task<List<StateMaster>> getstates();

        Task DeleteClield(EntityDto input);
    }
}