# Chinook README

This project is a playground for illustrating technology concepts such as:

* Architecture and Design
* API Design
* Docker
* Dotnet Core 3.1 For all backend
* React (Typescript) For all frontend
* Database Migrations and Versioning

The name of this project was chosen based on a fictitious media store called '**_chinook_**'.

## 1. Design

This section describes the general design and architecture of the _Chinook_ system.

### High Level Architecture

The overall system design has the traits of a [Modular Monolith]. The system is composed of 3 primary sub-systems (modules) namely:

* Catalog - Music catalog management
* Operations - Employee management
* Sales - Sales and customer management

There is a single database comprised of 3 schemas that closely relate to the aforementioned modules.

The following 2 diagrams illustrate 2 potential architectural approaches. The big difference between the 2 different approaches is with regards to the API layer. 

#### High Level View 1

For the first approach, there is a single API that interfaces into all 3 Chinook modules.

![chinook-high-level-arch-1](https://user-images.githubusercontent.com/33935506/72651213-98ae2680-39e7-11ea-9a85-503aebc69681.png)

#### High Level View 2

For the second approach, there is a single API per module.

![chinook-high-level-arch-2](https://user-images.githubusercontent.com/33935506/72651214-98ae2680-39e7-11ea-9117-f9a95477aa1f.png)

### Module Architecture

Each sub-system (module) high-level architecture has been influenced by the following architectural ideas:

* [Layered Architecture]
* [Hexagonal Architecture]
* [Onion Architecture]
* [Clean Architecture]
* [Modular Monolith]

#### High Level View

As can be seen by the diagram below, the arrows are always pointing inwards (or down) from one layer to the next. The whole idea is to ensure that dependants that change the least are at the center, with dependants that change the most at the top (outer) most level.

![chinook-module-architecture](https://user-images.githubusercontent.com/33935506/72653239-d2cef680-39ee-11ea-8215-e98386d32637.png)


**Domain and Domain Services**
  
_Primary Responsibility: Enterprise domain logic_

All domain logic relating to domain models and domain services are handled in this layer.

**Application**

_Primary Responsibility: Application logic_

This layer is typically where you would find "Application "Services" and "Use Cases". However, the CQRS design pattern is being used in place of "Use Cases" and "Application Services".

**Infrastructure**

_Primary Responsibility: Provide the core of the system an interface to the "world"_

This layer is aall about defining and configuring external dependencies such as:

* database access
* proxies to other API's
* logging
* monitoring
* dependency injection

**API**

_Primary Responsibility: Provides a distributed interface that gives access to application features_

All API's in this project have been implemented as _HTTP_ services with a strong REST influence. I've chosen not to call the API's "REST API's" due to using the _"[Richardson Maturity Model]"_ as a guide. Currently, in terms of the _"[Richardson Maturity Model]"_, all API's in this project only support up to and including Level 2. The next level up is to support HATEOAS and will be added to the product roadmap.

## 2. Technology Used

### OS

I have developed and tested _Chinook_ on the following Operating Systems.

* [Ubuntu 18.04 LTS]

  Ubuntu is an open source software operating system that runs from the desktop, to the cloud, to all your internet connected things.

* Windows 10 Professional

  In addition to developing _Chinook_ on Windows 10, I have also tried and tested _Chinook_ using [Windows Subsystem For Linux]. Specifically, I have used [WSL-Ubuntu]. See more about [WSL] below.

  * [Windows Subsystem For Linux]

    The Windows Subsystem for Linux lets developers run a GNU/Linux environment -- including most command-line tools, utilities, and applications -- directly on Windows, unmodified, without the overhead of a virtual machine.

  * [Windows Subsystem For Linux 2]
  
    NOTE: I have not tested _Chinook_ on [WSL2] yet. I mention it here because I want to be clear that I've only tested on [WSL] (not to be confused with WSL2).

    WSL 2 is a new version of the architecture in WSL that changes how Linux distros interact with Windows. WSL 2 has the primary goals of increasing file system performance and adding full system call compatibility. Each Linux distro can run as a WSL 1, or a WSL 2 distro and can be switched between at any time. WSL 2 is a major overhaul of the underlying architecture and uses virtualization technology and a Linux kernel to enable its new features.

### Code

* [Visual Studio Code]

  Visual Studio Code is a source code editor developed by Microsoft for Windows, Linux and macOS. It includes support for debugging, embedded Git control, syntax highlighting, intelligent code completion, snippets, and code refactoring.

* [Visual Studio Community Edition]

  A fully-featured, extensible, **FREE** IDE for creating modern applications for Android, iOS, Windows, as well as web applications and cloud services.

### Database

* [Postgresql]

  PostgreSQL, also known as Postgres, is a free and open-source relational database management system emphasizing extensibility and technical standards compliance. It is designed to handle a range of workloads, from single machines to data warehouses or Web services with many concurrent users.

* [pgAdmin4]

  Open Source administration and development platform for PostgreSQL

* [Flyway]

  Flyway is an open source database migration tool.

### Docker

* [Docker]

  Docker is a computer program that performs operating-system-level virtualization also known as containerization. It is developed by Docker, Inc.

* [Docker-Compose]

  Compose is a tool for defining and running multi-container Docker applications.

---

## 3. Getting Started

Before getting started, the following frameworks must be installed on your machine:

* Docker
* Docker-Compose
* Dotnet Core 3.1
* Node 12

### Get The Code

Clone 'chinook' repository from GitHub

```bash
# using https
git clone https://github.com/drminnaar/chinook.git

# or using ssh
git clone git@github.com:drminnaar/chinook.git
```

### Database Setup

The primary database that will be used is a Postgres database based on the '**_chinook_**' Sql database. The initial inspiration was taken from the [cwoodruff/ChinookDatabase
](https://github.com/cwoodruff/ChinookDatabase) github repository. For this project, the original [chinook database script] has been decomposed into different versioned migrations that will be used by the [Flyway] database version and migration tool.

#### Create And Run Database

A [Docker] container is used to host a [Postgresql] database. Furthermore, a [Docker-Compose] file has been included that can be used to more conveniently startup a [Postgresql] database. For further convenience, a database refresh script has been included for _bash_ and _powershell_. The script files can be used to spin up a database environment using postgres with all the database migrations executed using [Flyway].

__For Linux using Bash:__

```bash
# only run once to give script execute permissions
chmod +x ./refresh-chinook-db.sh

# create chinook database and populate with data
./refresh-chinook-db.sh
```

__For any OS running Powershell:__

```bash
# create chinook database and populate with data
./refresh-chinook-db.ps1
```

Once the script completes successfully, you should see an output in your console that resembles something that looks like the following:

```diff
Script started! Creating new chinook database using Docker, Docker-Compose, and Postgres.

Setup chinook Postgres database in Docker container started
pg-chinook-data
Stopping pg-chinook ... done
Stopping pg-admin   ... done
Removing pg-chinook ... done
Removing pg-admin   ... done
Removing network chinooknet
Creating network "chinooknet" with the default driver
Creating pg-chinook ... done
Creating pg-admin   ... done
Setup of chinook Postgres database in Docker container complete

Drop and recreate any existing chinook database started ...
dropdb: could not connect to database template1: FATAL:  the database system is starting up
createdb: could not connect to database template1: FATAL:  the database system is starting up
Drop and recreate any existing chinook database completed ...

Run migrations using Flyway started ...
Flyway Community Edition 6.0.0-beta2 by Boxfuse
Database: jdbc:postgresql://172.22.0.5:5432/chinook (PostgreSQL 11.6)
Successfully validated 25 migrations (execution time 00:02.771s)
Current version of schema "public": << Empty Schema >>
Migrating schema "public" to version 1.1 - Create employee operations schema
Migrating schema "public" to version 1.2 - Create employee table
Migrating schema "public" to version 2.1 - Create music catalog schema
Migrating schema "public" to version 2.2 - Create genre table
Migrating schema "public" to version 2.3 - Create artist table
Migrating schema "public" to version 2.4 - Create album table
Migrating schema "public" to version 2.5 - Create mediatype table
Migrating schema "public" to version 2.6 - Create track table
Migrating schema "public" to version 2.7 - Create playlist table
Migrating schema "public" to version 2.8 - Create playlisttrack table
Migrating schema "public" to version 3.1 - Create sales schema
Migrating schema "public" to version 3.2 - Create customer table
Migrating schema "public" to version 3.3 - Create invoice table
Migrating schema "public" to version 3.4 - Create invoiceline table
Migrating schema "public" to version 4.1 - Add genre data
Migrating schema "public" to version 4.2 - Add mediatype data
Migrating schema "public" to version 4.3 - Add artist data
Migrating schema "public" to version 4.4 - Add album data
Migrating schema "public" to version 4.5 - Add track data
Migrating schema "public" to version 4.6 - Add employee data
Migrating schema "public" to version 4.7 - Add customer data
Migrating schema "public" to version 4.8 - Add invoice data
Migrating schema "public" to version 4.9 - Add invoiceline data
Migrating schema "public" to version 4.10 - Add playlist data
Migrating schema "public" to version 4.11 - Add playlisttrack data
Successfully applied 25 migrations to schema "public" (execution time 00:05.159s)
Run migrations using Flyway completed ...

Script completed! The chinook database was created successfully!
Connect to chinook postgres database using the following details (as per 'docker-compose-pg.yml'):
  - server: localhost (native client) or 172.22.0.5 is using pgAdmin (http://localhost:8080)
  - username: postgres
  - password: password
```

### Get Node Ready

NPM is being used as a task runner of sorts. It's the reason for having a dependency on Node and NPM. Although the _dotnet CLI_ is fantastic, I wanted to illustrate how one might combine the 2. Therefore, if you have a look at the root of the solution, you will notice a packages.json file that has a number of tasks setup. It also have the "concurrently" package installed to run tasks in parallel.

For example:

```json
"scripts": {
    "build": "dotnet build ./src",
    "catalog": "dotnet watch --project ./src/Catalog/Chinook.Catalog.Api run",
    "operations": "dotnet watch --project ./src/Operations/Chinook.Operations.Api run",
    "sales": "dotnet watch --project ./src/Sales/Chinook.Sales.Api run",
    "start": "concurrently \"npm run catalog\" \"npm run operations\" \"npm run sales\""
}
```

From the command line, type the following:

```bash
# change to project root
cd ./chinook

# install node_modules
npm install
```

### Build The Code

```bash
# change to project root
cd ./chinook

# build solution
npm run build
```

### Running the Api's

Each Api can be run from a _Solution file_, or via the command line at the Api path. However, for convenience, one can run any of the Api's using _npm_ as follows:

```bash
# change to project root
cd ./chinook

# To run 'Catalog Api' (http://localhost:5000)
npm run catalog

# To run 'Operations Api' (http://localhost:5001)
npm run operations

# To run 'Sales Api' (http://localhost:5002)
npm run sales

# To run all Api's
npm start
```

---

## 4. Future Plans

This project will be evolving a lot over time as there is still lots to do. This section will also continuously be updated with new requirements for the future.

Tests

- Currently there are no tests. Add tests for all modules and related components.

REST Api

- Add caching strategies
- Add security
- Add HATEOAS support
- Add NSwag

gRPC Api

- Find a good usecase to use gRPC

GraphQL Api

- Find a good usecase to use GraphQL

Application

- Add more validation rules
- Add logging

Domain

- Introduce new scenarios that require business logic

Docker

- Add docker support for "Catalog Api"
- Add docker support for "Operations Api"
- Add docker support for "Sales Api"

Events

- Add domain events for each of the modules

Database

- Need a good usecase for using a NoSQL database

UI

- Build a React frontend

Documentation

- The documentation is not great. Potentially need to build out documentation in wiki.

---

## 5. Versioning

I use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/drminnaar/chinook/tags).

---

## 6. Authors

* **Douglas Minnaar** - *Initial work* - [drminnaar](https://github.com/drminnaar)


[Docker]: https://www.docker.com
[Docker-Compose]: https://docs.docker.com/compose/
[Postgresql]: https://www.postgresql.org/
[pgAdmin4]: https://www.pgadmin.org/
[Flyway]: https://flywaydb.org/
[Flyway Docker]: https://github.com/flyway/flyway-docker
[chinook database script]: https://github.com/cwoodruff/ChinookDatabase/blob/master/Scripts/Chinook_PostgreSql.sql

[Visual Studio Code]: https://code.visualstudio.com/
[VS Code]: https://code.visualstudio.com/
[Visual Studio Community Edition]: https://visualstudio.microsoft.com/vs/community/

[Ubuntu]: https://ubuntu.com/download/desktop
[Ubuntu 18.04]: https://ubuntu.com/download/desktop
[Ubuntu 18.04 LTS]: https://ubuntu.com/download/desktop

[WSL]: https://docs.microsoft.com/en-us/windows/wsl/about
[Windows Subsystem For Linux]: https://docs.microsoft.com/en-us/windows/wsl/about
[WSL-Ubuntu]: https://wiki.ubuntu.com/WSL
[WSL2]: https://docs.microsoft.com/en-us/windows/wsl/wsl2-index
[Windows Subsystem For Linux 2]: https://docs.microsoft.com/en-us/windows/wsl/wsl2-index

[Layered Architecture]: https://en.wikipedia.org/wiki/Multitier_architecture
[Onion Architecture]: https://jeffreypalermo.com/2008/07/the-onion-architecture-part-1/
[Modular Monolith]: https://www.youtube.com/watch?v=5OjqD-ow8GE
[Clean Architecture]: https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html
[Hexagonal Architecture]: https://en.wikipedia.org/wiki/Hexagonal_architecture_(software)
[Microservices]: https://en.wikipedia.org/wiki/Microservices

[Richardson Maturity Model]: https://martinfowler.com/articles/richardsonMaturityModel.html