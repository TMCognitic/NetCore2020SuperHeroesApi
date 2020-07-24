CREATE ROLE [AppUser]
Go

GRANT Select, Execute on SCHEMA::[AppUser] To [AppUser]
Go

ALTER ROLE [AppUser]
ADD MEMBER [SuperHeroes]
