# PathSaver

PathSaver is a tool to get paths of files from MsAccessDb via OleDB and save to text file, but basiclly can be use for load whatever collum from MsAccess to file, I builded it, because MsAccess2003 file(.mdb) cannot copy more than 65k objects, so for training I choose this way. 

## Install & Run
### 1. Download .NET SDK from Microsoft & Microsoft.ACE.OLEDB.12.0
[.NET SDK](https://dotnet.microsoft.com/en-us/download)
[32bit Microsoft.ACE.OLEDB.12.0](https://web.archive.org/web/20240214170634if_/https://download.microsoft.com/download/2/4/3/24375141-E08D-4803-AB0E-10F2E3A07AAA/AccessDatabaseEngine.exe) OR [64bit Microsoft.ACE.OLEDB.12.0](https://web.archive.org/web/20240214170634if_/https://download.microsoft.com/download/2/4/3/24375141-E08D-4803-AB0E-10F2E3A07AAA/AccessDatabaseEngine_X64.exe)
### 2. Clone repo
```bash
git clone https://github.com/LofasekU18/PathsSaver.git
```
### 3. Move to repo dictionary
```bash
cd PathSaver
```
### 4. Rename default_config.xml to config.xml file and fill it
```xml
<Configuration>
  <connectionString>Provider=Microsoft.ACE.OLEDB.12.0;Data Source={PATH_TO_DB};</connectionString>
  <query>{SELECT - return just one filed - path}</query>
  <resultPath>{PATH_TO_RESULT}</resultPath>
</Configuration>
```
### 5. Build
```bash
dotnet build
```
### 6. Run
```bash
dotnet run
```
