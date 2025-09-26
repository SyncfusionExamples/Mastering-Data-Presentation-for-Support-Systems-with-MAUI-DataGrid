using Customer_Support.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Support.ViewModel
{
    public class TicketViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<SupportTicket>? Tickets { get; set; }

        public ObservableCollection<string> TicketProperties { get; set; }

        public TicketViewModel()
        {

            TicketProperties = new ObservableCollection<string>
            {
                "TicketID",
                "CustomerName",
                "IssueType",
                "Priority",
                "Status",
                "SLA",
                "AssignedAgent",
                "DateCreated"

            };

            LoadTickets();
        }

        private async void LoadTickets()
        {
            var service = new Firestore_Service();
            Tickets = await service.GetTicketsAsync();
            OnPropertyChanged(nameof(Tickets));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}
