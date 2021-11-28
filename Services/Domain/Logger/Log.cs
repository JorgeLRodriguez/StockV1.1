using Services.Domain.SecurityComposite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.Logger
{
    public class Log
    {
        public Guid ID { get; set; }
        public int Event_ID { get; set; }
        [NotMapped]
        public Event Event { get; set; }
        public User User { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        [Required, EnumDataType(typeof(Severity))]
        public Severity Severity { get; set; }
        //public Log(Guid _ID, Event _Event, User _User, string _Message, DateTime _Datetime, Severity _Severity)
        //{
        //    ID = _ID;
        //    Event = _Event;
        //    User = _User;
        //    Message = _Message;
        //    DateTime = _Datetime;
        //    Severity = _Severity;
        //}
        public Log(){}
        public override string ToString()
        {
            return string.Format("[{0:G}] {1:yyyy-MM-dd HH:mm:ss}: {2}", this.Severity, this.DateTime, this.Message);
        }
    }
}
