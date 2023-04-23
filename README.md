# Animal Shelter API

#### By _Cameron Abel_

#### _Storing and retrieving info on adoptables_

## Technologies Used

- _C#_
- _Entity Framework Core_
- _MySQL_
- _Swagger_

## Description

This project is desinged to showcase a simple API featuring CRUD methods and pagination.

## Setup/Installation Requirements

- Clone this repository to your local machine
- Navigate to `\ShelterApi`
- Create a new file called `appSettings.json`. Paste into this file the following code and replace `uid` and `pwd` fields with your own username and password for MySQL.

```JSON
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=shelter_api;uid=[NAME];pwd=[PASSWORD];"
  }
}
```

- Execute `$ dotnet ef database update`
- Still within the `\ShelterApi` directory, execute `$ dotnet run`

## API Endpoints

Swagger documentation is located at https://localhost:7115/swagger/index.html

### GET /api/Animals

Optional Parameters:

`species`: filter by species

`pageNumber`: page number for pagination (default 1)

`pageSize`: page size for pagination (default 5)

Example Request

```
http://localhost:5249/api/Animals
```

Example Response

```json
{
  "pageNumber": 1,
  "pageSize": 5,
  "totalPages": 2,
  "totalRecords": 7,
  "data": [
    {
      "animalId": 1,
      "name": "Taki",
      "species": "Dog",
      "age": 16,
      "weight": 53,
      "sex": "Male"
    },
    {
      "animalId": 2,
      "name": "Ginger",
      "species": "Dog",
      "age": 43,
      "weight": 70,
      "sex": "Female"
    },
    {
      "animalId": 3,
      "name": "Rollie",
      "species": "Rabbit",
      "age": 36,
      "weight": 6,
      "sex": "Male"
    },
    {
      "animalId": 4,
      "name": "Gunther",
      "species": "Dog",
      "age": 26,
      "weight": 74,
      "sex": "Male"
    },
    {
      "animalId": 5,
      "name": "Raina",
      "species": "Cat",
      "age": 60,
      "weight": 7,
      "sex": "Female"
    }
  ],
  "succeeded": true,
  "errors": null,
  "message": null
}
```

### POST /api/Animals

No parameters

Request body(json)

```json
{
  "name": "string",
  "species": "string",
  "age": 0,
  "weight": 0,
  "sex": "string"
}
```

Example Request Body

```json
{
  "name": "Ridley",
  "species": "Dog",
  "age": 14,
  "weight": 38,
  "sex": "Male"
}
```

Example Response

```json
{
  "data": {
    "animalId": 9,
    "name": "Ridley",
    "species": "Dog",
    "age": 14,
    "weight": 38,
    "sex": "Male"
  },
  "succeeded": true,
  "errors": null,
  "message": "Animal added to database"
}
```

### GET /api/Animals/{id}

Required parameters:

`id`: the animal's ID

Example Request

```
http://localhost:5249/api/Animals/2
```

Example Response

```json
{
  "data": {
    "animalId": 2,
    "name": "Ginger",
    "species": "Dog",
    "age": 43,
    "weight": 70,
    "sex": "Female"
  },
  "succeeded": true,
  "errors": null,
  "message": ""
}
```

### PUT /api/Animals/{id}

Required parameters:

`id`: the animal's ID

Example Request Body

```json
{
  "animalId": 9,
  "name": "Ridley",
  "species": "Dog",
  "age": 15,
  "weight": 38,
  "sex": "Male"
}
```

Example Response

```
No Content
```

### DELETE /api/Animals/{id}

Required parameters:

`id`: the animal's ID

Example Request

```
http://localhost:5249/api/Animals/2
```

Example Response

```
No Content
```

## Known Bugs

Report bugs [here](mailto:cameronabel@gmail.com)

## License

_MIT_

Copyright (c) _2023_ _Cameron Abel_
