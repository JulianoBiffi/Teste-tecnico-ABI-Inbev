# What is left to develop?

Due to a lack of time, I was unable to complete the project. My next steps would be:
- Finish the CRUD for products, as it currently only includes product creation, get all and get product by id.
- Implement the CRUD for Cart and Cart Items.
- Write unit tests for the validators.
- Perform integration tests to verify that all fields are correctly persisted in the database.
- Create an [Authentication and Authorization](https://learn.microsoft.com/en-us/aspnet/core/security/?view=aspnetcore-9.0) flow.
- Configure the MongoDB database.
- Implement the CRUD for sales and store data in MongoDB.
- Integrate with RabbitMQ.
- Enqueue sales messages to RabbitMQ.

# How to run?

### Configurarion of docker
First of all, you will need to create de docker containers.

Check if Docker is running with the command:
```docker ps```
If an error is returned, open Docker and try running the command again.

Now with docker running, run:
```docker-compose up```

### Executing migrations

Open the `Package Manager Console` at `Tools > NuGet Package Manager > Package Manager Console`

Select the project `Ambev.DeveloperEvaluation.ORM` or run
```cd .\src\Ambev.DeveloperEvaluation.ORM```


Now run commands to create the databases
```dotnet ef database update```


### Running the application

Expand the ```Adapters > Drivers > WebApi```, right click on `Ambev.DeveloperEvaluation.WebApi` and select `Set as Startup Project`. Now you are ready to run the application.
