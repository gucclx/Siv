CREATE TABLE "Lotes" (
	"Id"	INTEGER NOT NULL UNIQUE,
	"ProductoId"	INTEGER NOT NULL,
	"UnidadesDisponibles"	INTEGER NOT NULL CHECK("UnidadesDisponibles" >= 0),
	"Inversion"	INTEGER NOT NULL CHECK(Inversion >= 0),
	"PrecioVentaUnidad"	INTEGER CHECK("PrecioVentaUnidad" >= 0),
	"FechaCreacion"	INTEGER NOT NULL,
	"UnidadesCompradas"	INTEGER NOT NULL CHECK("UnidadesCompradas" > 0),
	FOREIGN KEY("ProductoId") REFERENCES "Productos"("Id"),
	PRIMARY KEY("Id" AUTOINCREMENT)
)