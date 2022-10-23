# DirectoryApp

### Things to check before running the project

Check the `StaticDefinition.cs` files for port configurations.

The project consists of 2 microservices, UI, RabbitMQ services, Unit Test and a background worker exporting reports to excel.

CrudOperations microservice performs crud operations by creating the person database.

Report microservice creates the report database, processes the requested reports into the database, starts RabbitMQ, and updates the relevant row in the database when the report process is finished.

Workers.FileCreate is a background service. The report is created here and sent to the file upload api in the web interface. If the result is successful, it sends a request to the Report API to update the relevant record successfully. If the request is successful, the queue is dropped from RabbitMQ.

The project was created with .NET 5.0 and the postgresql database was used.
