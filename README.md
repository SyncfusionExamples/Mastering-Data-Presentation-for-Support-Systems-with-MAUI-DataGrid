# Customer Support Ticketing System (MAUI)

This project is a **.NET MAUI Customer Support Ticketing System** built using **Syncfusion MAUI controls**. It provides a clean, responsive interface for viewing, searching, sorting, and exporting customer support tickets across platforms.

## Features

- **Ticket Grid View** using `SfDataGrid`
- **Search functionality** with real-time filtering
- **Dynamic sorting** via Syncfusion `SfComboBox`
- **Visual priority indicators** using color-coded labels
- **Status icons** rendered through converters
- **PDF export** of ticket logs with column auto-fit
- **MVVM architecture** with strongly typed bindings

## Technologies Used

- .NET MAUI
- Syncfusion MAUI DataGrid & Inputs
- XAML UI with Data Templates
- PDF exporting via Syncfusion Pdf library
- Value converters for UI customization

## Key Components

- `MainPage.xaml` – UI layout and bindings  
- `TicketViewModel` – Ticket data and logic  
- `SupportTicket` – Data model  
- `PriorityColorConverter` & `StatusIconConverter`  
- `DataGridPdfExportingController` – PDF export

## How It Works

Users can search tickets, sort by selected properties, and export the displayed data into a PDF file. Priority and status are visually enhanced to improve readability and usability.

## Output

A fully functional cross-platform ticket management UI suitable for enterprise customer support workflows.
