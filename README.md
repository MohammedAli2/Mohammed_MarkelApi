Restful API built with .NET 8 that provides access to Claims and Company data
Test data included to help simulate sql database using in memnory database

Used visual studio 2022, .Net 8

•	The output in json format
•	endpoint that will give a single company with additional property for active insurance policy
•	endpoint that will give a list of claims for one company
•	endpoint that will give me the details of one claim with additional property for age of claim in days
•	endpoint that will allow us to update a claim
•	unit tests included for each above aswell


e.g.
get company by id api call - e.g. api/Company/Id?id=101

get claim by company id - e.g. /api/Claims/ucr?ucr=1

get list of claiims by company id - e.g. /api/Claims/companyId?companyID=101

update claim from given claim model and claim reference 
e.g.
/api/Claims?ucr=1
 request body
         {
          "ucr": "string",
          "companyId": 0,
          "claimDate": "2024-05-25T13:35:43.471Z",
          "lossDate": "2024-05-25T13:35:43.471Z",
          "assuredName": "string",
          "incurredLoss": "string",
          "closed": true
        }
