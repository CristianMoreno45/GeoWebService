# Scope

This project aims to connect an API developed in .Net Core 8 (C#) and a Postgres sql database for recording and displaying events (points) on a map (for the purposes of this project, the configurations will be made in QGIS)

# Recomendations

It is recommended to have docker installed on your computer to run the application pull without installing additional programs.

For this project, the use of Postgres SQL (database engine), PgAdmin (database administrator) and the application itself is required.

# Evolution

The project lacks all good development practices since the scope is only illustrative for academic purposes. However, if you consider that you can make a contribution, you can do so freely by making a request for changes (Pull request) to the Code which will be validated and approved if we consider that it is a contribution to the project.

# Docker installer

* Docker: https://docs.docker.com/engine/install/

# Option 1: Images (recomended) 

* Postgres installer: https://hub.docker.com/_/postgres 
* pdAgmin installer: https://www.pgadmin.org/ 

* Postgres image:
```
## Powershell Command

# download image
docker pull postgres

# Run image on port 5432 (default password)
docker run -p 5432:5432 --name container-postgresdb -e POSTGRES_PASSWORD=admin -d postgres

# Enter into container
docker exec -it container-postgresdb /bin/

# Install GIS features for postgresdb
apt-get update
apt-get upgrade -y
apt-get install postgis -y
```

* pdAgmin installer: 
```
## Powershell Command

# download image
docker pull dpage/pgadmin4:latest

# Run image on port 5050 (default password)
docker run -p 5050:80 --name container-pgadmin4 -e "PGADMIN_DEFAULT_EMAIL=name@example.com" -e "PGADMIN_DEFAULT_PASSWORD=admin" -d dpage/pgadmin4

```
# Option 2: Installers 

* Postgres installer: https://hub.docker.com/_/postgres 
* pdAgmin installer: https://www.pgadmin.org/ 

**NOTE:** After installation you need to install the postgis plugin for potgress

# Database connection from pdAgmin

Within Pgadmin locate the list of servers and right click to select *Register/Server* option. 

If you selected images, you need to set the database connection with the following configuration:

 ``` 
name: container-postgresdb
host: host.docker.internal
database: postgres
user: postgres
password: admin
```

If you selected installer, you need to set the database connection with the following configuration:

 ``` 
name: postgresdb
host: localhost
database: postgres
user: postgres
password: admin
```

# Database creation

Within Pgadmin locate the elephant icon and right click to select *Create/Database* optio, this action shold show a dialog, set *GeoDataBase* like database name.

After that, you should exceute teh following script:

```
CREATE EXTENSION postgis;

CREATE TABLE IF NOT EXISTS public."geoEvent"
(
	geo_eventid serial NOT NULL,
    name_event character(100) COLLATE pg_catalog."default",
    type_event character(20) COLLATE pg_catalog."default",
    geom geography, 
    CONSTRAINT "geoEvent_pkey" PRIMARY KEY (geo_eventid)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."geoEvent"
    OWNER to postgres;
```

# Connect QGIS with Postgres

How to connect QGIS to PostgreSQL Database? - https://www.youtube.com/watch?v=UL4nBRshNIA


# How can I have an automatic refresh of my map with a postgres connection?

Once you have connected QGIS with Postgress, the layer will be available to do click over *properties* option (right click contextual menu), you should select *representation*, after that *Refresh interval layer* and you should set interval value (5 seconds is well).

# Run the application

In your IDE, you can excute the applicaction in a specific port, also you will be able to see the documentation in the swagger page.

https://{{your_local_host:your_port}}/swagger/index.html.

A video of the expected resutl:



# About us

* Cristian Moreno (crmorenob@unal.edu.co)
* Farid Estepa (festepaq@unal.edu.co)
* Martín Gómez (mgomezu@unal.edu.co)
* Mateo Barragán (mbarragani@unal.edu.co)

Facultad de ingeniería 
Universidad Nacional de Colombia  
Bogotá, Colombia (2024) 




