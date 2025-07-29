CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;
CREATE TABLE "PojisteneOsoby" (
    "CisloPojistence" INTEGER NOT NULL CONSTRAINT "PK_PojisteneOsoby" PRIMARY KEY AUTOINCREMENT,
    "Jmeno" TEXT NOT NULL,
    "Prijmeni" TEXT NOT NULL,
    "Telefon" TEXT NOT NULL,
    "Vek" INTEGER NOT NULL
);

CREATE TABLE "Pojisteni" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Pojisteni" PRIMARY KEY AUTOINCREMENT,
    "Typ" TEXT NOT NULL,
    "Predmet" TEXT NOT NULL,
    "Castka" TEXT NOT NULL,
    "PlatnostOd" TEXT NOT NULL,
    "PlatnostDo" TEXT NOT NULL,
    "CisloPojistence" INTEGER NOT NULL,
    CONSTRAINT "FK_Pojisteni_PojisteneOsoby_CisloPojistence" FOREIGN KEY ("CisloPojistence") REFERENCES "PojisteneOsoby" ("CisloPojistence") ON DELETE CASCADE
);

CREATE INDEX "IX_Pojisteni_CisloPojistence" ON "Pojisteni" ("CisloPojistence");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250729163843_InitialCreate', '9.0.7');

COMMIT;

