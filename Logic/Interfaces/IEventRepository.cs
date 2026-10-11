using System;
using System.Collections.Generic;
using System.Text;
using Logic.DTO_s;

namespace Logic.Interfaces
{
    public interface IEventRepository
    {
        void CreatePractice(Event newEvent, TimeSpan endTime);
        List<Practice> GetAllPractices();
        Practice GetPracticeById(int eventId);

    }
}
