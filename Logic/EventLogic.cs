using Logic.DTO_s;
using Logic.Interfaces;
using Logic.Interfaces;
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
            _repo.CreatePractice(newEvent, endTime);
        }

        public List<Practice> GetAllPractices()
        {
            return _repo.GetAllPractices();
        }
    }
}
