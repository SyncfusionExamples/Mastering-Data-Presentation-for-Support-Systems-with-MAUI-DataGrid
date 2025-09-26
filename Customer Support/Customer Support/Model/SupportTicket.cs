using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Support.Model
{

    public class SupportTicket : INotifyPropertyChanged
    {
        private string _customerName = string.Empty;
        private string _issueType = string.Empty;
        private string _priority = string.Empty;
        private string _status = string.Empty;
        private string _sla = string.Empty;
        private string _assignedAgent = string.Empty;
        private DateTime _dateCreated= DateTime.Now;
        private int _ticketID = 0;


        public string CustomerName
        {
            get => _customerName;
            set
            {
                if (_customerName != value)
                {
                    _customerName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string IssueType
        {
            get => _issueType;
            set
            {
                if (_issueType != value)
                {
                    _issueType = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Priority
        {
            get => _priority;
            set
            {
                if (_priority != value)
                {
                    _priority = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged();
                }
            }
        }

        public int TicketID
        {
            get => _ticketID;
            set
            {
                if (_ticketID != value)
                {
                    _ticketID = value;
                    OnPropertyChanged();
                }
            }
        }

        public string SLA
        {
            get => _sla;
            set
            {
                if (_sla != value)
                {
                    _sla = value;
                    OnPropertyChanged();
                }
            }
        }

        public string AssignedAgent
        {
            get => _assignedAgent;
            set
            {
                if (_assignedAgent != value)
                {
                    _assignedAgent = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime DateCreated
        {
            get => _dateCreated;
            set
            {
                if (_dateCreated != value)
                {
                    _dateCreated = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
