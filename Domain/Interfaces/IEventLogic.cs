using Domain.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IEventLogic
    {
        void CreatePractice(Event newEvent, TimeSpan endTime);
        List<Practice> GetAllPractices();
        Practice GetPracticeById(int eventId);
    }
}
