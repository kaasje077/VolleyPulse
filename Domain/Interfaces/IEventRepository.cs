using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTO_s;

namespace Domain.Interfaces
{
    public interface IEventRepository
    {
        void CreatePractice(Event newEvent, TimeSpan endTime);
        List<Practice> GetAllPractices();
        Practice GetPracticeById(int eventId);

    }
}
