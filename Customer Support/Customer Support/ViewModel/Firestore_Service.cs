using Customer_Support.Model;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Customer_Support.ViewModel
{
    public class Firestore_Service
    {

        private FirestoreDb? db;

        private async Task SetUpFireStore()
        {
            if(db == null)
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("firebase_credentials.json");
                using var reader = new StreamReader(stream);
                var contents = reader.ReadToEnd();

                db = new FirestoreDbBuilder
                {
                    ProjectId = "Enter your projectId",
                    JsonCredentials = contents
                }.Build();
            }
        }

        public async Task<ObservableCollection<SupportTicket>> GetTicketsAsync()
        {
            await SetUpFireStore();
            if (db != null)
            {
                ObservableCollection<SupportTicket> tickets = new ObservableCollection<SupportTicket>();
                CollectionReference colRef = db.Collection("Enter your collection name");
                Query query = colRef.OrderBy("TicketID");
                QuerySnapshot snapshot = await query.GetSnapshotAsync();

                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    if (document.Exists)
                    {
                        Dictionary<string, object> ticketData = document.ToDictionary();

                        if (ticketData["DateCreated"] is Timestamp timestamp)
                        {
                            ticketData["DateCreated"] = timestamp.ToDateTime();
                        }

                        string json = JsonSerializer.Serialize(ticketData);
                        if (!string.IsNullOrWhiteSpace(json))
                        {
                            SupportTicket ticket = JsonSerializer.Deserialize<SupportTicket>(json)!;
                            if (ticket != null)
                                tickets.Add(ticket);
                        }
                    }
                }
                return tickets;
            }
            else
            {
              return new ObservableCollection<SupportTicket>();
            }
        }
    }
}
