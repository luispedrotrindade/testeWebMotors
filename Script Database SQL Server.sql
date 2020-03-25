create database teste_webmotors
go
use teste_webmotors
go 

create table tb_AnuncioWebmotors(
ID				int identity not null,
marca			varchar (45) not null,
modelo			varchar (45) not null,
versao			varchar (45) not null, 
ano				int not null, 
quilometragem	int not null, 
observacao		text not null 
)
go


create procedure CreateAnuncio
(
@marca			varchar(45),
@modelo			varchar(45),
@versao			varchar(45),
@ano			int,
@quilometragem	int,
@observacao		text
)
as
Begin 
Insert into tb_AnuncioWebmotors (
				 marca			
				,modelo			
				,versao			
				,ano			
				,quilometragem	
				,observacao		
			)
			values(
				 @marca			
				,@modelo			
				,@versao			
				,@ano			
				,@quilometragem	
				,@observacao		
			)
end

go 

create procedure ListAll
as
Begin
select * from tb_AnuncioWebmotors
end

go

create procedure UpdateAnuncio
(
@id				int,
@marca			varchar(45),
@modelo			varchar(45),
@versao			varchar(45),
@ano			int,
@quilometragem	int,
@observacao		varchar(200)
)
as
Begin 
update  tb_AnuncioWebmotors set 
						 marca			= @marca			
						,modelo			= @modelo			
						,versao			= @versao			
						,ano			= @ano				
						,quilometragem	= @quilometragem	
						,observacao		= @observacao		

		where ID = @id
end

go

create procedure DeleteAnuncio
(
@id int
)
as
Begin 
delete from  tb_AnuncioWebmotors where id = @id
end

go

create procedure GetById
(
@id int
)
as
Begin 
select * from  tb_AnuncioWebmotors  where ID = @id
end