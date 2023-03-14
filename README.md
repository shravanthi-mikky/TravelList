# TravelList
Making an app to note the Travel List using ASP.NET core with PostgreSQL, Code first approach of Entity Framework 
create table PayTable(
PaymentId serial PRIMARY KEY,
cardHolder varchar(100),
cardNumber varchar(100),
ExpiryDate varchar(100),
CVV varchar(100)
)
select * from memberstable2
select * from PayTable
insert into PayTable(cardHolder,cardNumber,ExpiryDate,CVV) values ('shiva','1234567801231234','01/24','1234');

create table PayButton(
PayButtonId serial PRIMARY KEY,
ListId int,
result varchar(100)
)
select * from PayButton;
Insert into PayButton(ListId,result) values (3,'Pending')

select * from public."ListTable"

select * from listTable Full outer join PayButton on listTable.ListId = PayButton.ListId;

create table listTable2(
ListId serial PRIMARY KEY,
Place varchar(100),
StartDate varchar(100),
EndDate varchar(100),
Duration varchar(100),
Cost varchar(100),
Members varchar(100),
PayDetails varchar(100)	
)
