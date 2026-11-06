using Domain.DTO_s;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Logic
{
    public class EventLogic : IEventLogic
    {
        private readonly IEventRepository _repo;

        public EventLogic(IEventRepository repo)
        {
            _repo = repo;
        }

        public void CreatePractice(Event newEvent, TimeSpan endTime)
        {
            if (endTime <= newEvent.startTime)
            {
                throw new Exception("End time must be after start time.");
            }

            if (newEvent.date < DateTime.Today)
            {
                throw new Exception("Practice cannot be created in the past.");
            }

            _repo.CreatePractice(newEvent, endTime);
        }

        public List<Practice> GetAllPractices()
        {
            return _repo.GetAllPractices();
        }

        public Practice GetPracticeById(int eventId)
        {
            return _repo.GetPracticeById(eventId);
        }
    }
}
