# Restaurant Website Readme

This repository contains the source code for a restaurant website. The website allows users to explore the menu, check out deals, and make table reservations. It also includes an admin panel for managing products, deals, and reservations.

## Features

- Menu: Users can browse the menu and view various food and beverage items offered by the restaurant.
- Deals: Users can find special deals and offers provided by the restaurant.
- Table Reservation: Users can reserve a table by selecting the desired date, time, and number of guests.
- Admin Panel: The admin panel provides CRUD operations for managing products, deals, and reservations.
- Email Notifications: Users who make table reservations receive email notifications with the reservation details.

## Technologies Used

The project is built using the following technologies:

- ASP.NET Core MVC: The web framework used for developing the application.
- Mediator: A design pattern for decoupling components and simplifying communication between them.
- CQRS: A pattern that separates read and write operations to optimize performance and scalability.
- Entity Framework: An ORM used for database access and management.
- Fluent Validation: A library for validating input data and enforcing data integrity.
- AutoMapper: A library for object-to-object mapping.

## Getting Started

To get started with the project, follow these steps:

1. Clone this repository to your local machine.
2. Open the solution in your preferred IDE (e.g., Visual Studio).
3. Restore the NuGet packages used in the project.
4. Set up the database connection string adn account settings in the `appsettings.json` file.
5. Run the database migrations to create the necessary tables.
6. Build the project and ensure there are no build errors.
7. Run the application and access it in your web browser.

## Usage

- As a user, you can visit the website to explore the menu, check out deals, and make table reservations.
- As an admin, you can log in to the admin panel to manage products, deals, and reservations.

## Contributing

Contributions to this project are welcome. If you encounter any issues or have suggestions for improvements, please submit an issue or create a pull request.


