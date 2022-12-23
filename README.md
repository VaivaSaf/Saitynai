# Projekto pavadinimas
Projektas vadinasi „Kolekcionierius“. Pavadinimas pasirinktas pagal tikslinę auditoriją, kadangi kuriama internetinė aplikacija yra skirta būtent kolekcionieriams.
# Projekto tikslas
Sukurti kolekcionieriams skirtą svetainę, kurioje jie dalyvaudami ir kurdami aukcionus galėtų pirkti bei parduoti kolekcinius daiktus.
# Sistemos aprašymas
Sistema daugiausiai yra skiriama kolekcionieriams, kurie nori pelningai parduoti turimą kolekcinį inventorių ir įsigyti juos dominančius daiktus. Registruoti vartotojai norintys parduoti savo vertingus kolekcinius daiktus gali juos įkelti į sistemą, priskirti pasirinktam aukcionui. Jei keldamas daiktą prisijungęs vartotojas padarė klaidą, tai jis gali redaguoti įkeltą informaciją. Prisijungę vartotojai taip pat gali dalyvauti pačiuose aukcionuose. Tai pasirinkus dominantį aukcioną ir nuėjus į jo konkretaus dominančio daikto puslapį jis gali pateikti savo minimalios kainos pasiūlymą. Neprisiregistravęs vartotojas gali tik peržiūrėti svetainę ir prisijungti prie jos. O administratorius gali daryti viską, ką prisijungęs vartotojas, tik dar gali šalinti tiek, aukcionus, tiek daiktus, tiek pasiūlymus. 
	
Sistemoje yra trijų tipų vartotojai: svečias, prisiregistravęs vartotojas ir administratorius. Priklausomai pagal savo roles, svetainės languose jie arba mato tas parinktis, arba ne.
#Fukciniai reikalavimai
	
Svečio funckciniai reikalavimai:
1.	peržiūrėti svetainę;
2.	prisijungti prie svetainės, tapdamas registruotu vartotoju.

Registruoto vartotojo (pirkėjo, pardavėjo) funkciniai reikalavimai:
1.	prisijungti prie svetainės;
2.	atsijungti nuo svetainės;
3.	įkelti kolekcinį daiktą;
4.	redaguoti įkeltą kolekcinį daiktą;
5.	peržiūrėti kolekcinius daiktus;
6.	skelbti aukcioną;
7.	redaguoti aukcioną; 
8.	peržiūrėti vykstančius aukcionus;
9.	pridėti pasiūlymą
10.	peržiūrėti pasiūlymus
11.	redaguoti pasiūlymus

Adminstratoriaus funkciniai reikalavimai (tokie patys, kaip registruoto vartotojo, tik dar papildomai):
1.	pašalinti aukcioną.
2.	pašalinti daiktą
3.	pašalinti pasiūlymą.

# Technologijos
Projektui kurti buvo pasirinktos šios technologijos:
•	Kliento pusė (ang. Front-End) – React.js; 
•	Serverio pusė (angl. Back-End) – C# .NET; 
•	Duomenų bazė – AzureSQL.

 
React yra atvirojo kodo „JavaScript“ biblioteka, naudojama kurti vartotojo sąsajas. Teigiama, kad React yra greitesnis nei HTML, nes galima kurti mažesnius ir efektyvesnius kodo failus.

# Sistemos architektūra
1 pav. yra pateikiama „Kolekcionieriaus“ diegimo diagrama. Internetinė aplikacija yra pasiekama per saugų HTTPS protokolą, per kurį komunikuoja kompiuteris ir serveris.

 ![Screenshot_1](https://user-images.githubusercontent.com/78726071/209276864-3631145c-92ad-4507-9c82-f2c89f4601cd.png)

#Naudotojo sąsaja
Prieš pradedant kurti kliento dalį buvo pasidaryti projektuojamos sąsajos langų „wireframe“, o po to buvo pagal juos suprogramuota. Wireframe‘uose geltonos spalvos mygtuką mato visi svetainės lankytojai, oranžinį - prisijungę vartotojai arba administratoriai, o raudoną – tik administratoriai.

 
![image](https://user-images.githubusercontent.com/78726071/209277047-76a7ffd7-63b6-41fe-a2e7-ecbc6d9d563e.png)
![image](https://user-images.githubusercontent.com/78726071/209277142-8af33abf-847b-494b-b493-153fb176c329.png)
![image](https://user-images.githubusercontent.com/78726071/209277168-9df95e3e-4b01-48d2-9953-7a40ee71f03e.png)
![image](https://user-images.githubusercontent.com/78726071/209277188-373c457d-4d18-4046-ac5f-cf973a78ab96.png)
![image](https://user-images.githubusercontent.com/78726071/209277202-90b89460-2e1c-44a5-a2ce-519fe590bf7b.png)
![image](https://user-images.githubusercontent.com/78726071/209277237-595f96c1-848a-4ea2-b25c-93ec8bbafa6e.png)
![image](https://user-images.githubusercontent.com/78726071/209277253-e74e3974-3775-4240-99f5-0f609bef2d63.png)
![image](https://user-images.githubusercontent.com/78726071/209277270-76229535-6086-4ca8-a80b-bb8bcc83b7f6.png)
![image](https://user-images.githubusercontent.com/78726071/209277280-0704f3ea-6379-4946-8d1f-2dcaab335b0a.png)


 
# API specifikacija
Projekte yra 17 API endpointų. Po 5 yra skirta aukcionams, kolekciniams daiktams, pasiūlymams, ir 2 yra skirti autentifikacijai - prisijungimui bei registracijai.

GET visi aukcionai
Metodas	GET
Autentifikacija	Nėra
Parametrai	Nėra
URL	https://projektas.azurewebsites.net/api/auctions
Aprašymas	Grąžina visus aukcionus
Atsako kodai	200
Pavyzdys
Užklausa	https://projektas.azurewebsites.net/api/auctions
Atsakas	[
  {
    "id": 1,
    "name": "Aukcionas 1",
    "description": "aprasymas",
    "startingTime": "2022-11-03T16:41:51.968",
    "endingTime": "2022-01-10T16:41:51.968",
    "creationDate": "2022-11-11T02:06:04.9198266"
  },
  {
    "id": 4,
    "name": "Antrasis aukcionas",
    "description": "Aukcionas apie bites",
    "startingTime": "2022-10-13T16:41:51.968",
    "endingTime": "2022-10-13T16:41:51.968",
    "creationDate": "2022-11-11T07:27:32.0824492"
  }
]

GET vienas aukcionas
Metodas	GET
Autentifikacija	Nėra
Parametrai	Id -  aukciono numeris
URL	https://projektas.azurewebsites.net/api/auctions/:id
Aprašymas	Grąžina vieną konkretų aukcioną
Atsako kodai	200
Pavyzdys
Užklausa	https://projektas.azurewebsites.net/api/auctions/1
Atsakas	[
  {
    "id": 1,
    "name": "Aukcionas 1",
    "description": "aprasymas",
    "startingTime": "2022-11-03T16:41:51.968",
    "endingTime": "2022-01-10T16:41:51.968",
    "creationDate": "2022-11-11T02:06:04.9198266"
  }
]

POST aukcionai
Metodas	POST
Autentifikacija	Admin arba SystemUser rolių turėtojai
Parametrai	Nėra
URL	https://projektas.azurewebsites.net/api/auctions
Aprašymas	Prideda naują aukcioną
Atsako kodai	201, 400, 401, 403, 404
Pavyzdys
Užklausa	https://projektas.azurewebsites.net/api/auctions
Atsakas	[ 
  {
    "id": 5,
    "name": "Naujasis aukcionas",
    "description": "Aukcionas apie naujuosius laikus",
    "startingTime": "2022-10-13T16:41:51.968",
    "endingTime": "2022-10-13T19:41:51.968",
    "creationDate": "2022-12-11T07:27:32.0824492"
  }
]

PUT aukcionai
Metodas	PUT
Autentifikacija	Admin arba SystemUser rolių turėtojai
Parametrai	Id - aukciono numeris
URL	https://projektas.azurewebsites.net/api/auctions/:id
Aprašymas	Redaguoja aukcioną
Atsako kodai	200, 400, 401, 403, 404
Pavyzdys
Užklausa	https://projektas.azurewebsites.net/api/auctions/1
Atsakas	[ 
  {
    "id": 1,
    "name": "Naujasis pakeistas aukcionas",
    "description": "Aukcionas apie naujuosius laikus pakeistas",
    "startingTime": "2022-10-13T16:41:51.968",
    "endingTime": "2022-10-13T19:41:51.968",
    "creationDate": "2022-12-11T07:27:32.0824492"
  }
]


DELETE aukcionai
Metodas	DELETE
Autentifikacija	Admin rolės turėtojai
Parametrai	Id - aukciono numeris
URL	https://projektas.azurewebsites.net/api/auctions/:id
Aprašymas	Ištrinti aukcioną
Atsako kodai	204, 400, 401, 403
Pavyzdys
Užklausa	https://projektas.azurewebsites.net/api/auctions/1
Atsakas	




GET visi daiktai
Metodas	GET
Autentifikacija	Nėra
Parametrai	auctionId- aukciono numeris
URL	https://projektas.azurewebsites.net/api/auctions/:auctionId/items
Aprašymas	Grąžina visus konkretaus aukciono daiktus
Atsako kodai	200, 400
Pavyzdys
Užklausa	https://projektas.azurewebsites.net/api/auctions/5/items
Atsakas	[
    {
        "id": 1,
        "name": "a",
        "description": "aprasymas",
        "category": 0,
        "country": "Lietuva",
        "creationDate": "2022-12-13T12:18:23.6470401",
        "minimalPrice": 50.00,
        "auctionId": 5
    },
    {
        "id": 24,
        "name": "Naujas daiktas",
        "description": "aprasymas naujo daikto",
        "category": 0,
        "country": "Lietuva",
        "creationDate": "2022-12-23T05:05:19.1062769",
        "minimalPrice": 50.00,
        "auctionId": 5
    }
]

GET vienas daiktas
Metodas	GET
Autentifikacija	Nėra
Parametrai	Id -  daikto numeris, auctionId – aukciono numeris
URL	https://projektas.azurewebsites.net/api/auctions/:auctionId/items/:id
Aprašymas	Grąžina vieną konkretų daiktą
Atsako kodai	200, 400
Pavyzdys
Užklausa	https://projektas.azurewebsites.net/api/auctions/5/items/1
Atsakas	[
  {
    "id": 1,
    "name": "a",
    "description": "aprasymas",
    "category": 0,
    "country": "Lietuva",
    "creationDate": "2022-12-13T12:18:23.6470401",
    "minimalPrice": 50.00,
    "auctionId": 5
  }
]

POST daiktai
Metodas	POST
Autentifikacija	Admin arba SystemUser rolių turėtojai
Parametrai	auctionId - aukciono numeris
URL	https://projektas.azurewebsites.net/api/auctions/:auctionId/items
Aprašymas	Prideda naują daiktą
Atsako kodai	201, 400, 401, 403, 404
Pavyzdys
Užklausa	https://projektas.azurewebsites.net/api/auctions/5/items
Atsakas	[ 
  {
    "id": 2,
    "name": "Naujas daiktas",
    "description": "aprasymas naujo daikto",
    "category": 0,
    "country": "Lietuva",
    "creationDate": "2022-12-13T12:18:23.6470401",
    "minimalPrice": 50.00,
    "auctionId": 5
  }
]

PUT aukcionai
Metodas	PUT
Autentifikacija	Admin arba SystemUser rolių turėtojai
Parametrai	Id – daikto numeris, auctionId - aukciono numeris
URL	https://projektas.azurewebsites.net/api/auctions/:auctionId/items/id
Aprašymas	Redaguoja daiktą
Atsako kodai	200, 400, 401, 403, 404
Pavyzdys
Užklausa	https://projektas.azurewebsites.net/api/auctions/5/items
Atsakas	[ 
  {
    "id": 2,
    "name": "Naujas daiktas redaguotas",
    "description": "aprasymas naujo daikto",
    "category": 0,
    "country": "Lietuva",
    "creationDate": "2022-12-13T12:18:23.6470401",
    "minimalPrice": 50.00,
    "auctionId": 5
  }
]


DELETE daiktai
Metodas	DELETE
Autentifikacija	Admin rolės turėtojai
Parametrai	Id – daikto numeris, auctionId- aukciono numeris
URL	https://projektas.azurewebsites.net/api/auctions/:auctionId/items/:id
Aprašymas	Ištrinti daiktą
Atsako kodai	204, 400, 401, 403
Pavyzdys
Užklausa	https://projektas.azurewebsites.net/api/auctions/6/items/23
Atsakas	





GET visi pasiūlymai
Metodas	GET
Autentifikacija	Nėra
Parametrai	auctionId- aukciono numeris, itemId – daikto numeris
URL	https://projektas.azurewebsites.net/api/auctions/:auctionId/items/:itemId/offers
Aprašymas	Grąžina visus konkretaus aukciono daikto pasiūlymus
Atsako kodai	200, 400
Pavyzdys
Užklausa	https://projektas.azurewebsites.net/api/auctions/5/items/1/offers
Atsakas	[
    {
        "id": 16,
        "name": "Kristupas",
        "comment": "Labai noriu isigyti.",
        "price": 6000.00,
        "creationDate": "2022-12-23T04:48:18.3987569",
        "itemId": 1
    },
    {
        "id": 17,
        "name": "Nijole",
        "comment": "Grazi vaza",
        "price": 1000.00,
        "creationDate": "2022-12-23T04:52:48.9888406",
        "itemId": 1
    }
]

GET vienas pasiūlymas
Metodas	GET
Autentifikacija	Nėra
Parametrai	Id – pasiūlymo numeris, itemId - daikto numeris, auctionId – aukciono numeris
URL	https://projektas.azurewebsites.net/api/auctions/:auctionId/items/:itemId/offers/:id
Aprašymas	Grąžina vieną konkretų pasiūlymą
Atsako kodai	200, 400
Pavyzdys
Užklausa	https://projektas.azurewebsites.net/api/auctions/5/items/1/offers/17
Atsakas	[
{
    "id": 17,
    "name": "Nijole",
    "comment": "Grazi vaza",
    "price": 1000.00,
    "creationDate": "2022-12-23T04:52:48.9888406",
    "itemId": 1
}
]

POST pasiūlymai
Metodas	POST
Autentifikacija	Admin arba SystemUser rolių turėtojai
Parametrai	auctionId - aukciono numeris, itemId – daikto numeris
URL	https://projektas.azurewebsites.net/api/auctions/:auctionId/items/:itemId/offers
Aprašymas	Prideda naują pasiūlymą
Atsako kodai	201, 400, 401, 403, 404
Pavyzdys
Užklausa	https://projektas.azurewebsites.net/api/auctions/1/items/1/offers
Atsakas	[ 
  {
    "id": 16,
    "name": "Kristupas",
    "comment": "Labai noriu isigyti.",
    "price": 6000,
    "creationDate": "2022-12-23T04:48:18.3987569Z",
    "itemId": 1
   }
]

PUT pasiūlymai
Metodas	PUT
Autentifikacija	Admin arba SystemUser rolių turėtojai
Parametrai	Id – pasiūlymo numeris, itemId - daikto numeris, auctionId - aukciono numeris
URL	https://projektas.azurewebsites.net/api/auctions/:auctionId/items/:itemId/offers/:id
Aprašymas	Redaguoja pasiūlymą
Atsako kodai	200, 400, 401, 403, 404
Pavyzdys
Užklausa	https://projektas.azurewebsites.net/api/auctions/5/items/1/offers/16
Atsakas	{
    "id": 16,
    "name": "Pakeista",
    "comment": "Pakeistas komentaras",
    "price": 6000.00,
    "creationDate": "2022-12-23T04:48:18.3987569",
    "itemId": 1
}


DELETE pasiūlymai
Metodas	DELETE
Autentifikacija	Admin rolės turėtojai
Parametrai	Id – pasiūlymo numeirs, itemId- daikto numeris, auctionId- aukciono numeris
URL	https://projektas.azurewebsites.net/api/auctions/:auctionId/items/:itemID/offeers/:id
Aprašymas	Ištrinti pasiūlymą
Atsako kodai	204, 400, 401, 403
Pavyzdys
Užklausa	https://projektas.azurewebsites.net/api/auctions/5/items/1/offers/5
Atsakas	


# Išvados
Naudojant „.NET Core“ karkasą (serverio pusei) ir „React“ (kliento pusei) buvo sukurta aukcionų svetainė. Joje galima kurta, redaguoti, peržiūrėti ir ištrinti aukcionus, kolekcinius daiktus ir pasiūlymus. Svetainėje yra 3 tipų vartotojai: svečias, prisijungęs vartotojas ir administratorius, o pagal jų roles yra pritaikytas skirtingas funkcionalumas. Svetainėje yra 17 endpointų, kurie leidžia svetainei veikti. Taip pat buvo atliktas serverio dalies diegimas diegimas debesyje („Azure“). 
