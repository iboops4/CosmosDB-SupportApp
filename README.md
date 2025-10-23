# 🌐 CosmosDB SupportApp

## 🎯 Formål
Dette projekt viser, hvordan man kan forbinde en **.NET 8 Blazor Server-applikation** til **Azure Cosmos DB (NoSQL)**.  
Formålet er at demonstrere cloud-integration, hvor brugeren kan:
- Oprette supporthenvendelser via en formular  
- Gemme data i en Cosmos DB-container  
- Hente og vise data direkte fra databasen  

Løsningen illustrerer brug af **dependency injection**, **Cosmos DB SDK** og **data-validering** i Blazor.

---

## ☁️ Opret en Cosmos DB-database med Azure CLI
Følgende kommandoer opretter den samme database-struktur som i projektet:

```bash
az group create --name CosmoGroup --location westeurope

az cosmosdb create --name ibas-db-account360 --resource-group CosmoGroup --kind GlobalDocumentDB

az cosmosdb sql database create --account-name ibas-db-account360 --resource-group CosmoGroup --name IBasSupportDB

az cosmosdb sql container create --account-name ibas-db-account360 --resource-group CosmoGroup --database-name IBasSupportDB --name ibassupport --partition-key-path "/category"

✅ Status
 Cosmos DB-forbindelse virker og er testet

 Formular til oprettelse af supporthenvendelser implementeret

 Data hentes og vises korrekt fra Cosmos DB

 Projekt publiceret på GitHub

 Mangler: mulighed for at redigere eller slette henvendelser

 Næste trin: tilføj login-system og udvid CRUD-funktionalitet

Udviklet af: Ibrahim Abde
📅 Oktober 2025 – EAAA IT-Arkitektur,
