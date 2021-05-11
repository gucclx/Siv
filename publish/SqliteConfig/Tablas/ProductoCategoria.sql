CREATE TABLE "ProductoCategoria" (
	"ProductoId"	INTEGER NOT NULL CHECK("ProductoId" > 0),
	"CategoriaId"	INTEGER NOT NULL CHECK("CategoriaId" > 0),
	FOREIGN KEY("ProductoId") REFERENCES "Productos"("Id"),
	FOREIGN KEY("CategoriaId") REFERENCES "Categorias"("Id"),
	PRIMARY KEY("ProductoId","CategoriaId")
)