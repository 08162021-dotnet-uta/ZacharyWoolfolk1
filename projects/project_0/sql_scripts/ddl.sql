-- DDL = data definition language
use master;
go

-- CREATE
create database StoreApplicationDB;
go

use StoreApplicationDB;
go

create schema Store;
go

create schema Customer;
go


create table Customer.Customer
(
    -- char, nchar, varchar, ncvarchar
    -- tinyint, smallint, int, bigint, money, decimal, numerical
    CustomerId tinyint not null identity(1,1)
    ,Name nvarchar(100) not null
    ,Active bit not null
);

create table Store.Store
(
    StoreId tinyint not null identity(1,1)
    ,Name nvarchar(100) not null
    ,Active bit not null
);

create table Store.Product
(
    ProductId tiynint not null identity(1,1)
    ,Name nvarchar(100) not null
    ,Price money not null
    ,Active bit not null
);

create table Store.Order
(
    OrderId smallint not null identity(1,1)
    ,CustomerId tinyint not null
    ,StoreId tinyint not null
    ,Active bit not null
);

create table Store.OrderProduct
(
    OrderProductId smallint not null identity(1,1)
    ,OrderId smallint not null
    ,ProductId smallint not null
    ,Active bit not null
);

-- ALTER
alter table Customer.Customer
    add constraint PK_Customer primary key (CustomerId);

alter table Store.Store
    add constraint PK_Store primary key (StoreId);

alter table Store.Order
    add constraint PK_Order primary key (OrderId);

alter table Store.OrderProduct
    add constraint PK_OrderProduct primary key (OrderProductId);

alter table Store.Product
    add constraint PK_Product primary key (ProductId);

alter table Store.Order
    add constraint FK_Order_Customer foreign key (CustomerId) references Customer.Customer(CustomerId);

alter table Store.Order
    add constraint FK_Order_Store foreign key (StoreId) references Store.Store(StoreId);

alter table Customer.Customer
    add Active bit not null;

-- DROP
--drop database StoreApplicationDB;
--drop schema Customer;
--drop table Customer.Customer;

-- TRUNCATE
--truncate table Customer.Customer;
