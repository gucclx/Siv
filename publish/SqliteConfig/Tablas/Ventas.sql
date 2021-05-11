CREATE TABLE "Ventas" (
	"Id"	INTEGER NOT NULL UNIQUE,
	"Unidades"	INTEGER NOT NULL CHECK("Unidades" > 0),
	"PrecioVentaUnidad"	INTEGER NOT NULL CHECK("PrecioVentaUnidad" >= 0),
	"ClienteId"	INTEGER,
	"Fecha"	INTEGER NOT NULL,
	"LoteId"	INTEGER NOT NULL,
	PRIMARY KEY("Id" AUTOINCREMENT),
	FOREIGN KEY("LoteId") REFERENCES "Lotes"("Id"),
	FOREIGN KEY("ClienteId") REFERENCES "Clientes"("Id")
)