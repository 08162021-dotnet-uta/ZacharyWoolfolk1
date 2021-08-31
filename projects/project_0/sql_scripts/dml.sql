-- DML = data manipulation language
use StoreApplicationDB;
go

-- INSERT
insert into Customer.Customer
  ([Name], Active)
values
  ("fred", 1),
  ("Tyler", 1),
  ("Cory", 1);

insert into Store.Product
  ([Name], Price, Active)
values
  ("computer", 500, 1),
  ("monitor", 200, 1);

insert into Store.Store
  ([Name], Active)
values
  ("Best Buy", 1),
  ("Micro Center", 1);

-- UPDATE
update Customer.Customer
set Name = "derf"
where [Name] = "fred";

-- DELETE
delete Customer.Customer
where Name = "derf";

-- SELECT
--- Order of Execution
--- from
--- where
--- group by
--- having
--- select
--- order by

-- get the product quantity from store

-- create report on all current customers
select [Name]
from Customer.Customer
where Active = 1;

-- create report on most sold products (at least 100)
--ProductOrder(count(productid))
select ProductId
from Store.OrderProduct
group by ProductId
having count(ProductId) > 99;

-- SET

-- JOIN = ability to relate/compose 2 or more tballe based on indexes/keys

-- UNION = ability to relate/compose 2 or more tabble based on datatypes
