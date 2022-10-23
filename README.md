# DirectoryApp

### Things to check before running the project

Check the `StaticDefinition.cs` files for port configurations.

The project consists of 2 microservices, UI, RabbitMQ services, Unit Test and a background worker exporting reports to excel.

CrudOperations microservice performs crud operations by creating the person database.

Report microservice creates the report database, processes the requested reports into the database, starts RabbitMQ, and updates the relevant row in the database when the report process is finished.
