# AURSearch

## Purpose
Learning how to work with public APIs and web scraping. The program can access APIs and parse web pages.


## API
Selected API: Aurweb RPC interface  
Documentation: https://aur.archlinux.org/rpc/swagger


## Startup instruction
To start, you need to launch PostgreSQL and MongoDB databases on the host, specifying the connection strings in the Presentation/appsettings.json file. Then simply build the project and run it.


## Command description
aursearch [command] [options]

Commands:  
  find    find a package in AUR  
  load    load article data  
  get     get data from the database  
  config  configuration parameters  

Options:  
find:  
  -n, --file-name <file-name>  name of the requested file  
load:  
  -u, --url <url>  full resource url  
get:  
  --package                    select a package repository  
  --article                    select the article repository  
  -n, --file-name <file-name>  name of the requested file  
  -u, --url <url>              full resource url  
  -a, --all                    get all values  
config:  
  -i, --info                                        get information  
  -s, --set                                         set configuration parameters  
  -pc, --postgres-connection <postgres-connection>  postgresql connection string  
  -mc, --mongo-connection <mongo-connection>        mongodb connection string  


## Data schema
AUR package:  
| Field        | Type              |
|--------------|-------------------|
|  ID          | integer           |
|  Name        | string            |
|  Version     | string (nullable) |
|  URL         | string (nullable) | 
|  Description | string (nullable) | 

Article:  
| Field        | Type                          |
|--------------|-------------------------------|
|  ID          | integer                       | 
|  URL         | string                        |
|  Title       | string (nullable)             |
|  Tags        | array[string]                 |
|  Metatags    | array[dict[string, string]]   |
|  Links       | dict[string, string]          |


## Examples of use
aursearch find -n "stockfih"   //search for a package named stockfish  
aursearch load -u "https://github.com"   //parsing the page github.com  
aursearch get --package -n "stockfish"   //retrieving the stockfish package from the repository  
aursearch get --article -u "https://github.com"   //retrieving the github.com page from the repository  
aursearch get --package -a   //retrieving all packages from the repository  
aursearch get --article -a   //retrieving all pages from storage  
aursearch get --package -n "stockfish" --article -u "https://github.com"   //retrieving the stockfish package and the github.com page  
aursearch get --package -a --article -a   //retrieving all packages and all pages from the repository  
aursearch config -i   //output of the current program configuration  
aursearch config -s --pc "Host=localhost;Port=5432;Database=aursearchdb;Username=user;Password=123"   //setting up the connection string for PostgreSQL  
aursearch config -s --mc   //setting up the connection string for MongoDB  
